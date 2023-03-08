using System;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for InputFields
/// </summary>
public static partial class InputFieldExt
{
    /// <summary>
    /// Add a submit event to an InputField
    /// </summary>\
    public static void AddSubmitEvent(this InputField inputField, InputFieldSubmitEvent.Function funcToExecute)
    {
        inputField.onEndEdit.AddListener(new Action<string>(funcToExecute.Invoke));
    }

    /// <summary>
    /// Adds a value change event to an InputField
    /// </summary>
    public static void AddOnValueChangeEvent(this InputField inputField, InputFieldOnValueChanged.Function funcToExecute)
    {
        inputField.onValueChange.AddListener(funcToExecute);
    }
        
    /// <summary>
    /// Adds a value changed event to an InputField
    /// </summary>
    public static void AddOnValueChangedEvent(this InputField inputField, InputFieldOnValueChanged.Function funcToExecute)
    {
        inputField.onValueChanged.AddListener(funcToExecute);
    }
}