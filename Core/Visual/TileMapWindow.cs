﻿using System;
using System.Numerics;
using Veldrid.Utilities;

namespace UAlbion.Core.Visual
{
    public class TileMapWindow : IRenderable
    {
        public string Name => TileMap.Name;
        public int RenderOrder { get => TileMap.RenderOrder; set => throw new NotImplementedException(); }

        public Type Renderer => TileMap.Renderer;
        public Matrix4x4 Transform => Matrix4x4.Identity;

        public int Offset { get; }
        public int Length { get; }
        public TileMap TileMap { get; }
        public int InstanceBufferId { get; set; }

        public TileMapWindow(TileMap tileMap, int offset, int length)
        {
            TileMap = tileMap;
            Offset = offset;
            Length = length;
        }
    }
}