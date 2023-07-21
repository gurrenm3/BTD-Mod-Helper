#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## MiscModelExt Class

Other miscellaneous extensions for various Model classes

```csharp
public static class MiscModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MiscModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisAssetPathModel)'></a>

## MiscModelExt.ApplyDisplay<T>(this AssetPathModel) Method

Applies the given ModDisplay to this asset path

```csharp
public static void ApplyDisplay<T>(this AssetPathModel effectModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisAssetPathModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisAssetPathModel).effectModel'></a>

`effectModel` [Il2CppAssets.Scripts.Models.Effects.AssetPathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Effects.AssetPathModel 'Il2CppAssets.Scripts.Models.Effects.AssetPathModel')

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisEffectModel)'></a>

## MiscModelExt.ApplyDisplay<T>(this EffectModel) Method

Applies the given ModDisplay to this effect

```csharp
public static void ApplyDisplay<T>(this EffectModel effectModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisEffectModel).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.ApplyDisplay_T_(thisEffectModel).effectModel'></a>

`effectModel` [Il2CppAssets.Scripts.Models.Effects.EffectModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Effects.EffectModel 'Il2CppAssets.Scripts.Models.Effects.EffectModel')

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.GetDamageMult(thisDamageModifierModel,Bloon)'></a>

## MiscModelExt.GetDamageMult(this DamageModifierModel, Bloon) Method

Gets the damageMultiplier field for a DamageModifierModel

```csharp
public static float GetDamageMult(this DamageModifierModel model, Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.GetDamageMult(thisDamageModifierModel,Bloon).model'></a>

`model` [Il2CppAssets.Scripts.Models.Towers.Projectiles.DamageModifierModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Projectiles.DamageModifierModel 'Il2CppAssets.Scripts.Models.Towers.Projectiles.DamageModifierModel')

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.GetDamageMult(thisDamageModifierModel,Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.UpdateOffset(thisParallelEmissionModel)'></a>

## MiscModelExt.UpdateOffset(this ParallelEmissionModel) Method

Updates the [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.offsetStart](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.offsetStart 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.offsetStart') to be consistent with the  
[Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.count](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.count 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.count') and [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.spreadLength](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.spreadLength 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel.spreadLength')

```csharp
public static void UpdateOffset(this ParallelEmissionModel parallelEmissionModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.MiscModelExt.UpdateOffset(thisParallelEmissionModel).parallelEmissionModel'></a>

`parallelEmissionModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.ParallelEmissionModel')