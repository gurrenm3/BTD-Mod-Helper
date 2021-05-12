using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class GameObjectExt
    {
        public static T GetComponent<T>(this GameObject gameObject, string componentPath)
        {
            return gameObject.transform.Find(componentPath).GetComponent<T>();
        }

        /// <summary>
        /// (Cross-Game compatible) Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public static T GetComponentInChildrenByName<T>(this GameObject gameObject, string componentName) where T : Component
        {
            return gameObject.transform.GetComponentsInChildren<T>().FirstOrDefault(component => component.name == componentName);
        }

        /// <summary>
        /// (Cross-Game compatible) Makes the Game Object visible by setting the scale to the default value of 1
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Show(this GameObject gameObject)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1);
        }

        /// <summary>
        /// (Cross-Game compatible) Makes the Game Object hidden (not visible) by setting the scale to zero
        /// </summary>
        /// <param name="gameObject"></param>
        public static void Hide(this GameObject gameObject)
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not this GameObject's scale is set to zero (not visible)
        /// </summary>
        /// <param name="gameObject"></param>
        public static bool IsVisible(this GameObject gameObject)
        {
            var scale = gameObject.GetComponent<RectTransform>().localScale;
            return (scale.x != 0) && (scale.y != 0);
        }
    }
}
