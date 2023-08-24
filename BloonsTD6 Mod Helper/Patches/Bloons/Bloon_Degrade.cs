using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using BTD_Mod_Helper.Api.Data;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Degrade))]
internal class Bloon_Degrade
{
    [HarmonyPrefix]
    internal static void Prefix(Bloon __instance)
    {
        var hasKey = SessionData.Instance.PoppedBloons.TryGetValue(__instance.bloonModel.id, out var amountPopped);
        if (!hasKey)
            SessionData.Instance.PoppedBloons.Add(__instance.bloonModel.id, 0);

        SessionData.Instance.PoppedBloons[__instance.bloonModel.id] = amountPopped + 1;
    }
}