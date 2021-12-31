using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class SizedListExt
    {
        public static List<T> ToList<T>(this SizedList<T> sizedList)
        {
            var newList = new List<T>();
            for (var i = 0; i < sizedList.count; i++)
                newList.Add(sizedList[i]);

            return newList;
        }

        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this SizedList<T> sizedList)
        {
            var il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (var i = 0; i < sizedList.count; i++)
                il2CppList.Add(sizedList[i]);

            return il2CppList;
        }

        public static T[] ToArray<T>(this SizedList<T> sizedList)
        {
            var newArray = new T[] { };
            for (var i = 0; i < sizedList.count; i++)
            {
                var item = sizedList[i];
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this SizedList<T> sizedList) where T : Il2CppSystem.Object
        {
            var il2cppArray = new Il2CppReferenceArray<T>(sizedList.Count);

            for (var i = 0; i < sizedList.Count; i++)
                il2cppArray[i] = sizedList[i];

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this SizedList<T> sizedList)
        {
            var lockList = new LockList<T>();
            for (var i = 0; i < sizedList.count; i++)
                lockList.Add(sizedList[i]);

            return lockList;
        }


        public static SizedList<T> Duplicate<T>(this SizedList<T> list)
        {
            var newList = new SizedList<T>();
            for (var i = 0; i < list.count; i++)
                newList.Add(list[i]);

            return newList;
        }

        public static SizedList<TCast> DuplicateAs<TSource, TCast>(this SizedList<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            var newList = new SizedList<TCast>();
            for (var i = 0; i < list.count; i++)
                newList.Add(list[i].TryCast<TCast>());

            return newList;
        }







        public static bool HasItemsOfType<TSource, TCast>(this SizedList<TSource> sizedList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (var i = 0; i < sizedList.count; i++)
            {
                var item = sizedList[i];
                try
                {
                    if (item.IsType<TCast>())
                        return true;
                }
                catch (Exception) { }
            }

            return false;
        }


        // Might be removed. Need to see if normal Add works
        /*public static SizedList<T> AddTo<T>(this SizedList<T> sizedList, T objectToAdd) where T : Il2CppSystem.Object
        {
            if (sizedList is null)
                sizedList = new SizedList<T>();

            var list = sizedList.ToList();
            list.Add(objectToAdd);
            return list.ToSizedList();
        }*/

        public static TCast GetItemOfType<TSource, TCast>(this SizedList<TSource> sizedList) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(sizedList))
                return null;

            for (var i = 0; i < sizedList.count; i++)
            {
                var item = sizedList[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return item.TryCast<TCast>();
                }
                catch (Exception) { }
            }

            return null;
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this SizedList<TSource> sizedList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(sizedList))
                return null;

            var results = new List<TCast>();
            for (var i = 0; i < sizedList.count; i++)
            {
                var item = sizedList[i];
                try
                {
                    if (item.IsType(out TCast tryCast))
                        results.Add(tryCast);
                }
                catch (Exception) { }
            }

            return results;
        }


        public static SizedList<TSource> RemoveItemOfType<TSource, TCast>(this SizedList<TSource> sizedList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            var behavior = GetItemOfType<TSource, TCast>(sizedList);
            return RemoveItem(sizedList, behavior);
        }


        public static SizedList<TSource> RemoveItem<TSource, TCast>(this SizedList<TSource> sizedList, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(sizedList))
                return sizedList;

            var arrayList = sizedList.ToList();

            for (var i = 0; i < sizedList.Count; i++)
            {
                var item = sizedList[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            return arrayList.ToSizedList();
        }


        public static SizedList<TSource> RemoveItemsOfType<TSource, TCast>(this SizedList<TSource> sizedList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(sizedList))
                return sizedList;

            var numRemoved = 0;
            var arrayList = sizedList.ToList();
            for (var i = 0; i < sizedList.Count; i++)
            {
                var item = sizedList[i];
                if (item is null || !item.IsType<TCast>())
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToSizedList();
        }
    }
}