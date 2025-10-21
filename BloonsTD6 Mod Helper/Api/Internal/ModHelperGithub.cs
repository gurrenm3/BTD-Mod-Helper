﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Newtonsoft.Json.Linq;
using Octokit;
using Semver;

namespace BTD_Mod_Helper.Api.Internal;

internal static class ModHelperGithub
{
    public static string RawUserContent =>
        MelonMain.ProxyGitHubContent ? MelonMain.ProxyGitHubContentURL : "https://raw.githubusercontent.com";

    internal const string RepoTopic = "btd6-mod";
    internal const string MonoRepoTopic = "btd6-mods";
    private const string ProductName = "btd-mod-helper";

    private static string ModdersURL =>
        $"{RawUserContent}/{ModHelper.RepoOwner}/{ModHelper.RepoName}/{ModHelper.Branch}/modders.json";

    private const string DllContentType = "application/x-msdownload";
    private const string DllContentType2 = "application/octet-stream";
    private const string DllContentType3 = "application/x-msdos-program";
    private const string ZipContentType = "application/zip";
    private const string ZipContentType2 = "application/x-zip-compressed";

    private const string GenericSorry =
        "Please try again at a later time. If issues stil persist for this mod and not others, contact the mod developer.";

    internal static readonly string[] AllContentTypes =
        [DllContentType, DllContentType2, DllContentType3, ZipContentType, ZipContentType2];

    public static readonly HashSet<string> VerifiedModders = [];
    public static readonly HashSet<string> BannedModders = [];
    public static readonly HashSet<string> VerifiedTopics = [];
    public static readonly HashSet<string> BannedMods = [];
    public static readonly HashSet<string> UnstableMelonLoaderVersions = [];

    private static MiscellaneousRateLimit rateLimit;
    private static readonly string DoYouWantToDownload =
        ModHelper.Localize(nameof(DoYouWantToDownload), "Do you want to download");
    private static readonly string AlsoDownloadDeps =
        ModHelper.Localize(nameof(AlsoDownloadDeps), "Also Download Dependencies?");
    private static readonly string AlsoDownloadDepsBody = ModHelper.Localize(nameof(AlsoDownloadDepsBody),
        "has dependencies that it may not function without. Would you like to download these as well?");
    private static readonly string DownloadDepsSuccess = ModHelper.Localize(nameof(DownloadDepsSuccess),
        "Successfully downloaded dependencies! Remember to restart to apply changes.");

    public static List<ModHelperData> Mods { get; private set; } = [];
    private static bool ForceVerifiedOnly { get; set; }

    public static GitHubClient Client { get; private set; }

    public static int RemainingSearches => rateLimit?.Resources?.Search?.Remaining ?? -1;

    public static bool VerifiedOnly => ForceVerifiedOnly || !MelonMain.ShowUnverifiedModBrowserContent;

    public static IEnumerable<ModHelperData> VisibleMods => Mods.Where(ModIsVisible);

    public static bool ModIsVisible(this ModHelperData data) => data.RepoName != ModHelper.RepoName &&
                                                                !BannedModders.Contains(data.RepoOwner) &&
                                                                !BannedMods.Contains(data.Identifier) &&
                                                                (!VerifiedOnly ||
                                                                 VerifiedModders.Contains(data.RepoOwner)) &&
                                                                (!MelonMain.HideBrokenMods || !data.ModIsBroken());

    public static bool ModIsBroken(this ModHelperData data) =>
        !SemVersion.TryParse(data.WorksOnVersion, out var semver) || semver.Major < 34;

    internal static Task populatingMods;

    public static bool FullyPopulated { get; private set; }

    public static void Init()
    {
        Client = new GitHubClient(new ProductHeaderValue(ProductName));
    }

    public static async Task PopulateMods(bool localOnly)
    {
        Mods.Clear();
        try
        {
            var page = 1;
            var start = DateTime.Now;

            // Finish getting all normal mods, processing multiple pages if needed
            var mods = new List<ModHelperData>();

            if (localOnly)
            {
                mods.AddRange(ModHelperData.All
                    .Where(data => !string.IsNullOrEmpty(data.RepoOwner) && !string.IsNullOrEmpty(data.RepoName))
                    .Select(data => new ModHelperData(data)));
            }
            else
            {
                // Start initial GitHub searches
                var repoSearchTask = Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{RepoTopic}")
                    {PerPage = 100, Page = page++});
                var monoRepoSearchTask = Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{MonoRepoTopic}"));
                var modHelperRepoSearchTask = Client.Repository.Get(ModHelper.RepoOwner, ModHelper.RepoName);

                // First, wait for the monorepo search and then kick off the loading tasks
                var monoRepoTasks = (await monoRepoSearchTask).Items
                    .Select(ModHelperData.LoadFromMonoRepo)
                    .ToArray();

                var searchResult = await repoSearchTask;
                while (searchResult.TotalCount > mods.Count && searchResult.Items.Any())
                {
                    mods.AddRange(searchResult.Items
                        .OrderBy(repo => repo.CreatedAt)
                        .Select(repo => new ModHelperData(repo))
                        .Append(new ModHelperData(await modHelperRepoSearchTask)));

                    searchResult = await Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{RepoTopic}")
                        {PerPage = 100, Page = page++});
                }

                // Finish getting monorepo mods
                mods.AddRange((await Task.WhenAll(monoRepoTasks)).SelectMany(d => d));
            }

            // Load all the ModHelperData for the retrieved mods
            Task.WhenAll(mods.Select(data => data.LoadDataFromRepoAsync().ContinueWith(data.FinalizeRepoData))).Wait();
            Mods = mods.Where(mod => mod.RepoDataSuccess && mod.Mod is not MelonMain).ToList();

            var time = DateTime.Now - start;
            ModHelper.Msg(
                $"Finished getting mods from github in background, found {Mods.Count} mods over {time.TotalSeconds:F1} seconds");

            FullyPopulated = !localOnly;

            UpdateRateLimit();
        }
        catch (Exception e)
        {
            ModHelper.Warning("Error while populating mods");
            ModHelper.Warning(e);
        }
    }

    public static async Task GetVerifiedModders()
    {
        try
        {
            var result = await ModHelperHttp.Client.GetStringAsync(ModdersURL);
            var jobject = JObject.Parse(result);
            ForceVerifiedOnly = jobject.GetValue("forceVerifiedOnly")!.ToObject<bool>();
            foreach (var jToken in jobject.GetValue("verified")!)
            {
                VerifiedModders.Add(jToken.ToObject<string>());
            }

            foreach (var jToken in jobject.GetValue("banned")!)
            {
                BannedModders.Add(jToken.ToObject<string>());
            }

            foreach (var jToken in jobject.GetValue("bannedMods")!)
            {
                BannedMods.Add(jToken.ToObject<string>());
            }

            if (jobject.ContainsKey("topics"))
            {
                foreach (var jToken in jobject.GetValue("topics")!)
                {
                    VerifiedTopics.Add(jToken.ToObject<string>());
                }
            }

            if (jobject.ContainsKey("unstableMelonLoaderVersions"))
            {
                foreach (var jToken in jobject.GetValue("unstableMelonLoaderVersions")!)
                {
                    UnstableMelonLoaderVersions.Add(jToken.ToObject<string>());
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning("Failed to get modders data");
            ModHelper.Warning(e);
        }
    }

    public static async Task<string> DownloadLatest(ModHelperData mod, bool bypassPopup = false,
        Action<string> filePathCallback = null, Action<Task> taskCallback = null)
    {
        Release latestRelease = null;
        GitHubCommit latestCommit = null;
        if (mod.SubPath != null)
        {
            latestCommit = mod.LatestCommit ?? await mod.GetLatestCommit();
            if (latestCommit == null)
            {
                const string errorMessage = $"Failed to get latest commit from the GitHub API. {GenericSorry}";
                ModHelper.Error(errorMessage);
                if (!bypassPopup)
                {
                    PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
                }

                return null;
            }
        }
        else
        {
            latestRelease = mod.LatestRelease ?? await mod.GetLatestRelease();
            if (latestRelease == null)
            {
                const string errorMessage = $"Failed to get latest release from the GitHub API. {GenericSorry}";
                ModHelper.Error(errorMessage);
                if (!bypassPopup)
                {
                    PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
                }

                return null;
            }

            if (latestRelease.TagName != mod.RepoVersion)
            {
                ModHelper.Warning(
                    $"Latest Release Tag '{latestRelease.TagName}' didn't exactly match listed mod version '{mod.RepoVersion}'. " +
                    "The real release for this version may not be present in the API yet.");
            }
        }

        var dependencies = mod.FindDependencies();

        if (bypassPopup)
        {
            var downloadTask = Download(mod, filePathCallback, latestRelease, false);
            taskCallback?.Invoke(downloadTask);
            var resultFile = await downloadTask;

            foreach (var modHelperData in dependencies)
            {
                ModHelper.Msg($"Also downloading dependency {modHelperData.DisplayName}");
                await DownloadLatest(modHelperData, true);
            }

            return resultFile;
        }

        PopupScreen.instance.SafelyQueue(screen =>
        {
            screen.ShowPopup(PopupScreen.Placement.menuCenter,
                $"{DoYouWantToDownload.Localize()}\n{mod.DisplayName} v{latestRelease?.TagName ?? mod.RepoVersion}?",
                ParseReleaseMessage(mod.SubPath == null
                    ? latestRelease!.Body
                    : latestCommit!.Commit.Message),
                new Action(async () =>
                {
                    var downloadTask = Download(mod, filePathCallback, latestRelease, !dependencies.Any());
                    taskCallback?.Invoke(downloadTask);
                    var resultFile = await downloadTask;

                    try
                    {
                        if (!string.IsNullOrEmpty(resultFile))
                        {
                            if (resultFile.EndsWith(".dll"))
                            {
                                mod.DllName = Path.GetFileName(resultFile);
                            }
                            mod.SaveToJson(ModHelper.DataDirectory);
                        }
                    }
                    catch (Exception e)
                    {
                        ModHelper.Warning(e);
                    }

                    if (dependencies.Any())
                    {
                        PopupScreen.instance.SafelyQueue(screen =>
                        {
                            screen.ShowPopup(
                                PopupScreen.Placement.menuCenter, AlsoDownloadDeps.Localize(),
                                $"{mod.DisplayName} {AlsoDownloadDepsBody.Localize()}\n{dependencies.Select(data => data.DisplayName).Join()}. ",
                                new Action(async () =>
                                {
                                    foreach (var modHelperData in dependencies)
                                    {
                                        ModHelper.Msg($"Also downloading dependency {modHelperData.DisplayName}");
                                        downloadTask = DownloadLatest(modHelperData, true);
                                        taskCallback?.Invoke(downloadTask);
                                        await downloadTask;
                                    }
                                    PopupScreen.instance.SafelyQueue(popupScreen =>
                                        popupScreen.ShowOkPopup(DownloadDepsSuccess.Localize()));
                                }), "Yes", null, "No", Popup.TransitionAnim.Scale, instantClose: true);
                        });
                    }
                }), "Yes", null, "No", Popup.TransitionAnim.Scale, instantClose: true);
            screen.MakeTextScrollable();
        });

        return null;
    }

    private static string ParseReleaseMessage(string body) =>
        Regex.Split(body ?? "", @"<!--Mod Browser Message Start-->[\r\n\s]*").LastOrDefault() ?? "";

    private static async Task<string> Download(ModHelperData mod, Action<string> callback, Release latestRelease,
        bool showPopup)
    {
        Exception exception = null;
        try
        {
            var asset = mod.SubPath == null
                ? latestRelease!.Assets.FirstOrDefault(asset =>
                      asset.Name == mod.DllName || asset.Name == mod.ZipName || asset.Name == mod.Mod?.FileName()
                  ) ??
                  latestRelease.Assets[0]
                : new ReleaseAsset("", 0, "", mod.Name, "", "", DllContentType, 0, 0, DateTimeOffset.Now,
                    DateTimeOffset.Now, mod.GetContentURL(mod.ZipName ?? mod.DllName), null);
            var resultFile = await DownloadAsset(mod, asset, showPopup);
            if (resultFile != null)
            {
                if (callback != null && !string.IsNullOrWhiteSpace(resultFile))
                {
                    callback(resultFile);
                }

                return resultFile;
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            exception = e;
        }
        exception ??= ModHelperHttp.LastException;

        var errorMessage = "Failed to download asset. ";
        errorMessage += exception switch
        {
            HttpRequestException httpRequestException when httpRequestException.Message.Contains("maximum buffer") =>
                $"Size exceeded the current limit of {(int) MelonMain.ModRequestLimitMb} MB. " +
                "This limit can be increased in the Mod Helper's settings menu under the Mod Browser section.",
            _ => GenericSorry
        };
        ModHelper.Error(errorMessage);
        PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
        return null;
    }

    public static async Task<string> DownloadAsset(ModHelperData mod, ReleaseAsset releaseAsset, bool showPopup = true)
    {
        if (mod.ManualDownload)
        {
            ProcessHelper.OpenURL(releaseAsset.BrowserDownloadUrl);
            return "";
        }

        var name = mod.DllName ?? releaseAsset.Name;
        if (mod.Mod != null && name == null)
        {
            name = $"{mod.Mod.GetAssembly().GetName().Name}.dll";
        }

        var disabled = mod.ModInstalledLocally(out _) && !mod.Enabled;
        var downloadFilePath = Path.Combine(disabled ? ModHelper.DisabledModsDirectory : mod.EnabledFolder, name);
        var oldModsFilePath = Path.Combine(ModHelper.OldModsDirectory, name);

        try
        {
            if (File.Exists(downloadFilePath))
            {
                Directory.CreateDirectory(ModHelper.OldModsDirectory);
                if (File.Exists(oldModsFilePath)) File.Delete(oldModsFilePath);
                File.Move(downloadFilePath, oldModsFilePath);
                ModHelper.Msg($"Backing up to {oldModsFilePath}");
            }

            if (mod.FilePath != null && File.Exists(mod.FilePath))
            {
                Directory.CreateDirectory(ModHelper.OldModsDirectory);
                if (File.Exists(oldModsFilePath)) File.Delete(oldModsFilePath);
                File.Move(mod.FilePath, oldModsFilePath);
                ModHelper.Msg($"Backing up to {oldModsFilePath}");
            }

            var success = false;
            switch (releaseAsset.ContentType)
            {
                default:
                    ModHelper.Error($"Won't download release asset with content type {releaseAsset.ContentType}");
                    return null;
                case DllContentType:
                case DllContentType2:
                case DllContentType3:
                    success = await ModHelperHttp.DownloadFile(releaseAsset.BrowserDownloadUrl, downloadFilePath);
                    break;
                case ZipContentType:
                case ZipContentType2:
                    var directoryInfo = await ModHelperHttp.DownloadZip(releaseAsset.BrowserDownloadUrl);
                    if (directoryInfo != null)
                    {
                        var file = Array.Find(directoryInfo.GetFiles(), info => info.Name.EndsWith(mod.DllName!));
                        if (file == null)
                        {
                            ModHelper.Warning($"Couldn't find file in Zip that matched DllName {mod.DllName}");
                            file = Array.Find(directoryInfo.GetFiles(), s => s.Extension == "dll");
                            if (file != null)
                            {
                                ModHelper.Warning($"Using the first .dll found instead, {file.Name}");
                            }
                        }

                        var folderPath = Path.GetDirectoryName(downloadFilePath);
                        if (file != null && folderPath != null)
                        {
                            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                            File.Copy(file.FullName, downloadFilePath);
                            success = true;
                        }
                    }

                    break;
            }

            if (success)
            {
                var message = $"Successfully downloaded {name}, remember to restart to apply the changes!";
                ModHelper.Log(message);
                if (showPopup)
                {
                    PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(message.Replace(",", "\n")));
                }

                mod.Version = mod.RepoVersion;
                return downloadFilePath;
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        if (File.Exists(oldModsFilePath))
        {
            File.Copy(oldModsFilePath, downloadFilePath, true);
            ModHelper.Msg($"Loading backup from {oldModsFilePath}");
        }

        return null;
    }


    public static void UpdateRateLimit()
    {
        Task.Run(async () =>
        {
            try
            {
                rateLimit = await Client.RateLimit.GetRateLimits();
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        });
    }

    public static void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
    {
        foreach (var dir in source.GetDirectories())
        {
            CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
        }
        foreach (var file in source.GetFiles())
        {
            file.CopyTo(Path.Combine(target.FullName, file.Name), true);
        }
    }
}