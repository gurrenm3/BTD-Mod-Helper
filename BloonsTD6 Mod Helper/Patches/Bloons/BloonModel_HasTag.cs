using Il2CppAssets.Scripts.Models.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(BloonModel), nameof(BloonModel.HasTag))]
internal static class BloonModel_HasTag
{
    [HarmonyPrefix]
    private static bool Prefix(string tagToFind, ref bool __result)
    {
        if (tagToFind == "All")
        {
            __result = true;
            return false;
        }

        return true;
    }
}