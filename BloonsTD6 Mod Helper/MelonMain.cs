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
using Assets.Scripts.Utils;
using System.Diagnostics;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.BTD6_UI;
using JetBrains.Annotations;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsTD6Mod
    {
        public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";

        public override void OnApplicationStart()
        {
            ModContentInstances.SetInstance(GetType(), this);

            // Mod Updating
            UpdateHandler.CheckModsForUpdates();

            // Mod Settings
            var settingsDir = this.GetModSettingsDir(true);
            ModSettingsHandler.InitializeModSettings(settingsDir);
            ModSettingsHandler.LoadModSettings(settingsDir);

            MainMenu.hasSeenModderWarning = AutoHideModdedClientPopup;

            Schedule_GameModel_Loaded();

            ModHelper.Log("Mod has finished loading");

            // Load Content from other mods
            ModHelper.LoadAllMods();
        }


        public static readonly ModSettingBool CleanProfile = true;

        private static readonly ModSettingBool AutoHideModdedClientPopup = false;

        private static readonly ModSettingBool OpenLocalDirectory = new ModSettingBool(false)
        {
            displayName = "Open Local Files Directory",
            IsButton = true,
            OnButtonPressed = _ => Process.Start(FileIOUtil.sandboxRoot),
            ButtonText = "Open"
        };

        private static readonly ModSettingBool ExportGameModel = new ModSettingBool(false)
        {
            displayName = "Export Game Model",
            IsButton = true,
            OnButtonPressed = _ =>
            {
                GameModelExporter.ExportAll();
                PopupScreen.instance.ShowOkPopup(
                    $"Finished exporting Game Model to {FileIOUtil.sandboxRoot}");
            },
            ButtonText = "Export"
        };


        private static bool afterTitleScreen;

        public override void OnUpdate()
        {
            KeyCodeHooks();

            ModByteLoader.OnUpdate();

            if (Game.instance is null)
                return;

            if (PopupScreen.instance != null && afterTitleScreen)
                UpdateHandler.AnnounceUpdates(UpdateHandler.ModsNeedingUpdates, this.GetModDirectory());

            if (InGame.instance is null)
                return;

            NotificationMgr.CheckForNotifications();
        }

        private static void KeyCodeHooks()
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key)) ModHelper.PerformHook(mod => mod.OnKeyDown(key));

                if (Input.GetKeyUp(key)) ModHelper.PerformHook(mod => mod.OnKeyUp(key));

                if (Input.GetKey(key)) ModHelper.PerformHook(mod => mod.OnKeyHeld(key));
            }
        }

        public override void OnTitleScreen()
        {
            ModSettingsHandler.SaveModSettings(this.GetModSettingsDir());

            if (!scheduledInGamePatch)
                Schedule_InGame_Loaded();

            AutoSave.InitAutosave(this.GetModSettingsDir(true));


            foreach (var gameMode in Game.instance.model.mods)
            {
                if (gameMode.mutatorMods == null) continue;
                foreach (var mutatorMod in gameMode.mutatorMods)
                {
                    var typeName = mutatorMod.GetIl2CppType().Name;
                    if (!mutatorMod.name.StartsWith(typeName))
                    {
                        mutatorMod.name = mutatorMod._name = typeName + "_" + mutatorMod.name;
                    }
                }
            }

            afterTitleScreen = true;
        }

        private void Schedule_GameModel_Loaded()
        {
            TaskScheduler.ScheduleTask(
                () => { ModHelper.PerformHook(mod => mod.OnGameModelLoaded(Game.instance.model)); },
                () => Game.instance?.model != null);
        }

        bool scheduledInGamePatch;

        private void Schedule_InGame_Loaded()
        {
            scheduledInGamePatch = true;
            TaskScheduler.ScheduleTask(() => { ModHelper.PerformHook(mod => mod.OnInGameLoaded(InGame.instance)); },
                () => InGame.instance?.GetSimulation() != null);
        }

        public override void OnInGameLoaded(InGame inGame) => scheduledInGamePatch = false;

        public override void OnMainMenu()
        {
            if (UpdateHandler.updatedMods && PopupScreen.instance != null)
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Restart Required",
                    "You've downloaded new updates for mods, but still need to restart your game to apply them.\n" +
                    "\nWould you like to do that now?", new Action(() =>
                    {
                        ModHelper.Log("Quitting the game");
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