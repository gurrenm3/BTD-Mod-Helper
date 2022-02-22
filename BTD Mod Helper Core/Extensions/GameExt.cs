using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using BTD_Mod_Helper.Api;
using Assets.Scripts.Models;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using BTD_Mod_Helper.Api.Enums;
using Assets.Scripts.Utils;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.UI_New;

#if BloonsTD6
using NinjaKiwi.LiNK;
using NinjaKiwi.Common;
#elif BloonsAT
using Ninjakiwi.LiNK;
using Assets.Scripts.Unity.Localization;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {
        /// <summary>
        /// (Cross-Game compatible) Returns the instance of the Map Loader.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static MapLoader GetMapLoader(this Game game)
        {
#if BloonsTD6
            return UI.instance?.mapLoader;
#elif BloonsAT
            return game.MapLoader;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Returns a new SpriteReference that uses the given guid
        /// </summary>
        /// <param name="game"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static SpriteReference CreateSpriteReference(this Game game, string guid)
        {
            return ModContent.CreateSpriteReference(guid);
        }

        /// <summary>
        /// (Cross-Game compatible) Returns whether or not the player's account is currently flagged/hackerpooled
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static bool IsAccountFlagged(this Game game)
        {
#if BloonsTD6
            var hackerStatus = game.GetBtd6Player().Hakxr;
            return hackerStatus.genrl || hackerStatus.ledrbrd;
#elif BloonsAT
            return game.GetAdventureTimePlayer().HasStatusFlags();
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Get the instance of LocalizationManager
        /// </summary>
        public static LocalizationManager GetLocalizationManager(this Game game)
        {
#if BloonsTD6
            return LocalizationManager.Instance;
#elif BloonsAT
            return game.localizationManager;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute right now as a Coroutine
        /// </summary>
        /// <param name="game"></param>
        /// <param name="iEnumerator"></param>
        public static void ScheduleTask(this Game game, IEnumerator iEnumerator) => MelonLoader.MelonCoroutines.Start(iEnumerator);

        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame
        /// </summary>
        /// <param name="game"></param>
        /// <param name="action">The action you want to execute once it's time to run your task</param>
        /// <param name="waitCondition">Wait for this to be true before executing task</param>
        public static void ScheduleTask(this Game game, Action action, Func<bool> waitCondition = null) => game.ScheduleTask(action, ScheduleType.WaitForFrames, 0, waitCondition);

        /// <summary>
        /// (Cross-Game compatible) Schedule a task to execute later on as a Coroutine
        /// </summary>
        /// <param name="game"></param>
        /// <param name="action">The action you want to execute once it's time to run your task</param>
        /// <param name="scheduleType">How you want to wait for your task</param>
        /// <param name="amountToWait">The amount you want to wait</param>
        /// /// <param name="waitCondition">Wait for this to be true before executing task</param>
        public static void ScheduleTask(this Game game, Action action, ScheduleType scheduleType, int amountToWait , Func<bool> waitCondition = null)
        {
            MelonLoader.MelonCoroutines.Start(TaskScheduler.Coroutine(action, scheduleType, amountToWait, waitCondition));
        }


        /// <summary>
        /// (Cross-Game compatible) Get Player LinkAccount. Contains limited info about player's NinjaKiwi account
        /// </summary>
        public static LiNKAccount GetPlayerLiNKAccount(this Game game)
        {
            return game.GetPlayerService()?.Player?.LiNKAccount;
        }

        /// <summary>
        /// (Cross-Game compatible) Get the ProfileModel for the Player
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static ProfileModel GetPlayerProfile(this Game game)
        {
            return game.GetPlayerService()?.Player?.Data;
        }

        /// <summary>
        /// (Cross-Game compatible) Get the PlayerService for the player
        /// </summary>
        public static PlayerService GetPlayerService(this Game game)
        {
#if BloonsTD6
            return game.playerService;
#elif BloonsAT
            return game.PlayerService;
#endif
        }

        /// <summary>
        /// (Cross-Game compatible) Get GameModel. Same as using Game.instance.model
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static GameModel GetModel(this Game game)
        {
            return game.model;
        }

        /// <summary>
        /// (Cross-Game compatible) Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
        /// </summary>
        /// <param name="game">the Game instance</param>
        /// <param name="message">Message body</param>
        /// <param name="title">Message title. Will be mod name by default</param>
        public static void ShowMessage(this Game game, string message, [Optional] string title)
        {
            game.ShowMessage(message, 2f, title);
        }

        /// <summary>
        /// (Cross-Game compatible) Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
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
    }
}
