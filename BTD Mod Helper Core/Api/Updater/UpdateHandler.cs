using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using MelonLoader;
using Newtonsoft.Json;

namespace BTD_Mod_Helper.Api.Updater
{
    internal class UpdateHandler
    {
        public static bool updatedMods;
        
        internal static void SaveModUpdateInfo(string dir)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                try
                {
                    if (mod.LatestURL != "" && (mod.GithubReleaseURL != "" || mod.MelonInfoCsURL != ""))
                    {
                        var info = new UpdateInfo(mod);
                        var serializedInfo = JsonConvert.SerializeObject(info, Formatting.Indented);
                        File.WriteAllText($"{dir}\\{mod.Info.Name}.json", serializedInfo);
                    }
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Encountered exception trying to save {mod.Info.Name} update info:");
                    MelonLogger.Warning(e.ToString());
                }
            }
        }

        internal static IEnumerable<UpdateInfo> LoadAllUpdateInfo(string dir)
        {
            var allUpdateInfo = new List<UpdateInfo>();
            foreach (var file in Directory.EnumerateFiles(dir).Where(s => s.EndsWith(".json")))
            {
                try
                {
                    var serializedInfo = File.ReadAllText(file);
                    var info = JsonConvert.DeserializeObject<UpdateInfo>(serializedInfo);
                    allUpdateInfo.Add(info);
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Encountered exception trying to load {file} update info:");
                    MelonLogger.Warning(e.ToString());
                }
            }

            return allUpdateInfo;
        }

        internal static void CheckForUpdates(IEnumerable<UpdateInfo> allUpdateInfo,
            List<UpdateInfo> modsNeedingUpdates)
        {
            Parallel.ForEach(
                allUpdateInfo,
                async updateInfo =>
                {
                    try
                    {
                        var updater = new UpdaterHttp(updateInfo);

                        if (await updater.IsUpdate())
                        {
                            lock (modsNeedingUpdates)
                            {
                                modsNeedingUpdates.Add(updateInfo);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Warning($"Encountered exception trying to check {updateInfo.Name} for updates: ");
                        MelonLogger.Warning(e.ToString());
                    }
                }
            );
        }


        internal static void AnnounceUpdates(List<UpdateInfo> modsNeedingUpdates, string modDir)
        {
            if (modsNeedingUpdates.Any())
            {
                lock (modsNeedingUpdates)
                {
                    foreach (var updateInfo in modsNeedingUpdates)
                    {
                        Action actionNo = null;
                        var no = "Not now";
                        string message;
                        if (MelonHandler.Mods.Any(mod => mod.Info.Name == updateInfo.Name))
                        {
                            message = $"Your version \"{updateInfo.CurrentVersion}\" of \"{updateInfo.Name}\" is now out of date. " +
                                      "Would you like to download the new version? (requires restart)";
                        }
                        else
                        {
                            message = $"An updated version of {updateInfo.Name}, which you previously used, is now available. " +
                                      "Would you like to download the new version and enable it? (requires restart)";
                            no = "No, forget this mod";
                            actionNo = () => 
                                File.Delete($"{modDir}\\UpdateInfo\\{updateInfo.Name}.json");
                        }

#if BloonsTD6
                        PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "An Update is Available!",
                            message, new Action(async () => await UpdateMod(updateInfo)), "YES", actionNo,
                            no, Popup.TransitionAnim.Scale);
#endif
                    }

                    modsNeedingUpdates.Clear();
                }
            }
        }

        private static async Task UpdateMod(UpdateInfo updateInfo)
        {
            var updater = new UpdaterHttp(updateInfo);
            try
            {
                if (await updater.Download($"{Environment.CurrentDirectory}\\Mods"))
                {
                    MelonLogger.Msg($"Successfully downloaded new version of {updateInfo.Name}");
                    updatedMods = true;
                    return;
                }
            }
            catch (Exception e)
            {
                MelonLogger.Warning(e.ToString());
            }

            MelonLogger.Warning($"Failed to download mod {updateInfo.Name}");
        }
    }
}