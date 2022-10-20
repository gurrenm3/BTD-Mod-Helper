using System.Linq;
using Assets.Main.Scenes;
using BTD_Mod_Helper.Api;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
internal class TitleScreen_Start
{
    [HarmonyPostfix]
    [HarmonyPriority(Priority.High)]
    internal static void Postfix()
    {
        if (ModHelper.FallbackToOldLoading)
        {
            if (ModByteLoader.currentLoadTask != null) ModByteLoader.currentLoadTask.Wait();
            ModContent.GetContent<ModByteLoader>().Where(loader => !loader.Loaded).Do(loader => loader.LoadAllBytes());
            PreLoadResourcesTask.Instance.RunSync();

            ModHelper.Mods
                .Where(mod => mod.Content.Count > 0)
                .OrderBy(mod => mod.Priority)
                .Select(mod => mod.LoadContentTask)
                .Do(task => task.RunSync());

            ModContent.GetContent<ModLoadTask>().Do(task => task.RunSync());
        }

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}