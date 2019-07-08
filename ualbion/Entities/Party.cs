﻿using System.Collections.Generic;
using PixelEngine;

namespace UAlbion.Entities
{
    enum Spell
    {
        // DjiKas
        ThornSnare,
        Hurry,
        ViewOfLife,
        FrostSplinter,
        FrostCrystal,
        FrostAvalanche,
        LightHealing,
        BlindingSpark,
        BlindingRay,
        BlindingStorm,
        SleepSpores,
        ThornTrap,
        RemoveTrap,
        HealIntoxication,
        HealBlindness,
        HealPoisoning,
        Fungification,
        Light,

        // Druid
        Berserk,
        BanishDemon,
        BanishDemons,
        DemonExodus,
        SmallFireball,
        MagicShield,
        Healing,
        Boasting,
        Shock,
        Panic,

        // Enlightened One
        Regeneration,
        MapView,
        Teleporter,
        // Healing, // Shared or dupe name?
        QuickWithdrawal,
        Irritation,
        Recuperation,

        // Kenget Kamulos
        Fireball,
        LightningStrike,
        FireRain,
        Thunderbolt,
        FireHail,
        Thunderstorm,
        PersonalProtection
    }

    enum Direction
    {
        North, East, South, West
    }

    internal class Party
    {
        const int PositionHistoryCount = 40;

        readonly IList<Player> _players = new List<Player>();
        readonly Point[] _positions = new Point[PositionHistoryCount];
        Direction _facing;
        int _activePlayer;
        bool _hasClock;
        bool _hasProximityDetector;
    }
}