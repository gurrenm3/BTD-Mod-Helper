using System;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericIEnumerable
    {
        /// <summary>
        /// (Cross-Game compatible) Performs the specified action on each element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action">Action to preform on each element</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            while (enumerator.MoveNext())
                action.Invoke(enumerator.Current.Cast<T>());
        }

        /// <summary>
        /// (Cross-Game compatible) Return whether or not there are any elements in this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool Any<T>(this IEnumerable<T> source) where T : Il2CppSystem.Object
        {
            while (source.GetEnumeratorCollections().MoveNext())
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
        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            while (enumerator.MoveNext())
            {
                if (predicate(enumerator.Current.Cast<T>()))
                    return true;
            }

            return false;
        }
    }
}