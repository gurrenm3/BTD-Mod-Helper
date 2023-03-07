using System;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;

[assembly: MelonInfo(typeof(MelonMain), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonPriority(-1000)]

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{
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
        //RoundSetChanger.EnsureHidden();  //TODO see if this is actually needed

#if BTD6_DEBUG
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

        foreach (var gameMode in Game.instance.model.mods)
        {
            if (gameMode.name.EndsWith("Only"))
            {
                // TODO fix modded tower sets
                /*var mutatorModModels = gameMode.mutatorMods.ToList();
                mutatorModModels.AddRange(ModContent.GetContent<ModTowerSet>()
                    .Where(set => !set.AllowInRestrictedModes)
                    .Select(set => new LockTowerSetModModel(gameMode.name, set.Id)));
                gameMode.mutatorMods = mutatorModModels.ToIl2CppReferenceArray();*/
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

    bool scheduledInGamePatch;

    private void Schedule_InGame_Loaded()
    {
        scheduledInGamePatch = true;
        TaskScheduler.ScheduleTask(() => ModHelper.PerformHook(mod => mod.OnInGameLoaded(InGame.instance)),
            () => InGame.instance && InGame.instance.GetSimulation() != null);
    }

    public override void OnInGameLoaded(InGame inGame) => scheduledInGamePatch = false;

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
}