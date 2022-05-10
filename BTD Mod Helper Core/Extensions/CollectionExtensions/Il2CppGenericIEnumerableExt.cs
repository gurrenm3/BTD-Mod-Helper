﻿using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericIEnumerableExt
    {
        /// <summary>
        /// (Cross-Game compatible) Get the IEnumerator as type Il2CppSystem.Collections.IEnumerator. Needed for IEnumerator.MoveNext(). Not the same as IEnumerable.GetEnumerator()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static Il2CppSystem.Collections.IEnumerator GetEnumeratorCollections<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.GetEnumerator().Cast<Il2CppSystem.Collections.IEnumerator>();
        }

        /// <summary>
        /// (Cross-Game compatible) Get the total number of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static int Count<T>(this IEnumerable<T> enumerable)
        {
            int length = 0;
            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
                length++;

            return length;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the Item at a specific index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Il2CppSystem.Object GetItem<T>(this IEnumerable<T> enumerable, int index)
        {
            int i = 0;
            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
            {
                if (i == index)
                    return enumerator.Current;
                i++;
            }

            return null;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppSystem.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            List<T> il2CppList = new List<T>();

            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
                il2CppList.Add(enumerator.Current.Cast<T>());

            return il2CppList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as System.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<T> ToList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();

            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current.Cast<T>());

            return list;
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

            int i = 0;
            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
            {
                il2cppArray[i] = enumerator.Current.Cast<T>();
                i++;
            }

            return il2cppArray;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as LockList
        /// </summary>
        public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            LockList<T> lockList = new LockList<T>();
            var enumerator = enumerable.GetEnumeratorCollections();
            while (enumerator.MoveNext())
                lockList.Add(enumerator.Current.Cast<T>());

            return lockList;
        }
    }
}