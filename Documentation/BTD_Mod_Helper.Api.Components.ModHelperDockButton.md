#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperDockButton Class

```csharp
public sealed class ModHelperDockButton : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperDockButton
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.button'></a>

## ModHelperDockButton.button Field

The button component

```csharp
public ModHelperButton button;
```

#### Field Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.icon'></a>

## ModHelperDockButton.icon Field

The icon of this button, if any

```csharp
public ModHelperImage icon;
```

#### Field Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Size'></a>

## ModHelperDockButton.Size Field

Constant amount of size that Dock buttons have based on the 16x9 aspect ratio border bars

```csharp
public const int Size = 50;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.text'></a>

## ModHelperDockButton.text Field

The label

```csharp
public ModHelperText text;
```

#### Field Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.window'></a>

## ModHelperDockButton.window Field

The window this corresponds to

```csharp
public ModHelperWindow window;
```

#### Field Value
[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string)'></a>

## ModHelperDockButton.Create(ModHelperPanel, ModHelperWindow, string, float, string) Method

Creates a new Dock button for a window

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDockButton Create(BTD_Mod_Helper.Api.Components.ModHelperPanel parent, BTD_Mod_Helper.Api.Components.ModHelperWindow window, string icon=null, float iconScale=1f, string dockTitle=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string).parent'></a>

`parent` [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

Parent panel of the button

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

window the button will correspond to

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

icon to use for the button

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string).iconScale'></a>

`iconScale` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

visual scale for the icon

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.Create(BTD_Mod_Helper.Api.Components.ModHelperPanel,BTD_Mod_Helper.Api.Components.ModHelperWindow,string,float,string).dockTitle'></a>

`dockTitle` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

title for the dock button

#### Returns
[ModHelperDockButton](BTD_Mod_Helper.Api.Components.ModHelperDockButton.md 'BTD_Mod_Helper.Api.Components.ModHelperDockButton')  
the created dock button

<a name='BTD_Mod_Helper.Api.Components.ModHelperDockButton.OnClick()'></a>

## ModHelperDockButton.OnClick() Method

When the button is clicked

```csharp
public void OnClick();
```