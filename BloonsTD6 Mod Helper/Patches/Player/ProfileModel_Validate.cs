using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Profile;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(ProfileModel), nameof(ProfileModel.Validate))]
internal class ProfileModel_Validate
{
    [HarmonyPrefix]
    internal static void Prefix(ProfileModel __instance)
    {
        ProfileManagement.CleanPastProfile(__instance);
    }


    [HarmonyPostfix]
    internal static void Postfix(ProfileModel __instance)
    {
        foreach (var modTowerId in ModContent.GetContent<ModTower>().Where(modTower => modTower is not ModHero && !__instance.unlockedTowers.Contains(modTower.Id)).Select(modTower => modTower.Id))
        {
            __instance.unlockedTowers.Add(modTowerId);
            __instance.acquiredUpgrades.Add(modTowerId);
        }

        foreach (var modUpgrade in ModContent.GetContent<ModUpgrade>()
                     .Where(modUpgrade => !__instance.acquiredUpgrades.Contains(modUpgrade.Id)))
        {
            __instance.acquiredUpgrades.Add(modUpgrade.Id);
        }

        foreach (var modHeroId in ModContent.GetContent<ModHero>().Select(modHero => modHero.Id))
        {
            __instance.unlockedHeroes.Add(modHeroId);
            __instance.seenUnlockedHeroes.Add(modHeroId);
            __instance.seenNewHeroNotification.Add(modHeroId);
        }

        ModHelper.PerformHook(mod => mod.OnProfileLoaded(__instance));
    }
}