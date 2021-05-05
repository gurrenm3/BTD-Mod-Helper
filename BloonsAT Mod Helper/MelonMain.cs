using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.InGame_Mod_Options;
using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using BTD_Mod_Helper.Api.Updater;
using BTD_Mod_Helper.Extensions;
using System.IO;
using System.Collections.Generic;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Behaviors;
using System.Linq;

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsATMod
    {
        public const string currentVersion = "1.0.3";

        /*private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        private readonly List<UpdateInfo> modsNeedingUpdates = new List<UpdateInfo>();*/

        public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";

        public override void OnApplicationStart()
        {
            
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            // used to test new api methods
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
            }
        }

        public override void OnFrontEndWorld()
        {
            // this code won't work for BATTD because it doesn't have PopupScreen.instance. Need to find replacement
            /*if (UpdateHandler.updatedMods && PopupScreen.instance != null)
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Restart Required",
                    "You've downloaded new updates for mods, but still need to restart your game to apply them.\n" +
                    "\nWould you like to do that now?", new Action(() => MenuManager.instance.QuitGame()),
                    "Yes, quit the game", null, "Not now", Popup.TransitionAnim.Update);
                UpdateHandler.updatedMods = false;
            }*/

            //TODO: with only external changing, settings should load when going to the main menu
            //TODO: with in game changing, settings should save when going to the main menu
            //ModSettingsHandler.SaveModSettings(modSettingsDir);
            ModSettingsHandler.LoadModSettings(ModSettingsDir);
        }

        public static void DoPatchMethods(Action<BloonsATMod> action) => DoPatchMethods<BloonsATMod>(action);
    }
}