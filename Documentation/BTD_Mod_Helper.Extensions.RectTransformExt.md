#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RectTransformExt Class

Extensions for RectTransforms

```csharp
public static class RectTransformExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RectTransformExt
### Methods

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ContainsScreenPoint(thisRectTransform,Vector2)'></a>

## RectTransformExt.ContainsScreenPoint(this RectTransform, Vector2) Method

```csharp
public static bool ContainsScreenPoint(this RectTransform rect, Vector2 screenPoint);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ContainsScreenPoint(thisRectTransform,Vector2).rect'></a>

`rect` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ContainsScreenPoint(thisRectTransform,Vector2).screenPoint'></a>

`screenPoint` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.FullyContains(thisRectTransform,RectTransform)'></a>

## RectTransformExt.FullyContains(this RectTransform, RectTransform) Method

Checks whether an inner rect transform is fully contained within an outer rect transform

```csharp
public static bool FullyContains(this RectTransform outer, RectTransform inner);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.FullyContains(thisRectTransform,RectTransform).outer'></a>

`outer` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

outer rect

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.FullyContains(thisRectTransform,RectTransform).inner'></a>

`inner` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

inner rect

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether inner is fully contained within outer

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.MousePositionLocal(thisRectTransform,bool)'></a>

## RectTransformExt.MousePositionLocal(this RectTransform, bool) Method

Gets the mouse position as a local position within this rectangle

```csharp
public static Vector2 MousePositionLocal(this RectTransform rect, bool clamp=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.MousePositionLocal(thisRectTransform,bool).rect'></a>

`rect` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

this

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.MousePositionLocal(thisRectTransform,bool).clamp'></a>

`clamp` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

whether to clamp the position to within the bounds of this rect

#### Returns
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.OverlapsWith(thisRectTransform,RectTransform)'></a>

## RectTransformExt.OverlapsWith(this RectTransform, RectTransform) Method

Checks whether a rect overlaps with another rect

```csharp
public static bool OverlapsWith(this RectTransform a, RectTransform b);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.OverlapsWith(thisRectTransform,RectTransform).a'></a>

`a` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

rect

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.OverlapsWith(thisRectTransform,RectTransform).b'></a>

`b` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

rect

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
whether rects overlap

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ScreenPointToLocalPoint(thisRectTransform,Vector2)'></a>

## RectTransformExt.ScreenPointToLocalPoint(this RectTransform, Vector2) Method

```csharp
public static Vector2 ScreenPointToLocalPoint(this RectTransform rect, Vector2 screenPoint);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ScreenPointToLocalPoint(thisRectTransform,Vector2).rect'></a>

`rect` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Extensions.RectTransformExt.ScreenPointToLocalPoint(thisRectTransform,Vector2).screenPoint'></a>

`screenPoint` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

#### Returns
[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')