#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModMutator Class

ModContent that implements a custom version of a [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

```csharp
public abstract class ModMutator : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModMutator

Derived  
&#8627; [ModMutator&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModMutator_T_.md 'BTD_Mod_Helper.Api.Towers.ModMutator<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.BaseMutator'></a>

## ModMutator.BaseMutator Property

The base mutator to hijack. If you override this you should also override [Create(JToken)](BTD_Mod_Helper.Api.Towers.ModMutator.md#BTD_Mod_Helper.Api.Towers.ModMutator.Create(JToken) 'BTD_Mod_Helper.Api.Towers.ModMutator.Create(JToken)'), and for custom data to  
work you will also need to override [GetData(BehaviorMutator)](BTD_Mod_Helper.Api.Towers.ModMutator.md#BTD_Mod_Helper.Api.Towers.ModMutator.GetData(BehaviorMutator) 'BTD_Mod_Helper.Api.Towers.ModMutator.GetData(BehaviorMutator)')

```csharp
public virtual System.Type BaseMutator { get; }
```

#### Property Value
[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.BuffIcon'></a>

## ModMutator.BuffIcon Property

Buff Icon to use for this mutator, if any

```csharp
public virtual BuffIndicatorModel BuffIcon { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GenericBehaviors.BuffIndicatorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.BuffIndicatorModel 'Il2CppAssets.Scripts.Models.GenericBehaviors.BuffIndicatorModel')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.CantBeAbsorbed'></a>

## ModMutator.CantBeAbsorbed Property

Whether this is immune to effects like Lych absorb

```csharp
public virtual bool CantBeAbsorbed { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.IsUnique'></a>

## ModMutator.IsUnique Property

Whether only one of this mutator can be applied to an entity at once

```csharp
public virtual bool IsUnique { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.MutatorId'></a>

## ModMutator.MutatorId Property

ID to use for the mutator. Defaults to [Id](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.Id 'BTD_Mod_Helper.Api.ModContent.Id'), of course

```csharp
public virtual string MutatorId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount'></a>

## ModMutator.OverrideStackCount Property

Whether to override the visual stack count of this mutator on a tower

```csharp
public virtual bool OverrideStackCount { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Priority'></a>

## ModMutator.Priority Property

Mutator Priority to use. Higher values make the Mutator happen earlier in the process in relation to other mutators.  
For reference, the Paths++ internal mutator is ~100 to be before pretty much all others

```csharp
public virtual int Priority { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.RunBaseMutator'></a>

## ModMutator.RunBaseMutator Property

Whether to still perform the original mutation of the base mutator

```csharp
public virtual bool RunBaseMutator { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Saved'></a>

## ModMutator.Saved Property

Whether this mutator should be manually saved

```csharp
public virtual bool Saved { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Create(JToken)'></a>

## ModMutator.Create(JToken) Method

Creates a BehaviorMutator for use with the specified custom data

```csharp
public virtual BehaviorMutator Create(JToken data=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Create(JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

custom data

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')  
BehaviorMutator

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Get(Mutable,JToken)'></a>

## ModMutator.Get(Mutable, JToken) Method

Gets the TimedMutator for this ModMutator on an entity

```csharp
public TimedMutator Get(Mutable mutable, out JToken data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Get(Mutable,JToken).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

mutated entity

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Get(Mutable,JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

custom data

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')  
TimedMutator

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Get(Mutable)'></a>

## ModMutator.Get(Mutable) Method

Gets the TimedMutator for this ModMutator on an entity

```csharp
public TimedMutator Get(Mutable mutable);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Get(Mutable).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

mutated entity

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')  
TimedMutator

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.GetData(BehaviorMutator)'></a>

## ModMutator.GetData(BehaviorMutator) Method

Gets the stored custom data for the behavior mutator

```csharp
public virtual JToken GetData(BehaviorMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.GetData(BehaviorMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

BehaviorMutator

#### Returns
[Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')  
json token of custom data

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.LoadMutator(Mutable,MutatorSaveDataModel)'></a>

## ModMutator.LoadMutator(Mutable, MutatorSaveDataModel) Method

Loads this mutator back onto an entity from its MutatorSaveDataModel

```csharp
public virtual void LoadMutator(Mutable mutable, MutatorSaveDataModel mutatorSaveDataModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.LoadMutator(Mutable,MutatorSaveDataModel).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

entity to mutate

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.LoadMutator(Mutable,MutatorSaveDataModel).mutatorSaveDataModel'></a>

`mutatorSaveDataModel` [Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel 'Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel')

mutator save data

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Mutate(Model,Model,JToken)'></a>

## ModMutator.Mutate(Model, Model, JToken) Method

Applies this mutator to a model

```csharp
public abstract bool Mutate(Model baseModel, Model model, JToken data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Mutate(Model,Model,JToken).baseModel'></a>

`baseModel` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Version of the model with no mutators applied

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Mutate(Model,Model,JToken).model'></a>

`model` [Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')

Current model, the one that should be mutated

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.Mutate(Model,Model,JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

any custom data for the mutator in the form of JSON

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether any changes were actually made

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.SaveMutator(Mutable,TimedMutator)'></a>

## ModMutator.SaveMutator(Mutable, TimedMutator) Method

Saves this mutator to a MutatorSaveDataModel

```csharp
public virtual MutatorSaveDataModel SaveMutator(Mutable mutable, TimedMutator timedMutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.SaveMutator(Mutable,TimedMutator).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

mutated entity

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.SaveMutator(Mutable,TimedMutator).timedMutator'></a>

`timedMutator` [Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

current mutator

#### Returns
[Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel 'Il2CppAssets.Scripts.Models.Profile.MutatorSaveDataModel')  
mutator save data

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.StackCount(JToken)'></a>

## ModMutator.StackCount(JToken) Method

To what amount to override the visual stack count of this mutator on a tower  
Requires [OverrideStackCount](BTD_Mod_Helper.Api.Towers.ModMutator.md#BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount 'BTD_Mod_Helper.Api.Towers.ModMutator.OverrideStackCount') to be true

```csharp
public virtual int StackCount(JToken data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModMutator.StackCount(JToken).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')