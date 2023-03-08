using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.Main.Facebook;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MapSelect;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.Modded;

/// <summary>
/// Class controlling the in game Round Set override UI
/// </summary>
public static class RoundSetChanger
{
    /// <summary>
    /// The round set override currently chosen, or null
    /// </summary>
    public static string RoundSetOverride { get; private set; }

    private static readonly string[] ShowOnMenus =
    {
        "MapSelectUI", "DifficultySelectUI", "ModeSelectUI",
        "MapSelectScreen", "DifficultySelectScreen", "ModeSelectScreen"
    };

    private const float AnimatorSpeed = .75f;
    private const int AnimationTicks = (int) (10 / AnimatorSpeed);

    private static ModHelperPanel buttonPanel;
    private static ModHelperScrollPanel optionsPanel;
    private static ModHelperButton button;
    private static readonly Dictionary<string, ModHelperImage> CheckMarks = new();
    private static List<ModRoundSet> modRoundSets;

    private static ModHelperPanel invisibleCancel;

    private static void CreatePanel(GameObject screen)
    {
        CheckMarks.Clear();
        RoundSetOverride = "";
        buttonPanel = screen.AddModHelperPanel(new Info("RoundSetChangerPanel")
        {
            Anchor = new Vector2(1, 0), Pivot = new Vector2(1, 0)
        });

        var animator = buttonPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed = AnimatorSpeed;


        optionsPanel = screen.AddModHelperScrollPanel(new Info("OptionsScroll")
        {
            Width = 400, AnchorMin = new Vector2(1, 0), AnchorMax = new Vector2(1, 1), Pivot = new Vector2(1, 0)
        }, RectTransform.Axis.Vertical, null, 50, 100);

        animator = optionsPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed = AnimatorSpeed;

        optionsPanel.ScrollContent.RectTransform.pivot = new Vector2(0.5f, 0);
        optionsPanel.ScrollContent.LayoutGroup.childAlignment = TextAnchor.LowerCenter;

        optionsPanel.SetActive(false);

        modRoundSets ??= ModContent.GetContent<ModRoundSet>().Where(set => set.AddToOverrideMenu).ToList();
        foreach (var modRoundSet in modRoundSets)
        {
            try
            {
                optionsPanel.AddScrollContent(
                    CreateRoundSetButton(modRoundSet.Id, modRoundSet.DisplayName, modRoundSet.IconReference.guidRef)
                );
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to display round set {modRoundSet.Id}");
                ModHelper.Warning(e);
            }
        }

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.ABR, "Alternate", VanillaSprites.AlternateBloonsBtn)
        );

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.Default, "Classic", VanillaSprites.BlueRoundPlayBtn)
        );

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.Empty, "No Change", VanillaSprites.WoodenRoundButton)
        );


        button = buttonPanel.AddButton(
            new Info("RoundSetChanger", -250, 50, 350, 350, new Vector2(1, 0), new Vector2(0.5f, 0)),
            VanillaSprites.WoodenRoundButton, new Action(StartOptionsMode));

        button.AddText(
            new Info("Text", 0, -175, 500, 100), "Change Rounds", 60f
        );
    }

    private static ModHelperButton CreateRoundSetButton(string id, string displayName, string icon)
    {
        var roundButton = ModHelperButton.Create(new Info(displayName, width: 300, height: 300),
            icon, new Action(() =>
            {
                StopOptionsMode();
                RoundSetOverride = id;
                button.Image.SetSprite(icon);
                MenuManager.instance.buttonClick3Sound.Play("ClickSounds");
            }));

        roundButton.AddText(
            new Info(displayName, 0, -175, 500, 100), displayName, 50f
        );

        CheckMarks[id] = roundButton.AddImage(
            new Info("Tick", -75, -75, 100, 100, anchor: Vector2.one), VanillaSprites.SelectedTick
        );

        return roundButton;
    }

    private static void StartOptionsMode()
    {
        MenuManager.instance.buttonClick2Sound.Play("ClickSounds");
        HideButton();
        RevealOptions();
        if (MenuManager.instance.GetCurrentMenu().Exists().IsType<MapSelectScreen>() && modRoundSets.Count > 3)
        {
            CommonForegroundScreen.instance.GetComponentInChildren<FriendLoginButton>(true).gameObject.SetActive(false);
        }
    }

    private static void StopOptionsMode()
    {
        HideOptions();
        RevealButton();
    }

    private static void Init()
    {
        var foregroundScreen = CommonForegroundScreen.instance.transform;
        var backgroundScreen = CommonBackgroundScreen.instance.transform;
        var roundSetChanger = foregroundScreen.FindChild("RoundSetChangerPanel");
        if (roundSetChanger == null)
        {
            CreatePanel(foregroundScreen.gameObject);
            CreateCancel(backgroundScreen.gameObject);
        }
    }
    
    private static void CreateCancel(GameObject screen)
    {
        invisibleCancel = screen.AddModHelperPanel(new Info("InvisibleCancel", InfoPreset.FillParent));
        var cancel = invisibleCancel.AddComponent<Button>();
        cancel.SetOnClick(StopOptionsMode);
        invisibleCancel.SetActive(false);
        invisibleCancel.AddComponent<Text>();
    }

    private static void RevealButton()
    {
        buttonPanel.SetActive(true);
        buttonPanel.GetComponent<Animator>().Play("PopupSlideIn");
    }

    private static void HideButton()
    {
        buttonPanel.GetComponent<Animator>().Play("PopupSlideOut");
        TaskScheduler.ScheduleTask(() => buttonPanel.SetActive(false), ScheduleType.WaitForFrames, AnimationTicks);
    }

    private static void RevealOptions()
    {
        optionsPanel.SetActive(true);
        optionsPanel.GetComponent<Animator>().Play("PopupScaleIn");
        optionsPanel.ScrollContent.RectTransform.localPosition = new Vector3(-200, 0, 0);
        foreach (var (id, image) in CheckMarks)
        {
            image.SetActive(RoundSetOverride == id);
        }
        invisibleCancel.SetActive(true);
    }

    private static void HideOptions()
    {
        optionsPanel.GetComponent<Animator>().Play("PopupScaleOut");
        TaskScheduler.ScheduleTask(() => optionsPanel.SetActive(false), ScheduleType.WaitForFrames, AnimationTicks);
        CommonForegroundScreen.instance.GetComponentInChildren<FriendLoginButton>(true).gameObject.SetActive(true);
        invisibleCancel.SetActive(false);
    }

    private static void Show()
    {
        Init();
        RevealButton();
        optionsPanel.SetActive(false);
    }

    private static void Hide()
    {
        Init();
        HideButton();
        HideOptions();
    }

    internal static void EnsureHidden()
    {
        if (buttonPanel != null)
        {
            buttonPanel.SetActive(false);
        }

        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }

    internal static void OnMenuChanged(string currentMenu, string newMenu)
    {
        if (!MelonMain.ShowRoundsetChanger) return;

        if (ShowOnMenus.Contains(newMenu))
        {
            if (!ShowOnMenus.Contains(currentMenu))
            {
                Show();
            }
            
            ModifyBlockClicks();
        }

        if (ShowOnMenus.Contains(currentMenu) && !ShowOnMenus.Contains(newMenu))
        {
            Hide();
        }
    }

    internal static void ModifyBlockClicks()
    {
        TaskScheduler.ScheduleTask(() =>
        {
            var gameMenu = MenuManager.instance.GetCurrentMenu();
            if (gameMenu == null) return;
            var blockClicks = gameMenu.transform.GetComponentFromChildrenByName<RectTransform>("BlockClicks");
            if (blockClicks != null && !blockClicks.gameObject.HasComponent<Button>())
            {
                var cancel = blockClicks.gameObject.AddComponent<Button>();
                cancel.AddOnClick(() =>
                {
                    if (optionsPanel != null && optionsPanel.isActiveAndEnabled)
                    {
                        StopOptionsMode();
                    }
                });
            }
        }, ScheduleType.WaitForFrames, 10);
    }
}