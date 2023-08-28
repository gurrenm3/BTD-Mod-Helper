#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ComponentExt Class

Extensions for Component

```csharp
public static class ComponentExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ComponentExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Destroy(thisComponent)'></a>

## ComponentExt.Destroy(this Component) Method

Destroys this Component

```csharp
public static void Destroy(this Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Destroy(thisComponent).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisComponent,string)'></a>

## ComponentExt.GetComponent<T>(this Component, string) Method

Finds the component with the given path and type

```csharp
public static T GetComponent<T>(this Component component, string componentPath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisComponent,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisComponent,string).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisComponent,string).componentPath'></a>

`componentPath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ComponentExt.md#BTD_Mod_Helper.Extensions.ComponentExt.GetComponent_T_(thisComponent,string).T 'BTD_Mod_Helper.Extensions.ComponentExt.GetComponent<T>(this Component, string).T')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisComponent,string)'></a>

## ComponentExt.GetComponentFromChildrenByName<T>(this Component, string) Method

Try to get a component in a child of this Component by it's name. Equivalent to a foreach with GetComponentsInChildren

```csharp
public static T GetComponentFromChildrenByName<T>(this Component component, string componentName)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisComponent,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisComponent,string).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisComponent,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ComponentExt.md#BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName_T_(thisComponent,string).T 'BTD_Mod_Helper.Extensions.ComponentExt.GetComponentFromChildrenByName<T>(this Component, string).T')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName_T_(thisComponent,string)'></a>

## ComponentExt.GetComponentsFromChildrenByName<T>(this Component, string) Method

Tries to get all component in a child of this Component by it's name. Equivalent to a foreach with GetComponentsInChildren

```csharp
public static T[] GetComponentsFromChildrenByName<T>(this Component component, string componentName)
    where T : Component;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName_T_(thisComponent,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName_T_(thisComponent,string).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName_T_(thisComponent,string).componentName'></a>

`componentName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[T](BTD_Mod_Helper.Extensions.ComponentExt.md#BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName_T_(thisComponent,string).T 'BTD_Mod_Helper.Extensions.ComponentExt.GetComponentsFromChildrenByName<T>(this Component, string).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Hide(thisComponent)'></a>

## ComponentExt.Hide(this Component) Method

Makes the Component hidden (not visible) by setting the scale to zero

```csharp
public static void Hide(this Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Hide(thisComponent).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Show(thisComponent)'></a>

## ComponentExt.Show(this Component) Method

Makes the Component visible by setting the scale to the default value of 1

```csharp
public static void Show(this Component component);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.Show(thisComponent).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisComponent,Vector3)'></a>

## ComponentExt.TranslateScaled(this Component, Vector3) Method

Translates this component scaled with it's "lossyScale", making it move the same  
amount regardless of screen resolution

```csharp
public static void TranslateScaled(this Component component, Vector3 translation);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisComponent,Vector3).component'></a>

`component` [UnityEngine.Component](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Component 'UnityEngine.Component')

<a name='BTD_Mod_Helper.Extensions.ComponentExt.TranslateScaled(thisComponent,Vector3).translation'></a>

`translation` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')