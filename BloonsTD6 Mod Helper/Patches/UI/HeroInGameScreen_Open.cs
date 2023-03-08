using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.HeroInGame;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(HeroInGameScreen), nameof(HeroInGameScreen.Open))]
internal static class HeroInGameScreen_Open
{
    [HarmonyPostfix]
    private static void Postfix(HeroInGameScreen __instance)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(__instance.heroId, out var tower) && tower is ModHero modHero)
        {
            for (var i = 0; i < __instance.heroUpgrades.Length; i++)
            {
                __instance.heroUpgrades[i].gameObject.SetActive(i < modHero.MaxLevel);
            }
        }
        else
        {
            foreach (var t in __instance.heroUpgrades)
            {
                t.gameObject.SetActive(true);
            }
        }
    }
}