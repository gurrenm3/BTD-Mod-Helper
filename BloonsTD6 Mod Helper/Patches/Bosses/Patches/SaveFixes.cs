using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(InGame), nameof(InGame.CreateMapSave))]
internal static class SaveFixes
{
    internal static bool patch = false;
    [HarmonyPrefix]
    private static void Prefix() => patch = true;

    [HarmonyPostfix]
    private static void Postfix() => patch = false;
}

[HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.GetBossBloonTier))]
internal static class UnityToSimulation_GetBossBloonTier
{
    [HarmonyPrefix]
    private static void Prefix(ref Nullable<int> __result)
    {
        if(SaveFixes.patch)
        {
            __result = new Nullable<int>(5);
        }
    }
}
