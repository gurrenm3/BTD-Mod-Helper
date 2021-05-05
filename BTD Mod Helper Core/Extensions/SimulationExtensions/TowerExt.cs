using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Simulation.Factory;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerExt
    {
        /// <summary>
        /// (Cross-Game compatible) Change TowerModel to a different one. Will update display
        /// </summary>
        /// <param name="towerModel">TowerModel to change to</param>
        public static void SetTowerModel(this Tower tower, TowerModel towerModel)
        {
            tower.UpdateRootModel(towerModel);
        }

        /// <summary>
        /// (Cross-Game compatible) Return the DisplayNode for this Tower
        /// </summary>
        /// <returns></returns>
        public static DisplayNode GetDisplayNode(this Tower tower)
        {
            return tower.Node;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the UnityDisplayNode for this Tower. Is apart of DisplayNode. Needed to modify sprites
        /// </summary>
        /// <returns></returns>
        public static UnityDisplayNode GetUnityDisplayNode(this Tower tower)
        {
            return tower.GetDisplayNode()?.graphic;
        }

        /// <summary>
        /// (Cross-Game compatible) Sell this tower
        /// </summary>
        public static void SellTower(this Tower tower)
        {
            InGame.instance.SellTower(tower.GetTowerSim());
        }

        /// <summary>
        /// (Cross-Game compatible) Return the TowerToSimulation for this specific Tower
        /// </summary>
        public static TowerToSimulation GetTowerSim(this Tower tower)
        {
            var towerSims = InGame.instance?.GetUnityToSimulation()?.GetAllTowers();

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

        /// <summary>
        /// (Cross-Game compatible) Return the Factory that creates Towers
        /// </summary>
        /// <param name="tower"></param>
        /// <returns></returns>
        public static Factory<Tower> GetFactory(this Tower tower)
        {
            return InGame.instance.GetFactory<Tower>();
        }
    }
}