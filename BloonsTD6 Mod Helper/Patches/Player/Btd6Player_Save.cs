using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Player;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.Save))]
internal class Btd6Player_Save
{
    [HarmonyPrefix]
    internal static bool Prefix(Btd6Player __instance, ref bool __state)
    {
        __state = __instance.IsPendingSave;
        if (__state && __instance.Data?.HasCompletedTutorial == true)
        {
            ProfileManagement.CleanCurrentProfile(__instance.Data);
        }

        return true;
    }


    [HarmonyPostfix]
    internal static void Postfix(Btd6Player __instance, ref bool __state)
    {
        if (__state && __instance.Data?.HasCompletedTutorial == true)
        {
            ProfileManagement.UnCleanProfile(__instance.Data);
        }
    }
}