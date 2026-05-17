#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BehaviorMutatorExt Class

Extensions for BehaviorMutators

```csharp
public static class BehaviorMutatorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BehaviorMutatorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.GetModMutator(thisBehaviorMutator)'></a>

## BehaviorMutatorExt.GetModMutator(this BehaviorMutator) Method

Gets the ModMutator class for this mutator if it's modded

```csharp
public static BTD_Mod_Helper.Api.Towers.ModMutator GetModMutator(this BehaviorMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.GetModMutator(thisBehaviorMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

this

#### Returns
[ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')  
ModMutator or null

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.GetModMutator(thisTimedMutator)'></a>

## BehaviorMutatorExt.GetModMutator(this TimedMutator) Method

Gets the ModMutator class for this mutator if it's modded

```csharp
public static BTD_Mod_Helper.Api.Towers.ModMutator GetModMutator(this TimedMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.GetModMutator(thisTimedMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

this

#### Returns
[ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')  
ModMutator or null

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.ModMutatorData(thisBehaviorMutator)'></a>

## BehaviorMutatorExt.ModMutatorData(this BehaviorMutator) Method

Gets the ModMutator custom data for this mutator

```csharp
public static JToken ModMutatorData(this BehaviorMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.ModMutatorData(thisBehaviorMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

this

#### Returns
[Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')  
custom json data for mod mutator, or null

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.ModMutatorData(thisTimedMutator)'></a>

## BehaviorMutatorExt.ModMutatorData(this TimedMutator) Method

Gets the ModMutator custom data for this mutator

```csharp
public static JToken ModMutatorData(this TimedMutator mutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.ModMutatorData(thisTimedMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

this

#### Returns
[Newtonsoft.Json.Linq.JToken](https://docs.microsoft.com/en-us/dotnet/api/Newtonsoft.Json.Linq.JToken 'Newtonsoft.Json.Linq.JToken')  
custom json data for mod mutator, or null

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisBehaviorMutator,BTD_Mod_Helper.Api.Towers.ModMutator)'></a>

## BehaviorMutatorExt.TryGetModMutator(this BehaviorMutator, ModMutator) Method

Tries to get the ModMutator class for this mutator if it's modded

```csharp
public static bool TryGetModMutator(this BehaviorMutator mutator, out BTD_Mod_Helper.Api.Towers.ModMutator modMutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisBehaviorMutator,BTD_Mod_Helper.Api.Towers.ModMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator 'Il2CppAssets.Scripts.Simulation.Objects.BehaviorMutator')

this

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisBehaviorMutator,BTD_Mod_Helper.Api.Towers.ModMutator).modMutator'></a>

`modMutator` [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

output ModMutator

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
ModMutator exists

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisTimedMutator,BTD_Mod_Helper.Api.Towers.ModMutator)'></a>

## BehaviorMutatorExt.TryGetModMutator(this TimedMutator, ModMutator) Method

Tries to get the ModMutator class for this mutator if it's modded

```csharp
public static bool TryGetModMutator(this TimedMutator mutator, out BTD_Mod_Helper.Api.Towers.ModMutator modMutator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisTimedMutator,BTD_Mod_Helper.Api.Towers.ModMutator).mutator'></a>

`mutator` [Il2CppAssets.Scripts.Simulation.Objects.TimedMutator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.TimedMutator 'Il2CppAssets.Scripts.Simulation.Objects.TimedMutator')

this

<a name='BTD_Mod_Helper.Extensions.BehaviorMutatorExt.TryGetModMutator(thisTimedMutator,BTD_Mod_Helper.Api.Towers.ModMutator).modMutator'></a>

`modMutator` [ModMutator](BTD_Mod_Helper.Api.Towers.ModMutator.md 'BTD_Mod_Helper.Api.Towers.ModMutator')

output ModMutator

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
ModMutator exists