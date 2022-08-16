using Assets.Scripts.Simulation.Towers.Behaviors;

using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(ParagonTower), nameof(ParagonTower.UpdateDegree))]
internal class ParagonTower_UpdateDegree {
    [HarmonyPostfix]
    internal static void Postfix(ParagonTower __instance) {
        if (__instance.tower?.towerModel?.GetModTower() is ModTower modTower && modTower.ShouldCreateParagon) {
            modTower.paragonUpgrade?.OnDegreeSet(__instance.tower, __instance.GetCurrentDegree());
        }
    }
}