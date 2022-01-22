using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using TMPro;
using UnityEngine;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting class for a number, implying it can have a min/max value, and be an input or a slider
    /// </summary>
    public abstract class ModSettingNumber<T> : ModSetting<T> where T : unmanaged
    {
        /// <summary>
        /// The lowest allowed value, or null for unbounded
        /// </summary>
        public T? minValue;

        /// <summary>
        /// The largest allowed value, or null for unbounded
        /// </summary>
        public T? maxValue;

        /// <summary>
        /// Whether this displays as a slider
        /// </summary>
        public bool isSlider;

        /// <summary>
        /// Action to modify the ModHelperSlider after it's created
        /// </summary>
        public Action<ModHelperSlider> modifySlider;

        /// <summary>
        /// Action to modify the ModHelperInputField after it's created
        /// </summary>
        public Action<ModHelperInputField> modifyInput;

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

        /// <inheritdoc />
        public override ModHelperComponent CreateComponent()
        {
            var option = CreateBaseOption();


            if (isSlider && minValue != null && maxValue != null)
            {
                // ReSharper disable twice PossibleInvalidOperationException
                var slider = option.AddSlider(
                    new Info("Slider", 0, -50f, 1500, 100), ToFloat(defaultValue),
                    ToFloat(minValue.Value), ToFloat(maxValue.Value), StepSize, new Vector2(150, 150),
                    new Action<float>(f =>
                    {
                        var v = FromFloat(f);
                        SetValue(v);
                        onValueChanged?.Invoke(v);
                    }), 80f, new Func<float, string>(f => ToString(FromFloat(f)))
                );

                option.SetResetAction(new Action(() => slider.SetCurrentValue(ToFloat(defaultValue))));
                modifySlider?.Invoke(slider);
            }
            else
            {
                var input = option.AddInputField(
                    new Info("Input", 0, 0, 500, 150), ToString(value), VanillaSprites.BlueInsertPanelRound,
                    new Action<string>(s =>
                    {
                        var v = FromString(s);
                        SetValue(v);
                        onValueChanged?.Invoke(v);
                    }), 80f, Validation
                );

                option.SetResetAction(new Action(() => input.SetText(ToString(defaultValue))));
                modifyInput?.Invoke(input);
            }

            return option;
        }
    }
}