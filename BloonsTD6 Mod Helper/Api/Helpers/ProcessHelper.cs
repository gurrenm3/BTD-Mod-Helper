using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Helper methods for processes
/// </summary>
public static class ProcessHelper
{
    private static readonly string EpicLauncherWarning = ModHelper.Localize(nameof(EpicLauncherWarning),
        "For the Epic Games version, you need to manually rerun the game from the Epic Launcher");
    private const int WaitSeconds = 10;

    /// <summary>
    /// Exits the game and starts a new process after waiting 10 seconds, to ensure no "Another instance is already running"
    /// errors
    /// </summary>
    public static void RestartGame()
    {
        if (ModHelper.IsEpic)
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup(
                EpicLauncherWarning.Localize(),
                new Action(() => MenuManager.instance.QuitGame())));
            return;
        }

        var linux = MelonUtils.IsUnderWineOrSteamProton();
        Process.Start(new ProcessStartInfo
        {
            Arguments = (linux ? "-c" : "/C") +
                        $" ping 127.0.0.1 -n {WaitSeconds} && " +
                        $"\"{MelonEnvironment.GameExecutablePath}\" " +
                        Environment.GetCommandLineArgs().Skip(1).Join(delimiter: " "),
            WindowStyle = ProcessWindowStyle.Hidden,
            CreateNoWindow = true,
            FileName = linux ? "sh" : "cmd.exe",
            UseShellExecute = true
        });

        MenuManager.instance.QuitGame();
    }

    /// <summary>
    /// Opens a url in the default browser
    /// </summary>
    /// <param name="url">URL to open</param>
    public static void OpenURL(string url)
    {
        Process.Start(new ProcessStartInfo(url)
        {
            UseShellExecute = true
        });
    }
    
    /// <summary>
    /// Opens a file in the default app for it
    /// </summary>
    /// <param name="filePath">File path</param>
    public static void OpenFile(string filePath)
    {
        filePath = filePath.Replace('/', Path.DirectorySeparatorChar);
        Process.Start(new ProcessStartInfo(filePath)
        {
            UseShellExecute = true
        });
    }


    /// <summary>
    /// Opens a folder in the file explorer
    /// </summary>
    /// <param name="folderPath">Folder to open</param>
    public static void OpenFolder(string folderPath)
    {
        folderPath = folderPath.Replace('/', Path.DirectorySeparatorChar);
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start("explorer.exe", folderPath);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", folderPath);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", folderPath);
        }
        else
        {
            throw new NotSupportedException("Operating system not supported");
        }
    }
}