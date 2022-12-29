#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## BloonModelUtils Class

Provides Utility methods for dealing with BloonModels

```csharp
public class BloonModelUtils
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonModelUtils
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.ConstructBloonId(string,bool,bool,bool)'></a>

## BloonModelUtils.ConstructBloonId(string, bool, bool, bool) Method

Constructs an accurate BloonID for a BloonModel based off of it's statuses.

```csharp
public static string ConstructBloonId(string bloonName, bool camo, bool regrow, bool fortified);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.ConstructBloonId(string,bool,bool,bool).bloonName'></a>

`bloonName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.ConstructBloonId(string,bool,bool,bool).camo'></a>

`camo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.ConstructBloonId(string,bool,bool,bool).regrow'></a>

`regrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.ConstructBloonId(string,bool,bool,bool).fortified'></a>

`fortified` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.CreateGrowModel(string,float)'></a>

## BloonModelUtils.CreateGrowModel(string, float) Method

Creates a GrowModel behavior that adds Regrowth.

```csharp
public static GrowModel CreateGrowModel(string regrowsTo, float regrowRate);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.CreateGrowModel(string,float).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.BloonModelUtils.CreateGrowModel(string,float).regrowRate'></a>

`regrowRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel')