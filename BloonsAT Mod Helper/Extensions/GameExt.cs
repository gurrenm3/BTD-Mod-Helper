using Assets.Scripts;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.TowerGraph;
using Assets.Scripts.Models.Towers.TowerGraph.DataModel;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.Player.Powers;
using Assets.Scripts.Unity.Towers;
using Assets.Scripts.Unity.Towers.Trinkets;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using Il2CppSystem.Collections.Generic;
using Ninjakiwi.LiNK;
using Ninjakiwi.Players.Utils;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {
        /// <summary>
        /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game
        /// </summary>
        public static Assets.Scripts.Unity.Display.DisplayFactory GetDisplayFactory(this Game game)
        {
            return game.scene?.displayFactory;
        }

        public static UISceneManager GetUISceneManager(this Game game)
        {
            return UISceneManager.instance;
        }

        /// <summary>
        /// Get the instance of UI
        /// </summary>
        public static UI GetUI(this Game game)
        {
            return UI.instance;
        }

        /// <summary>
        /// Get the Btd6Player data for the player. Contains different info than PlayerProfile
        /// </summary>
        public static AdventureTimePlayer GetAdventureTimePlayer(this Game game)
        {
            return game.GetPlayerService()?.Player;
        }

        /// <summary>
        /// Get player's current Gems amount
        /// </summary>
        public static int GetGems(this Game game)
        {   
            return game.GetAdventureTimePlayer().Gems;
        }

        /// <summary>
        /// Add Gems to player's total Gems. Untested
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public static void AddGems(this Game game, int amount)
        {
            game.GetAdventureTimePlayer().AddGems(amount, "", 
                new Il2CppSystem.Nullable<Il2CppSystem.Guid>(), new Il2CppSystem.Nullable<Il2CppSystem.Guid>());
        }

        public static TowerRootNode GetTowerNode(this Game game, string key)
        {
            return TowerDataStore.GetTowerNode(key);
        }

        public static Graph GetTowerGraph(this Game game, string towerId)
        {
            return TowerDataStore.GetTowerGraph(towerId);
        }

        public static Graph GetTowerGraphForChild(this Game game, string towerId)
        {
            return TowerDataStore.GetTowerGraphForChild(towerId);
        }

        public static TowerClassData GetTowerClassData(this Game game, TowerBaseType towerBaseType)
        {
            return TowerDataStore.GetTowerClassData(towerBaseType);
        }

        public static TowerUpgradeLayout GetTowerUpgradeLayout(this Game game, string towerId)
        {
            return TowerDataStore.GetTowerUpgradeLayout(towerId);
        }

        public static EquipmentNode GetEquipmentNode(this Game game, string key)
        {
            return TowerDataStore.GetEquipmentNode(key);
        }

        public static List<string> GetTowersThatCanUseItem(this Game game, EquipmentNode equipmentNode)
        {
            return EquipmentHelper.GetTowersThatCanUseItem(equipmentNode);
        }

        public static int GetMinionCost(this Game game, EquipmentNode equipmentNode)
        {
            return EquipmentHelper.GetMinionCost(equipmentNode);
        }

        public static bool IsShardable(this Game game, EquipmentNode equipmentNode)
        {
            return EquipmentHelper.IsShardable(equipmentNode);
        }

        public static Il2CppStringArray GetItemBlackList(this Game game)
        {
            return game.GetItemBlackList(game.ActiveSkuSettings);
        }

        public static Il2CppStringArray GetItemBlackList(this Game game, SkuModel sku)
        {
            return EquipmentHelper.GetItemBlackList(sku);
        }

        public static PlayerPowerNode GetPowerNode(this Game game, string key)
        {
            return TowerDataStore.GetPowerNode(key);
        }

        public static PlayerPowerData GetPlayerPowerData(this Game game)
        {
            return TowerDataStore.GetPlayerPowerData();
        }

        public static TrinketDisplayData GetTrinketDisplayData(this Game game)
        {
            return TowerDataStore.GetTrinketDisplayData();
        }

        public static List<TowerRootNode> GetTowerNodes(this Game game)
        {
            var nodes = new List<TowerRootNode>();
            TowerDataStore.TowerStore.entries.ForEach(entry => nodes.Add(game.GetTowerNode(entry.key)));
            return nodes;
        }

        public static List<EquipmentNode> GetEquipmentNodes(this Game game)
        {
            var nodes = new List<EquipmentNode>();
            TowerDataStore.EquipmentStore.entries.ForEach(entry => nodes.Add(game.GetEquipmentNode(entry.key)));
            return nodes;
        }

        public static List<Graph> GetTowerGraphs(this Game game)
        {
            return TowerDataStore.GraphStore?.GetValues();
        }

        public static List<PlayerPowerNode> GetPowerNodes(this Game game)
        {
            var nodes = new List<PlayerPowerNode>();
            TowerDataStore.PowerStore.entries.ForEach(entry => nodes.Add(game.GetPowerNode(entry.key)));
            return nodes;
        }

        public static List<TowerClassData> GetAllTowerClassData(this Game game)
        {
            return TowerDataStore.towerClassDataStore?.GetValues();
        }

        public static List<TowerUpgradeLayout> GetAllTowerUpgradeLayout(this Game game)
        {
            return TowerDataStore.towerUpgradeLayoutStore?.GetValues();
        }
    }
}