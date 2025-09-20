using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AssetRipper.VersionUtilities;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.InternalUtils;
using MelonLoader.Utils;
using Newtonsoft.Json.Linq;
using Semver;
using TinyDialogsNet;
using UnityEngine;
namespace UpdaterPlugin;

public class Message
{
    public enum MelonStage
    {
        OnPreInitialization,
        OnApplicationEarlyStart,
        OnPreModsLoaded, // This is the first stage when the GameVersion can be fully accurately determined
        OnApplicationStart
    }

    private const string MessageName = "messages.json";
    private const string File = "tinyfiledialogs";

    private static bool applicationVersionSafe;
    private static bool dialogWorks;

    private static readonly string GithubUrl =
        $"{ModHelperGithub.RawUserContent}/{ModHelper.RepoOwner}/{ModHelper.RepoName}/{ModHelper.Branch}";

    public MelonStage Stage { get; init; } = MelonStage.OnPreModsLoaded;

    public MessageBoxIconType Type { get; init; } = MessageBoxIconType.Warning;

    public MessageBoxDialogType Dialog { get; init; } = MessageBoxDialogType.Ok;

    public string Id { get; init; }

    public string Title { get; init; } = "Message from Mod Helper";

    public string Body { get; init; } = "Default";

    public string URL { get; init; }

    public string UnityVersionMax { get; init; }

    public string UnityVersionMin { get; init; }

    public string MelonLoaderVersionMax { get; init; }

    public string MelonLoaderVersionMin { get; init; }

    public string GameVersionMax { get; init; }

    public string GameVersionMin { get; init; }

    public bool ShouldShow()
    {
        if (!string.IsNullOrEmpty(UnityVersionMax))
        {
            try
            {
                var unityVersionMax = UnityVersion.Parse(UnityVersionMax);

                if (UnityInformationHandler.EngineVersion > unityVersionMax)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to parse warning {nameof(UnityVersionMax)}");
                ModHelper.Warning(e);
                return false;
            }
        }

        if (!string.IsNullOrEmpty(UnityVersionMin))
        {
            try
            {
                var unityVersionMin = UnityVersion.Parse(UnityVersionMin);

                if (UnityInformationHandler.EngineVersion < unityVersionMin)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to parse warning {nameof(UnityVersionMin)}");
                ModHelper.Warning(e);
                return false;
            }
        }

        var version = typeof(MelonEnvironment).Assembly.GetName().Version!;
        var versionString = $"{version.Major}.{version.Minor}.{version.Build}";

        if (SemVersion.TryParse(versionString, out var melonLoaderVersion))
        {
            if (!string.IsNullOrEmpty(MelonLoaderVersionMax) &&
                SemVersion.TryParse(MelonLoaderVersionMax, out var melonLoaderVersionMax) &&
                melonLoaderVersion > melonLoaderVersionMax)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(MelonLoaderVersionMin) &&
                SemVersion.TryParse(MelonLoaderVersionMin, out var melonLoaderVersionMin) &&
                melonLoaderVersion > melonLoaderVersionMin)
            {
                return false;
            }
        }

        if (!string.IsNullOrEmpty(GameVersionMax) || !string.IsNullOrEmpty(GameVersionMin))
        {
            var gameVersionString = applicationVersionSafe ? Application.version : UnityInformationHandler.GameVersion;

            if (SemVersion.TryParse(gameVersionString, out var gameVersion))
            {
                if (!string.IsNullOrEmpty(GameVersionMax) &&
                    SemVersion.TryParse(GameVersionMax, out var gameVersionMax) &&
                    gameVersion > gameVersionMax)
                {
                    return false;
                }

                if (!string.IsNullOrEmpty(GameVersionMin) &&
                    SemVersion.TryParse(GameVersionMin, out var gameVersionMin) &&
                    gameVersion > gameVersionMin)
                {
                    return false;
                }
            }
            else
            {
                ModHelper.Warning($"Unknown game version: {gameVersionString}");
            }
        }


        return true;
    }

    public void Show()
    {
        if (dialogWorks)
        {
            var defaultButton = Dialog switch
            {
                MessageBoxDialogType.Ok => MessageBoxButton.Ok,
                MessageBoxDialogType.OkCancel => MessageBoxButton.Cancel,
                MessageBoxDialogType.YesNo => MessageBoxButton.No,
                MessageBoxDialogType.YesNoCancel => MessageBoxButton.Cancel
            };

            var successButton = Dialog switch
            {
                MessageBoxDialogType.Ok => MessageBoxButton.Ok,
                MessageBoxDialogType.OkCancel => MessageBoxButton.Ok,
                MessageBoxDialogType.YesNo => MessageBoxButton.Yes,
                MessageBoxDialogType.YesNoCancel => MessageBoxButton.Yes
            };

            var result = TinyDialogs.MessageBox(Title, Body, Dialog, Type, defaultButton);
            if (result == successButton && !string.IsNullOrEmpty(URL))
            {
                Process.Start(new ProcessStartInfo(URL)
                {
                    UseShellExecute = true
                });
            }
        }
        else
        {
            Action<object> log = Type switch
            {
                MessageBoxIconType.Information => ModHelper.Msg,
                MessageBoxIconType.Warning => ModHelper.Warning,
                MessageBoxIconType.Error => ModHelper.Error,
                _ => ModHelper.Warning
            };

            log(Title);
            log(Body);
            if (!string.IsNullOrEmpty(URL)) log(URL);
        }
    }

    public void Handle()
    {
        try
        {
            if (ShouldShow()) Show();
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }
    }

    public static async Task CheckForMessages()
    {
        MelonEvents.OnPreModsLoaded.Subscribe(() => applicationVersionSafe = true);
        try
        {
            var file = await ModHelperHttp.Client.GetStringAsync(Path.Combine(GithubUrl, MessageName));

            if (string.IsNullOrEmpty(file)) return;

            var messages = JArray.Parse(file);

            if (messages.Count == 0) return;

            dialogWorks = await PrepareNativeDlls();

            foreach (var jToken in messages)
            {
                var message = jToken.ToObject<Message>();

                switch (message.Stage)
                {
                    case MelonStage.OnApplicationEarlyStart:
                        MelonEvents.OnPreInitialization.Subscribe(message.Handle);
                        break;
                    case MelonStage.OnPreModsLoaded:
                        MelonEvents.OnPreModsLoaded.Subscribe(message.Handle);
                        break;
                    case MelonStage.OnApplicationStart:
                        MelonEvents.OnApplicationStart.Subscribe(message.Handle);
                        break;
                    case MelonStage.OnPreInitialization:
                    default:
                        message.Handle();
                        break;
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning("Failed to check for messages from Mod Helper");
            ModHelper.Warning(e);
        }
    }

    public static string GetDllName()
    {
        string ext;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) ext = "dll";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) ext = "so";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) ext = "dylib";
        else throw new PlatformNotSupportedException();

        return $"{File}.{ext}";
    }

    public static string GetDllUrl()
    {
        string os;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) os = "win";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) os = "linux";
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) os = "osx";
        else throw new PlatformNotSupportedException();

        var arch = RuntimeInformation.ProcessArchitecture switch
        {
            Architecture.X64 => "x64",
            Architecture.X86 => "x86",
            _ => throw new PlatformNotSupportedException()
        };

        return Path.Combine(GithubUrl, nameof(UpdaterPlugin), File, $"{os}-{arch}", GetDllName());
    }

    private static async Task<bool> PrepareNativeDlls()
    {
        string url;
        try
        {
            var path = Path.Combine(MelonEnvironment.UserLibsDirectory, GetDllName());

            if (System.IO.File.Exists(path)) return true;

            url = GetDllUrl();

            return await ModHelperHttp.DownloadFile(url, path);
        }
        catch (PlatformNotSupportedException)
        {
            return false;
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            return false;
        }
    }
}