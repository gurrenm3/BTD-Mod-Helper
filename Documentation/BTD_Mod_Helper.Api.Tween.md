#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## Tween Struct

Helper for performing animation Tweens

```csharp
public readonly struct Tween
```
### Properties

<a name='BTD_Mod_Helper.Api.Tween.ElapsedTime'></a>

## Tween.ElapsedTime Property

The elapsed time, in seconds, for the current tween cycle.

```csharp
public float ElapsedTime { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.IsAlive'></a>

## Tween.IsAlive Property

Whether this handle still points to a currently running tween.

```csharp
public bool IsAlive { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Tween.IsPaused'></a>

## Tween.IsPaused Property

Whether this tween is currently paused.

```csharp
public bool IsPaused { get; set; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Tween.Progress'></a>

## Tween.Progress Property

The normalized progress for the current tween cycle.

```csharp
public float Progress { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')
### Methods

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Alpha(CanvasGroup, float, float, Ease, bool) Method

Tweens a CanvasGroup's alpha.

```csharp
public static BTD_Mod_Helper.Api.Tween Alpha(CanvasGroup target, float endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.CanvasGroup](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.CanvasGroup 'UnityEngine.CanvasGroup')

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Alpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.AnchoredPosition(RectTransform, Vector2, float, Ease, bool) Method

Tweens a RectTransform's anchored position.

```csharp
public static BTD_Mod_Helper.Api.Tween AnchoredPosition(RectTransform target, Vector2 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.AnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Color(Graphic, Color, float, Ease, bool) Method

Tweens a UI graphic's color.

```csharp
public static BTD_Mod_Helper.Api.Tween Color(Graphic target, Color endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.UI.Graphic](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Graphic 'UnityEngine.UI.Graphic')

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Color(Graphic,Color,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Complete()'></a>

## Tween.Complete() Method

Completes this tween immediately.

```csharp
public void Complete();
```

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Custom(Color, Color, float, Action<Color>, Ease, bool) Method

Creates a tween over a [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color') value.

```csharp
public static BTD_Mod_Helper.Api.Tween Custom(Color startValue, Color endValue, float duration, System.Action<Color> onValueChange, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).onValueChange'></a>

`onValueChange` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Color,Color,float,System.Action_Color_,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Custom(float, float, float, Action<float>, Ease, bool) Method

Creates a tween over a float value.

```csharp
public static BTD_Mod_Helper.Api.Tween Custom(float startValue, float endValue, float duration, System.Action<float> onValueChange, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).onValueChange'></a>

`onValueChange` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Custom(float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Custom(Object, float, float, float, Action<float>, Ease, bool) Method

Creates a tween over a float value, associated with a target object for cancellation and lifetime checks.

```csharp
public static BTD_Mod_Helper.Api.Tween Custom(Object target, float startValue, float endValue, float duration, System.Action<float> onValueChange, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).onValueChange'></a>

`onValueChange` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Object,float,float,float,System.Action_float_,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Custom(Vector2, Vector2, float, Action<Vector2>, Ease, bool) Method

Creates a tween over a [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2') value.

```csharp
public static BTD_Mod_Helper.Api.Tween Custom(Vector2 startValue, Vector2 endValue, float duration, System.Action<Vector2> onValueChange, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).onValueChange'></a>

`onValueChange` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector2,Vector2,float,System.Action_Vector2_,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Custom(Vector3, Vector3, float, Action<Vector3>, Ease, bool) Method

Creates a tween over a [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3') value.

```csharp
public static BTD_Mod_Helper.Api.Tween Custom(Vector3 startValue, Vector3 endValue, float duration, System.Action<Vector3> onValueChange, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).onValueChange'></a>

`onValueChange` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Custom(Vector3,Vector3,float,System.Action_Vector3_,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.EulerAngles(Transform, Vector3, float, Ease, bool) Method

Tweens a transform's local Euler angles.

```csharp
public static BTD_Mod_Helper.Api.Tween EulerAngles(Transform target, Vector3 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.EulerAngles(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.FromAlpha(CanvasGroup, float, float, Ease, bool) Method

Sets a CanvasGroup's alpha to a starting value, then tweens back to its current alpha.

```csharp
public static BTD_Mod_Helper.Api.Tween FromAlpha(CanvasGroup target, float startValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.CanvasGroup](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.CanvasGroup 'UnityEngine.CanvasGroup')

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.FromAlpha(CanvasGroup,float,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.FromAnchoredPosition(RectTransform, Vector2, float, Ease, bool) Method

Sets a RectTransform's anchored position to a starting value, then tweens back to its current anchored position.

```csharp
public static BTD_Mod_Helper.Api.Tween FromAnchoredPosition(RectTransform target, Vector2 startValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.FromAnchoredPosition(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.FromLocalPosition(Transform, Vector3, float, Ease, bool) Method

Sets a transform's local position to a starting value, then tweens back to its current local position.

```csharp
public static BTD_Mod_Helper.Api.Tween FromLocalPosition(Transform target, Vector3 startValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.FromLocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.FromScale(Transform, float, float, Ease, bool) Method

Sets a transform's local scale to a starting value, then tweens back to its current local scale.

```csharp
public static BTD_Mod_Helper.Api.Tween FromScale(Transform target, float startValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,float,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.FromScale(Transform, Vector3, float, Ease, bool) Method

Sets a transform's local scale to a starting value, then tweens back to its current local scale.

```csharp
public static BTD_Mod_Helper.Api.Tween FromScale(Transform target, Vector3 startValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).startValue'></a>

`startValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.FromScale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.LocalPosition(Transform, Vector3, float, Ease, bool) Method

Tweens a transform's local position.

```csharp
public static BTD_Mod_Helper.Api.Tween LocalPosition(Transform target, Vector3 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.LocalPosition(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.LocalRotation(Transform, Quaternion, float, Ease, bool) Method

Tweens a transform's local rotation.

```csharp
public static BTD_Mod_Helper.Api.Tween LocalRotation(Transform target, Quaternion endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Quaternion 'UnityEngine.Quaternion')

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.LocalRotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.OnComplete(System.Action)'></a>

## Tween.OnComplete(Action) Method

Adds a callback invoked when this tween completes naturally or via [Complete()](BTD_Mod_Helper.Api.Tween.md#BTD_Mod_Helper.Api.Tween.Complete() 'BTD_Mod_Helper.Api.Tween.Complete()').

```csharp
public BTD_Mod_Helper.Api.Tween OnComplete(System.Action onComplete);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.OnComplete(System.Action).onComplete'></a>

`onComplete` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.OnUpdate(System.Action_BTD_Mod_Helper.Api.Tween_)'></a>

## Tween.OnUpdate(Action<Tween>) Method

Adds a callback invoked every time this tween updates.

```csharp
public BTD_Mod_Helper.Api.Tween OnUpdate(System.Action<BTD_Mod_Helper.Api.Tween> onUpdate);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.OnUpdate(System.Action_BTD_Mod_Helper.Api.Tween_).onUpdate'></a>

`onUpdate` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Position(Transform, Vector3, float, Ease, bool) Method

Tweens a transform's world position.

```csharp
public static BTD_Mod_Helper.Api.Tween Position(Transform target, Vector3 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Position(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Rotation(Transform, Quaternion, float, Ease, bool) Method

Tweens a transform's rotation.

```csharp
public static BTD_Mod_Helper.Api.Tween Rotation(Transform target, Quaternion endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Quaternion](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Quaternion 'UnityEngine.Quaternion')

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Rotation(Transform,Quaternion,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.Scale(Transform, Vector3, float, Ease, bool) Method

Tweens a transform's local scale.

```csharp
public static BTD_Mod_Helper.Api.Tween Scale(Transform target, Vector3 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.Scale(Transform,Vector3,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool)'></a>

## Tween.SizeDelta(RectTransform, Vector2, float, Ease, bool) Method

Tweens a RectTransform's size delta.

```csharp
public static BTD_Mod_Helper.Api.Tween SizeDelta(RectTransform target, Vector2 endValue, float duration, BTD_Mod_Helper.Api.Ease ease=BTD_Mod_Helper.Api.Ease.Linear, bool useUnscaledTime=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).target'></a>

`target` [UnityEngine.RectTransform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform 'UnityEngine.RectTransform')

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).endValue'></a>

`endValue` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).duration'></a>

`duration` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).ease'></a>

`ease` [Ease](BTD_Mod_Helper.Api.Ease.md 'BTD_Mod_Helper.Api.Ease')

<a name='BTD_Mod_Helper.Api.Tween.SizeDelta(RectTransform,Vector2,float,BTD_Mod_Helper.Api.Ease,bool).useUnscaledTime'></a>

`useUnscaledTime` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Tween](BTD_Mod_Helper.Api.Tween.md 'BTD_Mod_Helper.Api.Tween')

<a name='BTD_Mod_Helper.Api.Tween.Stop()'></a>

## Tween.Stop() Method

Stops this tween without applying the end value.

```csharp
public void Stop();
```

<a name='BTD_Mod_Helper.Api.Tween.Stop(bool)'></a>

## Tween.Stop(bool) Method

Stops this tween, optionally completing it first.

```csharp
public void Stop(bool complete);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.Stop(bool).complete'></a>

`complete` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Tween.StopAll(bool)'></a>

## Tween.StopAll(bool) Method

Stops all active tweens.

```csharp
public static void StopAll(bool complete=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.StopAll(bool).complete'></a>

`complete` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Tween.StopAll(Object,bool)'></a>

## Tween.StopAll(Object, bool) Method

Stops every tween currently associated with a target.

```csharp
public static void StopAll(Object target, bool complete=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Tween.StopAll(Object,bool).target'></a>

`target` [UnityEngine.Object](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Object 'UnityEngine.Object')

<a name='BTD_Mod_Helper.Api.Tween.StopAll(Object,bool).complete'></a>

`complete` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')