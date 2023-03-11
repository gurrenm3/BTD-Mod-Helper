#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Scenarios](README.md#BTD_Mod_Helper.Api.Scenarios 'BTD_Mod_Helper.Api.Scenarios')

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
public virtual CoopDivision CoopDivision { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Data.MapSets.CoopDivision](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.MapSets.CoopDivision 'Il2CppAssets.Scripts.Data.MapSets.CoopDivision')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.Difficulty'></a>

## ModMap.Difficulty Property

The difficulty of this map.

```csharp
public abstract MapDifficulty Difficulty { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Data.MapSets.MapDifficulty](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.MapSets.MapDifficulty 'Il2CppAssets.Scripts.Data.MapSets.MapDifficulty')

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

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(AreaType,System.Collections.Generic.List_Vector2_)'></a>

## ModMap.AddAreaModel(AreaType, List<Vector2>) Method

Add an area model to this path.

```csharp
protected AreaModel AddAreaModel(AreaType type, System.Collections.Generic.List<Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(AreaType,System.Collections.Generic.List_Vector2_).type'></a>

`type` [Il2CppAssets.Scripts.Models.Map.AreaType](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.AreaType 'Il2CppAssets.Scripts.Models.Map.AreaType')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddAreaModel(AreaType,System.Collections.Generic.List_Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector2 'Il2CppAssets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Models.Map.AreaModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.AreaModel 'Il2CppAssets.Scripts.Models.Map.AreaModel')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddPath(System.Collections.Generic.List_Vector2_)'></a>

## ModMap.AddPath(List<Vector2>) Method

Use this to add a path to your map.

```csharp
protected PathModel AddPath(System.Collections.Generic.List<Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.AddPath(System.Collections.Generic.List_Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector2 'Il2CppAssets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PathModel 'Il2CppAssets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetMapDetails()'></a>

## ModMap.GetMapDetails() Method

Get's the map details for this map. Override this method if you want extra customization.

```csharp
protected virtual MapDetails GetMapDetails();
```

#### Returns
[Il2CppAssets.Scripts.Data.MapSets.MapDetails](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.MapSets.MapDetails 'Il2CppAssets.Scripts.Data.MapSets.MapDetails')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetSpriteReference()'></a>

## ModMap.GetSpriteReference() Method

Returns the sprite reference of this map.

```csharp
public virtual SpriteReference GetSpriteReference();
```

#### Returns
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.GetTexture()'></a>

## ModMap.GetTexture() Method

Returns the texture of this map. The first time it's loaded it will automatically resize to fit the game.

```csharp
public virtual Texture2D GetTexture();
```

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

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

<a name='BTD_Mod_Helper.Api.Scenarios.ModMap.Register()'></a>

## ModMap.Register() Method

<inheritdoc/>

```csharp
public sealed override void Register();
```