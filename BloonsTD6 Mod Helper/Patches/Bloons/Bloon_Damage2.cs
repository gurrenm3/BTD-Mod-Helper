using System;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using BTD_Mod_Helper.Api;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Patches.Bloons
{
    [HarmonyPatch(typeof(Bloon), nameof(Bloon.Damage), typeof(float), typeof(bool))]
    internal class Bloon_Damage3
    {
        [HarmonyPostfix]
        internal static void Postfix(Bloon __instance, float amount, bool ignoreNonTargetable = false)
        {
            
            //MelonMain.DoPatchMethods(mod => mod.PostBloonDamaged(__instance, amount, ignoreNonTargetable));
        }
    }
}