#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## MapHelper Class

Contains helper methods for working with maps and custom maps.

```csharp
public class MapHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MapHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Models.Map.PointInfo_)'></a>

## MapHelper.CreatePathModel(string, List<PointInfo>) Method

Creates a default PathModel out of list of PointInfos

```csharp
public static Assets.Scripts.Models.Map.PathModel CreatePathModel(string pathName, System.Collections.Generic.List<Assets.Scripts.Models.Map.PointInfo> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Models.Map.PointInfo_).pathName'></a>

`pathName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Models.Map.PointInfo_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PathModel 'Assets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_)'></a>

## MapHelper.CreatePathModel(string, List<Vector2>) Method

Creates a default PathModel out of list of Vector2 points

```csharp
public static Assets.Scripts.Models.Map.PathModel CreatePathModel(string pathName, System.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_).pathName'></a>

`pathName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Assets.Scripts.Simulation.SMath.Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.SMath.Vector2 'Assets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PathModel 'Assets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector2)'></a>

## MapHelper.CreatePointInfo(Vector2) Method

Create a [Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo') out of a Vector2.

```csharp
public static Assets.Scripts.Models.Map.PointInfo CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector2 point);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector2).point'></a>

`point` [Assets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.SMath.Vector2 'Assets.Scripts.Simulation.SMath.Vector2')

#### Returns
[Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector3)'></a>

## MapHelper.CreatePointInfo(Vector3) Method

Create a [Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo') out of a Vector3.

```csharp
public static Assets.Scripts.Models.Map.PointInfo CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector3 point);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Assets.Scripts.Simulation.SMath.Vector3).point'></a>

`point` [Assets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.SMath.Vector3 'Assets.Scripts.Simulation.SMath.Vector3')

#### Returns
[Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float)'></a>

## MapHelper.CreatePointInfo(float, float) Method

Create a [Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo') out of an X and Y coord.

```csharp
public static Assets.Scripts.Models.Map.PointInfo CreatePointInfo(float x, float y);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float)'></a>

## MapHelper.CreatePointInfo(float, float, float) Method

Create a [Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo') out of X, Y, Z coords.

```csharp
public static Assets.Scripts.Models.Map.PointInfo CreatePointInfo(float x, float y, float z);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).z'></a>

`z` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Assets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PointInfo 'Assets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreateSpawner(Assets.Scripts.Models.Map.PathModel[])'></a>

## MapHelper.CreateSpawner(PathModel[]) Method

Create a SpawnerModel based off of an array of paths

```csharp
public static Assets.Scripts.Models.Map.Spawners.PathSpawnerModel CreateSpawner(Assets.Scripts.Models.Map.PathModel[] paths);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreateSpawner(Assets.Scripts.Models.Map.PathModel[]).paths'></a>

`paths` [Assets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.PathModel 'Assets.Scripts.Models.Map.PathModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Assets.Scripts.Models.Map.Spawners.PathSpawnerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Map.Spawners.PathSpawnerModel 'Assets.Scripts.Models.Map.Spawners.PathSpawnerModel')