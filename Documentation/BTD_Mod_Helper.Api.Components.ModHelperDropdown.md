#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperDropdown Class

ModHelperComponent for a

```csharp
public class ModHelperDropdown : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperDropdown
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Arrow'></a>

## ModHelperDropdown.Arrow Property

The Arrow image

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage Arrow { get; }
```

#### Property Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Background'></a>

## ModHelperDropdown.Background Property

The Image being displayed

```csharp
public UnityEngine.UI.Image Background { get; }
```

#### Property Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Dropdown'></a>

## ModHelperDropdown.Dropdown Property

The component which handles the dropdown

```csharp
public TMPro.TMP_Dropdown Dropdown { get; }
```

#### Property Value
[TMPro.TMP_Dropdown](https://docs.microsoft.com/en-us/dotnet/api/TMPro.TMP_Dropdown 'TMPro.TMP_Dropdown')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.TemplateItem'></a>

## ModHelperDropdown.TemplateItem Property

The default item in the template

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel TemplateItem { get; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.TemplatePanel'></a>

## ModHelperDropdown.TemplatePanel Property

The template object for the window of the dropdown

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperScrollPanel TemplatePanel { get; }
```

#### Property Value
[ModHelperScrollPanel](BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperScrollPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Text'></a>

## ModHelperDropdown.Text Property

The Text which shows the currently selected value

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText Text { get; }
```

#### Property Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float)'></a>

## ModHelperDropdown.Create(Info, List<string>, float, UnityAction<int>, string, float) Method

Creates a new ModHelperDropdown

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperDropdown Create(BTD_Mod_Helper.Api.Components.Info info, Il2CppSystem.Collections.Generic.List<string> options, float windowHeight, UnityEngine.Events.UnityAction<int> onValueChanged, string background=null, float labelFontSize=42f);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info. NOTE: width/height must be set to actual values

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).options'></a>

`options` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

The list of options

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).windowHeight'></a>

`windowHeight` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Height of the created dropdown window

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).onValueChanged'></a>

`onValueChanged` [UnityEngine.Events.UnityAction&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction-1 'UnityEngine.Events.UnityAction`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction-1 'UnityEngine.Events.UnityAction`1')

Action that should happen when an option of the given index is selected

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).background'></a>

`background` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The background image

<a name='BTD_Mod_Helper.Api.Components.ModHelperDropdown.Create(BTD_Mod_Helper.Api.Components.Info,Il2CppSystem.Collections.Generic.List_string_,float,UnityEngine.Events.UnityAction_int_,string,float).labelFontSize'></a>

`labelFontSize` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Text size of label

#### Returns
[ModHelperDropdown](BTD_Mod_Helper.Api.Components.ModHelperDropdown.md 'BTD_Mod_Helper.Api.Components.ModHelperDropdown')  
The created ModHelperDropdown