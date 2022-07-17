#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperPanel Class

ModHelperComponent for a background panel

```csharp
public class ModHelperPanel : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperPanel

Derived  
&#8627; [ModHelperScrollPanel](BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperScrollPanel')
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Background'></a>

## ModHelperPanel.Background Property

The background image

```csharp
public UnityEngine.UI.Image Background { get; }
```

#### Property Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int)'></a>

## ModHelperPanel.Create(Info, SpriteReference, Nullable<Axis>, float, int) Method

Creates a new ModHelperPanel

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperPanel Create(BTD_Mod_Helper.Api.Components.Info info, Assets.Scripts.Utils.SpriteReference backgroundSprite=null, System.Nullable<UnityEngine.RectTransform.Axis> layoutAxis=null, float spacing=0f, int padding=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).backgroundSprite'></a>

`backgroundSprite` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

The panel's background sprite

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).layoutAxis'></a>

`layoutAxis` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.RectTransform.Axis](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform.Axis 'UnityEngine.RectTransform.Axis')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If present, creates this panel with a Horizontal/Vertical layout group

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The layout group's spacing

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The layout group's padding

#### Returns
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')  
The created ModHelperPanel

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int)'></a>

## ModHelperPanel.Create<T>(Info, SpriteReference, Nullable<Axis>, float, int) Method

Creates a new ModHelperPanel

```csharp
protected static T Create<T>(BTD_Mod_Helper.Api.Components.Info info, Assets.Scripts.Utils.SpriteReference backgroundSprite=null, System.Nullable<UnityEngine.RectTransform.Axis> layoutAxis=null, float spacing=0f, int padding=0)
    where T : BTD_Mod_Helper.Api.Components.ModHelperPanel;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).backgroundSprite'></a>

`backgroundSprite` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

The panel's background sprite

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).layoutAxis'></a>

`layoutAxis` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.RectTransform.Axis](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform.Axis 'UnityEngine.RectTransform.Axis')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If present, creates this panel with a Horizontal/Vertical layout group

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The layout group's spacing

<a name='BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The layout group's padding

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperPanel.md#BTD_Mod_Helper.Api.Components.ModHelperPanel.Create_T_(BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).T 'BTD_Mod_Helper.Api.Components.ModHelperPanel.Create<T>(BTD_Mod_Helper.Api.Components.Info, Assets.Scripts.Utils.SpriteReference, System.Nullable<UnityEngine.RectTransform.Axis>, float, int).T')  
The created ModHelperPanel