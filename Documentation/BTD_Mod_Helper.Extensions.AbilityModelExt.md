#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## AbilityModelExt Class

Extensions for AbilityModels

```csharp
public static class AbilityModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AbilityModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.EffectiveCooldown(thisAbilityModel)'></a>

## AbilityModelExt.EffectiveCooldown(this AbilityModel) Method

Gets the effective cooldown of this ability factoring in its [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale')

```csharp
public static float EffectiveCooldown(this AbilityModel abiltyModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.EffectiveCooldown(thisAbilityModel).abiltyModel'></a>

`abiltyModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.EffectiveCooldownFrames(thisAbilityModel)'></a>

## AbilityModelExt.EffectiveCooldownFrames(this AbilityModel) Method

Gets the effective cooldown of this ability factoring in its [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel.CooldownSpeedScale')

```csharp
public static int EffectiveCooldownFrames(this AbilityModel abiltyModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.EffectiveCooldownFrames(thisAbilityModel).abiltyModel'></a>

`abiltyModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.GetAbilitySims(thisAbilityModel)'></a>

## AbilityModelExt.GetAbilitySims(this AbilityModel) Method

Get the all AbilityToSimulation with this AbilityModel

```csharp
public static System.Collections.Generic.List<AbilityToSimulation> GetAbilitySims(this AbilityModel abiltyModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.AbilityModelExt.GetAbilitySims(thisAbilityModel).abiltyModel'></a>

`abiltyModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.AbilityModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.AbilityToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')