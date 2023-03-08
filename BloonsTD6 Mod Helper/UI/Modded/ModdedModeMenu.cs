using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Unity.UI_New.Main.ModeSelect;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.Modded;

internal class ModdedModeMenu
{
    private const float SpacingX = 780;
    private const float SpacingY = 690;

    private static Vector3 GetOffset(int num, int total)
    {
        var x = SpacingX * (num % 5);
        var y = -SpacingY * (1 + num / 5);
        if (total > 4)
        {
            x -= SpacingX;
        }

        y -= SpacingY * .52f;

        return new Vector3(x, y, 0);
    }

    private static void AddButtonsForDifficulty(ModeScreen modeScreen, string difficulty,
        List<ModGameMode> gameModes)
    {
        GameObject modes;
        if (difficulty == DifficultyType.Easy)
        {
            modes = modeScreen.easyModes;
        }
        else if (difficulty == DifficultyType.Medium)
        {
            modes = modeScreen.mediumModes;
        }
        else if (difficulty == DifficultyType.Hard)
        {
            modes = modeScreen.hardModes;
        }
        else return;

        var proto = modes.GetComponentInChildrenByName<Transform>("Standard").gameObject;

        for (var i = 0; i < gameModes.Count; i++)
        {
            var modGameMode = gameModes[i];

            var newButton = Object.Instantiate(proto, modes.transform);

            newButton.name = modGameMode.Id;
            newButton.transform.TranslateScaled(GetOffset(i, gameModes.Count));
            newButton.GetComponent<Image>().LoadSprite(modGameMode.IconReference);
            newButton.gameObject.GetComponentInChildrenByName<NK_TextMeshProUGUI>("Mode").localizeKey =
                "Mode " + modGameMode.Id;

            var modeButton = newButton.GetComponent<ModeButton>();
            modeButton.modeType = modGameMode.Id;
            modeButton.medal.active = false;

            var matchScale = newButton.AddComponent<MatchScale>();
            matchScale.transformToCopy = proto.transform;
        }
    }

    private static void MakeScrollable(ModeScreen modeScreen, int maxCount)
    {
        if (maxCount == 0)
        {
            return;
        }
        var modeSelectCanvas = modeScreen.transform.parent.gameObject;
        var scrollRect = modeSelectCanvas.AddComponent<ScrollRect>();
        scrollRect.horizontal = false;
        scrollRect.scrollSensitivity = 100;
        scrollRect.viewport = modeSelectCanvas.GetComponent<RectTransform>();
        scrollRect.content = modeScreen.GetComponent<RectTransform>();

        var neededYSpace = SpacingY * (1 + (1 + maxCount) / 5);
        scrollRect.content.sizeDelta = new Vector2(0, neededYSpace);
        scrollRect.normalizedPosition = new Vector2(0, 1);
        var up = new Vector3(0f, neededYSpace / 2f, 0f);
        modeScreen.easyModes.TranslateScaled(up);
        modeScreen.mediumModes.TranslateScaled(up);
        modeScreen.hardModes.TranslateScaled(up);
    }

    [HarmonyPatch(typeof(ModeScreen), nameof(ModeScreen.Open))]
    internal static class ModeScreen_Open
    {
        [HarmonyPrefix]
        private static void Prefix(ModeScreen __instance)
        {
            var maxCount = 0;
            foreach (var (difficulty, gameModes) in ModContent.GetContent<ModGameMode>()
                         .GroupBy(mode => mode.Difficulty))
            {
                if (gameModes.Count > maxCount)
                {
                    maxCount = gameModes.Count;
                }

                AddButtonsForDifficulty(__instance, difficulty, gameModes);
            }

            MakeScrollable(__instance, maxCount);
        }
    }
}