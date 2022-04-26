using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using NativeFileDialogSharp;
using TMPro;
using UnityEngine;


namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting for selecting a specific file on the host computer
/// </summary>
public class ModSettingFile : ModSetting<string>
{
    /// <summary>
    /// https://github.com/mlabbe/nativefiledialog/blob/master/README.md#file-filter-syntax
    /// </summary>
    public string filter = "";
        
        
    /// <inheritdoc />
    public ModSettingFile(string value) : base(value)
    {
    }
        
    /// <summary>
    /// Constructs a new ModSetting with the given value as default
    /// </summary>
    public static implicit operator ModSettingFile(string value)
    {
        return new ModSettingFile(value);
    }

    /// <summary>
    /// Gets the current value out of a ModSetting
    /// </summary>
    public static implicit operator string(ModSettingFile modSettingFile)
    {
        return modSettingFile.value;
    }

    /// <inheritdoc />
    public override void SetValue(object val)
    {
        base.SetValue(val);
        if (currentOption != null)
        {
            currentOption.GetDescendent<NK_TextMeshProUGUI>("FileText").SetText((string) val);
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
                    
                var dialog = Dialog.FileOpen(filter, value);
                if (dialog?.IsOk == true)
                {
                    SetValue(dialog.Path);
                }
            })
        );
        button.GetDescendent<Animator>().enabled = false;

        var text = button.AddText(new Info("FileText", anchorMin: Vector2.zero, anchorMax: Vector2.one), value);
        text.Text.alignment = TextAlignmentOptions.Center;

        option.SetResetAction(new Action(() => text.SetText(defaultValue)));
#endif

        return option;
    }
}