#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Legends](README.md#BTD_Mod_Helper.Api.Legends 'BTD_Mod_Helper.Api.Legends')

## ModBoostArtifact Class

Class for adding a custom Boost Artifact to the Rogue Legends mode

```csharp
public abstract class ModBoostArtifact : BTD_Mod_Helper.Api.Legends.ModArtifact<BoostArtifactData, BoostArtifactModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModArtifact](BTD_Mod_Helper.Api.Legends.ModArtifact.md 'BTD_Mod_Helper.Api.Legends.ModArtifact') &#129106; [BTD_Mod_Helper.Api.Legends.ModArtifact&lt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Data.Artifacts.BoostArtifactData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Artifacts.BoostArtifactData 'Il2CppAssets.Scripts.Data.Artifacts.BoostArtifactData')[,](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')[&gt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>') &#129106; ModBoostArtifact
### Methods

<a name='BTD_Mod_Helper.Api.Legends.ModBoostArtifact.CreateArtifactModel(int,int)'></a>

## ModBoostArtifact.CreateArtifactModel(int, int) Method

Creates the ArtifactModelBase derived model for this Artifact

```csharp
protected sealed override BoostArtifactModel CreateArtifactModel(int tier, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModBoostArtifact.CreateArtifactModel(int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0 for Common, 1 for Rare, 2 for Legendary

<a name='BTD_Mod_Helper.Api.Legends.ModBoostArtifact.CreateArtifactModel(int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Artifact index

#### Returns
[Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.BoostArtifactModel')  
Created Artifact Model

<a name='BTD_Mod_Helper.Api.Legends.ModBoostArtifact.GetId(int)'></a>

## ModBoostArtifact.GetId(int) Method

Gets the id this should use for the given index

```csharp
public sealed override string GetId(int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModBoostArtifact.GetId(int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

1, 2 or 3

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The ID to use