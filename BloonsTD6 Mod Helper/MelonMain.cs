using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.UI.BTD6;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using MelonLoader.Utils;
using Newtonsoft.Json.Linq;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;
#if DEBUG
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
#endif

[assembly: MelonInfo(typeof(MelonMain), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]
[assembly: MelonPriority(-1000)]
[assembly: MelonOptionalDependencies("NAudio.WinMM", "NAudio.Wasapi", "Il2CppFacepunch.Steamworks")]

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{
    public override void OnInitialize()
    {
        ModContentInstances.AddInstance(GetType(), this);

        // Create all and load default mod settings
        ModSettingsHandler.InitializeModSettings();

        try
        {
            ModHelperHttp.Init();
            ModHelperGithub.Init();

            Task.Run(ModHelperGithub.GetVerifiedModders);
            if (PopulateOnStartup)
            {
                Task.Run(ModHelperGithub.PopulateMods);
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        // Load Content from other mods
        ModHelper.LoadAllMods();

        // Load any mod settings that were added from other types
        ModSettingsHandler.LoadModSettings();

        // Utility to patch all valid UI "Open" methods for custom UI
        ModGameMenu.PatchAllTheOpens(HarmonyInstance);


        Schedule_GameModel_Loaded();
        Schedule_GameData_Loaded();

        try
        {
            // Create the targets file for mod sources
            ModHelperFiles.CreateTargetsFile(ModSourcesFolder);
        }
        catch (Exception e)
        {
            ModHelper.Warning("Could not create .targets file in Mod Sources. " +
                              "If you have no intention of making mods, you can ignore this.");
            ModHelper.Warning(e);
        }

        if (!ModHelper.IsEpic)
        {
            HarmonyInstance.CreateClassProcessor(typeof(EmbeddedBrowser.SteamWebView_OnGUI), true).Patch();
        }

        if (typeof(MelonEnvironment).Assembly.GetName().Version is {Minor: 6, Build: > 1})
        {
            loadErrors.Add("MelonLoader versions higher than 0.6.1 are not yet considered stable for BloonsTD6. " +
                           "Please downgrade to MelonLoader 0.6.1 via its installer for best results.");
        }
    }

    public override void OnUpdate()
    {
        ModByteLoader.OnUpdate();
        RoundSetChanger.OnUpdate();
        // InitialLoadTasks_MoveNext.Update();

        if (Game.instance is null || InGame.instance is null)
            return;

        NotificationMgr.CheckForNotifications();
        RoundSetChanger.EnsureHidden();
        ModSettingHotkey.HandleTowerHotkeys();

#if DEBUG
        if (ExportSelectedTower.JustPressed() &&
            TowerSelectionMenu.instance != null &&
            TowerSelectionMenu.instance.selectedTower != null)
        {
            GameModelExporter.Export(TowerSelectionMenu.instance.selectedTower.tower.towerModel, "selected_tower.json");
        }
#endif
    }

    public override void OnTitleScreen()
    {
        Schedule_InGame_Loaded();
    }

    private void Schedule_GameModel_Loaded()
    {
        TaskScheduler.ScheduleTask(
            () => ModHelper.PerformHook(mod => mod.OnGameModelLoaded(Game.instance.model)),
            () => Game.instance && Game.instance.model != null);
    }

    private void Schedule_InGame_Loaded()
    {
        TaskScheduler.ScheduleTask(() => ModHelper.PerformHook(mod => mod.OnInGameLoaded(InGame.instance)),
            () => InGame.instance && InGame.instance.GetSimulation() != null);
    }

    public void Schedule_GameData_Loaded()
    {
        TaskScheduler.ScheduleTask(() => ModHelper.PerformHook(mod => mod.OnGameDataLoaded(GameData.Instance)),
            () => GameData.Instance != null);
    }

    public override void OnInGameLoaded(InGame inGame)
    {
        inGame.gameObject.AddComponent<Instances>();
        TaskScheduler.ScheduleTask(Schedule_InGame_Loaded, () => !InGame.instance);
    }

    public override void OnLoadSettings(JObject settings)
    {
        var version = settings["Version"];
        if (version == null || version.ToString() != ModHelper.Version)
        {
            ModHelperHttp.DownloadDocumentationXml();
        }
    }

    public override void OnSaveSettings(JObject settings)
    {
        settings["Version"] = ModHelper.Version;
    }

    public override void OnMainMenu()
    {
        if (ModHelper.IsEpic &&
            MelonBase.RegisteredMelons.All(melon => melon.GetName() != EpicCompatibility.RepoName))
        {
            EpicCompatibility.PromptDownloadPlugin();
        }
    }
}