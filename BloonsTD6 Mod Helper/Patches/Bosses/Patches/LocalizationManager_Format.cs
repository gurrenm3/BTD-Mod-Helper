using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(LocalizationManager), nameof(LocalizationManager.Format), typeof(string),
    typeof(Il2CppReferenceArray<Object>))]
internal static class LocalizationManager_Format_string_Il2CppReferenceArray_Object
{
    [HarmonyPrefix]
    private static void Prefix(Il2CppReferenceArray<Object> args)
    {
        if (args is null || args.Length == 0)
            return;
        if (int.TryParse(args[0].ToString(), out var num) && ModBoss.Cache.TryGetValue(num, out var boss))
        {
            args[0] = boss.DisplayName;
        }
    }
}

[HarmonyPatch(typeof(LocalizationManager), nameof(LocalizationManager.Format), typeof(string),
    typeof(Object[]))]
internal static class LocalizationManager_Format_string_ObjectArray
{
    [HarmonyPrefix]
    private static void Prefix(Object[] args)
    {
        if (args is null || args.Length == 0)
            return;
        if (int.TryParse(args[0].ToString(), out var num) && ModBoss.Cache.TryGetValue(num, out var boss))
        {
            args[0] = boss.DisplayName;
        }
    }
}