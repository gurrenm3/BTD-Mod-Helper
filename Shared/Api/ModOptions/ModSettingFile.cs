using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*using System.Windows.Forms;
using Ookii.Dialogs.WinForms;*/

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// ModSetting for selecting a specific file on the host computer
    /// </summary>
    public class ModSettingFile : ModSetting<string>
    {
        /// <inheritdoc cref="VistaFileDialog.Filter"/>
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
            if (currentOption)
            {
                currentOption.GetDescendent<NK_TextMeshProUGUI>("FileText").SetText((string) val);
            }
        }

        /// <inheritdoc />
        internal override ModHelperOption CreateComponent()
        {
            var option = CreateBaseOption();

#if BloonsTD6
            /*var button = option.BottomRow.AddButton(
                new Info("Input", width: 1500, height: 150), VanillaSprites.BlueInsertPanelRound,
                new Action(() =>
                {
                    using (var dialog = new VistaOpenFileDialog())
                    {
                        dialog.CheckFileExists = true;
                        dialog.CheckPathExists = true;
                        dialog.Multiselect = false;
                        dialog.Title = @"Select a file";
                        dialog.FileName = value;
                        dialog.Filter = filter;
                        var dialogResult = dialog.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            SetValue(dialog.FileName);
                        }
                    }
                })
            );
            button.GetDescendent<Animator>().enabled = false;

            var text = button.AddText(new Info("FileText", anchorMin: Vector2.zero, anchorMax: Vector2.one), value);

            option.SetResetAction(new Action(() => text.SetText(defaultValue)));*/
#endif

            return option;
        }
    }
}