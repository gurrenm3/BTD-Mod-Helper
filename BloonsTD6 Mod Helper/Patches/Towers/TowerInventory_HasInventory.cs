using Il2CppAssets.Scripts.Simulation.Input;
namespace BTD_Mod_Helper.Patches.Towers;

[HarmonyPatch(typeof(TowerInventory), nameof(TowerInventory.HasInventory))]
internal static class TowerInventory_HasInventory
{
    internal static bool? overrideValue = null;

    [HarmonyPrefix]
    internal static bool Prefix(TowerInventory __instance, ref bool __result)
    {
        if (overrideValue is {} value)
        {
            __result = value;
            return false;
        }

        return true;
    }
}