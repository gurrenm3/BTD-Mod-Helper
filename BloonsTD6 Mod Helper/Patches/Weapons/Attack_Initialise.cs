using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Weapons
{
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
}