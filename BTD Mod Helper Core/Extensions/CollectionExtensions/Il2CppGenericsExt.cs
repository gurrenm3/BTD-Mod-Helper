using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using System;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericsExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return as System.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="il2CppList"></param>
        /// <returns></returns>
        public static System.Collections.Generic.List<T> ToList<T>(this List<T> il2CppList)
        {
            System.Collections.Generic.List<T> newList = new System.Collections.Generic.List<T>();
            foreach (T item in il2CppList)
                newList.Add(item);

            return newList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as an Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="il2CppList"></param>
        /// <returns></returns>
        public static T[] ToArray<T>(this List<T> il2CppList)
        {
            T[] newArray = new T[] { };

            foreach (T item in il2CppList)
            {
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppReferenceArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="il2CppList"></param>
        /// <returns></returns>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this List<T> il2CppList) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(il2CppList.Count);

            for (int i = 0; i < il2CppList.Count; i++)
                il2cppArray[i] = il2CppList[i];

            return il2cppArray;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as LockList
        /// </summary>
        public static LockList<T> ToLockList<T>(this List<T> il2CppList)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (T item in il2CppList)
                lockList.Add(item);

            return lockList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return a duplicate of this List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<T> Duplicate<T>(this List<T> list)
        {
            List<T> newList = new List<T>();
            foreach (T item in list)
                newList.Add(item);

            return newList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return a duplicate of this list as type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TCast> DuplicateAs<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            List<TCast> newList = new List<TCast>();
            foreach (TSource item in list)
                newList.Add(item.TryCast<TCast>());

            return newList;
        }


        /// <summary>
        /// (Cross-Game compatible) Check if this has any items of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type you're checking for</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                try
                {
                    if (item.IsType<TCast>())
                        return true;
                }
                catch (Exception) { }
            }

            return false;
        }

        /// <summary>
        /// (Cross-Game compatible) Return the first item of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item you want</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static TCast GetItemOfType<TSource, TCast>(this List<TSource> list) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return null;

            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return item.TryCast<TCast>();
                }
                catch (Exception) { }
            }

            return null;
        }

        /// <summary>
        /// (Cross-Game compatible) Return all Items of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Items you want</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TCast> GetItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return null;

            List<TCast> results = new List<TCast>();
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                try
                {
                    if (item.IsType(out TCast tryCast))
                        results.Add(tryCast);
                }
                catch (Exception) { }
            }

            return results;
        }

        /// <summary>
        /// (Cross-Game compatible) Return this with the first Item of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TSource> RemoveItemOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            TCast item = GetItemOfType<TSource, TCast>(list);
            return RemoveItem(list, item);
        }

        /// <summary>
        /// (Cross-Game compatible) Return this with the first Item of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
        /// <param name="list"></param>
        /// <param name="itemToRemove">The specific Item to remove</param>
        /// <returns></returns>
        public static List<TSource> RemoveItem<TSource, TCast>(this List<TSource> list, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return list;

            List<TSource> newList = list;
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                newList.RemoveAt(i);
                break;
            }
            return newList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return this with all Items of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<TSource> RemoveItemsOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return list;

            List<TSource> newList = list;
            int numRemoved = 0;
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                if (item is null || !item.IsType<TCast>())
                    continue;

                newList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return newList;
        }
    }
}