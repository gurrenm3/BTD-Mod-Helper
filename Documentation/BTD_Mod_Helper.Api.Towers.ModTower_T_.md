#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTower<T> Class

A convenient generic class for specifying the ModTowerSet that a ModTower uses

```csharp
public abstract class ModTower<T> : BTD_Mod_Helper.Api.Towers.ModTower
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTower_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; ModTower<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTower_T_.TowerSet'></a>

## ModTower<T>.TowerSet Property

The custom tower set that this ModTower uses

```csharp
public sealed override Assets.Scripts.Models.TowerSets.TowerSet TowerSet { get; }
```

#### Property Value
[Assets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerSet 'Assets.Scripts.Models.TowerSets.TowerSet')