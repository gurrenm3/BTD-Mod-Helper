using System.Linq;
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
        if (__instance.towerAdded && !__instance.tower.IsDestroyed)
        {
            var baseId = __instance.createTowerModel.towerModel.baseId;
            var tower = __instance.Sim.towerManager
                .GetChildTowers(__instance.tower)
                .ToList()
                .OrderBy(t => t.createdAt)
                .FirstOrDefault(tower => tower.towerModel.baseId == baseId);
            if (tower != null)
            {
                __instance.Sim.DestroyTower(tower, tower.owner);
            }
        }
    }
}