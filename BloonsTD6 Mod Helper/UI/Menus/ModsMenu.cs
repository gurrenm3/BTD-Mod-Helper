﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.UI.BTD6;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppFacepunch.Steamworks;
using Il2CppTMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;
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
    private static ModHelperButton selectedModDeleteButton;
    private static ModHelperButton selectedModHomeButton;
    private static ModHelperButton updateAllButton;
    private static ModHelperImage selectedModIcon;
    private static ModHelperImage selectedModLoadingSpinner;
    private static ModsMenuMod modTemplate;
    private static int currentSort;
    private static ModHelperPanel restartPanel;
    private static Task updateTask;
    private static ModHelperScrollPanel topRow;

    private static Animator bottomGroupAnimator;


    internal static ModHelperData selectedMod;

    private static readonly string[] SortOptions =
    {
        "All",
        "Active",
        "Inactive",
        "Updates"
    };

    private static bool RestartRequired => ModHelperData.All.Any(data => data.RestartRequired) ||
                                           ModHelper.Mods.Any(bloonsMod =>
                                               bloonsMod.ModSettings.Values.Any(setting => setting.needsRestartRightNow)
                                           );

    /// <inheritdoc />
    public override bool OnMenuOpened(Object data)
    {
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

        MelonCoroutines.Start(CreateModPanels());

        return false;
    }

    private IEnumerator CreateModPanels()
    {
        updateAllButton.gameObject.SetActive(modPanels.Keys.Any(data => data.UpdateAvailable));
        if (RestartRequired)
        {
            restartPanel.SetActive(true);
            restartPanel.GetComponent<Animator>().Play("PopupScaleIn");
        }

        yield return null;

        if (Closing) yield break;

        var keys = modPanels.Keys.ToList();
        for (var index = 0; index < keys.Count; index++)
        {
            var data = keys[index];
            var panel = modPanels[data] = modTemplate.Duplicate(data.Name);
            if (index > 6) yield return null;

            if (Closing) yield break;

            panel.SetMod(data, data.Mod);
            if (index > 6) yield return null;

            if (Closing) yield break;
        }

        Refresh();
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

        var modBrowserButton = bottomButtonGroup.AddButton(new Info("ModBrowserButton", -225, Padding, 400)
        {
            Anchor = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 0)
        }, VanillaSprites.WoodenRoundButton, new Action(() => Open<ModBrowserMenu>()));
        modBrowserButton.AddImage(new Info("ComputerMonkey", InfoPreset.FillParent), VanillaSprites.BenjaminIcon);
        modBrowserButton.AddText(new Info("Text", 0, -200, 500, 100), "Browse Mods", 60f);

        var createModButton = bottomButtonGroup.AddButton(new Info("CreateModButton", 225, Padding, 400)
        {
            Anchor = Vector2.zero,
            Pivot = new Vector2(0.5f, 0)
        }, VanillaSprites.EditChallengeIcon, new Action(() =>
        {
            PopupScreen.instance.SafelyQueue(screen => screen.ShowSetNamePopup("Create/Upgrade Mod",
                "Name of mod to create/upgrade. \n Example: 'TitleCaseButWithoutSpaces'", new Action<string>(s =>
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        TemplateMod.CreateModButtonClicked(s);
                    }
                }), null));
            PopupScreen.instance.SafelyQueue(screen => screen.ModifyField(tmpInputField =>
            {
                tmpInputField.textComponent.font = Fonts.Btd6FontBody;
                tmpInputField.characterLimit = 50;
                tmpInputField.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
            }));
        }));

        createModButton.AddText(new Info("Text", 0, -200, 500, 100), "Create Mod", 60f);


        restartPanel = gameMenu.gameObject.AddModHelperPanel(new Info("RestartPanel", -50, -50, 350)
        {
            Pivot = Vector2.one,
            Anchor = Vector2.one
        });
        var animator = restartPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed *= .7f;
        restartPanel.SetActive(false);

        restartPanel.AddButton(new Info("Restart", InfoPreset.FillParent), VanillaSprites.RestartBtn,
            new Action(() =>
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
                    "Restart Required",
                    "Changes you've made will require restarting the game to take effect. " +
                    "Would you like to do that now?", new Action(ProcessHelper.RestartGame),
                    "Yes", null, "No", Popup.TransitionAnim.Scale));
            }));
        restartPanel.AddText(new Info("Text", 0, -200, 500, 100), "Restart", FontMedium);


        if (DateTime.Now is {Month: 4, Day: 1})
        {
            var march32 = bottomButtonGroup.AddButton(new Info("March32ndButton")
            {
                Width = 1000, Height = 250, Y = Padding, Anchor = new Vector2(0.5f, 0), Pivot = new Vector2(0.5f, 0)
            }, VanillaSprites.GreenBtnLong, new Action(() => EmbeddedBrowser.OpenURL(
                "https://www.youtube.com/watch?v=dQw4w9WgXcQ?autoplay=1",
                view => view.Surface.KeyDown(0x0D /* VK_RETURN */, HTMLKeyModifiers.None))
            ));
            march32.AddText(new Info("Text", InfoPreset.FillParent), "Get 100 Trophies", 80f);
            march32.AddImage(new Info("TrophyL", -475, 0, 300), VanillaSprites.TrophyIcon);
            march32.AddImage(new Info("TrophyR", 475, 0, 300), VanillaSprites.TrophyIcon);
        }
    }

    /// <inheritdoc />
    public override void OnMenuClosed()
    {
        bottomGroupAnimator.Play("PopupSlideOut");
        restartPanel.GetComponent<Animator>().Play("PopupScaleOut");

        modPanels.Clear();
    }

    /// <inheritdoc />
    public override void OnMenuUpdate()
    {
        if (selectedModLoadingSpinner != null)
        {
            selectedModLoadingSpinner.transform.Rotate(0, 0, -2);
            selectedModLoadingSpinner.SetActive(updateTask is {IsCompleted: false});
        }
    }

    internal static void SetSelectedMod(ModHelperData modSelected)
    {
        selectedMod = modSelected;

        selectedModName.Text.SetText(modSelected.DisplayName);
        selectedModAuthor.Text.SetText(modSelected.DisplayAuthor);
        selectedModVersion.Text.SetText("v" + modSelected.Version);
        selectedModDescription.Text.SetText(modSelected.DisplayDescription);

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

        selectedModDisableButton.SetActive(modSelected.Enabled && selectedMod.Mod is not MelonMain);
        selectedModEnableButton.SetActive(!modSelected.Enabled && selectedMod.Mod is not MelonMain);
        selectedModDeleteButton.SetActive(!modSelected.Enabled && modSelected.Mod is null);

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

        topRow = leftMenu.AddScrollPanel(new Info("TopRow")
        {
            Height = ModNameHeight,
            FlexWidth = 1
        }, RectTransform.Axis.Horizontal, null, Padding);
        topRow.AddComponent<Image>();
        topRow.Mask.showMaskGraphic = false;
        topRow.Mask.enabled = false;
        topRow.ScrollContent.RectTransform.pivot = new Vector2(0, 0.5f);

        topRow.ScrollContent.AddDropdown(new Info("ModFilter", 500f, ModNameHeight), SortOptions.ToIl2CppList(),
            ModNameHeight * 4,
            new Action<int>(SortMods), VanillaSprites.BlueInsertPanelRound, FontSmall
        );

        // ReSharper disable once AsyncVoidLambda
        updateAllButton = topRow.ScrollContent.AddButton(
            new Info("UpdateAll", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.GreenBtnLong, new Action(() =>
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter,
                    "Confirm Update All Mods?",
                    "This will update all mods to latest versions with no further confirmation.", new Action(
                        async () =>
                        {
                            foreach (var (data, panel) in modPanels
                                         .Where(kvp => kvp.Key.UpdateAvailable))
                            {
                                await ModHelperGithub.DownloadLatest(data, true, null, task => updateTask = task);
                                panel.Refresh(data);
                            }

                            Refresh();
                            PopupScreen.instance.SafelyQueue(popupScreen => popupScreen.ShowOkPopup(
                                "Successfully updated mods, remember to restart to apply changes."));
                        }), "Yes", null, "No", Popup.TransitionAnim.Scale));
            })
        );
        updateAllButton.SetActive(false);
        updateAllButton.AddText(new Info("UpdateAllText", InfoPreset.FillParent), "Update All", FontSmall);

        var disableAll = topRow.ScrollContent.AddButton(
            new Info("DisableAll", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.RedBtnLong, new Action(
                () =>
                {
                    foreach (var modHelperData in ModHelperData.All.Where(data =>
                                 data.Enabled && data.Mod is not MelonMain))
                    {
                        modHelperData.MoveToDisabledModsFolder(true);
                    }
                    SortMods(currentSort);
                    MenuManager.instance.buttonClickSound.Play("ClickSounds");
                }));
        disableAll.AddText(new Info("Text", InfoPreset.FillParent), "Disable All", FontSmall);

        var enableAll = topRow.ScrollContent.AddButton(
            new Info("EnableAll", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.GreenBtnLong, new Action(
                () =>
                {
                    var any = false;
                    foreach (var modHelperData in ModHelperData.All.Where(data =>
                                 !data.Enabled && data.Mod is not MelonMain))
                    {
                        modHelperData.MoveToEnabledModsFolder();
                        any = true;
                    }
                    if (any)
                    {
                        SortMods(currentSort);
                        MenuManager.instance.buttonClickSound.Play("ClickSounds");
                    }
                }));
        enableAll.AddText(new Info("Text", InfoPreset.FillParent), "Enable All", FontSmall);

        topRow.ScrollContent.AddButton(new Info("ResetAll", ModNameHeight), VanillaSprites.RestartBtn,
            new Action(
                () =>
                {
                    foreach (var modHelperData in ModHelperData.All.Where(data => data.Mod is not MelonMain))
                    {
                        switch (modHelperData.Enabled)
                        {
                            case true when modHelperData.Mod is null:
                                modHelperData.MoveToDisabledModsFolder();
                                break;
                            case false when modHelperData.Mod is not null:
                                modHelperData.MoveToEnabledModsFolder();
                                break;
                        }
                    }
                    SortMods(currentSort);
                    MenuManager.instance.buttonClickSound.Play("ClickSounds");
                }));

        modsList = leftMenu.AddScrollPanel(new Info("ModListScroll", InfoPreset.Flex), RectTransform.Axis.Vertical,
            VanillaSprites.BlueInsertPanelRound, Padding, Padding);

        modPanels = new Dictionary<ModHelperData, ModsMenuMod>();
        modTemplate = ModsMenuMod.CreateTemplate();
        modsList.AddScrollContent(modTemplate);
        foreach (var modHelperData in ModHelperData.All)
        {
            modPanels[modHelperData] = null;
        }

        topRow.Mask.enabled = true;
    }

    private static void Refresh()
    {
        if (selectedModPanel == null) return;

        foreach (var (modHelperData, panel) in modPanels)
        {
            if (panel == null)
            {
                continue;
            }

            panel.Refresh(modHelperData);
        }

        if (updateAllButton != null)
        {
            var anyModsNeedUpdates = modPanels.Any(pair =>
                pair.Key.UpdateAvailable && pair.Value is not null && pair.Value.gameObject.active);
            updateAllButton.gameObject.SetActive(anyModsNeedUpdates);

        }

        restartPanel.SetActive(
            RestartRequired
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

        selectedModName = modTitlePanel.AddText(new Info("ModTitle", InfoPreset.FillParent)
        {
            Width = Padding * -2,
            Height = -Padding
        }, "Test Long Mod Name", FontLarge, TextAlignmentOptions.Left);
        selectedModName.Text.enableAutoSizing = true;


        selectedModHomeButton = firstRow.AddButton(new Info("HomePage")
        {
            Size = ModNameHeight
        }, VanillaSprites.HomeBtn, new Action(() => EmbeddedBrowser.OpenURL(selectedMod.ReadmeUrl!)));

        // ReSharper disable once AsyncVoidLambda
        selectedModUpdateButton = firstRow.AddButton(
            new Info("UpdateButton", size: ModNameHeight), VanillaSprites.GreenBtn, new Action(async () =>
                await ModHelperGithub.DownloadLatest(selectedMod, false, _ => Refresh(), task => updateTask = task))
        );
        selectedModUpdateButton.AddImage(
            new Info("UpgradeIcon", size: ModNameHeight - Padding), VanillaSprites.UpgradeIcon2
        );
        selectedModLoadingSpinner = selectedModUpdateButton.AddImage(
            new Info("Spinner", size: ModNameHeight), VanillaSprites.LoadingWheel
        );


        var secondRow = selectedModPanel.AddPanel(new Info("SecondRow")
        {
            Height = OtherHeight, FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal, Padding);

        var modAuthorPanel = secondRow.AddPanel(new Info("ModAuthorPanel")
        {
            FlexWidth = 4, FlexHeight = 1
        }, VanillaSprites.BlueInsertPanelRound);

        selectedModAuthor = modAuthorPanel.AddText(new Info("Author", InfoPreset.FillParent)
        {
            Width = Padding * -2,
            Height = -Padding
        }, "Author", FontSmall, TextAlignmentOptions.Left);
        selectedModAuthor.Text.enableAutoSizing = true;

        var modVersionPanel = secondRow.AddPanel(new Info("ModVersionPanel", InfoPreset.Flex),
            VanillaSprites.BlueInsertPanelRound);
        selectedModVersion = modVersionPanel.AddText(new Info("Version", InfoPreset.FillParent)
        {
            Width = -Padding,
            Height = -Padding
        }, "Version");
        selectedModVersion.Text.enableAutoSizing = true;


        var descriptionPanel = selectedModPanel.AddScrollPanel(new Info("DescriptionPanel", InfoPreset.Flex),
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
            Height = ModPanelHeight, FlexWidth = 1
        });

        selectedModIcon = buttonsRow.AddImage(
            new Info("ModIcon", ModIconSize / 2f, 0, ModIconSize, ModIconSize, new Vector2(0, 0.5f)),
            GetSprite<MelonMain>("Icon"));


        var middleButtons = buttonsRow.AddPanel(new Info("MiddleButtons", InfoPreset.FillParent), null,
            RectTransform.Axis.Horizontal, Padding);
        middleButtons.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
        selectedModDisableButton = middleButtons.AddButton(
            new Info("DisableButton", ModPanelHeight * ModHelperButton.LongBtnRatio, ModPanelHeight),
            VanillaSprites.RedBtnLong, new Action(DisableSelectedMod));
        selectedModDisableButton.AddText(new Info("ButtonText", InfoPreset.FillParent), "Disable", FontLarge);

        selectedModEnableButton = middleButtons.AddButton(
            new Info("EnabledButton", height: ModPanelHeight, width: ModPanelHeight * ModHelperButton.LongBtnRatio),
            VanillaSprites.GreenBtnLong, new Action(EnableSelectedMod)
        );
        selectedModEnableButton.AddText(new Info("ButtonText", InfoPreset.FillParent), "Enable", FontLarge);

        selectedModSettingsButton = buttonsRow.AddButton(
            new Info("SettingsButton", ModPanelHeight / -2f, 0, ModPanelHeight, ModPanelHeight, new Vector2(1, 0.5f)),
            VanillaSprites.BlueBtn, new Action(() => ModSettingsMenu.Open(selectedMod.Mod as BloonsMod)));
        selectedModSettingsButton.AddImage(
            new Info("Gear", width: ModNameHeight, height: ModNameHeight), VanillaSprites.SettingsIcon
        );

        selectedModDeleteButton = buttonsRow.AddButton(
            new Info("Delete", ModPanelHeight / -2f, 0, ModPanelHeight, ModPanelHeight, new Vector2(1, 0.5f)),
            VanillaSprites.CloseBtn, new Action(DeleteSelectedMod));
    }

    private static void DeleteSelectedMod()
    {
        PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter, "Delete Mod",
            "Are you sure you want to delete this mod? This action cannot be undone.", new Action(() =>
            {
                if (selectedMod.Delete())
                {
                    modPanels[selectedMod].gameObject.Destroy();
                    modPanels.Remove(selectedMod);
                    SetSelectedMod(ModHelper.Main.GetModHelperData());
                    SortMods(currentSort);
                    MenuManager.instance.buttonClickSound.Play("ClickSounds");
                }
            }), "Yes", null, "No", Popup.TransitionAnim.Scale));
    }

    internal static void DisableSelectedMod()
    {
        if (selectedMod.MoveToDisabledModsFolder())
        {
            SetSelectedMod(selectedMod);
            SortMods(currentSort);
            MenuManager.instance.buttonClickSound.Play("ClickSounds");
            if (selectedMod.Mod is MelonMain)
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowPopup(PopupScreen.Placement.menuCenter, "Warning",
                    "Disabling Mod Helper will mean you will no longer see this mods menu. " +
                    "You would have to manually re-enable this / any other mods by dragging their .dll files " +
                    "out of the Disabled folder within your mods directory.", null, "Ok",
                    new Action(EnableSelectedMod),
                    "Re-enable", Popup.TransitionAnim.Scale));
            }
        }
    }

    internal static void EnableSelectedMod()
    {
        if (selectedMod.MoveToEnabledModsFolder())
        {
            SetSelectedMod(selectedMod);
            SortMods(currentSort);
            MenuManager.instance.buttonClickSound.Play("ClickSounds");
        }
    }
}