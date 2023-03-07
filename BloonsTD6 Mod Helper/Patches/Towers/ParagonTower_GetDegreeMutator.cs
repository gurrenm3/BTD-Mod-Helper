using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(ParagonTower), nameof(ParagonTower.GetDegreeMutator))]
internal class ParagonTower_GetDegreeMutator
{
    [HarmonyPrefix]
    internal static bool Prefix(ref ParagonTower __instance, ref float investment, ref ParagonTowerModel.PowerDegreeMutator __result)
    {
        var result = true;
        var unref__instance = __instance;
        var unrefinvestment = investment;
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod=> result &= mod.PreParagonDegreeMutatorLoaded(ref unref__instance, ref unrefinvestment, ref unref__result));
        __instance = unref__instance;
        investment = unrefinvestment;
        __result = unref__result;
        
        return result;
    }
    
    
    [HarmonyPostfix]
    internal static void Postfix(ParagonTower __instance, float investment, ref ParagonTowerModel.PowerDegreeMutator __result)
    {
        if (__instance.tower?.towerModel?.GetModTower() is {ShouldCreateParagon: true} modTower)
        {
            modTower.paragonUpgrade?.ModifyPowerDegreeMutator(__result, investment, __result.degree);
        }
        
        var unref__result = __result;
        
        ModHelper.PerformAdvancedModHook(mod=> mod.PostParagonDegreeMutatorLoaded(__instance, investment, ref unref__result));
        
        __result = unref__result;
    }
}