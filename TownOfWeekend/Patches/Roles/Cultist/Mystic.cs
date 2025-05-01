using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Cultist;

public class CultistMystic : Role
{
    public CultistMystic(PlayerControl player) : base(player)
    {
        Name = "Mystic";
        ImpostorText = () => "Understand When Someone Gets Converted";
        TaskText = () => "Know when someone gets converted";
        Color = Colors.Mystic;
        RoleType = RoleEnum.CultistMystic;
        AddToRoleHistory(RoleType);
    }
}