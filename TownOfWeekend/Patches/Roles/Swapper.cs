using System.Collections.Generic;
using TownOfWeekend.Patches;
using UnityEngine;

namespace TownOfWeekend.Roles;

public class Swapper : Role
{
    public readonly List<GameObject> Buttons = new();

    public readonly List<bool> ListOfActives = new();


    public Swapper(PlayerControl player) : base(player)
    {
        Name = "Swapper";
        ImpostorText = () => "Swap The Votes Of Two People";
        TaskText = () => "Swap two people's votes to save the Crew!";
        Color = Colors.Swapper;
        RoleType = RoleEnum.Swapper;
        AddToRoleHistory(RoleType);
    }
}