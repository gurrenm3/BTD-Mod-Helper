using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.Legends;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

#if DEBUG
using BTD_Mod_Helper.Api.Internal.JsonTowers;
#endif

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
internal class TitleScreen_Start
{
    [HarmonyPostfix]
    [HarmonyPriority(Priority.High)]
    internal static void Postfix()
    {
        ModArtifact.FixVanillaArtifactDependants();

        if (ModHelper.FallbackToOldLoading)
        {
            ModByteLoader.currentLoadTask?.Wait();
            ModContent.GetContent<ModByteLoader>().Where(loader => !loader.Loaded).Do(loader => loader.LoadAllBytes());

#if DEBUG
            JsonTowers.LoadTask?.Wait();
            JsonTowers.ProcessAll(Game.instance.model);
#endif

            PreLoadResourcesTask.Instance.RunSync();

            ModHelper.Mods
                .Where(mod => mod.Content.Count > 0)
                .OrderBy(mod => mod.Priority)
                .Select(mod => mod.LoadContentTask)
                .Do(task => task.RunSync());
        }

        NamedModContent.RegisterAllText();
        LocalizationHelper.Initialize();
        ModSettingsHandler.SaveModSettings(false, false);
        ModHelperFiles.DownloadDocumentationXml();
        ModHelperData.SaveAll();
        ModGameMode.ModifyDefaultGameModes(GameData.Instance);


        var gameObject = new GameObject("ModHelperQuickAccess");
        SceneManager.MoveGameObjectToScene(gameObject, Game.instance.gameObject.scene);
        gameObject.AddComponent<Instances>();
        gameObject.AddComponent<Lists>();

        ModHelper.PerformHook(mod => mod.OnTitleScreen());
    }
}