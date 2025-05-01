using System.Linq;
using AmongUs.Data;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TownOfWeekend;

[HarmonyPatch(typeof(HatManager), nameof(HatManager.GetUnlockedHats))]
public class UnlockHats
{
    public static bool Prefix(HatManager __instance, ref Il2CppReferenceArray<HatData> __result)
    {
        var array = (
            from h in __instance.allHats.ToArray()
            where h.Free || DataManager.Player.Purchases.GetPurchase(h.ProductId, h.BundleId)
            select h
            into o
            orderby o.displayOrder descending, o.name
            select o).ToArray();
        __result = array;
        return false;
    }
}