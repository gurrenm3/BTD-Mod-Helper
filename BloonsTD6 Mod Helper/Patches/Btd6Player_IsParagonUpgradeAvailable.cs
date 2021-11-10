using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using HarmonyLib;
using MelonLoader;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Btd6Player), nameof(Btd6Player.CheckForNewParagonPipEvent))]
    internal class Btd6Player_CheckForNewParagonPipEvent
    {
        [HarmonyPrefix]
        internal static bool Prefix(Btd6Player __instance)
        {
            return true;
        }
    }




}