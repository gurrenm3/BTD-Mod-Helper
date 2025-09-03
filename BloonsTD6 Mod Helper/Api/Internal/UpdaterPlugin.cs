using System;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;
using Semver;

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
}