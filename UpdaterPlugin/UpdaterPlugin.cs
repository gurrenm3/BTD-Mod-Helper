using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
[assembly: MelonPriority(-999)]

namespace UpdaterPlugin;

public class UpdaterPlugin : MelonPlugin
{
    // ReSharper disable once CollectionNeverQueried.Global
    public static readonly ConcurrentBag<string> UpdatedMods = [];

    public static readonly ConcurrentDictionary<string, bool> InProgress = new();

    internal static string SettingsFile =>
        Path.Combine(ModHelper.ModSettingsDirectory, ModHelper.DllName.Replace(".dll", ".json"));

    public override void OnPreModsLoaded()
    {
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
        var dontAutoUpdate = new HashSet<string>();

        // Check auto update settings
        if (File.Exists(SettingsFile))
        {
            try
            {
                var file = await File.ReadAllTextAsync(SettingsFile, ct);
                using var stringReader = new StringReader(file);
                await using var reader = new JsonTextReader(stringReader);
                var json = await JObject.LoadAsync(reader, ct);

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
            tasks.Add(UpdateMod(data, ct));
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

                    using var stringReader = new StringReader(file);
                    await using var reader = new JsonTextReader(stringReader);

                    var json = await JObject.LoadAsync(reader, ct);

                    var data = new ModHelperData();
                    data.ReadValuesFromJson(json.ToString());

                    var repoMod = !string.IsNullOrEmpty(data.RepoName) && !string.IsNullOrEmpty(data.RepoOwner);
                    var nonRepoMod = !string.IsNullOrEmpty(data.ModHelperDataUrl) && !string.IsNullOrEmpty(data.DownloadUrl);

                    if (data.Plugin || data.ManualDownload || !repoMod && !nonRepoMod) return;

                    await UpdateMod(data, ct);
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

    private static async Task UpdateMod(ModHelperData data, CancellationToken ct)
    {
        var enabledDllPath = Path.Combine(MelonEnvironment.ModsDirectory, data.DllName);
        var disabledDllPath = Path.Combine(ModHelper.DisabledModsDirectory, data.DllName);

        var isModHelper = data.RepoName == ModHelper.RepoName && data.RepoOwner == ModHelper.RepoOwner;

        if (!isModHelper && !File.Exists(enabledDllPath) && !File.Exists(disabledDllPath)) return;

        var remoteData = new ModHelperData(data);
        var remoteValues = await remoteData.LoadDataFromRepoAsync(ct);

        if (string.IsNullOrEmpty(remoteValues)) return;

        remoteData.ReadValues(remoteValues);

        if (!ModHelperData.IsUpdate(data.Version, remoteData.Version, remoteData.WorksOnVersion)) return;

        var url = string.IsNullOrEmpty(data.SubPath)
            ? $"https://github.com/{data.RepoOwner}/{data.RepoName}/releases/latest/download/{data.DllName}"
            : data.GetContentURL(data.DllName);

        var downloadUrl = remoteData.DownloadUrl ?? data.DownloadUrl ?? url;
        var auth = remoteData.Authorization ?? data.Authorization;

        var enabled = isModHelper;
        ModHelper.Msg($"Starting download of {data.Name} {remoteData.Version}");

        try
        {
            InProgress[data.Name] = true;
            var bytes = await ModHelperHttp.Client.GetBytesWithAuthAsync(downloadUrl, auth, ct);

            if (File.Exists(enabledDllPath))
            {
                enabled = true;
                if (File.Exists(disabledDllPath)) File.Delete(disabledDllPath);
                File.Move(enabledDllPath, disabledDllPath);
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
            if (enabled)
            {
                File.Move(disabledDllPath, enabledDllPath);
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