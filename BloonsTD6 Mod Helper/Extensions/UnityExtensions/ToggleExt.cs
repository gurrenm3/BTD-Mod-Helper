using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Toggles
/// </summary>
public static class ToggleExt
{
    /// <summary>
    /// Adds a function to this toggle
    /// </summary>
    public static void AddOnValueChanged(this Toggle toggle, ToggleEventExt.Function funcToExecute)
    {
        toggle.onValueChanged.AddListener(funcToExecute);
    }
}