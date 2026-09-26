#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## MapHelper Class

Contains helper methods for working with maps and custom maps.

```csharp
public class MapHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MapHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_PointInfo_)'></a>

## MapHelper.CreatePathModel(string, List<PointInfo>) Method

Creates a default PathModel out of list of PointInfos

```csharp
public static PathModel CreatePathModel(string pathName, System.Collections.Generic.List<PointInfo> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_PointInfo_).pathName'></a>

`pathName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_PointInfo_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PathModel 'Il2CppAssets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Vector2_)'></a>

## MapHelper.CreatePathModel(string, List<Vector2>) Method

Creates a default PathModel out of list of Vector2 points

```csharp
public static PathModel CreatePathModel(string pathName, System.Collections.Generic.List<Vector2> points);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Vector2_).pathName'></a>

`pathName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePathModel(string,System.Collections.Generic.List_Vector2_).points'></a>

`points` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector2 'Il2CppAssets.Scripts.Simulation.SMath.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PathModel 'Il2CppAssets.Scripts.Models.Map.PathModel')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float)'></a>

## MapHelper.CreatePointInfo(float, float, float) Method

Create a [Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo') out of X, Y, Z coords.

```csharp
public static PointInfo CreatePointInfo(float x, float y, float z);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float,float).z'></a>

`z` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float)'></a>

## MapHelper.CreatePointInfo(float, float) Method

Create a [Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo') out of an X and Y coord.

```csharp
public static PointInfo CreatePointInfo(float x, float y);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float).x'></a>

`x` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(float,float).y'></a>

`y` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Vector2)'></a>

## MapHelper.CreatePointInfo(Vector2) Method

Create a [Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo') out of a Vector2.

```csharp
public static PointInfo CreatePointInfo(Vector2 point);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Vector2).point'></a>

`point` [Il2CppAssets.Scripts.Simulation.SMath.Vector2](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector2 'Il2CppAssets.Scripts.Simulation.SMath.Vector2')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Vector3)'></a>

## MapHelper.CreatePointInfo(Vector3) Method

Create a [Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo') out of a Vector3.

```csharp
public static PointInfo CreatePointInfo(Vector3 point);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreatePointInfo(Vector3).point'></a>

`point` [Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

#### Returns
[Il2CppAssets.Scripts.Models.Map.PointInfo](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PointInfo 'Il2CppAssets.Scripts.Models.Map.PointInfo')

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreateSpawner(PathModel[])'></a>

## MapHelper.CreateSpawner(PathModel[]) Method

Create a SpawnerModel based off of an array of paths

```csharp
public static PathSpawnerModel CreateSpawner(PathModel[] paths);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.MapHelper.CreateSpawner(PathModel[]).paths'></a>

`paths` [Il2CppAssets.Scripts.Models.Map.PathModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.PathModel 'Il2CppAssets.Scripts.Models.Map.PathModel')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Il2CppAssets.Scripts.Models.Map.Spawners.PathSpawnerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Map.Spawners.PathSpawnerModel 'Il2CppAssets.Scripts.Models.Map.Spawners.PathSpawnerModel')