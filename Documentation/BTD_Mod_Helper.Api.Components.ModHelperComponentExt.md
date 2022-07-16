#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperComponentExt Class

Extensions for mod helper components, for using generics and based on restricts for il2cpp objects

```csharp
public static class ModHelperComponentExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ModHelperComponentExt
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T)'></a>

## ModHelperComponentExt.AddModHelperComponent<T>(this ModHelperComponent, T) Method

Adds the ModHelperComponent to a parent GameObject, returning the ModHelperComponent  
<br/>  
(This is an extension method just so that we can return the type generically)

```csharp
public static T AddModHelperComponent<T>(this BTD_Mod_Helper.Api.Components.ModHelperComponent parentComponent, T modHelperComponent)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T).parentComponent'></a>

`parentComponent` [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T).modHelperComponent'></a>

`modHelperComponent` [T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent<T>(this BTD_Mod_Helper.Api.Components.ModHelperComponent, T).T')

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent_T_(thisBTD_Mod_Helper.Api.Components.ModHelperComponent,T).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddModHelperComponent<T>(this BTD_Mod_Helper.Api.Components.ModHelperComponent, T).T')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform)'></a>

## ModHelperComponentExt.AddTo<T>(this T, Transform) Method

Adds the ModHelperComponent to a parent Transform, returning the ModHelperComponent  
<br/>  
(This is an extension method just so that we can return the type generically)

```csharp
public static T AddTo<T>(this T modHelperComponent, UnityEngine.Transform parent)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform).modHelperComponent'></a>

`modHelperComponent` [T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo<T>(this T, UnityEngine.Transform).T')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform).parent'></a>

`parent` [UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo_T_(thisT,UnityEngine.Transform).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.AddTo<T>(this T, UnityEngine.Transform).T')

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string)'></a>

## ModHelperComponentExt.Duplicate<T>(this T, string) Method

Creates a copy of this ModHelperComponent with the same parent

```csharp
public static T Duplicate<T>(this T component, string name)
    where T : BTD_Mod_Helper.Api.Components.ModHelperComponent;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string).component'></a>

`component` [T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate<T>(this T, string).T')

this

<a name='BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Its new name

#### Returns
[T](BTD_Mod_Helper.Api.Components.ModHelperComponentExt.md#BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate_T_(thisT,string).T 'BTD_Mod_Helper.Api.Components.ModHelperComponentExt.Duplicate<T>(this T, string).T')