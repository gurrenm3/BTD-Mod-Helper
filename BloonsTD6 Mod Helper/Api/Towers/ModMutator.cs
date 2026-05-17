using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// ModContent that implements a custom version of a <see cref="BehaviorMutator"/>
/// </summary>
public abstract class ModMutator : ModContent
{
    internal static readonly Dictionary<string, ModMutator> Cache = [];

    /// <summary>
    /// ID to use for the mutator. Defaults to <see cref="ModContent.Id"/>, of course
    /// </summary>
    public virtual string MutatorId => Id;

    /// <summary>
    /// Whether only one of this mutator can be applied to an entity at once
    /// </summary>
    public virtual bool IsUnique => true;

    /// <summary>
    /// Whether this is immune to effects like Lych absorb
    /// </summary>
    public virtual bool CantBeAbsorbed => false;

    /// <summary>
    /// Mutator Priority to use. Higher values make the Mutator happen earlier in the process in relation to other mutators.
    /// For reference, the Paths++ internal mutator is ~100 to be before pretty much all others
    /// </summary>
    public virtual int Priority => 0;

    /// <summary>
    /// Whether to override the visual stack count of this mutator on a tower
    /// </summary>
    public virtual bool OverrideStackCount => false;

    /// <summary>
    /// Whether this mutator should be manually saved
    /// </summary>
    public virtual bool Saved => false;

    /// <summary>
    /// Buff Icon to use for this mutator, if any
    /// </summary>
    public virtual BuffIndicatorModel BuffIcon => null;

    /// <summary>
    /// To what amount to override the visual stack count of this mutator on a tower
    /// Requires <see cref="OverrideStackCount"/> to be true
    /// </summary>
    public virtual int StackCount(JToken data) => 1;

    /// <inheritdoc />
    public override void Register()
    {
        Cache[MutatorId] = this;
    }

    /// <summary>
    /// Applies this mutator to a model
    /// </summary>
    /// <param name="baseModel">Version of the model with no mutators applied</param>
    /// <param name="model">Current model, the one that should be mutated</param>
    /// <param name="data">any custom data for the mutator in the form of JSON</param>
    /// <returns>whether any changes were actually made</returns>
    public abstract bool Mutate(Model baseModel, Model model, JToken data);

    /// <summary>
    /// Creates a BehaviorMutator for use with the specified custom data
    /// </summary>
    /// <param name="data">custom data</param>
    /// <returns>BehaviorMutator</returns>
    public BehaviorMutator Create(JToken data = null) =>
        new AddTagToBloonModel.Mutator(data?.ToString(Formatting.None), MutatorId, IsUnique, "")
        {
            cantBeAbsorbed = CantBeAbsorbed,
            priority = Priority,
            buffIndicator = BuffIcon
        };

    /// <summary>
    /// Gets the stored custom data for the behavior mutator
    /// </summary>
    /// <param name="mutator">BehaviorMutator</param>
    /// <returns>json token of custom data</returns>
    public virtual JToken GetData(BehaviorMutator mutator) =>
        JToken.Parse(mutator.Cast<AddTagToBloonModel.Mutator>().bloonTag ?? "null");

    /// <summary>
    /// Saves this mutator to a MutatorSaveDataModel
    /// </summary>
    /// <param name="mutable">mutated entity</param>
    /// <param name="timedMutator">current mutator</param>
    /// <returns>mutator save data</returns>
    public virtual MutatorSaveDataModel SaveMutator(Mutable mutable, TimedMutator timedMutator)
    {
        var saveData = new JObject
        {
            ["data"] = GetData(timedMutator.mutator),
        };

        if (timedMutator.onlyTimeoutWhenActive) saveData["onlyTimeoutWhenActive"] = true;
        if (!timedMutator.useRoundTime) saveData["useRoundTime"] = false;
        if (timedMutator.includeSubTowers) saveData["includeSubTowers"] = true;
        if (timedMutator.isParagonMutator) saveData["isParagonMutator"] = true;
        if (timedMutator.cantBeAbsorbed) saveData["cantBeAbsorbed"] = true;

        return new MutatorSaveDataModel
        {
            towerId = mutable.Id,
            roundsLeft = timedMutator.roundsRemaining,
            framesLeft = timedMutator.removeAt,
            mutatorSaveId = saveData.ToString(Formatting.None)
        };
    }

    /// <summary>
    /// Loads this mutator back onto an entity from its MutatorSaveDataModel
    /// </summary>
    /// <param name="mutable">entity to mutate</param>
    /// <param name="mutatorSaveDataModel">mutator save data</param>
    public virtual void LoadMutator(Mutable mutable, MutatorSaveDataModel mutatorSaveDataModel)
    {
        var saveData = JObject.Parse(mutatorSaveDataModel.mutatorSaveId);

        mutable.AddMutator(Create(saveData["data"]),
            time: mutatorSaveDataModel.framesLeft, roundsRemaining: mutatorSaveDataModel.roundsLeft,
            onlyTimeoutWhenActive: saveData.Value<bool?>("onlyTimeoutWhenActive") ?? false,
            useRoundTime: saveData.Value<bool?>("useRoundTime") ?? true,
            includeSubTowers: saveData.Value<bool?>("includeSubTowers") ?? false,
            isParagonMutator: saveData.Value<bool?>("isParagonMutator") ?? false,
            cantBeAbsorbed: saveData.Value<bool?>("cantBeAbsorbed") ?? false
        );
    }

    /// <summary>
    /// Gets the TimedMutator for this ModMutator on an entity
    /// </summary>
    /// <param name="mutable">mutated entity</param>
    /// <param name="data">custom data</param>
    /// <returns>TimedMutator</returns>
    public TimedMutator Get(Mutable mutable, out JToken data)
    {
        var mutator = mutable.GetMutatorById(MutatorId);
        data = mutator?.mutator.ModMutatorData();
        return mutator;
    }

    /// <summary>
    /// Gets the TimedMutator for this ModMutator on an entity
    /// </summary>
    /// <param name="mutable">mutated entity</param>
    /// <returns>TimedMutator</returns>
    public TimedMutator Get(Mutable mutable) => Get(mutable, out _);
}

/// <summary>
/// ModMutator that uses a strongly typed custom data object
/// </summary>
/// <typeparam name="T">custom data type</typeparam>
public abstract class ModMutator<T> : ModMutator
{
    /// <inheritdoc />
    public sealed override bool Mutate(Model baseModel, Model model, JToken data) =>
        Mutate(baseModel, model, data.ToObject<T>());

    /// <summary>
    /// Applies this mutator to a model
    /// </summary>
    /// <param name="baseModel">Version of the model with no mutators applied</param>
    /// <param name="model">Current model, the one that should be mutated</param>
    /// <param name="data">any custom data for the mutator, in the form of the specified struct type</param>
    /// <returns>whether any changes were actually made</returns>
    public abstract bool Mutate(Model baseModel, Model model, T data);

    /// <inheritdoc cref="ModMutator.Create(JToken)" />
    public BehaviorMutator Create(T data) => Create(JObject.FromObject(data));

    /// <inheritdoc />
    public sealed override int StackCount(JToken data) => StackCount(data.ToObject<T>());

    /// <inheritdoc cref="ModMutator.StackCount" />
    public virtual int StackCount(T data) => 1;

    /// <inheritdoc cref="ModMutator.GetData" />
    public new virtual T GetData(BehaviorMutator mutator) =>
        base.GetData(mutator) is { } data ? data.ToObject<T>() : default;


    /// <summary>
    /// Gets the TimedMutator for this ModMutator on an entity
    /// </summary>
    /// <param name="mutable">mutated entity</param>
    /// <param name="data">custom data</param>
    /// <returns>TimedMutator</returns>
    public TimedMutator Get(Mutable mutable, out T data)
    {
        var mutator = Get(mutable, out JToken jToken);
        data = mutator == null ? default : jToken.ToObject<T>();
        return mutator;
    }
}