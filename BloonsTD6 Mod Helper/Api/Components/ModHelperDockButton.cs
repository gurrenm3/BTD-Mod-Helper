using System;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.UI;
using Il2CppAssets.Scripts.Unity.Display;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
///
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public sealed class ModHelperDockButton : ModHelperPanel
{
    /// <summary>
    /// Constant amount of size that Dock buttons have based on the 16x9 aspect ratio border bars
    /// </summary>
    public const int Size = 50;

    /// <summary>
    /// The button component
    /// </summary>
    public ModHelperButton button;

    /// <summary>
    /// The label
    /// </summary>
    public ModHelperText text;

    /// <summary>
    /// The window this corresponds to
    /// </summary>
    public ModHelperWindow window;

    /// <summary>
    /// The icon of this button, if any
    /// </summary>
    public ModHelperImage icon;

    private float width;

    private bool iconRotated;

    /// <inheritdoc />
    public ModHelperDockButton(IntPtr pointer) : base(pointer)
    {
    }

    /// <summary>
    /// Creates a new Dock button for a window
    /// </summary>
    /// <param name="parent">Parent panel of the button</param>
    /// <param name="window">window the button will correspond to</param>
    /// <param name="icon">icon to use for the button</param>
    /// <param name="iconScale">visual scale for the icon</param>
    /// <param name="dockTitle">title for the dock button</param>
    /// <returns>the created dock button</returns>
    public static ModHelperDockButton Create(ModHelperPanel parent, ModHelperWindow window, string icon = null,
        float iconScale = 1f, string dockTitle = null)
    {
        var modWindow = window.ModWindow;

        var width = modWindow?.DockButtonWidth ?? 200;

        var dockButton = Create<ModHelperDockButton>(new Info(window.name, Size, width));
        dockButton.SetParent(parent);
        dockButton.window = window;
        dockButton.width = width;
        dockButton.iconRotated = modWindow?.RotateDockIcon ?? false;

        var button = dockButton.button = dockButton.AddButton(new Info("Button", width, Size),
                         VanillaSprites.BlueBtnLong, new Action(dockButton.OnClick));
        button.Image.type = Image.Type.Sliced;
        button.Image.pixelsPerUnitMultiplier = 3;
        button.Button.transition = Selectable.Transition.ColorTint;
        button.RemoveComponent<Animator>();
        window.ApplyWindowColor(button, ModWindowColor.PanelType.Button);

        if (modWindow?.ShowIconInDock != false && icon != null)
        {
            var image = dockButton.icon = button.AddImage(new Info("Icon", Size)
            {
                Anchor = new Vector2(0, 0.5f),
                X = Size / 2f
            }, icon);
            image.RectTransform.localScale = Vector3.one * iconScale;
        }


        if (!string.IsNullOrEmpty(dockTitle))
        {
            var text = dockButton.text = button.AddText(new Info("Text", InfoPreset.FillParent), dockTitle, 32);
            text.EnableAutoSizing(32);
            text.Text.margin = text.Text.margin with
            {
                z = 10
            };

            if (dockButton.icon is not null)
            {
                text.RectTransform.offsetMin = new Vector2(Size, 0);
            }
        }


        var screenSize = FindObjectOfType<ScreenResizeDetector>();
        dockButton.UpdatePosition(screenSize.currentWidth, screenSize.currentHeight);

        return dockButton;
    }

    internal static float Scale(AspectRatio aspectRatio) => aspectRatio switch
    {
        AspectRatio.TallWidescreen => 1.6f,
        AspectRatio.NonWidescreen => 1.25f,
        _ => 1f
    };

    internal void UpdatePosition(int screenWidth, int screenHeight)
    {
        var aspectRatio = AspectRatios.From(screenWidth, screenHeight);

        var scale = Scale(aspectRatio);

        button.initialInfo = button.initialInfo with
        {
            Scale = new Vector3(scale, scale, scale),
        };
        button.RectTransform.localScale = new Vector3(scale, scale, scale);

        switch (aspectRatio)
        {
            case AspectRatio.Widescreen:
                button.RectTransform.localRotation = Quaternion.Euler(0, 0, 90);

                LayoutElement.preferredWidth = LayoutElement.minWidth = Size * scale;
                LayoutElement.preferredHeight = LayoutElement.minHeight = width * scale;

                if (icon is not null)
                {
                    icon.RectTransform.localRotation = Quaternion.Euler(0, 0, iconRotated ? -90 : 0);
                }

                break;
            default:
                button.RectTransform.localRotation = Quaternion.Euler(0, 0, 0);

                LayoutElement.preferredWidth = LayoutElement.minWidth = width * scale;
                LayoutElement.preferredHeight = LayoutElement.minHeight = Size * scale;

                if (icon is not null)
                {
                    icon.RectTransform.localRotation = Quaternion.Euler(0, 0, 0);
                }

                break;
        }
    }

    /// <summary>
    /// When the button is clicked
    /// </summary>
    public void OnClick()
    {
        window.ToggleMinimized();
    }
}