using System;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a background panel
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperPanel : ModHelperComponent
{

    /// <inheritdoc />
    public ModHelperPanel(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// The background image
    /// </summary>
    public Image Background => GetComponent<Image>();

    /// <summary>
    /// Creates a new ModHelperPanel
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="backgroundSprite">The panel's background sprite</param>
    /// <param name="layoutAxis">If present, creates this panel with a Horizontal/Vertical layout group</param>
    /// <param name="spacing">The layout group's spacing</param>
    /// <param name="padding">The layout group's padding</param>
    /// <returns>The created ModHelperPanel</returns>
    public static ModHelperPanel Create(Info info, string backgroundSprite = null,
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0) =>
        ModHelperComponent.Create<ModHelperPanel>(info).Init(backgroundSprite, layoutAxis, spacing, padding);

    /// <inheritdoc cref="Create" />
    protected static T Create<T>(Info info, string backgroundSprite = null,
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
        where T : ModHelperPanel
    {
        var modHelperPanel = ModHelperComponent.Create<T>(info);
        modHelperPanel.Init(backgroundSprite, layoutAxis, spacing, padding);
        return modHelperPanel;
    }

    /// <summary>
    /// Initializes this ModHelperPanel
    /// </summary>
    /// <param name="backgroundSprite">The panel's background sprite</param>
    /// <param name="layoutAxis">If present, creates this panel with a Horizontal/Vertical layout group</param>
    /// <param name="spacing">The layout group's spacing</param>
    /// <param name="padding">The layout group's padding</param>
    /// <returns>this ModHelperPanel</returns>
    public ModHelperPanel Init(string backgroundSprite = null,
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
    {
        if (backgroundSprite != null)
        {
            var background = AddComponent<Image>();
            background.type = Image.Type.Sliced;
            background.SetSprite(ModContent.CreateSpriteReference(backgroundSprite));
        }

        if (layoutAxis != null)
        {
            if (layoutAxis == RectTransform.Axis.Horizontal)
            {
                AddComponent<HorizontalLayoutGroup>();
                LayoutGroup.childAlignment = TextAnchor.MiddleLeft;
            }
            else
            {
                AddComponent<VerticalLayoutGroup>();
                LayoutGroup.childAlignment = TextAnchor.UpperCenter;
            }

            LayoutGroup.spacing = spacing;
            LayoutGroup.childForceExpandHeight = false;
            LayoutGroup.childForceExpandWidth = false;

            if (padding > 0)
            {
                LayoutGroup.SetPadding(padding);
            }
        }

        return this;
    }

    /// <summary>
    /// Implicitly get the Background
    /// </summary>
    public static implicit operator Image(ModHelperPanel component) => component.Background;
}