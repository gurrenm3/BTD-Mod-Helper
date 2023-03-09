using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Map), nameof(Map.DestroyRemoveable))]
internal static class Map_DestroyRemoveable
{
    [HarmonyPrefix]
    private static bool Prefix(ref Removeable removeable)
    {
        var result = true;
        var unrefremoveable = removeable;
        ModHelper.PerformAdvancedModHook(mod => result &= mod.PreRemoveableDestroyed(ref unrefremoveable));
        removeable = unrefremoveable;
        return result;
    }
    [HarmonyPostfix]
    private static void Postfix(Removeable removeable)
    {
        ModHelper.PerformAdvancedModHook(mod => mod.PostRemoveableDestroyed(removeable));
    }
}