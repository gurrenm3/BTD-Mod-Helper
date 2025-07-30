#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperWindow Class

A ModHelperComponent for a custom Window that can be opened in game and behaves similarly to a desktop Window

```csharp
public class ModHelperWindow : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperWindow
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.canvasGroup'></a>

## ModHelperWindow.canvasGroup Field

The CanvasGroup at the root of this Window

```csharp
public CanvasGroup canvasGroup;
```

#### Field Value
[UnityEngine.CanvasGroup](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.CanvasGroup 'UnityEngine.CanvasGroup')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.closeButton'></a>

## ModHelperWindow.closeButton Field

The button in the [topRightGroup](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup 'BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup') that can [Close()](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.Close() 'BTD_Mod_Helper.Api.Components.ModHelperWindow.Close()') the window

```csharp
public ModHelperButton closeButton;
```

#### Field Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.content'></a>

## ModHelperWindow.content Field

The main content panel of the Window

```csharp
public ModHelperPanel content;
```

#### Field Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.dockButton'></a>

## ModHelperWindow.dockButton Field

The button on the dock for the window, or null if this window doesn't use one

```csharp
public ModHelperDockButton dockButton;
```

#### Field Value
[ModHelperDockButton](BTD_Mod_Helper.Api.Components.ModHelperDockButton.md 'BTD_Mod_Helper.Api.Components.ModHelperDockButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.EdgeThreshold'></a>

## ModHelperWindow.EdgeThreshold Field

How close the mouse needs to be for resizing

```csharp
public const int EdgeThreshold = 10;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.icon'></a>

## ModHelperWindow.icon Field

The icon of this window, if it has one

```csharp
public ModHelperImage icon;
```

#### Field Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Margin'></a>

## ModHelperWindow.Margin Field

The default visual margin between elements

```csharp
public const int Margin = 25;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.minButton'></a>

## ModHelperWindow.minButton Field

The button in the [topRightGroup](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup 'BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup') that will Minimize the window

```csharp
public ModHelperButton minButton;
```

#### Field Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.minHeight'></a>

## ModHelperWindow.minHeight Field

The minimum height of this window when resizing

```csharp
public float minHeight;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.minWidth'></a>

## ModHelperWindow.minWidth Field

The minimum width of this window when resizing

```csharp
public float minWidth;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.noResizing'></a>

## ModHelperWindow.noResizing Field

Whether resizing is blocked for this window

```csharp
public bool noResizing;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.rightClickMenu'></a>

## ModHelperWindow.rightClickMenu Field

The options menu for the window

```csharp
public ModHelperPopupMenu rightClickMenu;
```

#### Field Value
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.settingsButton'></a>

## ModHelperWindow.settingsButton Field

The button in the [topRightGroup](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup 'BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup') that toggles the [rightClickMenu](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.rightClickMenu 'BTD_Mod_Helper.Api.Components.ModHelperWindow.rightClickMenu')

```csharp
public ModHelperButton settingsButton;
```

#### Field Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.title'></a>

## ModHelperWindow.title Field

The title of this window, if it has one

```csharp
public ModHelperText title;
```

#### Field Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.topBar'></a>

## ModHelperWindow.topBar Field

The top row of the window

```csharp
public ModHelperPanel topBar;
```

#### Field Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.topBarHeight'></a>

## ModHelperWindow.topBarHeight Field

The height of the topBar of the window

```csharp
public int topBarHeight;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.topCenterGroup'></a>

## ModHelperWindow.topCenterGroup Field

The center group of the top bar, which is by default empty

```csharp
public ModHelperPanel topCenterGroup;
```

#### Field Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.topLeftGroup'></a>

## ModHelperWindow.topLeftGroup Field

The left side group of the top bar, which by default features the Icon and window name

```csharp
public ModHelperPanel topLeftGroup;
```

#### Field Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.topRightGroup'></a>

## ModHelperWindow.topRightGroup Field

The right side group of the top bar, which by default features the Close / Options / Minimize buttons

```csharp
public ModHelperPanel topRightGroup;
```

#### Field Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ColorOption'></a>

## ModHelperWindow.ColorOption Property

The color option within the options menu

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupOption ColorOption { get; }
```

#### Property Value
[ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.IsMinimized'></a>

## ModHelperWindow.IsMinimized Property

Whether this window is minimized or not

```csharp
public bool IsMinimized { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.LockOption'></a>

## ModHelperWindow.LockOption Property

The lock / unlock option within the options menu

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupOption LockOption { get; }
```

#### Property Value
[ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ModWindow'></a>

## ModHelperWindow.ModWindow Property

The ModWindow definition used for this window, if any

```csharp
public BTD_Mod_Helper.Api.UI.ModWindow ModWindow { get; set; }
```

#### Property Value
[ModWindow](BTD_Mod_Helper.Api.UI.ModWindow.md 'BTD_Mod_Helper.Api.UI.ModWindow')

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.WindowColor'></a>

## ModHelperWindow.WindowColor Property

The current WindowColor theme of this window

```csharp
public BTD_Mod_Helper.Api.UI.ModWindowColor WindowColor { get; set; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ApplyWindowColor(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType)'></a>

## ModHelperWindow.ApplyWindowColor(GameObject, PanelType) Method

Applies the current window color to a game object and keeps track of it as part of this window

```csharp
public void ApplyWindowColor(GameObject gobject, BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType type);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ApplyWindowColor(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).gobject'></a>

`gobject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

Game object that has an Image component

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ApplyWindowColor(GameObject,BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType).type'></a>

`type` [PanelType](BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType.md 'BTD_Mod_Helper.Api.UI.ModWindowColor.PanelType')

panel type

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Close()'></a>

## ModHelperWindow.Close() Method

Closes this Window

```csharp
public void Close();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string)'></a>

## ModHelperWindow.Create(Info, int, string, string, float, string) Method

Creates a ModHelperWindow gameobject and adds it to the appropriate parent object for Windows.  
Also creates a corresponding [ModHelperDockButton](BTD_Mod_Helper.Api.Components.ModHelperDockButton.md 'BTD_Mod_Helper.Api.Components.ModHelperDockButton') within the [ModHelperDock](BTD_Mod_Helper.Api.Components.ModHelperDock.md 'BTD_Mod_Helper.Api.Components.ModHelperDock')

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperWindow Create(BTD_Mod_Helper.Api.Components.Info info, int topBarHeight=50, string icon=null, string title=null, float iconScale=1f, string dockTitle=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

the position / size / name info

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).topBarHeight'></a>

`topBarHeight` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

the height of the top bar

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the icon to display, or null for none

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).title'></a>

`title` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

the title to display, or null for none

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).iconScale'></a>

`iconScale` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

visual scale for the icon

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.Components.Info,int,string,string,float,string).dockTitle'></a>

`dockTitle` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

title for the dock button

#### Returns
[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')  
the created ModHelperWindow

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.UI.ModWindow)'></a>

## ModHelperWindow.Create(ModWindow) Method

Creates a ModHelperWindow gameobject from a ModWindow definition

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperWindow Create(BTD_Mod_Helper.Api.UI.ModWindow modWindow);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.Create(BTD_Mod_Helper.Api.UI.ModWindow).modWindow'></a>

`modWindow` [ModWindow](BTD_Mod_Helper.Api.UI.ModWindow.md 'BTD_Mod_Helper.Api.UI.ModWindow')

ModWindow definition

#### Returns
[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')  
the created ModHelperWindow

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.OpenRightClickMenu()'></a>

## ModHelperWindow.OpenRightClickMenu() Method

Open the Options Menu for this window at the current mouse position. Will handle changing the menu's position  
if it would be off screen

```csharp
public void OpenRightClickMenu();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ToggleLocked()'></a>

## ModHelperWindow.ToggleLocked() Method

Toggles whether this window is Locked, and cant be moved / resized / left clicked normally

```csharp
public void ToggleLocked();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.ToggleMinimized()'></a>

## ModHelperWindow.ToggleMinimized() Method

Toggles whether this window is minimized to the dock

```csharp
public void ToggleMinimized();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.UpdateWindowColor(string)'></a>

## ModHelperWindow.UpdateWindowColor(string) Method

Updates the WindowColor theme for this window

```csharp
public void UpdateWindowColor(string newColor);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperWindow.UpdateWindowColor(string).newColor'></a>

`newColor` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

new WindowColor theme