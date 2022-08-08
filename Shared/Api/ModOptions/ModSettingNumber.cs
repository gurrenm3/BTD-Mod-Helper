using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using TMPro;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting class for a number, implying it can have a min/max value, and be an input or a slider
/// </summary> 
public abstract class ModSettingNumber<T> : ModSetting<T> where T : struct, IComparable<T>
{
    /// <summary>
    /// The lowest allowed value, or null for unbounded
    /// </summary>
    public T? min;

    /// <summary>
    /// The largest allowed value, or null for unbounded
    /// </summary>
    public T? max;

    /// <summary>
    /// Whether this displays as a slider
    /// </summary>
    public bool slider;

#if BloonsTD6
    /// <summary>
    /// Action to modify the ModHelperSlider after it's created
    /// </summary>
    public Action<ModHelperSlider> modifySlider;

    /// <summary>
    /// Action to modify the ModHelperInputField after it's created
    /// </summary>
    public Action<ModHelperInputField> modifyInput;
#endif

    /// <summary>
    /// Step Size for the slider 
    /// </summary>
    protected virtual float StepSize => 1;

    /// <summary>
    /// Validation to use for the input component
    /// </summary>
    protected abstract TMP_InputField.CharacterValidation Validation { get; }

    /// <inheritdoc />
    protected ModSettingNumber(T value) : base(value)
    {
    }

    /// <summary>
    /// Turn the value into a string for labels
    /// </summary>
    protected abstract string ToString(T input);

    /// <summary>
    /// Get the value from the string input component
    /// </summary>
    protected abstract T FromString(string s);

    /// <summary>
    /// Conversion of the type to a float for the slider component
    /// </summary>
    protected abstract float ToFloat(T input);

    /// <summary>
    /// Conversion of the type from a float for the slider component
    /// </summary>
    protected abstract T FromFloat(float f);

    private T Clamp(T v)
    {
        if (min != null && v.CompareTo(min.Value) < 0)
        {
            return min.Value;
        }

        if (max != null && v.CompareTo(max.Value) > 0)
        {
            return max.Value;
        }

        return v;
    }

    /// <inheritdoc />
    internal override ModHelperOption CreateComponent()
    {
        var option = CreateBaseOption();

#if BloonsTD6
        if (slider && min != null && max != null)
        {
            // ReSharper disable twice PossibleInvalidOperationException
            var sliderComponent = option.BottomRow.AddSlider(
                new Info("Slider", width: 1500, height: 100), ToFloat(defaultValue),
                ToFloat(min.Value), ToFloat(max.Value), StepSize, new Vector2(150, 150),
                new Action<float>(f => SetValue(Clamp(FromFloat(f)))), 80f
            );
            sliderComponent.Slider.SetValueWithoutNotify(ToFloat(value));

            var labelPosition = sliderComponent.Label.RectTransform.localPosition;
            labelPosition.y *= -1;
            sliderComponent.Label.RectTransform.localPosition = labelPosition;

            option.SetResetAction(new Action(() => sliderComponent.SetCurrentValue(ToFloat(defaultValue))));
            modifySlider?.Invoke(sliderComponent);
        }
        else
        {
            var input = option.BottomRow.AddInputField(
                new Info("Input", width: 500, height: 150), ToString(value), VanillaSprites.BlueInsertPanelRound,
                new Action<string>(s => SetValue(Clamp(FromString(s)))), 80f, Validation
            );
            option.SetResetAction(new Action(() => input.SetText(ToString(defaultValue))));
            modifyInput?.Invoke(input);
        }
#elif BloonsAT
            throw new NotImplementedException(); // need to get ModHelperSlider and ModHelperInputField working for BloonsAT
#endif

        return option;
    }
}