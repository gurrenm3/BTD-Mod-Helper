using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;
using Newtonsoft.Json.Linq;
using Octokit;
using Semver;
using UnityEngine;

namespace BTD_Mod_Helper.Api;

internal static class ModHelperGithub
{
    public const string RawUserContent = "https://raw.githubusercontent.com";

    internal const string RepoTopic = "btd6-mod";
    internal const string MonoRepoTopic = "btd6-mods";
    private const string ProductName = "btd-mod-helper";

    private const string ModdersURL =
        $"https://raw.githubusercontent.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/{ModHelper.Branch}/modders.json";

    private const string DllContentType = "application/x-msdownload";
    private const string DllContentType2 = "application/octet-stream";
    private const string DllContentType3 = "application/x-msdos-program";
    private const string ZipContentType = "application/zip";
    private const string ZipContentType2 = "application/x-zip-compressed";

    private const string Sorry =
        "Please try again at a later time. If issues stil persist for this mod and not others, contact the mod developer.";

    public static List<ModHelperData> Mods { get; private set; } = new();

    public static readonly HashSet<string> VerifiedModders = new();
    public static readonly HashSet<string> BannedModders = new();
    public static readonly HashSet<string> VerifiedTopics = new();
    private static bool ForceVerifiedOnly { get; set; }

    public static GitHubClient Client { get; private set; }

    private static MiscellaneousRateLimit rateLimit;

    public static int RemainingSearches => rateLimit?.Resources?.Search?.Remaining ?? -1;

    public static bool VerifiedOnly => ForceVerifiedOnly || !MelonMain.ShowUnverifiedModBrowserContent;

    public static IEnumerable<ModHelperData> VisibleMods => Mods.Where(ModIsVisible);

    public static bool ModIsVisible(this ModHelperData data) =>
        data.RepoName != ModHelper.RepoName &&
        !BannedModders.Contains(data.RepoOwner) &&
        (!VerifiedOnly || VerifiedModders.Contains(data.RepoOwner)) &&
        (!MelonMain.HideBrokenMods || !data.ModIsBroken());

    public static bool ModIsBroken(this ModHelperData data) =>
        !SemVersion.TryParse(data.WorksOnVersion, out var semver) || semver.Major < 34;

    public static void Init()
    {
        Client = new GitHubClient(new ProductHeaderValue(ProductName));
    }

    public static async Task PopulateMods()
    {
        var start = DateTime.Now;
        var repoSearchTask = Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{RepoTopic}"));
        var monoRepoSearchTask = Client.Search.SearchRepo(new SearchRepositoriesRequest($"topic:{MonoRepoTopic}"));
        var modHelperRepoSearchTask = Client.Repository.Get(ModHelper.RepoOwner, ModHelper.RepoName);

        var monoRepoTasks = (await monoRepoSearchTask).Items
            .Select(ModHelperData.LoadFromMonoRepo)
            .ToArray();

        var mods = (await repoSearchTask).Items
            .OrderBy(repo => repo.CreatedAt)
            .Select(repo => new ModHelperData(repo))
            .Concat((await Task.WhenAll(monoRepoTasks)).SelectMany(d => d))
            .Append(new ModHelperData(await modHelperRepoSearchTask))
            .ToArray();

        Task.WhenAll(mods.Select(data => data.LoadDataFromRepoAsync())).Wait();

        Mods = mods.Where(mod => mod.RepoDataSuccess && mod.Mod is not MelonMain).ToList();
        var time = DateTime.Now - start;

        ModHelper.Msg($"Finished getting mods from github, found {Mods.Count} mods in {time.TotalSeconds:F1} seconds");

        UpdateRateLimit();
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

            if (jobject.ContainsKey("topics"))
            {
                foreach (var jToken in jobject.GetValue("topics")!)
                {
                    VerifiedTopics.Add(jToken.ToObject<string>());
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning("Failed to get modders data");
            ModHelper.Warning(e);
        }
    }

    public static async Task DownloadLatest(ModHelperData mod, bool bypassPopup = false,
        Action<string> filePathCallback = null, Action<Task> taskCallback = null)
    {
        Release latestRelease = null;
        GitHubCommit latestCommit = null;
        if (mod.SubPath != null)
        {
            latestCommit = mod.LatestCommit ?? await mod.GetLatestCommit();
            if (latestCommit == null)
            {
                const string errorMessage = $"Failed to get latest commit from the GitHub API. {Sorry}";
                ModHelper.Error(errorMessage);
                if (!bypassPopup)
                {
                    PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
                }

                return;
            }
        }
        else
        {
            latestRelease = mod.LatestRelease ?? await mod.GetLatestRelease();
            if (latestRelease == null)
            {
                const string errorMessage = $"Failed to get latest release from the GitHub API. {Sorry}";
                ModHelper.Error(errorMessage);
                if (!bypassPopup)
                {
                    PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
                }

                return;
            }

            if (latestRelease.TagName != mod.RepoVersion)
            {
                ModHelper.Warning(
                    $"Latest Release Tag '{latestRelease.TagName}' didn't exactly match listed mod version '{mod.RepoVersion}'. " +
                    "The real release for this version may not be present in the API yet.");
            }
        }


        if (bypassPopup)
        {
            var downloadTask = Download(mod, filePathCallback, latestRelease, false);
            taskCallback?.Invoke(downloadTask);
            await downloadTask;
        }
        else
        {
            PopupScreen.instance.SafelyQueue(screen =>
            {
                screen.ShowPopup(PopupScreen.Placement.menuCenter,
                    $"Do you want to download\n{mod.DisplayName} v{latestRelease?.TagName ?? mod.RepoVersion}?",
                    ParseReleaseMessage(mod.SubPath == null
                        ? latestRelease!.Body
                        : latestCommit!.Commit.Message),
                    new Action(async () =>
                    {
                        var downloadTask = Download(mod, filePathCallback, latestRelease, true);
                        taskCallback?.Invoke(downloadTask);
                        await downloadTask;
                    }), "Yes", null, "No", Popup.TransitionAnim.Scale, instantClose: true);

                screen.ModifyBodyText(field =>
                {
                    var scrollPanel = field.gameObject.AddModHelperScrollPanel(new Info("ScrollPanel",
                        InfoPreset.FillParent), RectTransform.Axis.Vertical, VanillaSprites.WhiteSquareGradient);
                    scrollPanel.Background.color = new Color(0, 0, 0, 77 / 255f);

                    var newBody = field.gameObject.Duplicate(scrollPanel.ScrollContent.transform);
                    newBody.GetComponentInChildren<ModHelperScrollPanel>().gameObject.Destroy();

                    field.Destroy();
                });
            });
        }

        UpdateRateLimit();
    }

    private static string ParseReleaseMessage(string body) =>
        Regex.Split(body ?? "", @"<!--Mod Browser Message Start-->[\r\n\s]*").LastOrDefault() ?? "";

    private static async Task Download(ModHelperData mod, Action<string> callback, Release latestRelease,
        bool showPopup)
    {
        try
        {
            var asset = mod.SubPath == null
                ? latestRelease!.Assets.FirstOrDefault(asset =>
                      asset.Name == mod.DllName || asset.Name == mod.ZipName) ??
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

                return;
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        const string errorMessage = $"Failed to download asset. {Sorry}";
        ModHelper.Error(errorMessage);
        PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(errorMessage));
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

        var downloadFilePath = Path.Combine(MelonEnvironment.ModsDirectory, name);
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
                        var file = directoryInfo.GetFiles()
                            .FirstOrDefault(info => info.Name.EndsWith(mod.DllName!));
                        if (file == null)
                        {
                            ModHelper.Warning($"Couldn't find file in Zip that matched DllName {mod.DllName}");
                            file = directoryInfo.GetFiles().FirstOrDefault(s => s.Extension == "dll");
                            if (file != null)
                            {
                                ModHelper.Warning($"Using the first .dll found instead, {file.Name}");
                            }
                        }

                        if (file != null)
                        {
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

                mod.SetVersion(mod.RepoVersion!);
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