using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions
{
    public static class TowerExt
    {
        /// <summary>
        /// Change TowerModel to a different one. Will update display
        /// </summary>
        /// <param name="towerModel">TowerModel to change to</param>
        public static void SetTowerModel(this Tower tower, TowerModel towerModel)
        {
            tower.UpdateRootModel(towerModel);
        }

        /// <summary>
        /// Sell this tower
        /// </summary>
        public static void SellTower(this Tower tower)
        {
            InGame.instance.SellTower(tower.GetTowerSim());
        }

        /// <summary>
        /// Get the TowerToSimulation for this specific Tower
        /// </summary>
        public static TowerToSimulation GetTowerSim(this Tower tower)
        {
            var towerSims = InGame.instance?.GetUnityToSim()?.GetAllTowers();

#if BloonsTD6
            return towerSims.FirstOrDefault(sim => sim.tower == tower);
#elif BloonsAT
            var enumerator = towerSims.GetEnumeratorCollections();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current.Cast<TowerToSimulation>();
                if (item.id == tower.Id)
                    return item;
            }

            return null;
#endif


        }
    }
}