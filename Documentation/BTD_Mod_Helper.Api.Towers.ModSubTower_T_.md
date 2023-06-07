#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModSubTower<T> Class

Helper class for making a subtower for a specific other ModTower

```csharp
public abstract class ModSubTower<T> : BTD_Mod_Helper.Api.Towers.ModSubTower
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; [ModSubTower](BTD_Mod_Helper.Api.Towers.ModSubTower.md 'BTD_Mod_Helper.Api.Towers.ModSubTower') &#129106; ModSubTower<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower_T_.Order'></a>

## ModSubTower<T>.Order Property

The order that this ModContent will be loaded/registered in by Mod Helper.  
Useful for changing the ordering that it will appear in in-game relative to other content of this type in your mod,  
or for making certain content load before others like may be necessary for sub-towers.  
Default/0 will use arbitrary ordering.

```csharp
protected override int Order { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower_T_.TowerSet'></a>

## ModSubTower<T>.TowerSet Property

The family of Monkeys that your Tower should be put in.  
<br/>  
For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.

```csharp
public override TowerSet TowerSet { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')