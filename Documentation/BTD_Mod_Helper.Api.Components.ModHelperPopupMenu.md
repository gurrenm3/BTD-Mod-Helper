#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperPopupMenu Class

ModHelperComponent for a PopUp menu similar to desktop right click menus

```csharp
public class ModHelperPopupMenu : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperPopupMenu
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.autoHide'></a>

## ModHelperPopupMenu.autoHide Field

Whether the menu should automatically hide when a click happens elsewhere

```csharp
public bool autoHide;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.parentComponent'></a>

## ModHelperPopupMenu.parentComponent Field

The parent object that this is for, used for determining if clicks elsewhere will auto hide the menu or not

```csharp
public ModHelperComponent parentComponent;
```

#### Field Value
[ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.IsShowing'></a>

## ModHelperPopupMenu.IsShowing Property

Whether this menu is open or not

```csharp
public bool IsShowing { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Options'></a>

## ModHelperPopupMenu.Options Property

The current [ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')s in the menu

```csharp
public System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.Components.ModHelperPopupOption> Options { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_)'></a>

## ModHelperPopupMenu.AddOption(Info, string, string, UnityAction, ModHelperPopupMenu, Func<bool>) Method

Add an option to the menu

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupMenu AddOption(BTD_Mod_Helper.Api.Components.Info info, string text=null, string icon=null, UnityAction action=null, BTD_Mod_Helper.Api.Components.ModHelperPopupMenu subMenu=null, Func<bool> isSelected=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The info to use for its size, if no Height is set, 75 will be used

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Option label, if null then uses the Name from the info

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Option icon, null for no icon, empty string for still creating the icon but it being empty

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).action'></a>

`action` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when this option is clicked

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).subMenu'></a>

`subMenu` [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

Sub menu that this option opens

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_).isSelected'></a>

`isSelected` [Il2CppSystem.Func](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Func 'Il2CppSystem.Func')

Function to determine if this option should display as selected or not

#### Returns
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')  
this

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.ModHelperPopupOption)'></a>

## ModHelperPopupMenu.AddOption(ModHelperPopupOption) Method

Add an option to the menu

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupMenu AddOption(BTD_Mod_Helper.Api.Components.ModHelperPopupOption option);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddOption(BTD_Mod_Helper.Api.Components.ModHelperPopupOption).option'></a>

`option` [ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')

Option to add

#### Returns
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')  
this

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddSeparator(int)'></a>

## ModHelperPopupMenu.AddSeparator(int) Method

Adds a horizontal separation line to the menu

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupMenu AddSeparator(int height=2);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.AddSeparator(int).height'></a>

`height` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')  
this

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Create(BTD_Mod_Helper.Api.Components.Info,bool)'></a>

## ModHelperPopupMenu.Create(Info, bool) Method

Constructs a new PopUp Menu, and makes it inactive to start

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperPopupMenu Create(BTD_Mod_Helper.Api.Components.Info info, bool fitSize=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Create(BTD_Mod_Helper.Api.Components.Info,bool).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

the initial info for the menu

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Create(BTD_Mod_Helper.Api.Components.Info,bool).fitSize'></a>

`fitSize` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

whether to use a [UnityEngine.UI.ContentSizeFitter](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.ContentSizeFitter 'UnityEngine.UI.ContentSizeFitter')

#### Returns
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')  
the created menu

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Hide(bool)'></a>

## ModHelperPopupMenu.Hide(bool) Method

Hide the menu

```csharp
public void Hide(bool propagate=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Hide(bool).propagate'></a>

`propagate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.Show()'></a>

## ModHelperPopupMenu.Show() Method

Show the menu

```csharp
public void Show();
```