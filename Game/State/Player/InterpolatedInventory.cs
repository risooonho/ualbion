﻿using System;
using System.Collections.Generic;
using UAlbion.Core;
using UAlbion.Formats.Assets;

namespace UAlbion.Game.State.Player
{
    public class InterpolatedInventory : ICharacterInventory
    {
        readonly Func<ICharacterInventory> _a;
        readonly Func<ICharacterInventory> _b;
        readonly Func<float> _getLerp;

        public InterpolatedInventory(Func<ICharacterInventory> a, Func<ICharacterInventory> b, Func<float> getLerp)
        {
            _a = a;
            _b = b;
            _getLerp = getLerp;
        }

        public ushort Gold => (ushort)Util.Lerp(_a().Gold, _b().Gold, _getLerp());
        public ushort Rations => (ushort)Util.Lerp(_a().Rations, _b().Rations, _getLerp());
        public ItemSlot Neck => _b().Neck;
        public ItemSlot Head => _b().Head;
        public ItemSlot Tail => _b().Tail;
        public ItemSlot LeftHand => _b().LeftHand;
        public ItemSlot Chest => _b().Chest;
        public ItemSlot RightHand => _b().RightHand;
        public ItemSlot LeftFinger => _b().LeftFinger;
        public ItemSlot Feet => _b().Feet;
        public ItemSlot RightFinger => _b().RightFinger;
        public ItemSlot[] Slots => _b().Slots;
        public IEnumerable<ItemSlot> EnumerateAll() => _b().EnumerateAll();
        public IEnumerable<ItemSlot> EnumerateBodyParts() => _b().EnumerateBodyParts();
        public ItemSlot GetSlot(ItemSlotId itemSlotId) => _b().GetSlot(itemSlotId);
    }
}