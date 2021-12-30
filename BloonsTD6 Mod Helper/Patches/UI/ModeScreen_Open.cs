using Assets.Scripts.Models.Difficulty;
using Assets.Scripts.Unity.UI_New.Main.ModeSelect;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Patches.UI
{
    [HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.Open))]
    internal static class ModeScreen_Open
    {
        [HarmonyPrefix]
        private static bool Prefix(ModeScreen __instance)
        {
            foreach (var modGameMode in ModContent.GetContent<ModGameMode>())
            {
                GameObject modes;

                if (modGameMode.Difficulty == DifficultyType.Easy)
                {
                    modes = __instance.easyModes;
                }
                else if (modGameMode.Difficulty == DifficultyType.Medium)
                {
                    modes = __instance.mediumModes;
                }
                else if (modGameMode.Difficulty == DifficultyType.Hard)
                {
                    modes = __instance.hardModes;
                }
                else continue;

                var proto = modes.GetComponentInChildrenByName<Transform>("Standard").gameObject;

                var newButt = Object.Instantiate(proto, modes.transform);

                newButt.name = modGameMode.Id;
                newButt.transform.TranslateScaled(new Vector3(0f, -1000f, 0f));
                newButt.GetComponent<Image>().LoadSprite(modGameMode.IconReference);
                newButt.gameObject.GetComponentInChildrenByName<NK_TextMeshProUGUI>("Mode").localizeKey =
                    "Mode " + modGameMode.Id;
                
                var modeButton = newButt.GetComponent<ModeButton>();
                modeButton.modeType = modGameMode.Id;
                modeButton.medal.active = false;

                var matchScale = newButt.AddComponent<MatchScale>();
                matchScale.transformToCopy = proto.transform;
            }

            var modeSelectCanvas = __instance.transform.parent.gameObject;
            var scrollRect = modeSelectCanvas.AddComponent<ScrollRect>();
            scrollRect.horizontal = false;
            scrollRect.scrollSensitivity = 100;
            scrollRect.viewport = modeSelectCanvas.GetComponent<RectTransform>();
            scrollRect.content = __instance.GetComponent<RectTransform>();

            var increaseSize = 500f;
            
            scrollRect.content.sizeDelta = new Vector2(0, increaseSize);
            scrollRect.normalizedPosition = new Vector2(0, 1);
            var up = new Vector3(0f, increaseSize / 2, 0f);
            __instance.easyModes.TranslateScaled(up);
            __instance.mediumModes.TranslateScaled(up);
            __instance.hardModes.TranslateScaled(up);

            return true;
        }
    }
}