using HarmonyLib;

namespace TownOfWeekend.Patches;

public static class CanMove
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CanMove), MethodType.Getter)]
    internal static class CanMovePatch
    {
        public static bool Prefix(PlayerControl __instance, ref bool __result)
        {
            __result = __instance.moveable
                       && !Minigame.Instance
                       && !__instance.shapeshifting
                       && (!HudManager.InstanceExists
                           || (!HudManager.Instance.Chat.IsOpenOrOpening
                               && !HudManager.Instance.KillOverlay.IsOpen
                               && !HudManager.Instance.GameMenu.IsOpen))
                       /*&& (!ControllerManager.Instance || !ControllerManager.Instance.IsUiControllerActive)*/
                       && (!MapBehaviour.Instance || !MapBehaviour.Instance.IsOpenStopped)
                       && !MeetingHud.Instance
                       && !PlayerCustomizationMenu.Instance
                       && !ExileController.Instance
                       && !IntroCutscene.Instance;

            return false;
        }
    }
}