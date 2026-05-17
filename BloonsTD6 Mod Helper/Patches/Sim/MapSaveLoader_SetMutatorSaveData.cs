using System;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Utils;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(MapSaveLoader), nameof(MapSaveLoader.SetMutatorSaveData))]
internal static class MapSaveLoader_SetMutatorSaveData
{
    [HarmonyPostfix]
    internal static void Postfix(Simulation sim, MapSaveDataModel mapSaveDataModel)
    {
        foreach (var (id, mutators) in mapSaveDataModel.activeMutators)
        {
            if (!ModMutator.Cache.TryGetValue(id, out var modMutator) || !modMutator.Saved) continue;

            foreach (var mutatorSaveDataModel in mutators)
            {
                try
                {
                    modMutator.LoadMutator(sim.factory.GetWithId<Mutable>(mutatorSaveDataModel.towerId), mutatorSaveDataModel);
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to load ModMutator {modMutator.Id}");
                    ModHelper.Warning(e);
                }
            }
        }
    }
}