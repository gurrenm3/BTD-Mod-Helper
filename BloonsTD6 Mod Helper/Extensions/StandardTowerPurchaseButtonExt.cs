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
            var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2 (0.5f, 0.5f), 100f, 0u, SpriteMeshType.Tight);

            button.bg.overrideSprite = sprite;
            button.bg.sprite = sprite;
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
        }

        /// <summary>
        /// Set the background image of this button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="texture2D"></param>
        /// <param name="requiredTowerBaseId">Only change the background if the button shares this baseId</param>
        public static void SetBackground(this StandardTowerPurchaseButton button, Texture2D texture2D, string requiredTowerBaseId)
        {
            if (button.baseTowerModel.GetBaseId().Contains(requiredTowerBaseId))
            {
                button.SetBackground(texture2D);
            }
        }

        /// <summary>
        /// Set the background image of this button
        /// </summary>
        /// <param name="button"></param>
        /// <param name="sprite"></param>
        /// <param name="requiredTowerBaseId">Only change the background if the button shares this baseId</param>
        public static void SetBackground(this StandardTowerPurchaseButton button, Sprite sprite, string requiredTowerBaseId)
        {
            if (button.baseTowerModel.GetBaseId().Contains(requiredTowerBaseId))
            {
                button.SetBackground(sprite);
            }
        }
    }
}