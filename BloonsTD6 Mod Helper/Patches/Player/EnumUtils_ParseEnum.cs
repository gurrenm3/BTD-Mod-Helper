using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using EnumUtils = Il2CppNewtonsoft.Json.Utilities.EnumUtils;

namespace BTD_Mod_Helper.Patches;

/// <summary>
/// Fix profiles with super old saved maps from when TowerSet was a string
/// </summary>
[HarmonyPatch(typeof(EnumUtils), nameof(EnumUtils.ParseEnum))]
internal static class EnumUtils_ParseEnum
{
    [HarmonyPrefix]
    internal static void Prefix(Type enumType, ref string value)
    {
        if (enumType != Il2CppType.Of<TowerSet>()) return;

        if (!int.TryParse(value, out _) && !Enum.GetNames(enumType).Contains(value))
        {
            value = nameof(TowerSet.None);
        }
    }
}