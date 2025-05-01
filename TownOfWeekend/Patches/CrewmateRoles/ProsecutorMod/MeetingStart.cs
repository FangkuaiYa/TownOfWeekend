using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.CrewmateRoles.ProsecutorMod;

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.StartMeeting))]
internal class StartMeetingPatch
{
    public static void Prefix(PlayerControl __instance, [HarmonyArgument(0)] NetworkedPlayerInfo meetingTarget)
    {
        if (__instance == null) return;
        foreach (var pros in Role.GetRoles(RoleEnum.Prosecutor))
        {
            var prosRole = (Prosecutor)pros;
            prosRole.StartProsecute = false;
        }
    }
}