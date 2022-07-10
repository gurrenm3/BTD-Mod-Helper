using Assets.Scripts.Models;

namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(GameModel), "This patch will fail but the mod will still load")]
internal static class ExampleFailedPatch
{
    [HarmonyPostfix]
    private static void Postfix()
    {
    }
}