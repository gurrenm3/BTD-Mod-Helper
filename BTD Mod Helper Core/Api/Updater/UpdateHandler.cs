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
        internal static void SaveModUpdateInfo(string dir)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsTD6Mod>())
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
                        var isUpdate = false;
                        if (updateInfo.GithubReleaseURL != "")
                        {
                            var updater = new UpdateChecker(updateInfo.GithubReleaseURL);
                            var releaseInfo = await updater.GetLatestReleaseAsync();
                            isUpdate = updater.IsUpdate(updateInfo.CurrentVersion, releaseInfo);
                        }
                        else if (updateInfo.MelonInfoCsURL != "")
                        {
                            var updater = new UpdateChecker(updateInfo.MelonInfoCsURL);
                            var version = await updater.GetMelonInfoAsync();
                            isUpdate = updater.IsUpdate(updateInfo.CurrentVersion, version);
                        }

                        if (isUpdate)
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


        internal static void AnnounceUpdates(BloonsTD6Mod thisMod, List<UpdateInfo> modsNeedingUpdates)
        {
            if (modsNeedingUpdates.Any())
            {
                lock (modsNeedingUpdates)
                {
                    foreach (var updateInfo in modsNeedingUpdates)
                    {
                        var message =
                            $"An update is available for the mod \"{updateInfo.Name}\". Would you like to be taken to the download page?";

                        if (updateInfo.Name == thisMod.Info.Name)
                        {
                            message +=
                                "\n\nNOTE: Some other mods may not work if you aren't using the latest version of this mod";
                        }

                        PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "An Update is Available!",
                            message, new Action(() => UpdateMod(updateInfo)), "YES", null,
                            "Not now", Popup.TransitionAnim.Update, instantClose: true);
                    }

                    modsNeedingUpdates.Clear();
                }
            }
        }


        private static void UpdateMod(UpdateInfo updateInfo)
        {
            //Just linking them for now
            Process.Start(updateInfo.LatestURL);
        }
    }
}