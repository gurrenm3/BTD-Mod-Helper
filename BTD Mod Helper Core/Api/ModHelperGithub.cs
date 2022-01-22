using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Menus;
using MelonLoader;
using Octokit;

namespace BTD_Mod_Helper.Api
{
    internal static class ModHelperGithub
    {
        public const string Topic = "btd6-mod";

        public const string RawUserContent = "https://raw.githubusercontent.com";
        public const string ProductName = "btd-mod-helper";

        private const string DllContentType = "application/x-msdownload";
        private const string ZipContentType = "application/zip";
        private const string ZipContentType2 = "application/x-zip-compressed";

        private const string Sorry =
            "Please try again at a later time, and if it still doesn't work, contact the mod developer.";

        public static List<ModHelperData> Mods { get; private set; } = new List<ModHelperData>();

        public static GitHubClient Client { get; private set; }

        private static MiscellaneousRateLimit rateLimit;

        public static int RemainingSearches => rateLimit?.Resources?.Search?.Remaining ?? -1;

        public static void Init()
        {
            Client = new GitHubClient(new ProductHeaderValue(ProductName));
        }

        public static async Task PopulateMods()
        {
            var searchRepositoryResult =
                await Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{Topic}"));


            var mods = searchRepositoryResult.Items
                .OrderBy(repo => repo.CreatedAt)
                .Select(repo => new ModHelperData(repo))
                .ToArray();

            ModHelper.Msg("finished getting mods");

            Task.WhenAll(mods.Select(data => data.LoadDataFromRepoAsync())).Wait();

            Mods = mods.Where(mod => mod.RepoDataSuccess).ToList();

            ModHelper.Msg("finished getting mod helper data");

            foreach (var modHelperData in Mods)
            {
                ModHelper.Msg($"Found mod {modHelperData.Name} v{modHelperData.Version} with description: \"{modHelperData.Description}\"");
            }

            UpdateRateLimit();
        }

        public static async Task DownloadLatest(ModHelperData mod, bool bypassPopup = false)
        {
            var latestRelease = mod.LatestRelease ?? await mod.GetLatestRelease();
            if (latestRelease == null)
            {
                PopupScreen.instance.ShowOkPopup($"Failed to get latest release from the GitHub API. {Sorry}");
                return;
            }

            // ReSharper disable once AsyncVoidLambda
            var action = new Action(async () =>
            {
                try
                {
                    var success = await DownloadRelease(mod, latestRelease);
                    if (success)
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning(e);
                }

                PopupScreen.instance.ShowOkPopup($"Failed to download asset. {Sorry}");
            });

            if (bypassPopup)
            {
                await Task.Run(action);
            }
            else
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter,
                    $"Do you want to download\n{mod.Name} {mod.RepoVersion}?",
                    "Release Message:\n\"" + latestRelease.Body + "\"",
                    action, "Yes", null, "No", Popup.TransitionAnim.Scale);
            }

            UpdateRateLimit();
        }

        public static async Task<bool> DownloadRelease(ModHelperData mod, Release release)
        {
            try
            {
                var releaseAsset = release.Assets.FirstOrDefault(asset => asset.Name == mod.DllName) ??
                                   release.Assets.First();

                if (mod.ManualDownload)
                {
                    Process.Start(releaseAsset.BrowserDownloadUrl);
                    return true;
                }

                return await DownloadAsset(mod, releaseAsset);
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
                return false;
            }
        }

        public static async Task<bool> DownloadAsset(ModHelperData mod, ReleaseAsset releaseAsset)
        {
            var name = mod.DllName ?? releaseAsset.Name;
            if (name == null || !name.EndsWith(".dll"))
            {
                name = $"{mod.Mod.Assembly.GetName().Name}.dll";
            }
            var filePath = Path.Combine(MelonHandler.ModsDirectory, name);
            var oldModsFilePath = Path.Combine(ModHelper.OldModsDirectory, name);

            try
            {
                if (File.Exists(filePath))
                {
                    if (!Directory.Exists(ModHelper.OldModsDirectory))
                    {
                        Directory.CreateDirectory(ModHelper.OldModsDirectory);
                    }

                    File.Copy(filePath, oldModsFilePath, true);
                    ModHelper.Msg($"Backing up to {oldModsFilePath}");
                }

                var success = false;
                switch (releaseAsset.ContentType)
                {
                    default:
                        throw new ArgumentException(
                            $"Won't download release asset with content type {releaseAsset.ContentType}");
                    case DllContentType:
                        success = await ModHelperHttp.DownloadFile(releaseAsset.BrowserDownloadUrl, filePath);
                        break;
                    case ZipContentType:
                    case ZipContentType2:
                        var zippedFiles = await ModHelperHttp.DownloadZip(releaseAsset.BrowserDownloadUrl);
                        if (zippedFiles != null)
                        {
                            try
                            {
                                var dll = zippedFiles.First(s => s.EndsWith(name));
                                File.Copy(dll, filePath, true);
                                success = true;
                            }
                            catch (InvalidOperationException)
                            {
                                ModHelper.Warning(
                                    $"Zip archive did not contain {name}. " +
                                    "The mod developer may have made a typo, " +
                                    "or needs to use the DllName property in their ModHelperData.");
                            }
                        }

                        break;
                }

                if (success)
                {
                    PopupScreen.instance.ShowOkPopup($"Successfully downloaded {name}");
                    mod.RestartRequired = true;
                    ModsMenu.Refresh();

                    return true;
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }

            if (File.Exists(oldModsFilePath))
            {
                File.Copy(oldModsFilePath, filePath, true);
                ModHelper.Msg($"Loading backup from {oldModsFilePath}");
            }

            return false;
        }


        public static void UpdateRateLimit()
        {
            Task.Run(async () =>
            {
                try
                {
                    rateLimit = await Client.Miscellaneous.GetRateLimits();
                }
                catch (Exception e)
                {
                    ModHelper.Warning(e);
                }
            });
        }
    }
}