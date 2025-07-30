#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## WindowColorSetter Class

Custom component used to easily keep track of Window Color themes and updating them

```csharp
public class WindowColorSetter
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; WindowColorSetter
### Fields

<a name='BTD_Mod_Helper.Api.Components.WindowColorSetter.image'></a>

## WindowColorSetter.image Field

The Image this is attached to

```csharp
public Image image;
```

#### Field Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Api.Components.WindowColorSetter.type'></a>

## WindowColorSetter.type Field

The panel type for determining the texture

```csharp
public PanelType type;
```

#### Field Value
[PanelType](BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType.md 'BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType')

<a name='BTD_Mod_Helper.Api.Components.WindowColorSetter.window'></a>

## WindowColorSetter.window Field

The window this is a part of, possibly null, in which case will follow the default color [BTD_Mod_Helper.MelonMain.CurrentDefaultWindowColor](https://docs.microsoft.com/en-us/dotnet/api/BTD_Mod_Helper.MelonMain.CurrentDefaultWindowColor 'BTD_Mod_Helper.MelonMain.CurrentDefaultWindowColor')

```csharp
public ModHelperWindow window;
```

#### Field Value
[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')
### Methods

<a name='BTD_Mod_Helper.Api.Components.WindowColorSetter.SetColor(string)'></a>

## WindowColorSetter.SetColor(string) Method

Change the image texture and pixel scale to a different WindowColor theme

```csharp
public void SetColor(string windowColor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.WindowColorSetter.SetColor(string).windowColor'></a>

`windowColor` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the WindowColor Name