#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBossTierCustomDisplay Class

A ModCustomDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBossTierCustomDisplay : BTD_Mod_Helper.Api.Display.ModBossTierDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; [ModBossTierDisplay](BTD_Mod_Helper.Api.Display.ModBossTierDisplay.md 'BTD_Mod_Helper.Api.Display.ModBossTierDisplay') &#129106; ModBossTierCustomDisplay

Derived  
&#8627; [ModBossTierCustomDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.AssetBundleName'></a>

## ModBossTierCustomDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
public abstract string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.BaseDisplay'></a>

## ModBossTierCustomDisplay.BaseDisplay Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.BaseDisplayReference'></a>

## ModBossTierCustomDisplay.BaseDisplayReference Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override PrefabReference BaseDisplayReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.LoadAsync'></a>

## ModBossTierCustomDisplay.LoadAsync Property

Whether to try loading the asset from the bundle asynchronously.

```csharp
public virtual bool LoadAsync { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.MaterialName'></a>

## ModBossTierCustomDisplay.MaterialName Property

The name of the material that should be applied to the tower from the asset bundle, if any

```csharp
public virtual string MaterialName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBossTierCustomDisplay.PrefabName'></a>

## ModBossTierCustomDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
public abstract string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')