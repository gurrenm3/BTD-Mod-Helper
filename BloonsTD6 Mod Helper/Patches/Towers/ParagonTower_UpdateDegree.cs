using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(ParagonTower), nameof(ParagonTower.UpdateDegree))]
internal class ParagonTower_UpdateDegree
{
    [HarmonyPrefix]
    internal static bool Prefix(ref ParagonTower __instance)
    {
        var result = true;
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PreParagonDegreeUpdated(ref unref__instance));
        __instance = unref__instance;
        
        return result;
    }
    [HarmonyPostfix]
    internal static void Postfix(ParagonTower __instance)
    {
        if (__instance.tower?.towerModel?.GetModTower() is ModTower modTower && modTower.ShouldCreateParagon)
        {
            modTower.paragonUpgrade?.OnDegreeSet(__instance.tower, __instance.GetCurrentDegree());
        }
        
        ModHelper.PerformAdvancedModHook(mod=> mod.PostParagonDegreeUpdated(__instance));
    }
}