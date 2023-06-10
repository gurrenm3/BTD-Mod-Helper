using System;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for SliderEvents
/// </summary>
public static class SliderEventExt
{
    #region Delegates

    /// <inheritdoc />
    public delegate void Function(float value);

    #endregion

    /// <summary>
    /// Adds a listener to a slider event
    /// </summary>
    public static void AddListener(this Slider.SliderEvent sliderEvent, Function funcToExecute)
    {
        sliderEvent.AddListener(new Action<float>(f => funcToExecute(f)));
    }
}