using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for LayoutGroups
/// </summary>
public static class LayoutGroupExt
{
    /// <summary>
    /// Sets the padding on all sides of a panel to be a certain value
    /// </summary>
    public static void SetPadding(this LayoutGroup layoutGroup, int padding)
    {
        layoutGroup.padding = new RectOffset
        {
            top = padding,
            bottom = padding,
            left = padding,
            right = padding
        };
    }
}