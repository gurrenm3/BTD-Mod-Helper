using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;
using Newtonsoft.Json.Linq;
using Semver;
using TinyDialogsNet;
// ReSharper disable UnusedAutoPropertyAccessor.Global AutoPropertyCanBeMadeGetOnly.Global

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

    private static bool dialogWorks;

    private const string GithubUrl =
        $"{ModHelperGithub.RawUserContent}/{ModHelper.RepoOwner}/{ModHelper.RepoName}/{ModHelper.Branch}";

    public MelonStage Stage { get; init; } = MelonStage.OnPreModsLoaded;

    public MessageBoxIconType Type { get; init; } = MessageBoxIconType.Warning;

    public MessageBoxDialogType Dialog { get; init; } = MessageBoxDialogType.Ok;

    public string Id { get; init; }

    public string Title { get; init; } = "Message from BTD6 Mod Helper";

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
        if (!string.IsNullOrEmpty(UnityVersionMax) || !string.IsNullOrEmpty(UnityVersionMin))
        {
            try
            {
                if (SemVersion.TryParse(VersionCompat.UnityVersionWithoutType, out var unityVersion))
                {
                    if (!string.IsNullOrEmpty(UnityVersionMax) &&
                        SemVersion.TryParse(VersionCompat.RemoveUnityInfo(UnityVersionMax), out var unityVersionMax) &&
                        unityVersion > unityVersionMax)
                    {
                        return false;
                    }

                    if (!string.IsNullOrEmpty(UnityVersionMin) &&
                        SemVersion.TryParse(VersionCompat.RemoveUnityInfo(UnityVersionMin), out var unityVersionMin) &&
                        unityVersion < unityVersionMin)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        if (SemVersion.TryParse(VersionCompat.MelonLoaderVersion, out var melonLoaderVersion))
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
            if (SemVersion.TryParse(VersionCompat.GameVersion, out var gameVersion))
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
                ModHelper.Warning($"Unknown game version: {VersionCompat.GameVersion}");
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
                MessageBoxDialogType.YesNoCancel => MessageBoxButton.Cancel,
                _ => throw new ArgumentOutOfRangeException()
            };

            try
            {
                var result = TinyDialogs.MessageBox(Title, Body, Dialog, Type, defaultButton);
                if (result is MessageBoxButton.Cancel or MessageBoxButton.No)
                {
                    return;
                }
            }
            catch (Exception e)
            {
#if DEBUG
                ModHelper.Warning(e);
#endif
            }

            if (!string.IsNullOrEmpty(URL))
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
        try
        {
            var path = Path.Combine(MelonEnvironment.UserLibsDirectory, GetDllName());

            if (System.IO.File.Exists(path)) return true;

            var url = GetDllUrl();

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