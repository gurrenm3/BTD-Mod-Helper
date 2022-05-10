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

        /// <summary>
        /// (Cross-Game compatible) Return the last item in the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Last<T>(this IEnumerable<T> source) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            T last = default;

            while (enumerator.MoveNext())
            {
                last = enumerator.Current.Cast<T>();
            }
            return last;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the last item in the collection that meets the condition, or return default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T LastOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            T last = default;

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current.Cast<T>();
                if (predicate(item))
                    last = item;
            }

            return last;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element in the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T First<T>(this IEnumerable<T> source) where T : Il2CppSystem.Object 
        {
            var enumerator = source.GetEnumeratorCollections();

            while (enumerator.MoveNext())
            {
                return enumerator.Current.Cast<T>();
            }

            throw new Exception();
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element in the collection, or return default if it's null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this IEnumerable<T> source) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            if (enumerator is null)
                return default;

            while (enumerator.MoveNext())
            {
                return enumerator.Current.Cast<T>();
            }

            return default;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first element that matches the predicate, or return default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static T FirstOrDefault<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            var enumerator = source.GetEnumeratorCollections();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current.Cast<T>();
                if (predicate(item))
                    return item;
            }

            return default;
        }
    }
}