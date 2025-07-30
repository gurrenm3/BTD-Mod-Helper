#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperDock Class

ModHelperComponent controlling the Dock used for [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')s

```csharp
public sealed class ModHelperDock : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperDock
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.canvasGroup'></a>

## ModHelperDock.canvasGroup Field

The canvas group for the dock

```csharp
public CanvasGroup canvasGroup;
```

#### Field Value
[UnityEngine.CanvasGroup](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.CanvasGroup 'UnityEngine.CanvasGroup')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.startButton'></a>

## ModHelperDock.startButton Field

The plus button that opens the start menu, or null if there are no start menu entries

```csharp
public ModHelperButton startButton;
```

#### Field Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.startMenu'></a>

## ModHelperDock.startMenu Field

The menu opened which lists the available windows, or null if there are no start menu entries

```csharp
public ModHelperPopupMenu startMenu;
```

#### Field Value
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.Instance'></a>

## ModHelperDock.Instance Property

Current instance of the Dock

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDock Instance { get; set; }
```

#### Property Value
[ModHelperDock](BTD_Mod_Helper.Api.Components.ModHelperDock.md 'BTD_Mod_Helper.Api.Components.ModHelperDock')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.WindowParent'></a>

## ModHelperDock.WindowParent Property

Parent object that windows are added to

```csharp
public static RectTransform WindowParent { get; set; }
```

#### Property Value
[UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperDock.OnUpdate()'></a>

## ModHelperDock.OnUpdate() Method

Unity Component OnUpdate

```csharp
protected override void OnUpdate();
```