using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ArrayExt
    {
        /// <summary>
        /// Not Tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this T[] array)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (T item in array)
                sizedList.Add(item);

            return sizedList;
        }
    }
}
