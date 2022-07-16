#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Scenarios](index.md#BTD_Mod_Helper.Api.Scenarios 'BTD_Mod_Helper.Api.Scenarios')

## ModMap Class

Class for creating custom Maps easier.

```csharp
public abstract class ModMap : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModMap
### Properties

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AutoUnlockMap'></a>

## ModMap.AutoUnlockMap Property

Set to true if you want this map to be unlocked by default.

```csharp
protected virtual bool AutoUnlockMap { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.CoopDivision'></a>

## ModMap.CoopDivision Property

```csharp
public virtual Assets.Scripts.Data.MapSets.CoopDivision CoopDivision { get; }
```

#### Property Value
[Assets.Scripts.Data.MapSets.CoopDivision](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Data.MapSets.CoopDivision 'Assets.Scripts.Data.MapSets.CoopDivision')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.Difficulty'></a>

## ModMap.Difficulty Property

The difficulty of this map.

```csharp
public abstract Assets.Scripts.Data.MapSets.MapDifficulty Difficulty { get; }
```

#### Property Value
[Assets.Scripts.Data.MapSets.MapDifficulty](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Data.MapSets.MapDifficulty 'Assets.Scripts.Data.MapSets.MapDifficulty')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.EnableRain'></a>

## ModMap.EnableRain Property

Set to true if you want Rain enabled in this map.

```csharp
public bool EnableRain { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.MapImageName'></a>

## ModMap.MapImageName Property

The name of the Image file that would be the actual map. By default  
this will be set to be the same as [Name](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.Name 'BTD_Mod_Helper.Api.ModContent.Name'). Change this  
if your map has a different file name than the name of the map itself.  
<br/><br/>Example: Castle.png

```csharp
protected virtual string MapImageName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.MapMusic'></a>

## ModMap.MapMusic Property

```csharp
public virtual string MapMusic { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.MapWideBloonSpeed'></a>

## ModMap.MapWideBloonSpeed Property

The map-wide modifier for all Bloons' speed

```csharp
public virtual float MapWideBloonSpeed { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(Assets.Scripts.Models.Map.AreaType,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_)'></a>

## ModMap.AddAreaModel(AreaType, List<Vector2>) Method

Add an area model to this path.

```csharp
protected Assets.Scripts.Models.Map.AreaModel AddAreaModel(Assets.Scripts.Models.Map.AreaType type, System.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(Assets.Scripts.Models.Map.AreaType,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_).type'></a>

`type` [Assets.Scripts.Models.Map.AreaType](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.AreaType 'Assets.Scripts.Models.Map.AreaType')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(Assets.Scripts.Models.Map.AreaType,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.SMath.Vector2 'Assets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Models.Map.AreaModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.AreaModel 'Assets.Scripts.Models.Map.AreaModel')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddPath(System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_)'></a>

## ModMap.AddPath(List<Vector2>) Method

Use this to add a path to your map.

```csharp
protected Assets.Scripts.Models.Map.PathModel AddPath(System.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddPath(System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.SMath.Vector2 'Assets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PathModel 'Assets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetMapDetails()'></a>

## ModMap.GetMapDetails() Method

Get's the map details for this map. Override this method if you want extra customization.

```csharp
protected virtual Assets.Scripts.Data.MapSets.MapDetails GetMapDetails();
```

#### Returns
[Assets.Scripts.Data.MapSets.MapDetails](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Data.MapSets.MapDetails 'Assets.Scripts.Data.MapSets.MapDetails')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetSpriteReference()'></a>

## ModMap.GetSpriteReference() Method

Returns the sprite reference of this map.

```csharp
public virtual Assets.Scripts.Utils.SpriteReference GetSpriteReference();
```

#### Returns
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetTexture()'></a>

## ModMap.GetTexture() Method

Returns the texture of this map. The first time it's loaded it will automatically resize to fit the game.

```csharp
public virtual UnityEngine.Texture2D GetTexture();
```

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.IsCustomMap(string)'></a>

## ModMap.IsCustomMap(string) Method

Returns whether or not a map is a custom map, based off of it's name.

```csharp
public static bool IsCustomMap(string mapName);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.IsCustomMap(string).mapName'></a>

`mapName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.IsCustomMap(string,BTD_Mod_Helper.Api.Scenarios.ModMap)'></a>

## ModMap.IsCustomMap(string, ModMap) Method

Returns whether or not a map is a custom map, based off of it's name.

```csharp
public static bool IsCustomMap(string mapName, out BTD_Mod_Helper.Api.Scenarios.ModMap map);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.IsCustomMap(string,BTD_Mod_Helper.Api.Scenarios.ModMap).mapName'></a>

`mapName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.IsCustomMap(string,BTD_Mod_Helper.Api.Scenarios.ModMap).map'></a>

`map` [ModMap](BTD_Mod_Helper.Api.Scenarios.ModMap.md 'BTD_Mod_Helper.Api.Scenarios.ModMap')

The custom map, if found

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.Register()'></a>

## ModMap.Register() Method

<inheritdoc/>

```csharp
public sealed override void Register();
```