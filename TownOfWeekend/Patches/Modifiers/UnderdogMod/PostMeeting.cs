using HarmonyLib;
using TownOfWeekend.Roles.Modifiers;

namespace TownOfWeekend.Modifiers.UnderdogMod;

[HarmonyPatch(typeof(ExileController), nameof(ExileController.WrapUp))]
public static class HUDClose
{
    public static void Postfix()
    {
        var modifier = Modifier.GetModifier(PlayerControl.LocalPlayer);
        if (modifier?.ModifierType == ModifierEnum.Underdog)
            ((Underdog)modifier).SetKillTimer();
    }
}