using System.Collections.Generic;
using TownOfWeekend.CrewmateRoles.InvestigatorMod;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Investigator : Role
{
    public readonly List<Footprint> AllPrints = new();


    public Investigator(PlayerControl player) : base(player)
    {
        Name = "Investigator";
        ImpostorText = () => "Find All Impostors By Examining Footprints";
        TaskText = () => "You can see everyone's footprints";
        Color = Colors.Investigator;
        RoleType = RoleEnum.Investigator;
        AddToRoleHistory(RoleType);
        Scale = 1.4f;
    }
}