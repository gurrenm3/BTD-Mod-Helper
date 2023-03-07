using Il2CppAssets.Scripts.Unity.UI_New.Main.HeroSelect;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(HeroUpgradeDetails), nameof(HeroUpgradeDetails.BindDetails))]
    internal class HeroUpgradeDetails_BindDetails
    {

        [HarmonyPostfix]
        internal static void Postfix(HeroUpgradeDetails __instance, string heroIdToUse)
        {
            if (ModTowerHelper.ModTowerCache.TryGetValue(heroIdToUse, out var tower) && tower is ModHero modHero)
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
}