using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Simulation.Input;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Simulation.Simulation;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class InGameExt
    {
        public static GameObject GetInGameUI(this InGame inGame)
        {
            Scene scene = SceneManager.GetSceneByName("InGameUi");
            Il2CppReferenceArray<GameObject> rootGameObjects = scene.GetRootGameObjects();

            const int uiIndex = 1;
            GameObject ui = rootGameObjects[uiIndex];
            return ui;
        }

        /// <summary>
        /// Get the main Factory that creates and manages all other Factories
        /// </summary>
        public static FactoryFactory GetMainFactory(this InGame inGame)
        {
            return inGame.GetUnityToSim()?.simulation.factory;
        }

        /// <summary>
        /// The Game.model that is being used for this InGame.instance
        /// </summary>
        public static GameModel GetGameModel(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.model;
        }

        /// <summary>
        /// Get the current Simulation for this InGame session
        /// </summary>
        public static Simulation GetSimulation(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation;
        }

        /// <summary>
        /// Get the current Map
        /// </summary>
        public static Map GetMap(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.map;
        }




        /// <summary>
        /// Get the Cash Manager for the current game
        /// </summary>
        /// <param name="index">Index of the cash manager. Default is 0</param>
        /*public static CashManager GetCashManager(this InGame inGame, int index = 0)
        {
            return inGame.bridge.simulation.cashManagers.entries[index].value;
        }*/



        /// <summary>
        /// Get the Player's current cash
        /// </summary>
        public static double GetCash(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.Cash;
        }

        /// <summary>
        /// Add cash to the Player's wallet
        /// </summary>
        /// <param name="amount">Amount of cash to add to player wallet</param>
        public static void AddCash(this InGame inGame, double amount)
        {
            inGame.Simulation.GameSimulation.Cash += amount;
        }

        /// <summary>
        /// Set the Player's cash to a specific amount
        /// </summary>
        /// <param name="amount">Value to set cash to</param>
        public static void SetCash(this InGame inGame, double amount)
        {
            inGame.Simulation.GameSimulation.Cash = amount;
        }

        /// <summary>
        /// Get the Player's current health
        /// </summary>
        public static double GetHealth(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.Health;
        }

        /// <summary>
        /// Add health to the players current health
        /// </summary>
        /// <param name="amount">Amount of health to add</param>
        public static void AddHealth(this InGame inGame, float amount)
        {
            inGame.Simulation.GameSimulation.Health += amount;
        }

        /// <summary>
        /// Set player's health to specific amount
        /// </summary>
        /// <param name="amount">Value to set health to</param>
        public static void SetHealth(this InGame inGame, float amount)
        {
            inGame.Simulation.GameSimulation.Health = amount;
        }

        /// <summary>
        /// Get the player's max health
        /// </summary>
        public static double GetMaxHealth(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.maxHealth;
        }

        /// <summary>
        /// Add to the player's max health
        /// </summary>
        /// <param name="amount">Amount to add to the player's max health</param>
        public static void AddMaxHealth(this InGame inGame, float amount)
        {
            inGame.Simulation.GameSimulation.maxHealth += amount;
        }

        /// <summary>
        /// Set the player's maximum health to a new value
        /// </summary>
        /// <param name="amount">Value to set max health to</param>
        public static void SetMaxHealth(this InGame inGame, float amount)
        {
            inGame.Simulation.GameSimulation.maxHealth = amount;
        }




        /// <summary>
        /// Get collection of popped bloons in this game. Right now only works for current games. Does not store results from loaded games 
        /// </summary>
        /*public static System.Collections.Generic.Dictionary<string, int> GetPoppedBloons(this InGame inGame)
        {
            return SessionData.PoppedBloons;
        }*/



        /// <summary>
        /// Get the current TowerManager for this game session
        /// </summary>
        public static TowerManager GetTowerManager(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.towerManager;
        }


        /// <summary>
        /// Get the current instance of TowerInventory being used in this game session
        /// </summary>
        public static List<TowerInventoryEntry> GetTowerInventory(this InGame inGame)
        {
            return inGame.Simulation.GameSimulation.GetTowerInventory();
        }



        /*public static void GetMapDimensions(this InGame inGame, out Vector2 topLeft, out Vector2 bottomRight)
        {
            topLeft = new Vector2(-149.9228f, -115.2562f);
            bottomRight = new Vector2(150.0713f, 115.4701f);
        }*/



        /*public static void SetRound(this InGame inGame, int round)
        {
            inGame.bridge.simulation.map.spawner.SetRound(round);
        }*/



        /// <summary>
        /// Gets all objects of type T. Does this by returning all objects created by the Factory of type T
        /// </summary>
        /// <typeparam name="T">The type of items you want</typeparam>
        public static LockList<T> GetAllObjectsOfType<T>(this InGame inGame) where T : RootObject, new()
        {
            var factory = inGame.Simulation.GameSimulation.factory.GetFactory<T>();
            return factory.active;
        }


        /*public static void SpawnBloons(this InGame inGame, string bloonName, int number, float spacing)
        {
            Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels = Game.instance.model.CreateBloonEmissions(bloonName, number, spacing).ToIl2CppReferenceArray();
            inGame.SpawnBloons(bloonEmissionModels);
        }*/

        /*public static void SpawnBloons(this InGame inGame, System.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.Simulation.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.Simulation.GetCurrentRound(), 0);
        }

        public static void SpawnBloons(this InGame inGame, List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.Simulation.SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray());
        }

        public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.bridge.SpawnBloons(bloonEmissionModels, inGame.bridge.GetCurrentRound(), 0);
        }

        public static void SpawnBloons(this InGame inGame, int round)
        {
            GameModel model = inGame.GetGameModel();

            int index = (round < 100) ? round - 1 : round - 100;
            Il2CppReferenceArray<BloonEmissionModel> emissions = (round < 100) ? model.GetRoundSet().rounds[index].emissions : model.freeplayGroups[index].bloonEmissions;
            InGame.instance.SpawnBloons(emissions);
        }*/
    }
}