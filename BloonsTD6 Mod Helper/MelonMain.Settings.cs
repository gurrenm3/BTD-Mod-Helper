using System;
using System.Diagnostics;
using System.IO;
using Assets.Scripts.Unity.UI_New.Popups;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.ModOptions;

namespace BTD_Mod_Helper;

internal partial class MelonMain
{
    private static readonly ModSettingCategory General = new("General")
    {
        collapsed = false
    };

    public static readonly ModSettingBool ShowRoundsetChanger = new(true)
    {
        description =
            "Toggles showing the the UI at the bottom right of the map select screen that lets you override which RoundSet to use for the mode you're playing.",
        category = General
    };

    public static readonly ModSettingBool BypassSavingRestrictions = new(true)
    {
        description =
            "With BTD6 v30.0, Ninja Kiwi made it so that progress can not be saved on your profile if it detects that you have mods, or even just MelonLoader, installed. " +
            "We think that they have gone too far with this change, and that it is not consistent with their stated goal in the patch notes of trying 'not to detract from modding'. " +
            "So, this setting overrides that restriction and will allow progress to be saved once more.",
        category = General
    };

    private static readonly ModSettingBool AutoHideModdedClientPopup = new(false)
    {
        category = General,
        description = "Removes the popup telling you that you're using a modded client. Like, we get it already."
    };

    public static readonly ModSettingBool CleanProfile = new(true)
    {
        description =
            "Automatically removes modded information from your profile before the data gets synced to the " +
            "Ninja Kiwi servers. NOTE: This is for very specific information relating to custom content implemented " +
            "using the Mod Helper. This does not broadly prevent hacker pooling or mods messing up your profile in other ways.",
        category = General
    };

    public static readonly ModSettingBool UseOldLoading = new(false)
    {
        description =
            "Switches back to the old system of loading all mod content all at once as soon as the Title Screen is reached " +
            "(causing the game to hang until finished), instead of the new method of adding new load tasks alongside the vanilla ones. " +
            "Depending on the mods use this could be slightly faster, but less robust.",
        category = General,
        requiresRestart = true
    };

    private static readonly ModSettingCategory ModBrowserSettings = "Mod Browser Settings";

    public static readonly ModSettingBool ShowUnverifiedModBrowserContent = new(false)
    {
        description =
            "Toggle whether to allow showing content from GitHub users that have not been manually verified with one of the major BTD6 modding discord servers. " +
            "Unverified content will still be moderated and egregious content removed, but it is still more of a risk than verified content.",
        category = ModBrowserSettings
    };

    public static readonly ModSettingDouble RequestTimeout = new(10)
    {
        displayName = "Request Timeout (s)",
        category = ModBrowserSettings,
        description =
            "The number of seconds that the internal HTTP client should wait for responses to its requests. " +
            "Increasing this value will make the browser slower to load all mods on average, " +
            "but increases the consistency of finding 100% of valid mods if you have slower internet.",
        slider = true,
        min = 1,
        max = 100,
        stepSize = .1f
    };

    public static readonly ModSettingDouble NormalRequestLimit = new(.5)
    {
        displayName = "Icon Size Limit (mb)",
        category = ModBrowserSettings,
        description = "The maximum number of megabytes that a non-mod http request can return, such as icons for mods.",
        min = .1,
        max = 50,
        stepSize = .1f
    };

    public static readonly ModSettingDouble ModRequestLimit = new(50)
    {
        displayName = "Mod Size Limit (mb)",
        category = ModBrowserSettings,
        description = "The maximum number of megabytes that a Mod can be to try to download it.",
        min = 1,
        max = 1000,
        stepSize = 1
    };

    private static readonly ModSettingCategory ModMaking = "Mod Making";

    public static readonly ModSettingString GitHubUsername = new("")
    {
        displayName = "GitHub Username",
        description = "Set this to your GitHub username to see messages in the log for " +
                      "HTTP / GitHub api errors about your mods as they get loaded to the Mod Browser",
        category = ModMaking
    };

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
            PopupScreen.instance.SafelyQueue(screen =>
                screen.ShowOkPopup($"Finished exporting Game Model to {FileIOUtil.sandboxRoot}"));
        },
        buttonText = "Export",
        category = ModMaking
    };

    public static readonly ModSettingFolder ModSourcesFolder =
        new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "BTD6 Mod Sources"))
        {
            category = ModMaking,
            description = "The folder where you keep the source codes for Mods",
            customValidation = Directory.Exists,
            onSave = ModHelperFiles.CreateTargetsFile
        };

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
        description = "Generates the VanillaSprites.cs file based on the previous two settings",
        buttonText = "Generate"
    };

    #endregion
}