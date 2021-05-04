using System;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class ArrayExt
    {
        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="match"> The Predicate<T> delegate that defines the conditions of the elements to search for.</param>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match);
        }
    }
}
