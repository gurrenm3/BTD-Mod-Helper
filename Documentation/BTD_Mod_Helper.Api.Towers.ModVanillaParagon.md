#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaParagon Class

Dummy ModTower that can be used to make a Paragon for a base tower.

```csharp
public abstract class ModVanillaParagon : BTD_Mod_Helper.Api.Towers.ModTower
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; ModVanillaParagon
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.BottomPathUpgrades'></a>

## ModVanillaParagon.BottomPathUpgrades Property

No upgrades for the paragon

```csharp
public sealed override int BottomPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Cost'></a>

## ModVanillaParagon.Cost Property

Handled by upgrade cost

```csharp
public sealed override int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Description'></a>

## ModVanillaParagon.Description Property

Controlled by the ModParagonUpgrade

```csharp
public override string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.DontAddToShop'></a>

## ModVanillaParagon.DontAddToShop Property

No paragons in shop

```csharp
public sealed override bool DontAddToShop { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Icon'></a>

## ModVanillaParagon.Icon Property

Controlled by the ModParagonUpgrade

```csharp
public sealed override string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.IconReference'></a>

## ModVanillaParagon.IconReference Property

Controlled by the ModParagonUpgrade

```csharp
public sealed override Il2CppAssets.Scripts.Utils.SpriteReference IconReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.MiddlePathUpgrades'></a>

## ModVanillaParagon.MiddlePathUpgrades Property

No upgrades for the paragon

```csharp
public sealed override int MiddlePathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Name'></a>

## ModVanillaParagon.Name Property

Name override

```csharp
public override string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Order'></a>

## ModVanillaParagon.Order Property

Order doesn't apply here

```csharp
protected sealed override int Order { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.ParagonMode'></a>

## ModVanillaParagon.ParagonMode Property

Not using the custom tower paragon mode

```csharp
public sealed override BTD_Mod_Helper.Api.Towers.ParagonMode ParagonMode { get; }
```

#### Property Value
[ParagonMode](BTD_Mod_Helper.Api.Towers.ParagonMode.md 'BTD_Mod_Helper.Api.Towers.ParagonMode')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.Portrait'></a>

## ModVanillaParagon.Portrait Property

Controlled by the ModParagonUpgrade

```csharp
public sealed override string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.PortraitReference'></a>

## ModVanillaParagon.PortraitReference Property

Controlled by the ModParagonUpgrade

```csharp
public sealed override Il2CppAssets.Scripts.Utils.SpriteReference PortraitReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.TopPathUpgrades'></a>

## ModVanillaParagon.TopPathUpgrades Property

No upgrades for the paragon

```csharp
public sealed override int TopPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.TowerSet'></a>

## ModVanillaParagon.TowerSet Property

Same towerSet as base tower

```csharp
public sealed override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.GetTowerIndex(System.Collections.Generic.List_Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel_)'></a>

## ModVanillaParagon.GetTowerIndex(List<TowerDetailsModel>) Method

Tower index doesn't apply

```csharp
public sealed override int GetTowerIndex(System.Collections.Generic.List<Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel> towerSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.GetTowerIndex(System.Collections.Generic.List_Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel_).towerSet'></a>

`towerSet` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.ModifyBaseTowerModel(Il2CppAssets.Scripts.Models.Towers.TowerModel)'></a>

## ModVanillaParagon.ModifyBaseTowerModel(TowerModel) Method

Tower gets modified in the Paragon upgrade

```csharp
public sealed override void ModifyBaseTowerModel(Il2CppAssets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.ModifyBaseTowerModel(Il2CppAssets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaParagon.TowerTiers()'></a>

## ModVanillaParagon.TowerTiers() Method

Doesn't generate any of the tower on its own

```csharp
public sealed override System.Collections.Generic.IEnumerable<int[]> TowerTiers();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')