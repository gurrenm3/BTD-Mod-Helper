using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ListExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this List<T> list)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (T item in list)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Confirmed working
        /// </summary>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this List<T> list) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(list.Count);

            for (int i = 0; i < list.Count; i++)
                il2cppArray[i] = list[i];

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this List<T> list)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (T item in list)
                lockList.Add(item);

            return lockList;
        }


        public static List<T> Duplicate<T>(this List<T> list)
        {
            List<T> newList = new List<T>();
            foreach (T item in list)
                newList.Add(item);

            return newList;
        }

        public static List<TCast> DuplicateAs<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            List<TCast> newList = new List<TCast>();
            foreach (TSource item in list)
                newList.Add(item.TryCast<TCast>());

            return newList;
        }




        public static bool HasItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                try
                {
                    if (item is TCast)
                        return true;

                    // old method of checking. Will remove once confirmed working
                    /*if (item.TryCast<TCast>() != null)
                        return true;*/
                }
                catch (Exception) { }
            }

            return false;
        }


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
                    if (item is TCast castItem)
                        return castItem;

                    // old method of checking. Will remove once confirmed working
                    /*if (item.TryCast<TCast>() != null)
                        return item.TryCast<TCast>();*/
                }
                catch (Exception) { }
            }

            return null;
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
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
                    if (item is TCast castItem)
                        results.Add(castItem);

                    // old method of checking. Will remove once confirmed working
                    /*TCast tryCast = item.TryCast<TCast>();
                    if (tryCast != null)
                        results.Add(tryCast);*/
                }
                catch (Exception) { }
            }

            return results;
        }

        public static List<TSource> RemoveItemOfType<TSource, TCast>(this List<TSource> list)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            TCast item = GetItemOfType<TSource, TCast>(list);
            return RemoveItem(list, item);
        }


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


        public static List<TSource> RemoveItemsOfType<TSource, TCast>(this List<TSource> list) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(list))
                return list;

            List<TSource> newList = list;
            int numRemoved = 0;
            for (int i = 0; i < list.Count; i++)
            {
                TSource item = list[i];
                if (item is null || !(item is TCast))
                    continue;

                // old method of checking. Will remove once confirmed working
                /*if (item is null || item.TryCast<TCast>() == null)
                    continue;*/

                newList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return newList;
        }
    }
}