using System;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.GameOver;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(DefeatScreen), nameof(DefeatScreen.Awake))]
internal class DefeatScreen_Awake
{
    [HarmonyPostfix]
    internal static void Postfix(DefeatScreen __instance)
    {
        __instance.retryLastRoundButton.onClick.AddListener(new Action(() =>
        {
            if (ModBoss.Cache.Count > 0)
            {
                ModBossUI.Init();
            }
        }));
    }
}