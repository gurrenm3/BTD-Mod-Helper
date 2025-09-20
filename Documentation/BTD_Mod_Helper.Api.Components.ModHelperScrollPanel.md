#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperScrollPanel Class

ModHelperComponent for a background panel

```csharp
public class ModHelperScrollPanel : BTD_Mod_Helper.Api.Components.ModHelperPanel
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; [ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel') &#129106; ModHelperScrollPanel
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.ContentSizeFitter'></a>

## ModHelperScrollPanel.ContentSizeFitter Property

The ContentSizeFitter component which makes sure that the ScrollContent  
is the right size to hold all the scrollable items.

```csharp
public ContentSizeFitter ContentSizeFitter { get; }
```

#### Property Value
[UnityEngine.UI.ContentSizeFitter](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.ContentSizeFitter 'UnityEngine.UI.ContentSizeFitter')

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.Mask'></a>

## ModHelperScrollPanel.Mask Property

The Mask component which prevents overflow of rendering outside the scroll area

```csharp
public Mask Mask { get; }
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
public ScrollRect ScrollRect { get; }
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

<a name='BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.UseInnerViewport()'></a>

## ModHelperScrollPanel.UseInnerViewport() Method

By default, ModHelperScrollPanels use themselves as the scroll viewport. This method separates it into  
two different objects. Useful for having the viewport change size based on scrollbar presence.

```csharp
public void UseInnerViewport();
```