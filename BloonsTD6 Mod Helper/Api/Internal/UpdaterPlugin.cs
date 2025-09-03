using System;
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

    public static ModHelperData Updater => ModHelperData.All.FirstOrDefault(IsUpdaterPlugin);

    private static string DownloadUrl =>
        $"https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/releases/latest/download/{DllName}";

    private static string FilePath => Path.Combine(MelonEnvironment.PluginsDirectory, DllName);
    private static string FilePathDisabled => Path.Combine(ModHelper.DisabledModsDirectory, DllName);

    private static bool didDownloadAlready;

    public static bool HasLatestVersion => Updater is { } currentPlugin &&
                                           SemVersion.TryParse(currentPlugin.Version, out var installedVersion) &&
                                           SemVersion.TryParse(ModHelper.UpdaterVersion, out var latestVersion) &&
                                           installedVersion >= latestVersion;

    public static bool ShouldDownload => !didDownloadAlready && (Updater is null || !HasLatestVersion);

    public static readonly Dictionary<string, ModSetting> AutoUpdateSettings = new();


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
            var list = (List<string>) plugin.GetType()
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

    public static void PopulateSettings()
    {
        if (Updater is not {Mod: { } mod}) return;

        foreach (var modHelperData in ModHelperData.All.Where(data => data.Mod is not MelonMain && !data.Plugin))
        {
            AutoUpdateSettings[modHelperData.DllName.Replace(".dll", "")] = new ModSettingBool(true)
            {
                displayName = modHelperData.DisplayName,
                modifyOption = option =>
                {
                    if (!modHelperData.HasNoIcon && modHelperData.GetIcon() is Sprite sprite)
                    {
                        option.Icon.gameObject.SetActive(true);
                        option.Icon.enabled = true;
                        option.Icon.Image.SetSprite(sprite);
                    }
                }
            };
        }

        ModSettingsHandler.LoadModSettings(mod);
    }
}