﻿using Assets.Scripts.Simulation.Towers.Behaviors.Abilities;
using HarmonyLib;
namespace BTD_Mod_Helper.Patches.Weapons {
    [HarmonyPatch(typeof(Ability),nameof(Ability.Activate))]
    internal class Activate_Patch{
        [HarmonyPostfix]
        internal static void Postfix(Ability __instance){
            MelonMain.PerformHook(mod=>mod.OnAbilityCast(__instance));
        }
    }
}
