using System;
using BTD_Mod_Helper.Api.UI;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Custom component used to easily keep track of Window Color themes and updating them
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class WindowColorSetter : MonoBehaviour
{
    /// <summary>
    /// The window this is a part of, possibly null, in which case will follow the default color <see cref="MelonMain.CurrentDefaultWindowColor"/>
    /// </summary>
    public ModHelperWindow window;

    /// <summary>
    /// The panel type for determining the texture
    /// </summary>
    public ModWindowColor.PanelType type;

    /// <summary>
    /// The Image this is attached to
    /// </summary>
    public Image image;

    private float basePixelMult;

    /// <inheritdoc />
    public WindowColorSetter(IntPtr pointer) : base(pointer)
    {
    }

    /// <summary>
    /// Change the image texture and pixel scale to a different WindowColor theme
    /// </summary>
    /// <param name="windowColor">the WindowColor Name</param>
    public void SetColor(string windowColor)
    {
        if ((image ??= GetComponent<Image>()) == null) return;

        if (basePixelMult == 0)
        {
            basePixelMult = image.pixelsPerUnitMultiplier;
        }

        image.SetSprite(((ModWindowColor) windowColor).GetSprite(type));
        image.pixelsPerUnitMultiplier = basePixelMult * ((ModWindowColor) windowColor).GetPixelMult(type);
    }
}