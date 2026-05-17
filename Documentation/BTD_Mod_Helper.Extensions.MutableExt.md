#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## MutableExt Class

Extensions for Mutables

```csharp
public static class MutableExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MutableExt
### Methods

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool)'></a>

## MutableExt.AddMutator<T>(this Mutable, JToken, int, bool, bool, bool, bool, bool, bool, bool, int, bool, bool) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.AddMutator(Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator,System.Int32,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean,System.Boolean)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.AddMutator#Il2CppAssets_Scripts_Simulation_Objects_Mutable_AddMutator_Il2CppAssets_Scripts_Simulation_Objects_BehaviorMutator,System_Int32,System_Boolean,System_Boolean,System_Boolean,System_Boolean,System_Boolean,System_Boolean,System_Boolean,System_Int32,System_Boolean,System_Boolean_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.AddMutator(Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator,System.Int32,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Boolean,System.Int32,System.Boolean,System.Boolean)') with a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static void AddMutator<T>(this Mutable mutable, JToken data=null, int time=-1, bool updateDuration=true, bool applyMutation=true, bool onlyTimeoutWhenActive=false, bool useRoundTime=true, bool cascadeMutators=false, bool includeSubTowers=false, bool ignoreRecursionCheck=false, int roundsRemaining=-1, bool isParagonMutator=false, bool cantBeAbsorbed=false)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).data'></a>

`data` [Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).time'></a>

`time` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).updateDuration'></a>

`updateDuration` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).applyMutation'></a>

`applyMutation` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).onlyTimeoutWhenActive'></a>

`onlyTimeoutWhenActive` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).useRoundTime'></a>

`useRoundTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).cascadeMutators'></a>

`cascadeMutators` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).includeSubTowers'></a>

`includeSubTowers` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).ignoreRecursionCheck'></a>

`ignoreRecursionCheck` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).roundsRemaining'></a>

`roundsRemaining` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).isParagonMutator'></a>

`isParagonMutator` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.AddMutator_T_(thisMutable,JToken,int,bool,bool,bool,bool,bool,bool,bool,int,bool,bool).cantBeAbsorbed'></a>

`cantBeAbsorbed` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutator_T_(thisMutable)'></a>

## MutableExt.GetMutator<T>(this Mutable) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator#Il2CppAssets_Scripts_Simulation_Objects_Mutable_GetMutator_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static BehaviorMutator GetMutator<T>(this Mutable mutable)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutator_T_(thisMutable).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutator_T_(thisMutable).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutatorById_T_(thisMutable)'></a>

## MutableExt.GetMutatorById<T>(this Mutable) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById#Il2CppAssets_Scripts_Simulation_Objects_Mutable_GetMutatorById_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static TimedMutator GetMutatorById<T>(this Mutable mutable)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutatorById_T_(thisMutable).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.GetMutatorById_T_(thisMutable).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutator_T_(thisMutable,BehaviorMutator)'></a>

## MutableExt.HasMutator<T>(this Mutable, BehaviorMutator) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator#Il2CppAssets_Scripts_Simulation_Objects_Mutable_GetMutator_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutator(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static bool HasMutator<T>(this Mutable mutable, out BehaviorMutator behaviorMutator)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutator_T_(thisMutable,BehaviorMutator).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutator_T_(thisMutable,BehaviorMutator).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutator_T_(thisMutable,BehaviorMutator).behaviorMutator'></a>

`behaviorMutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutatorById_T_(thisMutable,TimedMutator)'></a>

## MutableExt.HasMutatorById<T>(this Mutable, TimedMutator) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById#Il2CppAssets_Scripts_Simulation_Objects_Mutable_GetMutatorById_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.GetMutatorById(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static bool HasMutatorById<T>(this Mutable mutable, out TimedMutator behaviorMutator)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutatorById_T_(thisMutable,TimedMutator).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutatorById_T_(thisMutable,TimedMutator).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

<a name='BTD_Mod_Helper.Extensions.MutableExt.HasMutatorById_T_(thisMutable,TimedMutator).behaviorMutator'></a>

`behaviorMutator` [Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.IsMutatedBy_T_(thisMutable)'></a>

## MutableExt.IsMutatedBy<T>(this Mutable) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.IsMutatedBy(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.IsMutatedBy#Il2CppAssets_Scripts_Simulation_Objects_Mutable_IsMutatedBy_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.IsMutatedBy(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static bool IsMutatedBy<T>(this Mutable mutable)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.IsMutatedBy_T_(thisMutable).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.IsMutatedBy_T_(thisMutable).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.MutableExt.RemoveMutator_T_(thisMutable)'></a>

## MutableExt.RemoveMutator<T>(this Mutable) Method

Calls [Il2CppAssets.Scripts.Simulation.Objects.Mutable.RemoveMutatorsById(System.String)](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable.RemoveMutatorsById#Il2CppAssets_Scripts_Simulation_Objects_Mutable_RemoveMutatorsById_System_String_ 'Il2CppAssets.Scripts.Simulation.Objects.Mutable.RemoveMutatorsById(System.String)') for a [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

```csharp
public static void RemoveMutator<T>(this Mutable mutable)
    where T : BTD_Mod_Helper.Api.Towers.ModMutator;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.RemoveMutator_T_(thisMutable).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MutableExt.RemoveMutator_T_(thisMutable).mutable'></a>

`mutable` [Il2CppAssets.Scripts.Simulation.Objects.Mutable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Mutable 'Il2CppAssets.Scripts.Simulation.Objects.Mutable')