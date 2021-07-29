using Assets.Scripts.Utils;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TimeManager), nameof(TimeManager.SetFastForward))]
    internal class TimeManager_SetFastForward
    {
        [HarmonyPostfix]
        internal static void Postfix(bool value)
        {
            MelonMain.DoPatchMethods(mod => mod.OnFastForwardChanged(value));
        }
    }



}