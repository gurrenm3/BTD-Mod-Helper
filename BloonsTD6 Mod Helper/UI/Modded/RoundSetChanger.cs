using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;

namespace BTD_Mod_Helper.UI.Modded;

internal static class RoundSetChanger
{
    private static readonly string[] ShowOnMenus =
    {
        "MapSelectUI", "MapSelectScreen", "DifficultySelectUI", "DifficultySelectScreen", "ModeSelectUI",
        "ModeSelectScreen"
    };

    private const float AnimatorSpeed = .75f;
    private const int AnimationTicks = (int)(20 / AnimatorSpeed);

    private static ModHelperPanel buttonPanel = null!;
    private static ModHelperScrollPanel optionsPanel = null!;
    private static ModHelperButton button = null!;
    private static Dictionary<string, ModHelperImage> ticks = new();

    public static string? RoundSetOverride { get; private set; }

    private static void CreatePanel(GameObject screen)
    {
        ticks.Clear();
        RoundSetOverride = "";
        buttonPanel = screen.AddModHelperPanel(
            new Info("RoundSetChangerPanel", anchor: new Vector2(1, 0), pivot: new Vector2(1f, 0f)));

        var animator = buttonPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed = AnimatorSpeed;


        optionsPanel = screen.AddModHelperScrollPanel(new Info("OptionsScroll", anchorMin: new Vector2(1, 0),
            anchorMax: new Vector2(1, 1),
            pivot: new Vector2(1f, 0f), width: 400), RectTransform.Axis.Vertical, null, 50, 100);

        animator = optionsPanel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.PopupAnim;
        animator.speed = AnimatorSpeed;

        optionsPanel.ScrollContent.RectTransform.pivot = new Vector2(0.5f, 0);
        optionsPanel.ScrollContent.LayoutGroup.childAlignment = TextAnchor.LowerCenter;

        optionsPanel.SetActive(false);

        foreach (var modRoundSet in ModContent.GetContent<ModRoundSet>())
        {
            optionsPanel.AddScrollContent(
                CreateRoundSetButton(modRoundSet.Id, modRoundSet.DisplayName, modRoundSet.IconReference)
            );
        }

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.ABR, "Alternate", VanillaSprites.AlternateBloonsBtn)
        );

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.Default, "Classic", VanillaSprites.BlueRoundPlayBtn)
        );

        optionsPanel.AddScrollContent(
            CreateRoundSetButton(RoundSetType.Empty, "Default", VanillaSprites.WoodenRoundButton)
        );


        button = buttonPanel.AddButton(
            new Info("RoundSetChanger", -250, 50, 350, 350, anchor: new Vector2(1, 0), pivot: new Vector2(0.5f, 0)),
            VanillaSprites.WoodenRoundButton, new Action(StartOptionsMode)
        );

        button.AddText(
            new Info("Text", 0, -175, 500, 100), "Change Rounds", 60f
        );
    }

    private static ModHelperButton CreateRoundSetButton(string id, string displayName, SpriteReference icon)
    {
        var roundButton = ModHelperButton.Create(new Info(displayName, width: 300, height: 300),
            icon, new Action(() =>
            {
                StopOptionsMode();
                RoundSetOverride = id;
                button.Image.SetSprite(icon);
            }));

        roundButton.AddText(
            new Info(displayName, 0, -175, 500, 100), displayName, 50f
        );

        ticks[id] = roundButton.AddImage(
            new Info("Tick", -75, -75, 100, 100, anchor: Vector2.one), VanillaSprites.SelectedTick
        );

        return roundButton;
    }

    private static void StartOptionsMode()
    {
        HideButton();
        RevealOptions();
        /*if (MenuManager.instance.GetCurrentMenu().Exists().IsType<MapSelectScreen>(out var screen))
        {
            screen.transform.FindChild("Friends").Exists()?.gameObject.SetActive(false);
        }*/
    }

    private static void StopOptionsMode()
    {
        HideOptions();
        RevealButton();
        /*if (MenuManager.instance.GetCurrentMenu().Exists().IsType<MapSelectScreen>(out var screen))
        {
            screen.transform.FindChild("Friends").Exists()?.gameObject.SetActive(true);
        }*/
    }

    private static void Init()
    {
        var screen = CommonForegroundScreen.instance.transform;
        var roundSetChanger = screen.FindChild("RoundSetChangerPanel");
        if (roundSetChanger == null && MelonMain.ShowRoundsetChanger)
        {
            CreatePanel(screen.gameObject);
        }
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
        foreach (var (id, image) in ticks)
        {
            image.SetActive(RoundSetOverride == id);
        }
    }

    private static void HideOptions()
    {
        optionsPanel.GetComponent<Animator>().Play("PopupScaleOut");
        TaskScheduler.ScheduleTask(() => optionsPanel.SetActive(false), ScheduleType.WaitForFrames, AnimationTicks);
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

    public static void EnsureHidden()
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

    public static void OnMenuChanged(string currentMenu, string newMenu)
    {
        if (ShowOnMenus.Contains(newMenu) && !ShowOnMenus.Contains(currentMenu))
        {
            Show();
        }

        if (ShowOnMenus.Contains(currentMenu) && !ShowOnMenus.Contains(newMenu))
        {
            Hide();
        }
    }
}