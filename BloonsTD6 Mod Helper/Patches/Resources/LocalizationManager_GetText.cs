using BTD_Mod_Helper.Api.Data;
using Il2CppNinjaKiwi.Common;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(LocalizationManager), nameof(LocalizationManager.GetText))]
internal static class LocalizationManager_GetText
{
    [HarmonyPrefix]
    private static bool Prefix(string key, ref string __result)
    {
        return !ModTextOverride.TryGetOverride(key, out __result);
    }
}