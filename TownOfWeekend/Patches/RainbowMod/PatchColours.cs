using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;

namespace TownOfWeekend.RainbowMod;

[HarmonyPatch(typeof(TranslationController), nameof(TranslationController.GetString), typeof(StringNames),
    typeof(Il2CppReferenceArray<Object>))]
public class PatchColours
{
    public static bool Prefix(ref string __result, [HarmonyArgument(0)] StringNames name)
    {
        var newResult = (int)name switch
        {
            999983 => "Watermelon",
            999984 => "Chocolate",
            999985 => "Sky Blue",
            999986 => "Beige",
            999987 => "Magenta",
            999988 => "Turquoise",
            999989 => "Lilac",
            999990 => "Olive",
            999991 => "Azure",
            999992 => "Plum",
            999993 => "Jungle",
            999994 => "Mint",
            999995 => "Chartreuse",
            999996 => "Macau",
            999997 => "Tawny",
            999998 => "Gold",
            999999 => "Rainbow",
            _ => null
        };
        if (newResult != null)
        {
            __result = newResult;
            return false;
        }

        return true;
    }
}