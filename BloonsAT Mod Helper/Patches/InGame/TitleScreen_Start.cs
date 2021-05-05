using Harmony;
using Assets.Scripts.Unity.UI_New.Splash;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TitleScreen), nameof(TitleScreen.Start))]
    internal class TitleScreen_Start
    {
        [HarmonyPostfix]
        internal static void Postfix()
        {
            MelonMain.DoPatchMethods(mod => mod.OnTitleScreen());
        }
    }
}