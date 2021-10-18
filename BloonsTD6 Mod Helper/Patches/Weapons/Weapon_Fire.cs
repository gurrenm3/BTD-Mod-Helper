using System;
using Assets.Scripts.Simulation.Towers.Weapons;
using HarmonyLib;
namespace BTD_Mod_Helper.Patches.Weapons {
    [HarmonyPatch(typeof(Weapon),nameof(Weapon.SpawnDart))]
    public static class SpawnDart_Patch{
        [HarmonyPostfix]
        public static void Postfix(Weapon __instance){
            MelonMain.DoPatchMethods(mod=>mod.OnWeaponFire(__instance));
        }
    }
}
