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
        foreach (var modTower in ModContent.GetContent<ModTower>()
                     .Where(modTower => !(modTower is ModHero) && !__instance.unlockedTowers.Contains(modTower.Id)))
        {
            __instance.unlockedTowers.Add(modTower.Id);
            __instance.acquiredUpgrades.Add(modTower.Id);
        }

        foreach (var modUpgrade in ModContent.GetContent<ModUpgrade>()
                     .Where(modUpgrade => !__instance.acquiredUpgrades.Contains(modUpgrade.Id)))
        {
            __instance.acquiredUpgrades.Add(modUpgrade.Id);
        }

        foreach (var modHero in ModContent.GetContent<ModHero>())
        {
            __instance.unlockedHeroes.Add(modHero.Id);
            __instance.seenUnlockedHeroes.Add(modHero.Id);
            __instance.seenNewHeroNotification.Add(modHero.Id);
        }
            
        ModHelper.PerformHook(mod => mod.OnProfileLoaded(__instance));
    }
}