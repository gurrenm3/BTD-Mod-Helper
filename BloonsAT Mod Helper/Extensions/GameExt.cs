using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using Assets.Scripts.Unity.UI_New;
using BTD_Mod_Helper.Api;
using Ninjakiwi.LiNK;
using System.Runtime.InteropServices;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameExt
    {
        /// <summary>
        /// Get the Unity Display Factory that manages on screen sprites. This Factory is different from other Factories in the game
        /// </summary>
        public static Assets.Scripts.Unity.Display.DisplayFactory GetDisplayFactory(this Game game)
        {
            return game.scene?.displayFactory;
        }

        public static UISceneManager GetUISceneManager(this Game game)
        {
            return UISceneManager.instance;
        }

        /// <summary>
        /// Get the instance of UI
        /// </summary>
        public static UI GetUI(this Game game)
        {
            return UI.instance;
        }

        /// <summary>
        /// Get the Profile for the player. Contains different info than Btd6Player data
        /// </summary>
        public static ProfileModel GetPlayerProfile(this Game game)
        {
            return game.PlayerService?.Player?.Data;
        }

        /// <summary>
        /// Get the Btd6Player data for the player. Contains different info than PlayerProfile
        /// </summary>
        public static AdventureTimePlayer GetAdventureTimePlayer(this Game game)
        {
            return game.PlayerService?.Player;
        }

        /// <summary>
        /// Get Player LinkAccount. Contains limited info about player's NinjaKiwi account
        /// </summary>
        public static LiNKAccount GetPlayerLiNKAccount(this Game game)
        {
            return game.PlayerService?.Player?.LiNKAccount;
        }

        /// <summary>
        /// Get player's current Gems amount
        /// </summary>
        public static int GetGems(this Game game)
        {   
            return game.GetAdventureTimePlayer().Gems;
        }

        /// <summary>
        /// Add Gems to player's total Gems. Untested
        /// </summary>
        /// <param name="amount">Amount to add</param>
        public static void AddGems(this Game game, int amount)
        {
            game.GetAdventureTimePlayer().AddGems(amount, "", 
                new Il2CppSystem.Nullable<Il2CppSystem.Guid>(), new Il2CppSystem.Nullable<Il2CppSystem.Guid>());
        }
    }
}