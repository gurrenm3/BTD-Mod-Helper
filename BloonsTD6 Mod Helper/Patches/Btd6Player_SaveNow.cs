using Assets.Scripts.Unity.Player;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.SaveNow))]
    internal class Btd6Player_SaveNow
    {
        [HarmonyPrefix]
        internal static bool Prefix(Btd6Player __instance)
        {
            ProfileManagement.CleanCurrentProfile(__instance.Data);
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(Btd6Player __instance)
        {
            ProfileManagement.UnCleanProfile(__instance.Data);
        }

    }

}