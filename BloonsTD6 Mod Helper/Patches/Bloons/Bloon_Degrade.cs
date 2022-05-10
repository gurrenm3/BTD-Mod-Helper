using Assets.Scripts.Simulation.Bloons;
using BTD_Mod_Helper.Api;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Degrade))]
    internal class Bloon_Degrade
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            bool hasKey = SessionData.PoppedBloons.TryGetValue(__instance.bloonModel.id, out int amountPopped);
            if (!hasKey)
                SessionData.PoppedBloons.Add(__instance.bloonModel.id, 0);

            SessionData.PoppedBloons[__instance.bloonModel.id] = amountPopped + 1;
            return true;
        }
    }
}