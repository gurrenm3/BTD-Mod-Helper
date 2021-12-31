using System.Linq;
using MelonLoader;
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

        public static void Destroy(this GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
        
        public static void RecursivelyLog(this GameObject gameObject, int depth = 0)
        {
            var str = gameObject.name;
            for (var i = 0; i < depth; i++)
            {
                str = "|  " + str;
            }

            str += " (";
            foreach (var component in gameObject.GetComponents<Component>())
            {
                str += " " + component.GetIl2CppType().Name;
            }

            str += ")";
            MelonLogger.Msg(str);
            for (var i = 0; i < gameObject.transform.childCount; i++)
            {
                RecursivelyLog(gameObject.transform.GetChild(i).gameObject, depth + 1);
            }
        }
        
        /// <summary>
        /// (Cross-Game compatible) Translates this GameObject scaled with it's "lossyScale", making it move the same
        /// amount regardless of screen resolution
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="translation"></param>
        public static void TranslateScaled(this GameObject gameObject, Vector3 translation)
        {
            var transform = gameObject.transform;
            transform.TranslateScaled(translation);
        }
    }
}
