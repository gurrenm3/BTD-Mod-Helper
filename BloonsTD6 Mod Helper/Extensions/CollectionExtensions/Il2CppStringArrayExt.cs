namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for Il2CppStringArrays
/// </summary>
public static class Il2CppStringArrayExt
{
    /// <summary>
    /// Return this with an Item added to it
    /// </summary>
    /// <param name="array"></param>
    /// <param name="itemToAdd"></param>
    /// <returns></returns>
    public static Il2CppStringArray AddTo(this Il2CppStringArray array, string itemToAdd)
    {
        var newArray = new Il2CppStringArray(array.Length + 1);
        for (var i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }
        newArray[newArray.Length - 1] = itemToAdd;
        return newArray;
    }
}