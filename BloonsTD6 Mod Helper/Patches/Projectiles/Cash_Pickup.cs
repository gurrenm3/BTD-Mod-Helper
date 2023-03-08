using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
namespace BTD_Mod_Helper.Patches.Projectiles;

[HarmonyPatch(typeof(Cash), nameof(Cash.Pickup))]
internal static class Cash_Pickup
{
    [HarmonyPrefix]
    private static bool Prefix(ref Cash __instance, ref float __result)
    {
        var result = true;
        var unref__instance = __instance;
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PreCashPickup(ref unref__instance, ref unref__result));
        __instance = unref__instance;
        __result = unref__result;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(Cash __instance, ref float __result)
    {
        var unref__result = __result;
        ModHelper.PerformAdvancedModHook(mod => mod.PostCashPickup(__instance, ref unref__result));
        __result = unref__result;
    }
}