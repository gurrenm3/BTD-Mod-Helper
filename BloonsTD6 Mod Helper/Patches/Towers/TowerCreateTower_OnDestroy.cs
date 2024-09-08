using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
namespace BTD_Mod_Helper.Patches.Towers;

/// <summary>
/// NK never handled instances where a TowerCreateTower behavior was removed from the tower while it was still around.
/// In this case, it ought to delete its created subtower.
/// </summary>
[HarmonyPatch(typeof(TowerCreateTower), nameof(TowerCreateTower.OnDestroy))]
internal static class TowerCreateTower_OnDestroy
{
    [HarmonyPrefix]
    private static void Prefix(TowerCreateTower __instance)
    {
        if (__instance.tower is {IsDestroyed: false} && __instance.createdTower is {IsDestroyed: false})
        {
            __instance.Sim.DestroyTower(__instance.createdTower, __instance.createdTower.owner);
        }
    }
}