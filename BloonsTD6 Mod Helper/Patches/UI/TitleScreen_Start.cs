using System;
using System.Linq;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppNinjaKiwi.Common;
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
        }

        var currentTable = LocalizationManager.Instance.textTable;
        var defaultTable = LocalizationManager.Instance.defaultTable;
        foreach (var namedModContent in ModContent.GetContent<NamedModContent>())
        {
            try
            {
                namedModContent.RegisterText(currentTable);
                namedModContent.RegisterText(defaultTable);
            }
            catch (Exception e)
            {
                ModHelper.Log($"Failed to register text for {namedModContent}");
                ModHelper.Error(e);
            }
        }

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}
