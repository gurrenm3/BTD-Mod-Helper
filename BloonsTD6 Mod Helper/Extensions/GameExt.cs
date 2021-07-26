using Assets.Scripts.Models.PowerSets;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.InGame.RightMenu;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using NinjaKiwi.Common;
using NinjaKiwi.LiNK;
using NinjaKiwi.NKMulti;
using System;
using System.Collections;
using System.Collections.Generic;
using UnhollowerBaseLib;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {

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
            return SessionData.IsInRace;
        }

        /// <summary>
        /// Returns if Player is in a public co-op match
        /// </summary>
        public static bool IsInPublicCoop(this Game game)
        {
            return SessionData.IsInPublicCoop;
        }

        /// <summary>
        /// Returns if Player is in a Odyssey game
        /// </summary>
        public static bool IsInOdyssey(this Game game)
        {
            return SessionData.IsInOdyssey;
        }

        /// <summary>
        /// Get nkGI for the current session. Will be null if not in multiplayer game or lobby
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static NKMultiGameInterface GetNkGI(this Game game)
        {
            return SessionData.nkGI;
        }

        /// <summary>
        /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game
        /// </summary>
        public static Assets.Scripts.Unity.Display.Factory GetDisplayFactory(this Game game)
        {
            return game.scene?.factory;
        }

        /// <summary>
        /// Gets the Sprite Register. Can be used to add custom sprites
        /// </summary>
        public static SpriteRegister GetSpriteRegister(this Game game)
        {
            return SpriteRegister.Instance;
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
        /// Get the instance of LocalizationManager
        /// </summary>
        public static LocalizationManager GetLocalizationManager(this Game game)
        {
            return LocalizationManager.Instance;
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
        public static UI GetUI(this Game game)
        {
            return UI.instance;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static List<TowerModel> GetTowerListForTowerType(this Game game, string towerSet)
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
            return game.model?.heroSet;
        }

        /// <summary>
        /// Get all PowerDetailModels
        /// </summary>
        public static Il2CppReferenceArray<PowerDetailsModel> GetPowerDetailModels(this Game game)
        {
            return game.model?.powerSet;
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
        /// <param name="amount">Amount to add</param>
        public static void AddMonkeyMoney(this Game game, double amount)
        {
            KonFuze monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value += amount;
        }

        /// <summary>
        /// Set player's Monkey Money amount
        /// </summary>
        /// <param name="amount">Value to set Monkey Money to</param>
        public static void SetMonkeyMoney(this Game game, double amount)
        {
            KonFuze monkeyMoney = game.GetPlayerProfile()?.monkeyMoney;
            if (monkeyMoney != null)
                monkeyMoney.Value = amount;
        }
    }
}