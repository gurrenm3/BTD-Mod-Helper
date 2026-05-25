using System.Linq;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppNinjaKiwi.Localization;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(InitialLoadingScreen), nameof(InitialLoadingScreen.Update))]
internal static class InitialLoadingScreen_Update
{
    private static bool begun;

    [HarmonyPostfix]
    internal static void Postfix(InitialLoadingScreen __instance)
    {
        if (ModHelper.FallbackToOldLoading) return;

        if (ModLoadTask.CurrentTask is { } task)
        {
            begun = true;
            __instance.SetMainText("Modded " +
                                   LocalizationManager.Instance.Format("Loading Step",
                                       ModLoadTask.AllLoadTasks.Count(loadTask => loadTask.Complete) + 1,
                                       ModLoadTask.AllLoadTasks.Count));
            __instance.SetProgressBarVisible(task.ShowProgressBar);
            if (task.ShowProgressBar)
            {
                __instance.SetProgress(task.Progress);
            }
            __instance.SetSubText(task.DisplayName);
            if (!string.IsNullOrWhiteSpace(task.Description))
            {
                __instance.SetStatusText(task.Description);
            }
        }
        else if (begun && ModLoadTask.AllLoadTasks.All(loadTask => loadTask.Complete))
        {
            __instance.SetProgressBarVisible(false);
        }
    }
}