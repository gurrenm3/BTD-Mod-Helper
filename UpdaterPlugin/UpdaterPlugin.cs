using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Extensions;
using MelonLoader.Utils;
using Newtonsoft.Json.Linq;
using Ping = System.Net.NetworkInformation.Ping;

[assembly: MelonInfo(typeof(UpdaterPlugin.UpdaterPlugin), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]
[assembly: MelonPriority(-999)]

namespace UpdaterPlugin;

public class UpdaterPlugin : MelonPlugin
{
    // ReSharper disable once CollectionNeverQueried.Global
    public static readonly ConcurrentBag<string> UpdatedMods = [];

    public static readonly ConcurrentDictionary<string, bool> InProgress = new();

    internal static string ModHelperSettings =>
        Path.Combine(ModHelper.ModSettingsDirectory, "BloonsTD6 Mod Helper.json");

    internal static string UpdaterSettings =>
        Path.Combine(ModHelper.ModSettingsDirectory, ModHelper.DllName.Replace(".dll", ".json"));

    public override void OnPreInitialization()
    {
        try
        {
            if (File.Exists(ModHelperSettings))
            {
                var text = File.ReadAllText(ModHelperSettings);
                var settings = JObject.Parse(text);
                if (settings.TryGetValue("ProxyGitHubContent", out var b) &&
                    b.Value<bool>())
                {
                    ModHelperGithub.RawUserContent = settings.TryGetValue("ProxyGitHubContentURL", out var s) &&
                                                     s.Value<string>() is { } proxyGitHubContentURL
                        ? proxyGitHubContentURL
                        : "https://rawgithubusercontent.deno.dev";
                    ModHelper.Msg($"Using proxy {ModHelperGithub.RawUserContent}");
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to read mod helper settings from {ModHelperSettings}");
            ModHelper.Warning(e);
        }

        if (!CheckPing()) return;
        ModHelperHttp.Init();
        Message.CheckForMessages().Wait();
    }

    public override void OnPreModsLoaded()
    {
        VersionCompat.safeToGetVersionFromUnity = true;
        var start = DateTimeOffset.Now;
        try
        {
            if (!CheckPing()) return;

            UpdateMods().Wait();
        }
        finally
        {
            var end = DateTimeOffset.Now;
            ModHelper.Msg($"UpdaterPlugin took {end - start}");
        }
    }

    private static bool CheckPing(string host = null, CancellationToken ct = default)
    {
        host ??= "8.8.8.8";
        using var ping = new Ping();
        try
        {
            var reply = ping.Send(host, 1000);

            if (reply?.Status == IPStatus.Success) return true;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        ModHelper.Warning($"CheckPing failed for {host}, assuming there is no interest connection");

        return false;
    }

    private static async Task UpdateMods(CancellationToken ct = default)
    {
        var dontAutoUpdate = new HashSet<string>();

        // Check auto update settings
        if (File.Exists(UpdaterSettings))
        {
            try
            {
                var file = await File.ReadAllTextAsync(UpdaterSettings, ct);
                var json = await JObject.LoadAsync(file, ct);

                foreach (var (key, value) in json)
                {
                    if (value is {Type: JTokenType.Boolean} && !value.Value<bool>())
                    {
                        dontAutoUpdate.Add(key);
                    }
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        }

        var tasks = new List<Task>();

        // If it hasn't been installed, always update Mod Helper
        if (!File.Exists(Path.Join(ModHelper.DataDirectory, ModHelper.ModHelperDll.Replace(".dll", ".json"))))
        {
            var data = new ModHelperData();
            data.ReadValuesFromType(typeof(ModHelper));
            data.Version = "0.0.0"; // always update
            data.Name = ModHelper.ModHelperName;
            data.DllName = ModHelper.ModHelperDll;
            tasks.Add(UpdateMod(data, null, ct));
        }

        if (Directory.Exists(ModHelper.DataDirectory))
        {
            tasks.AddRange(Directory.EnumerateFiles(ModHelper.DataDirectory, "*.json").Select(async path =>
            {
                try
                {
                    var name = Path.GetFileNameWithoutExtension(path);

                    if (dontAutoUpdate.Contains(name)) return;

                    var file = await File.ReadAllTextAsync(path, ct);
                    var json = await JObject.LoadAsync(file, ct);

                    var data = new ModHelperData();
                    data.ReadValuesFromJson(json.ToString());

                    var repoMod = !string.IsNullOrEmpty(data.RepoName) && !string.IsNullOrEmpty(data.RepoOwner);
                    var nonRepoMod = !string.IsNullOrEmpty(data.ModHelperDataUrl) && !string.IsNullOrEmpty(data.DownloadUrl);

                    if (data.Plugin || data.ManualDownload || !repoMod && !nonRepoMod) return;

                    await UpdateMod(data, path, ct);
                }
                catch (Exception e)
                {
                    ModHelper.Warning(e);
                }
            }));
        }

        using var progress = CancellationTokenSource.CreateLinkedTokenSource(ct);
        try
        {
            _ = RunRepeatingAsync(TimeSpan.FromSeconds(2), () =>
            {
                if (InProgress.Any()) ModHelper.Msg($"Currently downloading: {InProgress.Keys.Join()}");
            }, progress.Token);

            await Task.WhenAll(tasks);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
        finally
        {
            progress.Cancel();
        }
    }

    private static async Task UpdateMod(ModHelperData data, string dataPath, CancellationToken ct)
    {
        var enabledDllPath = Path.Combine(MelonEnvironment.ModsDirectory, data.DllName);
        var disabledDllPath = Path.Combine(ModHelper.DisabledModsDirectory, data.DllName);
        var oldDllPath = Path.Combine(ModHelper.OldModsDirectory, data.DllName);
        var existingDllPath = File.Exists(enabledDllPath) ? enabledDllPath : disabledDllPath;

        var isModHelper = data.DllName == ModHelper.ModHelperDll;

        if (!isModHelper && !File.Exists(existingDllPath))
        {
            if (!string.IsNullOrEmpty(dataPath) && File.Exists(dataPath))
            {
                try
                {
                    File.Delete(dataPath);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return;
        }

        var remoteData = new ModHelperData(data);
        var remoteValues = await remoteData.LoadDataFromRepoAsync(ct);

        if (string.IsNullOrEmpty(remoteValues)) return;

        remoteData.ReadValues(remoteValues);

        if (!ModHelperData.IsUpdate(data.Version, remoteData.Version, remoteData.WorksOnVersion)) return;

        var repoDllName = !string.IsNullOrEmpty(remoteData.DllName) ? remoteData.DllName : data.DllName;
        var url = string.IsNullOrEmpty(data.SubPath)
            ? $"https://github.com/{data.RepoOwner}/{data.RepoName}/releases/latest/download/{repoDllName}"
            : data.GetContentURL(repoDllName);

        var downloadUrl = remoteData.DownloadUrl ?? data.DownloadUrl ?? url;
        var auth = remoteData.Authorization ?? data.Authorization;


        var enabled = isModHelper || File.Exists(enabledDllPath);
        ModHelper.Msg($"Starting download of {data.Name} {remoteData.Version}");

        try
        {
            InProgress[data.Name] = true;
            var bytes = await ModHelperHttp.Client.GetBytesWithAuthAsync(downloadUrl, auth, ct);

            if (File.Exists(existingDllPath))
            {
                if (File.Exists(oldDllPath)) File.Delete(oldDllPath);
                Directory.CreateDirectory(Path.GetDirectoryName(oldDllPath)!);
                File.Move(existingDllPath, oldDllPath);
            }

            await File.WriteAllBytesAsync(enabled ? enabledDllPath : disabledDllPath, bytes, ct);
            remoteData.SaveToJson(ModHelper.DataDirectory);
            UpdatedMods.Add(data.Name);
            ModHelper.Msg($"Successfully finished download of {data.Name} {remoteData.Version}");
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to download {data.Name} {remoteData.Version}");
            ModHelper.Warning(e);
            if (File.Exists(oldDllPath))
            {
                File.Move(oldDllPath, existingDllPath);
            }
        }
        finally
        {
            InProgress.Remove(data.Name, out _);
        }
    }

    private static async Task RunRepeatingAsync(
        TimeSpan interval,
        Action action,
        CancellationToken ct)
    {
        using var timer = new PeriodicTimer(interval);

        try
        {
            while (await timer.WaitForNextTickAsync(ct))
            {
                action();
            }
        }
        catch (OperationCanceledException)
        {
            // clean exit
        }
    }
}