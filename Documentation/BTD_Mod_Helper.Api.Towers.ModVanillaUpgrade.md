#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaUpgrade Class

ModContent class for modifying all TowerModels that have a given upgrade applied to them

```csharp
public abstract class ModVanillaUpgrade : BTD_Mod_Helper.Api.Towers.ModVanillaContent<Assets.Scripts.Models.Towers.TowerModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; ModVanillaUpgrade
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.Cost'></a>

## ModVanillaUpgrade.Cost Property

Changes the base cost

```csharp
public virtual int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.UpgradeId'></a>

## ModVanillaUpgrade.UpgradeId Property

The id of the Upgrade that this should modify all TowerModels that use  
<br/>  
Use UpgradeType.[upgrade]

```csharp
public abstract string UpgradeId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.Apply(Assets.Scripts.Models.Towers.Upgrades.UpgradeModel)'></a>

## ModVanillaUpgrade.Apply(UpgradeModel) Method

Change the UpgradeModel for this upgrade

```csharp
public virtual void Apply(Assets.Scripts.Models.Towers.Upgrades.UpgradeModel upgradeModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.Apply(Assets.Scripts.Models.Towers.Upgrades.UpgradeModel).upgradeModel'></a>

`upgradeModel` [Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.GetAffected(Assets.Scripts.Models.GameModel)'></a>

## ModVanillaUpgrade.GetAffected(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public override System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Towers.TowerModel> GetAffected(Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.GetAffected(Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaUpgrade.Register()'></a>

## ModVanillaUpgrade.Register() Method

(Cross-Game compatible) Registers this ModContent into the game

```csharp
public override void Register();
```