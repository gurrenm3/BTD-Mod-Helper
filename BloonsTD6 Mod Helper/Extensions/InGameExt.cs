using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Input;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for the InGame class
/// </summary>
public static class InGameExt
{
    /// <summary>
    /// Returns whether or not the player is currently in a game.
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static bool IsInGame(this InGame inGame) => inGame.GetSimulation() != null;

    /// <summary>
    /// Get the current Map
    /// </summary>
    public static Map GetMap(this InGame inGame) => inGame.GetSimulation()?.Map;

    /// <summary>
    /// Get the current Simulation for this InGame session
    /// </summary>
    public static Simulation GetSimulation(this InGame inGame) => inGame.GetUnityToSimulation()?.simulation;

    /// <summary>
    /// The Game.model that is being used for this InGame.instance
    /// </summary>
    public static GameModel GetGameModel(this InGame inGame) => inGame.GetSimulation()?.model;

    /// <summary>
    /// Get the main Factory that creates and manages all other Factories
    /// </summary>
    public static FactoryFactory GetMainFactory(this InGame inGame) => inGame.GetSimulation().factory;

    /// <summary>
    /// Get the Factory for a specific Type. Ex: Getting the Factory that makes Towers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static Factory<T> GetFactory<T>(this InGame inGame) where T : RootObject, new() =>
        inGame.GetMainFactory().GetFactory<T>();

    /// <summary>
    /// Get every Tower that has been created through the Tower Factory
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="name">Optionally only get Towers whose TowerModel name is this parameter</param>
    /// <returns></returns>
    public static List<Tower> GetTowers(this InGame inGame, string name = null)
    {
        var towers = inGame.GetAllObjectsOfType<Tower>();
        if (!string.IsNullOrEmpty(name))
            towers = towers?.FindAll(tower => tower.towerModel.name == name);

        return towers ?? new List<Tower>();
    }

    /// <summary>
    /// Get all TowerToSimulations
    /// </summary>
    /// <param name="inGame"></param>
    /// ///
    /// <param name="name">Optionally only get Towers whose TowerModel name is this parameter</param>
    /// <returns></returns>
    public static List<TowerToSimulation> GetAllTowerToSim(this InGame inGame, string name = null)
    {
        var towerToSims = inGame.GetUnityToSimulation().GetAllTowers()?.ToList();
        if (!string.IsNullOrEmpty(name))
            towerToSims = towerToSims?.FindAll(tower => tower.Def.name == name);

        return towerToSims ?? new List<TowerToSimulation>();
    }


    /// <summary>
    /// Get's all Bloons on the map
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static List<Bloon> GetBloons(this InGame inGame) => inGame.GetFactory<Bloon>().up.ToList(); // TODO check this

    /// <summary>
    /// Get's all existing BloonToSimulations
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static List<BloonToSimulation> GetAllBloonToSim(this InGame inGame) =>
        //return SessionData.Instance.bloonTracker.currentBloonToSims.Values.ToList();
        inGame.GetUnityToSimulation().GetAllBloons().ToList();

    /// <summary>
    /// Get's all existing Projectiles on the map
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static List<Projectile> GetProjectiles(this InGame inGame) => inGame.GetAllObjectsOfType<Projectile>();

    /// <summary>
    /// Get the current TowerManager for this game session
    /// </summary>
    public static TowerManager GetTowerManager(this InGame inGame) => inGame.GetSimulation().towerManager;

    /// <summary>
    /// Get's all AbilityToSimulations currently in the game
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static List<AbilityToSimulation> GetAbilities(this InGame inGame) =>
        inGame.GetUnityToSimulation()?.GetAllAbilities(false)?.ToList();

    /// <summary>
    /// Get's the UnityToSimulation for this game
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static UnityToSimulation GetUnityToSimulation(this InGame inGame) => inGame.bridge;


    /// <summary>
    /// Gets all objects of type T. Does this by returning all objects created by the Factory of type T
    /// </summary>
    /// <typeparam name="T">The type of items you want</typeparam>
    public static List<T> GetAllObjectsOfType<T>(this InGame inGame) where T : RootObject, new()
    {
        var factory = inGame.GetMainFactory()?.GetFactory<T>();

        return factory?.up?.ToList() ?? new List<T>(); // TODO check this

    }

    /// <summary>
    /// Sells multiple towers
    /// </summary>
    public static void SellTowers(this InGame inGame, List<Tower> towers)
    {
        towers.ForEach(inGame.SellTower);
    }

    /// <summary>
    /// Sells a tower
    /// </summary>
    public static void SellTower(this InGame inGame, Tower tower)
    {
        inGame.SellTower(tower.GetTowerToSim());
    }

    /// <summary>
    /// Returns true if the initial co-op handshake has finished and user has co-op game details.
    /// </summary>
    /// <param name="inGame">The game.</param>
    public static bool IsCoOpReady(this InGame inGame)
    {
        if (inGame == null)
            return false;

        if (!inGame.IsCoop)
            return false;

        return inGame.coopGame != null;
    }

    /// <summary>
    /// Custom API method that changes the game's round set to a custom RoundSetModel.
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="roundSet">New Round Set Model to use</param>
    public static void SetRoundSet(this InGame inGame, RoundSetModel roundSet)
    {
        inGame.GetGameModel().SetRoundSet(roundSet);
    }

    /// <summary>
    /// Get the game object that owns all InGame UI elements
    /// </summary>
    /// <param name="inGame"></param>
    /// <returns></returns>
    public static GameObject GetInGameUI(this InGame inGame)
    {
        var scene = SceneManager.GetSceneByName("InGameUi");
        var rootGameObjects = scene.GetRootGameObjects();

        const int uiIndex = 1;
        var ui = rootGameObjects[uiIndex];
        return ui;
    }

    /// <summary>
    /// Get the Cash Manager for the current game
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="index">Index of the cash manager. Default is 0</param>
    public static Simulation.CashManager GetCashManager(this InGame inGame, int index = 0) =>
        inGame.GetSimulation()?.cashManagers?._entries[index]?.value;

    /// <summary>
    /// Get the Player's current cash
    /// </summary>
    public static double GetCash(this InGame inGame) => inGame.GetCashManager().cash.Value;

    /// <summary>
    /// Add cash to the Player's wallet
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Amount of cash to add to player wallet</param>
    public static void AddCash(this InGame inGame, double amount)
    {
        inGame.GetCashManager().cash.Value += amount;
        InGame.instance.bridge.Simulation.hasCashChanged = true;
    }

    /// <summary>
    /// Set the Player's cash to a specific amount
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Value to set cash to</param>
    public static void SetCash(this InGame inGame, double amount)
    {
        inGame.GetCashManager().cash.Value = amount;
        InGame.instance.bridge.Simulation.hasCashChanged = true;
    }

    /// <summary>
    /// Get the Player's current health
    /// </summary>
    public static double GetHealth(this InGame inGame) => inGame.GetSimulation().health.Value;

    /// <summary>
    /// Add health to the players current health
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Amount of health to add</param>
    public static void AddHealth(this InGame inGame, double amount)
    {
        inGame.GetSimulation().health.Value += amount;
    }

    /// <summary>
    /// Set player's health to specific amount
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Value to set health to</param>
    public static void SetHealth(this InGame inGame, double amount)
    {
        inGame.GetSimulation().health.Value = amount;
    }

    /// <summary>
    /// Get the player's max health
    /// </summary>
    public static double GetMaxHealth(this InGame inGame) => inGame.GetSimulation().maxHealth.Value;

    /// <summary>
    /// Add to the player's max health
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Amount to add to the player's max health</param>
    public static void AddMaxHealth(this InGame inGame, double amount)
    {
        inGame.GetSimulation().maxHealth.Value += amount;
    }

    /// <summary>
    /// Set the player's maximum health to a new value
    /// </summary>
    /// <param name="inGame">InGame instance</param>
    /// <param name="amount">Value to set max health to</param>
    public static void SetMaxHealth(this InGame inGame, double amount)
    {
        inGame.GetSimulation().maxHealth.Value = amount;
    }

    /// <summary>
    /// Get collection of popped bloons in this game. Right now only works for current games. Does not store results from
    /// loaded games
    /// </summary>
    [Obsolete("No longer being populated")]
    public static Dictionary<string, int> GetPoppedBloons(this InGame inGame) => SessionData.Instance.PoppedBloons;

    /// <summary>
    /// Get the current instance of TowerInventory being used in this game session
    /// </summary>
    public static TowerInventory GetTowerInventory(this InGame inGame) =>
        inGame.bridge.simulation.GetTowerInventory(inGame.bridge.GetInputId());


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
        var bloonEmissionModels = Game.instance.model.CreateBloonEmissions(bloonName, number, spacing)
            .ToIl2CppReferenceArray();
        inGame.SpawnBloons(bloonEmissionModels);
    }

    /// <summary>
    /// Spawn bloons in game
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="bloonEmissionModels"></param>
    public static void SpawnBloons(this InGame inGame,
        List<BloonEmissionModel> bloonEmissionModels)
    {
        inGame.GetUnityToSimulation().SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(),
            inGame.GetUnityToSimulation().GetCurrentRound(), 0);
    }


    /// <summary>
    /// Spawn bloons in game
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="bloonEmissionModels"></param>
    public static void SpawnBloons(this InGame inGame,
        Il2CppSystem.Collections.Generic.List<BloonEmissionModel> bloonEmissionModels)
    {
        inGame.GetUnityToSimulation().SpawnBloons(bloonEmissionModels.ToIl2CppReferenceArray(),
            inGame.GetUnityToSimulation().GetCurrentRound(), 0);
    }


    /// <summary>
    /// Spawn bloons in game
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="bloonEmissionModels"></param>
    public static void SpawnBloons(this InGame inGame, Il2CppReferenceArray<BloonEmissionModel> bloonEmissionModels)
    {
        inGame.GetUnityToSimulation()!
            .SpawnBloons(bloonEmissionModels, inGame.GetUnityToSimulation().GetCurrentRound(), 0);
    }


    /// <summary>
    /// Spawn bloons in game
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="round"></param>
    public static void SpawnBloons(this InGame inGame, int round)
    {
        var model = inGame.GetGameModel();

        var index = round < 100 ? round - 1 : round - 100;
        var emissions = round < 100
            ? model.roundSet.rounds[index].emissions
            : model.freeplayGroups[index].bloonEmissions;
        inGame.SpawnBloons(emissions);
    }

    /// <inheritdoc cref="InGameExt"/>
    extension(InGame inGame)
    {
        /// <summary>
        /// Gets the main InputManager instance
        /// </summary>
        public Il2CppAssets.Scripts.Unity.UI_New.InGame.InputManager InputManager =>
            inGame?.playerContexts?.FirstOrDefault().inputManager;
    }
}