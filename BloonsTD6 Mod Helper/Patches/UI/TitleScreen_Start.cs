using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity.Scenes;
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

        NamedModContent.RegisterAll();
        ModSettingsHandler.SaveModSettings(true);
        ModHelperData.SaveAll();
        ModGameMode.ModifyDefaultGameModes(GameData.Instance);

        // Tests.ModelSerializationTests.TestSerialization(Game.instance.model);

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}