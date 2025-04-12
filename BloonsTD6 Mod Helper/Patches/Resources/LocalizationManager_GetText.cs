using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using BTD_Mod_Helper.Api.Data;
using Il2CppNinjaKiwi.Common;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch]
internal static class LocalizationManager_GetText
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(LocalizationManager), nameof(LocalizationManager.GetText));
        yield return AccessTools.Method(typeof(LocalizationManager), nameof(LocalizationManager.GetTextEnglish));
        yield return AccessTools.Method(typeof(LocalizationManager), nameof(LocalizationManager.Format),
            [typeof(string), typeof(Il2CppSystem.Object[])]);
        yield return AccessTools.Method(typeof(LocalizationManager), nameof(LocalizationManager.Format),
            [typeof(string), typeof(Il2CppReferenceArray<Il2CppSystem.Object>)]);
    }

    [HarmonyPrefix]
    private static bool Prefix(string key, ref string __result) => !ModTextOverride.TryGetOverride(key, out __result);

    [HarmonyPostfix]
    private static void Postfix(LocalizationManager __instance, string key, ref string __result, MethodBase __originalMethod)
    {
        if (__result == null || !__result.Contains('[') || !__result.Contains(']')) return;

        __result = Regex.Replace(__result, @"\[(.*?)\]", match =>
        {
            var subKey = match.Groups[1].Value;
            return subKey != key && __instance.ContainsKey(subKey)
                ? (string) __originalMethod.Invoke(__instance, [subKey])!
                : $"[{subKey}]";
        }, RegexOptions.Compiled);
    }
}