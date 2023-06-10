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
    /// Creates a new ModHelperScrollPanel
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="axis">The axis that it scrolls in, or null for both directions</param>
    /// <param name="backgroundSprite">The panel's background sprite</param>
    /// <param name="spacing">If axis is not null, then the layout spacing for the items</param>
    /// <param name="padding"></param>
    /// <returns>The created ModHelperScrollPanel</returns>
    public static ModHelperScrollPanel Create(Info info, RectTransform.Axis? axis,
        string backgroundSprite = null, float spacing = 0, int padding = 0)
    {
        var newPanel = Create<ModHelperScrollPanel>(info, backgroundSprite);
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