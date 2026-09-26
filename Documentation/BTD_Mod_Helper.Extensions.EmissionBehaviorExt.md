#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EmissionBehaviorExt Class

Behavior extensions for Emissions

```csharp
public static class EmissionBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EmissionBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior_T_(thisEmission,T)'></a>

## EmissionBehaviorExt.AddEmissionBehavior<T>(this Emission, T) Method

Add a Behavior to this

```csharp
public static void AddEmissionBehavior<T>(this Emission emission, T behavior)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior_T_(thisEmission,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior_T_(thisEmission,T).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior_T_(thisEmission,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior_T_(thisEmission,T).T 'BTD_Mod_Helper.Extensions.EmissionBehaviorExt.AddEmissionBehavior<T>(this Emission, T).T')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehavior_T_(thisEmission)'></a>

## EmissionBehaviorExt.GetEmissionBehavior<T>(this Emission) Method

Return the first Behavior of type T

```csharp
public static T GetEmissionBehavior<T>(this Emission emission)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehavior_T_(thisEmission).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehavior_T_(thisEmission).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

#### Returns
[T](BTD_Mod_Helper.Extensions.EmissionBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehavior_T_(thisEmission).T 'BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehavior<T>(this Emission).T')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehaviors_T_(thisEmission)'></a>

## EmissionBehaviorExt.GetEmissionBehaviors<T>(this Emission) Method

Return all Behaviors of type T

```csharp
public static List<T> GetEmissionBehaviors<T>(this Emission emission)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehaviors_T_(thisEmission).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.GetEmissionBehaviors_T_(thisEmission).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission,T)'></a>

## EmissionBehaviorExt.HasEmissionBehavior<T>(this Emission, T) Method

Check if this has a specific Behavior

```csharp
public static bool HasEmissionBehavior<T>(this Emission emission, out T item)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission,T).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission,T).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission,T).item'></a>

`item` [T](BTD_Mod_Helper.Extensions.EmissionBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission,T).T 'BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior<T>(this Emission, T).T')

The returned item, if it exists

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission)'></a>

## EmissionBehaviorExt.HasEmissionBehavior<T>(this Emission) Method

Check if this has a specific Behavior

```csharp
public static bool HasEmissionBehavior<T>(this Emission emission)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.HasEmissionBehavior_T_(thisEmission).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission,T)'></a>

## EmissionBehaviorExt.RemoveEmissionBehavior<T>(this Emission, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveEmissionBehavior<T>(this Emission emission, T behavior)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission,T).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EmissionBehaviorExt.md#BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission,T).T 'BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior<T>(this Emission, T).T')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission)'></a>

## EmissionBehaviorExt.RemoveEmissionBehavior<T>(this Emission) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveEmissionBehavior<T>(this Emission emission)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehavior_T_(thisEmission).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehaviors_T_(thisEmission)'></a>

## EmissionBehaviorExt.RemoveEmissionBehaviors<T>(this Emission) Method

Remove all Behaviors of type T

```csharp
public static void RemoveEmissionBehaviors<T>(this Emission emission)
    where T : RootBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehaviors_T_(thisEmission).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EmissionBehaviorExt.RemoveEmissionBehaviors_T_(thisEmission).emission'></a>

`emission` [Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission 'Il2CppAssets.Scripts.Simulation.Towers.Emissions.Emission')