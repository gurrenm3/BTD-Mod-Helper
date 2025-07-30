#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperPopdown Class

A ModHelperComponent for a dropdown menu that utilizes a [ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')

```csharp
public class ModHelperPopdown : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperPopdown
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.autosize'></a>

## ModHelperPopdown.autosize Field

Whether to automatically size the component that opens the dropdown based on the text width

```csharp
public bool autosize;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.dropdown'></a>

## ModHelperPopdown.dropdown Field

The component which handles the dropdown

```csharp
public TMP_Dropdown dropdown;
```

#### Field Value
[Il2CppTMPro.TMP_Dropdown](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TMP_Dropdown 'Il2CppTMPro.TMP_Dropdown')

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.menu'></a>

## ModHelperPopdown.menu Field

The popup menu used

```csharp
public ModHelperPopupMenu menu;
```

#### Field Value
[ModHelperPopupMenu](BTD_Mod_Helper.Api.Components.ModHelperPopupMenu.md 'BTD_Mod_Helper.Api.Components.ModHelperPopupMenu')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool)'></a>

## ModHelperPopdown.Create(Info, Vector2, List<string>, UnityAction<int>, Vector2, float, string, Vector2, List<string>, bool) Method

Constructs a new popup menu dropdown

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperPopdown Create(BTD_Mod_Helper.Api.Components.Info info, Vector2 itemSize, List<string> options, UnityAction<int> onValueChanged, Vector2 direction=default(Vector2), float labelFontSize=42f, string background=null, Vector2 menuOffset=default(Vector2), List<string> images=null, bool autosize=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

the initial info to use, should have a Height defined

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).itemSize'></a>

`itemSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

size of each option in the popup menu (before margins/padding)

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

the labels for the options

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

called when an option is selected, index passed in

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).direction'></a>

`direction` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

the direction of the dropdown, Vector2.down or Vector2.up will be the most used

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).labelFontSize'></a>

`labelFontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

text size for label

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

background image, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).menuOffset'></a>

`menuOffset` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

position offset for the menu

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).images'></a>

`images` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

images guids to use for the options

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.Create(BTD_Mod_Helper.Api.Components.Info,Vector2,List_string_,UnityAction_int_,Vector2,float,string,Vector2,List_string_,bool).autosize'></a>

`autosize` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[autosize](BTD_Mod_Helper.Api.Components.ModHelperPopdown.md#BTD_Mod_Helper.Api.Components.ModHelperPopdown.autosize 'BTD_Mod_Helper.Api.Components.ModHelperPopdown.autosize')

#### Returns
[ModHelperPopdown](BTD_Mod_Helper.Api.Components.ModHelperPopdown.md 'BTD_Mod_Helper.Api.Components.ModHelperPopdown')  
the created popdown

<a name='BTD_Mod_Helper.Api.Components.ModHelperPopdown.OnUpdate()'></a>

## ModHelperPopdown.OnUpdate() Method

Unity Component OnUpdate

```csharp
protected override void OnUpdate();
```