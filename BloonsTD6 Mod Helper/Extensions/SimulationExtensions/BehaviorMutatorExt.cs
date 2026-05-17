using System.Collections.Generic;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Simulation.Objects;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for BehaviorMutators
/// </summary>
public static class BehaviorMutatorExt
{
    /// <summary>
    /// Gets the ModMutator class for this mutator if it's modded
    /// </summary>
    /// <param name="mutator">this</param>
    /// <returns>ModMutator or null</returns>
    public static ModMutator GetModMutator(this BehaviorMutator mutator) =>
        ModMutator.Cache.GetValueOrDefault(mutator.id);

    /// <summary>
    /// Tries to get the ModMutator class for this mutator if it's modded
    /// </summary>
    /// <param name="mutator">this</param>
    /// <param name="modMutator">output ModMutator</param>
    /// <returns>ModMutator exists</returns>
    public static bool TryGetModMutator(this BehaviorMutator mutator, out ModMutator modMutator) =>
        ModMutator.Cache.TryGetValue(mutator.id, out modMutator);

    /// <summary>
    /// Gets the ModMutator custom data for this mutator
    /// </summary>
    /// <param name="mutator">this</param>
    /// <returns>custom json data for mod mutator, or null</returns>
    public static JToken ModMutatorData(this BehaviorMutator mutator) => mutator.GetModMutator()?.GetData(mutator);

    /// <summary>
    /// Gets the ModMutator class for this mutator if it's modded
    /// </summary>
    /// <param name="mutator">this</param>
    /// <returns>ModMutator or null</returns>
    public static ModMutator GetModMutator(this TimedMutator mutator) =>
        ModMutator.Cache.GetValueOrDefault(mutator.mutator.id);

    /// <summary>
    /// Tries to get the ModMutator class for this mutator if it's modded
    /// </summary>
    /// <param name="mutator">this</param>
    /// <param name="modMutator">output ModMutator</param>
    /// <returns>ModMutator exists</returns>
    public static bool TryGetModMutator(this TimedMutator mutator, out ModMutator modMutator) =>
        ModMutator.Cache.TryGetValue(mutator.mutator.id, out modMutator);

    /// <summary>
    /// Gets the ModMutator custom data for this mutator
    /// </summary>
    /// <param name="mutator">this</param>
    /// <returns>custom json data for mod mutator, or null</returns>
    public static JToken ModMutatorData(this TimedMutator mutator) => mutator.GetModMutator()?.GetData(mutator.mutator);
}