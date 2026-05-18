**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

A Mutator is BTD6's mechanism for layering changes on top of a `TowerModel` or `BloonModel` at runtime, e.g., Overclock, Alchemist buffs, Village buffs, etc. `ModMutator` lets you define your own.

# [ModMutator](/docs/BTD_Mod_Helper.Api.Towers.ModMutator)

## Required Methods

`Mutate(Model baseModel, Model model, JToken data)`: The actual mutation. `baseModel` is the unmutated base version, `model` is the current one you should actually change, and `data` is any JSON payload you attached when applying the mutator. Return `true` if you actually changed something.

## Common Overrides

`IsUnique`: Whether only one instance of this mutator can be applied to at a time to an entity. Defaults to true.

`CantBeAbsorbed`: Whether the mutator is immune to effects like Lych's absorb. Defaults to false.

`Priority`: Higher priorities run earlier in the BTD6 mutation chain, letting you control ordering against other mutators. Defaults to 0. For reference, the Paths++ internal mutator is ~100 to apply before basically anything else.

`BuffIcon`: A `BuffIndicatorModel` to display the mutator's status visually on the entity. You can provide a [ModBuffIcon](/docs/BTD_Mod_Helper.Api.Display.ModBuffIcon) via `GetInstance<MyBuffIcon>()` and it will implicitly convert to a `BuffIndicatorModel`.

`Saved`: Set to true if the mutator should automatically be persisted across saves. Defaults to false.

`OverrideStackCount` + `StackCount(JToken data)`: For mutators where the "stack count" displayed by the BuffIcon should be derived from the custom data rather than the literal number of applied mutators.

## Applying a Mutator

Use the `AddMutator<T>` extension on a `Mutable` (Tower, Bloon, etc.) to attach a `ModMutator` to it.

```cs
tower.AddMutator<MyMutator>(
    time: 60 * 30,           // duration in frames (60 fps); use -1 (default) for permanent
    roundsRemaining: 1,      // or duration in rounds
    data: someJson           // optional custom data
);
```

There are also `AddMutatorFromParent<T>` and `AddMutatorIncludeSubTowers<T>` for the relevant cases.

## Reading / Removing a Mutator

```cs
if (tower.HasMutatorById<MyMutator>(out var timed)) { ... }
if (tower.IsMutatedBy<MyMutator>()) { ... }
tower.RemoveMutator<MyMutator>();

ModContent.GetInstance<MyMutator>().Get(tower, out JToken data);
```

To go the other direction, from an arbitrary `BehaviorMutator` to its `ModMutator`, use the `GetModMutator()` / `TryGetModMutator()` extensions.

## Example

A mutator used by the Honorary Paragons mod.

```cs
public class HonoraryParagonMutator : ModMutator
{
    public override BuffIndicatorModel BuffIcon => GetInstance<HonoraryParagonIcon>();

    public override int Priority => 50; // Before other stuff, but after Paths++

    public override bool Mutate(Model baseModel, Model model, JToken data)
    {
        HonoraryParagon.Paragonify(model.Cast<TowerModel>());
        return true;
    }
}

public class HonoraryParagonIcon : ModBuffIcon
{
    public override string Icon => VanillaSprites.ParagonPip;
}
```

# [ModMutator&lt;T&gt;](/docs/BTD_Mod_Helper.Api.Towers.ModMutator_T_)

If you want to use statically typed custom data, you can use `ModMutator<T>` isntead of passing raw JSON around. `T` is a struct/record/class that gets serialized to/from JSON for you, and the `Mutate` method receives it strongly typed.

## Example

```cs
public class MyMutator : ModMutator<MyMutator.Data>
{
    public record struct Data(float Cost, int Stacks);

    public override bool CantBeAbsorbed => true;

    public override bool Saved => true;
    
    public override bool OverrideStackCount => true;

    public override int StackCount(Data data) => data.Stacks;

    public override bool Mutate(Model baseModel, Model model, Data data)
    {
        // ... using data.Stacks and data.Cost
    }
}
```

You can then read the data back from any `BehaviorMutator` via `GetData(behaviorMutator)`, or grab both the `TimedMutator` and its data in one call:

```cs
var timed = ModContent.GetInstance<BuffInShopMutator>().Get(tower, out var data);
if (timed != null)
{
    ModHelper.Msg<MyMod>($"Stacks: {data.Stacks}, Cost: {data.Cost}");
}
```

# Tips

- Mutators are *re*-applied whenever the model is rebuilt (e.g. on upgrade), so they work better for custom effects than 
- Look at exported game data "Buffs" folder for examples of vanilla buff indicators
