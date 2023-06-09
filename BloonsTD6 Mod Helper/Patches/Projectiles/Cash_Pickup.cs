using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
namespace BTD_Mod_Helper.Patches.Projectiles;

[HarmonyPatch(typeof(Cash), nameof(Cash.Pickup))]
internal static class Cash_Pickup
{
    [HarmonyPostfix]
    private static void Postfix(Cash __instance, float __result)
    {
        ModHelper.PerformHook(mod => mod.OnBananaPickup(__instance, __result));
    }
}