using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using System;
using UnityEngine;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Updater;
using Assets.Scripts.Unity.Menu;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Utils;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Main;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using TMPro;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;

namespace BTD_Mod_Helper
{
    internal class MelonMain : BloonsTD6Mod
    {
#pragma warning disable CS0672
        public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
        public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";
#pragma warning restore CS0672

        public override void OnApplicationStart()
        {
            ModContentInstances.SetInstance(GetType(), this);

            try
            {
                ModHelperHttp.Init();
                ModHelperGithub.Init();
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }

            // Mod Updating
            UpdateHandler.CheckModsForUpdates();

            // Mod Settings
            var settingsDir = this.GetModSettingsDir(true);
            ModSettingsHandler.InitializeModSettings(settingsDir);
            ModSettingsHandler.LoadModSettings(settingsDir);

            MainMenu.hasSeenModderWarning = AutoHideModdedClientPopup;

            Schedule_GameModel_Loaded();

            // Load Content from other mods
            ModHelper.LoadAllMods();

            ModGameMenu.PatchAllTheOpens(HarmonyInstance);

            Task.Run(ModHelperGithub.PopulateMods);

            ModHelper.Log("Mod has finished loading");

            /*VanillaSpriteGenerator.GenerateVanillaSprites(
                @"C:\Users\jpgale\Documents\Coding\BTD-Mod-Helper\BloonsTD6 Mod Helper\Api\Enums\VanillaSprites.cs",
                @"C:\Users\jpgale\Pictures\Dump\Sprites"
            );*/
        }

        public static readonly ModSettingBool CleanProfile = true;

        private static readonly ModSettingBool AutoHideModdedClientPopup = false;

        private static readonly ModSettingButton OpenLocalDirectory = new ModSettingButton
        {
            displayName = "Open Local Files Directory",
            action = () => Process.Start(FileIOUtil.sandboxRoot),
            buttonText = "Open"
        };

        private static readonly ModSettingButton ExportGameModel = new ModSettingButton
        {
            displayName = "Export Game Model",
            action = () =>
            {
                GameModelExporter.ExportAll();
                PopupScreen.instance.ShowOkPopup(
                    $"Finished exporting Game Model to {FileIOUtil.sandboxRoot}");
            },
            buttonText = "Export"
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
            ModSettingsHandler.SaveModSettings(this.GetModSettingsDir(), true);

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

        public static readonly ModSettingCategory AutoSaveCategory = "Auto Save Settings";

        public static readonly ModSettingButton OpenBackupDir = new ModSettingButton(AutoSave.OpenBackupDir)
        {
            displayName = "Open Backup Directory",
            buttonText = "Open",
            category = AutoSaveCategory
        };

        public static readonly ModSettingButton OpenSaveDir = new ModSettingButton(AutoSave.OpenAutoSaveDir)
        {
            displayName = "Open Save Directory",
            buttonText = "Open",
            category = AutoSaveCategory
        };

        public static readonly ModSettingString AutosavePath = new ModSettingString(Path.Combine(ModHelper.ModHelperDirectory, "Mod Settings"))
        {
            displayName = "Backup Directory",
            onSave = AutoSave.SetAutosaveDirectory,
            category = AutoSaveCategory,
            modifyInput = inputField => inputField.Text.Text.fontSize = 50
        };

        public static readonly ModSettingInt TimeBetweenBackup = new ModSettingInt(30)
        {
            displayName = "Minutes Between Each Backup",
            category = AutoSaveCategory
        };

        public static readonly ModSettingInt MaxSavedBackups = new ModSettingInt(10)
        {
            displayName = "Max Saved Backups",
            onSave = max => AutoSave.backup.SetMaxBackups(max),
            category = AutoSaveCategory
        };

        public override void OnMatchEnd() => AutoSave.backup.CreateBackup();

        #endregion
    }
}