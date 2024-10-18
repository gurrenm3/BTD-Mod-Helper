using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Player;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.GetCurrentMonkeyTeam))]
internal static class Btd6Player_GetCurrentMonkeyTeam
{
    [HarmonyPrefix]
    internal static void Prefix(ref Il2CppReferenceArray<TowerDetailsModel> __state)
    {
        __state = Game.instance.model.towerSet;

        Game.instance.model.towerSet = __state
            .Where(model => !ModTowerHelper.ModTowerCache.TryGetValue(model.towerId, out var modTower) ||
                            modTower.IncludeInMonkeyTeams)
            .ToArray();
    }

    [HarmonyPostfix]
    internal static void Postfix(ref Il2CppReferenceArray<TowerDetailsModel> __state)
    {
        Game.instance.model.towerSet = __state;
    }
}