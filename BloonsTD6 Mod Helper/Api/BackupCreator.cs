using System;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api;

class BackupCreator
{
    private long _maxBackups;
    private string _backupDir;

    public BackupCreator(string backupDir, long maxBackups)
    {
        _backupDir = backupDir;
        _maxBackups = maxBackups;
    }

    public void SetMaxBackups(long max) => _maxBackups = max;

    private FileInfo[] GetAllBackups() => new DirectoryInfo(_backupDir).GetFiles();

    private bool IsOverMaxBackups() => GetAllBackups().Length > _maxBackups;

    public void CreateBackup()
    {
        ModHelper.Log("Attempting to backup Profile...");
        var saveDir = Game.instance.GetSaveDirectory();
        if (string.IsNullOrEmpty(saveDir))
        {
            return;
        }

        ModHelper.Log("Creating Profile Backup...");
        var originalPath = $"{saveDir}\\Profile.save";

        var time = DateTime.Now.ToString().Replace("/", "-").Replace(":", ".");
        var copyPath = $"{_backupDir}\\Profile_{time}.Save";
        File.Copy(originalPath, copyPath);

        while (IsOverMaxBackups())
            DeleteOldestBackup();
    }

    public void MoveBackupDir(string newBackupDir)
    {
        if (string.IsNullOrEmpty(_backupDir) || string.IsNullOrEmpty(newBackupDir))
        {
            ModHelper.Error("Can't move Autosave directory because either" +
                            " the old backup dir or new backup dir was not valid");
            return;
        }

        var files = GetAllBackups();
        foreach (var file in files)
        {
            var destFileName = $"{newBackupDir}\\{file.Name}.{file.Extension}";
            try
            {
                File.Move(file.FullName, destFileName);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        _backupDir = newBackupDir;
    }

    private void DeleteOldestBackup()
    {
        var backups = GetAllBackups().OrderBy(backup => backup.CreationTime.ToFileTime());
        File.Delete(backups.ElementAt(0).FullName);
    }
}