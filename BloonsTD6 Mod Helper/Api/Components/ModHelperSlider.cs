﻿using System;
using System.Globalization;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a sliding input
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperSlider : ModHelperComponent
{
    /// <summary>
    /// The actual Slider component
    /// </summary>
    public Slider Slider => GetComponent<Slider>();

    /// <summary>
    /// The panel that's the filled up bar part of the slider
    /// </summary>
    public ModHelperPanel Fill => GetDescendent<ModHelperPanel>("Fill");

    /// <summary>
    /// The Default value, not scaled to anything
    /// </summary>
    public float defaultValue;

    /// <summary>
    /// The real current value, scaled by the appropriate scale factor
    /// </summary>
    public float CurrentValue => Slider.value / scaleFactor;

    /// <summary>
    /// The image showing where the default value is on the slider
    /// </summary>
    public ModHelperImage DefaultNotch => GetDescendent<ModHelperImage>("DefaultNotch");

    /// <summary>
    /// The text that's on the notch of the slider
    /// </summary>
    public ModHelperText Label => GetDescendent<ModHelperText>("Label");

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
    /// <param name="labelSuffix">String to add to the end of the label, e.g. "%"</param>
    /// <returns></returns>
    public static ModHelperSlider Create(Info info, float defaultValue, float minValue, float maxValue,
        float stepSize, Vector2 handleSize, UnityAction<float>? onValueChanged = null, float fontSize = 42f,
        string labelSuffix = "")
    {
        var modHelperSlider = ModHelperComponent.Create<ModHelperSlider>(info);
        var slider = modHelperSlider.AddComponent<Slider>();
        slider.direction = Slider.Direction.LeftToRight;

        if (stepSize > 0)
        {
            modHelperSlider.scaleFactor = 1 / stepSize;
            slider.wholeNumbers = true;
        }

        modHelperSlider.defaultValue = defaultValue;
        slider.minValue = minValue * modHelperSlider.scaleFactor;
        slider.maxValue = maxValue * modHelperSlider.scaleFactor;
        var background = modHelperSlider.AddPanel(
            new Info("Background", anchorMin: Vector2.zero, anchorMax: Vector2.one), VanillaSprites.SmallSquareWhite
        );
        background.Background.color = new Color(.219f, .125f, .058f);

        var fillPanel = modHelperSlider.AddPanel(
            new Info("FillPanel", width: info.Height / -4f, height: info.Height / -4f, anchorMin: Vector2.zero,
                anchorMax: Vector2.one)
        );

        var fill = fillPanel.AddPanel(
            new Info("Fill", anchorMin: Vector2.zero, anchorMax: Vector2.one), VanillaSprites.SmallSquareWhite
        );
        fill.Background.color = new Color(.5f, 1, 0);
        slider.fillRect = fill;
        slider.m_FillContainerRect = fillPanel;

        var anchorPos = (defaultValue - minValue) / (maxValue - minValue);

        modHelperSlider.AddImage(
            new Info("DefaultNotch", width: 64, height: 136, anchor: new Vector2(anchorPos, 0.5f)),
            VanillaSprites.SliderMarker
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

        var label = pip.AddText(
            new Info("Label", 0, handleSize.y / 2 + fontSize, 200, fontSize * 2),
            defaultValue.ToString(CultureInfo.InvariantCulture) + labelSuffix, fontSize
        );


        slider.onValueChanged.AddListener(new Action<float>(value =>
        {
            var realValue = value / modHelperSlider.scaleFactor;
            label.SetText(realValue.ToString(CultureInfo.InvariantCulture) + labelSuffix);
            onValueChanged?.Invoke(realValue);
        }));

        modHelperSlider.SetCurrentValue(defaultValue);

        return modHelperSlider;
    }
}