using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Adding more deconstruct methods to things
    /// </summary>
    public static class DeconstructExt
    {
        
        public static void Deconstruct(this Rect rect, out float x, out float y, out float width, out float height)
        {
            x = rect.x;
            y = rect.y;
            width = rect.width;
            height = rect.height;
        }
        
        /// <summary>
        /// For some reason the Unity deconstruct isn't accessible in all places
        /// </summary>
        public static void Deconstruct(this Vector2 vector2, out float x, out float y)
        {
            x = vector2.x;
            y = vector2.y;
        }
    }
}