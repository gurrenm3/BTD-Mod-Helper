using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppNinjaKiwi.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;

#if DEBUG
#endif

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
internal class TitleScreen_Start
{
    [HarmonyPostfix]
    [HarmonyPriority(Priority.High)]
    internal static void Postfix()
    {
        // Runs all load tasks synchronously that haven't already completed
        ModLoadTask.RunAllSync();

        // Load mod settings a final time for any that were added during the Registration phase
        ModSettingsHandler.LoadModSettings();
        // Save all initial mod settings
        ModSettingsHandler.SaveModSettings(false, false);

        NamedModContent.RegisterAllText();
        LocalizationHelper.Initialize();
        ModGameMode.ModifyDefaultGameModes(GameData.Instance);

#if !RELEASELITE
        ModHelperData.SaveAll();
#endif

        var gameObject = new GameObject("ModHelperQuickAccess");
        SceneManager.MoveGameObjectToScene(gameObject, Game.instance.gameObject.scene);
        gameObject.AddComponent<Instances>();
        gameObject.AddComponent<Lists>();

        ModHelper.PerformHook(mod => mod.OnTitleScreen());

        ConsoleHandler.SetupMelonConsole();
        ConsoleHandler.RunCommandsFromArgs().StartCoroutine();
    }
}