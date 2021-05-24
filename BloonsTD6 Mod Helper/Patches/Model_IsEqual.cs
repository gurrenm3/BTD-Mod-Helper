using Assets.Scripts.Models;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Model), nameof(Model.IsEqual))]
    internal class Model_IsEqual
    {
        [HarmonyPrefix]
        internal static bool Prefix(Model __instance, Model to, ref bool __result)
        {
            if (to.GetIl2CppType().Name != __instance.GetIl2CppType().Name)
            {
                //TODO: this is an incredibly weird thing to have to do, but we do
                __result = false;
                return false;
            }

            return true;
        }
    }
}