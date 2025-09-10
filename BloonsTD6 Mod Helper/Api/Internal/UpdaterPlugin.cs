using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader.Utils;
using Semver;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Internal;

internal static class UpdaterPlugin
{
    private const string DllName = $"{nameof(UpdaterPlugin)}.dll";

    public static bool IsUpdaterPlugin(this ModHelperData data) =>
        data.Name == "Updater Plugin" && data.Author == "doombubbles";

    public static bool IsUpdaterPlugin(this MelonBase melon) =>
        melon.Info.Name == "Updater Plugin" && melon.Info.Author == "doombubbles";

    public static ModHelperData Updater => field ??= ModHelperData.All.FirstOrDefault(IsUpdaterPlugin);

    private static string DownloadUrl =>
        $"https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/releases/latest/download/{DllName}";

    private static string FilePath => Path.Combine(MelonEnvironment.PluginsDirectory, DllName);
    private static string FilePathDisabled => Path.Combine(ModHelper.DisabledModsDirectory, DllName);

    private static bool didDownloadAlready;

    private static string latestVersionString;

    public static bool HasLatestVersion =>
        Updater is { } currentPlugin &&
        SemVersion.TryParse(currentPlugin.Version, out var installedVersion) &&
        SemVersion.TryParse(latestVersionString ?? ModHelper.UpdaterVersion, out var latestVersion) &&
        installedVersion >= latestVersion;

    public static bool ShouldDownload => !didDownloadAlready && (Updater is null || !HasLatestVersion);

    public static readonly Dictionary<string, ModSetting> AutoUpdateSettings = new();

    public static void CheckForUpdates()
    {
        if (ModHelper.Main.GetModHelperData() is {CachedModHelperData: { } data})
        {
            latestVersionString = ModHelperData.GetRegexMatch<string>(data, ModHelperData.UpdaterVersionRegex);
        }

        if (ShouldDownload)
        {
            DownloadLatest();
        }
    }

    public static void DownloadLatest()
    {
        try
        {
            Updater?.MoveToDisabledFolder();
        }
        catch (Exception)
        {
            // ignored
        }

        if (didDownloadAlready) return;

        ModHelperHttp.DownloadFile(DownloadUrl, FilePath).ContinueWith(task =>
        {
            if (task.Result)
            {
                didDownloadAlready = true;
                ModHelper.Msg("Successfully downloaded updater plugin");

                if (Updater is { } plugin)
                {
                    plugin.SetFilePath(FilePath);
                }
            }
        });
    }

    public static void Enable()
    {
        if (Updater is { } plugin && HasLatestVersion)
        {
            if (!plugin.Enabled) plugin.MoveToEnabledFolder();
            return;
        }

        if (didDownloadAlready && !File.Exists(FilePath) && File.Exists(FilePathDisabled))
        {
            File.Move(FilePathDisabled, FilePath);
            return;
        }

        DownloadLatest();
    }

    public static void Disable()
    {
        if (Updater is { } plugin)
        {
            if (plugin.Enabled) plugin.MoveToDisabledFolder();
            return;
        }

        if (File.Exists(FilePath))
        {
            File.Delete(FilePathDisabled);
            File.Move(FilePath, FilePathDisabled);
        }
    }

    public static void CheckUpdatedMods()
    {
        if (Updater is not {Mod: MelonPlugin plugin}) return;

        try
        {
            var list = (ConcurrentBag<string>) plugin.GetType()
                .GetField("UpdatedMods", BindingFlags.Static | BindingFlags.Public)!
                .GetValue(plugin)!;

            if (!list.Any()) return;

            PopupScreen.instance.SafelyQueue(screen =>
            {
                screen.ShowOkPopup($"The following mods were automatically updated:\n{list.Join()}");
                screen.MakeTextScrollable();
                list.Clear();
            });
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
    }

    public static readonly ModSettingCategory AutoUpdateMods = new("Auto Update Mods")
    {
        collapsed = false
    };

    public static void PopulateSettings()
    {
        if (Updater is not {Mod: { } mod}) return;

        var defaultAutoUpdate = new ModSettingBool(true)
        {
            displayName = "Default Auto Update Setting",
            description =
                "Whether the default is to auto update a mod unless it's set not to, or not auto update a mod until it's set to",
            onSave = b =>
            {
                foreach (var modSetting in AutoUpdateSettings.Values
                             .Where(setting => setting.category == AutoUpdateMods)
                             .OfType<ModSettingBool>())
                {
                    modSetting.SetDefaultValue(b);
                }
            },
            button = true,
            enabledText = "Auto Update",
            disabledText = "Dont Auto Update"
        };
        AutoUpdateSettings["DefaultAutoUpdateSetting"] = defaultAutoUpdate;

        ModSettingsHandler.LoadModSettings(mod);

        var defaultValue = defaultAutoUpdate.value;

        foreach (var modHelperData in ModHelperData.All.Where(data => data.Mod is not MelonMain && !data.Plugin))
        {
            AutoUpdateSettings[modHelperData.DllName.Replace(".dll", "")] = new ModSettingBool(defaultValue)
            {
                displayName = modHelperData.DisplayName,
                category = AutoUpdateMods,
                description = $"Whether {modHelperData.DisplayName} should automatically update on startup",
                modifyOption = option =>
                {
                    if (!modHelperData.HasNoIcon && modHelperData.GetIcon() is Sprite sprite)
                    {
                        option.Icon.gameObject.SetActive(true);
                        option.Icon.enabled = true;
                        option.Icon.Image.SetSprite(sprite);
                        option.Icon.Image.enabled = true;
                    }
                },
                button = true,
                enabledText = "Auto Update",
                disabledText = "Dont Auto Update"
            };
        }

        ModSettingsHandler.LoadModSettings(mod);
    }
}