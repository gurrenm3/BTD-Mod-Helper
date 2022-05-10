using Assets.Scripts.Simulation.Bloons;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
    internal class Blooon_Leaked
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            bool result = true;
            SessionData.Instance.LeakedBloons.Add(__instance);
            MelonMain.PerformHook(mod => result &= mod.PreBloonLeaked(__instance));
            return result;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.PerformHook(mod => mod.PostBloonLeaked(__instance));
        }
    }
}