using System.Linq;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.GetRoundHint))]
internal static class InGame_GetRoundHint
{
    [HarmonyPrefix]
    private static bool Prefix(ref InGame __instance, ref string __result)
    {        
        var result = true;
        var unrefinstance = __instance;
        var unrefresult = __result;
        
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreGetRoundHint(ref unrefinstance, ref unrefresult));
        
        __instance = unrefinstance;
        __result = unrefresult;
        
        return result;
    }
    
    [HarmonyPostfix]
    private static void Postfix(InGame __instance, ref string __result)
    {
        if (ModContent.GetContent<ModRoundSet>()
                .FirstOrDefault(set => set.Id == __instance.GetGameModel().bloonSet)
            is {CustomHints: true} modRoundSet)
        {
            __result = modRoundSet.HintKey(__instance.bridge.GetCurrentRound());
        }
        var unrefresult = __result;

        ModHelper.PerformAdvancedModHook(mod => mod.PostGetRoundHint(__instance, ref unrefresult));
        
        __result = unrefresult;
        
    }
}