using System;
using System.Collections.Generic;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Miner : Role
{
    public readonly List<Vent> Vents = new();

    public KillButton _mineButton;
    public DateTime LastMined;


    public Miner(PlayerControl player) : base(player)
    {
        Name = "Miner";
        ImpostorText = () => "From The Top, Make It Drop, That's A Vent";
        TaskText = () => "Place vents around the map";
        Color = Colors.Impostor;
        LastMined = DateTime.UtcNow;
        RoleType = RoleEnum.Miner;
        AddToRoleHistory(RoleType);
        Faction = Faction.Impostors;
    }

    public bool CanPlace { get; set; }
    public Vector2 VentSize { get; set; }

    public KillButton MineButton
    {
        get => _mineButton;
        set
        {
            _mineButton = value;
            ExtraButtons.Clear();
            ExtraButtons.Add(value);
        }
    }

    public float MineTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - LastMined;
        var num = CustomGameOptions.MineCd * 1000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }
}