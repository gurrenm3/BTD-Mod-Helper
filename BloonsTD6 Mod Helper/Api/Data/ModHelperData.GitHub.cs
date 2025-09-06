using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModMenu;
using Newtonsoft.Json.Linq;
using Octokit;
using Semver;
namespace BTD_Mod_Helper.Api.Data;

internal partial class ModHelperData
{
    private const string DescriptionBranchRegex = """Mod\s+Browser\s+Branch\s*:\s*"([a-zA-Z0-9\.\-_\/]+)""";
    private const string DescriptionDataPathRegex = """Mod\s*Helper\s*Data\s*:\s*"([a-zA-Z0-9\.\-_\/ ]+)""";
    internal const string UpdaterVersionRegex = """\bUpdaterVersion\s*=\s*"(""" + SemVerRegex + """)";?[\n\r]+""";

    private float splittingStarsAmongst = 1;

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

    // Browser Mod Info
    internal Repository Repository { get; private set; }
    internal bool RepoDataSuccess { get; private set; }
    internal string RepoVersion { get; private set; }
    internal Release LatestRelease { get; private set; }
    internal GitHubCommit LatestCommit { get; private set; }
    internal List<string> Topics { get; private set; }
    internal string RepoWorksOnVersion { get; private set; }

    internal bool UpdateAvailable =>
        Version != null &&
        !RestartRequired &&
        RepoDataSuccess &&
        RepoVersion != null &&
        IsUpdate(Version, RepoVersion, RepoWorksOnVersion);

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

    internal string Identifier => $"{RepoOwner}/{RepoName}" + (string.IsNullOrEmpty(SubPath) ? "" : "/" + SubPath);

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
                (await ModHelperGithub.Client.Repository.Commit.GetAll(Repository.Id,
                    new CommitRequest {Path = path}))
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

        return [];
    }

    public List<ModHelperData> FindDependencies(List<ModHelperData> ignored = null)
    {
        if (string.IsNullOrEmpty(Dependencies)) return [];

        var list = new List<ModHelperData>();
        try
        {
            foreach (var dependency in Dependencies.Split(","))
            {
                try
                {
                    var data = ModHelperGithub.Mods.Find(data => data.Identifier == dependency);

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

    public void FinalizeRepoData(Task<string> loadTask)
    {
        var data = loadTask.Result;
        if (!loadTask.IsCompletedSuccessfully || string.IsNullOrEmpty(data)) return;

        ReadValues(data, false);

        if (RequiredRepoDataError != null)
        {
            if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Warning(
                    $"{RepoOwner}/{RepoName} {SubPath} did not have all required ModHelperData: {RequiredRepoDataError}");
            }
            return;
        }

        RepoDataSuccess = true;
        RepoVersion = Version;
        RepoWorksOnVersion = WorksOnVersion;

        if (RepoOwner == MelonMain.GitHubUsername)
        {
            ModHelper.Log(
                $"Successfully found mod {RepoOwner}/{RepoName}{(string.IsNullOrEmpty(SubPath) ? "" : "/")}{SubPath} for browser");
        }

        if (ModInstalledLocally(out var modHelperData))
        {
            modHelperData.Repository = Repository;
            modHelperData.RepoVersion = Version;
            modHelperData.Branch = Branch;
            modHelperData.RepoDataSuccess = true;
            modHelperData.RepoWorksOnVersion = WorksOnVersion;
            modHelperData.ModHelperDataUrl = ModHelperDataUrl;
            modHelperData.CachedModHelperData = CachedModHelperData;
        }

        if (!string.IsNullOrEmpty(ZipName) && string.IsNullOrEmpty(DllName) && !ManualDownload)
        {
            ManualDownload = true;

            if (RepoOwner == MelonMain.GitHubUsername)
            {
                ModHelper.Warning(
                    $"Overriding {RepoOwner}/{RepoName} {SubPath} to be ManualDownload because it doesn't specify the DllName alongside the ZipName");
            }
        }

        if (Repository != null)
        {
            Topics = Repository.Topics.ToList();
        }

        if (!string.IsNullOrEmpty(ExtraTopics))
        {
            Topics.AddRange(ExtraTopics.Split(','));
        }
    }
}