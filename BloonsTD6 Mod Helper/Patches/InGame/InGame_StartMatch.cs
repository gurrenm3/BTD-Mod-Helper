using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
internal class InGame_StartMatch
{
    [HarmonyPrefix]
    internal static bool Prefix(InGame __instance)
    {
        var result = true;
        ModHelper.PerformAdvancedModHook(mod => result &=  mod.PreMatchStart(__instance));
        return result;
    }
    
    [HarmonyPostfix]
    internal static void Postfix(InGame __instance)
    {
        ModHelper.PerformHook(mod => mod.OnMatchStart());
    }
}