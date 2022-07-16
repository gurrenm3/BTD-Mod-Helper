#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaTower Class

ModContent class for modifying all TowerModels for a given Tower

```csharp
public abstract class ModVanillaTower : BTD_Mod_Helper.Api.Towers.ModVanillaContent<Assets.Scripts.Models.Towers.TowerModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; ModVanillaTower

Derived  
&#8627; [ModVanillaTower&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaTower_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaTower<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.Cost'></a>

## ModVanillaTower.Cost Property

Changes the base cost

```csharp
public virtual int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.DisplayNamePlural'></a>

## ModVanillaTower.DisplayNamePlural Property

Change the name of it when it's plural

```csharp
public virtual string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.TowerId'></a>

## ModVanillaTower.TowerId Property

The base id of the Tower that this should modify all TowerModels of  
<br/>  
Use TowerType.[tower]

```csharp
public abstract string TowerId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.TowerSet'></a>

## ModVanillaTower.TowerSet Property

Change the TowerSet that this tower is part of. Also handles moving its place within the shop.

```csharp
public virtual string TowerSet { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.GetAffected(Assets.Scripts.Models.GameModel)'></a>

## ModVanillaTower.GetAffected(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public override System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Towers.TowerModel> GetAffected(Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.GetAffected(Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaTower.Register()'></a>

## ModVanillaTower.Register() Method

(Cross-Game compatible) Registers this ModContent into the game

```csharp
public override void Register();
```