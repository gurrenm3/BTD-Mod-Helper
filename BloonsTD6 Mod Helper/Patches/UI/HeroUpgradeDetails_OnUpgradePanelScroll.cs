using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.Main.HeroSelect;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(HeroUpgradeDetails), nameof(HeroUpgradeDetails.OnUpgradePanelScroll))]
internal static class HeroUpgradeDetails_OnUpgradePanelScroll
{
    [HarmonyPrefix]
    private static bool Prefix(HeroUpgradeDetails __instance, ref Il2CppReferenceArray<HeroUpgradeButton> __state)
    {
        __state = __instance.heroUpgrades;
        if (ModTowerHelper.ModTowerCache.TryGetValue(__instance.selectedHeroId, out var tower) &&
            tower is ModHero {MaxLevel: < 20} hero)
        {
            __instance.heroUpgrades = __instance.heroUpgrades.Take(hero.MaxLevel).ToIl2CppReferenceArray();
        }

        return true;
    }

    [HarmonyPostfix]
    private static void Postfix(HeroUpgradeDetails __instance, ref Il2CppReferenceArray<HeroUpgradeButton> __state)
    {
        __instance.heroUpgrades = __state;
    }
}