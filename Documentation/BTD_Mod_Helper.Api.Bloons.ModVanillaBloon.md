#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModVanillaBloon Class

Allows you to easily modify the models of a specific vanilla Bloon

```csharp
public abstract class ModVanillaBloon : BTD_Mod_Helper.Api.Towers.ModVanillaContent<BloonModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; ModVanillaBloon
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

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.GetAffected(GameModel)'></a>

## ModVanillaBloon.GetAffected(GameModel) Method

Gets the BloonModels affected by this ModVanillaBloon

```csharp
public override System.Collections.Generic.IEnumerable<BloonModel> GetAffected(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloon.GetAffected(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')