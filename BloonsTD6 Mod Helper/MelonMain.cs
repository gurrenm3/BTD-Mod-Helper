using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.InGame_Mod_Options;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Updater;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Main.Scenes;
using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Extensions;
using Newtonsoft.Json;

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsTD6Mod
    {
        internal static readonly string modDir =
            $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        internal static readonly string ModSettingsDir = Path.Combine(modDir, "Mod Settings");
        
        public const string coopMessageCode = "BTD6_ModHelper";
        public const string currentVersion = "1.0.2";

        private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        private readonly List<UpdateInfo> modsNeedingUpdates = new List<UpdateInfo>();

        public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Mod has finished loading");
            MelonLogger.Msg("Checking for updates...");

            var updateDir = modDir + "\\UpdateInfo";
            if (!Directory.Exists(updateDir))
            {
                Directory.CreateDirectory(updateDir);
            }

            UpdateHandler.SaveModUpdateInfo(updateDir);
            var allUpdateInfo = UpdateHandler.LoadAllUpdateInfo(updateDir);
            UpdateHandler.CheckForUpdates(allUpdateInfo, modsNeedingUpdates);
                
            ModSettingsHandler.InitializeModSettings(ModSettingsDir);
            ModSettingsHandler.LoadModSettings(ModSettingsDir);
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (PopupScreen.instance != null)
            {
                UpdateHandler.AnnounceUpdates(modsNeedingUpdates, modDir);
            }

            // used to test new api methods
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
            }

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DoPatchMethods(mod => mod.OnKeyDown(key));
                }

                if (Input.GetKeyUp(key))
                {
                    DoPatchMethods(mod => mod.OnKeyUp(key));
                }

                if (Input.GetKey(key))
                {
                    DoPatchMethods(mod => mod.OnKeyHeld(key));
                }
            }

            if (InGame.instance is null)
                return;


            if (useModOptionsDEBUG && modOptionsUI is null)
                modOptionsUI = new ModOptionsMenu();

            NotificationMgr.CheckForNotifications();
        }

        public override void OnMainMenu()
        {
            if (UpdateHandler.updatedMods && PopupScreen.instance != null)
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Restart Required",
                    "You've downloaded new updates for mods, but still need to restart your game to apply them.\n" +
                    "\nWould you like to do that now?", new Action(() => MenuManager.instance.QuitGame()),
                    "Yes, quit the game", null, "Not now", Popup.TransitionAnim.Update);
                UpdateHandler.updatedMods = false;
            }
            
            //TODO: with only external changing, settings should load when going to the main menu
            //TODO: with in game changing, settings should save when going to the main menu
            //ModSettingsHandler.SaveModSettings(modSettingsDir);
            ModSettingsHandler.LoadModSettings(ModSettingsDir);
        }


        public static void DoPatchMethods(Action<BloonsTD6Mod> action)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsTD6Mod>())
            {
                action.Invoke(mod);
            }
        }
    }
}