#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModVanillaContent Class

Class for changing Vanilla content within the game

```csharp
public abstract class ModVanillaContent : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModVanillaContent

Derived  
&#8627; [ModVanillaContent&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModVanillaContent_T_.md 'BTD_Mod_Helper.Api.Towers.ModVanillaContent<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.AffectBaseGameModel'></a>

## ModVanillaContent.AffectBaseGameModel Property

Whether this should only modify the Towers In-Game, or also affect the default GameModel outside a game

```csharp
public virtual bool AffectBaseGameModel { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.Description'></a>

## ModVanillaContent.Description Property

Change the description of it

```csharp
public virtual string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.DisplayName'></a>

## ModVanillaContent.DisplayName Property

Change the name of it

```csharp
public virtual string DisplayName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.Name'></a>

## ModVanillaContent.Name Property

The name that will be at the end of the ID for this ModContent, by default the class name

```csharp
public sealed override string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.ShouldApply'></a>

## ModVanillaContent.ShouldApply Property

Whether this should apply or not. Useful for ModSettings

```csharp
public virtual bool ShouldApply { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.GetAffectedModels(GameModel)'></a>

## ModVanillaContent.GetAffectedModels(GameModel) Method

Gets the TowerModels that this will affect in the GameModel

```csharp
public abstract System.Collections.Generic.IEnumerable<Model> GetAffectedModels(GameModel gameModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModVanillaContent.GetAffectedModels(GameModel).gameModel'></a>

`gameModel` [Il2CppAssets.Scripts.Models.GameModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GameModel 'Il2CppAssets.Scripts.Models.GameModel')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Il2CppAssets.Scripts.Models.Model](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Model 'Il2CppAssets.Scripts.Models.Model')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')