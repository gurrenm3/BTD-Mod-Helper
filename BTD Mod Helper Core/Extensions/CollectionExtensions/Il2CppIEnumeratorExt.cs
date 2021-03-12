using Assets.Scripts.Utils;
using Il2CppSystem.Collections;
using System.Collections.Generic;
using UnhollowerBaseLib;


namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppIEnumeratorExt
    {
        public static int Count(this IEnumerator enumerator)
        {
            int length = 0;

            while (enumerator.MoveNext())
                length++;

            return length;
        }

        public static Il2CppSystem.Object GetItem(this IEnumerator enumerator, int index)
        {
            int i = 0;
            while (enumerator.MoveNext())
            {
                if (i == index)
                    return enumerator.Current;
                i++;
            }

            return null;
        }


        public static List<Il2CppSystem.Object> ToSystemList(this IEnumerator enumerator)
        {
            List<Il2CppSystem.Object> newList = new List<Il2CppSystem.Object>();
            while (enumerator.MoveNext())
                newList.Add(enumerator.Current);

            return newList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> ToIl2CppList(this IEnumerator enumerator)
        {
            Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> il2CppList = 
                new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

            while (enumerator.MoveNext())
                il2CppList.Add(enumerator.Current);

            return il2CppList;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static Il2CppReferenceArray<Il2CppSystem.Object> ToIl2CppReferenceArray(this IEnumerator enumerator)
        {
            Il2CppReferenceArray<Il2CppSystem.Object> il2cppArray = 
            new Il2CppReferenceArray<Il2CppSystem.Object>(enumerator.Count());

            int i = 0;
            while (enumerator.MoveNext())
            {
                il2cppArray[i] = enumerator.Current;
                i++;
            }


            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<Il2CppSystem.Object> ToLockList(this IEnumerator enumerator)
        {
            LockList<Il2CppSystem.Object> lockList = new LockList<Il2CppSystem.Object>();
            while (enumerator.MoveNext())
                lockList.Add(enumerator.Current);

            return lockList;
        }
    }
}
