using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.Map;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(MapLoader), nameof(MapLoader.LoadScene))]
internal static class MapLoader_LoadScene
{
    [HarmonyPrefix]
    private static bool Prefix(ref MapLoader __instance)
    {
        var result = true;
        var unref__instance = __instance;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreMapLoaded(ref unref__instance));
        __instance = unref__instance;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(MapLoader __instance)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostMapLoaded(__instance));
    }
}