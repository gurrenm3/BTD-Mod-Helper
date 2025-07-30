using System;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent controlling the Dock used for <see cref="ModHelperWindow"/>s
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public sealed class ModHelperDock : ModHelperPanel
{
    internal enum Visibility
    {
        Default,
        Hovered,
        Never
    }

    /// <summary>
    /// Parent object that windows are added to
    /// </summary>
    public static RectTransform WindowParent { get; private set; } = null!;

    /// <summary>
    /// Current instance of the Dock
    /// </summary>
    public static ModHelperDock Instance { get; private set; } = null!;


    /// <summary>
    /// The plus button that opens the start menu, or null if there are no start menu entries
    /// </summary>
    public ModHelperButton startButton;

    /// <summary>
    /// The menu opened which lists the available windows, or null if there are no start menu entries
    /// </summary>
    public ModHelperPopupMenu startMenu;

    /// <summary>
    /// The canvas group for the dock
    /// </summary>
    public CanvasGroup canvasGroup;

    /// <inheritdoc />
    public ModHelperDock(IntPtr ptr) : base(ptr)
    {
    }

    private static bool setupBefore;

    /// <inheritdoc />
    protected override void OnUpdate()
    {
        var visibility = MelonMain.DockVisibility.value;

        if (startMenu is null || startButton is null) return;

        var showing = visibility switch
        {
            Visibility.Never => false,
            Visibility.Hovered => startMenu.IsShowing || RectTransform.ContainsScreenPoint(Input.mousePosition),
            _ => true
        };

        canvasGroup.alpha = showing ? 1 : 0;
        canvasGroup.blocksRaycasts = showing;
        canvasGroup.interactable = showing;
    }

    internal static void UpdatePosition(int width, int height)
    {
        if (InGame.instance == null) return;

        var dock = Instance;

        dock.RemoveComponent<HorizontalLayoutGroup>();
        dock.RemoveComponent<VerticalLayoutGroup>();

        RectTransform parent;

        var aspectRatio = AspectRatios.From(width, height);
        switch (aspectRatio)
        {
            case AspectRatio.NonWidescreen:
                parent = InGame.instance.transform.GetComponentFromChildrenByName<RectTransform>("ExtraBottomPattern");
                dock.initialInfo = dock.initialInfo with
                {
                    AnchorMin = new Vector2(0.5f, 0.5f),
                    AnchorMax = new Vector2(0.5f, 0.5f),
                    Pivot = new Vector2(0.5f, 0.5f),
                    Height = 75,
                    Width = 2400,
                    X = 0,
                    Y = -60
                };

                dock.AddComponent<HorizontalLayoutGroup>();
                dock.LayoutGroup.childAlignment = TextAnchor.MiddleCenter;
                dock.LayoutGroup.spacing = 25;

                dock.RectTransform.localRotation = Quaternion.Euler(0, 0, 180);
                WindowParent.offsetMin = new Vector2(0, 120);
                break;
            case AspectRatio.TallWidescreen:
                parent = InGame.instance.transform.GetComponentFromChildrenByName<RectTransform>("BlackBarB");
                dock.initialInfo = dock.initialInfo with
                {
                    AnchorMin = new Vector2(0.5f, 1),
                    AnchorMax = new Vector2(0.5f, 1),
                    Pivot = new Vector2(0.5f, 1),
                    Height = 100,
                    Width = 4160,
                    X = 0,
                    Y = 0
                };

                dock.AddComponent<HorizontalLayoutGroup>();
                dock.LayoutGroup.childAlignment = TextAnchor.MiddleLeft;
                dock.LayoutGroup.spacing = 25;

                dock.RectTransform.localRotation = Quaternion.Euler(0, 0, 0);
                WindowParent.offsetMin = new Vector2(0, 0);
                break;
            case AspectRatio.Widescreen:
                parent = InGame.instance.transform.GetComponentFromChildrenByName<RectTransform>("BlackBarL");
                dock.initialInfo = dock.initialInfo with
                {
                    AnchorMin = new Vector2(1, 0),
                    AnchorMax = new Vector2(1, 1),
                    Pivot = new Vector2(1, 0),
                    Height = 0,
                    Width = 55,
                    X = -5,
                    Y = 0
                };

                dock.AddComponent<VerticalLayoutGroup>();
                dock.LayoutGroup.childAlignment = TextAnchor.LowerCenter;
                dock.LayoutGroup.reverseArrangement = true;
                dock.LayoutGroup.spacing = 10;

                dock.RectTransform.localRotation = Quaternion.Euler(0, 0, 0);
                WindowParent.offsetMin = new Vector2(0, 0);
                break;
            default:
                throw new IndexOutOfRangeException(nameof(AspectRatio));
        }

        dock.LayoutGroup.childForceExpandHeight = false;
        dock.LayoutGroup.childForceExpandWidth = false;

        foreach (var dockButton in FindObjectsOfType<ModHelperDockButton>())
        {
            dockButton.UpdatePosition(width, height);
        }

        if (dock.startButton != null)
        {
            var startLayout = dock.startButton.LayoutElement;
            var s = 55 * ModHelperDockButton.Scale(aspectRatio);
            startLayout.preferredHeight = startLayout.minHeight = startLayout.preferredWidth = startLayout.minWidth = s;
        }

        Instance.SetParent(parent);
    }

    internal static void Setup()
    {
        var dock = Create<ModHelperDock>(new Info("Dock"), null, RectTransform.Axis.Vertical, 10);
        dock.LayoutGroup.childAlignment = TextAnchor.LowerCenter;
        dock.LayoutGroup.reverseArrangement = true;

        dock.canvasGroup = dock.AddComponent<CanvasGroup>();

        // var fitter = dock.AddComponent<ContentSizeFitter>();
        // fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        // fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        Instance = dock;

        var mapRect = InGame.instance.GetComponentInChildren<InGameMapRect>();
        WindowParent = mapRect.transform.GetComponentFromChildrenByName<RectTransform>("--layer placeholder--");

        WindowParent.gameObject.name = "Windows";
        WindowParent.anchorMin = new Vector2(0, 0);
        WindowParent.anchorMax = new Vector2(1, 1);

        // Change the hitbox of the rounds label to not be extra big unnecessarily
        var roundButton = MainHudRightAlign.instance.roundButton.gameObject.transform.Cast<RectTransform>();
        var prevOffsetMin = roundButton.offsetMin;
        var prevOffsetMax = roundButton.offsetMax;
        roundButton.pivot = new Vector2(1, 0.5f);
        roundButton.offsetMin = prevOffsetMin;
        roundButton.offsetMax = prevOffsetMax;
        roundButton.sizeDelta = roundButton.sizeDelta with
        {
            x = 200
        };
        MainHudRightAlign.instance.roundObj.GetComponentInChildrenByName<NK_TextMeshProUGUI>("Title").raycastTarget = false;

        var entries = ModContent.GetContent<ModStartMenuEntry>()
            .Where(entry => !entry.DontAddToStartMenu && entry.ParentEntry == null)
            .ToArray();

        if (entries.Any())
        {
            var startMenu = dock.startMenu = ModHelperPopupMenu.Create(new Info("StartMenu")
            {
                Pivot = new Vector2(0, 0),
                Anchor = new Vector2(0, 0),
                Position = new Vector2(ModHelperWindow.Margin, ModHelperWindow.Margin),
            });
            startMenu.SetParent(WindowParent);

            MelonMain.CurrentDefaultWindowColor.Apply(startMenu, ModWindowColor.PanelType.Main);

            foreach (var entry in entries)
            {
                entry.AddEntry(startMenu);
            }

            startMenu.AddSeparator();

            startMenu.AddOption(new Info("Options"), icon: VanillaSprites.SettingsIcon, subMenu:
                ModHelperPopupMenu.Create(new Info("Options Options"))
                    .AddOption(new Info("Visibility"), subMenu:
                        ModHelperPopupMenu.Create(new Info("Visibility Options"))
                            .AddOption(new Info("Default"),
                                action: new Action(() => MelonMain.DockVisibility.SetValueAndSave(Visibility.Default)),
                                isSelected: new Func<bool>(() => MelonMain.DockVisibility == Visibility.Default)
                            )
                            .AddOption(new Info("Hovered"),
                                action: new Action(() => MelonMain.DockVisibility.SetValueAndSave(Visibility.Hovered)),
                                isSelected: new Func<bool>(() => MelonMain.DockVisibility == Visibility.Hovered)
                            )
                            .AddOption(new Info("Hidden"), action: new Action(() =>
                                {
                                    MelonMain.DockVisibility.SetValueAndSave(Visibility.Never);
                                    Game.instance.ShowMessage("Go into Mod Helper settings to re enable the dock");
                                }),
                                isSelected: new Func<bool>(() => MelonMain.DockVisibility == Visibility.Never)
                            )
                    )
            );

            var startButton = dock.startButton = dock.AddButton(new Info("Start", 60),
                                  VanillaSprites.SmallSquareWhiteGradient, new Action(() =>
                                  {
                                      startMenu.Show();
                                      startMenu.transform.SetAsLastSibling();
                                  }));
            startButton.AddImage(new Info("Image", InfoPreset.FillParent),
                ModContent.GetTextureGUID<MelonMain>("IconMinimal"));
            startButton.Button.UseBackgroundTint();

            startMenu.parentComponent = startButton;
        }
        else
        {
            dock.startButton = null;
            dock.startMenu = null;
        }

        var screenSize = ScreenResizeDetector.Instance;
        if (!setupBefore)
        {
            screenSize.onScreenSizeChanged += new Action<int, int>(UpdatePosition);
            setupBefore = true;
        }

        UpdatePosition(screenSize.currentWidth, screenSize.currentHeight);
    }

}