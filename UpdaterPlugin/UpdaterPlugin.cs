using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Semver;
using UnityEngine;
using UpdaterPlugin;
using Ping = System.Net.NetworkInformation.Ping;

[assembly: MelonInfo(typeof(UpdaterPlugin.UpdaterPlugin), ModHelperData.Name, ModHelperData.Version, ModHelperData.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]
[assembly: MelonPriority(-1000)]

namespace UpdaterPlugin;

public class UpdaterPlugin : MelonPlugin
{
    private static SemVersion currentModHelperVersion;
    private static SemVersion latestModHelperVersion;
    private static SemVersion latestModHelperWorksOnVersion;

    private static readonly HttpClient Client = new();

    public override void OnApplicationEarlyStart()
    {
        var start = DateTimeOffset.Now;
        try
        {
            var task = TaskHelpers.WhenAllFailFast([
                CheckPing,
                GetCurrentModHelperVersion,
                GetLatestModHelperVersion
            ]);

            task.Wait(2000);

            if (!task.Result) return;

            if (currentModHelperVersion >= latestModHelperVersion)
            {
                LoggerInstance.Msg("Mod Helper is up to date");
                return;
            }

            if (SemVersion.TryParse(Application.version, out var currentVersion) &&
                latestModHelperWorksOnVersion > currentVersion)
            {
                LoggerInstance.Msg("Not updating Mod Helper because installed BTD6 version isn't high enough");
                return;
            }

            var download = DownloadLatestModHelper();

            download.Wait();

            if (download.IsCompletedSuccessfully)
            {
                LoggerInstance.Msg($"Successfully downloaded Mod Helper {latestModHelperVersion}");
            }
        }
        finally
        {
            var end = DateTimeOffset.Now;

#if DEBUG
            LoggerInstance.Msg($"UpdaterPlugin took {end - start}");
#endif
        }
    }

    private static async Task CheckPing(CancellationToken ct)
    {
        using var ping = new Ping();
        try
        {
            var reply = await ping.SendPingAsync("8.8.8.8", 1000);

            if (reply.Status == IPStatus.Success) return;
        }
        catch (Exception)
        {
            // ignored
        }

        throw new WebException("Not connected to internet");
    }

    private static async Task GetCurrentModHelperVersion(CancellationToken ct)
    {
        var path = Path.Combine(ModHelper.DataDirectory, "Btd6ModHelper.json");

        if (!File.Exists(path))
        {
            currentModHelperVersion = new SemVersion(0, 0, 0);
            return;
        }

        var file = await File.ReadAllTextAsync(path, ct);

        using var stringReader = new StringReader(file);
        await using var reader = new JsonTextReader(stringReader);

        var json = await JObject.LoadAsync(reader, ct);

        if (!json.TryGetValue("Version", out var version))
        {
            throw new KeyNotFoundException("No version key in ModHelper json");
        }

        if (!SemVersion.TryParse(version.ToString(), out currentModHelperVersion))
        {
            throw new VersionNotFoundException("Installed Mod Helper Version was not a valid semantic version");
        }
    }

    private static async Task GetLatestModHelperVersion(CancellationToken ct)
    {
        var url = ModHelper.GetContentURL("BloonsTD6 Mod Helper/ModHelper.cs");
        var contents = await Client.GetStringAsync(url, ct);

        var version = ModHelperData.GetRegexMatch<string>(contents, ModHelperData.VersionRegex);

        if (version == null) throw new VersionNotFoundException("Could not get version from ModHelper.cs");

        if (!SemVersion.TryParse(version, out latestModHelperVersion))
        {
            throw new VersionNotFoundException("Latest Mod Helper Version was not a valid semantic version");
        }

        var worksOnVersion = ModHelperData.GetRegexMatch<string>(contents, ModHelperData.WorksOnVersionRegex);

        if (worksOnVersion == null) throw new VersionNotFoundException("Could not get worksOnVersion from ModHelper.cs");

        if (!SemVersion.TryParse(version, out latestModHelperWorksOnVersion))
        {
            throw new VersionNotFoundException("Latest Mod Helper WorksOnVersion was not a valid semantic version");
        }
    }

    private static async Task DownloadLatestModHelper()
    {
        var bytes = await Client.GetByteArrayAsync(ModHelper.DownloadUrl);

        await File.WriteAllBytesAsync(ModHelper.DllLocation, bytes);
    }

}