#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ProjectileHelper Class

A wrapper around ProjectileModels for making them easier to create

```csharp
public class ProjectileHelper : BTD_Mod_Helper.Api.Helpers.ModelHelper<ProjectileModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper') &#129106; [BTD_Mod_Helper.Api.Helpers.ModelHelper&lt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>')[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')[&gt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>') &#129106; ProjectileHelper
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.ProjectileHelper(string)'></a>

## ProjectileHelper(string) Constructor

Begins construction of a new ProjectileModel with sensible default values

```csharp
public ProjectileHelper(string name="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.ProjectileHelper(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The model name (don't need the ProjectileModel_ part)
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Behaviors'></a>

## ProjectileHelper.Behaviors Property

```csharp
public Model[] Behaviors { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.behaviors](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.behaviors 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.behaviors')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CanCollideWithBloons'></a>

## ProjectileHelper.CanCollideWithBloons Property

```csharp
public bool CanCollideWithBloons { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollideWithBloons](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollideWithBloons 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollideWithBloons')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CanCollisionBeBlockedByMapLos'></a>

## ProjectileHelper.CanCollisionBeBlockedByMapLos Property

```csharp
public bool CanCollisionBeBlockedByMapLos { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollisionBeBlockedByMapLos](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollisionBeBlockedByMapLos 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.canCollisionBeBlockedByMapLos')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CanHitCamo'></a>

## ProjectileHelper.CanHitCamo Property

```csharp
public bool CanHitCamo { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CheckCollisionFrames'></a>

## ProjectileHelper.CheckCollisionFrames Property

```csharp
public int CheckCollisionFrames { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CheckCollisionIntervalFrames'></a>

## ProjectileHelper.CheckCollisionIntervalFrames Property

```csharp
public int CheckCollisionIntervalFrames { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.checkCollisionIntervalFrames')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.CollissionPasses'></a>

## ProjectileHelper.CollissionPasses Property

```csharp
public int[] CollissionPasses { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.collisionPasses](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.collisionPasses 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.collisionPasses')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Display'></a>

## ProjectileHelper.Display Property

```csharp
public string Display { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.DisplayModel'></a>

## ProjectileHelper.DisplayModel Property

This ProjectileModel's DisplayModel

```csharp
public DisplayModel DisplayModel { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel 'Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayModel')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.DisplayReference'></a>

## ProjectileHelper.DisplayReference Property

```csharp
public PrefabReference DisplayReference { get; set; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference 'Il2CppNinjaKiwi.Common.ResourceUtils.PrefabReference')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.display')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.DontUseCollisionChecker'></a>

## ProjectileHelper.DontUseCollisionChecker Property

```csharp
public bool DontUseCollisionChecker { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.dontUseCollisionChecker](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.dontUseCollisionChecker 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.dontUseCollisionChecker')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Filter'></a>

## ProjectileHelper.Filter Property

This ProjectileModel's ProjectileFilterModel

```csharp
public ProjectileFilterModel Filter { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Filters'></a>

## ProjectileHelper.Filters Property

```csharp
public FilterModel[] Filters { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel.filters](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel.filters 'Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.ProjectileFilterModel.filters')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.IgnoreBlockers'></a>

## ProjectileHelper.IgnoreBlockers Property

```csharp
public bool IgnoreBlockers { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreBlockers](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreBlockers 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreBlockers')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.IgnoreNonTargetable'></a>

## ProjectileHelper.IgnoreNonTargetable Property

```csharp
public bool IgnoreNonTargetable { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreNonTargetable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreNonTargetable 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignoreNonTargetable')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.IgnorePierceExhaustion'></a>

## ProjectileHelper.IgnorePierceExhaustion Property

```csharp
public bool IgnorePierceExhaustion { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignorePierceExhaustion](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignorePierceExhaustion 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.ignorePierceExhaustion')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.MaxPierce'></a>

## ProjectileHelper.MaxPierce Property

```csharp
public float MaxPierce { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.maxPierce](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.maxPierce 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.maxPierce')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Pierce'></a>

## ProjectileHelper.Pierce Property

```csharp
public float Pierce { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.pierce](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.pierce 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.pierce')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Radius'></a>

## ProjectileHelper.Radius Property

```csharp
public float Radius { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.radius](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.radius 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.radius')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.SaveId'></a>

## ProjectileHelper.SaveId Property

```csharp
public string SaveId { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.saveId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.saveId 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.saveId')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.Scale'></a>

## ProjectileHelper.Scale Property

```csharp
public float Scale { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.scale](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.scale 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.scale')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.UsePointCollisionWithBloons'></a>

## ProjectileHelper.UsePointCollisionWithBloons Property

```csharp
public bool UsePointCollisionWithBloons { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.usePointCollisionWithBloons](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.usePointCollisionWithBloons 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.usePointCollisionWithBloons')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.VsBlockerRadius'></a>

## ProjectileHelper.VsBlockerRadius Property

```csharp
public float VsBlockerRadius { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.vsBlockerRadius](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.vsBlockerRadius 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel.vsBlockerRadius')
### Operators

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.ProjectileHelper(ProjectileModel)'></a>

## ProjectileHelper.implicit operator ProjectileHelper(ProjectileModel) Operator

Wraps a model

```csharp
public static BTD_Mod_Helper.Api.Helpers.ProjectileHelper implicit operator ProjectileHelper(ProjectileModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.ProjectileHelper(ProjectileModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

#### Returns
[ProjectileHelper](BTD_Mod_Helper.Api.Helpers.ProjectileHelper.md 'BTD_Mod_Helper.Api.Helpers.ProjectileHelper')

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.op_ImplicitProjectileModel(BTD_Mod_Helper.Api.Helpers.ProjectileHelper)'></a>

## ProjectileHelper.implicit operator ProjectileModel(ProjectileHelper) Operator

Unwraps the model (and updates collision passes)

```csharp
public static ProjectileModel implicit operator ProjectileModel(BTD_Mod_Helper.Api.Helpers.ProjectileHelper helper);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ProjectileHelper.op_ImplicitProjectileModel(BTD_Mod_Helper.Api.Helpers.ProjectileHelper).helper'></a>

`helper` [ProjectileHelper](BTD_Mod_Helper.Api.Helpers.ProjectileHelper.md 'BTD_Mod_Helper.Api.Helpers.ProjectileHelper')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')