using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class LockedListExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return as System.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this LockList<T> lockList)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < lockList.Count; i++)
                newList.Add(lockList[i]);

            return newList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppSystem.List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this LockList<T> lockList)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            for (int i = 0; i < lockList.Count; i++)
                il2CppList.Add(lockList[i]);

            return il2CppList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return as System.Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
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

        /// <summary>
        /// (Cross-Game compatible) Return as Il2CppReferenceArray
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this LockList<T> lockList) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(lockList.Count);

            for (int i = 0; i < lockList.Count; i++)
                il2cppArray[i] = lockList[i];

            return il2cppArray;
        }

        /// <summary>
        /// (Cross-Game compatible) Return a duplicate of this
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LockList<T> Duplicate<T>(this LockList<T> list)
        {
            LockList<T> newList = new LockList<T>();
            for (int i = 0; i < list.Count; i++)
                newList.Add(list[i]);

            return newList;
        }

        /// <summary>
        /// (Cross-Game compatible) Return a duplicate of this as type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LockList<TCast> DuplicateAs<TSource, TCast>(this LockList<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            LockList<TCast> newList = new LockList<TCast>();
            for (int i = 0; i < list.Count; i++)
                newList.Add(list[i].TryCast<TCast>());

            return newList;
        }


        /// <summary>
        /// (Cross-Game compatible) Return this with an additional Item added to it
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item to add</typeparam>
        /// <param name="lockList"></param>
        /// <param name="objectToAdd">Item to add</param>
        /// <returns></returns>
        public static LockList<TSource> AddTo<TSource, TCast>(this LockList<TSource> lockList, TCast objectToAdd)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (lockList is null)
                lockList = new LockList<TSource>();

            lockList.Add(objectToAdd.TryCast<TSource>());
            return lockList;
        }



        /// <summary>
        /// (Cross-Game compatible) Check if this has any items of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type you're checking for</typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static bool HasItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
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
        /// <param name="lockList"></param>
        /// <returns></returns>
        [Obsolete]
        public static TCast GetItemOfType<TSource, TCast>(this LockList<TSource> lockList) where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            TCast cast = null;
            var result = lockList.FirstOrDefault(item => item.IsType(out cast));
            return cast;

            // Switching to new Linq extension
            /*if (!HasItemsOfType<TSource, TCast>(lockList))
                return null;

            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
                try
                {
                    if (item.TryCast<TCast>() != null)
                        return item.TryCast<TCast>();
                }
                catch (Exception) { }
            }

            return null;*/
        }

        /// <summary>
        /// (Cross-Game compatible) Return all Items of type TCast
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Items you want</typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static List<TCast> GetItemsOfType<TSource, TCast>(this LockList<TSource> lockList) where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            List<TCast> result = new List<TCast>();
            lockList.ForEach(item => 
            {
                if (item.IsType(out TCast cast))
                    result.Add(cast);
            });
            return result;

            // Switching to new Linq extension
            /*if (!HasItemsOfType<TSource, TCast>(lockList))
                return null;

            List<TCast> results = new List<TCast>();
            for (int i = 0; i < lockList.Count; i++)
            {
                TSource item = lockList[i];
                try
                {
                    if (item.IsType(out TCast tryCast))
                        results.Add(tryCast);
                }
                catch (Exception) { }
            }

            return results;*/
        }

        /// <summary>
        /// (Cross-Game compatible) Return this with the first Item of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
        public static LockList<TSource> RemoveItemOfType<TSource, TCast>(this LockList<TSource> lockList)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            var behavior = lockList.First(o => o.IsType<TCast>()).Cast<TCast>();
            return RemoveItem(lockList, behavior);
        }

        /// <summary>
        /// (Cross-Game compatible) Return this with the first Item of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Item you want to remove</typeparam>
        /// <param name="lockList"></param>
        /// <param name="itemToRemove">The specific Item to remove</param>
        /// <returns></returns>
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

        /// <summary>
        /// (Cross-Game compatible) Return this with all Items of type TCast removed
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCast">The Type of the Items that you want to remove</typeparam>
        /// <param name="lockList"></param>
        /// <returns></returns>
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
                if (item is null || !item.IsType<TCast>())
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToLockList();
        }
    }
}
