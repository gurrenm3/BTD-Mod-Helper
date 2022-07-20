using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

    internal Repository Repository { get; private set; }
    internal bool RepoDataSuccess { get; private set; }
    internal string RepoVersion { get; private set; }
    internal Release LatestRelease { get; private set; }
    internal GitHubCommit LatestCommit { get; private set; }

    internal bool UpdateAvailable =>
        Version != null &&
        !RestartRequired &&
        RepoDataSuccess &&
        RepoVersion != null &&
        IsUpdate(Version, RepoVersion);

    internal string ReadmeUrl
    {
        get
        {
            if (RepoOwner == null || RepoName == null)
                return Mod?.Info.DownloadLink;
            if (SubPath == null || SubPath.EndsWith(".txt") || SubPath.EndsWith(".json"))
                return $"https://github.com/{RepoOwner}/{RepoName}#readme";

            return $"https://github.com/{RepoOwner}/{RepoName}/tree/{Repository.DefaultBranch}/{SubPath}#readme";
        }
    }

    internal string StarsUrl => $"https://www.github.com/{RepoOwner}/{RepoName}/stargazers";

    internal bool HasRequiredRepoData => SemVersion.TryParse(Version, out _) &&
                                       RepoName != null &&
                                       RepoOwner != null &&
                                       (SubPath == null || DllName != null);

    public ModHelperData(Repository repository, string subPath = null)
    {
        Repository = repository;
        RepoOwner = repository.Owner.Login;
        RepoName = repository.Name;
        SubPath = subPath;
    }

    internal string GetContentURL(string name)
    {
        var path = name;
        if (SubPath != null && !SubPath.EndsWith(".json") && SubPath.EndsWith(".txt"))
        {
            path = $"{SubPath}/{name}";
        }

        return $"{ModHelperGithub.RawUserContent}/{RepoOwner}/{RepoName}/{Branch}/{path}";
    }

    public async Task LoadDataFromRepoAsync()
    {
        try
        {
            string data = null;
            var json = false;

            if (RepoName == ModHelper.RepoName)
            {
                data = await ModHelperHttp.Client.GetStringAsync(GetContentURL("Shared/ModHelper.cs"));
            }

            if (SubPath != null && (SubPath.EndsWith(".txt") || SubPath.EndsWith(".json") || SubPath.EndsWith(".cs")))
            {
                data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(SubPath));
                json = SubPath.EndsWith(".json");
            }

            if (data == null)
            {
                try // getting ModHelperData.cs
                {
                    data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataCs));
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            if (data == null)
            {
                try // getting ModHelperData.json
                {
                    data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataJson));
                    json = true;
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            
            if (data == null)
            {
                try // getting ModHelperData.json
                {
                    data = await ModHelperHttp.Client.GetStringAsync(GetContentURL(ModHelperDataTxt));
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            if (data == null) return;

            if (json) ReadValuesFromJson(data, false);
            else ReadValuesFromString(data);


            if (HasRequiredRepoData)
            {
                RepoDataSuccess = true;
                RepoVersion = Version;

                if (ModInstalledLocally(out var modHelperData))
                {
                    modHelperData.Repository = Repository;
                    modHelperData.RepoVersion = Version;
                    modHelperData.RepoDataSuccess = true;
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to get ModHelperData for {Repository.Name}");
            ModHelper.Warning(e);
        }
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

            ;
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

    public static bool IsUpdate(string currentVersion, string latestVersion)
    {
        if (!SemVersion.TryParse(latestVersion, out var latestSemver)) return false;
        if (!SemVersion.TryParse(currentVersion, out var currentSemver)) return true;

        return latestSemver > currentSemver;
    }


    public async Task<bool> LoadIconFromRepoAsync()
    {
        // Don't fetch an icon that we've already got
        // This does mean that icon changes won't be seen in the Mod Browser until you download the new version, but that's ok
        if (ModInstalledLocally(out var local))
        {
            IconBytes = local.IconBytes;
            HasNoIcon = local.HasNoIcon;
            return !HasNoIcon;
        }

        // TODO might make it so that unverified mods can't have icons
        if (HasNoIcon /*|| !ModHelperGithub.VerifiedModders.Contains(RepoOwner)*/)
        {
            return false;
        }

        if (IconBytes == null)
        {
            try
            {
                IconBytes = await ModHelperHttp.Client.GetByteArrayAsync(GetContentURL(Icon ?? DefaultIcon));
            }
            catch (Exception)
            {
                HasNoIcon = true;
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

            ModHelper.Msg($"Found monorepo {monoRepo.FullName}");
            return modsJson
                .Where(token => token.Type == JTokenType.String)
                .Select(token => new ModHelperData(monoRepo, token.ToString()));
        }
        catch (HttpRequestException)
        {
            //ignored
        }
        catch (TimeoutException)
        {
            //ignored
        }

        return Enumerable.Empty<ModHelperData>();
    }
}