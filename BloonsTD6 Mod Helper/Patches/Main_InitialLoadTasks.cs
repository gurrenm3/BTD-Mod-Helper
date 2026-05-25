using System;
using System.Linq;
using BTD_Mod_Helper.Api;
using Il2CppSystem.Threading;
using Il2CppSystem.Threading.Tasks;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Main), nameof(Il2CppAssets.Scripts.Main.InitialLoadTasks))]
internal static class Main_InitialLoadTasks
{
    [HarmonyPostfix]
    internal static void Postfix(ref Task __result)
    {
        if (ModHelper.FallbackToOldLoading) return;
        try
        {
            __result = __result.ContinueWith(new Action<Task>(_ =>
            {
                ModLoadTask.RunAll().StartCoroutine();

                while (ModLoadTask.AllLoadTasks.Any(loadTask => !loadTask.Complete))
                {
                    Thread.Sleep(50);
                }
            }));
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
            ModHelper.FallbackToOldLoading = true;
        }
    }
}