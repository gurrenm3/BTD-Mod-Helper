using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class LockedList
    {
        /// <summary>
        /// (Cross-Game compatible) Performs the specified action on each element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">Action to preform on each element</param>
        public static void ForEach<T>(this LockList<T> source, Action<T> action)
        {
            for (int i = 0; i < source.Count; i++)
                action.Invoke(source[i]);
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element that matches the predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T First<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                T item = source[i];
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
        public static T FirstOrDefault<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            for (int i = 0; i < source.Count; i++)
            {
                T item = source[i];
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
        public static List<T> Where<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            for (int i = 0; i < source.Count; i++)
            {
                T item = source[i];
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
        public static int FindIndex<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
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
        public static bool Any<T>(this LockList<T> source) where T : Il2CppSystem.Object
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
        public static bool Any<T>(this LockList<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
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
