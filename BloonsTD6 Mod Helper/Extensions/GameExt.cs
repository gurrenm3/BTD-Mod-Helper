using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.PowerSets;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Map;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.Player;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.Coop;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Utils;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppNinjaKiwi.LiNK;
using Il2CppNinjaKiwi.LiNK.Lobbies;
using Il2CppNinjaKiwi.NKMulti;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Game
/// </summary>
public static class GameExt
{
    /// <summary>
    /// Returns the instance of the Map Loader.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static MapLoader GetMapLoader(this Game game) => Il2CppAssets.Scripts.Unity.UI_New.UI.instance.mapLoader;

    /// <summary>
    /// Returns a new SpriteReference that uses the given guid
    /// </summary>
    /// <param name="game"></param>
    /// <param name="guid"></param>
    /// <returns></returns>
    public static SpriteReference CreateSpriteReference(this Game game, string guid) =>
        ModContent.CreateSpriteReference(guid);

    /// <summary>
    /// Returns whether or not the player's account is currently flagged/hackerpooled
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static bool IsAccountFlagged(this Game game)
    {
        return game.GetBtd6Player().IsFlagged;
    }

    /// <summary>
    /// Get the instance of LocalizationManager
    /// </summary>
    public static LocalizationManager GetLocalizationManager(this Game game) => LocalizationManager.Instance;

    /// <summary>
    /// Schedule a task to execute right now as a Coroutine
    /// </summary>
    /// <param name="game"></param>
    /// <param name="iEnumerator"></param>
    public static void ScheduleTask(this Game game, IEnumerator iEnumerator)
    {
        MelonCoroutines.Start(iEnumerator);
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
    /// </summary>
    /// <param name="game"></param>
    /// <param name="action">The action you want to execute once it's time to run your task</param>
    /// <param name="waitCondition">Wait for this to be true before executing task</param>
    public static void ScheduleTask(this Game game, Action action, Func<bool> waitCondition = null)
    {
        game.ScheduleTask(action, ScheduleType.WaitForFrames, 0, waitCondition);
    }

    /// <summary>
    /// Schedule a task to execute later on as a Coroutine
    /// </summary>
    /// <param name="game"></param>
    /// <param name="action">The action you want to execute once it's time to run your task</param>
    /// <param name="scheduleType">How you want to wait for your task</param>
    /// <param name="amountToWait">The amount you want to wait</param>
    /// ///
    /// <param name="waitCondition">Wait for this to be true before executing task</param>
    public static void ScheduleTask(this Game game, Action action, ScheduleType scheduleType, int amountToWait,
        Func<bool> waitCondition = null)
    {
        TaskScheduler.ScheduleTask(action, scheduleType, amountToWait, waitCondition);
    }


    /// <summary>
    /// Get Player LinkAccount. Contains limited info about player's NinjaKiwi account
    /// </summary>
    public static LiNKAccount GetPlayerLiNKAccount(this Game game) => game.GetPlayerService()?.Player?.LiNKAccount;

    /// <summary>
    /// Get the ProfileModel for the Player
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static ProfileModel GetPlayerProfile(this Game game) => game.GetPlayerService()?.Player?.Data;

    /// <summary>
    /// Get the PlayerService for the player
    /// </summary>
    public static PlayerService GetPlayerService(this Game game) => game.playerService;

    /// <summary>
    /// Get GameModel. Same as using Game.instance.model
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static GameModel GetModel(this Game game) => game.model;

    /// <summary>
    /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
    /// </summary>
    /// <param name="game">the Game instance</param>
    /// <param name="message">Message body</param>
    /// <param name="title">Message title. Will be mod name by default</param>
    public static void ShowMessage(this Game game, string message, [Optional] string title)
    {
        game.ShowMessage(message, 2f, title);
    }

    /// <summary>
    /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
    /// </summary>
    /// <param name="game">the Game instance</param>
    /// <param name="message">Message body</param>
    /// <param name="displayTime">Time to show message on screen</param>
    /// <param name="title">Message title. Will be mod name by default</param>
    public static void ShowMessage(this Game game, string message, float displayTime, [Optional] string title)
    {
        var msg = new NkhMsg
        {
            MsgShowTime = displayTime,
            NkhText = new NkhText
            {
                Body = message,
                Title = title
            }
        };

        NotificationMgr.AddNotification(msg);
    }

    /// <summary>
    /// Returns the current lobby screen.
    /// </summary>
    public static CoopLobbyScreen GetCoopLobbyScreen(this Game game) =>
        // ReSharper disable once Unity.NoNullPropagation
        game.GetMenuManager()?.currMenu?.Item2?.TryCast<CoopLobbyScreen>();

    /// <summary>
    /// Returns the current lobby connection.
    /// </summary>
    public static LobbyConnection GetCoopLobbyConnection(this Game game) => game.GetCoopLobbyScreen()?.coopLobbyData.lobbyConnection;

    /// <summary>
    /// Returns the directory where the Player's Profile.save file is located.
    /// Not set until after reaching the Main Menu for the first time
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    [Obsolete]
    public static string GetSaveDirectory(this Game game) => SessionData.Instance.SaveDirectory;

    /// <summary>
    /// Makes a save of Player.Save at the specified path
    /// </summary>
    /// <param name="game"></param>
    /// <param name="savePath">Path to save to</param>
    [Obsolete]
    public static void SavePlayerData(this Game game, string savePath)
    {
        throw new NotSupportedException();
    }

    /// <summary>
    /// Checks if Player is in a game mode that would get them flagged if using mods
    /// </summary>
    public static bool CanGetFlagged(this Game game) => game.IsInRace() || game.IsInPublicCoop() || game.IsInOdyssey();

    /// <summary>
    /// Returns if Player is in a race
    /// </summary>
    public static bool IsInRace(this Game game) => SessionData.Instance.IsInRace;

    /// <summary>
    /// Returns if Player is in a public co-op match
    /// </summary>
    public static bool IsInPublicCoop(this Game game) => SessionData.Instance.IsInPublicCoop;

    /// <summary>
    /// Returns if Player is in a Odyssey game
    /// </summary>
    public static bool IsInOdyssey(this Game game) => SessionData.Instance.IsInOdyssey;

    /// <summary>
    /// Get nkGI for the current session. Will be null if not in multiplayer game or lobby
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public static NKMultiGameInterface GetNkGI(this Game game) => SessionData.Instance.NkGI;

    /// <summary>
    /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the
    /// game
    /// </summary>
    public static Factory GetDisplayFactory(this Game game) => game.scene?.factory;

    /// <summary>
    /// Get the instance of PopupScreen
    /// </summary>
    public static PopupScreen GetPopupScreen(this Game game) => PopupScreen.instance;

    /// <summary>
    /// Get the instance of ShopMenu
    /// </summary>
    public static ShopMenu GetShopMenu(this Game game) => ShopMenu.instance;

    /// <summary>
    /// Get the instance of CommonForegroundScreen
    /// </summary>
    public static CommonForegroundScreen GetCommonForegroundScreen(this Game game) => CommonForegroundScreen.instance;

    /// <summary>
    /// Get the instance of CommonBackgroundScreen
    /// </summary>
    public static CommonBackgroundScreen GetCommonBackgroundScreen(this Game game) => CommonBackgroundScreen.instance;

    /// <summary>
    /// Get the instance of MenuManager
    /// </summary>
    public static MenuManager GetMenuManager(this Game game) => MenuManager.instance;

    /// <summary>
    /// Get the instance of UI
    /// </summary>
    public static Il2CppAssets.Scripts.Unity.UI_New.UI GetUI(this Game game) =>
        Il2CppAssets.Scripts.Unity.UI_New.UI.instance;

    /// <summary>
    /// Not tested
    /// </summary>
    public static List<TowerModel> GetTowerListForTowerType(this Game game, TowerSet towerSet) =>
        Helpers.GetTowerListForTowerType(towerSet).ToList();

    /// <summary>
    /// Get the Btd6Player data for the player. Contains different info than PlayerProfile
    /// </summary>
    public static Btd6Player GetBtd6Player(this Game game) => game.GetPlayerService()?.Player;

    /// <summary>
    /// Get all TowerDetailModels
    /// </summary>
    public static Il2CppReferenceArray<TowerDetailsModel> GetTowerDetailModels(this Game game) => game.model?.towerSet;

    /// <summary>
    /// Get all HeroDetailModels
    /// </summary>
    public static Il2CppReferenceArray<TowerDetailsModel> GetHeroDetailModels(this Game game) => game.model.heroSet;

    /// <summary>
    /// Get all PowerDetailModels
    /// </summary>
    public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game) => game.model.powerSet;

    /// <summary>
    /// Get player's current Monkey Money amount
    /// </summary>
    public static double GetMonkeyMoney(this Game game) => game.GetPlayerProfile().monkeyMoney.Value;

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