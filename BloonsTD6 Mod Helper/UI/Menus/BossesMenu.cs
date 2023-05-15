using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.Common;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static BTD_Mod_Helper.UI.Menus.ModsMenu;

namespace BTD_Mod_Helper.UI.Menus;

internal class BossesMenu : ModGameMenu<ExtraSettingsScreen>
{
    static ModHelperText authorsLabel;
    static ModHelperText displayNameLabel;
    static ModHelperText systemNameLabel;
    static ModHelperText extraCreditLabel;
    static ModHelperText roundsLabel;

    static ModHelperText descriptionLabel;
    static ModHelperScrollPanel descriptionPanel;

    static ModHelperText speedLabel;
    static ModHelperText healthLabel;

    static ModHelperImage isFortifiedIcon;
    static ModHelperImage isCamoIcon;
    static ModHelperPanel iconsPanel;

    static ModHelperText skullLabel;
    static ModHelperText timerLabel;

    const string ListSeparator = ", ";
    const string InfoIcon = VanillaSprites.InfoBtn2;

    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        CommonForegroundHeader.SetText("Bosses");

        var panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
        var panel = panelTransform.gameObject;
        panel.DestroyAllChildren();

        var bossMenu = panel.AddModHelperPanel(new Info("ModsMenu", MenuWidth, MenuHeight), null);
        CreateLeftMenu(bossMenu);
        CreateRightMenu(bossMenu);

        return false;
    }

    static ModHelperPanel? bossPanel;

    private static void CreateLeftMenu(ModHelperPanel bossMenu)
    {
        int Padding = 50;

        var leftMenu = bossMenu.AddPanel(
            new Info("LeftMenu", (MenuWidth - 1750) / -2f, 0, 1750, MenuHeight),
            VanillaSprites.MainBGPanelBlue, RectTransform.Axis.Vertical, Padding, Padding
        );

        var bossList = leftMenu.AddScrollPanel(new Info("BossListScroll", InfoPreset.Flex), RectTransform.Axis.Vertical,
        VanillaSprites.BlueInsertPanelRound, Padding, Padding);

        foreach (var item in ModBoss.Cache.Values)
        {
            bossList.AddScrollContent(CreateItem(item));
        }
    }

    private static void CreateRightMenu(ModHelperPanel bossMenu)
    {
        ModHelperPanel rightPanel = bossMenu.AddPanel(
            new Info("RightMenu", (MenuWidth - 1750) / 2f, 0, 1750, MenuHeight),
            VanillaSprites.MainBGPanelBlue, RectTransform.Axis.Vertical, Padding, Padding
        );

        rightPanel.SetActive(false);

        var topPanel = rightPanel.AddPanel(new Info("TopPanel")
        {
            Height = ModNameHeight * 2,
            FlexWidth = 1
        }, null, RectTransform.Axis.Horizontal);

        topPanel.AddImage(new Info("Icon")
        {
            Size = ModNameHeight * 2
        }, new Sprite());

        var namesPanel = topPanel.AddPanel(new Info("NamesPanel", InfoPreset.Flex)
        {
            Y = -ModNameHeight * 2,
        });

        displayNameLabel = namesPanel.AddText(new Info("DisplayName", ModNameWidth, ModNameHeight), "DisplayName", FontLarge * 1.5f);
        displayNameLabel.Text.fontSizeMax = FontLarge * 1.5f;
        displayNameLabel.Text.enableAutoSizing = true;

        systemNameLabel = namesPanel.AddText(new Info("SystemName", 0, -FontLarge * 1.5f, ModNameWidth, ModNameHeight), "SystemName", FontSmall);
        systemNameLabel.Text.fontSizeMax = FontSmall;
        systemNameLabel.Text.enableAutoSizing = true;

        var authorsStatusPanel = rightPanel.AddPanel(new Info("authorsStatusPanel")
        {
            Height = ModNameHeight,
            FlexWidth = 1,
        }, null, RectTransform.Axis.Horizontal, Padding, 0);

        // Icons
        iconsPanel = authorsStatusPanel.AddPanel(new Info("IconsPanel")
        {
            Height = ModNameHeight,
            Width = ModNameHeight * 2,
        }, VanillaSprites.BlueInsertPanelRound);

        isCamoIcon = iconsPanel.AddImage(new Info("CamoIcon", ModNameHeight) { X = -Padding * 1.5f }, VanillaSprites.CamoBloonsIcon);
        isFortifiedIcon = iconsPanel.AddImage(new Info("FortifiedIcon", ModNameHeight) { X = ModNameHeight - Padding * 1.5f }, VanillaSprites.FortifiedBloonsIcon);

        // Authors
        authorsLabel = authorsStatusPanel.AddText(new Info("Authors", ModNameWidth, ModNameHeight / 3), "Authors: ", FontSmall, Il2CppTMPro.TextAlignmentOptions.Left);
        authorsLabel.Text.enableAutoSizing = true;

        extraCreditLabel = rightPanel.AddText(new Info("ExtraCredits", ModNameWidth, ModNameHeight / 3), "Extra Credits: ", FontSmall, Il2CppTMPro.TextAlignmentOptions.Left);
        extraCreditLabel.Text.enableAutoSizing = true;

        descriptionPanel = rightPanel.AddScrollPanel(new Info("DescriptionPanel", InfoPreset.FillParent)
        {
            FlexWidth = 1,
            Height = FontSmall * 4 + Padding * 2,
        }, RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanelRound, Padding, Padding);

        descriptionLabel = descriptionPanel.AddText(new Info("Description", ModNameWidth, ModNameHeight)
        {
            Flex = 1
        }, "", FontSmall, Il2CppTMPro.TextAlignmentOptions.MidlineLeft);
        descriptionLabel.Text.enableAutoSizing = true;

        descriptionPanel.AddScrollContent(descriptionLabel);

        var mainPanel = rightPanel.AddScrollPanel(new Info("MainPanel", InfoPreset.Flex), RectTransform.Axis.Vertical, VanillaSprites.BlueInsertPanelRound, Padding, Padding);
        var mainPanelWidth = rightPanel.RectTransform.sizeDelta.x - 4 * Padding;

        mainPanel.ScrollContent.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;

        roundsLabel = mainPanel.AddText(new Info("RoundsLabel", ModNameWidth, ModNameHeight)
        {
            Flex = 1
        }, "Round(s):", FontMedium, Il2CppTMPro.TextAlignmentOptions.Left);
        mainPanel.AddScrollContent(roundsLabel);

        var speedPanel = mainPanel.AddPanel(new Info("SpeedPanel", mainPanelWidth, ModNameHeight));
        mainPanel.AddScrollContent(speedPanel);
        speedPanel.AddComponent<HorizontalLayoutGroup>();

        speedLabel = speedPanel.AddText(new Info("SpeedLabel", speedPanel.RectTransform.sizeDelta.x - ModNameHeight, ModNameHeight), "Speed:", FontMedium, Il2CppTMPro.TextAlignmentOptions.Left);
        speedPanel.AddButton(new Info("SpeedInfo", ModNameHeight, ModNameHeight), InfoIcon,
            new Action(() =>
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup("For reference, a BAD has a speed of 4.5 while a red bloon has a speed of 25."));
            }));

        var healthPanel = mainPanel.AddPanel(new Info("HealthPanel", mainPanelWidth, ModNameHeight));
        mainPanel.AddScrollContent(healthPanel);
        healthPanel.AddComponent<HorizontalLayoutGroup>();

        healthLabel = healthPanel.AddText(new Info("HealthLabel", healthPanel.RectTransform.sizeDelta.x - ModNameHeight, ModNameHeight)
        {
            Flex = 1
        }, "Health:", FontMedium, Il2CppTMPro.TextAlignmentOptions.Left);
        healthPanel.AddButton(new Info("HealthInfo", ModNameHeight, ModNameHeight), InfoIcon,
            new Action(() =>
            {
                PopupScreen.instance.SafelyQueue(screen => screen.ShowOkPopup("For reference, a BAD has 20k health while a DDT has 400 health."));
            }));


        skullLabel = mainPanel.AddText(new Info("HealthLabel", ModNameWidth, ModNameHeight)
        {
            Flex = 1
        }, "Skull (#):", FontMedium, Il2CppTMPro.TextAlignmentOptions.Left);
        mainPanel.AddScrollContent(skullLabel);

        timerLabel = mainPanel.AddText(new Info("HealthLabel", ModNameWidth, ModNameHeight)
        {
            Flex = 1
        }, "Timer (Xs):", FontMedium, Il2CppTMPro.TextAlignmentOptions.Left);
        mainPanel.AddScrollContent(timerLabel);

        bossPanel = rightPanel;
    }

    private static ModHelperComponent CreateItem(ModBoss boss)
    {
        var mod = ModHelperPanel.Create(new Info(boss.Name)
        {
            Height = 200,
            FlexWidth = 1
        });

        var panel = mod.AddButton(new Info("MainBtn", InfoPreset.FillParent), VanillaSprites.MainBGPanelBlueNotches,
            new System.Action(() =>
            {
                LoadBossInfo(boss);
                MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
            }));

        panel.AddImage(new Info("Icon", Padding * 2, 0, ModIconSize, new Vector2(0, 0.5f)), GetTextureGUID(boss.mod, boss.Icon));

        panel.AddText(new Info("Name", ModNameWidth, ModNameHeight), boss.DisplayName,
            FontMedium);

        return mod;
    }

    private static void LoadBossInfo(ModBoss boss)
    {
        if (bossPanel == null)
            return;

        Sprite sprite = ModContent.GetSprite(boss.mod, boss.Icon);
        Transform icon = bossPanel.transform.FindChildWithName("Icon");

        if (sprite != null)
        {
            icon.GetComponent<Image>().sprite = sprite;
        }

        displayNameLabel.SetText(boss.DisplayName);
        systemNameLabel.SetText(boss.Name);

        // Icons
        iconsPanel.Background.enabled = boss.bloonModel.isCamo || boss.bloonModel.isFortified;
        isCamoIcon.SetActive(boss.bloonModel.isCamo);
        isFortifiedIcon.SetActive(boss.bloonModel.isFortified);

        // Authors
        authorsLabel.SetText($"Author(s): {boss.mod.Info.Author}");
        authorsLabel.Text.SetFaceColor(BlatantFavoritism.GetColor(boss.mod.GetModHelperData().RepoOwner));

        extraCreditLabel.SetActive(!string.IsNullOrEmpty(boss.ExtraCredits));
        extraCreditLabel.SetText("Extra credits: " + boss.ExtraCredits);

        descriptionPanel.SetActive($"Default description for {boss.Name}" != boss.Description);
        descriptionLabel.SetText(boss.Description);

        roundsLabel.SetText("Round(s): " + string.Join(", ", boss.SpawnRounds));

        speedLabel.SetText("Speed: " + boss.bloonModel.speed);
        healthLabel.SetText("Health: " + boss.bloonModel.maxHealth); // Format ?

        string timers = "";
        string skulls = "";

        ModBoss.BossRoundInfo[] infos = boss.RoundsInfo.Values.ToArray();
        for (int i = 0; i < boss.RoundsInfo.Count; i++)
        {
            var value = infos[i];

            timers += (value.interval != null ? value.interval : -1) + "s";
            skulls += value.skullCount != null ? value.skullCount : 0;

            if (i != boss.RoundsInfo.Count - 1)
            {
                timers += ListSeparator;
                skulls += ListSeparator;
            }
        }

        skullLabel.SetActive(boss.UsesSkulls);
        skullLabel.SetText($"Skull(s) ({skulls}): " + boss.SkullDescription);

        timerLabel.SetActive(boss.UsesTimer);
        timerLabel.SetText($"Timer ({timers}): " + boss.TimerDescription);

        bossPanel.SetActive(true);
    }
}
