using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Api
{
    public abstract partial class ModContent
    {
        /// <summary>
        /// Returns a ModMap based on it's name.
        /// </summary>
        /// <param name="mapName"></param>
        /// <returns></returns>
        public static ModMap GetModMap(string mapName)
        {            
            return GetInstancesWithBaseType<ModMap>()?.FirstOrDefault(map => map.Name == mapName);
        }

        /// <summary>
        /// Gets the ID for the given ModGameMode
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GameModeId<T>() where T : ModGameMode
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// Gets the ID for the given ModRoundSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string RoundSetId<T>() where T : ModRoundSet
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// Gets the internal tower name/id for a ModTower
        /// </summary>
        /// <param name="top">The top path tier</param>
        /// <param name="mid">The middle path tier</param>
        /// <param name="bot">The bottom path tier</param>
        /// <typeparam name="T">The ModTower type</typeparam>
        /// <returns>The tower name/id</returns>
        public static string TowerID<T>(int top = 0, int mid = 0, int bot = 0) where T : ModTower
        {
            return GetInstance<T>().TowerId(new[] { top, mid, bot });
        }

        /// <summary>
        /// Gets the TowerModel for a ModTower at a specific tier level
        /// </summary>
        /// <param name="top">The top path tier</param>
        /// <param name="mid">The middle path tier</param>
        /// <param name="bot">The bottom path tier</param>
        /// <typeparam name="T">The ModTower type</typeparam>
        /// <returns>The tower name/id</returns>
        public static TowerModel GetTowerModel<T>(int top = 0, int mid = 0, int bot = 0) where T : ModTower
        {
            return Game.instance.model.GetTowerFromId(TowerID<T>(top, mid, bot));
        }

        /// <summary>
        /// Gets the internal upgrade name/id for a ModUpgrade
        /// </summary>
        /// <typeparam name="T">The ModUpgrade type</typeparam>
        /// <returns>The upgrade name/id</returns>
        public static string UpgradeID<T>() where T : ModUpgrade
        {
            return GetInstance<T>().Id;
        }

        /// <summary>
        /// Gets the internal tower set id for a given TowerSet
        /// </summary>
        /// <typeparam name="T">The ModUpgrade type</typeparam>
        /// <returns>The upgrade name/id</returns>
        public static string TowerSet<T>() where T : ModTowerSet
        {
            return GetInstance<T>().Id;
        }
    }
}
