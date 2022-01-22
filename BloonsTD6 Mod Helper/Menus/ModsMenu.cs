using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Unity.Menu;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.ChallengeEditor;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Updater;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using TMPro;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace BTD_Mod_Helper.Menus
{
    /// <summary>
    /// The ModGameMenu for the screen showing current mods
    /// </summary>
    public class ModsMenu : ModGameMenu<ExtraSettingsScreen>
    {
        #region Constants

        private const int Padding = 50;

        private const int MenuWidth = 3600;
        private const int MenuHeight = 1800;

        private const int LeftMenuWidth = 1750;
        private const int RightMenuWidth = 1750;

        private const int ModNameWidth = 1000;

        private const int ModIconSize = 250;
        private const int ModPanelHeight = 200;
        private const int ModNameHeight = 150;
        private const int OtherHeight = 100;

        private const int FontSmall = 52;
        private const int FontMedium = 69;
        private const int FontLarge = 80;

        private const string DefaultDescription = "No description given";

        #endregion

        private static Dictionary<ModHelperData, ModHelperComponent> modPanels =
            new Dictionary<ModHelperData, ModHelperComponent>();

        private static ModHelperScrollPanel modsList;
        private static ModHelperData selectedMod;
        private static ModHelperPanel selectedModPanel;
        private static ModHelperText selectedModName;
        private static ModHelperText selectedModAuthor;
        private static ModHelperText selectedModVersion;
        private static ModHelperText selectedModDescription;
        private static ModHelperButton selectedModUpdateButton;
        private static ModHelperButton selectedModSettingsButton;
        private static ModHelperButton selectedModDisableButton;
        private static ModHelperButton selectedModEnableButton;
        private static ModHelperButton updateAllButton;
        private static ModHelperImage selectedModIcon;

        private static bool loadedAllMods;

        private static readonly string[] SortOptions =
        {
            "All Mods",
            "Enabled Mods",
            "Disabled Mods",
            "Mods Needing Updates"
        };

        /// <inheritdoc />
        public override bool OnMenuOpened(ExtraSettingsScreen gameMenu, Object data)
        {
            loadedAllMods = false;
            CommonForegroundHeader.SetText("Mods");

            var panelTransform = gameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
            var panel = panelTransform.gameObject;
            panel.DestroyAllChildren();

            var modsMenu = panel.AddModHelperPanel(new Info("ModsMenu", width: MenuWidth, height: MenuHeight));

            CreateLeftMenu(modsMenu);

            CreateRightMenu(modsMenu);

            SetSelectedMod(GetInstance<MelonMain>().GetModHelperData());
            Refresh();

            return false;
        }

        /// <inheritdoc />
        public override void OnMenuUpdate(ExtraSettingsScreen gameMenu)
        {
            if (loadedAllMods)
            {
                return;
            }

            var (data, _) = modPanels.FirstOrDefault(pair => pair.Value == null);
            if (data != null)
            {
                var panel = CreateModPanel(data, data.Mod);
                modPanels[data] = panel;
                modsList.AddScrollContent(panel);
                RefreshModPanel(data, panel);
            }
            else
            {
                Refresh();
                loadedAllMods = true;
            }
        }

        internal static void SetSelectedMod(ModHelperData modSelected)
        {
            selectedMod = modSelected;

            selectedModName.Text.SetText(modSelected.Name);
            selectedModAuthor.Text.SetText(modSelected.Author);
            selectedModVersion.Text.SetText("v" + modSelected.Version);
            selectedModDescription.Text.SetText(modSelected.Description ?? DefaultDescription);

            selectedModAuthor.Text.SetFaceColor(BlatantFavoritism.GetColor(modSelected.RepoOwner));

            selectedModUpdateButton.gameObject.SetActive(modSelected.UpdateAvailable);

            selectedModSettingsButton.gameObject.SetActive(modSelected.Mod is BloonsMod bloonsMod &&
                                                           bloonsMod.ModSettings.Any());

            if (!modSelected.HasNoIcon && modSelected.GetSprite() is Sprite sprite)
            {
                selectedModIcon.gameObject.SetActive(true);
                selectedModIcon.Image.SetSprite(sprite);
            }
            else
            {
                selectedModIcon.gameObject.SetActive(false);
            }
        }

        internal static void SortMods(int selectedIndex)
        {
            foreach (var (modHelperData, modPanel) in modPanels)
            {
                switch (selectedIndex)
                {
                    default:
                        modPanel.gameObject.SetActive(true);
                        break;
                    case 1:
                        modPanel.gameObject.SetActive(modHelperData.Mod != null);
                        break;
                    case 2:
                        modPanel.gameObject.SetActive(modHelperData.Mod == null);
                        break;
                    case 3:
                        modPanel.gameObject.SetActive(modHelperData.UpdateAvailable);
                        break;
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

            var topRow = leftMenu.AddPanel(
                new Info("TopRow", height: ModNameHeight, flexWidth: 1), null, RectTransform.Axis.Horizontal, Padding
            );

            topRow.AddDropdown(
                new Info("ModFilter", height: ModNameHeight, width: 800f),
                SortOptions.ToIl2CppList(), ModNameHeight * 4, new Action<int>(SortMods),
                VanillaSprites.BlueInsertPanelRound, FontSmall
            );

            topRow.AddPanel(new Info("Filler", flex: 1));

            // ReSharper disable once AsyncVoidLambda
            updateAllButton = topRow.AddButton(
                new Info("UpdateAll", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
                VanillaSprites.GreenBtnLong, new Action(async () =>
                {
                    foreach (var modHelperData in modPanels.Select(pair => pair.Key)
                                 .Where(data => data.UpdateAvailable))
                    {
                        await ModHelperGithub.DownloadLatest(modHelperData, true);
                    }
                })
            );

            updateAllButton.AddText(
                new Info("UpdateAllText", anchorMin: Vector2.zero, anchorMax: Vector2.one), "Update All", FontSmall
            );

            modsList = leftMenu.AddScrollPanel(
                new Info("ModListScroll", flex: 1), RectTransform.Axis.Vertical,
                VanillaSprites.BlueInsertPanelRound, Padding, Padding
            );

            modPanels = new Dictionary<ModHelperData, ModHelperComponent>();
            foreach (var modHelperData in ModHelperData.Data)
            {
                modPanels[modHelperData] = null;
            }
        }

        internal static void Refresh()
        {
            foreach (var (modHelperData, panel) in modPanels)
            {
                if (panel == null)
                {
                    continue;
                }

                RefreshModPanel(modHelperData, panel);
            }

            if (updateAllButton != null)
            {
                updateAllButton.gameObject.SetActive(modPanels.Any(pair =>
                    pair.Key.UpdateAvailable && pair.Value != null && pair.Value.gameObject.active));
            }

            SetSelectedMod(selectedMod);
        }

        internal static void RefreshModPanel(ModHelperData modHelperData, ModHelperComponent panel)
        {
            var transform = panel.transform;
            transform.Find("RestartRequired").gameObject.SetActive(modHelperData.RestartRequired);

            var updateAvailable = modHelperData.UpdateAvailable;
            transform.Find("VersionText").GetComponent<NK_TextMeshProUGUI>().color =
                UpdaterHttp.IsUpdate(modHelperData.Version, modHelperData.RepoVersion) ? Color.red : Color.white;
            transform.Find("UpdateButton").gameObject.SetActive(updateAvailable);

            transform.Find("Icon").gameObject.SetActive(!modHelperData.HasNoIcon);
        }

        /// <summary>
        /// Create the visual representation of a mod in the mods list
        /// </summary>
        internal static ModHelperComponent CreateModPanel(ModHelperData modHelperData, MelonMod melonMod = null)
        {
            var background = GetBackground(melonMod);

            var panel = ModHelperButton.Create(
                new Info(modHelperData.Name, height: ModPanelHeight, flexWidth: 1),
                background, new Action(() =>
                {
                    SetSelectedMod(modHelperData);
                    MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
                })
            );

            panel.AddImage(
                new Info("Icon", Padding * 2, 0, ModIconSize, ModIconSize, anchor: new Vector2(0, 0.5f)),
                modHelperData.GetSprite()
            );


            panel.AddImage(
                new Info("RestartRequired", Padding * 2, 0, ModIconSize, ModIconSize, anchor: new Vector2(0, 0.5f)),
                VanillaSprites.RestartIcon
            );

            panel.AddText(new Info("NameText", 0, 0, ModNameWidth, ModNameHeight), modHelperData.Name, FontMedium);

            panel.AddText(
                new Info("VersionText", Padding * -2, 0, ModNameWidth / 5f, ModNameHeight,
                    anchor: new Vector2(1, 0.5f)), "v" + modHelperData.Version, FontSmall
            );

            // ReSharper disable once AsyncVoidLambda
            panel.AddButton(
                new Info("UpdateButton", Padding / -2f, Padding / -2f, ModPanelHeight / 2f, ModPanelHeight / 2f,
                    anchor: new Vector2(1, 1)), VanillaSprites.UpgradeBtn,
                new Action(async () => await ModHelperGithub.DownloadLatest(modHelperData))
            );

            var settings = panel.AddButton(
                new Info("SettingsIcon", Padding / -2f, Padding / 2f, ModPanelHeight / 3f, ModPanelHeight / 3f,
                    anchor: new Vector2(1, 0)), VanillaSprites.SettingsIconSmall,
                new Action(() => ModSettingsMenu.Open((BloonsMod) melonMod))
            );

            if (!(melonMod is BloonsMod bloonsMod && bloonsMod.ModSettings.Any()))
            {
                settings.gameObject.SetActive(false);
            }


            return panel;
        }

        private static SpriteReference GetBackground(MelonMod melonMod)
        {
            var background = VanillaSprites.MainBGPanelBlue;
            if (melonMod == null)
                background = VanillaSprites.MainBGPanelGrey;
            else if (melonMod == GetInstance<MelonMain>())
                background = VanillaSprites.MainBGPanelYellow;
            else if (melonMod.Games.Any(attribute => attribute.Universal))
                background = VanillaSprites.MainBgPanelHematite;
            else if (!(melonMod is BloonsMod)) background = VanillaSprites.MainBGPanelBlueNotches;
            return background;
        }

        private static void CreateRightMenu(ModHelperPanel modsMenu)
        {
            selectedModPanel = modsMenu.AddPanel(
                new Info("ModInfo", (MenuWidth - RightMenuWidth) / 2f, 0, RightMenuWidth, MenuHeight),
                VanillaSprites.MainBGPanelBlue, RectTransform.Axis.Vertical, Padding, Padding
            );

            var firstRow = selectedModPanel.AddPanel(
                new Info("FirstRow", height: ModNameHeight, flexWidth: 1), null, RectTransform.Axis.Horizontal, Padding
            );

            var modTitlePanel = firstRow.AddPanel(
                new Info("ModTitlePanel", flex: 1), VanillaSprites.BlueInsertPanelRound
            );
            selectedModName = modTitlePanel.AddText(
                new Info("ModTitle", width: Padding * -2, anchorMin: Vector2.zero, anchorMax: Vector2.one),
                "Test Long Mod Name", FontLarge, TextAlignmentOptions.Left
            );

            // ReSharper disable once AsyncVoidLambda
            selectedModUpdateButton = firstRow.AddButton(
                new Info("UpdateButton", height: ModNameHeight, width: ModNameHeight * ModHelperButton.LongBtnRatio),
                VanillaSprites.GreenBtnLong, new Action(async () => await ModHelperGithub.DownloadLatest(selectedMod))
            );
            selectedModUpdateButton.AddText(
                new Info("Text", anchorMin: Vector2.zero, anchorMax: Vector2.one), "Update", FontMedium
            );

            var secondRow = selectedModPanel.AddPanel(
                new Info("SecondRow", height: OtherHeight, flexWidth: 1), null, RectTransform.Axis.Horizontal, Padding
            );

            var modAuthorPanel = secondRow.AddPanel(
                new Info("ModAuthorPanel", flexWidth: 4, flexHeight: 1), VanillaSprites.BlueInsertPanelRound
            );
            selectedModAuthor = modAuthorPanel.AddText(
                new Info("Author", width: Padding * -2, anchorMin: Vector2.zero, anchorMax: Vector2.one),
                "Author", FontSmall, TextAlignmentOptions.Left
            );

            var modVersionPanel = secondRow.AddPanel(
                new Info("ModVersionPanel", flexWidth: 1, flexHeight: 1), VanillaSprites.BlueInsertPanelRound
            );
            selectedModVersion = modVersionPanel.AddText(
                new Info("Version", width: Padding * -2, anchorMin: Vector2.zero, anchorMax: Vector2.one), "Version",
                FontSmall
            );


            var descriptionPanel = selectedModPanel.AddScrollPanel(
                new Info("DescriptionPanel", flex: 1), RectTransform.Axis.Vertical,
                VanillaSprites.BlueInsertPanelRound, Padding, Padding
            );

            selectedModDescription = ModHelperText.Create(
                new Info("DescriptionText", width: RightMenuWidth - Padding * 4),
                DefaultDescription, FontSmall, TextAlignmentOptions.TopLeft
            );
            descriptionPanel.AddScrollContent(selectedModDescription);
            selectedModDescription.LayoutElement.preferredHeight = -1;
            selectedModDescription.Text.enableAutoSizing = true;
            selectedModDescription.Text.lineSpacing = 50;

            var buttonsRow = selectedModPanel.AddPanel(new Info("ButtonRow", height: ModPanelHeight, flexWidth: 1));

            selectedModIcon = buttonsRow.AddImage(
                new Info("ModIcon", ModIconSize / 2f, 0, ModIconSize, ModIconSize, anchor: new Vector2(0, 0.5f)),
                VanillaSprites.InfoIcon
            );

            selectedModDisableButton = buttonsRow.AddButton(
                new Info("DisableButton", height: ModPanelHeight, width: ModPanelHeight * ModHelperButton.LongBtnRatio),
                VanillaSprites.RedBtnLong, new Action(() => { })
            );
            selectedModDisableButton.AddText(
                new Info("ButtonText", anchorMin: Vector2.zero, anchorMax: Vector2.one), "Disable", FontLarge
            );

            selectedModEnableButton = buttonsRow.AddButton(
                new Info("EnabledButton", height: ModPanelHeight, width: ModPanelHeight * ModHelperButton.LongBtnRatio),
                VanillaSprites.GreenBtnLong, new Action(() => { })
            );
            selectedModEnableButton.AddText(
                new Info("ButtonText", anchorMin: Vector2.zero, anchorMax: Vector2.one), "Enable", FontLarge
            );
            selectedModEnableButton.gameObject.active = false;

            selectedModSettingsButton = buttonsRow.AddButton(
                new Info("SettingsButton", ModPanelHeight / -2f, 0, ModPanelHeight, ModPanelHeight,
                    anchor: new Vector2(1, 0.5f)), VanillaSprites.BlueBtn,
                new Action(() => ModSettingsMenu.Open((BloonsMod) selectedMod.Mod))
            );
            selectedModSettingsButton.AddImage(
                new Info("Gear", width: ModNameHeight, height: ModNameHeight), VanillaSprites.SettingsIcon
            );
        }
    }
}