using System;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Models.TowerSets.Mods;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.UI.Modded;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;

[assembly: MelonInfo(typeof(MelonMain), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonPriority(-1000)]

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{
    public override void OnInitialize()
    {
        ModContentInstances.SetInstance(GetType(), this);

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

    private static bool afterTitleScreen;

    public override void OnUpdate()
    {
        ModByteLoader.OnUpdate();

        if (Game.instance is null)
            return;

        if (PopupScreen.instance != null && afterTitleScreen)
        {
            PopupScreen.instance.hasSeenModderWarning = AutoHideModdedClientPopup;
        }

        if (InGame.instance is null)
            return;

        NotificationMgr.CheckForNotifications();
        RoundSetChanger.EnsureHidden();

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

        AutoSave.InitAutosave(this.GetModSettingsDir(true));

        foreach (var gameMode in Game.instance.model.mods)
        {
            if (gameMode.name.EndsWith("Only"))
            {
                var mutatorModModels = gameMode.mutatorMods.ToList();
                mutatorModModels.AddRange(ModContent.GetContent<ModTowerSet>()
                    .Where(set => !set.AllowInRestrictedModes)
                    .Select(set => new LockTowerSetModModel(gameMode.name, set.Id)));
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

        afterTitleScreen = true;
    }

    private void Schedule_GameModel_Loaded()
    {
        TaskScheduler.ScheduleTask(
            () => { ModHelper.PerformHook(mod => mod.OnGameModelLoaded(Game.instance.model)); },
            () => Game.instance && Game.instance.model != null);
    }

    bool scheduledInGamePatch;

    private void Schedule_InGame_Loaded()
    {
        scheduledInGamePatch = true;
        TaskScheduler.ScheduleTask(() => { ModHelper.PerformHook(mod => mod.OnInGameLoaded(InGame.instance)); },
            () => InGame.instance && InGame.instance.GetSimulation() != null);
    }

    public override void OnInGameLoaded(InGame inGame) => scheduledInGamePatch = false;

    public override void OnMainMenu()
    {
        Animations.Load();
        Fonts.Load();
        RoundSetChanger.EnsureHidden();
    }

    #region Autosave

    public override void OnMatchEnd() => AutoSave.backup.CreateBackup();

    #endregion
}