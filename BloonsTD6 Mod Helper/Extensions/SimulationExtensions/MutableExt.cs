using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Simulation.Objects;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Mutables
/// </summary>
public static class MutableExt
{
    /// <summary>
    /// Calls <see cref="Mutable.AddMutator"/> with a <see cref="ModMutator"/>
    /// </summary>
    public static void AddMutator<T>(this Mutable mutable,
        JToken data = null,
        int time = -1,
        bool updateDuration = true,
        bool applyMutation = true,
        bool onlyTimeoutWhenActive = false,
        bool useRoundTime = true,
        bool cascadeMutators = false,
        bool includeSubTowers = false,
        bool ignoreRecursionCheck = false,
        int roundsRemaining = -1,
        bool isParagonMutator = false,
        bool cantBeAbsorbed = false) where T : ModMutator
    {
        mutable.AddMutator(ModContent.CreateMutator<T>(data), time: time, updateDuration: updateDuration,
            applyMutation: applyMutation, onlyTimeoutWhenActive: onlyTimeoutWhenActive,
            useRoundTime: useRoundTime, cascadeMutators: cascadeMutators, includeSubTowers: includeSubTowers,
            ignoreRecursionCheck: ignoreRecursionCheck, roundsRemaining: roundsRemaining, isParagonMutator: isParagonMutator,
            cantBeAbsorbed: cantBeAbsorbed);
    }

    /// <summary>
    /// Calls <see cref="Mutable.GetMutator"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static BehaviorMutator GetMutator<T>(this Mutable mutable) where T : ModMutator =>
        mutable.GetMutator(ModContent.GetInstance<T>().MutatorId);

    /// <summary>
    /// Calls <see cref="Mutable.GetMutatorById"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static TimedMutator GetMutatorById<T>(this Mutable mutable) where T : ModMutator =>
        mutable.GetMutatorById(ModContent.GetInstance<T>().MutatorId);

    /// <summary>
    /// Calls <see cref="Mutable.IsMutatedBy(string)"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static bool IsMutatedBy<T>(this Mutable mutable) where T : ModMutator =>
        mutable.IsMutatedBy(ModContent.GetInstance<T>().MutatorId);

    /// <summary>
    /// Calls <see cref="Mutable.GetMutator"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static bool HasMutator<T>(this Mutable mutable, out BehaviorMutator behaviorMutator) where T : ModMutator
    {
        behaviorMutator = mutable.GetMutator<T>();
        return behaviorMutator != null;
    }

    /// <summary>
    /// Calls <see cref="Mutable.GetMutatorById"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static bool HasMutatorById<T>(this Mutable mutable, out TimedMutator behaviorMutator) where T : ModMutator
    {
        behaviorMutator = mutable.GetMutatorById<T>();
        return behaviorMutator != null;
    }

    /// <summary>
    /// Calls <see cref="Mutable.RemoveMutatorsById"/> for a <see cref="ModMutator"/>
    /// </summary>
    public static void RemoveMutator<T>(this Mutable mutable) where T : ModMutator
    {
        mutable.RemoveMutatorsById(ModContent.GetInstance<T>().MutatorId);
    }
}