using Assets.Scripts.Unity;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.ModOptions;
using System;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Utils;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModMenu;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;
using BTD_Mod_Helper;

[assembly: MelonInfo(typeof(MelonMain), "BloonsTD6 Mod Helper", ModHelper.Version, "Gurrenm4 and Doombubbles")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BTD_Mod_Helper;

internal class MelonMain : BloonsTD6Mod
{
#pragma warning disable CS0672
    public override string GithubReleaseURL => "https://api.github.com/repos/gurrenm3/BTD-Mod-Helper/releases";
    public override string LatestURL => "https://github.com/gurrenm3/BTD-Mod-Helper/releases/latest";
#pragma warning restore CS0672

    public override void OnApplicationStart()
    {
        ModContentInstances.SetInstance(GetType(), this);

        try
        {
            ModHelperHttp.Init();
            ModHelperGithub.Init();
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        // Mod Settings
        ModSettingsHandler.InitializeModSettings();
        ModSettingsHandler.LoadModSettings();

        Schedule_GameModel_Loaded();

        // Load Content from other mods
        ModHelper.LoadAllMods();

        ModGameMenu.PatchAllTheOpens(HarmonyInstance);

        Task.Run(ModHelperGithub.PopulateMods);
        Task.Run(ModHelperGithub.GetVerifiedModders);

        try
        {
            CreateTargetsFile(ModSourcesFolder);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    public static readonly ModSettingBool BypassSavingRestrictions = new(true)
    {
        description =
            "With BTD6 v30.0, Ninja Kiwi made it so that progress can not be saved on your profile if it detects that you have mods, or even just MelonLoader, installed. " +
            "We think that they have gone too far with this change, and that it is not consistent with their stated goal in the patch notes of trying 'not to detract from modding'. " +
            "So, this setting overrides that restriction and will allow progress to be saved once more."
    };

    public static readonly ModSettingBool CleanProfile = new(true)
    {
        description =
            "Automatically removes modded information from your profile before the data gets synced to the " +
            "Ninja Kiwi servers. NOTE: This is for very specific information relating to custom content implemented " +
            "using the Mod Helper. This does not broadly prevent hacker pooling or mods messing up your profile in other ways."
    };

    private static readonly ModSettingBool AutoHideModdedClientPopup = false;

    private static readonly ModSettingCategory ModMaking = "Mod Making";

    private static readonly ModSettingButton OpenLocalDirectory = new()
    {
        displayName = "Open Local Files Directory",
        action = () => Process.Start(FileIOUtil.sandboxRoot),
        buttonText = "Open",
        description =
            "This is the 'Sandbox Root' directory that many vanilla and modded services use to dump files into.",
        category = ModMaking
    };

    private static readonly ModSettingButton ExportGameModel = new()
    {
        displayName = "Export Game Data",
        description =
            "Exports much of the games data to json files that you can view. Helpful for understanding how " +
            "vanilla content was implemented by Ninja Kiwi.",
        action = () =>
        {
            GameModelExporter.ExportAll();
            PopupScreen.instance.ShowOkPopup(
                $"Finished exporting Game Model to {FileIOUtil.sandboxRoot}");
        },
        buttonText = "Export",
        category = ModMaking
    };

    public static readonly ModSettingFolder ModSourcesFolder =
        new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "BTD6 Mods"))
        {
            category = ModMaking,
            description = "The folder where you keep the source codes for Mods",
            customValidation = Directory.Exists,
            onSave = CreateTargetsFile
        };

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
    }

    public static void CreateTargetsFile(string path)
    {
        if (!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                return;
            }
        }

        var targets = Path.Combine(path, "btd6.targets");
        using var fs = new StreamWriter(targets);
        using var stream =
            ModHelper.Main.Assembly.GetManifestResourceStream("BTD_Mod_Helper.btd6.targets");
        using var reader = new StreamReader(stream!);
        var text = reader.ReadToEnd().Replace(
            @"C:\Program Files (x86)\Steam\steamapps\common\BloonsTD6",
            MelonUtils.GameDirectory);
        fs.Write(text);
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

    public static readonly ModSettingCategory AutoSaveCategory = "Auto Save Settings";

    public static readonly ModSettingButton OpenBackupDir = new(AutoSave.OpenBackupDir)
    {
        displayName = "Open Backup Directory",
        buttonText = "Open",
        category = AutoSaveCategory
    };

    public static readonly ModSettingButton OpenSaveDir = new(AutoSave.OpenAutoSaveDir)
    {
        displayName = "Open Save Directory",
        buttonText = "Open",
        category = AutoSaveCategory
    };

    public static readonly ModSettingFolder AutosavePath =
        new(Path.Combine(ModHelper.ModHelperDirectory, "Mod Settings"))
        {
            displayName = "Backup Directory",
            onSave = AutoSave.SetAutosaveDirectory,
            category = AutoSaveCategory
        };

    public static readonly ModSettingInt TimeBetweenBackup = new(30)
    {
        displayName = "Minutes Between Each Backup",
        category = AutoSaveCategory
    };

    public static readonly ModSettingInt MaxSavedBackups = new(10)
    {
        displayName = "Max Saved Backups",
        onSave = max => AutoSave.backup.SetMaxBackups(max),
        category = AutoSaveCategory
    };

    public override void OnMatchEnd() => AutoSave.backup.CreateBackup();

    #endregion

    #region Debug

    private static readonly ModSettingCategory Debug = new("Debug");
    
    private static readonly ModSettingFile VanillaSpritesClass = new("")
    {
        category = Debug,
        description = "Location of the VanillaSprites.cs to generate to"
    };

    private static readonly ModSettingFolder AssetStudioDump = new("")
    {
        category = Debug,
        description = "Folder where Asset Studio has dumped all the Sprite information"
    };

    private static readonly ModSettingButton GenerateVanillaSprites = new(() =>
    {
        if (!string.IsNullOrEmpty(VanillaSpritesClass) && !string.IsNullOrEmpty(AssetStudioDump))
        {
            VanillaSpriteGenerator.GenerateVanillaSprites(VanillaSpritesClass, AssetStudioDump);
        }
    })
    {
        category = Debug,
        description = "Generates the VanillaSprites.cs file based on the previous two settings"
    };

    #endregion
}