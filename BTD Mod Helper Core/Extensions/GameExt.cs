using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api;
using System.Runtime.InteropServices;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {
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
