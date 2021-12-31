using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Towers
{
    [HarmonyPatch(typeof(TowerManager), nameof(TowerManager.UpgradeTower))]
    internal class TowerManager_UpgradeTower
    {
        [HarmonyPrefix]
        internal static bool Prefix(Tower tower, TowerModel def, ref string __state)
        {
            __state = null;
            foreach (var upgrade in def.appliedUpgrades)
            {
                if (!tower.towerModel.appliedUpgrades.Contains(upgrade))
                {
                    __state = upgrade;
                }
            }

            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Tower tower, TowerModel def, string __state)
        {
            if (__state != null)
            {
                ModHelper.PerformHook(mod => mod.OnTowerUpgraded(tower, __state, def));
            }
        }
    }
}