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

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsTD6Mod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public const string coopMessageCode = "BTD6_ModHelper";
        public const string currentVersion = "1.0.1";

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
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (PopupScreen.instance != null)
            {
                UpdateHandler.AnnounceUpdates(this, modsNeedingUpdates);
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


        public static void DoPatchMethods(Action<BloonsTD6Mod> action)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsTD6Mod>())
            {
                action.Invoke(mod);
            }
        }
    }
}