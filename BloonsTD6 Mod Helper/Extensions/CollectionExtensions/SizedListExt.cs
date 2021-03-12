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
            List<T> newList = new List<T>();
            for (int i = 0; i < sizedList.count; i++)
                newList.Add(sizedList[i]);

            return newList;
        }

        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this SizedList<T> sizedList)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < sizedList.count; i++)
                il2CppList.Add(sizedList[i]);

            return il2CppList;
        }

        public static T[] ToArray<T>(this SizedList<T> sizedList)
        {
            T[] newArray = new T[] { };
            for (int i = 0; i < sizedList.count; i++)
            {
                T item = sizedList[i];
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this SizedList<T> sizedList) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(sizedList.Count);

            for (int i = 0; i < sizedList.Count; i++)
                il2cppArray[i] = sizedList[i];

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this SizedList<T> sizedList)
        {
            LockList<T> lockList = new LockList<T>();
            for (int i = 0; i < sizedList.count; i++)
                lockList.Add(sizedList[i]);

            return lockList;
        }


        public static SizedList<T> Duplicate<T>(this SizedList<T> list)
        {
            SizedList<T> newList = new SizedList<T>();
            for (int i = 0; i < list.count; i++)
                newList.Add(list[i]);

            return newList;
        }

        public static SizedList<TCast> DuplicateAs<TSource, TCast>(this SizedList<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            SizedList<TCast> newList = new SizedList<TCast>();
            for (int i = 0; i < list.count; i++)
                newList.Add(list[i].TryCast<TCast>());

            return newList;
        }







        public static bool HasItemsOfType<TSource, TCast>(this SizedList<TSource> sizedList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < sizedList.count; i++)
            {
                TSource item = sizedList[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
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

            for (int i = 0; i < sizedList.count; i++)
            {
                TSource item = sizedList[i];
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

            List<TCast> list = new List<TCast>();
            for (int i = 0; i < sizedList.count; i++)
            {
                TSource item = sizedList[i];
                try
                {
                    TCast tryCast = item.TryCast<TCast>();
                    if (tryCast != null)
                        list.Add(tryCast);
                }
                catch (Exception) { }
            }

            return list;
        }


        public static SizedList<TSource> RemoveItemOfType<TSource, TCast>(this SizedList<TSource> sizedList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            TCast behavior = GetItemOfType<TSource, TCast>(sizedList);
            return RemoveItem(sizedList, behavior);
        }


        public static SizedList<TSource> RemoveItem<TSource, TCast>(this SizedList<TSource> sizedList, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(sizedList))
                return sizedList;

            List<TSource> arrayList = sizedList.ToList();

            for (int i = 0; i < sizedList.Count; i++)
            {
                TSource item = sizedList[i];
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

            int numRemoved = 0;
            List<TSource> arrayList = sizedList.ToList();
            for (int i = 0; i < sizedList.Count; i++)
            {
                TSource item = sizedList[i];
                if (item is null || item.TryCast<TCast>() == null)
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToSizedList();
        }
    }
}