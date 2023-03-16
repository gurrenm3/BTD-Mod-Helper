using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.PowerSets;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.LiNK.Lobbies;
using Il2CppNinjaKiwi.NKMulti;
using Il2CppNinjaKiwi.Players.Files.SaveStrategies;
using Il2CppNinjaKiwi.Players.LiNKAccountControllers;
using Il2CppSteamNative;
using Il2CppSystem.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Helpers = Il2CppAssets.Scripts.Utils.Helpers;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Game
/// </summary>
public static partial class GameExt
{
    /// <summary>
    /// Returns the current lobby screen.
    /// </summary>
    public static CoopLobbyScreen GetCoopLobbyScreen(this Game game)
    {
        // ReSharper disable once Unity.NoNullPropagation
        return game.GetMenuManager()?.currMenu?.Item2?.TryCast<CoopLobbyScreen>();
    }

    /// <summary>
    /// Returns the current lobby connection.
    /// </summary>
    public static LobbyConnection GetCoopLobbyConnection(this Game game) => game.GetCoopLobbyScreen()?.lobbyConnection;

    /// <summary>
    /// Returns the directory where the Player's Profile.save file is located.
    /// Not set until after reaching the Main Menu for the first time
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static string GetSaveDirectory(this Game game)
    {
        return SessionData.Instance.SaveDirectory;
    }

    /// <summary>
    /// Makes a save of Player.Save at the specified path
    /// </summary>
    /// <param name="game"></param>
    /// <param name="savePath">Path to save to</param>
    public static void SavePlayerData(this Game game, string savePath)
    {
        var backup = SessionData.Instance.PlayerSaveStrategy?.MemberwiseClone().Cast<TimedBackupStrategy>();
        if (backup != null)
        {
            backup.FilePath = savePath;
            backup.CreateBackup();
        }
    }

    /// <summary>
    /// Checks if Player is in a game mode that would get them flagged if using mods
    /// </summary>
    public static bool CanGetFlagged(this Game game)
    {
        return (game.IsInRace() || game.IsInPublicCoop() || game.IsInOdyssey());
    }

    /// <summary>
    /// Returns if Player is in a race
    /// </summary>
    public static bool IsInRace(this Game game)
    {
        return SessionData.Instance.IsInRace;
    }

    /// <summary>
    /// Returns if Player is in a public co-op match
    /// </summary>
    public static bool IsInPublicCoop(this Game game)
    {
        return SessionData.Instance.IsInPublicCoop;
    }

    /// <summary>
    /// Returns if Player is in a Odyssey game
    /// </summary>
    public static bool IsInOdyssey(this Game game)
    {
        return SessionData.Instance.IsInOdyssey;
    }

    /// <summary>
    /// Get nkGI for the current session. Will be null if not in multiplayer game or lobby
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static NKMultiGameInterface GetNkGI(this Game game)
    {
        return SessionData.Instance.NkGI;
    }

    /// <summary>
    /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game
    /// </summary>
    public static Factory GetDisplayFactory(this Game game)
    {
        return game.scene?.factory;
    }

    /// <summary>
    /// Gets a Json Serializer. Not necessary but can be useful
    /// </summary>
    public static JsonSerializer GetJsonSerializer(this Game game)
    {
        return JsonSerializer.instance;
    }

    /// <summary>
    /// Get the instance of PopupScreen
    /// </summary>
    public static PopupScreen GetPopupScreen(this Game game)
    {
        return PopupScreen.instance;
    }

    /// <summary>
    /// Get the instance of ShopMenu
    /// </summary>
    public static ShopMenu GetShopMenu(this Game game)
    {
        return ShopMenu.instance;
    }

    /// <summary>
    /// Get the instance of CommonForegroundScreen
    /// </summary>
    public static CommonForegroundScreen GetCommonForegroundScreen(this Game game)
    {
        return CommonForegroundScreen.instance;
    }

    /// <summary>
    /// Get the instance of CommonBackgroundScreen
    /// </summary>
    public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game)
    {
        return CommonBackgroundScreen.instance;
    }

    /// <summary>
    /// Get the instance of MenuManager
    /// </summary>
    public static MenuManager GetMenuManager(this Game game)
    {
        return MenuManager.instance;
    }

    /// <summary>
    /// Get the instance of UI
    /// </summary>
    public static Il2CppAssets.Scripts.Unity.UI_New.UI GetUI(this Game game)
    {
        return Il2CppAssets.Scripts.Unity.UI_New.UI.instance;
    }

    /// <summary>
    /// Not tested
    /// </summary>
    public static List<TowerModel> GetTowerListForTowerType(this Game game, TowerSet towerSet)
    {
        return Helpers.GetTowerListForTowerType(towerSet).ToList();
    }

    /// <summary>
    /// Get the Btd6Player data for the player. Contains different info than PlayerProfile
    /// </summary>
    public static Btd6Player GetBtd6Player(this Game game)
    {
        return game.GetPlayerService()?.Player;
    }

    /// <summary>
    /// Get all TowerDetailModels
    /// </summary>
    public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game)
    {
        return game.model?.towerSet;
    }

    /// <summary>
    /// Get all HeroDetailModels
    /// </summary>
    public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game)
    {
        return game.model.heroSet;
    }

    /// <summary>
    /// Get all PowerDetailModels
    /// </summary>
    public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game)
    {
        return game.model.powerSet;
    }

    /// <summary>
    /// Get player's current Monkey Money amount
    /// </summary>
    public static double GetMonkeyMoney(this Game game)
    {
        return game.GetPlayerProfile().monkeyMoney.Value;
    }

    /// <summary>
    /// Add Monkey Money to player's total Monkey Money
    /// </summary>
    /// <param name="game">the Game instance</param>
    /// <param name="amount">Amount to add</param>
    public static void AddMonkeyMoney(this Game game, double amount)
    {
        var monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
        if (monkeyMoney != null)
            monkeyMoney.Value += amount;
    }

    /// <summary>
    /// Set player's Monkey Money amount
    /// </summary>
    /// <param name="game">the Game instance</param>
    /// <param name="amount">Value to set Monkey Money to</param>
    public static void SetMonkeyMoney(this Game game, double amount)
    {
        var monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
        if (monkeyMoney != null)
            monkeyMoney.Value = amount;
    }
}