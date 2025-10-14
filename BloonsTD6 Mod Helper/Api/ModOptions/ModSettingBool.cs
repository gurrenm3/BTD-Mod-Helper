﻿using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting class for a boolean value
/// </summary>
public class ModSettingBool : ModSetting<bool>
{
    /// <summary>
    /// Whether this should display as an Enabled/Disabled button instead of a checkbox
    /// </summary>
    public bool button;

    private Action<bool, ModHelperButton> currentAction;

    /// <summary>
    /// The sprite to use for the button when it's disabled, RedBtnLong by default
    /// </summary>
    public string disabledButton = VanillaSprites.RedBtnLong;

    /// <summary>
    /// The text that the button should have when it's disabled, if this is a button
    /// </summary>
    public string disabledText = "Disabled";

    /// <summary>
    /// The sprite to use for the button when it's enabled, GreenBtnLong by default
    /// </summary>
    public string enabledButton = VanillaSprites.GreenBtnLong;

    /// <summary>
    /// The text that the button should have when it's enabled, if this is a button
    /// </summary>
    public string enabledText = "Enabled";

    /// <summary>
    /// Action to modify the ModHelperCheckbox after it's created
    /// </summary>
    public Action<ModHelperButton> modifyButton;

    /// <summary>
    /// Action to modify the ModHelperCheckbox after it's created
    /// </summary>
    public Action<ModHelperCheckbox> modifyCheckbox;

    /// <inheritdoc />
    public ModSettingBool(bool value) : base(value)
    {
    }

    /// <summary>
    /// Create a new ModSetting bool with the given value as default
    /// </summary>
    public static implicit operator ModSettingBool(bool value) => new(value);

    /// <summary>
    /// Gets the current value out of a ModSettingBool
    /// </summary>
    /// <param name="modSettingBool"></param>
    /// <returns></returns>
    public static implicit operator bool(ModSettingBool modSettingBool) => modSettingBool.value;

    /// <inheritdoc />
    public override void SetValue(object val)
    {
        base.SetValue(val);
        try
        {
            if (currentOption != null)
            {
                var butt = currentOption.GetDescendent<ModHelperButton>("Button");
                if (butt !=null)
                {
                    currentAction?.Invoke((bool) val, butt);
                }
            }
        }
        catch (Exception e)
        {
            if (currentAction != null)
            {
                ModHelper.Error("Failed to run ModSettingBool action");
                ModHelper.Error(e);
            }
        }
    }

    /// <inheritdoc />
    internal override ModHelperOption CreateComponent()
    {
        var option = CreateBaseOption();

        if (button)
        {
            var buttonComponent = option.BottomRow.AddButton(
                new Info("Button", 562, 200), value ? enabledButton : disabledButton, null
            );
            var text = buttonComponent.AddText(new Info("Text", InfoPreset.FillParent)
            {
                Size = -50
            }, value ? enabledText : disabledText, 80f);
            text.EnableAutoSizing();
            text.Text.lineSpacing = 10;

            currentAction = (_, butt) =>
            {
                if (butt != null)
                {
                    butt.Image.SetSprite(value ? enabledButton : disabledButton);
                    butt.GetDescendent<NK_TextMeshProUGUI>("Text").SetText(value ? enabledText : disabledText);
                }
            };
            buttonComponent.Button.onClick.AddListener(() =>
            {
                currentAction(!value, buttonComponent);
                SetValue(!value);
                MenuManager.instance.buttonClickSound.Play("ClickSounds");
            });

            option.SetResetAction(new Action(() =>
            {
                currentAction(defaultValue, buttonComponent);
                SetValue(defaultValue);
            }));
            modifyButton?.Invoke(buttonComponent);
        }
        else
        {
            var checkbox = option.BottomRow.AddCheckbox(new Info("Checkbox", 200), value,
                VanillaSprites.BlueInsertPanelRound, new Action<bool>(enabled =>
                {
                    SetValue(enabled);
                }));
            checkbox.Toggle.onValueChanged.AddListener(_ =>
            {
                ResourceLoader.LoadAsync<AudioClip>(VanillaAudioClips.UITick01).WaitForCompletion().Play("ClickSounds");
            });
            option.SetResetAction(new Action(() => checkbox.SetChecked(defaultValue)));
            modifyCheckbox?.Invoke(checkbox);
        }

        return option;
    }
}