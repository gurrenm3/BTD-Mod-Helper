using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Weapon), nameof(Weapon.SpawnDart))]
internal static class Weapon_SpawnDart
{
    [HarmonyPostfix]
    public static void Postfix(Weapon __instance)
    {
        ModHelper.PerformHook(mod => mod.OnWeaponFire(__instance));
    }
}