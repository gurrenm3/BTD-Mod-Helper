using Assets.Scripts.Models;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Weapons
{
    [HarmonyPatch(typeof(Attack), nameof(Attack.UpdatedModel))]
    internal class Attack_UpdatedModel
    {
        [HarmonyPostfix]
        internal static void Postfix(Attack __instance, Model modelToUse)
        {
            ModHelper.PerformHook(mod => mod.OnAttackModelChanged(__instance, modelToUse));
        }
    }
}