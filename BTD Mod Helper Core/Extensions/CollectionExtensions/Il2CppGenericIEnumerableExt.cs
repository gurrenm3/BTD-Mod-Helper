using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericIEnumerableExt
    {
        public static Il2CppSystem.Collections.IEnumerator GetCollectionsEnumerator<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.GetEnumerator().Cast<Il2CppSystem.Collections.IEnumerator>();
        }

        public static int Count<T>(this IEnumerable<T> enumerable)
        {
            int length = 0;
            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
                length++;

            return length;
        }

        public static Il2CppSystem.Object GetItem<T>(this IEnumerable<T> enumerable, int index)
        {
            int i = 0;
            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
            {
                if (i == index)
                    return enumerator.Current;
                i++;
            }

            return null;
        }


        public static List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            List<T> il2CppList = new List<T>();

            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
                il2CppList.Add(enumerator.Current.Cast<T>());

            return il2CppList;
        }

        public static System.Collections.Generic.List<T> ToSystemList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();

            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current.Cast<T>());

            return list;
        }

        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            Il2CppReferenceArray<T> il2cppArray = new Il2CppReferenceArray<T>(enumerable.Count());

            int i = 0;
            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
            {
                il2cppArray[i] = enumerator.Current.Cast<T>();
                i++;
            }

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable) where T : Il2CppSystem.Object
        {
            LockList<T> lockList = new LockList<T>();
            var enumerator = enumerable.GetCollectionsEnumerator();
            while (enumerator.MoveNext())
                lockList.Add(enumerator.Current.Cast<T>());

            return lockList;
        }
    }
}