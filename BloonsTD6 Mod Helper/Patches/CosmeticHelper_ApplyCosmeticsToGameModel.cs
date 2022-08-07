namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(CosmeticHelper), nameof(CosmeticHelper.ApplyTowerSkinToTowerModel))]
internal static class CosmeticHelper_ApplyCosmeticsToGameModel
{
    [HarmonyPrefix]
    private static bool Prefix()
    {
        return true;
    }

    [HarmonyPostfix]
    private static void Postfix()
    {
    }
}