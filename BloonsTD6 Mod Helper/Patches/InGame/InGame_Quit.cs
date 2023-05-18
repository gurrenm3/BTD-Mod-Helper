using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.Quit))]
internal class InGame_Quit
{
    [HarmonyPrefix]
    internal static bool Prefix(InGame __instance)
    {
        var result = true;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreMatchEnd(__instance));
        return result;
    }

    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnMatchEnd());

        if (ModBoss.Cache.Count > 0)
            ModBoss.ResetUIs();
    }
}