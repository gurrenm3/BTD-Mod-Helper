using System;
using System.Diagnostics;
using System.IO;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using UnityEngine;
using UnityEngine.UI;
using static BTD_Mod_Helper.Api.Enums.VanillaSprites;
using Blue = BTD_Mod_Helper.Api.UI.WindowColors.Blue;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper;

internal partial class MelonMain
{
    private static readonly ModSettingCategory General = new("General")
    {
        collapsed = false,
        icon = SettingsIcon
    };

    public static readonly ModSettingBool AutoUpdate = new(true)
    {
        category = General,
        icon = ModHelperSprites.DownloadBtn,
        description = "Installs a plugin that will keep Mod Helper and other mods up to date on startup",
        onSave = enabled =>
        {
            if (enabled)
            {
                UpdaterPlugin.Enable();
            }
            else
            {
                UpdaterPlugin.Disable();
            }
        }
    };

    public static readonly ModSettingBool ShowRoundsetChanger = new(true)
    {
        displayName = "Show Round Set Changer",
        description =
            "Toggles showing the the UI at the bottom right of the map select screen that lets you override which RoundSet to use for the mode you're playing.",
        category = General,
        icon = AlternateBloonsBtn
    };

    /*internal static readonly ModSettingBool AutoHideModdedClientPopup = new(false)
    {
        category = General,
        description = "Removes the popup telling you that you're using a modded client. Like, we get it already.",
        icon = HideIcon
    };*/

    public static readonly ModSettingBool CleanProfile = new(true)
    {
        description =
            "Automatically removes modded information from your profile before the data gets synced to the " +
            "Ninja Kiwi servers. NOTE: This is for very specific information relating to custom content implemented " +
            "using the Mod Helper. This does not broadly prevent hacker pooling or mods messing up your profile in other ways.",
        category = General,
        icon = CleansingFoamUpgradeIcon
    };

    /*public static readonly ModSettingBool UseOldLoading = new(false)
    {
        description =
            "Switches back to the old system of loading all mod content all at once as soon as the Title Screen is reached " +
            "(causing the game to hang until finished), instead of the new method of adding new load tasks alongside the vanilla ones. " +
            "Depending on the mods use this could be slightly faster, but less robust.",
        category = General,
        requiresRestart = true,
        icon = RetroTechbotIcon
    };*/

    public static readonly ModSettingBool EnableModHelperLocalization = new(true)
    {
        description = """
                      Enable or disable Mod Helper's own localization for its text into non-English languages.
                      """,
        category = General,
        requiresRestart = true,
        icon = LangUniversalIcon
    };

    public static ModWindowColor CurrentDefaultWindowColor => DefaultWindowColor.value;
    public static readonly ModSettingString DefaultWindowColor = new(nameof(Blue))
    {
        description = "Sets the default window color for in game windows added by mods. Also affects the start menu color.",
        category = General,
        icon = MainBGPanelBlue,
        modifyInput = field =>
        {
            field.RemoveComponent<Mask>();
            field.LayoutElement.minWidth = field.LayoutElement.preferredWidth = 500;

            var inputField = field.InputField;
            inputField.readOnly = true;
            inputField.selectionColor = new Color(0, 0, 0, 0);
            inputField.caretColor = new Color(0, 0, 0, 0);


            var icon = field.GetComponentInParent<ModHelperOption>().Icon;
            icon.Image.type = Image.Type.Sliced;
            icon.Image.pixelsPerUnitMultiplier = .5f;
            CurrentDefaultWindowColor.Apply(icon, ModWindowColor.PanelType.Main);

            var menu = ModHelperWindow.CreateColorsMenu(color =>
            {
                inputField.SetText(color.Name);

                foreach (var setter in Object.FindObjectsOfType<WindowColorSetter>(true))
                {
                    if (setter.window is null)
                    {
                        setter.SetColor(color);
                    }
                }
            }, color => CurrentDefaultWindowColor == color);
            CurrentDefaultWindowColor.Apply(menu, ModWindowColor.PanelType.Main);
            menu.initialInfo = menu.initialInfo with
            {
                X = -1000
            };
            menu.SetParent(field);
            menu.parentComponent = field;

            inputField.onSelect.AddListener(new Action<string>(_ => menu.Show()));
        }
    };

    public static readonly ModSettingEnum<ModHelperDock.Visibility> DockVisibility = new(ModHelperDock.Visibility.Default)
    {
        description = """
                      Visibility of the in game dock / start menu in the bottom left corner: 
                      Default: Shown if any mods have added start menu entries
                      Hovered: Like default, but also only if mouse is hovered over button / dock
                      Never: Never show
                      """,
        category = General,
        icon = ModHelperSprites.IconMinimal
    };

    private static readonly ModSettingCategory ModBrowserSettings = new("Mod Browser Settings")
    {
        icon = BenjaminIcon
    };

    public static readonly ModSettingBool HideBrokenMods = new(true)
    {
        description = "Hides mods from the Mod Browser that are almost certainly broken from being too out of date. " +
                      "This is currently just based on having a 'WorksOnVersion' value in its ModHelperData >= 34",
        category = ModBrowserSettings,
        icon = CloseBtn
    };

    public static readonly ModSettingBool ShowUnverifiedModBrowserContent = new(false)
    {
        description =
            "Toggle whether to allow showing content from GitHub users that have not been manually verified with one of the major BTD6 modding discord servers. " +
            "Unverified content will still be moderated and egregious content removed, but it is still more of a risk than verified content.",
        category = ModBrowserSettings,
        icon = DangerSoonIcon
    };

    public static readonly ModSettingBool PopulateOnStartup = new(false)
    {
        description = "Whether to begin fetching all mod info from GitHub in the background as the game starts, " +
                      "rather than just your local mods until you open the browser for the first time. " +
                      "Disabling this leads to 1-2 seconds faster startup time, " +
                      "but a 5s - 10s delay when first opening the browser",
        category = ModBrowserSettings,
        icon = AutoStartIcon,
        requiresRestart = true
    };

    public static readonly ModSettingInt ModsPerPage = new(15)
    {
        description =
            "How many mods to display in each page of the Mod Browser. Lower amounts would marginally improve performance.",
        category = ModBrowserSettings,
        min = 5,
        max = 100,
        icon = TrophyGameUiIcon
    };

    public static readonly ModSettingDouble RequestTimeout = new(30)
    {
        displayName = "Request Timeout (s)",
        category = ModBrowserSettings,
        description =
            "The number of seconds that the internal HTTP client should wait for responses to its requests. " +
            "Increasing this value will make the browser slower to load all mods on average, " +
            "but increases the consistency of finding 100% of valid mods if you have slower internet.",
        min = 5,
        max = 300,
        stepSize = 1,
        requiresRestart = ModHelper.IsNet6,
        icon = DartTimeIcon
    };

    public static readonly ModSettingBool ReUseLocalIcons = new(true)
    {
        displayName = "Re-Use Local Icons",
        category = ModBrowserSettings,
        description =
            "Set to true to avoid redownloading icons for Mod Browser mods that you already have installed on your machine. " +
            "Faster loading, with the caveat that if the icon was changed in an update it wouldn't appear until after you updated.",
        icon = RespecBtn
    };

    public static readonly ModSettingDouble NormalRequestLimit = new(.5)
    {
        displayName = "Icon Size Limit (mb)",
        category = ModBrowserSettings,
        description = "The maximum number of megabytes that a non-mod http request can return, such as icons for mods.",
        min = .1,
        max = 50,
        stepSize = .1f,
        requiresRestart = ModHelper.IsNet6,
        icon = LocalNetworkIcon
    };

    public static readonly ModSettingDouble ModRequestLimitMb = new(75)
    {
        displayName = "Mod Size Limit (mb)",
        category = ModBrowserSettings,
        description = "The maximum number of megabytes that a Mod can be to try to download it.",
        min = 1,
        max = 1000,
        stepSize = 1,
        requiresRestart = ModHelper.IsNet6,
        icon = LocalNetworkIcon
    };

    public static readonly ModSettingBool ProxyGitHubContent = new(false)
    {
        displayName = "Proxy GitHub Content",
        description =
            "Some people have issues using the Mod Browser ingame from the real raw.githubusercontent URLs." +
            " Enabling this setting switches those to use the proxy URL specified below instead",
        category = ModBrowserSettings,
    };

    public static readonly ModSettingString ProxyGitHubContentURL = new("https://rawgithubusercontent.deno.dev")
    {
        displayName = "Proxy GitHub Content URL",
        description =
            "If the above setting is enabled, then this proxy URL will be used as the base for raw.githubusercontent requests instead.",
        category = ModBrowserSettings,
        customValidation = s => s.StartsWith("https://")
    };

    private static readonly ModSettingCategory ModMaking = new("Mod Making")
    {
        icon = EditChallengeIcon
    };

    public static readonly ModSettingString GitHubUsername = new("")
    {
        displayName = "GitHub Username",
        description = "Set this to your GitHub username to see messages in the log for " +
                      "HTTP / GitHub api errors about your mods as they get loaded to the Mod Browser",
        category = ModMaking,
        icon = NamedMonkeyIcon
    };

    public static readonly ModSettingHotkey OpenConsole = new(KeyCode.F8)
    {
        displayName = "Open Console",
        description = "Hotkey that opens a command console where specific mod actions can be triggered.",
        category = ModMaking,
    };

    public static readonly ModSettingBool ShiftShiftOpensConsole = new(false)
    {
        description = "Makes it so that pressing Shift twice in a row also opens the console",
        category = ModMaking
    };

    private static readonly ModSettingButton OpenLocalDirectory = new()
    {
        displayName = "Open Local Files Directory",
        action = () => Process.Start(new ProcessStartInfo
        {
            FileName = FileIOHelper.sandboxRoot,
            UseShellExecute = true,
            Verb = "open"
        }),
        buttonText = "Open",
        description =
            "This is the 'Sandbox Root' directory that many vanilla and modded services use to dump files into.",
        category = ModMaking
    };

    private static readonly ModSettingButton ExportGameModel = new()
    {
        displayName = "Export Game Data",
        description =
            "Exports much of the game's data to json files that you can view. Helpful for understanding how " +
            "vanilla content was implemented by Ninja Kiwi.",
        action = () =>
        {
            GameModelExporter.ExportAll();
            PopupScreen.instance.SafelyQueue(screen =>
                screen.ShowOkPopup($"Finished exporting Game Model to {FileIOHelper.sandboxRoot}"));
        },
        buttonText = "Export",
        category = ModMaking,
        icon = ShareIosIcon
    };

    public static readonly ModSettingFolder ModSourcesFolder =
        new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BTD6 Mod Sources"))
        {
            category = ModMaking,
            description = "The folder where you keep the source codes for Mods",
            customValidation = Directory.Exists,
            onSave = ModHelperFiles.CreateTargetsFile
        };

    public static readonly ModSettingHotkey QuickEditTowerModel = new(KeyCode.Backslash, HotkeyModifier.Shift)
    {
        category = ModMaking,
        description =
            "If in sandbox mode, opens a text editor window where you can make quick edits to the selected tower's root model."
    };

    public static readonly ModSettingHotkey QuickEditMutatedModel = new(KeyCode.Backslash, HotkeyModifier.Ctrl)
    {
        category = ModMaking,
        description =
            "If in sandbox mode, opens a text editor window where you can make quick edits to the selected tower's root model."
    };

    public static readonly ModSettingString QuickEditProgram = new("")
    {
        category = ModMaking,
        description = "Choose a different program/command to edit the file with other than the default notepad.\n" +
                      "If you have VSCode installed,\na good option is \"code -w -n\".\n" +
                      "If you have JetBrains Rider, you can put its bin folder in your Path environment variable and do \"rider64 --wait\"."
    };

    internal static readonly ModSettingFolder ModHelperSourceFolder = new("")
    {
        category = ModMaking,
        description = "Location of Mod Helper Source code for development purposes"
    };
}