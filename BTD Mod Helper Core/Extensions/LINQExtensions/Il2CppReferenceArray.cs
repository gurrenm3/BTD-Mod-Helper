using System;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppReferenceArray
    {
        /// <summary>
        /// (Cross-Game compatible) Performs the specified action on each element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">Action to preform on each element</param>
        public static void ForEach<T>(this Il2CppReferenceArray<T> source, Action<T> action) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
                action.Invoke(source[i]);
        }

        /// <summary>
        /// (Cross-Game compatible) Return the index of the element that matches the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int FindIndex<T>(this Il2CppReferenceArray<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not there are any elements in this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Any<T>(this Il2CppReferenceArray<T> source) where T : Il2CppSystem.Object
        {
            return source.Count > 0;
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not there are any elements in this that match the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<T>(this Il2CppReferenceArray<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                    return true;
            }
            return false;
        }
    }
}
