using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors.Attack;
namespace BTD_Mod_Helper.Patches.Weapons;

[HarmonyPatch(typeof(Attack), nameof(Attack.UpdatedModel))]
internal class Attack_UpdatedModel
{
    [HarmonyPostfix]
    internal static void Postfix(Attack __instance, Model modelToUse)
    {
        ModHelper.PerformHook(mod => mod.OnAttackModelChanged(__instance, modelToUse));
    }
}