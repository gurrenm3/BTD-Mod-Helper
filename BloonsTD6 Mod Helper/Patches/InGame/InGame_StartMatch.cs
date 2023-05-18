using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
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

        InGameButtonsHolder.Init();

        if (ModBoss.Cache.Count > 0)
        {
            ModBossUI.Init();
        }
    }
}