#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonModelExt Class

Extensions for BloonModels

```csharp
public static class BloonModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisBloonModel,string)'></a>

## BloonModelExt.AddTag(this BloonModel, string) Method

Adds a tag to the BloonModel, if it doesn't already exist

```csharp
public static void AddTag(this BloonModel bloonModel, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisBloonModel,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddTag(thisBloonModel,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisBloonModel,string,int)'></a>

## BloonModelExt.AddToChildren(this BloonModel, string, int) Method

Adds a child to be spawned from the Bloon

```csharp
public static void AddToChildren(this BloonModel bloonModel, string id, int amount=1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisBloonModel,string,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisBloonModel,string,int).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren(thisBloonModel,string,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisBloonModel,int)'></a>

## BloonModelExt.AddToChildren<T>(this BloonModel, int) Method

Adds a child to be spawned from the Bloon

```csharp
public static void AddToChildren<T>(this BloonModel bloonModel, int amount=1)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisBloonModel,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisBloonModel,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.AddToChildren_T_(thisBloonModel,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisBloonModel)'></a>

## BloonModelExt.ApplyDisplay<T>(this BloonModel) Method

Applies a given ModDisplay to this TowerModel

```csharp
public static void ApplyDisplay<T>(this BloonModel bloonModel)
    where T : BTD_Mod_Helper.Api.Display.ModDisplay;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisBloonModel).T'></a>

`T`

The type of ModDisplay
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ApplyDisplay_T_(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisBloonModel,int,int)'></a>

## BloonModelExt.CreateBloonEmissionModel(this BloonModel, int, int) Method

Create a BloonEmissionModel from this BloonModel

```csharp
public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissionModel(this BloonModel bloonModel, int count, int spacing);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisBloonModel,int,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisBloonModel,int,int).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Number of bloons in this emission model

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.CreateBloonEmissionModel(thisBloonModel,int,int).spacing'></a>

`spacing` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Space between each bloon in this emission model

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisBloonModel,System.Action_BloonModel_,string)'></a>

## BloonModelExt.FindChangedBloonId(this BloonModel, Action<BloonModel>, string) Method

Finds the id for a bloon that has the properties of this bloonModel, or null if there isn't one

```csharp
public static bool FindChangedBloonId(this BloonModel bloonModel, System.Action<BloonModel> change, out string id);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisBloonModel,System.Action_BloonModel_,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisBloonModel,System.Action_BloonModel_,string).change'></a>

`change` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.FindChangedBloonId(thisBloonModel,System.Action_BloonModel_,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetAllBloonToSim(thisBloonModel)'></a>

## BloonModelExt.GetAllBloonToSim(this BloonModel) Method

Return all BloonToSimulations with this BloonModel

```csharp
public static System.Collections.Generic.List<BloonToSimulation> GetAllBloonToSim(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetAllBloonToSim(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBaseID(thisBloonModel)'></a>

## BloonModelExt.GetBaseID(this BloonModel) Method

Return the Base ID of this BloonModel

```csharp
public static string GetBaseID(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBaseID(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonModel(thisBloonGroupModel)'></a>

## BloonModelExt.GetBloonModel(this BloonGroupModel) Method

Gets the BloonModel for this group

```csharp
public static BloonModel GetBloonModel(this BloonGroupModel bloonGroupModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonModel(thisBloonGroupModel).bloonGroupModel'></a>

`bloonGroupModel` [Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel 'Il2CppAssets.Scripts.Models.Rounds.BloonGroupModel')

#### Returns
[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonSims(thisBloonModel)'></a>

## BloonModelExt.GetBloonSims(this BloonModel) Method

Return all BloonToSimulations with this BloonModel

```csharp
public static System.Collections.Generic.List<BloonToSimulation> GetBloonSims(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetBloonSims(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetDisplayGUID(thisBloonModel)'></a>

## BloonModelExt.GetDisplayGUID(this BloonModel) Method

Returns the Display GUID for this BloonModel.

```csharp
public static string GetDisplayGUID(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetDisplayGUID(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetIndex(thisBloonModel)'></a>

## BloonModelExt.GetIndex(this BloonModel) Method

Return the number position of this bloon from the list of all bloons (Game.instance.model.bloons)

```csharp
public static int GetIndex(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetIndex(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetModBloon(thisBloonModel)'></a>

## BloonModelExt.GetModBloon(this BloonModel) Method

Gets the ModBloon associated with this BloonModel  
<br/>  
If there is no associated ModBloon, returns null

```csharp
public static BTD_Mod_Helper.Api.Bloons.ModBloon GetModBloon(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetModBloon(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisBloonModel,bool)'></a>

## BloonModelExt.GetSpawnChildrenModel(this BloonModel, bool) Method

Gets the SpawnChildrenModel for the bloon, and optionally creates one if it doesn't exist

```csharp
public static SpawnChildrenModel GetSpawnChildrenModel(this BloonModel bloonModel, bool addIfNotExists=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisBloonModel,bool).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetSpawnChildrenModel(thisBloonModel,bool).addIfNotExists'></a>

`addIfNotExists` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Il2CppAssets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel 'Il2CppAssets.Scripts.Models.Bloons.Behaviors.SpawnChildrenModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisBloonModel,int)'></a>

## BloonModelExt.GetTotalCash(this BloonModel, int) Method

(Cross-Game compatable) Return how much cash this bloon would give if popped by [layersPopped](BTD_Mod_Helper.Extensions.BloonModelExt.md#BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisBloonModel,int).layersPopped 'BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(this BloonModel, int).layersPopped') number of layers

```csharp
public static int GetTotalCash(this BloonModel bloonModel, int layersPopped=-1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisBloonModel,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.GetTotalCash(thisBloonModel,int).layersPopped'></a>

`layersPopped` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How many layers of bloons to pop, ignoring layer health. If less than 0, calculates for the entire bloon

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsCamoBloon(thisBloonModel)'></a>

## BloonModelExt.IsCamoBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Camo bloon.

```csharp
public static bool IsCamoBloon(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsCamoBloon(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsFortifiedBloon(thisBloonModel)'></a>

## BloonModelExt.IsFortifiedBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Fortified bloon.

```csharp
public static bool IsFortifiedBloon(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsFortifiedBloon(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsMoabBloon(thisBloonModel)'></a>

## BloonModelExt.IsMoabBloon(this BloonModel) Method

Returns whether or not this BloonModel is an MOAB-Class bloon.

```csharp
public static bool IsMoabBloon(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsMoabBloon(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsRegrowBloon(thisBloonModel)'></a>

## BloonModelExt.IsRegrowBloon(this BloonModel) Method

Returns whether or not this BloonModel is a Regrow bloon.

```csharp
public static bool IsRegrowBloon(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.IsRegrowBloon(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenCamo(thisBloonModel)'></a>

## BloonModelExt.MakeChildrenCamo(this BloonModel) Method

Makes all children of this Bloon Camo, if they can have it

```csharp
public static void MakeChildrenCamo(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenCamo(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenFortified(thisBloonModel)'></a>

## BloonModelExt.MakeChildrenFortified(this BloonModel) Method

Makes all children of this Bloon Fortified, if they can have it

```csharp
public static void MakeChildrenFortified(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenFortified(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenRegrow(thisBloonModel)'></a>

## BloonModelExt.MakeChildrenRegrow(this BloonModel) Method

Makes all children of this Bloon Regrow, if they can have it

```csharp
public static void MakeChildrenRegrow(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.MakeChildrenRegrow(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveAllChildren(thisBloonModel)'></a>

## BloonModelExt.RemoveAllChildren(this BloonModel) Method

Removes all spawned children from this BloonModel

```csharp
public static void RemoveAllChildren(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveAllChildren(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisBloonModel,string,int)'></a>

## BloonModelExt.RemoveFromChildren(this BloonModel, string, int) Method

Removes up to amount of the given Bloon from the spawned children

```csharp
public static void RemoveFromChildren(this BloonModel bloonModel, string id, int amount=1);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisBloonModel,string,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisBloonModel,string,int).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveFromChildren(thisBloonModel,string,int).amount'></a>

`amount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveRegrow(thisBloonModel)'></a>

## BloonModelExt.RemoveRegrow(this BloonModel) Method

Removes the Regrow behavior from this BloonModel.

```csharp
public static void RemoveRegrow(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveRegrow(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisBloonModel,string)'></a>

## BloonModelExt.RemoveTag(this BloonModel, string) Method

Removes a tag from the BloonModel, if it exists

```csharp
public static void RemoveTag(this BloonModel bloonModel, string tag);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisBloonModel,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.RemoveTag(thisBloonModel,string).tag'></a>

`tag` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisBloonModel,string,string)'></a>

## BloonModelExt.ReplaceInChildren(this BloonModel, string, string) Method

Replaces all spawned child Bloons with the given id with the given ModBloon

```csharp
public static void ReplaceInChildren(this BloonModel bloonModel, string oldId, string newId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisBloonModel,string,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisBloonModel,string,string).oldId'></a>

`oldId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren(thisBloonModel,string,string).newId'></a>

`newId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisBloonModel,string)'></a>

## BloonModelExt.ReplaceInChildren<T>(this BloonModel, string) Method

Replaces all spawned child Bloons that have id oldId with the given ModBloon

```csharp
public static void ReplaceInChildren<T>(this BloonModel bloonModel, string oldId)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisBloonModel,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisBloonModel,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_T_(thisBloonModel,string).oldId'></a>

`oldId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisBloonModel,string)'></a>

## BloonModelExt.ReplaceInChildren<TOld,TNew>(this BloonModel, string) Method

Replaces all spawned child Bloons of the first ModBloon type with the second ModBloon type

```csharp
public static void ReplaceInChildren<TOld,TNew>(this BloonModel bloonModel, string id)
    where TOld : BTD_Mod_Helper.Api.Bloons.ModBloon
    where TNew : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisBloonModel,string).TOld'></a>

`TOld`

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisBloonModel,string).TNew'></a>

`TNew`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisBloonModel,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.ReplaceInChildren_TOld,TNew_(thisBloonModel,string).id'></a>

`id` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisBloonModel,bool)'></a>

## BloonModelExt.SetCamo(this BloonModel, bool) Method

Set whether or not this BloonModel is a Camo bloon.

```csharp
public static void SetCamo(this BloonModel bloonModel, bool isCamo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisBloonModel,bool).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetCamo(thisBloonModel,bool).isCamo'></a>

`isCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisBloonModel,string)'></a>

## BloonModelExt.SetDisplayGUID(this BloonModel, string) Method

Set the Display GUID for this BloonModel.

```csharp
public static void SetDisplayGUID(this BloonModel bloonModel, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisBloonModel,string).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetDisplayGUID(thisBloonModel,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisBloonModel,bool)'></a>

## BloonModelExt.SetFortified(this BloonModel, bool) Method

Set whether or not this BloonModel is a Fortified bloon.

```csharp
public static void SetFortified(this BloonModel bloonModel, bool isFortified);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisBloonModel,bool).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetFortified(thisBloonModel,bool).isFortified'></a>

`isFortified` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisBloonModel,bool)'></a>

## BloonModelExt.SetMoab(this BloonModel, bool) Method

Set whether or not this BloonModel is a Fortified bloon.

```csharp
public static void SetMoab(this BloonModel bloonModel, bool isMoabBloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisBloonModel,bool).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetMoab(thisBloonModel,bool).isMoabBloon'></a>

`isMoabBloon` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisBloonModel,string,float)'></a>

## BloonModelExt.SetRegrow(this BloonModel, string, float) Method

Adds the Regrow behavior to this BloonModel and sets what   
Bloon it Regrows into.

```csharp
public static void SetRegrow(this BloonModel bloonModel, string regrowsTo, float regrowRate=3f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisBloonModel,string,float).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisBloonModel,string,float).regrowsTo'></a>

`regrowsTo` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The ID of the BloonModel that this should regrow into.

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrow(thisBloonModel,string,float).regrowRate'></a>

`regrowRate` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The rate at which this regrows.

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisBloonModel,bool)'></a>

## BloonModelExt.SetRegrowBool(this BloonModel, bool) Method

Set whether or not this BloonModel is a Regrow bloon.

```csharp
private static void SetRegrowBool(this BloonModel bloonModel, bool isRegrow);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisBloonModel,bool).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SetRegrowBool(thisBloonModel,bool).isRegrow'></a>

`isRegrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SpawnBloonModel(thisBloonModel)'></a>

## BloonModelExt.SpawnBloonModel(this BloonModel) Method

Spawn this BloonModel on the map right now

```csharp
public static void SpawnBloonModel(this BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonModelExt.SpawnBloonModel(thisBloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')