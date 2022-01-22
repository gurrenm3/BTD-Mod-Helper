using System;
using System.Globalization;
using Assets.Scripts.Unity.Utils;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using MelonLoader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a sliding input
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperSlider : ModHelperComponent
    {
        /// <summary>
        /// The actual Slider component
        /// </summary>
        public Slider Slider { get; private set; }

        /// <summary>
        /// The panel that's the filled up bar part of the slider
        /// </summary>
        public ModHelperPanel Fill { get; private set; }

        /// <summary>
        /// The Default value, not scaled to anything
        /// </summary>
        public float DefaultValue { get; private set; }

        /// <summary>
        /// The real current value, scaled by the appropriate scale factor
        /// </summary>
        public float CurrentValue => Slider.value / scaleFactor;

        /// <summary>
        /// The image showing where the default value is on the slider
        /// </summary>
        public ModHelperImage DefaultNotch { get; private set; }

        /// <summary>
        /// The text that's on the notch of the slider
        /// </summary>
        public ModHelperText Label { get; private set; }

        private float scaleFactor = 1;

        /// <summary>
        /// Sets the current value of this
        /// </summary>
        /// <param name="value">The new value</param>
        /// <param name="sendCallback">Whether the onValueChanged listener should fire</param>
        public void SetCurrentValue(float value, bool sendCallback = true)
        {
            Slider.Set(value * scaleFactor, sendCallback);
        }

        /// <inheritdoc />
        public ModHelperSlider(IntPtr ptr) : base(ptr)
        {
        }

        /// <summary>
        /// Creates a new ModHelperSlider
        /// </summary>
        /// <param name="info">The name/position/size info. NOTE: height must be a set value</param>
        /// <param name="defaultValue">The default slider amount</param>
        /// <param name="minValue">The minimum value of the slider</param>
        /// <param name="maxValue">The maximum value of the slider</param>
        /// <param name="stepSize">What value the slider should increase by per tick</param>
        /// <param name="handleSize">The height and width of the pip</param>
        /// <param name="onValueChanged">Action should happen when the slider changes value, or null</param>
        /// <param name="fontSize">The size of the label text</param>
        /// <param name="getLabel">Function to apply to the value in order to get the label, like adding a '%', or null for default</param>
        /// <returns></returns>
        public static ModHelperSlider Create(Info info, float defaultValue, float minValue, float maxValue,
            float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged = null, float fontSize = 42f,
            Il2CppSystem.Func<float, string> getLabel = null)
        {
            var modHelperSlider = ModHelperComponent.Create<ModHelperSlider>(info);
            var slider = modHelperSlider.Slider = modHelperSlider.AddComponent<Slider>();
            slider.direction = Slider.Direction.LeftToRight;

            if (stepSize > 0)
            {
                modHelperSlider.scaleFactor = 1 / stepSize;
                slider.wholeNumbers = true;
            }

            modHelperSlider.DefaultValue = defaultValue;
            slider.minValue = minValue * modHelperSlider.scaleFactor;
            slider.maxValue = maxValue * modHelperSlider.scaleFactor;
            var background = modHelperSlider.AddPanel(
                new Info("Background", anchorMin: Vector2.zero, anchorMax: Vector2.one), VanillaSprites.SmallSquareWhite
            );
            background.Background.color = new Color(.219f, .125f, .058f);

            var fillPanel = modHelperSlider.AddPanel(
                new Info("FillPanel", width: info.Height / -4f, height: info.Height / -4f, anchorMin: Vector2.zero, anchorMax: Vector2.one)
            );

            var fill = modHelperSlider.Fill = fillPanel.AddPanel(
                new Info("Fill", anchorMin: Vector2.zero, anchorMax: Vector2.one), VanillaSprites.SmallSquareWhite
            );
            fill.Background.color = new Color(.5f, 1, 0);
            slider.fillRect = fill;
            slider.m_FillContainerRect = fillPanel;

            modHelperSlider.DefaultNotch = modHelperSlider.AddImage(
                new Info("DefaultNotch", 0, 0, 64, 136), VanillaSprites.SliderMarker
            );

            var handleContainer = modHelperSlider.AddPanel(
                new Info("HandleContainer", anchorMin: Vector2.zero, anchorMax: Vector2.one)
            );

            var pip = handleContainer.AddImage(
                new Info("Handle", width: handleSize.x, height: handleSize.y - info.Height),
                VanillaSprites.BlueBtnCircleSmall
            );
            slider.handleRect = pip;
            slider.m_HandleContainerRect = handleContainer;

            var label = modHelperSlider.Label = pip.AddText(
                new Info("Value", 0, handleSize.y / 2 + fontSize, 200, fontSize * 2), "", fontSize
            );

            
            slider.onValueChanged.AddListener(new Action<float>(value =>
            {
                var realValue = value / modHelperSlider.scaleFactor;
                label.SetText(getLabel != null ? getLabel.Invoke(realValue) : realValue.ToString(CultureInfo.InvariantCulture));
                onValueChanged?.Invoke(realValue);
            }));
            
            modHelperSlider.SetCurrentValue(defaultValue);

            return modHelperSlider;
        }
    }
}