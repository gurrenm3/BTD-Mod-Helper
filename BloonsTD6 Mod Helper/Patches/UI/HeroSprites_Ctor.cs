using Il2CppAssets.Scripts.Data.Global;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches.UI;

/*[HarmonyPatch(typeof(HeroSprites), MethodType.Constructor)]
internal static class HeroSprites_Ctor
{
    [HarmonyPostfix]
    private static void Postfix(HeroSprites __instance)
    {
        MelonLogger.Msg("A constructor patch");
    }
}*/