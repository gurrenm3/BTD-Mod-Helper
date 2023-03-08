using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Weapon), nameof(Weapon.Initialise))]
internal class Weapon_Initialise
{
    [HarmonyPostfix]
    internal static void Postfix(Weapon __instance, Entity target, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnWeaponCreated(__instance, target, modelToUse));
        ModHelper.PerformHook(mod => mod.OnWeaponModelChanged(__instance, modelToUse));
    }
}