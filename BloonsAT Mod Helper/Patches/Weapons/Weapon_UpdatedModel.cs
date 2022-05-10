using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Weapons.Behaviors;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Weapons
{

    [HarmonyPatch(typeof(Weapon), nameof(Weapon.UpdatedModel))]
    internal class Weapon_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Weapon __instance, Model modelToUse)
        {
            MelonMain.DoPatchMethods(mod => mod.OnWeaponModelChanged(__instance, modelToUse));
        }
    }
}