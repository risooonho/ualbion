﻿using System;
using System.Numerics;
using UAlbion.Core;
using UAlbion.Formats.AssetIds;
using UAlbion.Formats.Assets;
using UAlbion.Game.Entities;
using UAlbion.Game.State;
using Veldrid;

namespace UAlbion.Game.Gui.Inventory
{
    sealed class InventoryBodyPart : InventorySlot
    {
        protected override ItemSlotId SlotId { get; }
        protected override ButtonFrame Frame { get; }
        readonly UiItemSprite _sprite;

        // Inner area 16x16 w/ 1-pixel button frame
        public InventoryBodyPart(PartyCharacterId activeCharacter, ItemSlotId itemSlotId)
            : base(activeCharacter, SlotHandlers)
        {
            SlotId = itemSlotId;
            _sprite = new UiItemSprite(ItemSpriteId.Nothing);
            Frame = new ButtonFrame(new FixedSize(16, 16, _sprite)) { Padding = -1 };
            Children.Add(Frame);
        }

        void Rebuild()
        {
            var state = Resolve<IGameState>();
            var assets = Resolve<IAssetManager>();
            var member = state.Party[ActiveCharacter];
            var slotInfo = member?.Apparent.Inventory.GetSlot(SlotId);

            if(slotInfo == null)
            {
                _sprite.Id = ItemSpriteId.Nothing;
                return;
            }

            var item = assets.LoadItem(slotInfo.Id);
            int sprite = (int)item.Icon + state.TickCount % item.IconAnim;
            _sprite.Id = (ItemSpriteId)sprite;
            // TODO: Show item.Amount
            // TODO: Show broken overlay if item.Flags.HasFlag(ItemSlotFlags.Broken)
        }

        public override int Render(Rectangle extents, int order, Action<IRenderable> addFunc)
        {
            Rebuild();
            return base.Render(extents, order, addFunc);
        }

        public override string ToString() => $"InventoryBodyPart:{SlotId}";
        public override Vector2 GetSize() => Vector2.One * 16;
    }
}