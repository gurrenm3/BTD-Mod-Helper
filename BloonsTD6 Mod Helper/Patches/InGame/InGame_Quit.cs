using BTD_Mod_Helper.Api.Bloons;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame), nameof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.Quit))]
internal class InGame_Quit
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        ModHelper.PerformHook(mod => mod.OnMatchEnd());
        if (ModBoss.Cache.Count > 0)
        {
            ModBoss.ClearUI();
        }
    }
}