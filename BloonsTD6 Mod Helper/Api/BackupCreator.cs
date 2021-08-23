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
            MelonLoader.MelonLogger.Msg("Creating Profile Backup...");
            string originalPath = $"{Game.instance.GetSaveDirectory()}\\Profile.save";

            string time = DateTime.Now.ToString().Replace("/", "-").Replace(":", ".");
            string copyPath = $"{_backupDir}\\Profile_{time}.Save";
            File.Copy(originalPath, copyPath);

            while (IsOverMaxBackups())
                DeleteOldestBackup();
        }

        public void MoveBackupDir(string newBackupDir)
        {
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
