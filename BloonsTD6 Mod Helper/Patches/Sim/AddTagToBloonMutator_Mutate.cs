using System;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Objects;

namespace BTD_Mod_Helper.Patches.Sim;

/// <summary>
/// This is the internal mutator being hijacked for <see cref="ModMutator"/>
/// </summary>
[HarmonyPatch(typeof(AddTagToBloonModel.Mutator), nameof(AddTagToBloonModel.Mutator.Mutate))]
internal static class AddTagToBloonMutator_Mutate
{
    [HarmonyPrefix]
    private static bool Prefix(BehaviorMutator __instance, Model baseModel, Model model, ref bool __result)
    {
        if (!ModMutator.Cache.TryGetValue(__instance.id, out var modMutator)) return true;

        try
        {
            __result = modMutator.Mutate(baseModel, model, modMutator.GetData(__instance));
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to apply ModMutator {modMutator.Id} on {model.name}");
            ModHelper.Warning(e);
        }

        return false;
    }
}