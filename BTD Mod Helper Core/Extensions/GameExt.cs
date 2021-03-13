using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using BTD_Mod_Helper.Api;


using System.Runtime.InteropServices;

#if BloonsTD6
using NinjaKiwi.LiNK;
#elif BloonsAT
using Ninjakiwi.LiNK;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {
        /// <summary>
        /// Get Player LinkAccount. Contains limited info about player's NinjaKiwi account
        /// </summary>
        public static LiNKAccount GetPlayerLiNKAccount(this Game game)
        {
            return game.GetPlayerService()?.Player?.LiNKAccount;
        }

        public static ProfileModel GetPlayerProfile(this Game game)
        {
            return game.GetPlayerService()?.Player?.Data;
        }

        /// <summary>
        /// Get the Profile for the player
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
        /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
        /// </summary>
        /// <param name="message">Message body</param>
        /// <param name="title">Message title. Will be mod name by default</param>
        public static void ShowMessage(this Game game, string message, [Optional] string title)
        {
            game.ShowMessage(message, 2f, title);
        }

        /// <summary>
        /// Uses custom message popup to show a message in game. Currently only works in active game sessions and not on Main Menu
        /// </summary>
        /// <param name="message">Message body</param>
        /// <param name="displayTime">Time to show message on screen</param>
        /// <param name="title">Message title. Will be mod name by default</param>
        public static void ShowMessage(this Game game, string message, float displayTime, [Optional] string title)
        {
            NkhMsg msg = new NkhMsg
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
