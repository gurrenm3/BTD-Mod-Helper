using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.OnDestroy))]
internal class Tower_Destroy
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance)
    {
        ModHelper.PerformHook(mod => mod.OnTowerDestroyed(__instance));
    }
}