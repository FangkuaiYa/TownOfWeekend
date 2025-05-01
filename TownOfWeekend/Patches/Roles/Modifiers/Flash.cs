using TownOfWeekend.Extensions;
using TownOfWeekend.Patches;

namespace TownOfWeekend.Roles.Modifiers;

public class Flash : Modifier, IVisualAlteration
{
    public Flash(PlayerControl player) : base(player)
    {
        Name = "Flash";
        TaskText = () => "Superspeed!";
        Color = Colors.Flash;
        ModifierType = ModifierEnum.Flash;
    }

    public bool TryGetModifiedAppearance(out VisualAppearance appearance)
    {
        appearance = Player.GetDefaultAppearance();
        appearance.SpeedFactor = CustomGameOptions.FlashSpeed;
        return true;
    }
}