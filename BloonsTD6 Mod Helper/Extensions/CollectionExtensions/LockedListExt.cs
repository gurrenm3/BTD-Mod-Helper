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
            var sizedList = new SizedList<T>();
            for (var i = 0; i < sizedList.Count; i++)
                sizedList.Add(sizedList[i]);

            return sizedList;
        }
    }
}
