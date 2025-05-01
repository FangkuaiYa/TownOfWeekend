using System.Linq;
using HarmonyLib;
using TownOfWeekend.Roles;

namespace TownOfWeekend.Patches;

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.SetTasks))]
internal class SetTasks
{
    public static void Postfix(PlayerControl __instance)
    {
        var role = Role.GetRole(__instance);
        if (role.Faction != Faction.Crewmates && role.RoleType != RoleEnum.Phantom) return;

        var taskinfos = __instance.Data.Tasks.ToArray();
        var tasksLeft = taskinfos.Count(x => !x.Complete);
        var totalTasks = taskinfos.Count();
    }
}