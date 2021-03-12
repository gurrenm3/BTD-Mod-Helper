using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class Il2CppGenericIEnumerable
    {
        public static bool Any<T>(this IEnumerable<T> source) where T : Il2CppSystem.Object
        {
            while (source.GetCollectionsEnumerator().MoveNext())
                return true;

            return false;
        }
    }
}