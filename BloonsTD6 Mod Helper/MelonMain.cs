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
using BTD_Mod_Helper.Api.UI;
using BTD_Mod_Helper.UI.BTD6;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
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
[assembly: MelonOptionalDependencies("NAudio.Wasapi", "Il2CppFacepunch.Steamworks")]

namespace BTD_Mod_Helper;

internal partial class MelonMain : BloonsTD6Mod
{
    public override void OnInitialize()
    {
        ModContentInstances.AddInstance(GetType(), this);
        ModHelper.MigrateFolders();

        // Create all and load default mod settings
        ModSettingsHandler.InitializeModSettings();

        try
        {
            ModHelperHttp.Init();
            ModHelperGithub.Init();

            Task.Run(ModHelperGithub.GetVerifiedModders);
            if (PopulateOnStartup)
            {
                ModHelperGithub.populatingMods = Task.Run(ModHelperGithub.PopulateMods);
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

        try
        {
            FileDialogHelper.PrepareNativeDlls();
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        if (AutoUpdate && UpdaterPlugin.ShouldDownload)
        {
            UpdaterPlugin.DownloadLatest();
        }
    }

    public override void OnUpdate()
    {
        ModByteLoader.OnUpdate();
        RoundSetChanger.OnUpdate();
        ConsoleHandler.OnUpdate();
        NotificationMgr.CheckForNotifications();
        // InitialLoadTasks_MoveNext.OnUpdate();

        if (Game.instance is null || InGame.instance is null)
            return;

        RoundSetChanger.EnsureHidden();
        ModSettingHotkey.HandleTowerHotkeys();
        TowerEditing.OnUpdate();
        ModWindow.Update();
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

        if (!settings.TryGetValue("SavedWindows", out var savedWindows)) return;

        foreach (var savedWindow in savedWindows.OfType<JObject>())
        {
            if (!savedWindow.TryGetValue("ID", out var id)) continue;

            ModWindow.SavedWindows[id.Value<string>()!] = savedWindow.ToObject<SavedModWindow>();
        }
    }

    public override void OnSaveSettings(JObject settings)
    {
        settings["Version"] = ModHelper.Version;

        settings["SavedWindows"] = new JArray(ModWindow.SavedWindows.Values.Select(window => JObject.FromObject(window)));
    }

    public override void OnMainMenu()
    {
        if (ModHelper.IsEpic &&
            MelonBase.RegisteredMelons.All(melon => melon.GetName() != EpicCompatibility.RepoName))
        {
            EpicCompatibility.PromptDownloadPlugin();
        }

        var version = typeof(MelonEnvironment).Assembly.GetName().Version!;
        var versionString = $"{version.Major}.{version.Minor}.{version.Build}";

        if (ModHelperGithub.UnstableMelonLoaderVersions.Contains(versionString))
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
                "Unstable MelonLoader Version",
                """
                The currently installed version of MelonLoader is not considered stable for BTD6.
                Would you like to view the install guide to see the currently recommended version?
                """,
                new Action(() =>
                {
                    ProcessHelper.OpenURL(
                        $"https://{ModHelper.RepoOwner}.github.io/{ModHelper.RepoName}/wiki/Install-Guide#recommended-version");
                }), "OK", null, "No", Popup.TransitionAnim.Scale));
        }

        foreach (var renderTexture in ResourceHandler.RenderTexturesToRelease)
        {
            if (renderTexture != null)
            {
                renderTexture.Release();
            }
        }
        ResourceHandler.RenderTexturesToRelease.Clear();

        if (ModWindow.saveSettingsAfterGame)
        {
            ModSettingsHandler.SaveModSettings(this, true, false);
            ModWindow.saveSettingsAfterGame = false;
        }
    }
}