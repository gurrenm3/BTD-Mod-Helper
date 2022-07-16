#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModParagonUpgrade Class

Defines the Paragon Upgrade for a ModTower. Remember to set the [ParagonMode](BTD_Mod_Helper.Api.Towers.ModTower.md#BTD_Mod_Helper.Api.Towers.ModTower.ParagonMode 'BTD_Mod_Helper.Api.Towers.ModTower.ParagonMode') property.

```csharp
public abstract class ModParagonUpgrade : BTD_Mod_Helper.Api.Towers.ModUpgrade
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') &#129106; ModParagonUpgrade

Derived  
&#8627; [ModParagonUpgrade&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModParagonUpgrade_T_.md 'BTD_Mod_Helper.Api.Towers.ModParagonUpgrade<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.Name'></a>

## ModParagonUpgrade.Name Property

Specifically use the paragon upgrade naming scheme. No overriding because that apparently causes issues.

```csharp
public sealed override string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.ParagonTowerModel'></a>

## ModParagonUpgrade.ParagonTowerModel Property

The ParagonTowerModel that this will use as a base. You don't need to worry about displayDegreePaths

```csharp
public virtual Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel ParagonTowerModel { get; }
```

#### Property Value
[Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel 'Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.Path'></a>

## ModParagonUpgrade.Path Property

No changing of ModParagonUpgrade path

```csharp
public sealed override int Path { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.RemoveAbilities'></a>

## ModParagonUpgrade.RemoveAbilities Property

By default, remove any abilities from the Paragon tower

```csharp
public virtual bool RemoveAbilities { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.Tier'></a>

## ModParagonUpgrade.Tier Property

No changing of ModParagonUpgrade tier

```csharp
public sealed override int Tier { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.GetUpgradeModel()'></a>

## ModParagonUpgrade.GetUpgradeModel() Method

If you really need to override the way that the ModUpgrade makes its UpgradeModel, go ahead

```csharp
public override Assets.Scripts.Models.Towers.Upgrades.UpgradeModel GetUpgradeModel();
```

#### Returns
[Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.Load()'></a>

## ModParagonUpgrade.Load() Method

No loading of multiple ModParagonUpgrades

```csharp
public sealed override System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.ModifyPowerDegreeMutator(Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator,float,int)'></a>

## ModParagonUpgrade.ModifyPowerDegreeMutator(PowerDegreeMutator, float, int) Method

Modify the PowerDegreeMutator of the Paragon

```csharp
public virtual void ModifyPowerDegreeMutator(Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator powerDegreeMutator, float investment, int degree);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.ModifyPowerDegreeMutator(Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator,float,int).powerDegreeMutator'></a>

`powerDegreeMutator` [Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator 'Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.ModifyPowerDegreeMutator(Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator,float,int).investment'></a>

`investment` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.ModifyPowerDegreeMutator(Assets.Scripts.Models.Towers.Behaviors.ParagonTowerModel.PowerDegreeMutator,float,int).degree'></a>

`degree` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.OnDegreeSet(Assets.Scripts.Simulation.Towers.Tower,int)'></a>

## ModParagonUpgrade.OnDegreeSet(Tower, int) Method

Method to modify the Simulation Tower once its Degree has been set

```csharp
public virtual void OnDegreeSet(Assets.Scripts.Simulation.Towers.Tower tower, int degree);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.OnDegreeSet(Assets.Scripts.Simulation.Towers.Tower,int).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.OnDegreeSet(Assets.Scripts.Simulation.Towers.Tower,int).degree'></a>

`degree` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')