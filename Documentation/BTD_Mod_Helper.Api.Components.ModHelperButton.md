#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperButton Class

ModHelperComponent for a background panel

```csharp
public class ModHelperButton : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperButton
### Fields

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.LongBtnRatio'></a>

## ModHelperButton.LongBtnRatio Field

The aspect ratio of LongBtn sprites, since they aren't sliced for some reason lol

```csharp
public const float LongBtnRatio = 2.81;
```

#### Field Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Button'></a>

## ModHelperButton.Button Property

The actual button component

```csharp
public Button Button { get; }
```

#### Property Value
[UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Image'></a>

## ModHelperButton.Image Property

The displayed image of the button

```csharp
public Image Image { get; }
```

#### Property Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,string,Action)'></a>

## ModHelperButton.Create(Info, string, Action) Method

Creates a new ModHelperButton

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperButton Create(BTD_Mod_Helper.Api.Components.Info info, string sprite, Action onClick);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,string,Action).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,string,Action).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The button's visuals

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,string,Action).onClick'></a>

`onClick` [Il2CppSystem.Action](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action 'Il2CppSystem.Action')

What should happen when the button is clicked

#### Returns
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')