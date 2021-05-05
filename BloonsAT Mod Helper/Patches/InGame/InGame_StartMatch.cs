using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.StartMatch))]
    internal class InGame_StartMatch
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnMatchStart());
        }
    }
}