using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Extensions;
using MelonLoader.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ping = System.Net.NetworkInformation.Ping;

[assembly: MelonInfo(typeof(UpdaterPlugin.UpdaterPlugin), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]
[assembly: MelonPriority(-1000)]

namespace UpdaterPlugin;

public class UpdaterPlugin : MelonPlugin
{
    public override void OnPreModsLoaded()
    {
        var start = DateTimeOffset.Now;
        try
        {
            if (!CheckPing()) return;

            UpdateMods().Wait(15000);
        }
        finally
        {
            var end = DateTimeOffset.Now;

#if DEBUG
            LoggerInstance.Msg($"UpdaterPlugin took {end - start}");
#endif
        }
    }

    private static bool CheckPing(CancellationToken ct = default)
    {
        using var ping = new Ping();
        try
        {
            var reply = ping.Send("8.8.8.8", 1000);

            if (reply?.Status == IPStatus.Success) return true;
        }
        catch (Exception)
        {
            //ignored
        }

        return false;
    }

    private static async Task UpdateMods(CancellationToken ct = default)
    {
        if (!Directory.Exists(ModHelper.DataDirectory)) return;

        await Task.WhenAll(Directory.EnumerateFiles(ModHelper.DataDirectory, "*.json").Select(async path =>
        {
            try
            {
                var file = await File.ReadAllTextAsync(path, ct);

                using var stringReader = new StringReader(file);
                await using var reader = new JsonTextReader(stringReader);

                var json = await JObject.LoadAsync(reader, ct);

                var data = new ModHelperData();
                data.ReadValuesFromJson(json.ToString());

                if (data.Plugin || data.ManualDownload) return;

                var enabledDllPath = Path.Combine(MelonEnvironment.ModsDirectory, data.DllName);
                var disabledDllPath = Path.Combine(ModHelper.DisabledModsDirectory, data.DllName);

                if (!(data.RepoName == ModHelper.RepoName && data.RepoOwner == ModHelper.RepoOwner) &&
                    !File.Exists(enabledDllPath) &&
                    !File.Exists(disabledDllPath)) return;

                var repoData = new ModHelperData(data);
                var remoteData = await repoData.LoadDataFromRepoAsync(ct);

                if (string.IsNullOrEmpty(remoteData)) return;

                repoData.ReadValues(remoteData);

                if (!ModHelperData.IsUpdate(data.Version, repoData.Version, repoData.WorksOnVersion)) return;

                var url = $"https://github.com/{data.RepoOwner}/{data.RepoName}/releases/latest/download/{data.DllName}";

                var downloadUrl = repoData.DownloadUrl ?? data.DownloadUrl ?? url;
                var auth = repoData.Authorization ?? data.Authorization;

                ModHelper.Msg($"Downloading {data.RepoOwner}/{data.RepoName} {data.Version}");
                var bytes = await ModHelperHttp.Client.GetBytesWithAuthAsync(downloadUrl, auth, ct);

                var enabled = false;
                if (File.Exists(enabledDllPath))
                {
                    enabled = true;
                    if (File.Exists(disabledDllPath)) File.Delete(disabledDllPath);
                    File.Move(enabledDllPath, disabledDllPath);
                }

                try
                {
                    await File.WriteAllBytesAsync(enabled ? enabledDllPath : disabledDllPath, bytes, ct);
                    repoData.SaveToJson(ModHelper.DataDirectory);
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to download {data.RepoOwner}/{data.RepoName} {data.Version}");
                    ModHelper.Warning(e);
                    if (enabled)
                    {
                        File.Move(disabledDllPath, enabledDllPath);
                    }
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        }));
    }

}