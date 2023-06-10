using System;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension for OnChangeEvent
/// </summary>
public static class InputFieldOnValueChanged
{
    #region Delegates

    /// <inheritdoc />
    public delegate void Function(string value);

    #endregion

    /// <summary>
    /// Adds a listener to a ValueChangedEvent
    /// </summary>
    public static void AddListener(this InputField.OnChangeEvent valueChangedEvent, Function funcToExecute)
    {
        valueChangedEvent.AddListener(new Action<string>(str => { funcToExecute(str); }));
    }
}