#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperPopupOption Class

An option for a [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

```csharp
public class ModHelperPopupOption : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperPopupOption
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.hideAllParentsOnClick'></a>

## ModHelperPopupOption.hideAllParentsOnClick Field

Whether to hide ALL parent menus when this option is pressed

```csharp
public bool hideAllParentsOnClick;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.hideParentOnClick'></a>

## ModHelperPopupOption.hideParentOnClick Field

Whether to hide the parent menu when this option is pressed

```csharp
public bool hideParentOnClick;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.icon'></a>

## ModHelperPopupOption.icon Field

The icon for the option

```csharp
public ModHelperImage icon;
```

#### Field Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.parentMenu'></a>

## ModHelperPopupOption.parentMenu Field

The parent pop up menu if this is a sub option

```csharp
public ModHelperPopupMenu parentMenu;
```

#### Field Value
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.subMenu'></a>

## ModHelperPopupOption.subMenu Field

The sub popup menu that this leads to, or null

```csharp
public ModHelperPopupMenu subMenu;
```

#### Field Value
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.text'></a>

## ModHelperPopupOption.text Field

The label for the option

```csharp
public ModHelperText text;
```

#### Field Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.toggle'></a>

## ModHelperPopupOption.toggle Field

The Toggle component for the option

```csharp
public Toggle toggle;
```

#### Field Value
[UnityEngine.UI.Toggle](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Toggle 'UnityEngine.UI.Toggle')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.AddSubMenu(BTD_Mod_Helper.Api.Components.Info)'></a>

## ModHelperPopupOption.AddSubMenu(Info) Method

Adds a submenu to to this option

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupMenu AddSubMenu(BTD_Mod_Helper.Api.Components.Info info);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.AddSubMenu(BTD_Mod_Helper.Api.Components.Info).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

#### Returns
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')  
this option

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.AddSubMenu(BTD_Mod_Helper.Api.Components.ModHelperPopupMenu)'></a>

## ModHelperPopupOption.AddSubMenu(ModHelperPopupMenu) Method

Adds a submenu to to this option

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPopupOption AddSubMenu(BTD_Mod_Helper.Api.Components.ModHelperPopupMenu menu);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.AddSubMenu(BTD_Mod_Helper.Api.Components.ModHelperPopupMenu).menu'></a>

`menu` [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

The popup menu to use

#### Returns
[ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')  
this option

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_)'></a>

## ModHelperPopupOption.Create(Info, string, string, UnityAction, ModHelperPopupMenu, Func<bool>, Func<bool>) Method

Constructs a new option for a popupmenu

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperPopupOption Create(BTD_Mod_Helper.Api.Components.Info info, string text=null, string icon=null, UnityAction action=null, BTD_Mod_Helper.Api.Components.ModHelperPopupMenu subMenu=null, Func<bool> isSelected=null, Func<bool> isHidden=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The info to use for its size, if no Height is set, 75 will be used

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Option label, if null then uses the Name from the info

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Option icon, null for no icon, empty string for still creating the icon but it being empty

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).action'></a>

`action` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when this option is clicked

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).subMenu'></a>

`subMenu` [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

Sub menu that this option opens

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).isSelected'></a>

`isSelected` [Il2CppSystem.Func](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Func 'Il2CppSystem.Func')

Function to determine if this option should display as selected or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.Create(BTD_Mod_Helper.Api.Components.Info,string,string,UnityAction,BTD_Mod_Helper.Api.Components.ModHelperPopupMenu,Func_bool_,Func_bool_).isHidden'></a>

`isHidden` [Il2CppSystem.Func](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Func 'Il2CppSystem.Func')

Function to determine if this option should be visible or should be hidden

#### Returns
[ModHelperPopupOption](BTD_Mod_Helper.Api.Components.ModHelperPopupOption.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupOption')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.FixSubMenuPosition()'></a>

## ModHelperPopupOption.FixSubMenuPosition() Method

Fixes the submenu position to not be off screen

```csharp
public void FixSubMenuPosition();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.HideSubMenu()'></a>

## ModHelperPopupOption.HideSubMenu() Method

Hides the sub menu for this option, if there is one

```csharp
public void HideSubMenu();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.SetSelected(bool)'></a>

## ModHelperPopupOption.SetSelected(bool) Method

Sets whether this option is selected

```csharp
public void SetSelected(bool selected);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.SetSelected(bool).selected'></a>

`selected` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopupOption.ShowSubMenu()'></a>

## ModHelperPopupOption.ShowSubMenu() Method

Shows the sub menu for this option, if there is one

```csharp
public void ShowSubMenu();
```