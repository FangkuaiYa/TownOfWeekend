using AmongUs.Data.Player;
using HarmonyLib;

namespace TownOfWeekend;

[HarmonyPatch(typeof(PlayerBanData), nameof(PlayerBanData.IsBanned), MethodType.Getter)]
public class IsBanned
{
    public static void Postfix(out bool __result)
    {
        __result = false;
    }
}