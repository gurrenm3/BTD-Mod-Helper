using System;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for InputFieldSubmitEvents
/// </summary>
public static class InputFieldSubmitEvent
{
    #region Delegates

    /// <inheritdoc />
    public delegate void Function(string value);

    #endregion

    /// <summary>
    /// Adds a function to a submit event
    /// </summary>
    public static void AddListener(this InputField.SubmitEvent submitEvent, Function funcToExecute)
    {
        submitEvent.AddListener(new Action<string>(str => { funcToExecute(str); }));
    }
}