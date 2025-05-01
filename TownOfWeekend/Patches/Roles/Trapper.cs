using System;
using System.Collections.Generic;
using TMPro;
using TownOfWeekend.CrewmateRoles.TrapperMod;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Trapper : Role
{
    public static Material trapMaterial = TownOfWeekendPlugin.bundledAssets.Get<Material>("trap");

    public List<RoleEnum> trappedPlayers;

    public List<Trap> traps = new();
    public int UsesLeft;
    public TextMeshPro UsesText;

    public Trapper(PlayerControl player) : base(player)
    {
        Name = "Trapper";
        ImpostorText = () => "Catch Killers In The Act";
        TaskText = () => "Place traps around the map";
        Color = Colors.Trapper;
        RoleType = RoleEnum.Trapper;
        LastTrapped = DateTime.UtcNow;
        trappedPlayers = new List<RoleEnum>();
        AddToRoleHistory(RoleType);

        UsesLeft = CustomGameOptions.MaxTraps;
    }

    public DateTime LastTrapped { get; set; }

    public bool ButtonUsable => UsesLeft != 0;

    public float TrapTimer()
    {
        var utcNow = DateTime.UtcNow;
        var timeSpan = utcNow - LastTrapped;
        var num = CustomGameOptions.TrapCooldown * 1000f;
        var flag2 = num - (float)timeSpan.TotalMilliseconds < 0f;
        if (flag2) return 0;
        return (num - (float)timeSpan.TotalMilliseconds) / 1000f;
    }
}