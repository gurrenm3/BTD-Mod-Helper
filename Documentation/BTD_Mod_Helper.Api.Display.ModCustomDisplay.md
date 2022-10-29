#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModCustomDisplay Class

The custom version of a ModDisplay that loads in a model from a unity assetbundle

```csharp
public abstract class ModCustomDisplay : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModCustomDisplay
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.AssetBundleName'></a>

## ModCustomDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
public abstract string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.BaseDisplay'></a>

## ModCustomDisplay.BaseDisplay Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.LoadAsync'></a>

## ModCustomDisplay.LoadAsync Property

Whether to try loading the asset from the bundle asynchronously.

```csharp
public virtual bool LoadAsync { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.MaterialName'></a>

## ModCustomDisplay.MaterialName Property

The name of the material that should be applied to the tower from the asset bundle, if any

```csharp
public virtual string MaterialName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.PrefabName'></a>

## ModCustomDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
public abstract string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode)'></a>

## ModCustomDisplay.ModifyDisplayNode(UnityDisplayNode) Method

Performs alterations to the unity display node when it is created

```csharp
public override void ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModCustomDisplay.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')