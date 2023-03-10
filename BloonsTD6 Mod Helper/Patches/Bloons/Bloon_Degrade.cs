using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Degrade))]
internal class Bloon_Degrade
{
    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance)
    {
        bool hasKey = SessionData.Instance.PoppedBloons.TryGetValue(__instance.bloonModel.id, out int amountPopped);
        if (!hasKey)
            SessionData.Instance.PoppedBloons.Add(__instance.bloonModel.id, 0);
        SessionData.Instance.PoppedBloons[__instance.bloonModel.id] = amountPopped + 1;
        return true;
    }
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance)
    {
        if (ModBoss.Cache.ContainsKey(__instance.bloonModel.id))
            ModBoss.Cache[__instance.bloonModel.id].OnPop(__instance);
    }
}