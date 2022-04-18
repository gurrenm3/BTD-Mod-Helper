using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;

/*using System.Windows.Forms;
using Ookii.Dialogs.WinForms;*/

namespace BTD_Mod_Helper.Api.ModOptions
{
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
            if (currentOption)
            {
                currentOption.GetDescendent<NK_TextMeshProUGUI>("FolderText").SetText((string) val);
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
                    using (var dialog = new VistaFolderBrowserDialog())
                    {
                        
                        dialog.Description = @"Select a folder";
                        dialog.SelectedPath = lastSavedValue;
                        dialog.ShowNewFolderButton = false;
                        dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                        var dialogResult = dialog.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            SetValue(dialog.SelectedPath);
                        }
                    }
                })
            );
            button.GetDescendent<Animator>().enabled = false;

            var text = button.AddText(new Info("FolderText", anchorMin: Vector2.zero, anchorMax: Vector2.one), value);

            option.SetResetAction(new Action(() => text.SetText(defaultValue)));*/
#endif

            return option;
        }
    }
}