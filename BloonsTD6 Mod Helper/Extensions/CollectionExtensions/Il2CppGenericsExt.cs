using Assets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericsExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this List<T> il2CppList)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (T item in il2CppList)
                sizedList.Add(item);

            return sizedList;
        }
    }
}