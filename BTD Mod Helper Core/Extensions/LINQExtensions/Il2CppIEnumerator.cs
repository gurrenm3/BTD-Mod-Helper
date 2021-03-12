using System;
using Il2CppSystem.Collections;
using System.Text;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class Il2CppIEnumerator
    {
        public static T First<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
                if (predicate(item))
                    return item;
            }
            throw new NullReferenceException();
        }

        public static T FirstOrDefault<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
                if (predicate(item))
                    return item;
            }
            return default;
        }

        public static List<T> Where<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            List<T> result = new List<T>();
            while (source.MoveNext())
            {
                var item = source.Current.Cast<T>();
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        public static int FindIndex<T>(this IEnumerator source, Func<T, bool> predicate) where T : Il2CppSystem.Object
        {
            int i = 0;
            while (source.MoveNext())
            {
                if (predicate(source.Current.Cast<T>()))
                    return i;
                i++;
            }

            return -1;
        }

        public static bool Any<T>(this IEnumerator source) where T : Il2CppSystem.Object
        {
            while (source.MoveNext())
                return true;

            return false;
        }
    }
}
