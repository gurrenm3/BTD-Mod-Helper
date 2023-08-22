using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame), nameof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.Restart))]
internal class InGame_Restart
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        if (ModBoss.Cache.Count > 0)
        {
            ModBossUI.Init();
        }
        ModHelper.PerformHook(mod => mod.OnRestart());
    }
}