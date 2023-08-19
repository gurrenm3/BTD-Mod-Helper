using System;
using System.Diagnostics;
using System.Linq;
using BTD_Mod_Helper.UI.BTD6;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Helper methods for processes
/// </summary>
public static class ProcessHelper
{
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
                "For the Epic Games version, you need to manually rerun the game from the Epic Launcher",
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
}