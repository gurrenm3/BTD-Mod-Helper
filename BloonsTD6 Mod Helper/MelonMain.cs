using System;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Newtonsoft.Json.Linq;
using ModHelperData = BTD_Mod_Helper.Api.Data.ModHelperData;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;
[assembly: MelonInfo(typeof(MelonMain), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonPriority(-1000)]
[assembly: MelonOptionalDependencies("NAudio.WinMM", "NAudio.Wasapi")] // Avoids the warning about these not getting ILRepacked; they're not needed

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{

    private bool scheduledInGamePatch;

    public override void OnInitialize()
    {
        ModContentInstances.AddInstance(GetType(), this);

        // Mod Settings
        ModSettingsHandler.InitializeModSettings();

        try
        {
            ModHelperHttp.Init();
            ModHelperGithub.Init();

            Task.Run(ModHelperGithub.PopulateMods);
            Task.Run(ModHelperGithub.GetVerifiedModders);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        // Load Content from other mods
        ModHelper.LoadAllMods();

        // Utility to patch all valid UI "Open" methods for custom UI
        ModGameMenu.PatchAllTheOpens(HarmonyInstance);


        Schedule_GameModel_Loaded();
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
    }

    public override void OnUpdate()
    {
        ModByteLoader.OnUpdate();
        // InitialLoadTasks_MoveNext.Update();

        if (Game.instance is null || InGame.instance is null)
            return;

        NotificationMgr.CheckForNotifications();
        RoundSetChanger.EnsureHidden();

#if DEBUG
        if (TowerSelectionMenu.instance != null &&
            TowerSelectionMenu.instance.selectedTower != null &&
            ExportSelectedTower.JustPressed())
        {
            GameModelExporter.Export(TowerSelectionMenu.instance.selectedTower.tower.towerModel, "selected_tower.json");
        }
#endif

    }

    public override void OnTitleScreen()
    {
        ModSettingsHandler.SaveModSettings(true);
        foreach (var modHelperData in ModHelperData.Active)
        {
            modHelperData.SaveToJson(ModHelper.DataDirectory);
        }

        if (!scheduledInGamePatch) Schedule_InGame_Loaded();

        foreach (var gameMode in GameData.Instance.mods)
        {
            if (gameMode.name.EndsWith("Only"))
            {
                var mutatorModModels = gameMode.mutatorMods.ToList();
                mutatorModModels.AddRange(ModContent.GetContent<ModTowerSet>()
                    .Where(set => !set.AllowInRestrictedModes)
                    .Select(set => new LockTowerSetModModel(gameMode.name, set.Set)));
                gameMode.mutatorMods = mutatorModModels.ToIl2CppReferenceArray();
            }

            if (gameMode.mutatorMods == null) continue;

            foreach (var mutatorMod in gameMode.mutatorMods)
            {
                var typeName = mutatorMod.GetIl2CppType().Name;
                if (!mutatorMod.name.StartsWith(typeName))
                {
                    mutatorMod.name = mutatorMod._name = typeName + "_" + mutatorMod.name;
                }
            }
        }
    }

    private void Schedule_GameModel_Loaded()
    {
        TaskScheduler.ScheduleTask(
            () => ModHelper.PerformHook(mod => mod.OnGameModelLoaded(Game.instance.model)),
            () => Game.instance && Game.instance.model != null);
    }

    private void Schedule_InGame_Loaded()
    {
        scheduledInGamePatch = true;
        TaskScheduler.ScheduleTask(() => ModHelper.PerformHook(mod => mod.OnInGameLoaded(InGame.instance)),
            () => InGame.instance && InGame.instance.GetSimulation() != null);
    }

    public override void OnInGameLoaded(InGame inGame)
    {
        scheduledInGamePatch = false;
    }

    public void Schedule_GameData_Loaded()
    {
        TaskScheduler.ScheduleTask(() => ModHelper.PerformHook(mod => mod.OnGameDataLoaded(GameData.Instance)),
            () => GameData.Instance != null);
    }

    public override void OnMainMenu()
    {
        Animations.Load();
        Fonts.Load();
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
}