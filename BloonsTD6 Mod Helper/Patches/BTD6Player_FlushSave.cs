using Assets.Scripts.Unity.Player;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.FlushSave))]
    internal class Btd6Player_FlushSave
    {
        [HarmonyPrefix]
        internal static bool Prefix(Btd6Player __instance, ref bool __state)
        {
            __state = __instance.isPendingSave;
            if (__state)
            {
                ProfileManagement.CleanCurrentProfile(__instance.Data);
            }
            return true;
        }
        
        
        [HarmonyPostfix]
        internal static void Postfix(Btd6Player __instance, ref bool __state)
        {
            if (__state)
            {
               ProfileManagement.UnCleanProfile(__instance.Data);
            }
        }
        
    }



}