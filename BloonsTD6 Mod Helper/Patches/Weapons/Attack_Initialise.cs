using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Attack), nameof(Attack.Initialise))]
internal class Attack_Initialise
{
    [HarmonyPostfix]
    internal static void Postfix(Attack __instance, Entity targetLocal, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnAttackCreated(__instance, targetLocal, modelToUse));
        ModHelper.PerformHook(mod => mod.OnAttackModelChanged(__instance, modelToUse));
    }
}