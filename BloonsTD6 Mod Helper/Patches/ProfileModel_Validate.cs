using System.Linq;
using Assets.Scripts.Models.Profile;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ProfileModel), nameof(ProfileModel.Validate))]
    internal class ProfileModel_Validate
    {
        [HarmonyPostfix]
        internal static void Postfix(ProfileModel __instance)
        {
            foreach (var modTower in ModContent.GetInstances<ModTower>()
                .Where(modTower => !(modTower is ModHero) && !__instance.unlockedTowers.Contains(modTower.Id)))
            {
                __instance.unlockedTowers.Add(modTower.Id);
            }

            foreach (var modUpgrade in ModContent.GetInstances<ModUpgrade>()
                .Where(modUpgrade => !__instance.acquiredUpgrades.Contains(modUpgrade.Id)))
            {
                __instance.acquiredUpgrades.Add(modUpgrade.Id);
            }

            foreach (var modHero in ModContent.GetInstances<ModHero>())
            {
                __instance.unlockedHeroes.Add(modHero.Id);
                __instance.seenUnlockedHeroes.Add(modHero.Id);
                __instance.seenNewHeroNotification.Add(modHero.Id);
            }
            
            MelonMain.DoPatchMethods(mod => mod.OnProfileLoaded(__instance));
        }
    }
}