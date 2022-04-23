using Assets.Scripts.Simulation.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(Tower), nameof(Tower.Hilight))]
internal class Tower_Highlight
{
    [HarmonyPostfix]
    internal static void Postfix(Tower __instance)
    {
        ModHelper.PerformHook(mod => mod.OnTowerSelected(__instance));
    }
}