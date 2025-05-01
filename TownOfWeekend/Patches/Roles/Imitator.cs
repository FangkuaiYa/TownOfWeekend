using System.Collections.Generic;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Imitator : Role
{
    public readonly List<GameObject> Buttons = new();

    public readonly List<bool> ListOfActives = new();
    public PlayerControl confessingPlayer = null;
    public PlayerControl ImitatePlayer = null;

    public List<RoleEnum> trappedPlayers = null;


    public Imitator(PlayerControl player) : base(player)
    {
        Name = "Imitator";
        ImpostorText = () => "Use The True-Hearted Dead To Benefit The Crew";
        TaskText = () => "Use dead roles to benefit the crew";
        Color = Colors.Imitator;
        RoleType = RoleEnum.Imitator;
        AddToRoleHistory(RoleType);
    }
}