using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(Bloon), nameof(Bloon.Degrade))]
internal class Bloon_Degrade
{
    [HarmonyPrefix]
    internal static bool Prefix(Bloon __instance)
    {
        var hasKey = SessionData.Instance.PoppedBloons.TryGetValue(__instance.bloonModel.id, out var amountPopped);
        if (!hasKey)
            SessionData.Instance.PoppedBloons.Add(__instance.bloonModel.id, 0);
        SessionData.Instance.PoppedBloons[__instance.bloonModel.id] = amountPopped + 1;
        return true;
    }
    [HarmonyPostfix]
    internal static void Postfix(Bloon __instance)
    {
        try
        {
            if (ModBoss.Cache.TryGetValue(__instance.bloonModel.name, out var value))
                value.OnPop(__instance);
        }
        catch (System.Exception e)
        {
            ModHelper.Error(e);
        }
    }
}