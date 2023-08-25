using System.Collections.Generic;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Bloons.Bosses.Patches;

[HarmonyPatch(typeof(BossUI), nameof(BossUI.ShowBossAliveUI))]
internal static class BossUI_ShowBossAliveUI
{
    [HarmonyPostfix]
    private static void Postfix(BossUI __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            var star = __instance.stars[0].Duplicate();
            var parent = __instance.stars[0].transform.parent;
            __instance.stars.ForEach(x => x.gameObject.Destroy());

            List<Image> stars = new();
            for (int i = 0; i < boss.highestTier; i++)
            {
                var newStar = star.Duplicate(parent);
                var gameObject = newStar.gameObject;
                gameObject.SetActive(true);
                newStar.name = gameObject.name = "Star" + i;
                newStar.color = __instance.starColorOff;
                stars.Add(newStar);
            }

            star.gameObject.Destroy();

            for (var i = 0; i < boss.CurrentTier.Tier; i++)
            {
                stars[i].color = __instance.starColorOn;
            }

            __instance.stars = stars.ToArray();
        }
    }
}