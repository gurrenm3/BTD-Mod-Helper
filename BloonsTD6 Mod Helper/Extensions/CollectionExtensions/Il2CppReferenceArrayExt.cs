using Assets.Scripts.Utils;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Il2cpp arrays
/// </summary>
public static partial class Il2CppReferenceArrayExt
{
    /// <summary>
    /// Not tested
    /// </summary>
    public static SizedList<T> ToSizedList<T>(this Il2CppReferenceArray<T> referenceArray) where T : Il2CppSystem.Object
    {
        var sizedList = new SizedList<T>();
        foreach (var item in referenceArray)
            sizedList.Add(item);

        return sizedList;
    }
}