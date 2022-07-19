#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonModelExt Class

Extensions for BloonModels

```csharp
public static class BloonModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisAssets.Scripts.Models.Bloons.BloonModel,string)'></a>

## BloonModelExt.AddTag(this BloonModel, string) Method

Adds a tag to the BloonModel, if it doesn't already exist

```csharp
public static void AddTag(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisAssets.Scripts.Models.Bloons.BloonModel,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisAssets.Scripts.Models.Bloons.BloonModel,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int)'></a>

## BloonModelExt.AddToChildren(this BloonModel, string, int) Method

Adds a child to be spawned from the Bloon

```csharp
public static void AddToChildren(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string id, int amount=1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,int)'></a>

## BloonModelExt.AddToChildren<T>(this BloonModel, int) Method

Adds a child to be spawned from the Bloon

```csharp
public static void AddToChildren<T>(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, int amount=1)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,int).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.ApplyDisplay<T>(this BloonModel) Method

Applies a given ModDisplay to this TowerModel

```csharp
public static void ApplyDisplay<T>(this Assets.Scripts.Models.Bloons.BloonModel bloonModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Bloons.BloonModel).T'></a>

`T`

The type of ModDisplay
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisAssets.Scripts.Models.Bloons.BloonModel,int,int)'></a>

## BloonModelExt.CreateBloonEmissionModel(this BloonModel, int, int) Method

Create a BloonEmissionModel from this BloonModel

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<Assets.Scripts.Models.Rounds.BloonEmissionModel> CreateBloonEmissionModel(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, int count, int spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisAssets.Scripts.Models.Bloons.BloonModel,int,int).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisAssets.Scripts.Models.Bloons.BloonModel,int,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of bloons in this emission model

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisAssets.Scripts.Models.Bloons.BloonModel,int,int).spacing'></a>

`spacing` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Space between each bloon in this emission model

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[Assets.Scripts.Models.Rounds.BloonEmissionModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonEmissionModel 'Assets.Scripts.Models.Rounds.BloonEmissionModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisAssets.Scripts.Models.Bloons.BloonModel,System.Action_Assets.Scripts.Models.Bloons.BloonModel_,string)'></a>

## BloonModelExt.FindChangedBloonId(this BloonModel, Action<BloonModel>, string) Method

Finds the id for a bloon that has the properties of this bloonModel, or null if there isn't one

```csharp
public static bool FindChangedBloonId(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, System.Action<Assets.Scripts.Models.Bloons.BloonModel> change, out string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisAssets.Scripts.Models.Bloons.BloonModel,System.Action_Assets.Scripts.Models.Bloons.BloonModel_,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisAssets.Scripts.Models.Bloons.BloonModel,System.Action_Assets.Scripts.Models.Bloons.BloonModel_,string).change'></a>

`change` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisAssets.Scripts.Models.Bloons.BloonModel,System.Action_Assets.Scripts.Models.Bloons.BloonModel_,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetAllBloonToSim(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetAllBloonToSim(this BloonModel) Method

Return all BloonToSimulations with this BloonModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.BloonToSimulation> GetAllBloonToSim(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetAllBloonToSim(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.BloonToSimulation 'Assets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBaseID(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetBaseID(this BloonModel) Method

Return the Base ID of this BloonModel

```csharp
public static string GetBaseID(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBaseID(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonModel(thisAssets.Scripts.Models.Rounds.BloonGroupModel)'></a>

## BloonModelExt.GetBloonModel(this BloonGroupModel) Method

Gets the BloonModel for this group

```csharp
public static Assets.Scripts.Models.Bloons.BloonModel GetBloonModel(this Assets.Scripts.Models.Rounds.BloonGroupModel bloonGroupModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonModel(thisAssets.Scripts.Models.Rounds.BloonGroupModel).bloonGroupModel'></a>

`bloonGroupModel` [Assets.Scripts.Models.Rounds.BloonGroupModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Rounds.BloonGroupModel 'Assets.Scripts.Models.Rounds.BloonGroupModel')

#### Returns
[Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonSims(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetBloonSims(this BloonModel) Method

This is Obsolete, use GetAllBloonToSim instead. Return all BloonToSimulations with this BloonModel

```csharp
public static System.Collections.Generic.List<Assets.Scripts.Unity.Bridge.BloonToSimulation> GetBloonSims(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonSims(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.BloonToSimulation 'Assets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetDisplayGUID(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetDisplayGUID(this BloonModel) Method

Returns the Display GUID for this BloonModel.

```csharp
public static string GetDisplayGUID(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetDisplayGUID(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetIndex(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetIndex(this BloonModel) Method

Return the number position of this bloon from the list of all bloons (Game.instance.model.bloons)

```csharp
public static int GetIndex(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetIndex(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetModBloon(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.GetModBloon(this BloonModel) Method

Gets the ModBloon associated with this BloonModel  
<br/>  
If there is no associated ModBloon, returns null

```csharp
public static BTD_Mod_Helper.Api.Bloons.ModBloon GetModBloon(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetModBloon(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisAssets.Scripts.Models.Bloons.BloonModel,bool)'></a>

## BloonModelExt.GetSpawnChildrenModel(this BloonModel, bool) Method

Gets the SpawnChildrenModel for the bloon, and optionally creates one if it doesn't exist

```csharp
public static Assets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel GetSpawnChildrenModel(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, bool addIfNotExists=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisAssets.Scripts.Models.Bloons.BloonModel,bool).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisAssets.Scripts.Models.Bloons.BloonModel,bool).addIfNotExists'></a>

`addIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Assets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel 'Assets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisAssets.Scripts.Models.Bloons.BloonModel,int)'></a>

## BloonModelExt.GetTotalCash(this BloonModel, int) Method

(Cross-Game compatable) Return how much cash this bloon would give if popped by [layersPopped](BTD_Mod_Helper.Extensions.BloonModelExt.md#BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisAssets.Scripts.Models.Bloons.BloonModel,int).layersPopped 'BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(this Assets.Scripts.Models.Bloons.BloonModel, int).layersPopped') number of layers

```csharp
public static int GetTotalCash(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, int layersPopped=-1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisAssets.Scripts.Models.Bloons.BloonModel,int).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisAssets.Scripts.Models.Bloons.BloonModel,int).layersPopped'></a>

`layersPopped` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the entire bloon

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsCamoBloon(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.IsCamoBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Camo bloon.

```csharp
public static bool IsCamoBloon(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsCamoBloon(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsFortifiedBloon(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.IsFortifiedBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Fortified bloon.

```csharp
public static bool IsFortifiedBloon(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsFortifiedBloon(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsMoabBloon(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.IsMoabBloon(this BloonModel) Method

Returns whether or not this BloonModel is an MOAB-Class bloon.

```csharp
public static bool IsMoabBloon(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsMoabBloon(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsRegrowBloon(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.IsRegrowBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Regrow bloon.

```csharp
public static bool IsRegrowBloon(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsRegrowBloon(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenCamo(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.MakeChildrenCamo(this BloonModel) Method

Makes all children of this Bloon Camo, if they can have it

```csharp
public static void MakeChildrenCamo(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenCamo(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenFortified(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.MakeChildrenFortified(this BloonModel) Method

Makes all children of this Bloon Fortified, if they can have it

```csharp
public static void MakeChildrenFortified(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenFortified(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenRegrow(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.MakeChildrenRegrow(this BloonModel) Method

Makes all children of this Bloon Regrow, if they can have it

```csharp
public static void MakeChildrenRegrow(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenRegrow(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveAllChildren(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.RemoveAllChildren(this BloonModel) Method

Removes all spawned children from this BloonModel

```csharp
public static void RemoveAllChildren(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveAllChildren(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int)'></a>

## BloonModelExt.RemoveFromChildren(this BloonModel, string, int) Method

Removes up to amount of the given Bloon from the spawned children

```csharp
public static void RemoveFromChildren(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string id, int amount=1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveRegrow(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.RemoveRegrow(this BloonModel) Method

Removes the Regrow behavior from this BloonModel.

```csharp
public static void RemoveRegrow(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveRegrow(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisAssets.Scripts.Models.Bloons.BloonModel,string)'></a>

## BloonModelExt.RemoveTag(this BloonModel, string) Method

Removes a tag from the BloonModel, if it exists

```csharp
public static void RemoveTag(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisAssets.Scripts.Models.Bloons.BloonModel,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisAssets.Scripts.Models.Bloons.BloonModel,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,string)'></a>

## BloonModelExt.ReplaceInChildren(this BloonModel, string, string) Method

Replaces all spawned child Bloons with the given id with the given ModBloon

```csharp
public static void ReplaceInChildren(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string oldId, string newId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,string).oldId'></a>

`oldId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisAssets.Scripts.Models.Bloons.BloonModel,string,string).newId'></a>

`newId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,string)'></a>

## BloonModelExt.ReplaceInChildren<T>(this BloonModel, string) Method

Replaces all spawned child Bloons that have id oldId with the given ModBloon

```csharp
public static void ReplaceInChildren<T>(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string oldId)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisAssets.Scripts.Models.Bloons.BloonModel,string).oldId'></a>

`oldId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisAssets.Scripts.Models.Bloons.BloonModel,string)'></a>

## BloonModelExt.ReplaceInChildren<TOld,TNew>(this BloonModel, string) Method

Replaces all spawned child Bloons of the first ModBloon type with the second ModBloon type

```csharp
public static void ReplaceInChildren<TOld,TNew>(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string id)
    where TOld : BTD_Mod_Helper.Api.Bloons.ModBloon
    where TNew : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisAssets.Scripts.Models.Bloons.BloonModel,string).TOld'></a>

`TOld`

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisAssets.Scripts.Models.Bloons.BloonModel,string).TNew'></a>

`TNew`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisAssets.Scripts.Models.Bloons.BloonModel,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisAssets.Scripts.Models.Bloons.BloonModel,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisAssets.Scripts.Models.Bloons.BloonModel,bool)'></a>

## BloonModelExt.SetCamo(this BloonModel, bool) Method

Set whether or not this BloonModel is a Camo bloon.

```csharp
public static void SetCamo(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, bool isCamo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisAssets.Scripts.Models.Bloons.BloonModel,bool).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisAssets.Scripts.Models.Bloons.BloonModel,bool).isCamo'></a>

`isCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisAssets.Scripts.Models.Bloons.BloonModel,string)'></a>

## BloonModelExt.SetDisplayGUID(this BloonModel, string) Method

Set the Display GUID for this BloonModel.

```csharp
public static void SetDisplayGUID(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisAssets.Scripts.Models.Bloons.BloonModel,string).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisAssets.Scripts.Models.Bloons.BloonModel,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisAssets.Scripts.Models.Bloons.BloonModel,bool)'></a>

## BloonModelExt.SetFortified(this BloonModel, bool) Method

Set whether or not this BloonModel is a Fortified bloon.

```csharp
public static void SetFortified(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, bool isFortified);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisAssets.Scripts.Models.Bloons.BloonModel,bool).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisAssets.Scripts.Models.Bloons.BloonModel,bool).isFortified'></a>

`isFortified` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisAssets.Scripts.Models.Bloons.BloonModel,bool)'></a>

## BloonModelExt.SetMoab(this BloonModel, bool) Method

Set whether or not this BloonModel is a Fortified bloon.

```csharp
public static void SetMoab(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, bool isMoabBloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisAssets.Scripts.Models.Bloons.BloonModel,bool).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisAssets.Scripts.Models.Bloons.BloonModel,bool).isMoabBloon'></a>

`isMoabBloon` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisAssets.Scripts.Models.Bloons.BloonModel,string,float)'></a>

## BloonModelExt.SetRegrow(this BloonModel, string, float) Method

Adds the Regrow behavior to this BloonModel and sets what   
Bloon it Regrows into.

```csharp
public static void SetRegrow(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, string regrowsTo, float regrowRate=3f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisAssets.Scripts.Models.Bloons.BloonModel,string,float).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisAssets.Scripts.Models.Bloons.BloonModel,string,float).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the BloonModel that this should regrow into.

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisAssets.Scripts.Models.Bloons.BloonModel,string,float).regrowRate'></a>

`regrowRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The rate at which this regrows.

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisAssets.Scripts.Models.Bloons.BloonModel,bool)'></a>

## BloonModelExt.SetRegrowBool(this BloonModel, bool) Method

Set whether or not this BloonModel is a Regrow bloon.

```csharp
private static void SetRegrowBool(this Assets.Scripts.Models.Bloons.BloonModel bloonModel, bool isRegrow);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisAssets.Scripts.Models.Bloons.BloonModel,bool).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisAssets.Scripts.Models.Bloons.BloonModel,bool).isRegrow'></a>

`isRegrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SpawnBloonModel(thisAssets.Scripts.Models.Bloons.BloonModel)'></a>

## BloonModelExt.SpawnBloonModel(this BloonModel) Method

Spawn this BloonModel on the map right now

```csharp
public static void SpawnBloonModel(this Assets.Scripts.Models.Bloons.BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SpawnBloonModel(thisAssets.Scripts.Models.Bloons.BloonModel).bloonModel'></a>

`bloonModel` [Assets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Bloons.BloonModel 'Assets.Scripts.Models.Bloons.BloonModel')