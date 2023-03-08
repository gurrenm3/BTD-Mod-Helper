using System;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for ToggleEvents
/// </summary>
public static class ToggleEventExt
{
    /// <inheritdoc />
    public delegate void Function(bool value);

    /// <summary>
    /// Add a function to a submit event
    /// </summary>
    public static void AddListener(this Toggle.ToggleEvent submitEvent, Function funcToExecute)
    {
        submitEvent.AddListener(new Action<bool>(b => { funcToExecute(b); }));
    }
}