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
using System.Linq;
using System.Threading.Tasks;

namespace BTD_Mod_Helper
{
    internal class MelonMain : MelonMod
    {
        internal static string modDir = $"{Environment.CurrentDirectory}\\Mods\\{Assembly.GetExecutingAssembly().GetName().Name}";

        public const string githubReleaseURL = "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public const string githubLatestURL = "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";
        public const string coopMessageCode = "BTD6_ModHelper";
        public const string currentVersion = "1.0.0";

        private bool useModOptionsDEBUG = false;
        private ModOptionsMenu modOptionsUI;

        private Dictionary<string, string> updateURLs = new Dictionary<string, string>();


        public override async void OnApplicationStart()
        {
            MelonLogger.Msg("Mod has finished loading");

            MelonLogger.Msg("Checking for updates...");
            var updater = new UpdateChecker(githubReleaseURL);
            var releaseInfo = await updater.GetLatestReleaseAsync();
            if (updater.IsUpdate(Info.Version, releaseInfo))
            {
                updateURLs[Info.Name] = githubLatestURL;
            }

            Parallel.ForEach(
                MelonHandler.Mods.OfType<BloonsTD6Mod>(),
                async mod =>
                {
                    if (mod.GithubReleaseURL != "")
                    {
                        try
                        {
                            updater = new UpdateChecker(mod.GithubReleaseURL);
                            releaseInfo = await updater.GetLatestReleaseAsync();
                            if (updater.IsUpdate(mod.Info.Version, releaseInfo))
                            {
                                updateURLs[mod.Info.Name] = mod.LatestURL;
                            }
                        }
                        catch (Exception e)
                        {
                            MelonLogger.Warning($"Encountered exception trying to check {mod.Info.Name} for updates: ");
                            MelonLogger.Warning(e.Message);
                        }
                    }
                }
            );
            
            MelonLogger.Msg("Finished checking for updates.");
        }

        public override void OnUpdate()
        {
            if (Game.instance is null)
                return;

            if (PopupScreen.instance != null && updateURLs.Count > 0)
            {
                foreach (var (modName, updateURL) in updateURLs)
                {
                    PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "An Update is Available!",
                        $"An update is available for the mod \"{modName}\". Would you like to be taken to the download page?\n\n" +
                        $"NOTE: Some mods may not work if you aren't using the latest version of this mod",
                        new Action(() => { Process.Start(updateURL); }), "YES", new Action(() => { }),
                        "Not now", Popup.TransitionAnim.Update, instantClose:true);
                }
                
                updateURLs.Clear();
            }

            // used to test new api methods
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                
            }

            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyDown(key);
                    });
                }

                if (Input.GetKeyUp(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyUp(key);
                    });
                }

                if (Input.GetKey(key))
                {
                    DoPatchMethods(mod =>
                    {
                        mod.OnKeyHeld(key);
                    });
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