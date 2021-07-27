using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions
{
    public static class CollectionExt
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            throw new System.Exception($"{typeof(CollectionExt).FullName}\\GetValueOrDefault" +
                $" is not currently set up for BloonsAT. Contact devs if you are seeing this");
        }
    }
}
