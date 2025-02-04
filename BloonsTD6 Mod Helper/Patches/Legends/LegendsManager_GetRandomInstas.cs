using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Unity.UI_New.Legends;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch]
internal class LegendsManager__GetRandomInstas_b__34_1
{
    private static System.Collections.Generic.IEnumerable<MethodBase> TargetMethods() => AccessTools
        .GetDeclaredMethods(typeof(LegendsManager)).Where(method =>
            method.Name.Contains("_" + nameof(LegendsManager.GetRandomInstas) + "_"));

    [HarmonyPrefix]
    internal static bool Prefix(LegendsManager __instance, string x, ref bool __result)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(x, out var tower) && !tower.IncludeInRogueLegends)
        {
            __result = false;
            return false;
        }

        return true;
    }
}

[HarmonyPatch(typeof(LegendsManager), nameof(LegendsManager.GetRandomInstas))]
internal static class LegendsManager_GetRandomInstas
{
    [HarmonyPostfix]
    internal static void Postfix(List<RogueInstaMonkey> __result)
    {
        foreach (var rogueInstaMonkey in __result)
        {
            if (ModTowerHelper.ModTowerCache.TryGetValue(rogueInstaMonkey.baseId, out var tower))
            {
                for (var i = 0; i < rogueInstaMonkey.tiers.Count; i++)
                {
                    rogueInstaMonkey.tiers[i] = Math.Min(rogueInstaMonkey.tiers[i], tower.TierMaxes[i]);
                }
            }
        }
    }
}