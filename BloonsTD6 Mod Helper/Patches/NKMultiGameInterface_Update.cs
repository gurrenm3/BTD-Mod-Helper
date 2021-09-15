using HarmonyLib;
using NinjaKiwi.NKMulti;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Update))]
    internal class NKMultiGameInterface_Update
    {
        [HarmonyPostfix]
        internal static void Postfix(ref NKMultiGameInterface __instance)
        {
            SessionData.Instance.NkGI = __instance;
        }
    }
}