using System;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class IEnumerableExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppSystem.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < enumerable.Count(); i++)
                il2CppList.Add(enumerable.ElementAt(i));

            return il2CppList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppReferenceArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(enumerable.Count());

            for (int i = 0; i < enumerable.Count(); i++)
                il2cppArray[i] = enumerable.ElementAt(i);

            return il2cppArray;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as LockList
        /// </summary>
        public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable)
        {
            LockList<T> lockList = new LockList<T>();
            for (int i = 0; i < enumerable.Count(); i++)
                lockList.Add(enumerable.ElementAt(i));

            return lockList;
        }



        /// <summary>
        /// (Cross-Game compatible) Return as a duplicate IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> Duplicate<T>(this IEnumerable<T> enumerable)
        {
            List<T> test = new List<T>();
            foreach (T item in enumerable)
                test.Add(item);

            return test.AsEnumerable();
        }

        /// <summary>
        /// (Cross-Game compatible) Return as a duplicate IEnumerable of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<TCast> DuplicateAs<TSource, TCast>(this IEnumerable<TSource> enumerable)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            List<TCast> test = new List<TCast>();
            foreach (TSource item in enumerable)
                test.Add(item.TryCast<TCast>());

            return test.AsEnumerable();
        }
        
        
        // Thanks to Dmitry Bychenko on StackOverflow for this
        public static T ArgMax<T, K>(this IEnumerable<T> source, 
            Func<T, K> map = null, 
            IComparer<K> comparer = null) {
            if (ReferenceEquals(null, source))
                throw new ArgumentNullException(nameof(source));

            T result = default(T);
            K maxKey = default(K);
            Boolean first = true;

            if (null == comparer)
                comparer = System.Collections.Generic.Comparer<K>.Default;

            if (null == map)
            {
                map = arg => (K)(object)arg;
            }
            
            foreach (var item in source) {
                K key = map(item);

                if (first || comparer.Compare(key, maxKey) > 0) {
                    first = false;
                    maxKey = key;
                    result = item;
                }
            }

            if (!first)
                return result;
            throw new ArgumentException("Can't compute ArgMax on empty sequence.", "source");
        }
    }
}