#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModTowerCustomDisplay Class

A ModCustomDisplay that will automatically apply to a ModTower for specific tiers

```csharp
public abstract class ModTowerCustomDisplay : BTD_Mod_Helper.Api.Display.ModTowerDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModTowerDisplay](BTD_Mod_Helper.Api.Display.ModTowerDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay') &#129106; ModTowerCustomDisplay

Derived  
&#8627; [ModTowerCustomDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.AssetBundleName'></a>

## ModTowerCustomDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
public abstract string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.BaseDisplay'></a>

## ModTowerCustomDisplay.BaseDisplay Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.LoadAsync'></a>

## ModTowerCustomDisplay.LoadAsync Property

Whether to try loading the asset from the bundle asynchronously.

```csharp
public virtual bool LoadAsync { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.MaterialName'></a>

## ModTowerCustomDisplay.MaterialName Property

The name of the material that should be applied to the tower from the asset bundle, if any

```csharp
public virtual string MaterialName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.PrefabName'></a>

## ModTowerCustomDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
public abstract string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode)'></a>

## ModTowerCustomDisplay.ModifyDisplayNode(UnityDisplayNode) Method

Performs alterations to the unity display node when it is created

```csharp
public override void ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.ModifyDisplayNode(Assets.Scripts.Unity.Display.UnityDisplayNode).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')