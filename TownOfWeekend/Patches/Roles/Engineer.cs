using TMPro;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles;

public class Engineer : Role
{
    public int UsesLeft;
    public TextMeshPro UsesText;

    public Engineer(PlayerControl player) : base(player)
    {
        Name = "Engineer";
        ImpostorText = () => "Maintain Important Systems On The Ship";
        TaskText = () =>
            CustomGameOptions.GameMode == GameMode.Cultist ? "Vent around" : "Vent around and fix sabotages";
        Color = Colors.Engineer;
        RoleType = RoleEnum.Engineer;
        AddToRoleHistory(RoleType);
        UsesLeft = CustomGameOptions.MaxFixes;
    }

    public bool ButtonUsable => UsesLeft != 0;
}