using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
namespace BTD_Mod_Helper.Patches.Bloons;

[HarmonyPatch(typeof(GameModel), nameof(GameModel.GetBloon))]
internal static class GameModel_GetBloon
{
    [HarmonyPostfix]
    private static void Postfix(string id, ref BloonModel __result)
    { 
        // This is here to catch errors in this method, otherwise it just fails silently which can be confusing
    }
}