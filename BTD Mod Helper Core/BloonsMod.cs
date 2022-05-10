﻿using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using UnityEngine;
using BTD_Mod_Helper.Api;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BloonsMod : MelonMod
    {
        /// <summary>
        /// All ModContent in ths mod
        /// </summary>
        public IReadOnlyList<ModContent> Content { get; internal set; }

        internal Dictionary<string, ModSetting> ModSettings;
        
        /// <summary>
        /// The prefix used for the IDs of towers, upgrades, etc for this mod to prevent conflicts with other mods
        /// </summary>
        public virtual string IDPrefix => Assembly.GetName().Name + "-";
        
        /// <summary>
        /// Setting this to true will prevent your BloonsMod hooks from executing if the player could get flagged for using mods at that time.
        /// 
        /// For example, using mods in public co-op
        /// </summary>
        public virtual bool CheatMod => true;


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


        /// <summary>
        /// Allows you to define ways for other mods to interact with this mod. Other mods could do:
        /// <code>
        /// ModContent.GetMod("YourModName")?.Call("YourOperationName", ...);
        /// </code>
        /// to execute functionality here.
        /// <br/>
        /// </summary>
        /// <param name="operation">A string for the name of the operation that another mods wants to call</param>
        /// <param name="parameters">The parameters that another mod has provided</param>
        /// <returns>A possible result of this call</returns>
        public virtual object Call(string operation, params object[] parameters)
        {
            return null;
        }

        #region API Hooks

        /// <summary>
        /// Called whenever the Mod Options Menu gets opened, after it finishes initializing
        /// </summary>
        public virtual void OnModOptionsOpened()
        {
        }
        /*
        /// <summary>
        /// Called when the Mod Options Menu gets closed
        /// </summary>
        public virtual void OnModOptionsClosed() // not implemented for now
        {
        }*/

        #endregion

        #region Input Hooks

        /// <summary>
        /// Called on the frame that a key starts being held
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKeyDown
        /// </summary>
        public virtual void OnKeyDown(KeyCode keyCode)
        {
        }

        /// <summary>
        /// Called on the frame that a key stops being held
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKeyUp
        /// </summary>
        public virtual void OnKeyUp(KeyCode keyCode)
        {
        }

        /// <summary>
        /// Called every frame that a key is being held 
        ///
        /// Equivalent to a HarmonyPostFix on Input.GetKey
        /// </summary>
        public virtual void OnKeyHeld(KeyCode keyCode)
        {
        }

        #endregion

        public static int CostForDifficulty(int cost, string difficulty)
        {
            switch (difficulty)
            {
                case "Easy":
                    return CostForDifficulty(cost, .85f);
                case "Hard":
                    return CostForDifficulty(cost, 1.08f);
                case "Impoppable":
                    return CostForDifficulty(cost, 1.2f);
                default:
                    return cost;
            }
        }

        public static int CostForDifficulty(int cost, float multiplier)
        {
            var price = cost * multiplier;
            return (int) (5 * Math.Round(price / 5));
        }
    }
}