using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.Internal;

internal static class EpicCompatibility
{
    internal const string GameName = "BloonsTD6-Epic";

    internal const string RepoName = "BTD6EpicGamesModCompat";
    private const string RepoOwner = "GrahamKracker";
    private const string DllName = $"{RepoName}.dll";
    private static string BackupUrl => $"https://github.com/{RepoOwner}/{RepoName}/releases/latest/download/{DllName}";

    private static readonly string CompatibilityPluginNeeded =
        ModHelper.Localize(nameof(CompatibilityPluginNeeded), "Compatibility Plugin Needed");
    private static readonly string CompatibilityPluginBody = ModHelper.Localize(nameof(CompatibilityPluginBody), """
        You need the BTD6EpicGamesModCompat plugin in order for your other mods to be able to work on the Epic Games version. 
        Would you like to download it now?
        """);
    private static readonly string CompatibilityPluginSuccess = ModHelper.Localize(nameof(CompatibilityPluginSuccess), """
        Successfully downloaded the compatability plugin. 
        You will now need to manually relaunch the game from the Epic Games Launcher.
        """);

    public static void PromptDownloadPlugin()
    {
        PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
            CompatibilityPluginNeeded.Localize(), CompatibilityPluginBody.Localize(), new Action(() =>
                {
                    var plugin = ModHelperGithub.Mods.FirstOrDefault(data =>
                        data.RepoOwner == RepoOwner && data.RepoName == RepoName);

                    if (plugin != null)
                    {
                        Task.Run(() => ModHelperGithub.DownloadLatest(plugin, true, SuccessCallback));
                    }
                    else
                    {
                        Task.Run(async () =>
                        {
                            var filePath = Path.Combine(MelonEnvironment.PluginsDirectory, DllName);
                            var success = await ModHelperHttp.DownloadFile(BackupUrl, filePath);
                            if (success)
                            {
                                ModHelper.Msg($"Successfully downloaded to {filePath}");
                                SuccessCallback(filePath);
                            }
                            else
                            {
                                ModHelper.Error($"Failed to download {BackupUrl}");
                            }
                        });
                    }
                }
            ), "Yes", null, "No", Popup.TransitionAnim.Scale));
    }

    private static void SuccessCallback(string filePath)
    {
        PopupScreen.instance.SafelyQueue(screen =>
            screen.ShowPopup(PopupScreen.Placement.menuCenter, LocalizationHelper.Success.Localize(),
                CompatibilityPluginSuccess.Localize(),
                new Action(() => MenuManager.instance.QuitGame()), "Quit", null, "Cancel", Popup.TransitionAnim.Scale));
    }
}