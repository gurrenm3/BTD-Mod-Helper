#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperOption Class

ModHelperComponent that's the base panel for the visual representation of a ModSetting

```csharp
public class ModHelperOption : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperOption

Derived  
&#8627; [ModHelperCategory](BTD_Mod_Helper.Api.Components.ModHelperCategory.md 'BTD_Mod_Helper.Api.Components.ModHelperCategory')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.BottomRow'></a>

## ModHelperOption.BottomRow Property

The bottom row of elements containing the reset button and whatever input is added

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel BottomRow { get; set; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Icon'></a>

## ModHelperOption.Icon Property

The Icon for this setting. Will be null if no Icon provided

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage Icon { get; set; }
```

#### Property Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.InfoButton'></a>

## ModHelperOption.InfoButton Property

The button that popups the description when pressed

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperButton InfoButton { get; set; }
```

#### Property Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Name'></a>

## ModHelperOption.Name Property

The displayed name for this setting

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperText Name { get; set; }
```

#### Property Value
[ModHelperText](BTD_Mod_Helper.Api.Components.ModHelperText.md 'BTD_Mod_Helper.Api.Components.ModHelperText')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.ResetButton'></a>

## ModHelperOption.ResetButton Property

The button that resets this setting

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperButton ResetButton { get; set; }
```

#### Property Value
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.RestartIcon'></a>

## ModHelperOption.RestartIcon Property

The image shown when this setting requires a restart

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage RestartIcon { get; set; }
```

#### Property Value
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.TopRow'></a>

## ModHelperOption.TopRow Property

The top row of elements containing icon, name, info button

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel TopRow { get; set; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create(string,string,string)'></a>

## ModHelperOption.Create(string, string, string) Method

Creates a new MoodHelperOption

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperOption Create(string displayName, string description=null, string icon=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create(string,string,string).displayName'></a>

`displayName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The displayed name of the mod setting

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create(string,string,string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The description of the mod setting, if any

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create(string,string,string).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The icon of the mod setting, if any

#### Returns
[ModHelperOption](BTD_Mod_Helper.Api.Components.ModHelperOption.md 'BTD_Mod_Helper.Api.Components.ModHelperOption')  
The created ModHelperOption

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string)'></a>

## ModHelperOption.Create<T>(string, string, string) Method

Creates a new MoodHelperOption

```csharp
protected static T Create<T>(string displayName, string description=null, string icon=null)
    where T : BTD_Mod_Helper.Api.Components.ModHelperOption;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string).displayName'></a>

`displayName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The displayed name of the mod setting

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string).description'></a>

`description` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The description of the mod setting, if any

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string).icon'></a>

`icon` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The icon of the mod setting, if any

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperOption.md#BTD_Mod_Helper.Api.Components.ModHelperOption.Create_T_(string,string,string).T 'BTD_Mod_Helper.Api.Components.ModHelperOption.Create<T>(string, string, string).T')  
The created ModHelperOption

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.SetResetAction(UnityEngine.Events.UnityAction)'></a>

## ModHelperOption.SetResetAction(UnityAction) Method

Adds an action to the reset button

```csharp
public void SetResetAction(UnityEngine.Events.UnityAction action);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperOption.SetResetAction(UnityEngine.Events.UnityAction).action'></a>

`action` [UnityEngine.Events.UnityAction](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Events.UnityAction 'UnityEngine.Events.UnityAction')