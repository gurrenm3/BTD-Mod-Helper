using Assets.Scripts.Models.ServerEvents;
using BTD_Mod_Helper.Api.Towers;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(DailyChallengeModel), nameof(DailyChallengeModel.Clone))]
internal static class DailyChallengeModel_Clone
{
    [HarmonyPostfix]
    private static void Postfix(DailyChallengeModel __result)
    {
        foreach (var (towerId, modTower) in ModTowerHelper.ModTowerCache)
        {
            if (modTower.AlwaysIncludeInChallenge)
            {
                var towerData = __result.towers.FirstOrDefault(data => data.tower == towerId);
                if (towerData == null)
                {
                    towerData = new TowerData
                    {
                        tower = towerId,
                        isHero = modTower is ModHero
                    };
                    __result.towers.Add(towerData);
                }

                if (modTower is ModHero)
                {
                    var chooseHero = __result.towers.First(data => data.isHero && data.tower == "ChosenPrimaryHero");
                    if (chooseHero.max != 1)
                    {
                        towerData.max = 1;
                    }
                }
                else
                {
                    towerData.max = -1;
                }
            }
        }
    }
}