using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using Newtonsoft.Json.Linq;
using Octokit;
using UnityEngine;

namespace BTD_Mod_Helper.Api;

internal static class ModHelperGithub
{
    public const string RawUserContent = "https://raw.githubusercontent.com";

    private const string RepoTopic = "btd6-mod";
    private const string MonoRepoTopic = "btd6-mods";
    private const string ProductName = "btd-mod-helper";

    private const string ModdersURL =
        "https://raw.githubusercontent.com/gurrenm3/BTD-Mod-Helper/3.0_Features/modders.json";

    private const string DllContentType = "application/x-msdownload";
    private const string ZipContentType = "application/zip";
    private const string ZipContentType2 = "application/x-zip-compressed";

    private const string Sorry =
        "Please try again at a later time, and if it still doesn't work, contact the mod developer.";

    public static List<ModHelperData> Mods { get; private set; } = new();

    public static readonly HashSet<string> VerifiedModders = new();
    public static readonly HashSet<string> BannedModders = new();
    public static bool ForceVerifiedOnly { get; private set; }

    public static GitHubClient Client { get; private set; }

    private static MiscellaneousRateLimit rateLimit;

    public static int RemainingSearches => rateLimit?.Resources?.Search?.Remaining ?? -1;

    private static bool VerifiedOnly => ForceVerifiedOnly || !MelonMain.ShowUnverifiedModBrowserContent;

    public static IEnumerable<ModHelperData> VisibleMods => Mods
        .Where(data => data.RepoName != ModHelper.RepoName &&
                       !BannedModders.Contains(data.RepoOwner) &&
                       (!VerifiedOnly || VerifiedModders.Contains(data.RepoOwner)));

    public static void Init()
    {
        Client = new GitHubClient(new ProductHeaderValue(ProductName));
    }

    public static async Task PopulateMods()
    {
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

        ModHelper.Msg("finished getting mods");

        Task.WhenAll(mods.Select(data => data.LoadDataFromRepoAsync())).Wait();

        Mods = mods.Where(mod => mod.RepoDataSuccess && mod.Mod is not MelonMain).ToList();

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
        }
        catch (Exception e)
        {
            ModHelper.Warning("Failed to get modders data");
            ModHelper.Warning(e);
        }
    }

    public static async Task DownloadLatest(ModHelperData mod, bool bypassPopup = false, Action<string> callback = null)
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
#if BloonsTD6
                PopupScreen.instance.ShowOkPopup(errorMessage);
#endif
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
#if BloonsTD6
                PopupScreen.instance.ShowOkPopup(errorMessage);
#endif
                return;
            }

            if (latestRelease.TagName != mod.RepoVersion)
            {
                ModHelper.Warning("Latest Release Tag didn't match listed mod version. " +
                                  "The real release for this version may be present in the API yet.");
            }
        }

        var action = new Action(() =>
        {
            Task.Run(async () =>
            {
                try
                {
                    var asset = mod.SubPath == null
                        ? latestRelease!.Assets.FirstOrDefault(asset =>
                              asset.Name == mod.DllName || asset.Name == mod.ZipName) ??
                          latestRelease.Assets[0]
                        : new ReleaseAsset("", 0, "", mod.Name, "", "", DllContentType, 0, 0, DateTimeOffset.Now,
                            DateTimeOffset.Now, mod.GetContentURL(mod.DllName!), null);
                    var resultFile = await DownloadAsset(mod, asset);
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
#if BloonsTD6
                PopupScreen.instance.ShowOkPopup(errorMessage);
#endif
            });
        });

        if (bypassPopup)
        {
            action.Invoke();
        }
        else
        {
#if BloonsTD6
            PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter,
                $"Do you want to download\n{mod.DisplayName} v{latestRelease?.TagName ?? mod.RepoVersion}?",
                mod.SubPath == null
                    ? $"Latest Release Message:\n\"{latestRelease!.Body}\""
                    : $"Latest Commit Message:\n\"{latestCommit!.Commit.Message}\"",
                action, "Yes", null, "No", Popup.TransitionAnim.Scale);

            PopupScreen.instance.ModifyBodyText(field =>
            {
                var scrollPanel = field.gameObject.AddModHelperScrollPanel(new Info("ScrollPanel",
                    InfoPreset.FillParent), RectTransform.Axis.Vertical, VanillaSprites.WhiteSquareGradient);
                scrollPanel.Background.color = new Color(0, 0, 0, 77 / 255f);

                var newBody = field.gameObject.Duplicate(scrollPanel.ScrollContent.transform);
                newBody.GetComponentInChildren<ModHelperScrollPanel>().gameObject.Destroy();

                field.Destroy();
            });
#elif BloonsAT
                throw new NotImplementedException(); // need to figure out how to do popups in BloonsAT
#endif
        }

        UpdateRateLimit();
    }

    public static async Task<string> DownloadAsset(ModHelperData mod, ReleaseAsset releaseAsset)
    {
        if (mod.ManualDownload)
        {
            ProcessHelper.OpenURL(releaseAsset.BrowserDownloadUrl);
            return "";
        }

        var name = mod.DllName ?? releaseAsset.Name;
        if (name == null || !name.EndsWith(".dll"))
        {
            name = $"{mod.Mod.MelonAssembly.Assembly.GetName().Name}.dll";
        }

        var downloadFilePath = Path.Combine(MelonHandler.ModsDirectory, name);
        var oldModsFilePath = Path.Combine(ModHelper.OldModsDirectory, name);

        try
        {
            if (mod.FilePath != null && File.Exists(mod.FilePath))
            {
                if (!Directory.Exists(ModHelper.OldModsDirectory))
                {
                    Directory.CreateDirectory(ModHelper.OldModsDirectory);
                }

                if (File.Exists(oldModsFilePath))
                {
                    File.Delete(oldModsFilePath);
                }

                File.Move(mod.FilePath, oldModsFilePath);
                ModHelper.Msg($"Backing up to {oldModsFilePath}");
            }

            var success = false;
            switch (releaseAsset.ContentType)
            {
                default:
                    throw new ArgumentException(
                        $"Won't download release asset with content type {releaseAsset.ContentType}");
                case DllContentType:
                    success = await ModHelperHttp.DownloadFile(releaseAsset.BrowserDownloadUrl, downloadFilePath);
                    break;
                case ZipContentType:
                case ZipContentType2:
                    var directoryInfo = await ModHelperHttp.DownloadZip(releaseAsset.BrowserDownloadUrl);
                    if (directoryInfo != null)
                    {
                        try
                        {
                            var dll = directoryInfo.GetFiles().First(s => s.Extension == "dll").FullName;
                            File.Copy(dll, downloadFilePath);
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
                var message = $"Successfully downloaded {name}\nRemember to restart to apply the changes!";
                ModHelper.Log(message);
#if BloonsTD6
                PopupScreen.instance.ShowOkPopup(message);
#endif
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
                rateLimit = await Client.Miscellaneous.GetRateLimits();
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        });
    }
}