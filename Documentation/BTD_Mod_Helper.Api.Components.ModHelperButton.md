#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Components](index.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperButton Class

ModHelperComponent for a background panel

```csharp
public class ModHelperButton : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperButton
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
public UnityEngine.UI.Button Button { get; }
```

#### Property Value
[UnityEngine.UI.Button](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Button 'UnityEngine.UI.Button')

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Image'></a>

## ModHelperButton.Image Property

The displayed image of the button

```csharp
public UnityEngine.UI.Image Image { get; }
```

#### Property Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,Il2CppSystem.Action)'></a>

## ModHelperButton.Create(Info, SpriteReference, Action) Method

Creates a new ModHelperButton

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperButton Create(BTD_Mod_Helper.Api.Components.Info info, Assets.Scripts.Utils.SpriteReference sprite, Il2CppSystem.Action onClick);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,Il2CppSystem.Action).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,Il2CppSystem.Action).sprite'></a>

`sprite` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

The button's visuals

<a name='BTD_Mod_Helper.Api.Components.ModHelperButton.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,Il2CppSystem.Action).onClick'></a>

`onClick` [Il2CppSystem.Action](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Action 'Il2CppSystem.Action')

What should happen when the button is clicked

#### Returns
[ModHelperButton](BTD_Mod_Helper.Api.Components.ModHelperButton.md 'BTD_Mod_Helper.Api.Components.ModHelperButton')