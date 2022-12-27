using System.Linq;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
namespace BTD_Mod_Helper.Patches.Sim;

/// <summary>
/// This is a pretty specific patch that addresses the following:
/// <br/>
/// In the default game, the tower id specified in an UpgradePathModel is ONLY used in the UpgradeScreen for w/e reason.
/// For actually upgrading the tower, it ignores it and just tries to find the next tower by its base id and tier.
/// This patch changes it so that it actually respects what tower is being asked for in the UpgradePathModel.
/// <br/>
/// This has no effect at all for vanilla towers, but allows modded towers to more easily do funky stuff with upgrades.
/// </summary>
[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.UpgradeTower_Impl))]
internal static class UnityToSimulation_UpgradeTower_Impl
{
    [HarmonyPrefix]
    private static void Prefix(UnityToSimulation __instance, ObjectId id, int pathIndex)
    {
        var towerManager = __instance.simulation.towerManager;
        var tower = towerManager.GetTowerById(id).towerModel;
        var upgrade = tower.upgrades.FirstOrDefault(model => model.GetUpgrade()?.path == pathIndex);
        if (upgrade != null)
        {
            GameModel_GetTower.overrideTower = upgrade.tower;
        }
    }

    [HarmonyPostfix]
    private static void Postfix()
    {
        GameModel_GetTower.overrideTower = null;
    }
}

[HarmonyPatch(typeof(GameModel), nameof(GameModel.GetTower))]
internal static class GameModel_GetTower
{
    internal static string overrideTower;

    [HarmonyPrefix]
    private static bool Prefix(GameModel __instance, ref TowerModel __result)
    {
        if (overrideTower != null)
        {
            __result = __instance.GetTowerWithName(overrideTower);
            overrideTower = null;
            return false;
        }

        return true;
    }
}