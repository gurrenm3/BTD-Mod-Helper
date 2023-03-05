using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.OnVictory))]
internal class InGame_OnVictory
{
    [HarmonyPrefix]
    internal static bool Prefix(InGame __instance)
    {
        var result = true;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreOnVictory(__instance));
        return result;
    }
    
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnVictory());
    }
}