#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## WeaponHelper Class

A wrapper around WeaponModels for making them easier to create

```csharp
public class WeaponHelper : BTD_Mod_Helper.Api.Helpers.ModelHelper<WeaponModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModelHelper](BTD_Mod_Helper.Api.Helpers.ModelHelper.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper') &#129106; [BTD_Mod_Helper.Api.Helpers.ModelHelper&lt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>')[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')[&gt;](BTD_Mod_Helper.Api.Helpers.ModelHelper_T_.md 'BTD_Mod_Helper.Api.Helpers.ModelHelper<T>') &#129106; WeaponHelper
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.WeaponHelper(string)'></a>

## WeaponHelper(string) Constructor

Begins construction of a new WeaponModel with sensible default values

```csharp
public WeaponHelper(string name="");
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.WeaponHelper(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The model name (don't need the WeaponModel_ part)
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.AnimateOnMainAttack'></a>

## WeaponHelper.AnimateOnMainAttack Property

```csharp
public bool AnimateOnMainAttack { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animateOnMainAttack](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animateOnMainAttack 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animateOnMainAttack')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Animation'></a>

## WeaponHelper.Animation Property

```csharp
public int Animation { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animation 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animation')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.AnimationOffset'></a>

## WeaponHelper.AnimationOffset Property

```csharp
public float AnimationOffset { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animationOffset](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animationOffset 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.animationOffset')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Behaviors'></a>

## WeaponHelper.Behaviors Property

```csharp
public WeaponBehaviorModel[] Behaviors { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponBehaviorModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponBehaviorModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponBehaviorModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.behaviors](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.behaviors 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.behaviors')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.CustomStartCooldown'></a>

## WeaponHelper.CustomStartCooldown Property

```csharp
public float CustomStartCooldown { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.customStartCooldown](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.customStartCooldown 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.customStartCooldown')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Eject'></a>

## WeaponHelper.Eject Property

```csharp
public Vector3 Eject { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectX](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectX 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectX')
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectY](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectY 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectY')
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectZ](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectZ 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.ejectZ')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Emission'></a>

## WeaponHelper.Emission Property

```csharp
public EmissionModel Emission { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.EmissionModel')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.emission](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.emission 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.emission')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.FireBetweenRounds'></a>

## WeaponHelper.FireBetweenRounds Property

```csharp
public bool FireBetweenRounds { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireBetweenRounds](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireBetweenRounds 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireBetweenRounds')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.FireWithoutTarget'></a>

## WeaponHelper.FireWithoutTarget Property

```csharp
public bool FireWithoutTarget { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireWithoutTarget](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireWithoutTarget 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.fireWithoutTarget')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Projectile'></a>

## WeaponHelper.Projectile Property

```csharp
public ProjectileModel Projectile { get; set; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.ProjectileModel')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.projectile](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.projectile 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.projectile')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.Rate'></a>

## WeaponHelper.Rate Property

```csharp
public float Rate { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.Rate](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.Rate 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.Rate')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.StartInCooldown'></a>

## WeaponHelper.StartInCooldown Property

```csharp
public bool StartInCooldown { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.startInCooldown](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.startInCooldown 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.startInCooldown')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.UseAttackPosition'></a>

## WeaponHelper.UseAttackPosition Property

```csharp
public bool UseAttackPosition { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

### See Also
- [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.useAttackPosition](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.useAttackPosition 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel.useAttackPosition')
### Operators

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.WeaponHelper(WeaponModel)'></a>

## WeaponHelper.implicit operator WeaponHelper(WeaponModel) Operator

Wraps a model

```csharp
public static BTD_Mod_Helper.Api.Helpers.WeaponHelper implicit operator WeaponHelper(WeaponModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.op_ImplicitBTD_Mod_Helper.Api.Helpers.WeaponHelper(WeaponModel).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')

#### Returns
[WeaponHelper](BTD_Mod_Helper.Api.Helpers.WeaponHelper.md 'BTD_Mod_Helper.Api.Helpers.WeaponHelper')

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.op_ImplicitWeaponModel(BTD_Mod_Helper.Api.Helpers.WeaponHelper)'></a>

## WeaponHelper.implicit operator WeaponModel(WeaponHelper) Operator

Unwraps the model

```csharp
public static WeaponModel implicit operator WeaponModel(BTD_Mod_Helper.Api.Helpers.WeaponHelper helper);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.WeaponHelper.op_ImplicitWeaponModel(BTD_Mod_Helper.Api.Helpers.WeaponHelper).helper'></a>

`helper` [WeaponHelper](BTD_Mod_Helper.Api.Helpers.WeaponHelper.md 'BTD_Mod_Helper.Api.Helpers.WeaponHelper')

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel 'Il2CppAssets.Scripts.Models.Towers.Weapons.WeaponModel')