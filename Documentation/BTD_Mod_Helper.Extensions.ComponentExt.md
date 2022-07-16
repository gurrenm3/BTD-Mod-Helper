#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ComponentExt Class

Extensions for Component

```csharp
public static class ComponentExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ComponentExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Destroy(thisUnityEngine.Component)'></a>

## ComponentExt.Destroy(this Component) Method

Destroys this Component

```csharp
public static void Destroy(this UnityEngine.Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Destroy(thisUnityEngine.Component).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisUnityEngine.Component,string)'></a>

## ComponentExt.GetComponent<T>(this Component, string) Method

Finds the component with the given path and type

```csharp
public static T GetComponent<T>(this UnityEngine.Component component, string componentPath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisUnityEngine.Component,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisUnityEngine.Component,string).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisUnityEngine.Component,string).componentPath'></a>

`componentPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ComponentExt.md#BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisUnityEngine.Component,string).T 'BTD_Mod_Helper.Extensions.ComponentExt.GetComponent<T>(this UnityEngine.Component, string).T')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisUnityEngine.Component,string)'></a>

## ComponentExt.GetComponentFromChildrenByName<T>(this Component, string) Method

(Cross-Game compatible) Try to get a component in a child of this Component by it's name. Equivelant to a foreach with GetComponentsInChildren

```csharp
public static T GetComponentFromChildrenByName<T>(this UnityEngine.Component component, string componentName)
    where T : UnityEngine.Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisUnityEngine.Component,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisUnityEngine.Component,string).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisUnityEngine.Component,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ComponentExt.md#BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisUnityEngine.Component,string).T 'BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName<T>(this UnityEngine.Component, string).T')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Hide(thisUnityEngine.Component)'></a>

## ComponentExt.Hide(this Component) Method

(Cross-Game compatible) Makes the Component hidden (not visible) by setting the scale to zero

```csharp
public static void Hide(this UnityEngine.Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Hide(thisUnityEngine.Component).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Show(thisUnityEngine.Component)'></a>

## ComponentExt.Show(this Component) Method

(Cross-Game compatible) Makes the Component visible by setting the scale to the default value of 1

```csharp
public static void Show(this UnityEngine.Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Show(thisUnityEngine.Component).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisUnityEngine.Component,UnityEngine.Vector3)'></a>

## ComponentExt.TranslateScaled(this Component, Vector3) Method

(Cross-Game compatible) Translates this component scaled with it's "lossyScale", making it move the same  
amount regardless of screen resolution

```csharp
public static void TranslateScaled(this UnityEngine.Component component, UnityEngine.Vector3 translation);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisUnityEngine.Component,UnityEngine.Vector3).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisUnityEngine.Component,UnityEngine.Vector3).translation'></a>

`translation` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')