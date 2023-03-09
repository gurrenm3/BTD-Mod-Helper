using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Abilities;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Ability), nameof(Ability.Activate))]
internal class Activate_Patch
{
    [HarmonyPostfix]
    internal static void Postfix(Ability __instance)
    {
        ModHelper.PerformHook(mod => mod.OnAbilityCast(__instance));
    }
}