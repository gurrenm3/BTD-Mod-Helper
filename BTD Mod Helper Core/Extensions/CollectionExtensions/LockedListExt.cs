using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class LockedListExt
    {
        public static List<T> ToList<T>(this LockList<T> lockList)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < lockList.Count; i++)
                newList.Add(lockList[i]);

            return newList;
        }

        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this LockList<T> lockList)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < lockList.Count; i++)
                il2CppList.Add(lockList[i]);

            return il2CppList;
        }

        public static T[] ToArray<T>(this LockList<T> lockList)
        {
            T[] newArray = new T[] { };
            for (int i = 0; i < lockList.Count; i++)
            {
                T item = lockList[i];
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this LockList<T> lockList) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(lockList.Count);

            for (int i = 0; i < lockList.Count; i++)
                il2cppArray[i] = lockList[i];

            return il2cppArray;
        }


        public static LockList<T> Duplicate<T>(this LockList<T> list)
        {
            LockList<T> newList = new LockList<T>();
            for (int i = 0; i < list.Count; i++)
                newList.Add(list[i]);

            return newList;
        }

        public static LockList<TCast> DuplicateAs<TSource, TCast>(this LockList<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            LockList<TCast> newList = new LockList<TCast>();
            for (int i = 0; i < list.Count; i++)
                newList.Add(list[i].TryCast<TCast>());

            return newList;
        }







        public static bool HasItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
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


        public static LockList<TSource> AddTo<TSource, TCast>(this LockList<TSource> lockList, TCast objectToAdd)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (lockList is null)
                lockList = new LockList<TSource>();

            lockList.Add(objectToAdd.TryCast<TSource>());
            return lockList;
        }


        public static TCast GetItemOfType<TSource, TCast>(this LockList<TSource> lockList) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(lockList))
                return null;

            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
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

        public static List<TCast> GetItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(lockList))
                return null;

            List<TCast> list = new List<TCast>();
            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
                try
                {
                    if (item is TCast castItem)
                        list.Add(castItem);

                    // old method of checking. Will remove once confirmed working
                    /*TCast tryCast = item.TryCast<TCast>();
                    if (tryCast != null)
                        list.Add(tryCast);*/
                }
                catch (Exception) { }
            }

            return list;
        }


        public static LockList<TSource> RemoveItemOfType<TSource, TCast>(this LockList<TSource> lockList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            TCast behavior = GetItemOfType<TSource, TCast>(lockList);
            return RemoveItem(lockList, behavior);
        }


        public static LockList<TSource> RemoveItem<TSource, TCast>(this LockList<TSource> lockList, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(lockList))
                return lockList;

            List<TSource> arrayList = lockList.ToList();

            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            return arrayList.ToLockList();
        }


        public static LockList<TSource> RemoveItemsOfType<TSource, TCast>(this LockList<TSource> lockList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(lockList))
                return lockList;

            int numRemoved = 0;
            List<TSource> arrayList = lockList.ToList();
            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
                if (item is null || !(item is TCast))
                    continue;
                
                // old method of checking. Will remove once confirmed working
                /*if (item is null || item.TryCast<TCast>() == null)
                    continue;*/

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToLockList();
        }
    }
}
