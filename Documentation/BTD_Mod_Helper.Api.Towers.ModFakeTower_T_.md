#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModFakeTower<T> Class

Defines a "fake" tower that will be added as an entry to the shop but instead of placing down as normal, will just show its  
icon being placed with custom conditions and an action upon placement

```csharp
public abstract class ModFakeTower<T> : BTD_Mod_Helper.Api.Towers.ModFakeTower
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; [ModFakeTower](BTD_Mod_Helper.Api.Towers.ModFakeTower.md 'BTD_Mod_Helper.Api.Towers.ModFakeTower') &#129106; ModFakeTower<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower_T_.ModTowerSet'></a>

## ModFakeTower<T>.ModTowerSet Property

The ModTowerSet that this belongs to, if any

```csharp
public sealed override BTD_Mod_Helper.Api.Towers.ModTowerSet ModTowerSet { get; }
```

#### Property Value
[ModTowerSet](BTD_Mod_Helper.Api.Towers.ModTowerSet.md 'BTD_Mod_Helper.Api.Towers.ModTowerSet')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower_T_.TowerSet'></a>

## ModFakeTower<T>.TowerSet Property

The family of Monkeys that your Tower should be put in.  
<br/>  
For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.

```csharp
public sealed override TowerSet TowerSet { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')