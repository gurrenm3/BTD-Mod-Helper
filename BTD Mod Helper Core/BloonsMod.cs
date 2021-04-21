using System;
using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api.InGame_Mod_Options;
using MelonLoader;

namespace BTD_Mod_Helper
{
    public abstract class BloonsMod : MelonMod
    {
        internal Dictionary<string, ModSetting> ModSettings;
        
        /// <summary>
        /// Github API URL used to check if this mod is up to date.
        ///
        ///     For example: "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases"
        /// </summary>
        public virtual string GithubReleaseURL => "";
        
        
        /// <summary>
        /// As an alternative to a GithubReleaseURL, a direct link to a web-hosted version of the .cs file that
        /// has the "MelonInfo" attribute with the version of your mod
        ///
        ///     
        ///     For example: "https://raw.githubusercontent.com/doombubbles/BTD6-Mods/main/MegaKnowledge/Main.cs"
        ///
        ///     because the file contains
        ///     [assembly: MelonInfo(typeof(MegaKnowledge.Main), "Mega Knowledge", "1.0.1", "doombubbles")]
        /// </summary>
        public virtual string MelonInfoCsURL => "";
        
        
        /// <summary>
        /// Link that people should be prompted to go to when this mod is out of date.
        ///
        ///     For example: "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest"
        /// </summary>
        public virtual string LatestURL => "";
        
        
        public static int CostForDifficulty(int cost, string difficulty)
        {
            float price = cost;
            MelonLogger.Msg(difficulty);
            switch (difficulty)
            {
                case "Easy":
                    price *= .85f;
                    break;
                case "Hard":
                    price *= 1.08f;
                    break;
                case "Impoppable":
                    price *= 1.2f;
                    break;
            }
            return (int) (5 * Math.Round(price / 5));
        }
        
        public static int CostForDifficulty(int cost, GameModel gameModel)
        {
            return CostForDifficulty(cost, gameModel.difficultyId);
        }
        
        public static int CostForDifficulty(int cost, InGame inGame)
        {
            return CostForDifficulty(cost, inGame.SelectedDifficulty);
        }
    }
}