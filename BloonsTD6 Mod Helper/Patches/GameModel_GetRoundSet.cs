using Assets.Scripts.Models;
using Assets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(GameModel), nameof(GameModel.GetRoundSet))]
    internal class GameModel_GetRoundSet
    {
        [HarmonyPostfix]
        internal static void Postfix(ref RoundSetModel __result)
        {
            if (SessionData.Instance.RoundSet != null)
                __result = SessionData.Instance.RoundSet;
        }
    }
}