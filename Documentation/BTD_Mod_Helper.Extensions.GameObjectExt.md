#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## GameObjectExt Class

Extensions for GameObjects

```csharp
public static class GameObjectExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; GameObjectExt
### Methods

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T)'></a>

## GameObjectExt.AddModHelperComponent<T>(this GameObject, T) Method

Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent  
<br/>  
(This is an extension method just so that we can return the type generically)

```csharp
public static T AddModHelperComponent<T>(this GameObject gameObject, T modHelperComponent)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).modHelperComponent'></a>

`modHelperComponent` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this GameObject, T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.AddModHelperComponent<T>(this GameObject, T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisGameObject)'></a>

## GameObjectExt.Destroy(this GameObject) Method

Destroys this GameObject

```csharp
public static void Destroy(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Destroy(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisGameObject)'></a>

## GameObjectExt.DestroyAllChildren(this GameObject) Method

Destroys all children of a game object

```csharp
public static void DestroyAllChildren(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.DestroyAllChildren(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform)'></a>

## GameObjectExt.Duplicate<T>(this T, Transform) Method

Instantiate a clone of the GameObject with the new transform as parent

```csharp
public static T Duplicate<T>(this T gameObject, Transform parent)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).parent'></a>

`parent` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT,Transform).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T, Transform).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT)'></a>

## GameObjectExt.Duplicate<T>(this T) Method

Instantiate a clone of the GameObject keeping the same parent

```csharp
public static T Duplicate<T>(this T gameObject)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).gameObject'></a>

`gameObject` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Duplicate<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT,T)'></a>

## GameObjectExt.Exists<T>(this T, T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static bool Exists<T>(this T obj, out T result)
    where T : Object;
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

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT)'></a>

## GameObjectExt.Exists<T>(this T) Method

Used to null check unity objects without bypassing the lifecycle

```csharp
public static T Exists<T>(this T obj)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).obj'></a>

`obj` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.Exists_T_(thisT).T 'BTD_Mod_Helper.Extensions.GameObjectExt.Exists<T>(this T).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string)'></a>

## GameObjectExt.GetComponent<T>(this GameObject, string) Method

Finds a component with the given path and type

```csharp
public static T GetComponent<T>(this GameObject gameObject, string componentPath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).componentPath'></a>

`componentPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent_T_(thisGameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponent<T>(this GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string)'></a>

## GameObjectExt.GetComponentInChildrenByName<T>(this GameObject, string) Method

Try to get a component in a child of this GameObject by it's name. Equivelant to a foreach with GetComponentsInChildren

```csharp
public static T GetComponentInChildrenByName<T>(this GameObject gameObject, string componentName)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName_T_(thisGameObject,string).T 'BTD_Mod_Helper.Extensions.GameObjectExt.GetComponentInChildrenByName<T>(this GameObject, string).T')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T)'></a>

## GameObjectExt.HasComponent<T>(this GameObject, T) Method

Returns whether a component of the given type exists on a game object, and puts it in the out param

```csharp
public static bool HasComponent<T>(this GameObject gameObject, out T component)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).component'></a>

`component` [T](BTD_Mod_Helper.Extensions.GameObjectExt.md#BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject,T).T 'BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent<T>(this GameObject, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject)'></a>

## GameObjectExt.HasComponent<T>(this GameObject) Method

Returns whether a component of the given type exists on a game object

```csharp
public static bool HasComponent<T>(this GameObject gameObject)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.HasComponent_T_(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisGameObject)'></a>

## GameObjectExt.Hide(this GameObject) Method

Makes the Game Object hidden (not visible) by setting the scale to zero

```csharp
public static void Hide(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Hide(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int)'></a>

## GameObjectExt.RecursivelyLog(this GameObject, int) Method

Logs a GameObject's hierarchy recursively

```csharp
public static void RecursivelyLog(this GameObject gameObject, int depth=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RecursivelyLog(thisGameObject,int).depth'></a>

`depth` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject)'></a>

## GameObjectExt.RemoveComponent<T>(this GameObject) Method

Removes a Component from a GameObject by destroying it

```csharp
public static void RemoveComponent<T>(this GameObject gameObject)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.RemoveComponent_T_(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisGameObject)'></a>

## GameObjectExt.Show(this GameObject) Method

Makes the Game Object visible by setting the scale to the default value of 1

```csharp
public static void Show(this GameObject gameObject);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.Show(thisGameObject).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3)'></a>

## GameObjectExt.TranslateScaled(this GameObject, Vector3) Method

Translates this GameObject scaled with it's "lossyScale", making it move the same  
amount regardless of screen resolution

```csharp
public static void TranslateScaled(this GameObject gameObject, Vector3 translation);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3).gameObject'></a>

`gameObject` [UnityEngine.GameObject](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.GameObject 'UnityEngine.GameObject')

<a name='BTD_Mod_Helper.Extensions.GameObjectExt.TranslateScaled(thisGameObject,Vector3).translation'></a>

`translation` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')