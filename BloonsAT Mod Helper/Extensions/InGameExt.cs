﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers;
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
        /// Get the Player's current cash
        /// </summary>
        public static double GetCash(this InGame inGame)
        {
            return inGame.GetSimulation().Cash;
        }

        /// <summary>
        /// Add cash to the Player's wallet
        /// </summary>
        /// <param name="amount">Amount of cash to add to player wallet</param>
        public static void AddCash(this InGame inGame, double amount)
        {
            inGame.GetSimulation().Cash += amount;
        }

        /// <summary>
        /// Set the Player's cash to a specific amount
        /// </summary>
        /// <param name="amount">Value to set cash to</param>
        public static void SetCash(this InGame inGame, double amount)
        {
            inGame.GetSimulation().Cash = amount;
        }

        /// <summary>
        /// Get the Player's current health
        /// </summary>
        public static double GetHealth(this InGame inGame)
        {
            return inGame.GetSimulation().Health;
        }

        /// <summary>
        /// Add health to the players current health
        /// </summary>
        /// <param name="amount">Amount of health to add</param>
        public static void AddHealth(this InGame inGame, float amount)
        {
            inGame.GetSimulation().Health += amount;
        }

        /// <summary>
        /// Set player's health to specific amount
        /// </summary>
        /// <param name="amount">Value to set health to</param>
        public static void SetHealth(this InGame inGame, float amount)
        {
            inGame.GetSimulation().Health = amount;
        }

        /// <summary>
        /// Get the player's max health
        /// </summary>
        public static double GetMaxHealth(this InGame inGame)
        {
            return inGame.GetSimulation().maxHealth;
        }

        /// <summary>
        /// Add to the player's max health
        /// </summary>
        /// <param name="amount">Amount to add to the player's max health</param>
        public static void AddMaxHealth(this InGame inGame, float amount)
        {
            inGame.GetSimulation().maxHealth += amount;
        }

        /// <summary>
        /// Set the player's maximum health to a new value
        /// </summary>
        /// <param name="amount">Value to set max health to</param>
        public static void SetMaxHealth(this InGame inGame, float amount)
        {
            inGame.GetSimulation().maxHealth = amount;
        }




        /// <summary>
        /// Get collection of popped bloons in this game. Right now only works for current games. Does not store results from loaded games 
        /// </summary>
        /*public static System.Collections.Generic.Dictionary<string, int> GetPoppedBloons(this InGame inGame)
        {
            return SessionData.PoppedBloons;
        }*/


        /// <summary>
        /// Get the current instance of TowerInventory being used in this game session
        /// </summary>
        public static List<TowerInventoryEntry> GetTowerInventory(this InGame inGame)
        {
            return inGame.GetSimulation().GetTowerInventory();
        }

        /// <summary>
        /// Get the TowerModels for all of the Towers in your Party. Includes Minions and Allies
        /// </summary>
        /// <param name="inGame"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<TowerModel> GetPartyTowerModels(this InGame inGame)
        {
            return Api.SessionData.instance.inGameTowerModels;
        }
    }
}