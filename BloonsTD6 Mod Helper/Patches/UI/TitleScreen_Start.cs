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
            new PreLoadResourcesTask().RunSync();
            ModContent.GetContent<ModByteLoader>().Do(loader => loader.LoadAllBytes());

            ModHelper.Mods
                .Where(mod => mod.Content.Count > 0)
                .OrderBy(mod => mod.Priority)
                .Select(mod => new ModContentTask {mod = mod})
                .Do(task => task.RunSync());

            ModContent.GetContent<ModLoadTask>().Do(task => task.RunSync());
        }

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}