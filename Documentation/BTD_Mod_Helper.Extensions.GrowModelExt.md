#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GrowModelExt Class

Extension methods for [Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel').

```csharp
public static class GrowModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GrowModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.GetRegrowBloon(thisGrowModel)'></a>

## GrowModelExt.GetRegrowBloon(this GrowModel) Method

Returns the ID of the BloonModel that this regrows into.

```csharp
public static string GetRegrowBloon(this GrowModel growModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.GetRegrowBloon(thisGrowModel).growModel'></a>

`growModel` [Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string,float)'></a>

## GrowModelExt.SetRegrowBloon(this GrowModel, string, float) Method

Sets which bloon this should regrow into.

```csharp
public static void SetRegrowBloon(this GrowModel growModel, string regrowsTo, float regrowRate);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string,float).growModel'></a>

`growModel` [Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string,float).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the bloon this should regrow into

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string,float).regrowRate'></a>

`regrowRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The rate at which this regrows.

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string)'></a>

## GrowModelExt.SetRegrowBloon(this GrowModel, string) Method

Sets which bloon this should regrow into.

```csharp
public static void SetRegrowBloon(this GrowModel growModel, string regrowsTo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string).growModel'></a>

`growModel` [Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.GrowModel')

<a name='BTD_Mod_Helper.Extensions.GrowModelExt.SetRegrowBloon(thisGrowModel,string).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the bloon this should regrow into