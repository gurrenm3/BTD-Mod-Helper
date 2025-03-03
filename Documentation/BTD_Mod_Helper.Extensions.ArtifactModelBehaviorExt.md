#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ArtifactModelBehaviorExt Class

Behavior extensions for ItemArtifactModels and BoostArtifactModels

```csharp
public static class ArtifactModelBehaviorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ArtifactModelBehaviorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisBoostArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.AddBehavior<T>(this BoostArtifactModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this BoostArtifactModel model, T behavior)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisBoostArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisBoostArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisBoostArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisBoostArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior<T>(this BoostArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisItemArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.AddBehavior<T>(this ItemArtifactModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this ItemArtifactModel model, T behavior)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisItemArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisItemArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisItemArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisItemArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior<T>(this ItemArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisMapArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.AddBehavior<T>(this MapArtifactModel, T) Method

Add a Behavior to this model

```csharp
public static void AddBehavior<T>(this MapArtifactModel model, T behavior)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisMapArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisMapArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisMapArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior_T_(thisMapArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBehavior<T>(this MapArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehavior(thisItemArtifactModel,BoostArtifactBehaviorModel,System.Action_BoostArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddBoostBehavior(this ItemArtifactModel, BoostArtifactBehaviorModel, Action<BoostArtifactModel>) Method

Helper method for ItemArtifacts to easily add BoostArtifactBehaviorModels via InvokeBoostBuffBehaviorModel like many vanilla items do

```csharp
public static void AddBoostBehavior(this ItemArtifactModel artifact, BoostArtifactBehaviorModel boostBehavior, System.Action<BoostArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehavior(thisItemArtifactModel,BoostArtifactBehaviorModel,System.Action_BoostArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehavior(thisItemArtifactModel,BoostArtifactBehaviorModel,System.Action_BoostArtifactModel_).boostBehavior'></a>

`boostBehavior` [Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel')

Boost behavior to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehavior(thisItemArtifactModel,BoostArtifactBehaviorModel,System.Action_BoostArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific towers

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_BoostArtifactBehaviorModel_,System.Action_BoostArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddBoostBehaviors(this ItemArtifactModel, IEnumerable<BoostArtifactBehaviorModel>, Action<BoostArtifactModel>) Method

Helper method for ItemArtifacts to easily add BoostArtifactBehaviorModels via InvokeBoostBuffBehaviorModel like many vanilla items do

```csharp
public static void AddBoostBehaviors(this ItemArtifactModel artifact, System.Collections.Generic.IEnumerable<BoostArtifactBehaviorModel> boostBehaviors, System.Action<BoostArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_BoostArtifactBehaviorModel_,System.Action_BoostArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_BoostArtifactBehaviorModel_,System.Action_BoostArtifactModel_).boostBehaviors'></a>

`boostBehaviors` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.BoostArtifactBehaviorModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Boost behaviors to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddBoostBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_BoostArtifactBehaviorModel_,System.Action_BoostArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific towers

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehavior(thisItemArtifactModel,ProjectileBehaviorModel,System.Action_AddProjectileBehaviorsArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddProjectileBehavior(this ItemArtifactModel, ProjectileBehaviorModel, Action<AddProjectileBehaviorsArtifactModel>) Method

Helper method for ItemArtifacts to easily add ProjectileBehaviors to projectiles via AddProjectileBehaviorsArtifactModel like many vanilla items do

```csharp
public static void AddProjectileBehavior(this ItemArtifactModel artifact, ProjectileBehaviorModel projectileBehavior, System.Action<AddProjectileBehaviorsArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehavior(thisItemArtifactModel,ProjectileBehaviorModel,System.Action_AddProjectileBehaviorsArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehavior(thisItemArtifactModel,ProjectileBehaviorModel,System.Action_AddProjectileBehaviorsArtifactModel_).projectileBehavior'></a>

`projectileBehavior` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel')

Projectile behavior to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehavior(thisItemArtifactModel,ProjectileBehaviorModel,System.Action_AddProjectileBehaviorsArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific projectiles

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_ProjectileBehaviorModel_,System.Action_AddProjectileBehaviorsArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddProjectileBehaviors(this ItemArtifactModel, IEnumerable<ProjectileBehaviorModel>, Action<AddProjectileBehaviorsArtifactModel>) Method

Helper method for ItemArtifacts to easily add ProjectileBehaviors to projectiles via AddProjectileBehaviorsArtifactModel like many vanilla items do

```csharp
public static void AddProjectileBehaviors(this ItemArtifactModel artifact, System.Collections.Generic.IEnumerable<ProjectileBehaviorModel> projectileBehaviors, System.Action<AddProjectileBehaviorsArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_ProjectileBehaviorModel_,System.Action_AddProjectileBehaviorsArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_ProjectileBehaviorModel_,System.Action_AddProjectileBehaviorsArtifactModel_).projectileBehaviors'></a>

`projectileBehaviors` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileBehaviorModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Projectile behaviors to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddProjectileBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_ProjectileBehaviorModel_,System.Action_AddProjectileBehaviorsArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddProjectileBehaviorsArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific projectiles

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehavior(thisItemArtifactModel,TowerBehaviorModel,System.Action_AddTowerBehaviorsArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddTowerBehavior(this ItemArtifactModel, TowerBehaviorModel, Action<AddTowerBehaviorsArtifactModel>) Method

Helper method for ItemArtifacts to easily add TowerBehaviors to towers via AddTowerBehaviorsArtifactModel like many vanilla items do

```csharp
public static void AddTowerBehavior(this ItemArtifactModel artifact, TowerBehaviorModel towerBehavior, System.Action<AddTowerBehaviorsArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehavior(thisItemArtifactModel,TowerBehaviorModel,System.Action_AddTowerBehaviorsArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehavior(thisItemArtifactModel,TowerBehaviorModel,System.Action_AddTowerBehaviorsArtifactModel_).towerBehavior'></a>

`towerBehavior` [Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel 'Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel')

Tower behavior to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehavior(thisItemArtifactModel,TowerBehaviorModel,System.Action_AddTowerBehaviorsArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific towers

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_TowerBehaviorModel_,System.Action_AddTowerBehaviorsArtifactModel_)'></a>

## ArtifactModelBehaviorExt.AddTowerBehaviors(this ItemArtifactModel, IEnumerable<TowerBehaviorModel>, Action<AddTowerBehaviorsArtifactModel>) Method

Helper method for ItemArtifacts to easily add TowerBehaviors to towers via AddTowerBehaviorsArtifactModel like many vanilla items do

```csharp
public static void AddTowerBehaviors(this ItemArtifactModel artifact, System.Collections.Generic.IEnumerable<TowerBehaviorModel> towerBehaviors, System.Action<AddTowerBehaviorsArtifactModel> modifyBoost=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_TowerBehaviorModel_,System.Action_AddTowerBehaviorsArtifactModel_).artifact'></a>

`artifact` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

this

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_TowerBehaviorModel_,System.Action_AddTowerBehaviorsArtifactModel_).towerBehaviors'></a>

`towerBehaviors` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel 'Il2CppAssets.Scripts.Models.Towers.TowerBehaviorModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Tower behaviors to add

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.AddTowerBehaviors(thisItemArtifactModel,System.Collections.Generic.IEnumerable_TowerBehaviorModel_,System.Action_AddTowerBehaviorsArtifactModel_).modifyBoost'></a>

`modifyBoost` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.Behaviors.AddTowerBehaviorsArtifactModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

function for modifying the boost, like for filtering it to specific towers

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehavior<T>(this BoostArtifactModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this BoostArtifactModel model)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisBoostArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisBoostArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior<T>(this BoostArtifactModel).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehavior<T>(this ItemArtifactModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this ItemArtifactModel model)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisItemArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisItemArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior<T>(this ItemArtifactModel).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehavior<T>(this MapArtifactModel) Method

Return the first Behavior of type T, or null if there isn't one

```csharp
public static T GetBehavior<T>(this MapArtifactModel model)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisMapArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

#### Returns
[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior_T_(thisMapArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehavior<T>(this MapArtifactModel).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehaviors<T>(this BoostArtifactModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this BoostArtifactModel model)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisBoostArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisBoostArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors<T>(this BoostArtifactModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehaviors<T>(this ItemArtifactModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this ItemArtifactModel model)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisItemArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisItemArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors<T>(this ItemArtifactModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.GetBehaviors<T>(this MapArtifactModel) Method

Return all Behaviors of type T

```csharp
public static System.Collections.Generic.List<T> GetBehaviors<T>(this MapArtifactModel model)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisMapArtifactModel).T'></a>

`T`

The Behavior you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors_T_(thisMapArtifactModel).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.GetBehaviors<T>(this MapArtifactModel).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.HasBehavior<T>(this BoostArtifactModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this BoostArtifactModel model)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisBoostArtifactModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.HasBehavior<T>(this ItemArtifactModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this ItemArtifactModel model)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisItemArtifactModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.HasBehavior<T>(this MapArtifactModel) Method

Check if this has a specific Behavior

```csharp
public static bool HasBehavior<T>(this MapArtifactModel model)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisMapArtifactModel).T'></a>

`T`

The Behavior you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.HasBehavior_T_(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this BoostArtifactModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this BoostArtifactModel model, T behavior)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior<T>(this BoostArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this BoostArtifactModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this BoostArtifactModel model)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this ItemArtifactModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this ItemArtifactModel model, T behavior)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior<T>(this ItemArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this ItemArtifactModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this ItemArtifactModel model)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel,T)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this MapArtifactModel, T) Method

Removes a specific behavior from a tower

```csharp
public static void RemoveBehavior<T>(this MapArtifactModel model, T behavior)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel,T).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel,T).behavior'></a>

`behavior` [T](BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.md#BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel,T).T 'BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior<T>(this MapArtifactModel, T).T')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehavior<T>(this MapArtifactModel) Method

Remove the first Behavior of Type T

```csharp
public static void RemoveBehavior<T>(this MapArtifactModel model)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel).T'></a>

`T`

The Behavior you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehavior_T_(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors(this BoostArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this BoostArtifactModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors(this ItemArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this ItemArtifactModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors(this MapArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors(this MapArtifactModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisBoostArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors<T>(this BoostArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this BoostArtifactModel model)
    where T : BoostArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisBoostArtifactModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisBoostArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisItemArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors<T>(this ItemArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this ItemArtifactModel model)
    where T : ItemArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisItemArtifactModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisItemArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisMapArtifactModel)'></a>

## ArtifactModelBehaviorExt.RemoveBehaviors<T>(this MapArtifactModel) Method

Remove all Behaviors of type T

```csharp
public static void RemoveBehaviors<T>(this MapArtifactModel model)
    where T : MapArtifactBehaviorModel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisMapArtifactModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArtifactModelBehaviorExt.RemoveBehaviors_T_(thisMapArtifactModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')