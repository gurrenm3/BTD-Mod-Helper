using System.Linq;
using Assets.Scripts.Unity.UI_New.InGame;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.GetRoundHint))]
    internal static class InGame_GetRoundHint
    {
        [HarmonyPostfix]
        private static void Postfix(InGame __instance, ref string __result)
        {
            if (ModContent.GetContent<ModRoundSet>()
                    .FirstOrDefault(set => set.Id == __instance.GetGameModel().bloonSet)
                is ModRoundSet modRoundSet && modRoundSet.CustomHints)
            {
                __result = modRoundSet.HintKey(__instance.bridge.GetCurrentRound());
            }
        }
    }
}