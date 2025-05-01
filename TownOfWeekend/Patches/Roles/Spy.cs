using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Spy : Role
{
    public Spy(PlayerControl player) : base(player)
    {
        Name = "Spy";
        ImpostorText = () => "Snoop Around And Find Stuff Out";
        TaskText = () => "Gain extra information on the Admin Table";
        Color = Colors.Spy;
        RoleType = RoleEnum.Spy;
        AddToRoleHistory(RoleType);
    }
}