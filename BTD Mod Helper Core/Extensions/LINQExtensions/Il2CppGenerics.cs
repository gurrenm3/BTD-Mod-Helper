using Il2CppSystem.Collections.Generic;
using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppGenerics
    {
        /// <summary>
        /// (Cross-Game compatible) Return the first element that matches the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T First<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return item;
            }
            throw new NullReferenceException();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element that matches the predicate, or return default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            foreach (T item in source)
            {
                if (predicate(item))
                    return item;
            }
            return default;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all elements that match the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static List<T> Where<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the index of the element that matches the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static int FindIndex<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
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
        public static bool Any<T>(this List<T> source) where T : Il2CppSystem.Object
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
        public static bool Any<T>(this List<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return true;
            }
            return false;
        }
    }
}