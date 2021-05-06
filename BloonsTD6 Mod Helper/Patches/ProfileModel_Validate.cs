using Assets.Scripts.Models.Profile;
using Harmony;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(ProfileModel), nameof(ProfileModel.Validate))]
    internal class ProfileModel_Validate
    {
        [HarmonyPostfix]
        internal static void Postfix(ProfileModel __instance)
        {
            MelonMain.DoPatchMethods(mod => mod.OnProfileLoaded(__instance));
        }
    }
}
