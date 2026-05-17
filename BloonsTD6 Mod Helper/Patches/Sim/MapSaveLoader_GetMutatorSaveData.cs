using System;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Utils;
using Il2CppSystem.Linq;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(MapSaveLoader), nameof(MapSaveLoader.GetMutatorSaveData))]
internal static class MapSaveLoader_GetMutatorSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(Simulation sim,
        Il2CppSystem.Collections.Generic.Dictionary<string, Il2CppSystem.Collections.Generic.List<MutatorSaveDataModel>>
            __result)
    {
        foreach (var mutable in sim.factory.GetUncast<Mutable>().ToArray())
        {
            foreach (var timedMutator in mutable.mutators.ToArray())
            {
                var mutator = timedMutator.mutator;
                if (!mutator.TryGetModMutator(out var modMutator) || !modMutator.Saved) continue;

                if (!__result.ContainsKey(modMutator.Id))
                {
                    __result[modMutator.Id] = new Il2CppSystem.Collections.Generic.List<MutatorSaveDataModel>();
                }

                try
                {
                    __result[modMutator.Id].Add(modMutator.SaveMutator(mutable, timedMutator));
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to save ModMutator {modMutator.Id}");
                    ModHelper.Warning(e);
                }
            }
        }
    }
}