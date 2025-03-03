#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Legends](README.md#BTD_Mod_Helper.Api.Legends 'BTD_Mod_Helper.Api.Legends')

## ModMapArtifact Class

Class for adding a custom Map Artifact to the Rogue Legends mode

```csharp
public abstract class ModMapArtifact : BTD_Mod_Helper.Api.Legends.ModArtifact<MapArtifactData, MapArtifactModel>
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModArtifact](BTD_Mod_Helper.Api.Legends.ModArtifact.md 'BTD_Mod_Helper.Api.Legends.ModArtifact') &#129106; [BTD_Mod_Helper.Api.Legends.ModArtifact&lt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Data.Artifacts.MapArtifactData](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Data.Artifacts.MapArtifactData 'Il2CppAssets.Scripts.Data.Artifacts.MapArtifactData')[,](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>')[Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')[&gt;](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>') &#129106; ModMapArtifact
### Methods

<a name='BTD_Mod_Helper.Api.Legends.ModMapArtifact.CreateArtifactModel(int,int)'></a>

## ModMapArtifact.CreateArtifactModel(int, int) Method

Creates the ArtifactModelBase derived model for this Artifact

```csharp
protected sealed override MapArtifactModel CreateArtifactModel(int tier, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModMapArtifact.CreateArtifactModel(int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0 for Common, 1 for Rare, 2 for Legendary

<a name='BTD_Mod_Helper.Api.Legends.ModMapArtifact.CreateArtifactModel(int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Artifact index

#### Returns
[Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel 'Il2CppAssets.Scripts.Models.Artifacts.MapArtifactModel')  
Created Artifact Model