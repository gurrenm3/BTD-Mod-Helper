#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonBehaviorExt Class

Extensions for getting bloon behaviors

```csharp
public static class BloonBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisBloon,T)'></a>

## BloonBehaviorExt.AddBloonBehavior<T>(this Bloon, T) Method

Add a Behavior to this

```csharp
public static void AddBloonBehavior<T>(this Bloon bloon, T behavior)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisBloon,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisBloon,T).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisBloon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior_T_(thisBloon,T).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.AddBloonBehavior<T>(this Bloon, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisBloon)'></a>

## BloonBehaviorExt.GetBloonBehavior<T>(this Bloon) Method

Return the first Behavior of type T

```csharp
public static T GetBloonBehavior<T>(this Bloon bloon)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisBloon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisBloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior_T_(thisBloon).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehavior<T>(this Bloon).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisBloon)'></a>

## BloonBehaviorExt.GetBloonBehaviors<T>(this Bloon) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBloonBehaviors<T>(this Bloon bloon)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisBloon).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisBloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors_T_(thisBloon).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.GetBloonBehaviors<T>(this Bloon).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisBloon)'></a>

## BloonBehaviorExt.HasBloonBehavior<T>(this Bloon) Method

Check if this has a specific Behavior

```csharp
public static bool HasBloonBehavior<T>(this Bloon bloon)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisBloon).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.HasBloonBehavior_T_(thisBloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon,T)'></a>

## BloonBehaviorExt.RemoveBloonBehavior<T>(this Bloon, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBloonBehavior<T>(this Bloon bloon, T behavior)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon,T).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.BloonBehaviorExt.md#BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon,T).T 'BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior<T>(this Bloon, T).T')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon)'></a>

## BloonBehaviorExt.RemoveBloonBehavior<T>(this Bloon) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBloonBehavior<T>(this Bloon bloon)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehavior_T_(thisBloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisBloon)'></a>

## BloonBehaviorExt.RemoveBloonBehaviors<T>(this Bloon) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBloonBehaviors<T>(this Bloon bloon)
    where T : BloonBehavior;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisBloon).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonBehaviorExt.RemoveBloonBehaviors_T_(thisBloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')