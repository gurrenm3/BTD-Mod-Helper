#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## AspectRatios Class

The aspect ratios BTD6 runs at natively

```csharp
public static class AspectRatios
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AspectRatios
### Properties

<a name='BTD_Mod_Helper.Api.UI.AspectRatios.Current'></a>

## AspectRatios.Current Property

The current AspectRatio the game is running at

```csharp
public static BTD_Mod_Helper.Api.UI.AspectRatio Current { get; }
```

#### Property Value
[AspectRatio](BTD_Mod_Helper.Api.UI.AspectRatio.md 'BTD_Mod_Helper.Api.UI.AspectRatio')
### Methods

<a name='BTD_Mod_Helper.Api.UI.AspectRatios.From(int,int)'></a>

## AspectRatios.From(int, int) Method

Gets the BTD6 aspect ratio based on the screen width and height

```csharp
public static BTD_Mod_Helper.Api.UI.AspectRatio From(int width, int height);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.AspectRatios.From(int,int).width'></a>

`width` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

screen width

<a name='BTD_Mod_Helper.Api.UI.AspectRatios.From(int,int).height'></a>

`height` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

screen height

#### Returns
[AspectRatio](BTD_Mod_Helper.Api.UI.AspectRatio.md 'BTD_Mod_Helper.Api.UI.AspectRatio')  
aspect ratio