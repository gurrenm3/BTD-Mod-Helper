using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class LockedListExt
    {
        /// <summary>
        /// Not Tested
        /// </summary>
        public static SizedList<T> ToSizedList<T>(this LockList<T> lockList)
        {
            SizedList<T> sizedList = new SizedList<T>();
            for (int i = 0; i < sizedList.Count; i++)
                sizedList.Add(sizedList[i]);

            return sizedList;
        }
    }
}
