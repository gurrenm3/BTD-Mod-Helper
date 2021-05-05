using Assets.Scripts.Unity.UI_New.InGame;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(InGame), nameof(InGame.Restart))]
    internal class InGame_Restart
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnRestart());
        }
    }
}