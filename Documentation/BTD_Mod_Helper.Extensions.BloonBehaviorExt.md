#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonBehaviorExt Class

Extensions for getting bloon behaviors

```csharp
public static class BloonBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T)'></a>

## BloonBehaviorExt.AddBloonBehavior<T>(this Bloon, T) Method

Add a Behavior to this

```csharp
public static void AddBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon, T behavior)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonBehaviorExt.GetBloonBehavior<T>(this Bloon) Method

Return the first Behavior of type T

```csharp
public static T GetBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonBehaviorExt.GetBloonBehaviors<T>(this Bloon) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBloonBehaviors<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors<T>(this Assets.Scripts.Simulation.Bloons.Bloon).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonBehaviorExt.HasBloonBehavior<T>(this Bloon) Method

Check if this has a specific Behavior

```csharp
public static bool HasBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonBehaviorExt.RemoveBloonBehavior<T>(this Bloon) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T)'></a>

## BloonBehaviorExt.RemoveBloonBehavior<T>(this Bloon, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon, T behavior)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisAssets.Scripts.Simulation.Bloons.Bloon,T).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior<T>(this Assets.Scripts.Simulation.Bloons.Bloon, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonBehaviorExt.RemoveBloonBehaviors<T>(this Bloon) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBloonBehaviors<T>(this Assets.Scripts.Simulation.Bloons.Bloon bloon)
    where T : Assets.Scripts.Simulation.Bloons.BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')