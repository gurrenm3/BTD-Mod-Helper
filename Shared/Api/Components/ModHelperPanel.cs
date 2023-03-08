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
    /// <summary>
    /// The background image
    /// </summary>
    public Image Background => GetComponent<Image>();

    /// <inheritdoc />
    public ModHelperPanel(IntPtr ptr) : base(ptr)
    {
    }

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
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
    {
        return Create<ModHelperPanel>(info, backgroundSprite, layoutAxis, spacing, padding);
    }

    /// <inheritdoc cref="Create"/>
    protected static T Create<T>(Info info, string backgroundSprite = null,
        RectTransform.Axis? layoutAxis = null, float spacing = 0, int padding = 0)
        where T : ModHelperPanel
    {
        var modHelperPanel = ModHelperComponent.Create<T>(info);

        if (backgroundSprite != null)
        {
            var background = modHelperPanel.AddComponent<Image>();
            background.type = Image.Type.Sliced;
            background.SetSprite(ModContent.CreateSpriteReference(backgroundSprite));
        }

        if (layoutAxis != null)
        {
            if (layoutAxis == RectTransform.Axis.Horizontal)
            {
                modHelperPanel.AddComponent<HorizontalLayoutGroup>();
                modHelperPanel.LayoutGroup.childAlignment = TextAnchor.MiddleLeft;
            }
            else
            {
                modHelperPanel.AddComponent<VerticalLayoutGroup>();
                modHelperPanel.LayoutGroup.childAlignment = TextAnchor.UpperCenter;
            }

            modHelperPanel.LayoutGroup.spacing = spacing;
            modHelperPanel.LayoutGroup.childForceExpandHeight = false;
            modHelperPanel.LayoutGroup.childForceExpandWidth = false;

            if (padding > 0)
            {
                modHelperPanel.LayoutGroup.SetPadding(padding);
            }
        }

        return modHelperPanel;
    }
}