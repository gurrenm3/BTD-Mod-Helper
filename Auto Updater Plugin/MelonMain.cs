using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using MelonLoader;

namespace Auto_Updater_Plugin
{
    internal class MelonMain : MelonPlugin
    {
        private static readonly string ModsDir = $"{Environment.CurrentDirectory}\\Mods";
        private static readonly string NewModsDir = ModsDir + "\\BloonsTD6 Mod Helper\\New Mods";
        private static readonly string OldModsDir = ModsDir + "\\BloonsTD6 Mod Helper\\Old Mods";
        private static readonly string ZipDir = NewModsDir + "\\ZipContents";

        public override void OnPreInitialization()
        {
            if (!Directory.Exists(NewModsDir))
            {
                Directory.CreateDirectory(NewModsDir);
            }
            
            if (!Directory.Exists(OldModsDir))
            {
                Directory.CreateDirectory(OldModsDir);
            }
            
            foreach (var file in Directory.EnumerateFiles(NewModsDir).Where(s => s.EndsWith(".zip")))
            {
                Directory.CreateDirectory(ZipDir);
                ZipFile.ExtractToDirectory(file, ZipDir);
                foreach (var unzippedFile in Directory.EnumerateFiles(ZipDir))
                {
                    if (unzippedFile.EndsWith(".dll"))
                    {
                        var realName = unzippedFile.Substring(unzippedFile.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                        var newFile = $"{NewModsDir}\\{realName}";
                        if (File.Exists(newFile))
                        {
                            File.Delete(newFile);
                        }
                        File.Copy(unzippedFile, newFile);
                    }
                    File.Delete(unzippedFile);
                }
                Directory.Delete(ZipDir);
                File.Delete(file);
            }
            
            foreach (var file in Directory.EnumerateFiles(NewModsDir).Where(s => s.EndsWith(".dll")))
            {
                var realName = file.Substring(file.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                var newFile = $"{ModsDir}\\{realName}";
                if (File.Exists(newFile))
                {
                    var oldFile = $"{OldModsDir}\\{realName}";
                    if (File.Exists(oldFile))
                    {
                        File.Delete(oldFile);
                    }
                    File.Copy(newFile, oldFile);
                    File.Delete(newFile);
                }
                File.Copy(file, newFile);
                File.Delete(file);
                
                MelonLogger.Msg($"Transferred over {realName} to mods folder");
            }
        }
    }
}