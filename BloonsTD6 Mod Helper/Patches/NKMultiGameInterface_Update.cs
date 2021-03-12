using Assets.Scripts.Unity;
using Harmony;
using NinjaKiwi.NKMulti;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Update))]
    internal class NKMultiGameInterface_Update
    {
        [HarmonyPostfix]
        internal static void Postfix(ref NKMultiGameInterface __instance)
        {
            Game.instance.nkGI = __instance;
        }
    }
}