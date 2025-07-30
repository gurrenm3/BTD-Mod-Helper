using BTD_Mod_Helper.Api.Enums;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Selectable
/// </summary>
public static class SelectableExt
{
    internal static readonly Color NormalColor = new(1, 1, 1, 0);
    internal static readonly Color HighlightColor = new(1, 1, 1, .5f);
    internal static readonly Color PressedColor = new(1, 1, 1, .25f);
    internal static readonly Color DisabledColor = new(0, 0, 0, .25f);

    /// <summary>
    /// Sets a selectable to use ColorTint as its transition with colors designed for a semi transparent background image
    /// <seealso cref="VanillaSprites.SmallSquareWhiteGradient"/>
    /// </summary>
    /// <param name="selectable">this</param>
    public static void UseBackgroundTint(this Selectable selectable)
    {
        selectable.transition = Selectable.Transition.ColorTint;

        selectable.colors = selectable.colors with
        {
            normalColor = NormalColor,
            disabledColor = DisabledColor,
            highlightedColor = HighlightColor,
            selectedColor = HighlightColor,
            pressedColor = PressedColor
        };

        if (selectable.gameObject.HasComponent(out Animator animator))
        {
            animator.enabled = false;
        }

        selectable.DoStateTransition(Selectable.SelectionState.Normal, true);
    }
}