#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Legends](README.md#BTD_Mod_Helper.Api.Legends 'BTD_Mod_Helper.Api.Legends')

## ModArtifact<TData,TModel> Class

<inheritdoc cref="T:BTD_Mod_Helper.Api.Legends.ModArtifact"/>

```csharp
public abstract class ModArtifact<TData,TModel> : BTD_Mod_Helper.Api.Legends.ModArtifact
    where TData : ArtifactDataBase
    where TModel : ArtifactModelBase
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.TData'></a>

`TData`

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.TModel'></a>

`TModel`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModArtifact](BTD_Mod_Helper.Api.Legends.ModArtifact.md 'BTD_Mod_Helper.Api.Legends.ModArtifact') &#129106; ModArtifact<TData,TModel>

Derived  
&#8627; [ModBoostArtifact](BTD_Mod_Helper.Api.Legends.ModBoostArtifact.md 'BTD_Mod_Helper.Api.Legends.ModBoostArtifact')  
&#8627; [ModItemArtifact](BTD_Mod_Helper.Api.Legends.ModItemArtifact.md 'BTD_Mod_Helper.Api.Legends.ModItemArtifact')  
&#8627; [ModMapArtifact](BTD_Mod_Helper.Api.Legends.ModMapArtifact.md 'BTD_Mod_Helper.Api.Legends.ModMapArtifact')
### Methods

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.CreateArtifactModel(int,int)'></a>

## ModArtifact<TData,TModel>.CreateArtifactModel(int, int) Method

Creates the ArtifactModelBase derived model for this Artifact

```csharp
protected abstract TModel CreateArtifactModel(int tier, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.CreateArtifactModel(int,int).tier'></a>

`tier` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

0 for Common, 1 for Rare, 2 for Legendary

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.CreateArtifactModel(int,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Artifact index

#### Returns
[TModel](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md#BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.TModel 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>.TModel')  
Created Artifact Model

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.ModifyArtifactModel(TModel)'></a>

## ModArtifact<TData,TModel>.ModifyArtifactModel(TModel) Method

Modifies and adds behaviors to the artifact to define its in-game effcts

```csharp
public abstract void ModifyArtifactModel(TModel artifactModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.ModifyArtifactModel(TModel).artifactModel'></a>

`artifactModel` [TModel](BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.md#BTD_Mod_Helper.Api.Legends.ModArtifact_TData,TModel_.TModel 'BTD_Mod_Helper.Api.Legends.ModArtifact<TData,TModel>.TModel')

Artifact Model