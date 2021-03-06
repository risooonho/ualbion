﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UAlbion.Api;
using UAlbion.Core;
using UAlbion.Core.Events;
using UAlbion.Core.Textures;
using UAlbion.Core.Visual;
using UAlbion.Formats.AssetIds;
using UAlbion.Formats.Assets;
using UAlbion.Formats.Assets.Labyrinth;
using UAlbion.Game.Events;
using UAlbion.Game.State;

namespace UAlbion.Game.Entities
{
    public class MapRenderable3D : Component
    {
        const int TicksPerFrame = 8;
        readonly MapDataId _mapId;
        readonly MapData3D _mapData;
        readonly LabyrinthData _labyrinthData;
        readonly Vector3 _tileSize;
        readonly IDictionary<int, IList<int>> _tilesByDistance = new Dictionary<int, IList<int>>();
        TileMap _tilemap;
        bool _isSorting = false;

        static readonly HandlerSet Handlers = new HandlerSet(
            H<MapRenderable3D, RenderEvent>((x, e) => x.Render(e)),
            H<MapRenderable3D, PostUpdateEvent>((x, _) => x.PostUpdate()),
            H<MapRenderable3D, SortMapTilesEvent>((x, e) => x._isSorting = e.IsSorting),
            H<MapRenderable3D, LoadPaletteEvent>((x, e) => {})
        );

        public MapRenderable3D(MapDataId mapId, MapData3D mapData, LabyrinthData labyrinthData, Vector3 tileSize) : base(Handlers)
        {
            _mapId = mapId;
            _mapData = mapData;
            _labyrinthData = labyrinthData;
            _tileSize = tileSize;
        }

        public override void Subscribed()
        {
            Raise(new LoadPaletteEvent(_mapData.PaletteId));

            if (_tilemap != null)
                return;

            var assets = Resolve<IAssetManager>();
            _tilemap = new TileMap(
                _mapId.ToString(),
                (int)DrawLayer.Background, 
                _tileSize,
                _mapData.Width, _mapData.Height,
                Resolve<IPaletteManager>());

            for(int i = 0; i < _labyrinthData.FloorAndCeilings.Count; i++)
            {
                var floorInfo = _labyrinthData.FloorAndCeilings[i];
                ITexture floor = floorInfo?.TextureNumber == null ? null : assets.LoadTexture(floorInfo.TextureNumber.Value);
                _tilemap.DefineFloor(i + 1, floor);
            }

            for (int i = 0; i < _labyrinthData.Walls.Count; i++)
            {
                var wallInfo = _labyrinthData.Walls[i];
                if (wallInfo?.TextureNumber == null)
                    continue;

                ITexture wall = assets.LoadTexture(wallInfo.TextureNumber.Value);
                bool isAlphaTested = (wallInfo.Properties & Wall.WallFlags.AlphaTested) != 0;
                _tilemap.DefineWall(i + 1, wall, 0, 0, wallInfo.TransparentColour, isAlphaTested);

                foreach(var overlayInfo in wallInfo.Overlays)
                {
                    if (!overlayInfo.TextureNumber.HasValue)
                        continue;

                    var overlay = assets.LoadTexture(overlayInfo.TextureNumber.Value);
                    _tilemap.DefineWall(i + 1, overlay, overlayInfo.XOffset, overlayInfo.YOffset, wallInfo.TransparentColour, isAlphaTested);
                }
            }

        }

        void SetTile(int index, int order, int ticks)
        {
            byte i = (byte)(index % _mapData.Width);
            byte j = (byte)(index / _mapData.Width);
            byte floorIndex = (byte)_mapData.Floors[index];
            byte ceilingIndex = (byte)_mapData.Ceilings[index];
            int contents = _mapData.Contents[index];
            byte wallIndex = (byte)(contents < 100 || contents - 100 >= _labyrinthData.Walls.Count
                ? 0
                : contents - 100);

            _tilemap.Set(order, i, j, floorIndex, ceilingIndex, wallIndex, ticks / TicksPerFrame);
        }

        void PostUpdate()
        {
            var state = Resolve<IGameState>();
            if (state == null)
                return;

            using var _ = PerfTracker.FrameEvent("Update tilemap");
            foreach (var list in _tilesByDistance.Values)
                list.Clear();

            var scene = Resolve<ISceneManager>().ActiveScene;
            var cameraTilePosition = scene.Camera.Position;

            var map = Resolve<IMapManager>().Current;
            if (map != null)
                cameraTilePosition /= map.TileSize;

            int cameraTileX = (int)cameraTilePosition.X;
            int cameraTileY = (int)cameraTilePosition.Y;

            for (int j = 0; j < _mapData.Height; j++)
            {
                for (int i = 0; i < _mapData.Width; i++)
                {
                    int distance = Math.Abs(j - cameraTileY) + Math.Abs(i - cameraTileX);
                    if(!_tilesByDistance.TryGetValue(distance, out var list))
                    {
                        list = new List<int>();
                        _tilesByDistance[distance] = list;
                    }

                    int index = j * _mapData.Width + i;
                    if(_isSorting)
                        list.Add(index);
                    else
                        SetTile(index, index, state.TickCount);
                }
            }

            if (_isSorting)
            {
                int order = 0;
                foreach (var distance in _tilesByDistance.OrderByDescending(x => x.Key).ToList())
                {
                    if (distance.Value.Count == 0)
                    {
                        _tilesByDistance.Remove(distance.Key);
                        continue;
                    }

                    foreach (var index in distance.Value)
                    {
                        SetTile(index, order, state.TickCount);
                        order++;
                    }
                }
            }
        }

        void Render(RenderEvent e)
        {
            e.Add(_tilemap); /*
            // Split map rendering into one render call per distance group for debugging
            int offset = 0;
            foreach (var distance in _tilesByDistance.OrderByDescending(x => x.Key))
            {
                e.Add(new TileMapWindow(_tilemap, offset, distance.Value.Count));
                offset += distance.Value.Count;
            }
            //*/
        }
    }
}
