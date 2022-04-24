using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using NativeFileDialogSharp;
using TMPro;
using UnityEngine;
using Action = System.Action;

namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting for selecting a specific folder on the host computer
/// </summary>
public class ModSettingFolder : ModSetting<string>
{
    /// <inheritdoc />
    public ModSettingFolder(string value) : base(value)
    {
    }


    /// <inheritdoc />
    public ModSettingFolder(Environment.SpecialFolder folder) : base(Environment.GetFolderPath(folder))
    {
    }


    /// <summary>
    /// Constructs a new ModSetting with the given value as default
    /// </summary>
    public static implicit operator ModSettingFolder(string value)
    {
        return new ModSettingFolder(value);
    }

    /// <summary>
    /// Gets the current value out of a ModSetting
    /// </summary>
    public static implicit operator string(ModSettingFolder modSettingFolder)
    {
        return modSettingFolder.value;
    }

    /// <inheritdoc />
    public override void SetValue(object val)
    {
        base.SetValue(val);
        if (currentOption != null)
        {
            currentOption.GetDescendent<NK_TextMeshProUGUI>("FolderText").SetText((string) val);
        }
    }

    /// <inheritdoc />
    internal override ModHelperOption CreateComponent()
    {
        var option = CreateBaseOption();

#if BloonsTD6
        var button = option.BottomRow.AddButton(
            new Info("Input", width: 1500, height: 150), VanillaSprites.BlueInsertPanelRound,
            new Action(() =>
            {
                FileDialogHelper.PrepareNativeDlls();
                    
                var dialog = Dialog.FolderPicker(lastSavedValue);
                if (dialog?.IsOk == true)
                {
                    SetValue(dialog.Path);
                }
            })
        );
        button.GetDescendent<Animator>().enabled = false;

        var text = button.AddText(new Info("FolderText", anchorMin: Vector2.zero, anchorMax: Vector2.one), value);
        text.Text.alignment = TextAlignmentOptions.Center;

        option.SetResetAction(new Action(() => text.SetText(defaultValue)));
#endif

        return option;
    }
}