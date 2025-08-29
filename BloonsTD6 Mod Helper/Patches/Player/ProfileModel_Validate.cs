using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.Legends;
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
        foreach (var modTowerId in ModContent.GetContent<ModTower>()
                     .Where(modTower => modTower is not ModHero &&
                                        !__instance.unlockedTowers.Contains(modTower.Id) &&
                                        modTower.ShouldUnlockTower(__instance))
                     .Select(modTower => modTower.Id))
        {
            __instance.unlockedTowers.Add(modTowerId);
            __instance.acquiredUpgrades.Add(modTowerId);
        }

        foreach (var modUpgradeId in ModContent.GetContent<ModUpgrade>()
                     .Where(modUpgrade => modUpgrade.ShouldAcquireUpgrade(__instance))
                     .Select(upgrade => upgrade.Id)
                )
        {
            if (!__instance.acquiredUpgrades.Contains(modUpgradeId))
            {
                __instance.acquiredUpgrades.Add(modUpgradeId);
            }
        }

        foreach (var modHeroId in ModContent.GetContent<ModHero>()
                     .Where(hero => hero.ShouldUnlockTower(__instance))
                     .Select(modHero => modHero.Id))
        {
            __instance.unlockedHeroes.Add(modHeroId);
            __instance.seenUnlockedHeroes.Add(modHeroId);
            __instance.seenNewHeroNotification.Add(modHeroId);

        }

        if (__instance.legendsData is {unlockedStarterArtifacts: not null})
        {
            foreach (var modArtifact in ModContent.GetContent<ModArtifact>().Where(artifact => artifact.ShouldUnlock))
            {
                foreach (var (_, index) in modArtifact.Tiers)
                {
                    __instance.legendsData.unlockedStarterArtifacts.Add(modArtifact.GetId(index));
                }
            }
        }

        ModHelper.PerformHook(mod => mod.OnProfileLoaded(__instance));
    }
}