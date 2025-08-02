using System;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a background panel
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperScrollPanel : ModHelperPanel
{

    /// <inheritdoc />
    public ModHelperScrollPanel(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// The ScrollContent object. This is the object that the children are actually part of,
    /// and is what actually moves up and down when scrolling.
    /// </summary>
    public ModHelperPanel ScrollContent => GetDescendent<ModHelperPanel>("ScrollContent");

    /// <summary>
    /// The ScrollRect component which controls many aspects of scrolling
    /// </summary>
    public ScrollRect ScrollRect => GetComponent<ScrollRect>();

    /// <summary>
    /// The Mask component which prevents overflow of rendering outside the scroll area
    /// </summary>
    public Mask Mask => GetComponent<Mask>();

    /// <summary>
    /// The ContentSizeFitter component which makes sure that the ScrollContent
    /// is the right size to hold all the scrollable items.
    /// </summary>
    public ContentSizeFitter ContentSizeFitter { get; private set; }

    /// <summary>
    /// Adds a child to the ScrollContent of this panel
    /// </summary>
    public void AddScrollContent(ModHelperComponent child)
    {
        ScrollContent.Add(child);
    }

    /// <summary>
    /// By default, ModHelperScrollPanels use themselves as the scroll viewport. This method separates it into
    /// two different objects. Useful for having the viewport change size based on scrollbar presence.
    /// </summary>
    public void UseInnerViewport()
    {
        if (ScrollRect.viewport != ScrollRect.rectTransform) return;

        var viewport = AddPanel(new Info("Viewport")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 1),
            Pivot = new Vector2(0, 1)
        });
        viewport.AddComponent<Image>();
        var mask = viewport.AddComponent<Mask>();
        mask.showMaskGraphic = false;

        ScrollContent.initialInfo = ScrollContent.initialInfo with
        {
            Pivot = new Vector2(0, 1)
        };
        ScrollContent.SetParent(viewport);

        ScrollRect.viewport = viewport;

        RemoveComponent<Mask>();
    }

    /// <inheritdoc cref="AddHorizontalScrollbar(BTD_Mod_Helper.Api.Components.Info,string,string,UnityEngine.UI.ScrollRect.ScrollbarVisibility)"/>
    public Scrollbar AddHorizontalScrollbar(float height, string trackSprite = "", string handleSprite = "",
        ScrollRect.ScrollbarVisibility visibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport) =>
        AddHorizontalScrollbar(new Info("HorizontalScrollbar")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 0),
            Height = height
        }, trackSprite, handleSprite, visibility);

    /// <summary>
    /// Adds a horizontal scrollbar to this scroll panel
    /// </summary>
    /// <param name="info">size info for the scrollbar track</param>
    /// <param name="trackSprite">sprite for the background track of the scrollbar</param>
    /// <param name="handleSprite">sprite for the foreground handle of the scrollbar</param>
    /// <param name="visibility">scrollbar visibility setting</param>
    /// <returns>the created ScrollBar</returns>
    public Scrollbar AddHorizontalScrollbar(Info info, string trackSprite = "", string handleSprite = "",
        ScrollRect.ScrollbarVisibility visibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport)
    {
        if (ScrollRect.horizontalScrollbar.Exists(out Scrollbar scrollbar)) return scrollbar;

        scrollbar = CreateScrollbar(info, trackSprite, handleSprite);
        scrollbar.direction = Scrollbar.Direction.LeftToRight;

        var scrollRect = ScrollRect;
        scrollRect.horizontalScrollbar = scrollbar;
        scrollRect.horizontalScrollbarVisibility = visibility;

        scrollbar.onValueChanged.AddListener(new Action<float>(pos => scrollRect.horizontalNormalizedPosition = pos));

        return scrollbar;
    }

    /// <inheritdoc cref="AddVerticalScrollbar(BTD_Mod_Helper.Api.Components.Info,string,string,UnityEngine.UI.ScrollRect.ScrollbarVisibility)"/>
    public Scrollbar AddVerticalScrollbar(float width, string trackSprite = "", string handleSprite = "",
        ScrollRect.ScrollbarVisibility visibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport) =>
        AddVerticalScrollbar(new Info("VerticalScrollbar")
        {
            AnchorMin = new Vector2(1, 0),
            AnchorMax = new Vector2(1, 1),
            Pivot = new Vector2(1, 0.5f),
            Width = width
        }, trackSprite, handleSprite, visibility);

    /// <summary>
    /// Adds a vertical scrollbar to this scroll panel
    /// </summary>
    /// <param name="info">size info for the scrollbar track</param>
    /// <param name="trackSprite">sprite for the background track of the scrollbar</param>
    /// <param name="handleSprite">sprite for the foreground handle of the scrollbar</param>
    /// <param name="visibility">scrollbar visibility setting</param>
    /// <returns>the created ScrollBar</returns>
    public Scrollbar AddVerticalScrollbar(Info info, string trackSprite = "", string handleSprite = "",
        ScrollRect.ScrollbarVisibility visibility = ScrollRect.ScrollbarVisibility.AutoHideAndExpandViewport)
    {
        if (ScrollRect.verticalScrollbar.Exists(out Scrollbar scrollbar)) return scrollbar;

        scrollbar = CreateScrollbar(info, trackSprite, handleSprite);
        scrollbar.direction = Scrollbar.Direction.BottomToTop;

        var scrollRect = ScrollRect;
        scrollRect.verticalScrollbar = scrollbar;
        scrollRect.verticalScrollbarVisibility = visibility;

        scrollbar.onValueChanged.AddListener(new Action<float>(pos => scrollRect.verticalNormalizedPosition = pos));

        return scrollbar;
    }

    private Scrollbar CreateScrollbar(Info info, string trackSprite, string handleSprite)
    {
        if (ScrollRect.viewport == ScrollRect.rectTransform)
        {
            UseInnerViewport();
        }

        var scrollTrack = AddPanel(info, trackSprite);

        var scrollbar = scrollTrack.AddComponent<Scrollbar>();

        var handle = scrollTrack.AddImage(new Info("Handle", InfoPreset.FillParent), handleSprite);
        handle.AddComponent<Selectable>();
        handle.Image.type = Image.Type.Sliced;

        scrollbar.handleRect = handle;



        return scrollbar;
    }

    /// <inheritdoc cref="Create{T}" />
    public static ModHelperScrollPanel Create(Info info, RectTransform.Axis? axis,
        string backgroundSprite = null, float spacing = 0, int padding = 0) =>
        Create<ModHelperScrollPanel>(info, axis, backgroundSprite, spacing, padding);

    /// <summary>
    /// Creates a new ModHelperScrollPanel
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="axis">The axis that it scrolls in, or null for both directions</param>
    /// <param name="backgroundSprite">The panel's background sprite</param>
    /// <param name="spacing">If axis is not null, then the layout spacing for the items</param>
    /// <param name="padding"></param>
    /// <returns>The created ModHelperScrollPanel</returns>
    public static T Create<T>(Info info, RectTransform.Axis? axis,
        string backgroundSprite = null, float spacing = 0, int padding = 0) where T : ModHelperScrollPanel
    {
        var newPanel = Create<T>(info, backgroundSprite);
        var scrollRect = newPanel.AddComponent<ScrollRect>();

        var scrollContent = newPanel.AddPanel(new Info("ScrollContent")
        {
            AnchorMin = new Vector2(
                axis == RectTransform.Axis.Vertical ? 0 : 0.5f,
                axis == RectTransform.Axis.Horizontal ? 0 : 0.5f),
            AnchorMax = new Vector2(
                axis == RectTransform.Axis.Vertical ? 1 : 0.5f,
                axis == RectTransform.Axis.Horizontal ? 1 : 0.5f)
        }, null, axis, spacing, padding);
        scrollContent.SetParent(newPanel);


        scrollContent.AddComponent<NK_TextMeshProUGUI>(); // so that everywhere in the content window is draggable
        scrollRect.content = scrollContent.RectTransform;
        scrollRect.content.pivot = new Vector2(0.5f, 1);
        scrollRect.viewport = newPanel.RectTransform;
        scrollRect.scrollSensitivity = 100;

        newPanel.AddComponent<Mask>();

        if (axis != null)
        {
            var contentSizeFitter = newPanel.ContentSizeFitter = scrollContent.AddComponent<ContentSizeFitter>();
            if (axis == RectTransform.Axis.Horizontal)
            {
                scrollRect.vertical = false;
                contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
                contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.Unconstrained;
            }
            else
            {
                scrollRect.horizontal = false;
                contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
                contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            }
        }


        return newPanel;
    }
}