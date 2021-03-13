using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppReferenceArrayExt
    {
        /// <summary>
        /// Confirmed working
        /// </summary>
        public static List<T> ToList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            List<T> newList = new List<T>();
            foreach (T item in referenceArray)
                newList.Add(item);

            return newList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this Il2CppReferenceArray<T> referenceArray)
            where T : Il2CppSystem.Object
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (T item in referenceArray)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static T[] ToArray<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            T[] newArray = new T[] { };
            foreach (T item in referenceArray)
            {
                Array.Resize(ref newArray, newArray.Length + 1);
                newArray[newArray.Length - 1] = item;
            }

            return newArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            LockList<T> lockList = new LockList<T>();
            foreach (T item in referenceArray)
                lockList.Add(item);

            return lockList;
        }

        public static Il2CppReferenceArray<T> Duplicate<T>(this Il2CppReferenceArray<T> list) where T : Il2CppSystem.Object
        {
            List<T> newList = new List<T>();
            foreach (T item in list)
                newList.Add(item);

            return newList.ToIl2CppReferenceArray();
        }

        public static Il2CppReferenceArray<TCast> DuplicateAs<TSource, TCast>(this Il2CppReferenceArray<TSource> list)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            List<TCast> newList = new List<TCast>();
            foreach (TSource item in list)
                newList.Add(item.TryCast<TCast>());

            return newList.ToIl2CppReferenceArray();
        }






        public static bool HasItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            try { TSource result = referenceArray.First(item => item.IsType<TCast>()); }
            catch (Exception) { return false; }

            return true;
        }




        public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray, T objectToAdd) where T : Il2CppSystem.Object
        {
            if (referenceArray is null)
                referenceArray = new Il2CppReferenceArray<T>(0);

            Il2CppReferenceArray<T> newRef = new Il2CppReferenceArray<T>(referenceArray.Count + 1);
            for (int i = 0; i < referenceArray.Count; i++)
                newRef[i] = referenceArray[i];

            newRef[newRef.Length - 1] = objectToAdd;

            return newRef;
        }

        public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray, Il2CppReferenceArray<T> objectsToAdd) where T : Il2CppSystem.Object
        {
            if (referenceArray is null)
                referenceArray = new Il2CppReferenceArray<T>(0);

            int size = referenceArray.Count + objectsToAdd.Count;
            Il2CppReferenceArray<T> newReference = new Il2CppReferenceArray<T>(size);

            List<T> tempList = new List<T>(referenceArray);
            tempList.AddRange(objectsToAdd);

            for (int i = 0; i < tempList.Count; i++)
            {
                T item = tempList[i];
                newReference[i] = item;
            }

            return newReference;
        }

        public static Il2CppReferenceArray<T> AddTo<T>(this Il2CppReferenceArray<T> referenceArray, List<T> objectsToAdd) where T : Il2CppSystem.Object
        {
            return referenceArray.AddTo(objectsToAdd.ToIl2CppReferenceArray());
        }


        public static TCast GetItemOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TCast : Il2CppSystem.Object
            where TSource : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return null;

            TSource result = referenceArray.FirstOrDefault(item => item.TryCast<TCast>() != null);
            return result.TryCast<TCast>();
        }

        public static List<TCast> GetItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return null;

            List<TCast> results = new List<TCast>();
            foreach (var item in referenceArray)
            {
                if (item.IsType(out TCast tryCast))
                    results.Add(tryCast);
            }

            return results;
        }

        public static Il2CppReferenceArray<TSource> RemoveItemOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            TCast behavior = GetItemOfType<TSource, TCast>(referenceArray);
            return RemoveItem(referenceArray, behavior);
        }

        public static Il2CppReferenceArray<TSource> RemoveItem<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray, TCast itemToRemove)
            where TSource : Il2CppSystem.Object where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return referenceArray;

            List<TSource> arrayList = referenceArray.ToList();

            for (int i = 0; i < referenceArray.Count; i++)
            {
                TSource item = referenceArray[i];
                if (item is null || !item.Equals(itemToRemove.TryCast<TCast>()))
                    continue;

                arrayList.RemoveAt(i);
                break;
            }

            return arrayList.ToIl2CppReferenceArray();
        }


        public static Il2CppReferenceArray<TSource> RemoveItemsOfType<TSource, TCast>(this Il2CppReferenceArray<TSource> referenceArray)
            where TSource : Il2CppSystem.Object
            where TCast : Il2CppSystem.Object
        {
            if (!HasItemsOfType<TSource, TCast>(referenceArray))
                return referenceArray;

            int numRemoved = 0;
            List<TSource> arrayList = referenceArray.ToList();
            for (int i = 0; i < referenceArray.Count; i++)
            {
                TSource item = referenceArray[i];
                if (item is null || !item.IsType<TCast>())
                        continue;

                if (item is null || !item.IsType<TCast>())
                    continue;

                arrayList.RemoveAt(i - numRemoved);
                numRemoved++;
            }

            return arrayList.ToIl2CppReferenceArray();
        }
    }
}