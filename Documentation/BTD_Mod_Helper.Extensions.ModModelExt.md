#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ModModelExt Class

Extensions for the ModModel (GameMode) class

```csharp
public static class ModModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ModModelExt.AddMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel)'></a>

## ModModelExt.AddMutator(this ModModel, MutatorModModel) Method

(Cross-Game compatible) Add a Mutator to this ModModel

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

(Cross-Game compatible) Return the first Mutator of type T, or null if there isn't one

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

(Cross-Game compatible) Return the index'th Mutator of type T, or null

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

(Cross-Game compatible) Return the first Mutator of type T whose name contains the given string, or null

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

(Cross-Game compatible) Return all Mutators of type T

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

(Cross-Game compatible) Check if this has a specific Mutator

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

(Cross-Game compatible) Check if this has a specific Mutator and return it

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

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutator(thisAssets.Scripts.Models.Towers.Mods.ModModel,Assets.Scripts.Models.Towers.Mods.MutatorModModel)'></a>

## ModModelExt.RemoveMutator(this ModModel, MutatorModModel) Method

(Cross-Game compatible) Removes a specific mutator from a tower

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

(Cross-Game compatible) Remove the first Mutator of Type T

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

(Cross-Game compatible) Remove the index'th Mutator of Type T

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

(Cross-Game compatible) Remove the first Mutator of Type T whose name contains a certain string

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

<a name='BTD_Mod_Helper.Extensions.ModModelExt.RemoveMutators_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.RemoveMutators<T>(this ModModel) Method

(Cross-Game compatible) Remove all Mutators of type T

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

<a name='BTD_Mod_Helper.Extensions.ModModelExt.UseRoundSet_T_(thisAssets.Scripts.Models.Towers.Mods.ModModel)'></a>

## ModModelExt.UseRoundSet<T>(this ModModel) Method

(Cross-Game compatible) Makes this GameMode use the given RoundSet

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