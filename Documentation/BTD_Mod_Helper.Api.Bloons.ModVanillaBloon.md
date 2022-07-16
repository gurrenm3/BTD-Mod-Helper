#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Bloons](index.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModVanillaBloon Class

```csharp
public abstract class ModVanillaBloon : BTD_Mod_Helper.Api.Towers.ModVanillaContent<Assets.Scripts.Models.Bloons.BloonModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; ModVanillaBloon
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.BloonId'></a>

## ModVanillaBloon.BloonId Property

The id of the vanilla Bloon to change

```csharp
public abstract string BloonId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.MatchBaseId'></a>

## ModVanillaBloon.MatchBaseId Property

Whether this should match by BaseId instead of Id.  
<br/>  
If true, RedCamo would be affected as well if your [BloonId](BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.md#BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.BloonId 'BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.BloonId') was Red

```csharp
public virtual bool MatchBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.GetAffected(Assets.Scripts.Models.GameModel)'></a>

## ModVanillaBloon.GetAffected(GameModel) Method

Gets the BloonModels affected by this ModVanillaBloon

```csharp
public override System.Collections.Generic.IEnumerable<Assets.Scripts.Models.Bloons.BloonModel> GetAffected(Assets.Scripts.Models.GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.GetAffected(Assets.Scripts.Models.GameModel).gameModel'></a>

`gameModel` [Assets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.GameModel 'Assets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')