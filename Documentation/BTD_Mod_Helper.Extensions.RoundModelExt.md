#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RoundModelExt Class

Extensions for RoundModels

```csharp
public static class RoundModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RoundModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float)'></a>

## RoundModelExt.AddBloonGroup(this RoundModel, string, int, float, float) Method

Adds a new group of Bloons to this round

```csharp
public static void AddBloonGroup(this RoundModel roundModel, string bloonId, int count=1, float startTime=0f, float endTime=60f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

The round model

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float).bloonId'></a>

`bloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The id of the Bloon

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How many Bloons will be emitted

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float).startTime'></a>

`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

When this group starts emitting, in frames (seconds / 60)

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup(thisRoundModel,string,int,float,float).endTime'></a>

`endTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

When this group stops emitting, in frames (seconds / 60)

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float)'></a>

## RoundModelExt.AddBloonGroup<T>(this RoundModel, int, float, float) Method

Adds a new group of Bloons to this round

```csharp
public static void AddBloonGroup<T>(this RoundModel roundModel, int count=1, float startTime=0f, float endTime=60f)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

The round model

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float).count'></a>

`count` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How many Bloons will be emitted

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float).startTime'></a>

`startTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

When this group starts emitting, in frames (seconds / 60)

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.AddBloonGroup_T_(thisRoundModel,int,float,float).endTime'></a>

`endTime` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

When this group stops emitting, in frames (seconds / 60)

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ClearBloonGroups(thisRoundModel)'></a>

## RoundModelExt.ClearBloonGroups(this RoundModel) Method

Removes all Bloon Groups from the Round

```csharp
public static void ClearBloonGroups(this RoundModel roundModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ClearBloonGroups(thisRoundModel).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string,int)'></a>

## RoundModelExt.RemoveBloonGroup(this RoundModel, string, int) Method

Removes the index'th Bloon Group where the id is as specified

```csharp
public static void RemoveBloonGroup(this RoundModel roundModel, string bloonId, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string,int).bloonId'></a>

`bloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string)'></a>

## RoundModelExt.RemoveBloonGroup(this RoundModel, string) Method

Removes all Bloon Groups where the id is as specified

```csharp
public static void RemoveBloonGroup(this RoundModel roundModel, string bloonId);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.RemoveBloonGroup(thisRoundModel,string).bloonId'></a>

`bloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups(thisRoundModel,string,string,bool)'></a>

## RoundModelExt.ReplaceBloonInGroups(this RoundModel, string, string, bool) Method

Replaces BloonGroups of a certain bloonId with ones for a new Id

```csharp
public static void ReplaceBloonInGroups(this RoundModel roundModel, string oldBloonId, string newBloonId, bool byBaseId=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups(thisRoundModel,string,string,bool).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups(thisRoundModel,string,string,bool).oldBloonId'></a>

`oldBloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups(thisRoundModel,string,string,bool).newBloonId'></a>

`newBloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups(thisRoundModel,string,string,bool).byBaseId'></a>

`byBaseId` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups_T_(thisRoundModel,string,bool)'></a>

## RoundModelExt.ReplaceBloonInGroups<T>(this RoundModel, string, bool) Method

Replaces BloonGroups of a certain bloonId with ones for a new Id

```csharp
public static void ReplaceBloonInGroups<T>(this RoundModel roundModel, string oldBloonId, bool byBaseId=false)
    where T : BTD_Mod_Helper.Api.Bloons.ModBloon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups_T_(thisRoundModel,string,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups_T_(thisRoundModel,string,bool).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups_T_(thisRoundModel,string,bool).oldBloonId'></a>

`oldBloonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.RoundModelExt.ReplaceBloonInGroups_T_(thisRoundModel,string,bool).byBaseId'></a>

`byBaseId` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')