using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppInterop.Runtime.Attributes;
using Il2CppNinjaKiwi.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using Guid = Il2CppSystem.Guid;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// A ModHelperComponent for a custom Window that can be opened in game and behaves similarly to a desktop Window
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperWindow : ModHelperPanel
{
    /// <summary>
    /// The top row of the window
    /// </summary>
    public ModHelperPanel topBar;

    /// <summary>
    /// The right side group of the top bar, which by default features the Close / Options / Minimize buttons
    /// </summary>
    public ModHelperPanel topRightGroup;

    /// <summary>
    /// The left side group of the top bar, which by default features the Icon and window name
    /// </summary>
    public ModHelperPanel topLeftGroup;

    /// <summary>
    /// The center group of the top bar, which is by default empty
    /// </summary>
    public ModHelperPanel topCenterGroup;

    /// <summary>
    /// The main inset panel of the Window
    /// </summary>
    public ModHelperPanel main;

    /// <summary>
    /// The content panel of the Window where most UI should be added to
    /// </summary>
    public ModHelperPanel content;

    /// <summary>
    /// The icon of this window, if it has one
    /// </summary>
    public ModHelperImage icon;

    /// <summary>
    /// The title of this window, if it has one
    /// </summary>
    public ModHelperText title;

    /// <summary>
    /// The CanvasGroup at the root of this Window
    /// </summary>
    public CanvasGroup rootCanvas;

    /// <summary>
    /// The CanvasGroup of the content
    /// </summary>
    public CanvasGroup contentCanvas;

    private bool isDragging;
    private Vector2 dragOffset;

    private ModHelperPanel resizeIndicators;
    private ModHelperImage resizeLeft, resizeRight, resizeTop, resizeBot;
    private bool isNearTop, isNearBottom, isNearLeft, isNearRight;
    private bool isResizing;
    private Vector2 initialMousePosition;
    private Vector2 initialWindowSize;
    private Vector2 initialWindowPosition;

    internal Guid id;

    /// <summary>
    /// The button in the <see cref="topRightGroup"/> that can <see cref="Close"/> the window
    /// </summary>
    public ModHelperButton closeButton;

    /// <summary>
    /// The button in the <see cref="topRightGroup"/> that toggles the <see cref="rightClickMenu"/>
    /// </summary>
    public ModHelperButton settingsButton;

    /// <summary>
    /// The button in the <see cref="topRightGroup"/> that will Minimize the window
    /// </summary>
    public ModHelperButton minButton;

    /// <summary>
    /// The button on the dock for the window, or null if this window doesn't use one
    /// </summary>
    public ModHelperDockButton dockButton;

    /// <summary>
    /// Whether this window is locked
    /// </summary>
    public bool locked;

    /// <summary>
    /// The height of the topBar of the window
    /// </summary>
    public int topBarHeight;

    /// <summary>
    /// The minimum height of this window when resizing
    /// </summary>
    public float minHeight = 500;

    /// <summary>
    /// The minimum width of this window when resizing
    /// </summary>
    public float minWidth = 1000;

    /// <summary>
    /// Whether resizing is blocked for this window
    /// </summary>
    public bool noResizing;


    /// <summary>
    /// The options menu for the window
    /// </summary>
    public ModHelperPopupMenu rightClickMenu;

    /// <summary>
    /// The color option within the options menu
    /// </summary>
    public ModHelperPopupOption ColorOption => rightClickMenu.GetComponentFromChildrenByName<ModHelperPopupOption>("Color");

    /// <summary>
    /// The lock / unlock option within the options menu
    /// </summary>
    public ModHelperPopupOption LockOption => rightClickMenu.GetComponentFromChildrenByName<ModHelperPopupOption>("Lock");

    private bool nonRightClickOpened;

    private string windowColor = MelonMain.DefaultWindowColor;

    /// <summary>
    /// The current WindowColor theme of this window
    /// </summary>
    [HideFromIl2Cpp]
    public ModWindowColor WindowColor
    {
        get => windowColor;
        set => windowColor = value;
    }

    private string modWindow;

    /// <summary>
    /// The ModWindow definition used for this window, if any
    /// </summary>
    [HideFromIl2Cpp]
    public ModWindow ModWindow
    {
        get => ModWindow.Cache.GetValueOrDefault(modWindow ?? "", null);
        set => modWindow = value?.Id;
    }

    /// <summary>
    /// The default visual margin between elements
    /// </summary>
    public const int Margin = 25;

    /// <summary>
    /// How close the mouse needs to be for resizing
    /// </summary>
    public const int EdgeThreshold = 10;

    /// <inheritdoc />
    public ModHelperWindow(IntPtr ptr) : base(ptr)
    {
    }

    private void OnDestroy()
    {
        if (ModWindow != null)
        {
            if (InGame.instance == null || InGame.instance.quitting)
            {
                ModWindow?.SaveWindow(this);
            }
            else if (ModWindow.SavedWindows.Remove(id.ToString()))
            {
                ModWindow.saveSettingsAfterGame = true;
            }
        }

        ModWindow?.openedWindows.Remove(this);
        ModWindow?.OnClose(this);
        dockButton.gameObject.Destroy();
    }

    /// <summary>
    /// Creates a ModHelperWindow gameobject from a ModWindow definition
    /// </summary>
    /// <param name="modWindow">ModWindow definition</param>
    /// <returns>the created ModHelperWindow</returns>
    [HideFromIl2Cpp]
    public static ModHelperWindow Create(ModWindow modWindow)
    {
        var window = Create(modWindow.WindowInfo, modWindow.TopBarHeight, modWindow.ShowIconOnWindow ? modWindow.Icon : null,
            modWindow.ShowTitleOnWindow ? modWindow.DisplayName : null, modWindow.IconScale, modWindow.DockName);
        window.ModWindow = modWindow;

        window.minHeight = modWindow.MinimumHeight;
        window.minWidth = modWindow.MinimumWidth;
        window.noResizing = !modWindow.AllowResizing;

        window.UpdateWindowColor(modWindow.DefaultWindowColor);

        return window;
    }

    /// <summary>
    /// Creates a ModHelperWindow gameobject and adds it to the appropriate parent object for Windows.
    /// Also creates a corresponding <see cref="ModHelperDockButton"/> within the <see cref="ModHelperDock"/>
    /// </summary>
    /// <param name="info">the position / size / name info</param>
    /// <param name="topBarHeight">the height of the top bar</param>
    /// <param name="icon">the icon to display, or null for none</param>
    /// <param name="title">the title to display, or null for none</param>
    /// <param name="iconScale">visual scale for the icon</param>
    /// <param name="dockTitle">title for the dock button</param>
    /// <returns>the created ModHelperWindow</returns>
    public static ModHelperWindow Create(Info info, int topBarHeight = 50, string icon = null, string title = null,
        float iconScale = 1f, string dockTitle = null)
    {
        var window = Create<ModHelperWindow>(info, "");
        window.SetParent(ModHelperDock.WindowParent);

        window.Background.pixelsPerUnitMultiplier = 2;
        window.ApplyWindowColor(window, ModWindowColor.PanelType.Main);

        window.rootCanvas = window.AddComponent<CanvasGroup>();

        window.topBarHeight = topBarHeight;
        var topBar = window.topBar = window.AddPanel(new Info("TopBar")
        {
            AnchorMin = new Vector2(0, 1),
            AnchorMax = new Vector2(1, 1),
            Pivot = new Vector2(0.5f, 1),
            Height = topBarHeight + Margin
        });

        var topLeftGroup = window.topLeftGroup = topBar.AddPanel(new Info("LeftGroup")
        {
            Anchor = new Vector2(0, 1),
            Pivot = new Vector2(0, 1)
        }, null, RectTransform.Axis.Horizontal, Margin);
        topLeftGroup.LayoutGroup.padding = new RectOffset
        {
            top = Margin / 2,
            left = Margin
        };
        topLeftGroup.LayoutGroup.childAlignment = TextAnchor.UpperLeft;

        if (icon != null)
        {
            var image = window.icon = topLeftGroup.AddImage(new Info("Icon", topBarHeight), icon);
            image.Image.enabled = !string.IsNullOrWhiteSpace(icon);
            window.icon.transform.localScale = Vector3.one * iconScale;
        }

        if (title != null)
        {
            window.title = topLeftGroup.AddText(new Info("Title", 1000, topBarHeight), title);
            window.title.SizeWidthToText();
        }

        var fitter = topLeftGroup.AddComponent<ContentSizeFitter>();
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;


        var topCenterGroup = window.topCenterGroup = topBar.AddPanel(new Info("CenterGroup")
        {
            Anchor = new Vector2(0.5f, 1)
        }, null, RectTransform.Axis.Horizontal, Margin);
        topCenterGroup.LayoutGroup.padding = new RectOffset
        {
            top = Margin / 2
        };
        topCenterGroup.LayoutGroup.childAlignment = TextAnchor.UpperCenter;

        fitter = topCenterGroup.AddComponent<ContentSizeFitter>();
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;


        var topRightGroup = window.topRightGroup = topBar.AddPanel(new Info("RightGroup")
        {
            Anchor = new Vector2(1, 1),
            Pivot = new Vector2(1, 1)
        }, null, RectTransform.Axis.Horizontal, Margin);

        topRightGroup.LayoutGroup.padding = new RectOffset
        {
            top = Margin / 2,
            right = Margin / 2
        };
        topRightGroup.LayoutGroup.childAlignment = TextAnchor.UpperRight;
        topRightGroup.LayoutGroup.reverseArrangement = true;

        fitter = topRightGroup.AddComponent<ContentSizeFitter>();
        fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        var closeButton = window.closeButton = topRightGroup.AddButton(new Info("Close", topBarHeight),
                              VanillaSprites.SmallSquareWhiteGradient, new Action(window.Close));
        closeButton.AddImage(new Info("Image", InfoPreset.FillParent), VanillaSprites.CloseIcon);
        closeButton.Button.UseBackgroundTint();

        var settingsButton = window.settingsButton = topRightGroup.AddButton(new Info("SettingsButton", topBarHeight),
                                 VanillaSprites.SmallSquareWhiteGradient, new Action(() =>
                                 {
                                     window.nonRightClickOpened = true;
                                     window.OpenRightClickMenu();
                                 }));
        settingsButton.AddImage(new Info("Image", InfoPreset.FillParent), VanillaSprites.SettingsIcon);
        settingsButton.Button.UseBackgroundTint();

        var minButton = window.minButton = topRightGroup.AddButton(new Info("Minimize", topBarHeight),
                            VanillaSprites.SmallSquareWhiteGradient, new Action(window.ToggleMinimized));
        minButton.AddImage(new Info("Image", InfoPreset.FillParent), ModHelperSprites.Minus);
        minButton.Button.UseBackgroundTint();

        var main = window.main = window.AddPanel(new Info("Main")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 1),
            Pivot = new Vector2(0.5f, 1)
        }, "");
        window.ApplyWindowColor(main, ModWindowColor.PanelType.Insert);
        main.RectTransform.offsetMin = new Vector2(0, 0);
        main.RectTransform.offsetMax = new Vector2(0, -Margin - topBarHeight);

        var content = window.content = main.AddPanel(new Info("Content", InfoPreset.FillParent)
        {
            Pivot = new Vector2(0.5f, 1)
        });
        var contentCanvas = window.contentCanvas = content.AddComponent<CanvasGroup>();
        contentCanvas.ignoreParentGroups = true;


        var resizeIndicators = window.resizeIndicators = window.AddPanel(new Info("ResizeIndicators"));
        resizeIndicators.SetActive(false);

        window.resizeRight = resizeIndicators.AddImage(new Info("Right", 25, 0, 50), VanillaSprites.NextArrowSmall);
        window.resizeRight.transform.localRotation = Quaternion.Euler(0, 0, 0);

        window.resizeLeft = resizeIndicators.AddImage(new Info("Left", -25, 0, 50), VanillaSprites.NextArrowSmall);
        window.resizeLeft.transform.localRotation = Quaternion.Euler(0, 180, 0);

        window.resizeTop = resizeIndicators.AddImage(new Info("Top", 0, 25, 50), VanillaSprites.NextArrowSmall);
        window.resizeTop.transform.localRotation = Quaternion.Euler(0, 0, 90);

        window.resizeBot = resizeIndicators.AddImage(new Info("Bot", 0, 25, 50), VanillaSprites.NextArrowSmall);
        window.resizeBot.transform.localRotation = Quaternion.Euler(0, 0, -90);


        window.rightClickMenu = ModHelperPopupMenu.Create(new Info("RightClickMenu"));
        window.Add(window.rightClickMenu);
        window.ApplyWindowColor(window.rightClickMenu, ModWindowColor.PanelType.Main);

        var colorsMenu = CreateColorsMenu(color => window.UpdateWindowColor(color), color => window.WindowColor == color);
        window.ApplyWindowColor(colorsMenu, ModWindowColor.PanelType.Main);

        window.rightClickMenu.AddOption(new Info("Color"), icon: window.WindowColor.MainPanelSprite, subMenu: colorsMenu);
        window.rightClickMenu.AddOption(new Info("Lock"), icon: VanillaSprites.LockIcon,
            action: new Action(window.ToggleLocked));

        var opacityMenu = ModHelperPopupMenu.Create(new Info("Opacity"));
        foreach (var (kind, canvas) in new[] {("Background", window.rootCanvas), ("Foreground", window.contentCanvas)})
        {
            foreach (var opacity in (float[]) [1f, .75f, .5f, .25f])
            {
                opacityMenu.AddOption(new Info($"{kind} {opacity:P0}"),
                    action: new Action(() => canvas.alpha = opacity),
                    isSelected: new Func<bool>(() => Mathf.Approximately(canvas.alpha, opacity)));
            }
            if (kind != "Foreground")
            {
                opacityMenu.AddSeparator();
            }
        }
        window.ApplyWindowColor(opacityMenu, ModWindowColor.PanelType.Main);

        window.rightClickMenu.AddOption(new Info("Opacity"), icon: ModHelperSprites.Transparency, subMenu: opacityMenu);

        window.rightClickMenu.AddComponent<CanvasGroup>().ignoreParentGroups = true;

        window.dockButton = ModHelperDockButton.Create(ModHelperDock.Instance, window, icon, iconScale, dockTitle);

        window.id = Guid.NewGuid();

        return window;
    }

    [HideFromIl2Cpp]
    internal static ModHelperPopupMenu CreateColorsMenu(Action<ModWindowColor> colorCallback,
        Func<ModWindowColor, bool> isSelected)
    {
        var colorsMenu = ModHelperPopupMenu.Create(new Info("Colors"));

        foreach (var color in ModContent.GetContent<ModWindowColor>())
        {
            colorsMenu.AddOption(new Info(color.Name, 350, 75), color.DisplayName,
                color.MainPanelSprite, new Action(() => colorCallback(color)),
                isSelected: new Func<bool>(() => isSelected(color)));
        }

        return colorsMenu;
    }

    /// <summary>
    /// Toggles whether this window is Locked, and cant be moved / resized / left clicked normally
    /// </summary>
    public void ToggleLocked()
    {
        locked = !locked;

        if (locked && nonRightClickOpened)
        {
            Game.instance.ShowMessage("Right Click Window to Unlock");
        }
    }

    /// <summary>
    /// Whether this window is minimized or not
    /// </summary>
    public bool IsMinimized => !gameObject.active;

    /// <summary>
    /// Toggles whether this window is minimized to the dock
    /// </summary>
    public void ToggleMinimized()
    {
        if (gameObject.active)
        {
            ModWindow?.OnMinimized(this);
            gameObject.SetActive(false);
        }
        else
        {
            ModWindow?.OnUnMinimized(this);
            HandleTopBarOverlap();
            gameObject.SetActive(true);
            transform.SetAsLastSibling();
        }
    }

    /// <summary>
    /// Applies the current window color to a game object and keeps track of it as part of this window
    /// </summary>
    /// <param name="gobject">Game object that has an Image component</param>
    /// <param name="type">panel type</param>
    public void ApplyWindowColor(GameObject gobject, ModWindowColor.PanelType type)
    {
        var setter = WindowColor.Apply(gobject, type);
        setter.window = this;
    }

    /// <summary>
    /// Updates the WindowColor theme for this window
    /// </summary>
    /// <param name="newColor">new WindowColor theme</param>
    public void UpdateWindowColor(string newColor)
    {
        windowColor = newColor;

        foreach (var setter in FindObjectsOfType<WindowColorSetter>(true).Where(setter => setter.window == this))
        {
            setter.SetColor(newColor);
        }
    }

    private Vector2 LocalMousePos => transform.parent.Cast<RectTransform>().MousePositionLocal(true);

    internal static GameObject RaycastedGameObject
    {
        get
        {
            var raycastResults = new Il2CppSystem.Collections.Generic.List<RaycastResult>();
            var data = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            EventSystem.current.RaycastAll(data, raycastResults);

            return raycastResults.FirstOrDefault()?.gameObject;
        }
    }

    /// <summary>
    /// Open the Options Menu for this window at the current mouse position. Will handle changing the menu's position
    /// if it would be off screen
    /// </summary>
    public void OpenRightClickMenu()
    {
        ColorOption.icon.Image.SetSprite(WindowColor.MainPanelSprite);

        LockOption.icon.Image.SetSprite(locked ? VanillaSprites.LockIconOpen : VanillaSprites.LockIcon);
        LockOption.text.Text.SetText(locked ? "Unlock" : "Lock");

        FixRightClickMenuPosition();

        rightClickMenu.parentComponent = nonRightClickOpened ? settingsButton : null;
        // rightClickMenu.GetComponent<CanvasGroup>().alpha = contentCanvas.alpha;

        rightClickMenu.Show();

        if (rightClickMenu.RectTransform.rect == Rect.zero)
        {
            Invoke(nameof(FixRightClickMenuPosition), Time.deltaTime);
        }
    }

    private void FixRightClickMenuPosition()
    {
        rightClickMenu.RectTransform.pivot = new Vector2(0, 1);
        rightClickMenu.transform.position = Input.mousePosition;

        LayoutRebuilder.ForceRebuildLayoutImmediate(rightClickMenu);

        if (IsOutsideScreenRight(rightClickMenu))
        {
            rightClickMenu.RectTransform.pivot = rightClickMenu.RectTransform.pivot with
            {
                x = 1
            };
        }

        if (IsOutsideScreenBottom(rightClickMenu))
        {
            rightClickMenu.RectTransform.pivot = rightClickMenu.RectTransform.pivot with
            {
                y = 0
            };
        }
    }

    /// <summary>
    /// Closes this Window
    /// </summary>
    public void Close()
    {
        gameObject.Destroy();
    }

    private void Update()
    {
        HandleResizing();
        HandleDragging();
        HandleFocus();
        HandleRightClick();

        if (InGame.instance is not null && InGame.Bridge is not null)
        {
            ModWindow?.OnUpdate(this);
        }
    }

    private void HandleDragging()
    {
        if (locked)
        {
            isDragging = false;
            return;
        }

        var localMousePos = LocalMousePos;

        if (isDragging)
        {
            var oldPos = RectTransform.anchoredPosition;
            RectTransform.localPosition = localMousePos - dragOffset;
            var newPos = RectTransform.anchoredPosition;

            ModWindow?.OnMove(this, oldPos, newPos);
        }

        if (Input.GetMouseButtonDown((int) MouseButton.Left) && !isResizing)
        {
            if (RaycastedGameObject is { } target &&
                (target == topBar.gameObject ||
                 target == gameObject ||
                 target == icon?.gameObject ||
                 target == title?.gameObject))
            {
                isDragging = true;
                dragOffset = localMousePos - (Vector2) RectTransform.localPosition;
            }
        }
        else if (!Input.GetMouseButton((int) MouseButton.Left))
        {
            isDragging = false;
        }
    }

    private void HandleResizing()
    {
        if (locked || noResizing)
        {
            isResizing = false;
            resizeLeft.SetActive(false);
            resizeRight.SetActive(false);
            resizeTop.SetActive(false);
            resizeBot.SetActive(false);
            resizeIndicators.SetActive(false);
            return;
        }

        var localMousePosition = LocalMousePos;

        if (!isResizing)
        {
            var rect = RectTransform.rect;
            Vector2 rectPosition = RectTransform.localPosition;
            var leftEdge = rectPosition.x - rect.width * RectTransform.pivot.x;
            var rightEdge = rectPosition.x + rect.width * (1 - RectTransform.pivot.x);
            var topEdge = rectPosition.y + rect.height * (1 - RectTransform.pivot.y);
            var bottomEdge = rectPosition.y - rect.height * RectTransform.pivot.y;

            isNearTop = topEdge - localMousePosition.y is < EdgeThreshold and >= 0;
            isNearBottom = localMousePosition.y - bottomEdge is < EdgeThreshold and >= 0;
            isNearLeft = localMousePosition.x - leftEdge is < EdgeThreshold and >= 0;
            isNearRight = rightEdge - localMousePosition.x is < EdgeThreshold and >= 0;

            resizeLeft.SetActive(isNearLeft);
            resizeRight.SetActive(isNearRight);
            resizeTop.SetActive(isNearTop);
            resizeBot.SetActive(isNearBottom);
        }

        var anyActive = isNearTop || isNearBottom || isNearLeft || isNearRight;
        resizeIndicators.SetActive(anyActive);

        if (anyActive)
        {
            resizeIndicators.transform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown((int) MouseButton.Left))
            {
                if (RaycastedGameObject is { } target && target.transform.IsChildOf(transform))
                {
                    isResizing = true;
                    initialMousePosition = localMousePosition;
                    initialWindowSize = RectTransform.sizeDelta;
                    initialWindowPosition = RectTransform.localPosition;
                }
            }
        }

        if (!Input.GetMouseButton((int) MouseButton.Left))
        {
            isResizing = false;
        }

        if (!isResizing) return;

        var deltaMousePosition = LocalMousePos - initialMousePosition;
        var newSize = initialWindowSize;
        var oldSize = RectTransform.sizeDelta;
        var direction = new Vector2(0, 0);

        if (isNearLeft)
        {
            newSize.x = initialWindowSize.x - deltaMousePosition.x;
            direction.x = -(1 - RectTransform.pivot.x);
        }
        if (isNearRight)
        {
            newSize.x = initialWindowSize.x + deltaMousePosition.x;
            direction.x = RectTransform.pivot.x;
        }
        if (isNearTop)
        {
            newSize.y = initialWindowSize.y + deltaMousePosition.y;
            direction.y = RectTransform.pivot.y;
        }
        if (isNearBottom)
        {
            newSize.y = initialWindowSize.y - deltaMousePosition.y;
            direction.y = -(1 - RectTransform.pivot.y);
        }

        if (newSize.x < minWidth)
        {
            newSize.x = minWidth;
        }
        if (newSize.y < minHeight)
        {
            newSize.y = minHeight;
        }

        RectTransform.localPosition = initialWindowPosition + direction * (newSize - initialWindowSize);

        RectTransform.sizeDelta = newSize;

        if (oldSize == newSize) return;

        ModWindow?.OnResize(this, oldSize, newSize);
        HandleTopBarOverlap();
    }

    private void HandleTopBarOverlap()
    {
        if (ModWindow?.HideOverlappingTopBarItems == false) return;

        foreach (var child in topLeftGroup.GetChildren().OfIl2CppType<RectTransform>())
        {
            if (!topBar.RectTransform.FullyContains(child) && child != icon?.RectTransform ||
                child.OverlapsWith(topRightGroup))
            {
                var cg = child.gameObject.GetComponentOrAdd<CanvasGroup>();
                cg.alpha = 0;
                cg.blocksRaycasts = false;
                cg.interactable = false;
            }
            else if (child.gameObject.HasComponent(out CanvasGroup cg))
            {
                cg.alpha = 1;
                cg.blocksRaycasts = true;
                cg.interactable = true;
            }
        }
    }

    private void HandleFocus()
    {
        rootCanvas.blocksRaycasts = !locked || rightClickMenu.gameObject.active;
        contentCanvas.blocksRaycasts = !locked || rightClickMenu.gameObject.active;

        if (Input.GetMouseButton((int) MouseButton.Left) &&
            RaycastedGameObject is { } target &&
            target.transform.IsChildOf(transform))
        {
            transform.SetAsLastSibling();
        }
    }

    private void HandleRightClick()
    {
        if (!Input.GetMouseButtonUp((int) MouseButton.Right)) return;

        var prev = rootCanvas.blocksRaycasts;
        rootCanvas.blocksRaycasts = true;
        var targeted = RaycastedGameObject is { } target &&
                       target.transform.IsChildOf(transform) &&
                       !target.transform.IsChildOf(rightClickMenu.transform);
        rootCanvas.blocksRaycasts = prev;

        if (targeted)
        {
            if (rightClickMenu.IsShowing)
            {
                rightClickMenu.Hide();
            }

            transform.SetAsLastSibling();
            nonRightClickOpened = false;
            OpenRightClickMenu();
        }
    }

    internal static bool IsOutsideScreenRight(RectTransform rectTransform) =>
        ScreenEdgeCheck(rectTransform, bounds => bounds.Max(b => b.x));

    internal static bool IsOutsideScreenLeft(RectTransform rectTransform) =>
        !ScreenEdgeCheck(rectTransform, bounds => bounds.Min(b => b.x));

    internal static bool IsOutsideScreenTop(RectTransform rectTransform) =>
        ScreenEdgeCheck(rectTransform, bounds => bounds.Max(b => b.y));

    internal static bool IsOutsideScreenBottom(RectTransform rectTransform) =>
        !ScreenEdgeCheck(rectTransform, bounds => bounds.Min(b => b.y));

    private static bool ScreenEdgeCheck(RectTransform rectTransform, Func<IEnumerable<Vector3>, float> getEdge)
    {
        var screenBounds = new Il2CppStructArray<Vector3>(4);
        ModHelperDock.WindowParent.GetWorldCorners(screenBounds);
        var screenEdge = getEdge(screenBounds);

        var panelBounds = new Il2CppStructArray<Vector3>(4);
        rectTransform.GetWorldCorners(panelBounds);
        var panelEdge = getEdge(panelBounds);

        return panelEdge > screenEdge;
    }
}