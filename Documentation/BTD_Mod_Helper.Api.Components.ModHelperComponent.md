#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperComponent Class

Base for a helper component for making custom UIs in the same style as Vanilla ones

```csharp
public class ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; ModHelperComponent

Derived  
&#8627; [ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')  
&#8627; [ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
&#8627; [ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
&#8627; [ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
&#8627; [ModHelperInputField](BTD_Mod_Helper.Api.Components.ModHelperInputField.md 'BTD_Mod_Helper.Api.Components.ModHelperInputField')  
&#8627; [ModHelperOption](BTD_Mod_Helper.Api.Components.ModHelperOption.md 'BTD_Mod_Helper.Api.Components.ModHelperOption')  
&#8627; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')  
&#8627; [ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')  
&#8627; [ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.DefaultFontSize'></a>

## ModHelperComponent.DefaultFontSize Field

Default font size for UI labels

```csharp
public const float DefaultFontSize = 42;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.DefaultTextAlignment'></a>

## ModHelperComponent.DefaultTextAlignment Field

Default alignment for texts and input fields

```csharp
public const TextAlignmentOptions DefaultTextAlignment = 4098;
```

#### Field Value
[Il2CppTMPro.TextAlignmentOptions](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TextAlignmentOptions 'Il2CppTMPro.TextAlignmentOptions')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.disableNextFrame'></a>

## ModHelperComponent.disableNextFrame Field

Bool for if this should disable itself on the next frame

```csharp
public bool disableNextFrame;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.enableNextFrame'></a>

## ModHelperComponent.enableNextFrame Field

Bool for if this should enable itself on the next frame

```csharp
public bool enableNextFrame;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.initialInfo'></a>

## ModHelperComponent.initialInfo Field

The Info object that this was defined with, determining its initial name, position and size

```csharp
public Info initialInfo;
```

#### Field Value
[Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.LayoutElement'></a>

## ModHelperComponent.LayoutElement Property

The LayoutElement component, if this has been assigned one

```csharp
public LayoutElement LayoutElement { get; }
```

#### Property Value
[UnityEngine.UI.LayoutElement](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.LayoutElement 'UnityEngine.UI.LayoutElement')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.LayoutGroup'></a>

## ModHelperComponent.LayoutGroup Property

The LayoutGroup component, if this has been assigned one

```csharp
public HorizontalOrVerticalLayoutGroup LayoutGroup { get; }
```

#### Property Value
[UnityEngine.UI.HorizontalOrVerticalLayoutGroup](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.HorizontalOrVerticalLayoutGroup 'UnityEngine.UI.HorizontalOrVerticalLayoutGroup')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.parent'></a>

## ModHelperComponent.parent Property

The ModHelperComponent that this is a child of, if any

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperComponent parent { get; }
```

#### Property Value
[ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.RectTransform'></a>

## ModHelperComponent.RectTransform Property

The RectTransform for this GameObject

```csharp
public RectTransform RectTransform { get; }
```

#### Property Value
[UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.Add_T_(T)'></a>

## ModHelperComponent.Add<T>(T) Method

Adds another ModHelperComponent as a child of this, returning the child

```csharp
public T Add<T>(T child)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.Add_T_(T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.Add_T_(T).child'></a>

`child` [T](BTD_Mod_Helper.Api.Components.ModHelperComponent.md#BTD_Mod_Helper.Api.Components.ModHelperComponent.Add_T_(T).T 'BTD_Mod_Helper.Api.Components.ModHelperComponent.Add<T>(T).T')

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperComponent.md#BTD_Mod_Helper.Api.Components.ModHelperComponent.Add_T_(T).T 'BTD_Mod_Helper.Api.Components.ModHelperComponent.Add<T>(T).T')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddButton(BTD_Mod_Helper.Api.Components.Info,string,Action)'></a>

## ModHelperComponent.AddButton(Info, string, Action) Method

Creates a new ModHelperButton

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperButton AddButton(BTD_Mod_Helper.Api.Components.Info info, string sprite, Action onClick);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddButton(BTD_Mod_Helper.Api.Components.Info,string,Action).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddButton(BTD_Mod_Helper.Api.Components.Info,string,Action).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The button's visuals

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddButton(BTD_Mod_Helper.Api.Components.Info,string,Action).onClick'></a>

`onClick` [Il2CppSystem.Action](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action 'Il2CppSystem.Action')

What should happen when the button is clicked

#### Returns
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string)'></a>

## ModHelperComponent.AddCheckbox(Info, bool, string) Method

Creates a new ModHelperCheckbox

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_)'></a>

## ModHelperComponent.AddCheckbox(Info, bool, string, UnityAction<bool>) Method

Creates a new ModHelperCheckbox

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string)'></a>

## ModHelperComponent.AddCheckbox(Info, bool, string, UnityAction<bool>, string) Method

Creates a new ModHelperCheckbox

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged, string checkImage);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).checkImage'></a>

`checkImage` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The checkmark itself, or null for the default checkmark

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int)'></a>

## ModHelperComponent.AddCheckbox(Info, bool, string, UnityAction<bool>, string, int) Method

Creates a new ModHelperCheckbox

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged, string checkImage, int padding);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).checkImage'></a>

`checkImage` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The checkmark itself, or null for the default checkmark

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddCheckbox(BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How much space around the outside of the check there is

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_)'></a>

## ModHelperComponent.AddDropdown(Info, List<string>, float, UnityAction<int>) Method

Creates a new ModHelperDropdown

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string)'></a>

## ModHelperComponent.AddDropdown(Info, List<string>, float, UnityAction<int>, string) Method

Creates a new ModHelperDropdown

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged, string background);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background image

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float)'></a>

## ModHelperComponent.AddDropdown(Info, List<string>, float, UnityAction<int>, string, float) Method

Creates a new ModHelperDropdown

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged, string background, float labelFontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background image

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddDropdown(BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).labelFontSize'></a>

`labelFontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Text size of label

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,Sprite)'></a>

## ModHelperComponent.AddImage(Info, Sprite) Method

Creates a new ModHelperImage

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage AddImage(BTD_Mod_Helper.Api.Components.Info info, Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,Sprite).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,string)'></a>

## ModHelperComponent.AddImage(Info, string) Method

Creates a new ModHelperImage

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage AddImage(BTD_Mod_Helper.Api.Components.Info info, string sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddImage(BTD_Mod_Helper.Api.Components.Info,string).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddLayoutElement()'></a>

## ModHelperComponent.AddLayoutElement() Method

Adds and returns a LayoutElement for this, making it work as part of a LayoutGroup

```csharp
public LayoutElement AddLayoutElement();
```

#### Returns
[UnityEngine.UI.LayoutElement](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.LayoutElement 'UnityEngine.UI.LayoutElement')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2)'></a>

## ModHelperComponent.AddSlider(Info, float, float, float, float, Vector2) Method

Creates a new ModHelperSlider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_)'></a>

## ModHelperComponent.AddSlider(Info, float, float, float, float, Vector2, UnityAction<float>) Method

Creates a new ModHelperSlider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float)'></a>

## ModHelperComponent.AddSlider(Info, float, float, float, float, Vector2, UnityAction<float>, float) Method

Creates a new ModHelperSlider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string)'></a>

## ModHelperComponent.AddSlider(Info, float, float, float, float, Vector2, UnityAction<float>, float, string) Method

Creates a new ModHelperSlider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).labelSuffix'></a>

`labelSuffix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String to add to the end of the label, e.g. "%"

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float)'></a>

## ModHelperComponent.AddSlider(Info, float, float, float, float, Vector2, UnityAction<float>, float, string, float) Method

Creates a new ModHelperSlider

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix, float startingValue);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).labelSuffix'></a>

`labelSuffix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String to add to the end of the label, e.g. "%"

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddSlider(BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).startingValue'></a>

`startingValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If not null, the value that this should start as instead of the default

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string)'></a>

## ModHelperComponent.AddText(Info, string) Method

Creates a new ModHelperText

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText AddText(BTD_Mod_Helper.Api.Components.Info info, string text);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float)'></a>

## ModHelperComponent.AddText(Info, string, float) Method

Creates a new ModHelperText

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText AddText(BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions)'></a>

## ModHelperComponent.AddText(Info, string, float, TextAlignmentOptions) Method

Creates a new ModHelperText

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText AddText(BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize, TextAlignmentOptions align);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.AddText(BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).align'></a>

`align` [Il2CppTMPro.TextAlignmentOptions](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TextAlignmentOptions 'Il2CppTMPro.TextAlignmentOptions')

Alignment of text

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.DeleteObject()'></a>

## ModHelperComponent.DeleteObject() Method

Deletes the underlying GameObject this is attached to, not just the component

```csharp
public void DeleteObject();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.GetDescendent_T_(string)'></a>

## ModHelperComponent.GetDescendent<T>(string) Method

Gets a descendent component with the given name

```csharp
public T GetDescendent<T>(string s="")
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.GetDescendent_T_(string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.GetDescendent_T_(string).s'></a>

`s` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperComponent.md#BTD_Mod_Helper.Api.Components.ModHelperComponent.GetDescendent_T_(string).T 'BTD_Mod_Helper.Api.Components.ModHelperComponent.GetDescendent<T>(string).T')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.OnDestroy()'></a>

## ModHelperComponent.OnDestroy() Method

Unity Component OnDestroy

```csharp
protected virtual void OnDestroy();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.OnUpdate()'></a>

## ModHelperComponent.OnUpdate() Method

Unity Component OnUpdate

```csharp
protected virtual void OnUpdate();
```

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.RemoveComponent_T_()'></a>

## ModHelperComponent.RemoveComponent<T>() Method

Removes a Component from a GameObject by destroying it

```csharp
public void RemoveComponent<T>()
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.RemoveComponent_T_().T'></a>

`T`

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetActive(bool)'></a>

## ModHelperComponent.SetActive(bool) Method

Sets whether or not this is active

```csharp
public void SetActive(bool active);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetActive(bool).active'></a>

`active` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetInfo(BTD_Mod_Helper.Api.Components.Info)'></a>

## ModHelperComponent.SetInfo(Info) Method

Applies the properties of an info struct to this

```csharp
public void SetInfo(BTD_Mod_Helper.Api.Components.Info newInfo);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetInfo(BTD_Mod_Helper.Api.Components.Info).newInfo'></a>

`newInfo` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetParent(BTD_Mod_Helper.Api.Components.ModHelperComponent)'></a>

## ModHelperComponent.SetParent(ModHelperComponent) Method

Sets a particular ModHelperComponent to be the parent of this

```csharp
public void SetParent(BTD_Mod_Helper.Api.Components.ModHelperComponent newParent);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetParent(BTD_Mod_Helper.Api.Components.ModHelperComponent).newParent'></a>

`newParent` [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetParent(Transform)'></a>

## ModHelperComponent.SetParent(Transform) Method

Sets a particular transform to be the parent of this

```csharp
public void SetParent(Transform newParent);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.SetParent(Transform).newParent'></a>

`newParent` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')
### Operators

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.op_ImplicitGameObject(BTD_Mod_Helper.Api.Components.ModHelperComponent)'></a>

## ModHelperComponent.implicit operator GameObject(ModHelperComponent) Operator

Implicitly get the gameObject

```csharp
public static GameObject implicit operator GameObject(BTD_Mod_Helper.Api.Components.ModHelperComponent component);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.op_ImplicitGameObject(BTD_Mod_Helper.Api.Components.ModHelperComponent).component'></a>

`component` [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

#### Returns
[UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.op_ImplicitRectTransform(BTD_Mod_Helper.Api.Components.ModHelperComponent)'></a>

## ModHelperComponent.implicit operator RectTransform(ModHelperComponent) Operator

Implicitly get the RectTransform

```csharp
public static RectTransform implicit operator RectTransform(BTD_Mod_Helper.Api.Components.ModHelperComponent component);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponent.op_ImplicitRectTransform(BTD_Mod_Helper.Api.Components.ModHelperComponent).component'></a>

`component` [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

#### Returns
[UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')