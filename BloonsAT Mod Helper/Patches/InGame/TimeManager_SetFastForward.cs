using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.ToggleFastForward))]
    internal class TimeManager_SetFastForward
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnFastForwardChanged());
        }
    }
}