#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperScrollPanel Class

ModHelperComponent for a background panel

```csharp
public class ModHelperScrollPanel : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [UnhollowerBaseLib.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppObjectBase 'UnhollowerBaseLib.Il2CppObjectBase') &#129106; [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object') &#129106; [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object') &#129106; [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component') &#129106; [UnityEngine.Behaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Behaviour 'UnityEngine.Behaviour') &#129106; [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperScrollPanel
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.ContentSizeFitter'></a>

## ModHelperScrollPanel.ContentSizeFitter Property

The ContentSizeFitter component which makes sure that the ScrollContent  
is the right size to hold all the scrollable items.

```csharp
public UnityEngine.UI.ContentSizeFitter ContentSizeFitter { get; set; }
```

#### Property Value
[UnityEngine.UI.ContentSizeFitter](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.ContentSizeFitter 'UnityEngine.UI.ContentSizeFitter')

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Mask'></a>

## ModHelperScrollPanel.Mask Property

The Mask component which prevents overflow of rendering outside the scroll area

```csharp
public UnityEngine.UI.Mask Mask { get; }
```

#### Property Value
[UnityEngine.UI.Mask](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Mask 'UnityEngine.UI.Mask')

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.ScrollContent'></a>

## ModHelperScrollPanel.ScrollContent Property

The ScrollContent object. This is the object that the children are actually part of,  
and is what actually moves up and down when scrolling.

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperPanel ScrollContent { get; }
```

#### Property Value
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.ScrollRect'></a>

## ModHelperScrollPanel.ScrollRect Property

The ScrollRect component which controls many aspects of scrolling

```csharp
public UnityEngine.UI.ScrollRect ScrollRect { get; }
```

#### Property Value
[UnityEngine.UI.ScrollRect](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.ScrollRect 'UnityEngine.UI.ScrollRect')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.AddScrollContent(BTD_Mod_Helper.Api.Components.ModHelperComponent)'></a>

## ModHelperScrollPanel.AddScrollContent(ModHelperComponent) Method

Adds a child to the ScrollContent of this panel

```csharp
public void AddScrollContent(BTD_Mod_Helper.Api.Components.ModHelperComponent child);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.AddScrollContent(BTD_Mod_Helper.Api.Components.ModHelperComponent).child'></a>

`child` [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int)'></a>

## ModHelperScrollPanel.Create(Info, Nullable<Axis>, string, float, int) Method

Creates a new ModHelperScrollPanel

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperScrollPanel Create(BTD_Mod_Helper.Api.Components.Info info, System.Nullable<UnityEngine.RectTransform.Axis> axis, string backgroundSprite=null, float spacing=0f, int padding=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int).axis'></a>

`axis` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.RectTransform.Axis](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform.Axis 'UnityEngine.RectTransform.Axis')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The axis that it scrolls in, or null for both directions

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int).backgroundSprite'></a>

`backgroundSprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The panel's background sprite

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If axis is not null, then the layout spacing for the items

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Create(BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,string,float,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[ModHelperScrollPanel](BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperScrollPanel')  
The created ModHelperScrollPanel