using System.Collections.Generic;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.Races;
using Il2CppInterop.Runtime;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(BossUI), nameof(BossUI.ShowBossAliveUI))]
internal static class BossUI_ShowBossAliveUI
{
    [HarmonyPostfix]
    private static void Postfix(BossUI __instance)
    {
        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            var star = new GameObject("StarPrefab", Il2CppType.Of<RectTransform>(), Il2CppType.Of<Image>()).GetComponent<Image>();
            star.SetSprite(ModContent.GetSpriteReference<MelonMain>("BossStar"));

            var parent = __instance.bossHealthTxt.transform.parent.FindChild("StarsOn");
            __instance.stars.ForEach(x => x.gameObject.Destroy());

            List<Image> stars = new();
            for (int i = 0; i < boss.highestTier; i++)
            {
                var newStar = star.Duplicate(parent);
                var gameObject = newStar.gameObject;
                gameObject.SetActive(true);
                newStar.name = gameObject.name = "Star" + (i + 1);
                newStar.color = __instance.starColorOff;
                stars.Add(newStar);
            }

            star.gameObject.Destroy();

            for (var i = 0; i < boss.CurrentTier.Tier; i++)
            {
                stars[i].color = __instance.starColorOn;
            }

            for (var i = boss.highestTier; i < 5; i++) //matches ingame behavior
            {
                var newStar = star.Duplicate(parent);
                var gameObject = newStar.gameObject;
                gameObject.SetActive(true);
                newStar.name = gameObject.name = "Star" + (i + 1);
                newStar.color = __instance.starColorOff;
                newStar.enabled = false;
                stars.Add(newStar);
            }

            TaskScheduler.ScheduleTask(() =>
            {
                stars.ForEach(starImage =>
                {
                    var transform = starImage.transform;
                    transform.localPosition = transform.localPosition with
                    {
                        y = 9.4806f
                    };
                });
            });

            __instance.stars = stars.ToArray();
        }
    }
}