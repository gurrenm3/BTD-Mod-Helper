using System.Linq;
using Assets.Scripts.Models.Profile;
using BTD_Mod_Helper.Api.Towers;
using Harmony;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ProfileModel), nameof(ProfileModel.Validate))]
    internal class ProfileModel_Validate
    {
        [HarmonyPostfix]
        internal static void Postfix(ProfileModel __instance)
        {
            foreach (var modTower in ModTowerHandler.ModTowers
                .Where(modTower => !__instance.unlockedTowers.Contains(modTower.Id)))
            {
                __instance.unlockedTowers.Add(modTower.Id);
            }
            
            foreach (var modUpgrade in ModTowerHandler.ModUpgrades
                .Where(modUpgrade => !__instance.acquiredUpgrades.Contains(modUpgrade.Id)))
            {
                __instance.acquiredUpgrades.Add(modUpgrade.Id);
            }
            
            MelonMain.DoPatchMethods(mod => mod.OnProfileLoaded(__instance));
        }
    }
}
