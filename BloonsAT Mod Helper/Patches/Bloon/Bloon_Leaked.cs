using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Leaked))]
    internal class Bloon_Leaked
    {
        [HarmonyPrefix]
        internal static bool Prefix(Bloon __instance)
        {
            bool result = true;
            MelonMain.DoPatchMethods(mod => result &= mod.PreBloonLeaked(__instance));
            return result;
        }

        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance)
        {
            MelonMain.DoPatchMethods(mod =>
            {
                mod.PostBloonLeaked(__instance);
            });
        }
    }
}