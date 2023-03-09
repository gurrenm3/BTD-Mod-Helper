#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModModelExt Class

Extensions for the ModModel (GameMode) class

```csharp
public static class ModModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisModModel,MutatorModModel)'></a>

## ModModelExt.AddMutator(this ModModel, MutatorModModel) Method

Add a Mutator to this ModModel

```csharp
public static void AddMutator(this ModModel model, MutatorModModel mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisModModel,MutatorModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisModModel,MutatorModModel).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,int)'></a>

## ModModelExt.GetMutator<T>(this ModModel, int) Method

Return the index'th Mutator of type T, or null

```csharp
public static T GetMutator<T>(this ModModel model, int index)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,int).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,int).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this ModModel, int).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,string)'></a>

## ModModelExt.GetMutator<T>(this ModModel, string) Method

Return the first Mutator of type T whose name contains the given string, or null

```csharp
public static T GetMutator<T>(this ModModel model, string nameContains)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,string).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel,string).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this ModModel, string).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel)'></a>

## ModModelExt.GetMutator<T>(this ModModel) Method

Return the first Mutator of type T, or null if there isn't one

```csharp
public static T GetMutator<T>(this ModModel model)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisModModel).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this ModModel).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisModModel)'></a>

## ModModelExt.GetMutators<T>(this ModModel) Method

Return all Mutators of type T

```csharp
public static System.Collections.Generic.IEnumerable<T> GetMutators<T>(this ModModel model)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisModModel).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisModModel).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutators<T>(this ModModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel,T)'></a>

## ModModelExt.HasMutator<T>(this ModModel, T) Method

Check if this has a specific Mutator and return it

```csharp
public static bool HasMutator<T>(this ModModel model, out T mutator)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel,T).T'></a>

`T`

The Mutator you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel,T).mutator'></a>

`mutator` [T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel,T).T 'BTD_Mod_Helper.Extensions.ModModelExt.HasMutator<T>(this ModModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel)'></a>

## ModModelExt.HasMutator<T>(this ModModel) Method

Check if this has a specific Mutator

```csharp
public static bool HasMutator<T>(this ModModel model)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel).T'></a>

`T`

The Mutator you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisModModel,TowerSet,bool)'></a>

## ModModelExt.LockTowerSet(this ModModel, TowerSet, bool) Method

Prevents a particular TowerSet from being used in this mode

```csharp
public static void LockTowerSet(this ModModel model, TowerSet towerSet, bool locked=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisModModel,TowerSet,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisModModel,TowerSet,bool).towerSet'></a>

`towerSet` [Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

The tower set to lock

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisModModel,TowerSet,bool).locked'></a>

`locked` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to lock or unlock the tower set

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisModModel,MutatorModModel)'></a>

## ModModelExt.RemoveMutator(this ModModel, MutatorModModel) Method

Removes a specific mutator from a tower

```csharp
public static void RemoveMutator(this ModModel model, MutatorModModel mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisModModel,MutatorModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisModModel,MutatorModModel).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,int)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel, int) Method

Remove the index'th Mutator of Type T

```csharp
public static void RemoveMutator<T>(this ModModel model, int index)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,int).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,string)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel, string) Method

Remove the first Mutator of Type T whose name contains a certain string

```csharp
public static void RemoveMutator<T>(this ModModel model, string nameContains)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,string).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel) Method

Remove the first Mutator of Type T

```csharp
public static void RemoveMutator<T>(this ModModel model)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisModModel,System.Func_MutatorModModel,bool_)'></a>

## ModModelExt.RemoveMutators(this ModModel, Func<MutatorModModel,bool>) Method

Removes all mutators that match a given condition

```csharp
public static void RemoveMutators(this ModModel model, System.Func<MutatorModModel,bool> predicate);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisModModel,System.Func_MutatorModModel,bool_).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisModModel,System.Func_MutatorModModel,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.MutatorModModel')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisModModel)'></a>

## ModModelExt.RemoveMutators<T>(this ModModel) Method

Remove all Mutators of type T

```csharp
public static void RemoveMutators<T>(this ModModel model)
    where T : MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisModModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisModModel,float)'></a>

## ModModelExt.SetAllCashMultiplier(this ModModel, float) Method

Applies a multiplier to all cash gains in the mode (but not starting cash)

```csharp
public static void SetAllCashMultiplier(this ModModel model, float mult);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisModModel,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisModModel,float).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisModModel,float,string)'></a>

## ModModelExt.SetBloonHealth(this ModModel, float, string) Method

Modifies the Health that Bloons with a given tag have, like [BTD_Mod_Helper.Api.Enums.BloonTag.Moabs](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Enums.BloonTag.Moabs 'BTD_Mod_Helper.Api.Enums.BloonTag.Moabs') for all Moabs

```csharp
public static void SetBloonHealth(this ModModel model, float mult, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisModModel,float,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisModModel,float,string).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The multiplier to apply to Bloons' health

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisModModel,float,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The Bloon tag to apply to

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisModModel,bool)'></a>

## ModModelExt.SetContinuesEnabled(this ModModel, bool) Method

Sets whether Continues are enabled for a game mode

```csharp
public static void SetContinuesEnabled(this ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisModModel,int)'></a>

## ModModelExt.SetEndingRound(this ModModel, int) Method

Sets the round this mode ends at using a [Il2CppAssets.Scripts.Models.Towers.Mods.EndRoundModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.EndRoundModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.EndRoundModModel')

```csharp
public static void SetEndingRound(this ModModel model, int endingRound);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisModModel,int).endingRound'></a>

`endingRound` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisModModel,bool)'></a>

## ModModelExt.SetImpoppable(this ModModel, bool) Method

Sets the max health and shield amount to 1

```csharp
public static void SetImpoppable(this ModModel model, bool impoppable=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisModModel,bool).impoppable'></a>

`impoppable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisModModel,bool)'></a>

## ModModelExt.SetIncomeEnabled(this ModModel, bool) Method

Sets whether extra income is enabled for a game mode

```csharp
public static void SetIncomeEnabled(this ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisModModel,int)'></a>

## ModModelExt.SetMaxHealth(this ModModel, int) Method

Sets the maximum life total this mode starts you with using a [Il2CppAssets.Scripts.Models.Towers.Mods.MaxHealthModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.MaxHealthModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.MaxHealthModModel')

```csharp
public static void SetMaxHealth(this ModModel model, int health);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisModModel,int).health'></a>

`health` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisModModel,bool)'></a>

## ModModelExt.SetMkEnabled(this ModModel, bool) Method

Sets whether Monkey Knowledge is enabled for a gamemode

```csharp
public static void SetMkEnabled(this ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisModModel,bool)'></a>

## ModModelExt.SetPowersEnabled(this ModModel, bool) Method

Sets whether Powers are enabled for a game mode

```csharp
public static void SetPowersEnabled(this ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisModModel,bool)'></a>

## ModModelExt.SetReversed(this ModModel, bool) Method

Sets whether the Bloons go in reverse

```csharp
public static void SetReversed(this ModModel model, bool reversed=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisModModel,bool).reversed'></a>

`reversed` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisModModel,bool)'></a>

## ModModelExt.SetSellingEnabled(this ModModel, bool) Method

Sets whether selling towers is enabled for a game mode

```csharp
public static void SetSellingEnabled(this ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisModModel,bool).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisModModel,float)'></a>

## ModModelExt.SetSellMultiplier(this ModModel, float) Method

Sets the portion of cash that should be gotten back when selling (0.7 by default)

```csharp
public static void SetSellMultiplier(this ModModel model, float mult);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisModModel,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisModModel,float).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisModModel,int,int,float)'></a>

## ModModelExt.SetStartingCash(this ModModel, int, int, float) Method

Sets the cash this mode starts you with using a [Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel')

```csharp
public static void SetStartingCash(this ModModel model, int baseCash=0, int addCash=0, float multCash=0f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisModModel,int,int,float).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisModModel,int,int,float).baseCash'></a>

`baseCash` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

If not 0, the new base cash amount to set the starting amount to

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisModModel,int,int,float).addCash'></a>

`addCash` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How much cash to add to the default base cash

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisModModel,int,int,float).multCash'></a>

`multCash` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If not 0, an overall multiplier to the amount of starting cash

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisModModel,int)'></a>

## ModModelExt.SetStartingHealth(this ModModel, int) Method

Sets the life total this mode starts you with using a [Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.StartingCashModModel')

```csharp
public static void SetStartingHealth(this ModModel model, int health);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisModModel,int).health'></a>

`health` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisModModel,int)'></a>

## ModModelExt.SetStartingRound(this ModModel, int) Method

Sets the round this mode starts at using a [Il2CppAssets.Scripts.Models.Towers.Mods.StartingRoundModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.StartingRoundModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.StartingRoundModModel')

```csharp
public static void SetStartingRound(this ModModel model, int startingRound);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisModModel,int).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisModModel,int).startingRound'></a>

`startingRound` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisModModel,string)'></a>

## ModModelExt.UseRoundSet(this ModModel, string) Method

Makes this GameMode use the given RoundSet

```csharp
public static void UseRoundSet(this ModModel model, string roundSetName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisModModel,string).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisModModel,string).roundSetName'></a>

`roundSetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisModModel)'></a>

## ModModelExt.UseRoundSet<T>(this ModModel) Method

Makes this GameMode use the given RoundSet

```csharp
public static void UseRoundSet<T>(this ModModel model)
    where T : BTD_Mod_Helper.Api.Bloons.ModRoundSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisModModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisModModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Mods.ModModel 'Il2CppAssets.Scripts.Models.Towers.Mods.ModModel')