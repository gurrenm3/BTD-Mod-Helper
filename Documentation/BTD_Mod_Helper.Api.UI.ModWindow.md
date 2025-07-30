#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.UI](README.md#BTD_Mod_Helper.Api.UI 'BTD_Mod_Helper.Api.UI')

## ModWindow Class

Defines a kind of Window that can be opened in game from the custom Mod Helper start menu with specific name and content

```csharp
public abstract class ModWindow : BTD_Mod_Helper.Api.UI.ModStartMenuEntry
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModStartMenuEntry](BTD_Mod_Helper.Api.UI.ModStartMenuEntry.md 'BTD_Mod_Helper.Api.UI.ModStartMenuEntry') &#129106; ModWindow

Derived  
&#8627; [ModWindow&lt;T&gt;](BTD_Mod_Helper.Api.UI.ModWindow_T_.md 'BTD_Mod_Helper.Api.UI.ModWindow<T>')
### Properties

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ActiveWindows'></a>

## ModWindow.ActiveWindows Property

All window instances that have been opened for this type of ModWindow and are currently not minimized

```csharp
public System.Collections.Generic.IReadOnlyList<BTD_Mod_Helper.Api.Components.ModHelperWindow> ActiveWindows { get; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.AllowMultiple'></a>

## ModWindow.AllowMultiple Property

Whether to allow more than one of this window to be opened at once

```csharp
public virtual bool AllowMultiple { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.AllowResizing'></a>

## ModWindow.AllowResizing Property

Whether the user should be able to resize the window

```csharp
public virtual bool AllowResizing { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.DefaultHeight'></a>

## ModWindow.DefaultHeight Property

Default height of the window

```csharp
public virtual int DefaultHeight { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.DefaultWidth'></a>

## ModWindow.DefaultWidth Property

Default width of the window

```csharp
public virtual int DefaultWidth { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.DefaultWindowColor'></a>

## ModWindow.DefaultWindowColor Property

Override to change the default window color to something other than the user's defined default

```csharp
public virtual BTD_Mod_Helper.Api.UI.ModWindowColor DefaultWindowColor { get; }
```

#### Property Value
[ModWindowColor](BTD_Mod_Helper.Api.UI.ModWindowColor.md 'BTD_Mod_Helper.Api.UI.ModWindowColor')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.DockButtonWidth'></a>

## ModWindow.DockButtonWidth Property

Width of the button in the dock for this Window

```csharp
public virtual int DockButtonWidth { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.DockName'></a>

## ModWindow.DockName Property

What name this should display within the Dock. It's a small space by default, so the shorter the better. null for no text

```csharp
public virtual string DockName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.HideOverlappingTopBarItems'></a>

## ModWindow.HideOverlappingTopBarItems Property

Whether to hide top bar elements when the window is sized too small so they would overlap

```csharp
public virtual bool HideOverlappingTopBarItems { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.MinimumHeight'></a>

## ModWindow.MinimumHeight Property

Minimum height of the window when resizing

```csharp
public virtual int MinimumHeight { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.MinimumWidth'></a>

## ModWindow.MinimumWidth Property

Minimum width of the window when resizing

```csharp
public virtual int MinimumWidth { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OpenedWindows'></a>

## ModWindow.OpenedWindows Property

All window instances that have been opened for this type of ModWindow. They may be minimized

```csharp
public System.Collections.Generic.IReadOnlyList<BTD_Mod_Helper.Api.Components.ModHelperWindow> OpenedWindows { get; }
```

#### Property Value
[System.Collections.Generic.IReadOnlyList&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IReadOnlyList-1 'System.Collections.Generic.IReadOnlyList`1')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.RotateDockIcon'></a>

## ModWindow.RotateDockIcon Property

Whether to rotate the dock icon so that it's facing upwards in the 16x9 aspect ratio dock setup

```csharp
public virtual bool RotateDockIcon { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ShowIconInDock'></a>

## ModWindow.ShowIconInDock Property

Whether the dock entry should show the icon

```csharp
public virtual bool ShowIconInDock { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ShowIconOnWindow'></a>

## ModWindow.ShowIconOnWindow Property

Whether the window should show its icon in the upper left

```csharp
public virtual bool ShowIconOnWindow { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ShowTitleOnWindow'></a>

## ModWindow.ShowTitleOnWindow Property

Whether the window should show its title in the upper left

```csharp
public virtual bool ShowTitleOnWindow { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.TopBarHeight'></a>

## ModWindow.TopBarHeight Property

Height of the top bar of the window which has the Close, Settings, and Minimize buttons by default

```csharp
public virtual int TopBarHeight { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.UI.ModWindow.WindowInfo'></a>

## ModWindow.WindowInfo Property

The Mod Helper [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info') used to initially define the [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

```csharp
public virtual BTD_Mod_Helper.Api.Components.Info WindowInfo { get; }
```

#### Property Value
[Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')
### Methods

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ModifyOptionsMenu(BTD_Mod_Helper.Api.Components.ModHelperWindow,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu)'></a>

## ModWindow.ModifyOptionsMenu(ModHelperWindow, ModHelperPopupMenu) Method

Modifies the content of the options / Right Click menu for the window. This happens after [ModifyWindow(ModHelperWindow)](BTD_Mod_Helper.Api.UI.ModWindow.md#BTD_Mod_Helper.Api.UI.ModWindow.ModifyWindow(BTD_Mod_Helper.Api.Components.ModHelperWindow) 'BTD_Mod_Helper.Api.UI.ModWindow.ModifyWindow(BTD_Mod_Helper.Api.Components.ModHelperWindow)')

```csharp
public virtual void ModifyOptionsMenu(BTD_Mod_Helper.Api.Components.ModHelperWindow window, BTD_Mod_Helper.Api.Components.ModHelperPopupMenu menu);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ModifyOptionsMenu(BTD_Mod_Helper.Api.Components.ModHelperWindow,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ModifyOptionsMenu(BTD_Mod_Helper.Api.Components.ModHelperWindow,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu).menu'></a>

`menu` [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

the right click menu

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ModifyWindow(BTD_Mod_Helper.Api.Components.ModHelperWindow)'></a>

## ModWindow.ModifyWindow(ModHelperWindow) Method

Modifies the initial content of the window.  
Adding UI to [content](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.content 'BTD_Mod_Helper.Api.Components.ModHelperWindow.content') and [topLeftGroup](BTD_Mod_Helper.Api.Components.ModHelperWindow.md#BTD_Mod_Helper.Api.Components.ModHelperWindow.topLeftGroup 'BTD_Mod_Helper.Api.Components.ModHelperWindow.topLeftGroup') is most common

```csharp
public abstract void ModifyWindow(BTD_Mod_Helper.Api.Components.ModHelperWindow window);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.ModifyWindow(BTD_Mod_Helper.Api.Components.ModHelperWindow).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance being created

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnClose(BTD_Mod_Helper.Api.Components.ModHelperWindow)'></a>

## ModWindow.OnClose(ModHelperWindow) Method

Called when the window is closed

```csharp
public virtual void OnClose(BTD_Mod_Helper.Api.Components.ModHelperWindow window);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnClose(BTD_Mod_Helper.Api.Components.ModHelperWindow).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow)'></a>

## ModWindow.OnMinimized(ModHelperWindow) Method

Called when the window is minimized to the dock

```csharp
public virtual void OnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow window);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMove(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2)'></a>

## ModWindow.OnMove(ModHelperWindow, Vector2, Vector2) Method

Called each frame while a window is being moved around by a user

```csharp
public virtual void OnMove(BTD_Mod_Helper.Api.Components.ModHelperWindow window, Vector2 oldPos, Vector2 newPos);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMove(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMove(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).oldPos'></a>

`oldPos` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

the old position of the window

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnMove(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).newPos'></a>

`newPos` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

the new position of the window

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnResize(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2)'></a>

## ModWindow.OnResize(ModHelperWindow, Vector2, Vector2) Method

Called each frame while a window is being resized by the user

```csharp
public virtual void OnResize(BTD_Mod_Helper.Api.Components.ModHelperWindow window, Vector2 oldSize, Vector2 newSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnResize(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnResize(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).oldSize'></a>

`oldSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

the old height and width of the window

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnResize(BTD_Mod_Helper.Api.Components.ModHelperWindow,Vector2,Vector2).newSize'></a>

`newSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

the new height and width of the window

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnUnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow)'></a>

## ModWindow.OnUnMinimized(ModHelperWindow) Method

Called when the window is unminimized from the deck

```csharp
public virtual void OnUnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow window);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnUnMinimized(BTD_Mod_Helper.Api.Components.ModHelperWindow).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnUpdate()'></a>

## ModWindow.OnUpdate() Method

Called once each frame as long as any window of this type is open  
<seealso cref="P:BTD_Mod_Helper.Api.UI.ModWindow.OpenedWindows"/>

```csharp
public virtual void OnUpdate();
```

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnUpdate(BTD_Mod_Helper.Api.Components.ModHelperWindow)'></a>

## ModWindow.OnUpdate(ModHelperWindow) Method

Called each frame for each window that is Open / Unminimized

```csharp
public virtual void OnUpdate(BTD_Mod_Helper.Api.Components.ModHelperWindow window);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.UI.ModWindow.OnUpdate(BTD_Mod_Helper.Api.Components.ModHelperWindow).window'></a>

`window` [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')

the ModHelperWindow instance

<a name='BTD_Mod_Helper.Api.UI.ModWindow.Open()'></a>

## ModWindow.Open() Method

Opens a new [ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow') for this window in game

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperWindow Open();
```

#### Returns
[ModHelperWindow](BTD_Mod_Helper.Api.Components.ModHelperWindow.md 'BTD_Mod_Helper.Api.Components.ModHelperWindow')  
the ModModHelperWindow

<a name='BTD_Mod_Helper.Api.UI.ModWindow.StartMenuEntryClicked()'></a>

## ModWindow.StartMenuEntryClicked() Method

What to do when the start menu entry is clicked. Not called if this has child entries

```csharp
public override void StartMenuEntryClicked();
```