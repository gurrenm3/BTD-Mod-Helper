using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Weapon), nameof(Weapon.UpdatedModel))]
internal class Weapon_UpdatedModel
{
    [HarmonyPostfix]
    internal static void Postfix(Weapon __instance, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnWeaponModelChanged(__instance, modelToUse));
    }
}