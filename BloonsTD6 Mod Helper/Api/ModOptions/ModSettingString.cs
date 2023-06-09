using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppTMPro;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting for a string value
/// </summary>
public class ModSettingString : ModSetting<string>
{


    /// <summary>
    /// Allow all characters
    /// </summary>
    public static readonly string None = TMP_InputField.CharacterValidation.None.ToString();

    /// <summary>
    /// Allow only alphanumeric characters
    /// </summary>
    public static readonly string Alphanumeric = TMP_InputField.CharacterValidation.Alphanumeric.ToString();

    /// <summary>
    /// Allow only valid decimals
    /// </summary>
    public static readonly string Decimal = TMP_InputField.CharacterValidation.Decimal.ToString();

    /// <summary>
    /// Allow only valid integers
    /// </summary>
    public static readonly string Integer = TMP_InputField.CharacterValidation.Integer.ToString();

    /// <summary>
    /// Validation for the input field, determining which characters are allowed
    /// </summary>
    public TMP_InputField.CharacterValidation characterValidation;

    /// <summary>
    /// Action to modify the ModHelperInputField after it's created
    /// </summary>
    public Action<ModHelperInputField> modifyInput;

    /// <summary>
    /// InputField validation, use one of the ModSettingString.[thing] constants
    /// </summary>
    [Obsolete("Use characterValidation instead")]
    public string validation;

    /// <inheritdoc />
    public ModSettingString(string value) : base(value)
    {
    }

    /// <summary>
    /// Constructs a new ModSetting with the given value as default
    /// </summary>
    public static implicit operator ModSettingString(string value)
    {
        return new ModSettingString(value);
    }

    /// <summary>
    /// Gets the current value out of a ModSetting
    /// </summary>
    public static implicit operator string(ModSettingString modSettingString)
    {
        return modSettingString.value;
    }

    /// <inheritdoc />
    internal override ModHelperOption CreateComponent()
    {
        var option = CreateBaseOption();


        var input = option.BottomRow.AddInputField(
            new Info("Input", 1500, 150), value, VanillaSprites.BlueInsertPanelRound,
            new Action<string>(s =>
            {
                SetValue(s);
                // ModHelper.Log("value is a changin");
            }), 80f, characterValidation
        );

        option.SetResetAction(new Action(() => input.SetText(defaultValue)));
        modifyInput?.Invoke(input);

        return option;
    }
}