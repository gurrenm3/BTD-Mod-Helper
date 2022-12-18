using Il2CppAssets.Scripts.Utils;
using System.Collections.Generic;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for system Lists
/// </summary>
public static partial class ListExt
{
    /// <summary>
    /// Not tested
    /// </summary>
    public static SizedList<T> ToSizedList<T>(this List<T> list)
    {
        var sizedList = new SizedList<T>();
        foreach (var item in list)
            sizedList.Add(item);

        return sizedList;
    }
}