#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GrowModelExt Class

Extension methods for [Assets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.Behaviors.GrowModel 'Assets.Scripts.Models.Bloons.Behaviors.GrowModel').

```csharp
public static class GrowModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GrowModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.GetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel)'></a>

## GrowModelExt.GetRegrowBloon(this GrowModel) Method

(Cross-Game compatible) Returns the ID of the BloonModel that this regrows into.

```csharp
public static string GetRegrowBloon(this Assets.Scripts.Models.Bloons.Behaviors.GrowModel growModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.GetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel).growModel'></a>

`growModel` [Assets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.Behaviors.GrowModel 'Assets.Scripts.Models.Bloons.Behaviors.GrowModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string)'></a>

## GrowModelExt.SetRegrowBloon(this GrowModel, string) Method

(Cross-Game compatible) Sets which bloon this should regrow into.

```csharp
public static void SetRegrowBloon(this Assets.Scripts.Models.Bloons.Behaviors.GrowModel growModel, string regrowsTo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string).growModel'></a>

`growModel` [Assets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.Behaviors.GrowModel 'Assets.Scripts.Models.Bloons.Behaviors.GrowModel')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the bloon this should regrow into

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string,float)'></a>

## GrowModelExt.SetRegrowBloon(this GrowModel, string, float) Method

(Cross-Game compatible) Sets which bloon this should regrow into.

```csharp
public static void SetRegrowBloon(this Assets.Scripts.Models.Bloons.Behaviors.GrowModel growModel, string regrowsTo, float regrowRate);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string,float).growModel'></a>

`growModel` [Assets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.Behaviors.GrowModel 'Assets.Scripts.Models.Bloons.Behaviors.GrowModel')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string,float).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the bloon this should regrow into

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisAssets.Scripts.Models.Bloons.Behaviors.GrowModel,string,float).regrowRate'></a>

`regrowRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The rate at which this regrows.