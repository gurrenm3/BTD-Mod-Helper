#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EntityBehaviorExt Class

Behavior extensions for Entities

```csharp
public static class EntityBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior_T_(thisEntity,T)'></a>

## EntityBehaviorExt.AddBehavior<T>(this Entity, T) Method

Add a Behavior to this

```csharp
public static void AddBehavior<T>(this Entity entity, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior_T_(thisEntity,T).T'></a>

`T`

The Behavior you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior_T_(thisEntity,T).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior_T_(thisEntity,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EntityBehaviorExt.md#BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior_T_(thisEntity,T).T 'BTD_Mod_Helper.Extensions.EntityBehaviorExt.AddBehavior<T>(this Entity, T).T')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehavior_T_(thisEntity)'></a>

## EntityBehaviorExt.GetBehavior<T>(this Entity) Method

Return the first Behavior of type T

```csharp
public static T GetBehavior<T>(this Entity entity)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehavior_T_(thisEntity).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehavior_T_(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[T](BTD_Mod_Helper.Extensions.EntityBehaviorExt.md#BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehavior_T_(thisEntity).T 'BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehavior<T>(this Entity).T')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehaviors_T_(thisEntity)'></a>

## EntityBehaviorExt.GetBehaviors<T>(this Entity) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this Entity entity)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehaviors_T_(thisEntity).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehaviors_T_(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.EntityBehaviorExt.md#BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehaviors_T_(thisEntity).T 'BTD_Mod_Helper.Extensions.EntityBehaviorExt.GetBehaviors<T>(this Entity).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.HasBehavior_T_(thisEntity)'></a>

## EntityBehaviorExt.HasBehavior<T>(this Entity) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this Entity entity)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.HasBehavior_T_(thisEntity).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.HasBehavior_T_(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity,T)'></a>

## EntityBehaviorExt.RemoveBehavior<T>(this Entity, T) Method

Remove the first Behavior of type T

```csharp
public static void RemoveBehavior<T>(this Entity entity, T behavior)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity,T).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity,T).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.EntityBehaviorExt.md#BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity,T).T 'BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior<T>(this Entity, T).T')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity)'></a>

## EntityBehaviorExt.RemoveBehavior<T>(this Entity) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this Entity entity)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehavior_T_(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehaviors_T_(thisEntity)'></a>

## EntityBehaviorExt.RemoveBehaviors<T>(this Entity) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this Entity entity)
    where T : Model;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehaviors_T_(thisEntity).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityBehaviorExt.RemoveBehaviors_T_(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')