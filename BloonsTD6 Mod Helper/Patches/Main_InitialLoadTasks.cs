using System;
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
            __result = __result.ContinueWith(new Action<Task>(void (_) =>
            {
                try
                {
                    var waitHandle = new ManualResetEvent(false);

                    ModLoadTask.RunAll(waitHandle).StartCoroutine();

                    waitHandle.WaitOne();
                }
                catch (Exception e)
                {
                    ModHelper.Error(e);
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