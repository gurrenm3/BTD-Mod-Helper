#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaTower<T> Class

Helper class for changing a vanilla tower to be part of a modded tower set

```csharp
public abstract class ModVanillaTower<T> : BTD_Mod_Helper.Api.Towers.ModVanillaTower
    where T : BTD_Mod_Helper.Api.Towers.ModTowerSet
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; [ModVanillaTower](BTD_Mod_Helper.Api.Towers.ModVanillaTower.md 'BTD_Mod_Helper.Api.Towers.ModVanillaTower') &#129106; ModVanillaTower<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower_T_.TowerSet'></a>

## ModVanillaTower<T>.TowerSet Property

Change the TowerSet that this tower is part of. Also handles moving its place within the shop.

```csharp
public sealed override string TowerSet { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')