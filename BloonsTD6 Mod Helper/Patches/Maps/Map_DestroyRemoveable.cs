using Il2CppAssets.Scripts.Simulation.Track;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Map), nameof(Map.DestroyRemoveable))]
internal static class Map_DestroyRemoveable
{
    [HarmonyPostfix]
    private static void Postfix(Removeable removeable)
    {
        ModHelper.PerformHook(mod => mod.OnRemoveableDestroyed(removeable));
    }
}