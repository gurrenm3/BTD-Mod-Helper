#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModModelExt Class

Extensions for the ModModel (GameMode) class

```csharp
public static class ModModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel)'></a>

## ModModelExt.AddMutator(this ModModel, MutatorModModel) Method

Add a Mutator to this ModModel

```csharp
public static void AddMutator(this Assets.Scripts.Models.Towers.Mods.ModModel model, Assets.Scripts.Models.Towers.Mods.MutatorModModel mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel).mutator'></a>

`mutator` [Assets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.MutatorModModel 'Assets.Scripts.Models.Towers.Mods.MutatorModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.GetMutator<T>(this ModModel) Method

Return the first Mutator of type T, or null if there isn't one

```csharp
public static T GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.GetMutator<T>(this ModModel, int) Method

Return the index'th Mutator of type T, or null

```csharp
public static T GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model, int index)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel, int).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string)'></a>

## ModModelExt.GetMutator<T>(this ModModel, string) Method

Return the first Mutator of type T whose name contains the given string, or null

```csharp
public static T GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model, string nameContains)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel, string).T')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.GetMutators<T>(this ModModel) Method

Return all Mutators of type T

```csharp
public static System.Collections.Generic.IEnumerable<T> GetMutators<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`

The Mutator you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.GetMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T 'BTD_Mod_Helper.Extensions.ModModelExt.GetMutators<T>(this Assets.Scripts.Models.Towers.Mods.ModModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.HasMutator<T>(this ModModel) Method

Check if this has a specific Mutator

```csharp
public static bool HasMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`

The Mutator you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,T)'></a>

## ModModelExt.HasMutator<T>(this ModModel, T) Method

Check if this has a specific Mutator and return it

```csharp
public static bool HasMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model, out T mutator)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,T).T'></a>

`T`

The Mutator you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,T).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,T).mutator'></a>

`mutator` [T](BTD_Mod_Helper.Extensions.ModModelExt.md#BTD_Mod_Helper.Extensions.ModModelExt.HasMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,T).T 'BTD_Mod_Helper.Extensions.ModModelExt.HasMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string,bool)'></a>

## ModModelExt.LockTowerSet(this ModModel, string, bool) Method

Prevents a particular TowerSet from being used in this mode

```csharp
public static void LockTowerSet(this Assets.Scripts.Models.Towers.Mods.ModModel model, string towerSet, bool locked=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string,bool).towerSet'></a>

`towerSet` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The tower set to lock

<a name='BTD_Mod_Helper.Extensions.ModModelExt.LockTowerSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string,bool).locked'></a>

`locked` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to lock or unlock the tower set

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel)'></a>

## ModModelExt.RemoveMutator(this ModModel, MutatorModModel) Method

Removes a specific mutator from a tower

```csharp
public static void RemoveMutator(this Assets.Scripts.Models.Towers.Mods.ModModel model, Assets.Scripts.Models.Towers.Mods.MutatorModModel mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel).mutator'></a>

`mutator` [Assets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.MutatorModModel 'Assets.Scripts.Models.Towers.Mods.MutatorModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel) Method

Remove the first Mutator of Type T

```csharp
public static void RemoveMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel, int) Method

Remove the index'th Mutator of Type T

```csharp
public static void RemoveMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model, int index)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string)'></a>

## ModModelExt.RemoveMutator<T>(this ModModel, string) Method

Remove the first Mutator of Type T whose name contains a certain string

```csharp
public static void RemoveMutator<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model, string nameContains)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).T'></a>

`T`

The Mutator you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).nameContains'></a>

`nameContains` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisAssets.Scripts.Models.Towers.Mods.ModModel,System.Func_Assets.Scripts.Models.Towers.Mods.MutatorModModel,bool_)'></a>

## ModModelExt.RemoveMutators(this ModModel, Func<MutatorModModel,bool>) Method

Removes all mutators that match a given condition

```csharp
public static void RemoveMutators(this Assets.Scripts.Models.Towers.Mods.ModModel model, System.Func<Assets.Scripts.Models.Towers.Mods.MutatorModModel,bool> predicate);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisAssets.Scripts.Models.Towers.Mods.ModModel,System.Func_Assets.Scripts.Models.Towers.Mods.MutatorModModel,bool_).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators(thisAssets.Scripts.Models.Towers.Mods.ModModel,System.Func_Assets.Scripts.Models.Towers.Mods.MutatorModModel,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[Assets.Scripts.Models.Towers.Mods.MutatorModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.MutatorModModel 'Assets.Scripts.Models.Towers.Mods.MutatorModModel')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.RemoveMutators<T>(this ModModel) Method

Remove all Mutators of type T

```csharp
public static void RemoveMutators<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : Assets.Scripts.Models.Towers.Mods.MutatorModModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float)'></a>

## ModModelExt.SetAllCashMultiplier(this ModModel, float) Method

Applies a multiplier to all cash gains in the mode (but not starting cash)

```csharp
public static void SetAllCashMultiplier(this Assets.Scripts.Models.Towers.Mods.ModModel model, float mult);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetAllCashMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,float,string)'></a>

## ModModelExt.SetBloonHealth(this ModModel, float, string) Method

Modifies the Health that Bloons with a given tag have, like [BTD_Mod_Helper.Api.Enums.BloonTag.Moabs](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.Api.Enums.BloonTag.Moabs 'BTD_Mod_Helper.Api.Enums.BloonTag.Moabs') for all Moabs

```csharp
public static void SetBloonHealth(this Assets.Scripts.Models.Towers.Mods.ModModel model, float mult, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,float,string).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,float,string).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The multiplier to apply to Bloons' health

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetBloonHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,float,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The Bloon tag to apply to

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetContinuesEnabled(this ModModel, bool) Method

Sets whether Continues are enabled for a game mode

```csharp
public static void SetContinuesEnabled(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetContinuesEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.SetEndingRound(this ModModel, int) Method

Sets the round this mode ends at using a [Assets.Scripts.Models.Towers.Mods.EndRoundModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.EndRoundModModel 'Assets.Scripts.Models.Towers.Mods.EndRoundModModel')

```csharp
public static void SetEndingRound(this Assets.Scripts.Models.Towers.Mods.ModModel model, int endingRound);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetEndingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).endingRound'></a>

`endingRound` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetImpoppable(this ModModel, bool) Method

Sets the max health and shield amount to 1

```csharp
public static void SetImpoppable(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool impoppable=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetImpoppable(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).impoppable'></a>

`impoppable` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetIncomeEnabled(this ModModel, bool) Method

Sets whether extra income is enabled for a game mode

```csharp
public static void SetIncomeEnabled(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetIncomeEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.SetMaxHealth(this ModModel, int) Method

Sets the maximum life total this mode starts you with using a [Assets.Scripts.Models.Towers.Mods.MaxHealthModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.MaxHealthModModel 'Assets.Scripts.Models.Towers.Mods.MaxHealthModModel')

```csharp
public static void SetMaxHealth(this Assets.Scripts.Models.Towers.Mods.ModModel model, int health);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMaxHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).health'></a>

`health` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetMkEnabled(this ModModel, bool) Method

Sets whether Monkey Knowledge is enabled for a gamemode

```csharp
public static void SetMkEnabled(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetMkEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetPowersEnabled(this ModModel, bool) Method

Sets whether Powers are enabled for a game mode

```csharp
public static void SetPowersEnabled(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetPowersEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetReversed(this ModModel, bool) Method

Sets whether the Bloons go in reverse

```csharp
public static void SetReversed(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool reversed=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetReversed(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).reversed'></a>

`reversed` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool)'></a>

## ModModelExt.SetSellingEnabled(this ModModel, bool) Method

Sets whether selling towers is enabled for a game mode

```csharp
public static void SetSellingEnabled(this Assets.Scripts.Models.Towers.Mods.ModModel model, bool enabled);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellingEnabled(thisAssets.Scripts.Models.Towers.Mods.ModModel,bool).enabled'></a>

`enabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float)'></a>

## ModModelExt.SetSellMultiplier(this ModModel, float) Method

Sets the portion of cash that should be gotten back when selling (0.7 by default)

```csharp
public static void SetSellMultiplier(this Assets.Scripts.Models.Towers.Mods.ModModel model, float mult);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetSellMultiplier(thisAssets.Scripts.Models.Towers.Mods.ModModel,float).mult'></a>

`mult` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisAssets.Scripts.Models.Towers.Mods.ModModel,int,int,float)'></a>

## ModModelExt.SetStartingCash(this ModModel, int, int, float) Method

Sets the cash this mode starts you with using a [Assets.Scripts.Models.Towers.Mods.StartingCashModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.StartingCashModModel 'Assets.Scripts.Models.Towers.Mods.StartingCashModModel')

```csharp
public static void SetStartingCash(this Assets.Scripts.Models.Towers.Mods.ModModel model, int baseCash=0, int addCash=0, float multCash=0f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisAssets.Scripts.Models.Towers.Mods.ModModel,int,int,float).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisAssets.Scripts.Models.Towers.Mods.ModModel,int,int,float).baseCash'></a>

`baseCash` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

If not 0, the new base cash amount to set the starting amount to

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisAssets.Scripts.Models.Towers.Mods.ModModel,int,int,float).addCash'></a>

`addCash` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How much cash to add to the default base cash

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingCash(thisAssets.Scripts.Models.Towers.Mods.ModModel,int,int,float).multCash'></a>

`multCash` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If not 0, an overall multiplier to the amount of starting cash

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.SetStartingHealth(this ModModel, int) Method

Sets the life total this mode starts you with using a [Assets.Scripts.Models.Towers.Mods.StartingCashModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.StartingCashModModel 'Assets.Scripts.Models.Towers.Mods.StartingCashModModel')

```csharp
public static void SetStartingHealth(this Assets.Scripts.Models.Towers.Mods.ModModel model, int health);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingHealth(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).health'></a>

`health` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int)'></a>

## ModModelExt.SetStartingRound(this ModModel, int) Method

Sets the round this mode starts at using a [Assets.Scripts.Models.Towers.Mods.StartingRoundModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.StartingRoundModModel 'Assets.Scripts.Models.Towers.Mods.StartingRoundModModel')

```csharp
public static void SetStartingRound(this Assets.Scripts.Models.Towers.Mods.ModModel model, int startingRound);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.SetStartingRound(thisAssets.Scripts.Models.Towers.Mods.ModModel,int).startingRound'></a>

`startingRound` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string)'></a>

## ModModelExt.UseRoundSet(this ModModel, string) Method

Makes this GameMode use the given RoundSet

```csharp
public static void UseRoundSet(this Assets.Scripts.Models.Towers.Mods.ModModel model, string roundSetName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet(thisAssets.Scripts.Models.Towers.Mods.ModModel,string).roundSetName'></a>

`roundSetName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.UseRoundSet<T>(this ModModel) Method

Makes this GameMode use the given RoundSet

```csharp
public static void UseRoundSet<T>(this Assets.Scripts.Models.Towers.Mods.ModModel model)
    where T : BTD_Mod_Helper.Api.Bloons.ModRoundSet;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Mods.ModModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Mods.ModModel 'Assets.Scripts.Models.Towers.Mods.ModModel')