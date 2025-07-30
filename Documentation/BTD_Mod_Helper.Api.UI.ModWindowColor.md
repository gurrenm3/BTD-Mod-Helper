#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModWindowColor Class

Defines a Window Color theme for [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')s and related UI components

```csharp
public abstract class ModWindowColor : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModWindowColor
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Blue'></a>

## ModWindowColor.Blue Property

Blue

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Blue { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Bronze'></a>

## ModWindowColor.Bronze Property

Bronze

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Bronze { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Brown'></a>

## ModWindowColor.Brown Property

Brown

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Brown { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.DarkBlue'></a>

## ModWindowColor.DarkBlue Property

Dark Blue

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor DarkBlue { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Glass'></a>

## ModWindowColor.Glass Property

Glass

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Glass { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Hematite'></a>

## ModWindowColor.Hematite Property

Hematite

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Hematite { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.InsertPanelPixelMult'></a>

## ModWindowColor.InsertPanelPixelMult Property

For insert panels, a multiplier to the [UnityEngine.UI.Image.pixelsPerUnitMultiplier](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image.pixelsPerUnitMultiplier 'UnityEngine.UI.Image.pixelsPerUnitMultiplier') to change the scale

```csharp
public virtual float InsertPanelPixelMult { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.InsertPanelSprite'></a>

## ModWindowColor.InsertPanelSprite Property

Sprite to use for the "insert" or sub-panels of windows that are nested in the outer panels

```csharp
public abstract string InsertPanelSprite { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.MainPanelSprite'></a>

## ModWindowColor.MainPanelSprite Property

Sprite to use for the main panels of windows

```csharp
public abstract string MainPanelSprite { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.PanelPixelMult'></a>

## ModWindowColor.PanelPixelMult Property

For main panels, a multiplier to the [UnityEngine.UI.Image.pixelsPerUnitMultiplier](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image.pixelsPerUnitMultiplier 'UnityEngine.UI.Image.pixelsPerUnitMultiplier') to change the scale

```csharp
public virtual float PanelPixelMult { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Purple'></a>

## ModWindowColor.Purple Property

Purple

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Purple { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Silver'></a>

## ModWindowColor.Silver Property

Silver

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Silver { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')
### Methods

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Apply(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType)'></a>

## ModWindowColor.Apply(GameObject, PanelType) Method

Apply this color to a specific image for a given panel type via a [WindowColorSetter](BTD_Mod_Helper.Api.Components.WindowColorSetter.md 'BTD_Mod_Helper.Api.Components.WindowColorSetter') component

```csharp
public BTD_Mod_Helper.Api.Components.WindowColorSetter Apply(GameObject gobject, BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Apply(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).gobject'></a>

`gobject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

GameObject that has an Image component

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Apply(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).type'></a>

`type` [PanelType](BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType.md 'BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType')

panel type

#### Returns
[WindowColorSetter](BTD_Mod_Helper.Api.Components.WindowColorSetter.md 'BTD_Mod_Helper.Api.Components.WindowColorSetter')  
the added WindowColorSetter component

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.GetPixelMult(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType)'></a>

## ModWindowColor.GetPixelMult(PanelType) Method

Get the corresponding pixels per unit multiplier for a given panel type

```csharp
public float GetPixelMult(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.GetPixelMult(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).type'></a>

`type` [PanelType](BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType.md 'BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType')

panel type

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')  
pixels per unit multiplier

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.GetSprite(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType)'></a>

## ModWindowColor.GetSprite(PanelType) Method

Get the corresponding sprite to use for a given panel type

```csharp
public string GetSprite(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.GetSprite(BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).type'></a>

`type` [PanelType](BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType.md 'BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType')

panel type

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
sprite guid

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Of(string)'></a>

## ModWindowColor.Of(string) Method

Gets a ModWindowColor instance from its [Name](BTD_Mod_Helper.Api.ModContent.md#BTD_Mod_Helper.Api.ModContent.Name 'BTD_Mod_Helper.Api.ModContent.Name')

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor Of(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.Of(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the mod content name

#### Returns
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')  
ModWindowColor instance, Blue if no name match
### Operators

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.op_ImplicitBTD_Mod_Helper.Api.UI.ModWindowColor(string)'></a>

## ModWindowColor.implicit operator ModWindowColor(string) Operator

Implicitly converts a string into the corresponding ModWindowColor instance

```csharp
public static BTD_Mod_Helper.Api.UI.ModWindowColor implicit operator ModWindowColor(string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.op_ImplicitBTD_Mod_Helper.Api.UI.ModWindowColor(string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the mod content name

#### Returns
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')  
ModWindowColor instance

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.op_Implicitstring(BTD_Mod_Helper.Api.UI.ModWindowColor)'></a>

## ModWindowColor.implicit operator string(ModWindowColor) Operator

Implicitly turns a ModWindowColor isntance into its Name

```csharp
public static string implicit operator string(BTD_Mod_Helper.Api.UI.ModWindowColor modWindowColor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindowColor.op_Implicitstring(BTD_Mod_Helper.Api.UI.ModWindowColor).modWindowColor'></a>

`modWindowColor` [ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

mod window color instance

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
its name