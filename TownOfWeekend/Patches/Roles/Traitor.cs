using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Traitor : Role
{
    public RoleEnum formerRole = new();

    public Traitor(PlayerControl player) : base(player)
    {
        Name = "Traitor";
        ImpostorText = () => "";
        TaskText = () => "Betray the Crewmates!";
        Color = Colors.Impostor;
        RoleType = RoleEnum.Traitor;
        AddToRoleHistory(RoleType);
        Faction = Faction.Impostors;
    }
}