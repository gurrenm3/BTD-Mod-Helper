using System.Diagnostics;
using System.IO;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using static BTD_Mod_Helper.MelonMain;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Implements the features of the AutoSave mod
    /// </summary>
    public static class AutoSave
    {
        internal static BackupCreator backup;
        internal static bool autosaveInit;
        internal static string profileSaveDir;

        internal static void InitAutosave(string settingsDir)
        {
            if (autosaveInit)
                return;

            InitAutosaveSettings(settingsDir);
            backup = new BackupCreator(autosavePath, maxSavedBackups);
            ScheduleAutosave();
            autosaveInit = true;

            MelonLogger.Msg("Successfully initiated profile AutoSaving");
        }

        private static void InitAutosaveSettings(string settingsDir)
        {
            string saveDir = Game.instance.GetSaveDirectory();
            if (!string.IsNullOrEmpty(saveDir))
                openSaveDir.OnInitialized.Add((option) => InitOpenDirButton(option, saveDir));
            else
                openSaveDir.OnValueChanged.Add((value) =>
                        PopupScreen.instance.ShowOkPopup("Can't open Save directory because it wasn't found"));

            openBackupDir.OnInitialized.Add((option) => InitOpenDirButton(option, autosavePath));
            maxSavedBackups.OnValueChanged.Add((newMax) => backup.SetMaxBackups(newMax));

            if (string.IsNullOrEmpty(autosavePath))
            {
                var autosaveDir = settingsDir + "\\Autosave";
                Directory.CreateDirectory(autosaveDir);
                autosavePath.SetValue(autosaveDir);
            }
            autosavePath.OnValueChanged.Add((newPath) =>
            {
                if (!string.IsNullOrEmpty(newPath))
                {
                    Directory.CreateDirectory(newPath);
                    backup.MoveBackupDir(newPath);
                }
            });
        }

        private static void ScheduleAutosave()
        {
            const int secondsPerMinute = 60;
            TaskScheduler.ScheduleTask(() =>
                {
                    backup.CreateBackup();
                    ScheduleAutosave();
                },
                Api.Enums.ScheduleType.WaitForSeconds, timeBetweenBackup * secondsPerMinute);
        }

        private static void InitOpenDirButton(SharedOption option, string dir)
        {
            var button = (ButtonOption)option;
            button.ButtonText.text = "Open";
            button.Button.onClick.AddListener(() => Process.Start(dir));
        }
    }
}