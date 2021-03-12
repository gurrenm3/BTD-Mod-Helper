using Assets.Scripts.Utils;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppReferenceArrayExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (T item in referenceArray)
                sizedList.Add(item);

            return sizedList;
        }
    }
}