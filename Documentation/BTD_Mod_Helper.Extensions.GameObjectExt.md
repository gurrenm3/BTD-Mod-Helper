#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameObjectExt Class

Extensions for GameObjects

```csharp
public static class GameObjectExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameObjectExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,System.Action)'></a>

## GameObjectExt.AddButton(this GameObject, Info, string, Action) Method

Creates a new ModHelperButton

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperButton AddButton(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string sprite, System.Action onClick);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,System.Action).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,System.Action).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,System.Action).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The button's visuals

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,System.Action).onClick'></a>

`onClick` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

What should happen when the button is clicked

#### Returns
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int)'></a>

## GameObjectExt.AddCheckbox(this GameObject, Info, bool, string, UnityAction<bool>, string, int) Method

Creates a new ModHelperCheckbox

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged, string checkImage, int padding);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).checkImage'></a>

`checkImage` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The checkmark itself, or null for the default checkmark

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

How much space around the outside of the check there is

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string)'></a>

## GameObjectExt.AddCheckbox(this GameObject, Info, bool, string, UnityAction<bool>, string) Method

Creates a new ModHelperCheckbox

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged, string checkImage);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_,string).checkImage'></a>

`checkImage` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The checkmark itself, or null for the default checkmark

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_)'></a>

## GameObjectExt.AddCheckbox(this GameObject, Info, bool, string, UnityAction<bool>) Method

Creates a new ModHelperCheckbox

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background, UnityAction<bool> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string,UnityAction_bool_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action to perform when it is checked/unchecked, or null

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string)'></a>

## GameObjectExt.AddCheckbox(this GameObject, Info, bool, string) Method

Creates a new ModHelperCheckbox

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperCheckbox AddCheckbox(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, bool defaultValue, string background);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string).defaultValue'></a>

`defaultValue` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

If it starts out checked or not

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddCheckbox(thisGameObject,BTD_Mod_Helper.Api.Components.Info,bool,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background behind the check, or null for nothing

#### Returns
[ModHelperCheckbox](BTD_Mod_Helper.Api.Components.ModHelperCheckbox.md 'BTD_Mod_Helper.Api.Components.ModHelperCheckbox')  
The new ModHelperCheckbox

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float)'></a>

## GameObjectExt.AddDropdown(this GameObject, Info, List<string>, float, UnityAction<int>, string, float) Method

Creates a new ModHelperDropdown

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged, string background, float labelFontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background image

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string,float).labelFontSize'></a>

`labelFontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Text size of label

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string)'></a>

## GameObjectExt.AddDropdown(this GameObject, Info, List<string>, float, UnityAction<int>, string) Method

Creates a new ModHelperDropdown

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged, string background);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_,string).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background image

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_)'></a>

## GameObjectExt.AddDropdown(this GameObject, Info, List<string>, float, UnityAction<int>) Method

Creates a new ModHelperDropdown

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDropdown AddDropdown(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, List<string> options, float windowHeight, UnityAction<int> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).options'></a>

`options` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

The list of options

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddDropdown(thisGameObject,BTD_Mod_Helper.Api.Components.Info,List_string_,float,UnityAction_int_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action that should happen when an option of the given index is selected

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,Sprite)'></a>

## GameObjectExt.AddImage(this GameObject, Info, Sprite) Method

Creates a new ModHelperImage

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperImage AddImage(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,Sprite).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,Sprite).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string)'></a>

## GameObjectExt.AddImage(this GameObject, Info, string) Method

Creates a new ModHelperImage

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperImage AddImage(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddImage(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T)'></a>

## GameObjectExt.AddModHelperComponent<T>(this GameObject, T) Method

Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent  
<br/>  
(This is an extension method just so that we can return the type generically)

```csharp
public static T AddModHelperComponent<T>(this GameObject gameObject, T modHelperComponent)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).modHelperComponent'></a>

`modHelperComponent` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this GameObject, T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this GameObject, T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float)'></a>

## GameObjectExt.AddSlider(this GameObject, Info, float, float, float, float, Vector2, UnityAction<float>, float, string, float) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix, float startingValue);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).labelSuffix'></a>

`labelSuffix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String to add to the end of the label, e.g. "%"

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string,float).startingValue'></a>

`startingValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If not null, the value that this should start as instead of the default

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string)'></a>

## GameObjectExt.AddSlider(this GameObject, Info, float, float, float, float, Vector2, UnityAction<float>, float, string) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize, string labelSuffix);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float,string).labelSuffix'></a>

`labelSuffix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

String to add to the end of the label, e.g. "%"

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float)'></a>

## GameObjectExt.AddSlider(this GameObject, Info, float, float, float, float, Vector2, UnityAction<float>, float) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged, float fontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The size of the label text

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_)'></a>

## GameObjectExt.AddSlider(this GameObject, Info, float, float, float, float, Vector2, UnityAction<float>) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize, UnityAction<float> onValueChanged);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2,UnityAction_float_).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')

Action should happen when the slider changes value, or null

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2)'></a>

## GameObjectExt.AddSlider(this GameObject, Info, float, float, float, float, Vector2) Method

Creates a new ModHelperSlider

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperSlider AddSlider(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, float defaultValue, float minValue, float maxValue, float stepSize, Vector2 handleSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: height must be a set value

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).defaultValue'></a>

`defaultValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The default slider amount

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).minValue'></a>

`minValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The minimum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).maxValue'></a>

`maxValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The maximum value of the slider

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).stepSize'></a>

`stepSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

What value the slider should increase by per tick

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddSlider(thisGameObject,BTD_Mod_Helper.Api.Components.Info,float,float,float,float,Vector2).handleSize'></a>

`handleSize` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

The height and width of the pip

#### Returns
[ModHelperSlider](BTD_Mod_Helper.Api.Components.ModHelperSlider.md 'BTD_Mod_Helper.Api.Components.ModHelperSlider')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions)'></a>

## GameObjectExt.AddText(this GameObject, Info, string, float, TextAlignmentOptions) Method

Creates a new ModHelperText

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperText AddText(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize, TextAlignmentOptions align);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float,TextAlignmentOptions).align'></a>

`align` [Il2CppTMPro.TextAlignmentOptions](https://docs.microsoft.com/en-us/dotnet/api/Il2CppTMPro.TextAlignmentOptions 'Il2CppTMPro.TextAlignmentOptions')

Alignment of text

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float)'></a>

## GameObjectExt.AddText(this GameObject, Info, string, float) Method

Creates a new ModHelperText

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperText AddText(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string text, float fontSize);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,float).fontSize'></a>

`fontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Size of font

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string)'></a>

## GameObjectExt.AddText(this GameObject, Info, string) Method

Creates a new ModHelperText

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperText AddText(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string text);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddText(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The text to display

#### Returns
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')  
The created ModHelperText

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string)'></a>

## GameObjectExt.AddTSMButton(this GameObject, Info, string, string, string) Method

Adds a TSMButton to this with the given buttonId and optional customInputId

```csharp
public static TSMButton AddTSMButton(this GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, string sprite, string buttonId, string customInputId=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

this

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

Mod Helper Component info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

sprite guid for the button

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string).buttonId'></a>

`buttonId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

tsm buttonId

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddTSMButton(thisGameObject,BTD_Mod_Helper.Api.Components.Info,string,string,string).customInputId'></a>

`customInputId` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

optional tsm customInputId

#### Returns
[Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton 'Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes.TSMButton')  
created TSMButton

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisGameObject)'></a>

## GameObjectExt.Destroy(this GameObject) Method

Destroys this GameObject

```csharp
public static void Destroy(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisGameObject)'></a>

## GameObjectExt.DestroyAllChildren(this GameObject) Method

Destroys all children of a game object

```csharp
public static void DestroyAllChildren(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform)'></a>

## GameObjectExt.Duplicate<T>(this T, Transform) Method

Instantiate a clone of the GameObject with the new transform as parent

```csharp
public static T Duplicate<T>(this T gameObject, Transform parent)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).parent'></a>

`parent` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT)'></a>

## GameObjectExt.Duplicate<T>(this T) Method

Instantiate a clone of the GameObject keeping the same parent

```csharp
public static T Duplicate<T>(this T gameObject)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T)'></a>

## GameObjectExt.Exists<T>(this T, T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static bool Exists<T>(this T obj, out T result)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T).obj'></a>

`obj` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T, T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T).result'></a>

`result` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT)'></a>

## GameObjectExt.Exists<T>(this T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static T Exists<T>(this T obj)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).obj'></a>

`obj` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetChildren(thisGameObject)'></a>

## GameObjectExt.GetChildren(this GameObject) Method

Gets the direct children of this gameobject

```csharp
public static System.Collections.Generic.IEnumerable<GameObject> GetChildren(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetChildren(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

this

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string)'></a>

## GameObjectExt.GetComponent<T>(this GameObject, string) Method

Finds a component with the given path and type

```csharp
public static T GetComponent<T>(this GameObject gameObject, string componentPath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).componentPath'></a>

`componentPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent<T>(this GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string)'></a>

## GameObjectExt.GetComponentInChildrenByName<T>(this GameObject, string) Method

Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren

```csharp
public static T GetComponentInChildrenByName<T>(this GameObject gameObject, string componentName)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName<T>(this GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T)'></a>

## GameObjectExt.HasComponent<T>(this GameObject, T) Method

Returns whether a component of the given type exists on a game object, and puts it in the out param

```csharp
public static bool HasComponent<T>(this GameObject gameObject, out T component)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).component'></a>

`component` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent<T>(this GameObject, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject)'></a>

## GameObjectExt.HasComponent<T>(this GameObject) Method

Returns whether a component of the given type exists on a game object

```csharp
public static bool HasComponent<T>(this GameObject gameObject)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisGameObject)'></a>

## GameObjectExt.Hide(this GameObject) Method

Makes the Game Object hidden (not visible) by setting the scale to zero

```csharp
public static void Hide(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int)'></a>

## GameObjectExt.RecursivelyLog(this GameObject, int) Method

Logs a GameObject's hierarchy recursively

```csharp
public static void RecursivelyLog(this GameObject gameObject, int depth=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int).depth'></a>

`depth` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject)'></a>

## GameObjectExt.RemoveComponent<T>(this GameObject) Method

Removes a Component from a GameObject by destroying it

```csharp
public static void RemoveComponent<T>(this GameObject gameObject)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisGameObject)'></a>

## GameObjectExt.Show(this GameObject) Method

Makes the Game Object visible by setting the scale to the default value of 1

```csharp
public static void Show(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3)'></a>

## GameObjectExt.TranslateScaled(this GameObject, Vector3) Method

Translates this GameObject scaled with it's "lossyScale", making it move the same  
amount regardless of screen resolution

```csharp
public static void TranslateScaled(this GameObject gameObject, Vector3 translation);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3).translation'></a>

`translation` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')