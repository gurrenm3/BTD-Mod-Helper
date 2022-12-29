#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModVanillaBloons Class

Allows you to easily modify the models of multiple vanilla Bloons

```csharp
public abstract class ModVanillaBloons : BTD_Mod_Helper.Api.Towers.ModVanillaContent<BloonModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModVanillaContent](BTD_Mod_Helper.Api.Towers.ModVanillaContent.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent') &#129106; [BTD_Mod_Helper.Api.Towers.ModVanillaContent&lt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')[&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>') &#129106; ModVanillaBloons
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.BloonIds'></a>

## ModVanillaBloons.BloonIds Property

The ids of the vanilla Bloon to change

```csharp
public abstract System.Collections.Generic.IEnumerable<string> BloonIds { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.MatchBaseId'></a>

## ModVanillaBloons.MatchBaseId Property

Whether this should match by BaseId instead of Id.  
<br/>  
If true, RedCamo would be affected as well if your [BloonIds](BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.md#BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.BloonIds 'BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.BloonIds') was Red

```csharp
public virtual bool MatchBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.GetAffected(GameModel)'></a>

## ModVanillaBloons.GetAffected(GameModel) Method

Gets the BloonModels affected by this ModVanillaBloons

```csharp
public override System.Collections.Generic.IEnumerable<BloonModel> GetAffected(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModVanillaBloons.GetAffected(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')