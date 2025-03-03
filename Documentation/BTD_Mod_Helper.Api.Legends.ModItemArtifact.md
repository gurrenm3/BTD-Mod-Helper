#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Legends](README.md#BTD_Mod_Helper.Api.Legends 'BTD_Mod_Helper.Api.Legends')

## ModItemArtifact Class

Class for adding a custom Permanent/Item Artifact to the Rogue Legends mode

```csharp
public abstract class ModItemArtifact : BTD_Mod_Helper.Api.Legends.ModArtifact<ItemArtifactData, ItemArtifactModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModArtifact](BTD_Mod_Helper.Api.Legends.ModArtifact.md 'BTD_Mod_Helper.Api.Legends.ModArtifact') &#129106; [BTD_Mod_Helper.Api.Legends.ModArtifact&lt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Data.Artifacts.ItemArtifactData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Artifacts.ItemArtifactData 'Il2CppAssets.Scripts.Data.Artifacts.ItemArtifactData')[,](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')[&gt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>') &#129106; ModItemArtifact
### Methods

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.CreateArtifactModel(int,int)'></a>

## ModItemArtifact.CreateArtifactModel(int, int) Method

Creates the ArtifactModelBase derived model for this Artifact

```csharp
protected sealed override ItemArtifactModel CreateArtifactModel(int tier, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.CreateArtifactModel(int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0 for Common, 1 for Rare, 2 for Legendary

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.CreateArtifactModel(int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Artifact index

#### Returns
[Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.ItemArtifactModel')  
Created Artifact Model

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.GetId(int)'></a>

## ModItemArtifact.GetId(int) Method

Gets the id this should use for the given index

```csharp
public sealed override string GetId(int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.GetId(int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The ID to use

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.InstaMonkey(int)'></a>

## ModItemArtifact.InstaMonkey(int) Method

The baseId of the Insta Monkey that this Artifact should add to your party for the given tier. Setting this will  
handle adding to the Artifact description

```csharp
public virtual string InstaMonkey(int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.InstaMonkey(int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

artifact tier 0,1,2

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
tower base id

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.InstaTiers(int)'></a>

## ModItemArtifact.InstaTiers(int) Method

The baseId of the Insta Monkey that this Artifact should add to your party for the given tier. Setting this will  
handle adding to the Artifact description

```csharp
public virtual int[] InstaTiers(int tier);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModItemArtifact.InstaTiers(int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

artifact tier 0,1,2

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
3 length array of tiers [top, middle, bottom]