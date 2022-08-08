using System.Diagnostics;
using System.IO;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.Popups;
using static BTD_Mod_Helper.MelonMain;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Implements the features of the AutoSave mod
/// </summary>
public static class AutoSave
{
    internal static BackupCreator backup;

    internal static bool autosaveInit;
    // internal static string profileSaveDir;

    internal static void InitAutosave(string settingsDir)
    {
        if (autosaveInit)
            return;

        ModHelper.Log("Starting to initiate profile AutoSaving...");
        InitAutosaveSettings(settingsDir);
        backup = new BackupCreator(AutosavePath, MaxSavedBackups);
        ScheduleAutosave();
        autosaveInit = true;

        ModHelper.Log("Successfully initiated profile AutoSaving");
    }

    private static void InitAutosaveSettings(string settingsDir)
    {
        if (string.IsNullOrEmpty(AutosavePath))
        {
            var autosaveDir = settingsDir + "\\Autosave";
            Directory.CreateDirectory(autosaveDir);
            AutosavePath.SetValue(autosaveDir);
            AutosavePath.defaultValue = autosaveDir;
        }
    }

    private static void ScheduleAutosave()
    {
        const int secondsPerMinute = 60;
        TaskScheduler.ScheduleTask(() =>
            {
                backup.CreateBackup();
                ScheduleAutosave();
            },
            Api.Enums.ScheduleType.WaitForSeconds, TimeBetweenBackup * secondsPerMinute);
    }

    internal static void OpenAutoSaveDir()
    {
        var saveDirectory = Game.instance.GetSaveDirectory();
        if (string.IsNullOrEmpty(saveDirectory) || !Directory.Exists(saveDirectory))
        {
            PopupScreen.instance.SafelyQueue(screen =>
                screen.ShowOkPopup("Can't open Save directory because it wasn't found"));
        }
        else
        {
            Process.Start(saveDirectory);
        }
    }

    internal static void OpenBackupDir()
    {
        if (string.IsNullOrEmpty(AutosavePath) || !Directory.Exists(AutosavePath))
        {
            PopupScreen.instance.SafelyQueue(screen =>
                screen.ShowOkPopup("Can't open Backup directory because it wasn't found"));
        }
        else
        {
            Process.Start(AutosavePath);
        }
    }

    internal static void SetAutosaveDirectory(string newPath)
    {
        if (!string.IsNullOrEmpty(newPath))
        {
            Directory.CreateDirectory(newPath);
            backup.MoveBackupDir(newPath);
        }
    }
}