#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameObjectExt Class

Extensions for GameObjects

```csharp
public static class GameObjectExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameObjectExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T)'></a>

## GameObjectExt.AddModHelperComponent<T>(this GameObject, T) Method

Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent  
<br/>  
(This is an extension method just so that we can return the type generically)

```csharp
public static T AddModHelperComponent<T>(this UnityEngine.GameObject gameObject, T modHelperComponent)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T).modHelperComponent'></a>

`modHelperComponent` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this UnityEngine.GameObject, T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisUnityEngine.GameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this UnityEngine.GameObject, T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int)'></a>

## GameObjectExt.AddModHelperPanel(this GameObject, Info, SpriteReference, Nullable<Axis>, float, int) Method

Creates a new ModHelperPanel

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperPanel AddModHelperPanel(this UnityEngine.GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, Assets.Scripts.Utils.SpriteReference backgroundSprite=null, System.Nullable<UnityEngine.RectTransform.Axis> layoutAxis=null, float spacing=50f, int padding=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).backgroundSprite'></a>

`backgroundSprite` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

The panel's background sprite

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).layoutAxis'></a>

`layoutAxis` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.RectTransform.Axis](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform.Axis 'UnityEngine.RectTransform.Axis')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If present, creates this panel with a Horizontal/Vertical layout group

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The layout group's spacing

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,Assets.Scripts.Utils.SpriteReference,System.Nullable_UnityEngine.RectTransform.Axis_,float,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The layout group's padding

#### Returns
[ModHelperPanel](BTD_Mod_Helper.Api.Components.ModHelperPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperPanel')  
The created ModHelperPanel

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int)'></a>

## GameObjectExt.AddModHelperScrollPanel(this GameObject, Info, Nullable<Axis>, SpriteReference, float, int) Method

Creates a new ModHelperScrollPanel

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperScrollPanel AddModHelperScrollPanel(this UnityEngine.GameObject gameObject, BTD_Mod_Helper.Api.Components.Info info, System.Nullable<UnityEngine.RectTransform.Axis> axis, Assets.Scripts.Utils.SpriteReference backgroundSprite=null, float spacing=0f, int padding=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).axis'></a>

`axis` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.RectTransform.Axis](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RectTransform.Axis 'UnityEngine.RectTransform.Axis')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

The axis that it scrolls in, or null for both directions

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).backgroundSprite'></a>

`backgroundSprite` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

The panel's background sprite

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).spacing'></a>

`spacing` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If axis is not null, then the layout spacing for the items

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperScrollPanel(thisUnityEngine.GameObject,BTD_Mod_Helper.Api.Components.Info,System.Nullable_UnityEngine.RectTransform.Axis_,Assets.Scripts.Utils.SpriteReference,float,int).padding'></a>

`padding` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[ModHelperScrollPanel](BTD_Mod_Helper.Api.Components.ModHelperScrollPanel.md 'BTD_Mod_Helper.Api.Components.ModHelperScrollPanel')  
The created ModHelperScrollPanel

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisUnityEngine.GameObject)'></a>

## GameObjectExt.Destroy(this GameObject) Method

Destroys this GameObject

```csharp
public static void Destroy(this UnityEngine.GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisUnityEngine.GameObject)'></a>

## GameObjectExt.DestroyAllChildren(this GameObject) Method

Destroys all children of a game object

```csharp
public static void DestroyAllChildren(this UnityEngine.GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT)'></a>

## GameObjectExt.Duplicate<T>(this T) Method

Instantiate a clone of the GameObject keeping the same parent

```csharp
public static T Duplicate<T>(this T gameObject)
    where T : UnityEngine.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform)'></a>

## GameObjectExt.Duplicate<T>(this T, Transform) Method

Instantiate a clone of the GameObject with the new transform as parent

```csharp
public static T Duplicate<T>(this T gameObject, UnityEngine.Transform parent)
    where T : UnityEngine.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, UnityEngine.Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform).parent'></a>

`parent` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,UnityEngine.Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, UnityEngine.Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT)'></a>

## GameObjectExt.Exists<T>(this T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static T Exists<T>(this T obj)
    where T : UnityEngine.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).obj'></a>

`obj` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T)'></a>

## GameObjectExt.Exists<T>(this T, T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static bool Exists<T>(this T obj, out T result)
    where T : UnityEngine.Object;
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

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisUnityEngine.GameObject,string)'></a>

## GameObjectExt.GetComponent<T>(this GameObject, string) Method

Finds a component with the given path and type

```csharp
public static T GetComponent<T>(this UnityEngine.GameObject gameObject, string componentPath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisUnityEngine.GameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisUnityEngine.GameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisUnityEngine.GameObject,string).componentPath'></a>

`componentPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisUnityEngine.GameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent<T>(this UnityEngine.GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisUnityEngine.GameObject,string)'></a>

## GameObjectExt.GetComponentInChildrenByName<T>(this GameObject, string) Method

(Cross-Game compatible) Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren

```csharp
public static T GetComponentInChildrenByName<T>(this UnityEngine.GameObject gameObject, string componentName)
    where T : UnityEngine.Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisUnityEngine.GameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisUnityEngine.GameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisUnityEngine.GameObject,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisUnityEngine.GameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName<T>(this UnityEngine.GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject)'></a>

## GameObjectExt.HasComponent<T>(this GameObject) Method

Returns whether a component of the given type exists on a game object

```csharp
public static bool HasComponent<T>(this UnityEngine.GameObject gameObject)
    where T : UnityEngine.Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject,T)'></a>

## GameObjectExt.HasComponent<T>(this GameObject, T) Method

Returns whether a component of the given type exists on a game object, and puts it in the out param

```csharp
public static bool HasComponent<T>(this UnityEngine.GameObject gameObject, out T component)
    where T : UnityEngine.Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject,T).component'></a>

`component` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisUnityEngine.GameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent<T>(this UnityEngine.GameObject, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisUnityEngine.GameObject)'></a>

## GameObjectExt.Hide(this GameObject) Method

(Cross-Game compatible) Makes the Game Object hidden (not visible) by setting the scale to zero

```csharp
public static void Hide(this UnityEngine.GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisUnityEngine.GameObject,int)'></a>

## GameObjectExt.RecursivelyLog(this GameObject, int) Method

Logs a GameObject's hierarchy recursively

```csharp
public static void RecursivelyLog(this UnityEngine.GameObject gameObject, int depth=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisUnityEngine.GameObject,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisUnityEngine.GameObject,int).depth'></a>

`depth` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisUnityEngine.GameObject)'></a>

## GameObjectExt.RemoveComponent<T>(this GameObject) Method

Removes a Component from a GameObject by destroying it

```csharp
public static void RemoveComponent<T>(this UnityEngine.GameObject gameObject)
    where T : UnityEngine.Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisUnityEngine.GameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisUnityEngine.GameObject)'></a>

## GameObjectExt.Show(this GameObject) Method

(Cross-Game compatible) Makes the Game Object visible by setting the scale to the default value of 1

```csharp
public static void Show(this UnityEngine.GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisUnityEngine.GameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisUnityEngine.GameObject,UnityEngine.Vector3)'></a>

## GameObjectExt.TranslateScaled(this GameObject, Vector3) Method

(Cross-Game compatible) Translates this GameObject scaled with it's "lossyScale", making it move the same  
amount regardless of screen resolution

```csharp
public static void TranslateScaled(this UnityEngine.GameObject gameObject, UnityEngine.Vector3 translation);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisUnityEngine.GameObject,UnityEngine.Vector3).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisUnityEngine.GameObject,UnityEngine.Vector3).translation'></a>

`translation` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')