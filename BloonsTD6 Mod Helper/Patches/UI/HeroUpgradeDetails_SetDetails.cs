using System.Linq;
using Assets.Scripts.Unity.UI_New.HeroInGame;
using Assets.Scripts.Unity.UI_New.Main.HeroSelect;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(HeroUpgradeDetails), nameof(HeroUpgradeDetails.SetDetails))]
    internal class HeroUpgradeDetails_SetDetails
    {
        [HarmonyPrefix]
        internal static void Prefix(HeroUpgradeDetails __instance, string heroIdToUse)
        {
            /*var heroSprites = __instance.heroSprites;
            var newHeroSprites = new Il2CppReferenceArray<HeroFontMaterial>(heroSprites.Length + 1);
            for (var i = 0; i < heroSprites.Count; i++)
            {
                var heroFontMaterial = heroSprites[i];
                if (heroFontMaterial.name != heroIdToUse)
                {
                    newHeroSprites[i] = heroFontMaterial;
                }
                else return;
            }

            var nameMaterial = newHeroSprites[0].heroNameMaterial;
            if (ModTowerHelper.ModTowerCache.TryGetValue(heroIdToUse, out var tower) && tower is ModHero modHero &&
                heroSprites.FirstOrDefault(material => material.name == modHero.NameStyle) is HeroFontMaterial materal)
            {
                nameMaterial = materal.heroNameMaterial;
            }

            newHeroSprites[heroSprites.Length] = new HeroFontMaterial
            {
                name = heroIdToUse,
                heroNameMaterial = nameMaterial
            };

            __instance.heroSprites = newHeroSprites;*/
        }

        [HarmonyPostfix]
        internal static void Postfix(HeroUpgradeDetails __instance, string heroIdToUse)
        {
            if (ModTowerHelper.ModTowerCache.TryGetValue(heroIdToUse, out var tower) && tower is ModHero modHero)
            {
                for (var i = 0; i < __instance.heroUpgrades.Length; i++)
                {
                    __instance.heroUpgrades[i].gameObject.SetActive(i < modHero.MaxLevel);
                }

                // TODO unity explorer ability panels
                /*for (var i = 0; i < __instance.abilityPanels.Length; i++)
                {
                    __instance.abilityPanels[i].gameObject.SetActive(i < modHero.Abilities);
                }*/
            }
        }
    }
}