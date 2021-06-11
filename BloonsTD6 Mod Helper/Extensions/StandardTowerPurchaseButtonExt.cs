using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Extensions
{
    public static class StandardTowerPurchaseButtonExt
    {
        /// <summary>
        /// Set the background image of this button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="texture2D"></param>
        public static void SetBackground(this StandardTowerPurchaseButton button, Texture2D texture2D)
        {
            button.bg = button.gameObject.GetComponent<Image>();
            button.bg.overrideSprite.SetTexture(texture2D);
            button.bg.sprite.SetTexture(texture2D);

            //button.icon.sprite.SetTexture(texture2D);
            //button.icon.overrideSprite.SetTexture(texture2D);
            //button.UpdateIcon();
        }

        /// <summary>
        /// Set the background image of this button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="sprite"></param>
        public static void SetBackground(this StandardTowerPurchaseButton button, Sprite sprite)
        {
            button.bg = button.gameObject.GetComponent<Image>();
            button.bg.overrideSprite = sprite;
            button.bg.sprite = sprite;

            //button.icon.sprite = sprite;
            //button.icon.overrideSprite = sprite;
            //button.UpdateIcon();
        }
    }
}