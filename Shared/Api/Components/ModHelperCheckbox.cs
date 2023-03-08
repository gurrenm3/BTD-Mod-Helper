using System;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine.Events;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a Checkbox
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperCheckbox : ModHelperComponent
{
    /// <summary>
    /// The Toggle component
    /// </summary>
    public Toggle Toggle => GetComponent<Toggle>();

    /// <summary>
    /// The ModHelperImage for the Checkmark
    /// </summary>
    public ModHelperImage Check => GetDescendent<ModHelperImage>("Check");

    /// <summary>
    /// Whether it is currently checked or not
    /// </summary>
    public bool CurrentValue => Toggle.isOn;

    /// <summary>
    /// Sets the current value of this
    /// </summary>
    /// <param name="isChecked">The new value</param>
    /// <param name="sendCallback">Whether the onValueChanged listener should fire</param>
    public void SetChecked(bool isChecked, bool sendCallback = true)
    {
        Toggle.Set(isChecked, sendCallback);
    }

    /// <inheritdoc />
    public ModHelperCheckbox(IntPtr ptr) : base(ptr)
    {
    }

    /// <summary>
    /// Creates a new ModHelperCheckbox
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="defaultValue">If it starts out checked or not</param>
    /// <param name="onValueChanged">Action to perform when it is checked/unchecked, or null</param>
    /// <param name="background">The background behind the check, or null for nothing</param>
    /// <param name="checkImage">The checkmark itself, or null for the default checkmark</param>
    /// <param name="padding">How much space around the outside of the check there is</param>
    /// <returns>The new ModHelperCheckbox</returns>
    public static ModHelperCheckbox Create(Info info, bool defaultValue, string background,
        UnityAction<bool> onValueChanged = null, string checkImage = null, int padding = 0)
    {
        var modHelperCheckbox = Create<ModHelperCheckbox>(info);

        var backgroundImage = modHelperCheckbox.AddComponent<Image>();
        backgroundImage.type = Image.Type.Sliced;
        backgroundImage.SetSprite(background);

        ModHelperImage check;
#if BloonsTD6
        check = modHelperCheckbox.AddImage(new Info("Check", InfoPreset.FillParent)
        {
            Size = padding * -2
        }, checkImage ?? VanillaSprites.TickGreenIcon);
#elif BloonsAT
            // need to figure out how to get "VanillaSprites.TickGreenIcon" for BloonsAT
            throw new NotImplementedException();
#endif

        var toggle = modHelperCheckbox.AddComponent<Toggle>();
        toggle.graphic = check.Image;
        if (onValueChanged != null)
        {
            toggle.onValueChanged.AddListener(onValueChanged);
        }

        toggle.isOn = defaultValue;

        return modHelperCheckbox;
    }
}