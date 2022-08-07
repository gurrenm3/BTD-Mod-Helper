using System;
using System.Threading.Tasks;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.UI.Modded;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;

[assembly: MelonInfo(typeof(MelonMain), ModHelper.Name, ModHelper.Version, ModHelper.Author)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonPriority(-1000)]

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModContentInstances.SetInstance(GetType(), this);

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

        // Mod Settings
        ModSettingsHandler.InitializeModSettings();

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
    }

    public override void OnTitleScreen()
    {
        ModSettingsHandler.SaveModSettings(true);

        if (!scheduledInGamePatch)
            Schedule_InGame_Loaded();

        AutoSave.InitAutosave(this.GetModSettingsDir(true));


        foreach (var gameMode in Game.instance.model.mods)
        {
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

    #region Autosave

    public override void OnMatchEnd() => AutoSave.backup.CreateBackup();

    #endregion
}