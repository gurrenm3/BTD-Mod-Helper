#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModMutator<T> Class

ModMutator that uses a strongly typed custom data object

```csharp
public abstract class ModMutator<T> : BTD_Mod_Helper.Api.Towers.ModMutator
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.T'></a>

`T`

custom data type

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator') &#129106; ModMutator<T>
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Create(T)'></a>

## ModMutator<T>.Create(T) Method

Creates a BehaviorMutator for use with the specified custom data

```csharp
public BehaviorMutator Create(T data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Create(T).data'></a>

`data` [T](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md#BTD_Mod_Helper.Api.Towers.ModMutator_T_.T 'BTD_Mod_Helper.Api.Towers.ModMutator<T>.T')

custom data

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')  
BehaviorMutator

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Get(Mutable,T)'></a>

## ModMutator<T>.Get(Mutable, T) Method

Gets the TimedMutator for this ModMutator on an entity

```csharp
public TimedMutator Get(Mutable mutable, out T data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Get(Mutable,T).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

mutated entity

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Get(Mutable,T).data'></a>

`data` [T](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md#BTD_Mod_Helper.Api.Towers.ModMutator_T_.T 'BTD_Mod_Helper.Api.Towers.ModMutator<T>.T')

custom data

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')  
TimedMutator

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.GetData(BehaviorMutator)'></a>

## ModMutator<T>.GetData(BehaviorMutator) Method

Gets the stored custom data for the behavior mutator

```csharp
public virtual T GetData(BehaviorMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.GetData(BehaviorMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

BehaviorMutator

#### Returns
[T](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md#BTD_Mod_Helper.Api.Towers.ModMutator_T_.T 'BTD_Mod_Helper.Api.Towers.ModMutator<T>.T')  
json token of custom data

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,JToken)'></a>

## ModMutator<T>.Mutate(Model, Model, JToken) Method

Applies this mutator to a model

```csharp
public sealed override bool Mutate(Model baseModel, Model model, JToken data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,JToken).baseModel'></a>

`baseModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Version of the model with no mutators applied

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,JToken).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Current model, the one that should be mutated

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

any custom data for the mutator in the form of JSON

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether any changes were actually made

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,T)'></a>

## ModMutator<T>.Mutate(Model, Model, T) Method

Applies this mutator to a model

```csharp
public abstract bool Mutate(Model baseModel, Model model, T data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,T).baseModel'></a>

`baseModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Version of the model with no mutators applied

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Current model, the one that should be mutated

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.Mutate(Model,Model,T).data'></a>

`data` [T](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md#BTD_Mod_Helper.Api.Towers.ModMutator_T_.T 'BTD_Mod_Helper.Api.Towers.ModMutator<T>.T')

any custom data for the mutator, in the form of the specified struct type

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether any changes were actually made

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.StackCount(JToken)'></a>

## ModMutator<T>.StackCount(JToken) Method

To what amount to override the visual stack count of this mutator on a tower  
Requires [OverrideStackCount](BTD_Mod_Helper.Api.Towers.ModMutator.md#BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount 'BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount') to be true

```csharp
public sealed override int StackCount(JToken data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.StackCount(JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.StackCount(T)'></a>

## ModMutator<T>.StackCount(T) Method

To what amount to override the visual stack count of this mutator on a tower  
Requires [OverrideStackCount](BTD_Mod_Helper.Api.Towers.ModMutator.md#BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount 'BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount') to be true

```csharp
public virtual int StackCount(T data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator_T_.StackCount(T).data'></a>

`data` [T](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md#BTD_Mod_Helper.Api.Towers.ModMutator_T_.T 'BTD_Mod_Helper.Api.Towers.ModMutator<T>.T')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')