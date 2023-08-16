#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## AttackHelper Class

A wrapper around AttackModels for making them easier to create

```csharp
public class AttackHelper : BTD_Mod_Helper.Api.Helpers.ModelHelper<AttackModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper') &#129106; [BTD_Mod_Helper.Api.Helpers.ModelHelper&lt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>')[Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')[&gt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>') &#129106; AttackHelper
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.AttackHelper(string)'></a>

## AttackHelper(string) Constructor

Begins construction of a new AttackModel with sensible default values

```csharp
public AttackHelper(string name="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.AttackHelper(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The model name (don't need the AttackModel_ part)
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.AddToSharedGrid'></a>

## AttackHelper.AddToSharedGrid Property

```csharp
public bool AddToSharedGrid { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.addsToSharedGrid](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.addsToSharedGrid 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.addsToSharedGrid')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.AttackThroughWalls'></a>

## AttackHelper.AttackThroughWalls Property

```csharp
public bool AttackThroughWalls { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.attackThroughWalls](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.attackThroughWalls 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.attackThroughWalls')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Behaviors'></a>

## AttackHelper.Behaviors Property

```csharp
public Model[] Behaviors { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.behaviors](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.behaviors 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.behaviors')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.CanSeeCamo'></a>

## AttackHelper.CanSeeCamo Property

```csharp
public bool CanSeeCamo { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel.isActive')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Filter'></a>

## AttackHelper.Filter Property

This AttackModel's AttackFilterModel

```csharp
public AttackFilterModel Filter { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Filters'></a>

## AttackHelper.Filters Property

```csharp
public FilterModel[] Filters { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel 'Il2CppAssets.Scripts.Models.Towers.Filters.FilterModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel.filters](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel.filters 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.AttackFilterModel.filters')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.FireWithoutTarget'></a>

## AttackHelper.FireWithoutTarget Property

```csharp
public bool FireWithoutTarget { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.fireWithoutTarget](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.fireWithoutTarget 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.fireWithoutTarget')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.FramesBeforeRetarget'></a>

## AttackHelper.FramesBeforeRetarget Property

```csharp
public int FramesBeforeRetarget { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.framesBeforeRetarget](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.framesBeforeRetarget 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.framesBeforeRetarget')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Offset'></a>

## AttackHelper.Offset Property

```csharp
public Vector3 Offset { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetX](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetX 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetX')
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetY](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetY 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetY')
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetZ](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetZ 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.offsetZ')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Range'></a>

## AttackHelper.Range Property

```csharp
public float Range { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.range](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.range 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.range')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.SharedGridRange'></a>

## AttackHelper.SharedGridRange Property

```csharp
public float SharedGridRange { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.sharedGridRange](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.sharedGridRange 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.sharedGridRange')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.TargetProvider'></a>

## AttackHelper.TargetProvider Property

```csharp
public TargetSupplierModel TargetProvider { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.TargetSupplierModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.TargetSupplierModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors.TargetSupplierModel')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.targetProvider](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.targetProvider 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.targetProvider')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Weapon'></a>

## AttackHelper.Weapon Property

```csharp
public WeaponModel Weapon { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.Weapons'></a>

## AttackHelper.Weapons Property

```csharp
public WeaponModel[] Weapons { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel.weapons')
### Operators

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.op_ImplicitAttackModel(BTD_Mod_Helper.Api.Helpers.AttackHelper)'></a>

## AttackHelper.implicit operator AttackModel(AttackHelper) Operator

Unwraps the model

```csharp
public static AttackModel implicit operator AttackModel(BTD_Mod_Helper.Api.Helpers.AttackHelper helper);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.op_ImplicitAttackModel(BTD_Mod_Helper.Api.Helpers.AttackHelper).helper'></a>

`helper` [AttackHelper](BTD_Mod_Helper.Api.Helpers.AttackHelper.md 'BTD_Mod_Helper.Api.Helpers.AttackHelper')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.AttackHelper(AttackModel)'></a>

## AttackHelper.implicit operator AttackHelper(AttackModel) Operator

Wraps a model

```csharp
public static BTD_Mod_Helper.Api.Helpers.AttackHelper implicit operator AttackHelper(AttackModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.AttackHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.AttackHelper(AttackModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.AttackModel')

#### Returns
[AttackHelper](BTD_Mod_Helper.Api.Helpers.AttackHelper.md 'BTD_Mod_Helper.Api.Helpers.AttackHelper')