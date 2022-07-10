using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using TMPro;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.UI.Menus;

/// <summary>
/// The ModGameMenu for the screen showing current mods
/// </summary>
public class ModsMenu : ModGameMenu<ExtraSettingsScreen>
{
    #region Constants

    internal const int Padding = 50;

    internal const int MenuWidth = 3600;
    internal const int MenuHeight = 1900;

    internal const int LeftMenuWidth = 1750;
    internal const int RightMenuWidth = 1750;

    internal const int ModNameWidth = 1000;

    internal const int ModIconSize = 250;
    internal const int ModPanelHeight = 200;
    internal const int ModNameHeight = 150;
    internal const int OtherHeight = 100;

    internal const int FontSmall = 52;
    internal const int FontMedium = 69;
    internal const int FontLarge = 80;

    internal const string DefaultDescription = "No description given";

    #endregion

    private static Dictionary<ModHelperData, ModsMenuMod> modPanels = new();

    private static ModHelperScrollPanel modsList;
    private static ModHelperPanel selectedModPanel;
    private static ModHelperText selectedModName;
    private static ModHelperText selectedModAuthor;
    private static ModHelperText selectedModVersion;
    private static ModHelperText selectedModDescription;
    private static ModHelperButton selectedModUpdateButton;
    private static ModHelperButton selectedModSettingsButton;
    private static ModHelperButton selectedModDisableButton;
    private static ModHelperButton selectedModEnableButton;
    private static ModHelperButton selectedModHomeButton;
    private static ModHelperButton updateAllButton;
    private static ModHelperImage selectedModIcon;
    private static ModsMenuMod modTemplate;
    private static int currentSort;
    private static ModHelperPanel restartButton;

    private static Animator bottomGroupAnimator;

    private static bool loadedAllMods;

    private static ModHelperData selectedMod;

    private static readonly string[] SortOptions =
    {
        "All Mods",
        "Active Mods",
        "Inactive Mods",
        "Mods Needing Updates"
    };

    /// <inheritdoc />
    public override bool OnMenuOpened(Object data)
    {
        loadedAllMods = false;
        CommonForegroundHeader.SetText("Mods");

        var panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
        var panel = panelTransform.gameObject;
        panel.DestroyAllChildren();

        var modsMenu = panel.AddModHelperPanel(new Info("ModsMenu", MenuWidth, MenuHeight));

        CreateLeftMenu(modsMenu);
        CreateRightMenu(modsMenu);
        CreateExtraButtons(GameMenu);

        selectedMod ??= ModHelper.Main.GetModHelperData();

        SetSelectedMod(selectedMod!);
        Refresh();

        return false;
    }

    private static void CreateExtraButtons(ExtraSettingsScreen gameMenu)
    {
        var bottomButtonGroup = gameMenu.gameObject.AddModHelperPanel(new Info("BottomButtonGroup")
        {
            Height = 400,
            AnchorMin = Vector2.zero,
            AnchorMax = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 0)
        });
        bottomGroupAnimator = bottomButtonGroup.AddComponent<Animator>();
        bottomGroupAnimator.runtimeAnimatorController = Animations.PopupAnim;
        bottomGroupAnimator.speed = .55f;
        bottomGroupAnimator.Play("PopupSlideIn");

        var modBrowserButton = bottomButtonGroup.AddButton(new Info("ModBrowserButton", -225, 50, 400)
        {
            Anchor = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 0)
        }, VanillaSprites.WoodenRoundButton, new Action(() => Open<ModBrowserMenu>()));
        modBrowserButton.AddImage(new Info("ComputerMonkey", Info.Preset.FillParent), VanillaSprites.BenjaminIcon);
        modBrowserButton.AddText(new Info("Text", 0, -200, 500, 100), "Browse Mods", 60f);

        var createModButton = bottomButtonGroup.AddButton(new Info("CreateModButton", 225, 50, 400)
        {
            Anchor = Vector2.zero,
            Pivot = new Vector2(0.5f, 0)
        }, VanillaSprites.EditChallengeIcon, new Action(() =>
        {
            PopupScreen.instance.ShowSetNamePopup("Create/Upgrade Mod",
                "Name of mod to create/upgrade. \n Example: 'TitleCaseButWithoutSpaces'", new Action<string>(s =>
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        TemplateMod.CreateModButtonClicked(s);
                    }
                }), null);
            PopupScreen.instance.ModifyField(tmpInputField =>
            {
                tmpInputField.textComponent.font = Fonts.Btd6FontBody;
                tmpInputField.characterLimit = 50;
                tmpInputField.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
            });
        }));

        createModButton.AddText(new Info("Text", 0, -200, 500, 100), "Create Mod", 60f);


        restartButton = gameMenu.gameObject.AddModHelperPanel(new Info("RestartPanel", -50, -50, 350)
        {
            Pivot = Vector2.one,
            Anchor = Vector2.one
        });

        restartButton.AddButton(new Info("Restart", Info.Preset.FillParent), VanillaSprites.RestartBtn,
            new Action(() =>
            {
                PopupScreen.instance.ShowPopup(PopupScreen.Placement.menuCenter, "Restart Required",
                    "Changes you've made will require restarting the game to take effect. " +
                    "Would you like to do that now?", new Action(ProcessHelper.RestartGame),
                    "Yes", null, "No", Popup.TransitionAnim.Scale);
            }));
        restartButton.AddText(new Info("Text", 0, -200, 500, 100), "Restart", FontMedium);
    }

    /// <inheritdoc />
    public override void OnMenuUpdate()
    {
        if (loadedAllMods)
        {
            return;
        }

        var (data, _) = modPanels.FirstOrDefault(pair => pair.Value == null);
        if (data != null)
        {
            try
            {
                var panel = modTemplate.Duplicate(data.Name);
                panel.SetMod(data, data.Mod);
                modPanels[data] = panel;
            }
            catch (Exception)
            {
                loadedAllMods = true;
                throw;
            }
        }
        else
        {
            Refresh();
            loadedAllMods = true;
        }
    }

    /// <inheritdoc />
    public override void OnMenuClosed()
    {
        bottomGroupAnimator.Play("PopupSlideOut");

        modPanels.Clear();
    }

    internal static void SetSelectedMod(ModHelperData modSelected)
    {
        selectedMod = modSelected;

        selectedModName.Text.SetText(modSelected.Name);
        selectedModAuthor.Text.SetText(modSelected.Author ?? modSelected.RepoOwner);
        selectedModVersion.Text.SetText("v" + modSelected.Version);
        selectedModDescription.Text.SetText(modSelected.Description ?? DefaultDescription);

        selectedModAuthor.Text.SetFaceColor(BlatantFavoritism.GetColor(modSelected.RepoOwner));

        selectedModUpdateButton.gameObject.SetActive(modSelected.UpdateAvailable);

        selectedModSettingsButton.gameObject.SetActive(modSelected.Mod is BloonsMod bloonsMod &&
                                                       bloonsMod.ModSettings.Any());

        if (!modSelected.HasNoIcon && modSelected.GetIcon() is Sprite sprite)
        {
            selectedModIcon.gameObject.SetActive(true);
            selectedModIcon.Image.SetSprite(sprite);
        }
        else
        {
            selectedModIcon.gameObject.SetActive(false);
        }

        selectedModDisableButton.SetActive(modSelected.Enabled);
        selectedModEnableButton.SetActive(!modSelected.Enabled);

        selectedModHomeButton.SetActive(selectedMod.ReadmeUrl != null);
    }

    private static void SortMods(int selectedIndex)
    {
        currentSort = selectedIndex;
        foreach (var (modHelperData, modPanel) in modPanels)
        {
            if (modPanel != null)
            {
                switch (selectedIndex)
                {
                    default:
                        modPanel.gameObject.SetActive(true);
                        break;
                    case 1:
                        modPanel.gameObject.SetActive(ModHelperData.Active.Contains(modHelperData));
                        break;
                    case 2:
                        modPanel.gameObject.SetActive(ModHelperData.Inactive.Contains(modHelperData));
                        break;
                    case 3:
                        modPanel.gameObject.SetActive(modHelperData.UpdateAvailable);
                        break;
                }
            }
        }

        Refresh();
    }

    private static void CreateLeftMenu(ModHelperPanel modsMenu)
    {
        var leftMenu = modsMenu.AddPanel(
            new Info("LeftMenu", (MenuWidth - LeftMenuWidth) / -2f, 0, LeftMenuWidth, MenuHeight),
            VanillaSprites.MainBGPanelBlue, RectTransform.Axis.Vertical, Padding, Padding
        );

        var topRow = leftMenu.AddPanel(new Info("TopRow")
        {
            Height = ModNameHeight,
            FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, Padding);

        topRow.AddDropdown(new Info("ModFilter", 800f, ModNameHeight), SortOptions.ToIl2CppList(), ModNameHeight * 4,
            new Action<int>(SortMods), VanillaSprites.BlueInsertPanelRound, FontSmall
        );

        topRow.AddPanel(new Info("Filler", Info.Preset.Flex));

        // ReSharper disable once AsyncVoidLambda
        updateAllButton = topRow.AddButton(
            new Info("UpdateAll", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.GreenBtnLong, new Action(async () =>
            {
                foreach (var modHelperData in modPanels.Select(pair => pair.Key)
                             .Where(data => data.UpdateAvailable))
                {
                    await ModHelperGithub.DownloadLatest(modHelperData, true, _ => Refresh());
                }
            })
        );

        updateAllButton.AddText(new Info("UpdateAllText", Info.Preset.FillParent), "Update All", FontSmall);

        modsList = leftMenu.AddScrollPanel(new Info("ModListScroll", Info.Preset.Flex), RectTransform.Axis.Vertical,
            VanillaSprites.BlueInsertPanelRound, Padding, Padding);

        modPanels = new Dictionary<ModHelperData, ModsMenuMod>();
        modTemplate = ModsMenuMod.CreateTemplate();
        modsList.AddScrollContent(modTemplate);
        foreach (var modHelperData in ModHelperData.All)
        {
            modPanels[modHelperData] = null;
        }
    }

    private static void Refresh()
    {
        foreach (var (modHelperData, panel) in modPanels)
        {
            if (panel is null)
            {
                continue;
            }

            panel.Refresh(modHelperData);
        }

        if (updateAllButton is not null)
        {
            updateAllButton.gameObject.SetActive(modPanels.Any(pair =>
                pair.Key.UpdateAvailable && pair.Value is not null && pair.Value.gameObject.active));
        }

        restartButton.SetActive(
            ModHelperData.All.Any(data => data.RestartRequired) ||
            ModHelper.Mods.Any(bloonsMod =>
                bloonsMod.ModSettings.Values.Any(setting => setting.needsRestartRightNow)
            )
        );

        SetSelectedMod(selectedMod!);
    }

    private static void CreateRightMenu(ModHelperPanel modsMenu)
    {
        selectedModPanel = modsMenu.AddPanel(
            new Info("ModInfo", (MenuWidth - RightMenuWidth) / 2f, 0, RightMenuWidth, MenuHeight),
            VanillaSprites.MainBGPanelBlue, RectTransform.Axis.Vertical, Padding, Padding
        );

        var firstRow = selectedModPanel.AddPanel(new Info("FirstRow")
        {
            Height = ModNameHeight, FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, Padding);

        var modTitlePanel = firstRow.AddPanel(new Info("ModTitlePanel")
        {
            Flex = 1
        }, VanillaSprites.BlueInsertPanelRound);

        selectedModName = modTitlePanel.AddText(new Info("ModTitle", Info.Preset.FillParent)
        {
            Width = Padding * -2
        }, "Test Long Mod Name", FontLarge, TextAlignmentOptions.Left);


        selectedModHomeButton = firstRow.AddButton(new Info("HomePage")
        {
            Size = ModNameHeight
        }, VanillaSprites.HomeBtn, new Action(() => ProcessHelper.OpenURL(selectedMod.ReadmeUrl!)));

        // ReSharper disable once AsyncVoidLambda
        selectedModUpdateButton = firstRow.AddButton(
            new Info("UpdateButton", size: ModNameHeight), VanillaSprites.GreenBtn, new Action(async () =>
                await ModHelperGithub.DownloadLatest(selectedMod, false, _ => Refresh()))
        );
        /*selectedModUpdateButton.AddText(
            new Info("Text", anchorMin: Vector2.zero, anchorMax: Vector2.one), "Update", FontMedium
        );*/
        selectedModUpdateButton.AddImage(
            new Info("UpgradeIcon", size: ModNameHeight - Padding), VanillaSprites.UpgradeIcon2
        );

        var secondRow = selectedModPanel.AddPanel(new Info("SecondRow")
        {
            Height = OtherHeight, FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, Padding);

        var modAuthorPanel = secondRow.AddPanel(new Info("ModAuthorPanel")
        {
            FlexWidth = 4, FlexHeight = 1
        }, VanillaSprites.BlueInsertPanelRound);

        selectedModAuthor = modAuthorPanel.AddText(new Info("Author", Info.Preset.FillParent)
        {
            Width = Padding * -2
        }, "Author", FontSmall, TextAlignmentOptions.Left);

        var modVersionPanel = secondRow.AddPanel(new Info("ModVersionPanel", Info.Preset.Flex),
            VanillaSprites.BlueInsertPanelRound);
        selectedModVersion = modVersionPanel.AddText(new Info("Version")
        {
            Width = Padding * -2
        }, "Version", FontSmall);


        var descriptionPanel = selectedModPanel.AddScrollPanel(new Info("DescriptionPanel", Info.Preset.Flex),
            RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanelRound, Padding, Padding);

        selectedModDescription = ModHelperText.Create(new Info("DescriptionText")
        {
            Width = RightMenuWidth - Padding * 4
        }, DefaultDescription, FontSmall, TextAlignmentOptions.TopLeft);
        descriptionPanel.AddScrollContent(selectedModDescription);
        selectedModDescription.LayoutElement.preferredHeight = -1;
        selectedModDescription.Text.enableAutoSizing = true;
        selectedModDescription.Text.lineSpacing = Padding / 2f;
        selectedModDescription.Text.font = Fonts.Btd6FontBody;

        var buttonsRow = selectedModPanel.AddPanel(new Info("ButtonRow")
        {
            Height = ModPanelHeight,
            FlexWidth = 1
        });

        selectedModIcon = buttonsRow.AddImage(
            new Info("ModIcon", ModIconSize / 2f, 0, ModIconSize, ModIconSize, new Vector2(0, 0.5f)),
            GetSprite<MelonMain>("Icon"));

        selectedModDisableButton = buttonsRow.AddButton(
            new Info("DisableButton", ModPanelHeight * ModHelperButton.LongBtnRatio, ModPanelHeight),
            VanillaSprites.RedBtnLong, new Action(() => { }));

        selectedModDisableButton.AddText(new Info("ButtonText", Info.Preset.FillParent), "Disable", FontLarge);
        selectedModDisableButton.Button.SetOnClick(() =>
        {
            selectedMod.MoveToDisabledModsFolder();
            SetSelectedMod(selectedMod);
            SortMods(currentSort);
            MenuManager.instance.buttonClickSound.Play("ClickSounds");
        });

        selectedModEnableButton = buttonsRow.AddButton(
            new Info("EnabledButton", height: ModPanelHeight, width: ModPanelHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.GreenBtnLong, new Action(() => { })
        );
        selectedModEnableButton.AddText(new Info("ButtonText", Info.Preset.FillParent), "Enable", FontLarge);
        selectedModEnableButton.Button.SetOnClick(() =>
        {
            selectedMod.MoveToEnabledModsFolder();
            SetSelectedMod(selectedMod);
            SortMods(currentSort);
            MenuManager.instance.buttonClickSound.Play("ClickSounds");
        });

        selectedModSettingsButton = buttonsRow.AddButton(
            new Info("SettingsButton", ModPanelHeight / -2f, 0, ModPanelHeight, ModPanelHeight, new Vector2(1, 0.5f)),
            VanillaSprites.BlueBtn, new Action(() => ModSettingsMenu.Open(selectedMod.Mod as BloonsMod)));
        selectedModSettingsButton.AddImage(
            new Info("Gear", width: ModNameHeight, height: ModNameHeight), VanillaSprites.SettingsIcon
        );
    }
}