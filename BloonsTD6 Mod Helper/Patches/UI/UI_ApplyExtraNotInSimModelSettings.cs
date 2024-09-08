using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Track.RoundManagers;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.UI), nameof(Il2CppAssets.Scripts.Unity.UI_New.UI.ApplyExtraNotInSimModelSettings))]
internal static class UI_ApplyExtraNotInSimModelSettings
{
    [HarmonyPostfix]
    internal static void Postfix(UnityToSimulation uts, GameModel model)
    {
        if (!string.IsNullOrEmpty(RoundSetChanger.RoundSetOverride) && model.isApopalypse)
        {
            var roundManager = new DefaultRoundManager(model);
            uts.InitRoundSet(roundManager);
        }
    }
}