using System;
using Il2CppSystem.Collections;
using System.Text;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppIEnumerator
    {
        /// <summary>
        /// (Cross-Game compatible) Performs the specified action on each element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">Action to preform on each element</param>
        public static void ForEach<T>(this IEnumerator source, Action<T> action) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
                action.Invoke(source.Current.Cast<T>());
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element that matches the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T First<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
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
        public static T FirstOrDefault<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
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
        public static List<T> Where<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
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
        public static int FindIndex<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            int i = 0;
            while (source.MoveNext())
            {
                if (predicate(source.Current.Cast<T>()))
                    return i;
                i++;
            }

            return -1;
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not there are any elements in this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerator source)
        {
            while (source.MoveNext())
                return true;

            return false;
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not there are any elements in this that match the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
            {
                if (predicate(source.Current.Cast<T>()))
                    return true;
            }
            return false;
        }
    }
}
