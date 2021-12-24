using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Updater;
using System.Linq;
using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Extensions;
using System.IO;
using Assets.Scripts.Utils;
using System.Diagnostics;
using Assets.Scripts.Models;
using Assets.Scripts.Unity.UI_New.Main;

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsTD6Mod
    {
        public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";
        internal readonly List<UpdateInfo> modsNeedingUpdates = new List<UpdateInfo>();

        public const string coopMessageCode = "BTD6_ModHelper";
        public const string currentVersion = ModHelperData.currentVersion;

        public override void OnApplicationStart()
        {
            // Mod Updating
            MelonLogger.Msg("Checking for updates...");
            var updateDir = this.GetModDirectory() + "\\UpdateInfo";
            Directory.CreateDirectory(updateDir);
            UpdateHandler.SaveModUpdateInfo(updateDir);
            var allUpdateInfo = UpdateHandler.LoadAllUpdateInfo(updateDir);
            UpdateHandler.CheckForUpdates(allUpdateInfo, modsNeedingUpdates);

            
            // Mod Settings
            var settingsDir = this.GetModSettingsDir(true);
            ModSettingsHandler.InitializeModSettings(settingsDir);
            ModSettingsHandler.LoadModSettings(settingsDir);
            MainMenu.hasSeenModderWarning = AutoHideModdedClientPopup;


            Schedule_GameModel_Loaded();

            MelonLogger.Msg("Mod has finished loading");
            
            // Load Content from other mods
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>().OrderByDescending(mod => mod.Priority))
            {
                try
                {
                    ResourceHandler.LoadEmbeddedTextures(mod);
                    ResourceHandler.LoadEmbeddedBundles(mod);
                    ModContent.LoadModContent(mod);
                }
                catch (Exception e)
                {
                    MelonLogger.Error("Critical failure when loading resources for mod " + mod.Info.Name);
                    MelonLogger.Error(e);
                }
            }
        }

        public override void OnGameModelLoaded(GameModel model)
        {
            /* Save for now, useful for when they add new upgrades
             Game.instance.model.upgrades.ForEach(upgrade =>
            {
                var textInfo = new CultureInfo("en-US", false).TextInfo;
                var p = textInfo.ToTitleCase(upgrade.name.Replace(".", " ")).Replace(" ", "").Replace("+", "I")
                    .Replace("Buccaneer-", "").Replace("-", "").Replace("'", "").Replace(":", "");
                MelonLogger.Msg($"public const string {p} = \"{upgrade.name}\";");
            });
            */
        }

        public static ModSettingBool CleanProfile = true;

        private static ModSettingBool AutoHideModdedClientPopup = false;
        
        private static ModSettingBool OpenLocalDirectory = new ModSettingBool(false)
        {
            displayName = "Open Local Files Directory",
            IsButton = true
        };

        private static ModSettingBool ExportTowerJSONs = new ModSettingBool(false)
        {
            displayName = "Export Tower JSONs",
            IsButton = true
        };

        private static ModSettingBool ExportUpgradeJSONs = new ModSettingBool(false)
        {
            displayName = "Export Upgrade JSONs",
            IsButton = true
        };



        internal static ShowModOptions_Button modsButton;

        private static bool afterTitleScreen;

        public override void OnUpdate()
        {
            KeyCodeHooks();
            
            ModByteLoader.OnUpdate();

            if (Game.instance is null)
                return;
            
            if (PopupScreen.instance != null && afterTitleScreen)
                UpdateHandler.AnnounceUpdates(modsNeedingUpdates, this.GetModDirectory());

            if (InGame.instance is null)
                return;

            NotificationMgr.CheckForNotifications();
        }

        private static void KeyCodeHooks()
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                    PerformHook(mod => mod.OnKeyDown(key));

                if (Input.GetKeyUp(key))
                    PerformHook(mod => mod.OnKeyUp(key));

                if (Input.GetKey(key))
                    PerformHook(mod => mod.OnKeyHeld(key));
            }
        }
        
        public override void OnTitleScreen()
        {
            ModSettingsHandler.SaveModSettings(this.GetModSettingsDir());

            if (!scheduledInGamePatch)
                Schedule_InGame_Loaded();
            
            AutoSave.InitAutosave(this.GetModSettingsDir(true));

            OpenLocalDirectory.OnInitialized.Add(option =>
            {
                var buttonOption = (ButtonOption)option;
                buttonOption.ButtonText.text = "Open";
                buttonOption.Button.AddOnClick(() => Process.Start(FileIOUtil.sandboxRoot));
            });

            ExportTowerJSONs.OnInitialized.Add(option =>
            {
                var buttonOption = (ButtonOption)option;
                buttonOption.ButtonText.text = "Export";
                buttonOption.Button.AddOnClick(() =>
                {
                    MelonLogger.Msg("Dumping Towers to local files");
                    foreach (var tower in Game.instance.model.towers)
                    {
                        var path = "Towers/" + tower.baseId + "/" + tower.name + ".json";
                        try
                        {
                            FileIOUtil.SaveObject(path, tower);
                            MelonLogger.Msg("Saving " + FileIOUtil.sandboxRoot + path);
                        }
                        catch (Exception)
                        {
                            MelonLogger.Error("Failed to save " + FileIOUtil.sandboxRoot + path);
                        }
                    }

                    PopupScreen.instance.ShowOkPopup($"Finished exporting towers to {FileIOUtil.sandboxRoot + "Towers"}");
                });
            });
            
            ExportUpgradeJSONs.OnInitialized.Add(option =>
            {
                var buttonOption = (ButtonOption)option;
                buttonOption.ButtonText.text = "Export";
                buttonOption.Button.AddOnClick(() =>
                {
                    MelonLogger.Msg("Exporting Upgrades to local files");
                    foreach (var upgrade in Game.instance.model.upgrades)
                    {
                        var path = "Upgrades/" + upgrade.name + ".json";
                        try
                        {
                            FileIOUtil.SaveObject(path, upgrade);
                            MelonLogger.Msg("Saving " + FileIOUtil.sandboxRoot + path);
                        }
                        catch (Exception)
                        {
                            MelonLogger.Error("Failed to save " + FileIOUtil.sandboxRoot + path);
                        }
                    }

                    PopupScreen.instance.ShowOkPopup(
                        $"Finished exporting upgrades to {FileIOUtil.sandboxRoot + "Upgrades"}");
                });
            });

            afterTitleScreen = true;
        }

        private void Schedule_GameModel_Loaded()
        {
            TaskScheduler.ScheduleTask(() => { PerformHook(mod => mod.OnGameModelLoaded(Game.instance.model)); },
                () => Game.instance?.model != null);
        }

        bool scheduledInGamePatch;

        private void Schedule_InGame_Loaded()
        {
            scheduledInGamePatch = true;
            TaskScheduler.ScheduleTask(() => { PerformHook(mod => mod.OnInGameLoaded(InGame.instance)); },
                () => InGame.instance?.GetSimulation() != null);
        }

        public override void OnInGameLoaded(InGame inGame) => scheduledInGamePatch = false;

        public static void PerformHook(Action<BloonsTD6Mod> action)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsTD6Mod>().OrderByDescending(mod => mod.Priority))
            {
                if (!mod.CheatMod || !Game.instance.CanGetFlagged())
                {
                    try
                    {
                        action.Invoke(mod);
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Error(e);
                    }
                }
            }
        }

        public override void OnMainMenu()
        {
            if (UpdateHandler.updatedMods && PopupScreen.instance != null)
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Restart Required",
                    "You've downloaded new updates for mods, but still need to restart your game to apply them.\n" +
                    "\nWould you like to do that now?", new Action(() =>
                    {
                        MelonLogger.Msg("Quitting the game");
                        MenuManager.instance.QuitGame();
                    }),
                    "Yes, quit the game", new Action(() => { }), "Not now", Popup.TransitionAnim.Update);
                UpdateHandler.updatedMods = false;
            }
        }

        #region Autosave

        public static ModSettingBool openBackupDir = new ModSettingBool(true)
        {
            IsButton = true,
            displayName = "Open Backup Directory"
        };

        public static ModSettingBool openSaveDir = new ModSettingBool(true)
        {
            IsButton = true,
            displayName = "Open Save Directory"
        };

        public static ModSettingString autosavePath = new ModSettingString("")
        {
            displayName = "Backup Directory"
        };

        public static ModSettingInt timeBetweenBackup = new ModSettingInt(30)
        {
            displayName = "Minutes Between Each Backup"
        };

        public static ModSettingInt maxSavedBackups = new ModSettingInt(10)
        {
            displayName = "Max Saved Backups"
        };

        public override void OnMatchEnd() => AutoSave.backup.CreateBackup();

        #endregion
    }
}