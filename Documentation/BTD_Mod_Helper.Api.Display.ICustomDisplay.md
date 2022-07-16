#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Display](index.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ICustomDisplay Interface

```csharp
internal interface ICustomDisplay
```

Derived  
&#8627; [ModCustomDisplay](BTD_Mod_Helper.Api.Display.ModCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModCustomDisplay')  
&#8627; [ModTowerCustomDisplay](BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ICustomDisplay.AssetBundleName'></a>

## ICustomDisplay.AssetBundleName Property

The name of the asset bundle file that the model is in, not including the .bundle extension

```csharp
string AssetBundleName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ICustomDisplay.MaterialName'></a>

## ICustomDisplay.MaterialName Property

The name of the material that should be applied to the tower from the asset bundle

```csharp
string MaterialName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ICustomDisplay.PrefabName'></a>

## ICustomDisplay.PrefabName Property

The name of the prefab that the model has within the Asset Bundle

```csharp
string PrefabName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')