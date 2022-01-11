using System;
using System.Linq;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.Components
{
    /// <summary>
    /// ModHelperComponent for a 
    /// </summary>
    [RegisterTypeInIl2Cpp(false)]
    public class ModHelperDropdown : ModHelperComponent
    {
        /// <summary>
        /// The Image being displayed
        /// </summary>
        public Image Background { get; private set; }

        public ModHelperText Text { get; private set; }

        public TMP_Dropdown Dropdown { get; private set; }

        public ModHelperImage Arrow { get; private set; }
        
        public GameObject Template { get; private set; }

        /// <inheritdoc />
        public ModHelperDropdown(IntPtr ptr) : base(ptr)
        {
        }


        public static ModHelperDropdown Create(Rect rect, List<TMP_Dropdown.OptionData> options,
            string objectName = "ModHelperDropdown", SpriteReference background = null, float labelFontSize = 42f)
        {
            var modHelperDropdown = ModHelperComponent.Create<ModHelperDropdown>(rect, objectName);

            var text = modHelperDropdown.Text = modHelperDropdown.AddText(rect, "", labelFontSize);


            var dropdown = modHelperDropdown.Dropdown = modHelperDropdown.AddComponent<TMP_Dropdown>();
            dropdown.captionText = text.Text;

            if (background != null)
            {
                var image = dropdown.image = modHelperDropdown.Background = modHelperDropdown.AddComponent<Image>();
                image.SetSprite(background);
            }

            modHelperDropdown.Arrow = modHelperDropdown.AddImage(
                new Rect(rect.width / 2 - 64, 0, 64, 40), VanillaSprites.MonkeyKnowledgeArrow, "Arrow");

            dropdown.options = options;

            

            return modHelperDropdown;
        }
    }
}