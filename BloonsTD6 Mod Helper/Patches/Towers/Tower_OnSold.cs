using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.OnSold))]
internal class Tower_OnSold
{
    [HarmonyPrefix]
    internal static bool Prefix(ref Tower __instance, ref float amount)
    {
        var result = true;
        var unref__instance = __instance;
        var unrefamount = amount;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreTowerSold(ref unref__instance, ref unrefamount));
        __instance = unref__instance;
        amount = unrefamount;
        
        return result;
    }
    
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance, float amount)
    {
        ModHelper.PerformHook(mod => mod.OnTowerSold(__instance, amount));
    }
}