using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using Newtonsoft.Json.Linq;
using Octokit;
using Semver;
namespace BTD_Mod_Helper.Api;

internal partial class ModHelperData
{
    private const string ModHelperDataCs = "ModHelperData.cs";
    private const string ModHelperDataJson = "ModHelperData.json";
    private const string ModHelperDataTxt = "ModHelperData.txt";
    private const string ModHelperModsJson = "ModHelperMods.json";

    private const string DescriptionBranchRegex = "Mod\\s+Browser\\s+Branch\\s*:\\s*\"([a-zA-Z0-9\\.\\-_\\/]+)\"";
    private const string DescriptionDataPathRegex = "Mod\\s*Helper\\s*Data\\s*:\\s*\"([a-zA-Z0-9\\.\\-_\\/ ]+)\"";

    // Browser Mod Info
    internal Repository Repository { get; private set; }
    internal bool RepoDataSuccess { get; private set; }
    internal string RepoVersion { get; private set; }
    internal Release LatestRelease { get; private set; }
    internal GitHubCommit LatestCommit { get; private set; }
    internal string Branch { get; private set; }
    internal string DataPath { get; private set; }
    internal List<string> Topics { get; private set; }

    internal bool UpdateAvailable =>
        Version != null &&
        !RestartRequired &&
        RepoDataSuccess &&
        RepoVersion != null &&
        IsUpdate(Version, RepoVersion, RepoOwner);

    internal bool OutOfDate => UpdateAvailable || OldDownloadUrl != null;

    internal string ReadmeUrl
    {
        get
        {
            if (RepoOwner == null || RepoName == null)
                return OldDownloadUrl ?? Mod?.Info.DownloadLink;
            if (SubPath == null || SubPath.EndsWith(".txt") || SubPath.EndsWith(".json"))
                return $"https://github.com/{RepoOwner}/{RepoName}#readme";

            return $"https://github.com/{RepoOwner}/{RepoName}/tree/{Branch}/{SubPath}#readme";
        }
    }

    internal string StarsUrl => $"https://www.github.com/{RepoOwner}/{RepoName}/stargazers";
    private float splittingStarsAmongst = 1;
    internal int Stars => (int) Math.Ceiling((Repository?.StargazersCount ?? 0) / splittingStarsAmongst);
    internal long UpdatedAtUtc
    {
        get
        {
            var updatedAt = (Repository.PushedAt ?? Repository.CreatedAt).ToUnixTimeSeconds();
            if (splittingStarsAmongst > 1)
            {
                var splitBetween = (long) Math.Ceiling(Math.Sqrt(splittingStarsAmongst));
                var since = DateTimeOffset.Now.ToUnixTimeSeconds();
                updatedAt -= since * splitBetween;
            }
            return updatedAt;
        }
    }

    internal string RequiredRepoDataError
    {
        get
        {
            if (!SemVersion.TryParse(Version, out _)) return $"'{Version}' is not a valid SemVer";
            if (string.IsNullOrEmpty(RepoName)) return "RepoName is null/empty";
            if (string.IsNullOrEmpty(RepoOwner)) return "RepoOwner is null/empty";
            if (SubPath != null && DllName == null && ZipName == null) return "SubPath used without DllName/ZipName";

            return null;
        }
    }

    public ModHelperData(Repository repository, string subPath = null)
    {
        Repository = repository;
        RepoOwner = repository.Owner.Login;
        RepoName = repository.Name;
        SubPath = subPath;
        Branch = Repository.DefaultBranch;
        if (GetRegexMatch<string>(Repository.Description ?? "", DescriptionBranchRegex) is string branch)
        {
            Branch = branch;
            if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Msg($"Successfully set branch for {repository.FullName} to {branch}");
            }
        }
        if (string.IsNullOrEmpty(SubPath) &&
            GetRegexMatch<string>(Repository.Description ?? "", DescriptionDataPathRegex) is string dataPath)
        {
            DataPath = dataPath;
            if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Msg($"Successfully looking for ModHelperData for {repository.FullName} at {dataPath}");
            }
        }
    }

    internal string GetContentURL(string name)
    {
        var path = WebUtility.UrlEncode(name);
        if (SubPath != null && !(SubPath.EndsWith(".json") || SubPath.EndsWith(".cs") || SubPath.EndsWith(".txt")))
        {
            path = $"{SubPath}/{path}";
        }

        return $"{ModHelperGithub.RawUserContent}/{RepoOwner}/{RepoName}/{Branch}/{path}";
    }

    public async Task LoadDataFromRepoAsync()
    {
        try
        {
            string data = null;

            if (RepoName == ModHelper.RepoName)
            {
                data = await ModHelperHttp.Client.GetStringAsync(GetContentURL("Shared/ModHelper.cs"));
            }
            else if (SubPath != null &&
                     (SubPath.EndsWith(".txt") || SubPath.EndsWith(".json") || SubPath.EndsWith(".cs")))
            {
                data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(SubPath));
            }
            else if (DataPath != null)
            {
                data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(DataPath));
            }

            try
            {
                data ??= await WhenFirstSucceededOrAllFailed(new[]
                {
                    ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataCs)),
                    ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataJson)),
                    ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataTxt))
                });
            }
            catch (Exception e)
            {
                if (RepoOwner == MelonMain.GitHubUsername)
                {
                    ModHelper.Warning(e);
                }
            }

            if (data == null)
            {
                if (RepoOwner == MelonMain.GitHubUsername)
                {
                    ModHelper.Warning(
                        $"Did not find any mod data for {Repository.FullName} {SubPath} branch {Branch} ");
                }

                return;
            }

            var json = data.TrimStart().StartsWith("{");

            if (json) ReadValuesFromJson(data, false);
            else ReadValuesFromString(data, false);


            if (RequiredRepoDataError == null)
            {
                RepoDataSuccess = true;
                RepoVersion = Version;

                if (RepoOwner == MelonMain.GitHubUsername)
                {
                    ModHelper.Log($"Successfully found mod {Repository.FullName} {SubPath} for browser");
                }

                if (ModInstalledLocally(out var modHelperData))
                {
                    modHelperData.Repository = Repository;
                    modHelperData.RepoVersion = Version;
                    modHelperData.Branch = Branch;
                    modHelperData.RepoDataSuccess = true;
                }

                if (!string.IsNullOrEmpty(ZipName) && string.IsNullOrEmpty(DllName) && !ManualDownload)
                {
                    ManualDownload = true;

                    if (RepoOwner == MelonMain.GitHubUsername)
                    {
                        ModHelper.Warning(
                            $"Overriding {Repository.FullName} {SubPath} to be ManualDownload because it doesn't specify the DllName alongside the ZipName");
                    }
                }

                Topics = Repository.Topics.ToList();
                if (!string.IsNullOrEmpty(ExtraTopics))
                {
                    Topics.AddRange(ExtraTopics.Split(','));
                }
            }
            else if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Warning(
                    $"{Repository.FullName} {SubPath} did not have all required ModHelperData: {RequiredRepoDataError}");
            }
        }
        catch (Exception e)
        {
            if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Warning($"Failed to get ModHelperData for {Repository.FullName}");
                ModHelper.Warning(e);
            }
        }
    }

    private static async Task<T> WhenFirstSucceededOrAllFailed<T>(IEnumerable<Task<T>> tasks)
    {
        var taskList = new List<Task<T>>(tasks);
        while (taskList.Count > 0)
        {
            var firstCompleted = await Task.WhenAny(taskList).ConfigureAwait(false);
            if (firstCompleted.Status == TaskStatus.RanToCompletion)
            {
                return firstCompleted.Result;
            }

            taskList.Remove(firstCompleted);
        }

        return default;
    }

    public async Task<Release> GetLatestRelease()
    {
        try
        {
            return LatestRelease = await ModHelperGithub.Client.Repository.Release.GetLatest(Repository.Id);
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to get latest release for {DisplayName}");
            ModHelper.Warning(e);
            return null;
        }
        finally
        {
            ModHelperGithub.UpdateRateLimit();
        }
    }

    public async Task<GitHubCommit> GetLatestCommit()
    {
        try
        {
            var path = DllName;
            if (!SubPath.EndsWith(".json") && !SubPath.EndsWith(".txt"))
            {
                path = $"{SubPath}/{path}";
            }

            return LatestCommit =
                (await ModHelperGithub.Client.Repository.Commit.GetAll(Repository.Id, new CommitRequest {Path = path}))
                [0];
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to get latest commit for {DisplayName}");
            ModHelper.Warning(e);
            return null;
        }
        finally
        {
            ModHelperGithub.UpdateRateLimit();
        }
    }

    public static bool IsUpdate(string currentVersion, string latestVersion, string repoOwner = null)
    {
        if (!SemVersion.TryParse(latestVersion, out var latestSemver) ||
            !SemVersion.TryParse(currentVersion, out var currentSemver))
        {
            return false;
        }

        return latestSemver > currentSemver;
    }


    public async Task<bool> LoadIconFromRepoAsync()
    {
        // Don't fetch an icon that we've already got
        // This does mean that icon changes won't be seen in the Mod Browser until you download the new version, but eh
        if (MelonMain.ReUseLocalIcons && ModInstalledLocally(out var local) && !local.HasNoIcon)
        {
            IconBytes = local.IconBytes;
            HasNoIcon = false;
            return true;
        }

        // TODO might make it so that unverified mods can't have icons
        if (HasNoIcon /*|| !ModHelperGithub.VerifiedModders.Contains(RepoOwner)*/)
        {
            return false;
        }

        var iconURL = GetContentURL(Icon ?? DefaultIcon);
        if (IconBytes == null)
        {
            try
            {
                IconBytes = await ModHelperHttp.Client.GetByteArrayAsync(iconURL);
            }
            catch (Exception e)
            {
                HasNoIcon = true;
                if (RepoOwner == MelonMain.GitHubUsername)
                {
                    ModHelper.Warning($"Failed to get icon for mod {Repository.FullName}. Checked at {iconURL}");
                    ModHelper.Warning(e);
                }
            }
        }

        return IconBytes != null && IconBytes.Length != 0;
    }

    public static async Task<IEnumerable<ModHelperData>> LoadFromMonoRepo(Repository monoRepo)
    {
        var modsJsonUrl =
            $"{ModHelperGithub.RawUserContent}/{monoRepo.Owner.Login}/{monoRepo.Name}/{monoRepo.DefaultBranch}/{ModHelperModsJson}";

        try
        {
            var modsJson = JArray.Parse(await ModHelperHttp.Client.GetStringAsync(modsJsonUrl));

            if (monoRepo.Owner.Login == MelonMain.GitHubUsername)
            {
                ModHelper.Msg($"Found monorepo {monoRepo.FullName}");
            }

            var modHelperDatas = modsJson
                .Where(token => token.Type == JTokenType.String)
                .Select(token => new ModHelperData(monoRepo, token.ToString()))
                .ToList();

            foreach (var modHelperData in modHelperDatas)
            {
                modHelperData.splittingStarsAmongst = modHelperDatas.Count;
            }

            return modHelperDatas;
        }
        catch (Exception e)
        {
            if (monoRepo.Owner.Login == MelonMain.GitHubUsername)
            {
                ModHelper.Warning($"Failed to load data for monorepo {monoRepo.FullName}.");
                ModHelper.Warning(e);
            }
        }

        return Enumerable.Empty<ModHelperData>();
    }

    internal string Identifier => $"{RepoOwner}/{RepoName}" + (string.IsNullOrEmpty(SubPath) ? "" : "/" + SubPath);

    public List<ModHelperData> FindDependencies(List<ModHelperData> ignored = null)
    {
        if (string.IsNullOrEmpty(Dependencies)) return new List<ModHelperData>();

        var list = new List<ModHelperData>();
        try
        {
            foreach (var dependency in Dependencies.Split(","))
            {
                try
                {
                    var data = ModHelperGithub.Mods.FirstOrDefault(data => data.Identifier == dependency);

                    if (data != null &&
                        !data.ModInstalledLocally(out _) &&
                        (ignored == null || !ignored.Contains(data)))
                    {
                        list.Add(data);
                        list.AddRange(data.FindDependencies(list));
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Problem with dependency list {dependency}");
                    ModHelper.Warning(e);
                }
            }

        }
        catch (Exception e)
        {
            ModHelper.Warning($"Problem with dependencies list {Dependencies}");
            ModHelper.Warning(e);
        }

        return list;
    }

}