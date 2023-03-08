using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.ServerEvents;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(DailyChallengeModel), nameof(DailyChallengeModel.Clone))]
internal static class DailyChallengeModel_Clone
{
    [HarmonyPostfix]
    private static void Postfix(DailyChallengeModel __result)
    {
        if (__result?.towers == null) return;
        
        foreach (var modTower in ModContent.GetContent<ModTower>().Where(x => x.AlwaysIncludeInChallenge))
        {
            var towerId = modTower.Id;

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
                var chooseHero =
                    __result.towers.FirstOrDefault(data => data.isHero && data.tower == "ChosenPrimaryHero");
                if (chooseHero?.max != 1)
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