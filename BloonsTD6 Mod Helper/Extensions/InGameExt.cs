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
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Patches;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets.Scripts.Simulation.Simulation;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class InGameExt
    {
        /// <summary>
        /// Custom API method that changes the game's round set to a custom RoundSetModel.
        /// </summary>
        /// <param name="roundSet">New Round Set Model to use</param>
        public static void SetRoundSet(this InGame inGame, RoundSetModel roundSet)
        {
            SessionData.RoundSet = roundSet;
        }

        /// <summary>
        /// Get the game object that owns all InGame UI elements
        /// </summary>
        /// <param name="inGame"></param>
        /// <returns></returns>
        public static GameObject GetInGameUI(this InGame inGame)
        {
            Scene scene = SceneManager.GetSceneByName("InGameUi");
            Il2CppReferenceArray<GameObject> rootGameObjects = scene.GetRootGameObjects();

            const int uiIndex = 1;
            GameObject ui = rootGameObjects[uiIndex];
            return ui;
        }

        /// <summary>
        /// Get the save path for the game (I think?)
        /// </summary>
        /// <param name="inGame"></param>
        /// <returns></returns>
        public static string GetSavePath(this InGame inGame)
        {
            return InGame.savePath;
        }

        /// <summary>
        /// Get the Cash Manager for the current game
        /// </summary>
        /// <param name="index">Index of the cash manager. Default is 0</param>
        public static CashManager GetCashManager(this InGame inGame, int index = 0)
        {
            return inGame.GetSimulation()?.cashManagers?.entries[index]?.value;
        }

        /// <summary>
        /// Get the Player's current cash
        /// </summary>
        public static double GetCash(this InGame inGame)
        {
            return inGame.GetCashManager().cash.Value;
        }

        /// <summary>
        /// Add cash to the Player's wallet
        /// </summary>
        /// <param name="amount">Amount of cash to add to player wallet</param>
        public static void AddCash(this InGame inGame, double amount)
        {
            inGame.GetCashManager().cash.Value += amount;
        }

        /// <summary>
        /// Set the Player's cash to a specific amount
        /// </summary>
        /// <param name="amount">Value to set cash to</param>
        public static void SetCash(this InGame inGame, double amount)
        {
            inGame.GetCashManager().cash.Value = amount;
        }

        /// <summary>
        /// Get the Player's current health
        /// </summary>
        public static double GetHealth(this InGame inGame)
        {
            return inGame.GetSimulation().health.Value;
        }

        /// <summary>
        /// Add health to the players current health
        /// </summary>
        /// <param name="amount">Amount of health to add</param>
        public static void AddHealth(this InGame inGame, double amount)
        {
            inGame.GetSimulation().health.Value += amount;
        }

        /// <summary>
        /// Set player's health to specific amount
        /// </summary>
        /// <param name="amount">Value to set health to</param>
        public static void SetHealth(this InGame inGame, double amount)
        {
            inGame.GetSimulation().health.Value = amount;
        }

        /// <summary>
        /// Get the player's max health
        /// </summary>
        public static double GetMaxHealth(this InGame inGame)
        {
            return inGame.GetSimulation().maxHealth.Value;
        }

        /// <summary>
        /// Add to the player's max health
        /// </summary>
        /// <param name="amount">Amount to add to the player's max health</param>
        public static void AddMaxHealth(this InGame inGame, double amount)
        {
            inGame.GetSimulation().maxHealth.Value += amount;
        }

        /// <summary>
        /// Set the player's maximum health to a new value
        /// </summary>
        /// <param name="amount">Value to set max health to</param>
        public static void SetMaxHealth(this InGame inGame, double amount)
        {
            inGame.GetSimulation().maxHealth.Value = amount;
        }

        /// <summary>
        /// Get collection of popped bloons in this game. Right now only works for current games. Does not store results from loaded games 
        /// </summary>
        public static System.Collections.Generic.Dictionary<string, int> GetPoppedBloons(this InGame inGame)
        {
            return SessionData.PoppedBloons;
        }

        //not using this one because it doesn't seem to work. May check back later
        //public static TowerInventory GetTowerInventory(this InGame inGame, int index) => inGame.bridge.simulation.GetTowerInventory(index);

        /// <summary>
        /// Get the current instance of TowerInventory being used in this game session
        /// </summary>
        public static TowerInventory GetTowerInventory(this InGame inGame)
        {
            return TowerInventory_Init.towerInventory;
        }


        // This has been removed so it can be tested further.
        /*public static void GetMapDimensions(this InGame inGame, out Vector2 topLeft, out Vector2 bottomRight)
        {
            topLeft = new Vector2(-149.9228f, -115.2562f);
            bottomRight = new Vector2(150.0713f, 115.4701f);
        }*/

        /// <summary>
        /// Set the current round
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="round"></param>
        public static void SetRound(this InGame inGame, int round)
        {
            inGame.GetMap().spawner.SetRound(round);
        }

        /// <summary>
        /// Spawn bloons in game
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="bloonName"></param>
        /// <param name="number"></param>
        /// <param name="spacing"></param>
        public static void SpawnBloons(this InGame inGame, string bloonName, int number, float spacing)
        {
            Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels = Game.instance.model.CreateBloonEmissions(bloonName, number, spacing).ToIl2CppReferenceArray();
            inGame.SpawnBloons(bloonEmissionModels);
        }

        /// <summary>
        /// Spawn bloons in game
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="bloonEmissionModels"></param>
        public static void SpawnBloons(this InGame inGame, System.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.GetUnityToSimulation().SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.GetUnityToSimulation().GetCurrentRound(), 0);
        }


        /// <summary>
        /// Spawn bloons in game
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="bloonEmissionModels"></param>
        public static void SpawnBloons(this InGame inGame, List<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.GetUnityToSimulation().SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(), inGame.GetUnityToSimulation().GetCurrentRound(), 0);
        }


        /// <summary>
        /// Spawn bloons in game
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="bloonEmissionModels"></param>
        public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels)
        {
            inGame.GetUnityToSimulation().SpawnBloons(bloonEmissionModels, inGame.GetUnityToSimulation().GetCurrentRound(), 0);
        }


        /// <summary>
        /// Spawn bloons in game
        /// </summary>
        /// <param name="inGame"></param>
        /// <param name="round"></param>
        public static void SpawnBloons(this InGame inGame, int round)
        {
            GameModel model = inGame.GetGameModel();

            int index = (round < 100) ? round - 1 : round - 100;
            Il2CppReferenceArray<BloonEmissionModel> emissions = (round < 100) ? model.GetRoundSet().rounds[index].emissions : model.freeplayGroups[index].bloonEmissions;
            inGame.SpawnBloons(emissions);
        }
    }
}