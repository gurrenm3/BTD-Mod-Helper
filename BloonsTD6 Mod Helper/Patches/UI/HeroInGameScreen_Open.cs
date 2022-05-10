using Assets.Scripts.Unity.UI_New.HeroInGame;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(HeroInGameScreen), nameof(HeroInGameScreen.Open))]
internal class HeroInGameScreen_Open
{
    [HarmonyPostfix]
    internal static void Postfix(HeroInGameScreen __instance)
    {
        if (ModTowerHelper.ModTowerCache.TryGetValue(__instance.heroId, out var tower) && tower is ModHero modHero)
        {
            for (var i = 0; i < __instance.heroUpgrades.Length; i++)
            {
                __instance.heroUpgrades[i].gameObject.SetActive(i < modHero.MaxLevel);
            }

            for (var i = 0; i < __instance.abilityPanels.Length; i++)
            {
                __instance.abilityPanels[i].gameObject.SetActive(i < modHero.Abilities);
            }
        }
    }
}