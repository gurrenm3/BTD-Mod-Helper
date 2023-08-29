#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## TrackFXDisplay Class

The display for the [TrackFXReference](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TrackFXReference 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TrackFXReference') for a boss

```csharp
public abstract class TrackFXDisplay : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; TrackFXDisplay

Derived  
&#8627; [TrackFXDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.TrackFXDisplay_T_.md 'BTD_Mod_Helper.Api.Display.TrackFXDisplay<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Display.TrackFXDisplay.AssetBundleName'></a>

## TrackFXDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
public abstract string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.TrackFXDisplay.Boss'></a>

## TrackFXDisplay.Boss Property

The ModBoss that this MapFXDisplay is used for

```csharp
public abstract BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')

<a name='BTD_Mod_Helper.Api.Display.TrackFXDisplay.LoadAsync'></a>

## TrackFXDisplay.LoadAsync Property

Whether to try loading the asset from the bundle asynchronously.

```csharp
public abstract bool LoadAsync { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.TrackFXDisplay.PrefabName'></a>

## TrackFXDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
public abstract string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')