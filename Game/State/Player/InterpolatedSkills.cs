﻿using System;
using UAlbion.Core;
using UAlbion.Formats.Assets;

namespace UAlbion.Game.State.Player
{
    public class InterpolatedSkills : ICharacterSkills
    {
        readonly Func<ICharacterSkills> _a;
        readonly Func<ICharacterSkills> _b;
        readonly Func<float> _getLerp;

        public InterpolatedSkills(Func<ICharacterSkills> a, Func<ICharacterSkills> b, Func<float> getLerp)
        {
            _a = a;
            _b = b;
            _getLerp = getLerp;
        }

        public ushort CloseCombat => (ushort)Util.Lerp(_a().CloseCombat, _b().CloseCombat, _getLerp());
        public ushort RangedCombat => (ushort)Util.Lerp(_a().RangedCombat, _b().RangedCombat, _getLerp());
        public ushort CriticalChance => (ushort)Util.Lerp(_a().CriticalChance, _b().CriticalChance, _getLerp());
        public ushort LockPicking => (ushort)Util.Lerp(_a().LockPicking, _b().LockPicking, _getLerp());
        public ushort CloseCombatMax => (ushort)Util.Lerp(_a().CloseCombatMax, _b().CloseCombatMax, _getLerp());
        public ushort RangedCombatMax => (ushort)Util.Lerp(_a().RangedCombatMax, _b().RangedCombatMax, _getLerp());
        public ushort CriticalChanceMax => (ushort)Util.Lerp(_a().CriticalChanceMax, _b().CriticalChanceMax, _getLerp());
        public ushort LockPickingMax => (ushort)Util.Lerp(_a().LockPickingMax, _b().LockPickingMax, _getLerp());
    }
}