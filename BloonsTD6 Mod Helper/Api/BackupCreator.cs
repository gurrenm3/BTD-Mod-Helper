using System.IO;
using System.Linq;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using System;

namespace BTD_Mod_Helper.Api
{
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
            MelonLoader.MelonLogger.Msg("Attempting to backup Profile...");
            string saveDir = Game.instance.GetSaveDirectory();
            if (string.IsNullOrEmpty(saveDir))
            {
                MelonLoader.MelonLogger.Error("Unable to backup Profile. Save directory not found");
                return;
            }

            MelonLoader.MelonLogger.Msg("Creating Profile Backup...");
            string originalPath = $"{saveDir}\\Profile.save";

            string time = DateTime.Now.ToString().Replace("/", "-").Replace(":", ".");
            string copyPath = $"{_backupDir}\\Profile_{time}.Save";
            File.Copy(originalPath, copyPath);

            while (IsOverMaxBackups())
                DeleteOldestBackup();
        }

        public void MoveBackupDir(string newBackupDir)
        {
            if (string.IsNullOrEmpty(_backupDir) || string.IsNullOrEmpty(newBackupDir))
            {
                MelonLoader.MelonLogger.Error("Can't move Autosave directory because either" +
                    " the old backup dir or new backup dir was not valid");
                return;
            }

            var files = GetAllBackups();
            foreach (var file in files)
                File.Move(file.FullName, $"{newBackupDir}\\{file.Name}.{file.Extension}");

            _backupDir = newBackupDir;
        }

        private void DeleteOldestBackup()
        {
            var backups = GetAllBackups().OrderBy(backup => backup.CreationTime.ToFileTime());
            File.Delete(backups.ElementAt(0).FullName);
        }
    }
}
