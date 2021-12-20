using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class ButtonExt
    {
        public static void AddOnClick(this Button button, Function funcToExecute)
        {
            button.onClick.AddListener(funcToExecute);
        }

        public static void SetOnClick(this Button button, Function funcToExecute)
        {
            button.onClick.SetListener(funcToExecute);
        }

        public static void RemoveOnClickAction(this Button button, int actionIndex)
        {
            button.onClick.RemovePersistantCall(actionIndex);
        }

        /// <summary>
        /// Set the sprite for this button.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="sprite">Sprite to change to</param>
        /// <param name="newSpriteName">Optionally provide a new name for the sprite</param>
        public static void SetSprite(this Button button, Sprite sprite, string newSpriteName = "")
        {
            button.image.sprite = sprite;
            if (!string.IsNullOrEmpty(newSpriteName))
                button.image.sprite.name = newSpriteName;
        }
    }
}