#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBloonCustomDisplay Class

A ModCustomDisplay that will automatically apply to a ModBloon

```csharp
public abstract class ModBloonCustomDisplay : BTD_Mod_Helper.Api.Display.ModBloonDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; [ModBloonDisplay](BTD_Mod_Helper.Api.Display.ModBloonDisplay.md 'BTD_Mod_Helper.Api.Display.ModBloonDisplay') &#129106; ModBloonCustomDisplay

Derived  
&#8627; [ModBloonCustomDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.AssetBundleName'></a>

## ModBloonCustomDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
public abstract string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.BaseDisplay'></a>

## ModBloonCustomDisplay.BaseDisplay Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override string BaseDisplay { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.BaseDisplayReference'></a>

## ModBloonCustomDisplay.BaseDisplayReference Property

On a ModCustomDisplay, this property does nothing

```csharp
public sealed override PrefabReference BaseDisplayReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.LoadAsync'></a>

## ModBloonCustomDisplay.LoadAsync Property

Whether to try loading the asset from the bundle asynchronously.

```csharp
public virtual bool LoadAsync { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.MaterialName'></a>

## ModBloonCustomDisplay.MaterialName Property

The name of the material that should be applied to the tower from the asset bundle, if any

```csharp
public virtual string MaterialName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBloonCustomDisplay.PrefabName'></a>

## ModBloonCustomDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
public abstract string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')