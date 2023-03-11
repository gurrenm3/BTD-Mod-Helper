#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppSystemObjectExt Class

Extensions for Il2cpp objects

```csharp
public static class Il2CppSystemObjectExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppSystemObjectExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase,T)'></a>

## Il2CppSystemObjectExt.Is<T>(this Il2CppObjectBase, T) Method

Check if object is the same type as T

```csharp
public static bool Is<T>(this Il2CppObjectBase instance, out T castObject)
    where T : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase,T).T'></a>

`T`

Type to check
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase,T).instance'></a>

`instance` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase,T).castObject'></a>

`castObject` [T](BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase,T).T 'BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is<T>(this Il2CppObjectBase, T).T')

The casted object if this is of type T

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase)'></a>

## Il2CppSystemObjectExt.Is<T>(this Il2CppObjectBase) Method

Check if object is the same type as T

```csharp
public static bool Is<T>(this Il2CppObjectBase instance)
    where T : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase).T'></a>

`T`

Type to check
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.Is_T_(thisIl2CppObjectBase).instance'></a>

`instance` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject,T)'></a>

## Il2CppSystemObjectExt.IsType<T>(this Object, T) Method

Check if object is the same type as T

```csharp
public static bool IsType<T>(this Object instance, out T castObject)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject,T).T'></a>

`T`

Type to check
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject,T).instance'></a>

`instance` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject,T).castObject'></a>

`castObject` [T](BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject,T).T 'BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType<T>(this Object, T).T')

The casted object if this is of type T

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject)'></a>

## Il2CppSystemObjectExt.IsType<T>(this Object) Method

Check if object is the same type as T

```csharp
public static bool IsType<T>(this Object instance)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject).T'></a>

`T`

Type to check
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.IsType_T_(thisObject).instance'></a>

`instance` [Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ReferenceEquals(thisIl2CppObjectBase,Il2CppObjectBase)'></a>

## Il2CppSystemObjectExt.ReferenceEquals(this Il2CppObjectBase, Il2CppObjectBase) Method

Is this Reference equal to another Object's Reference?

```csharp
public static bool ReferenceEquals(this Il2CppObjectBase instance, Il2CppObjectBase to);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ReferenceEquals(thisIl2CppObjectBase,Il2CppObjectBase).instance'></a>

`instance` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ReferenceEquals(thisIl2CppObjectBase,Il2CppObjectBase).to'></a>

`to` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

Object to compare to

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisbool)'></a>

## Il2CppSystemObjectExt.ToIl2Cpp(this bool) Method

Box a bool into an Il2cpp object

```csharp
public static Object ToIl2Cpp(this bool b);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisbool).b'></a>

`b` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisfloat)'></a>

## Il2CppSystemObjectExt.ToIl2Cpp(this float) Method

Box a float into an Il2cpp object

```csharp
public static Object ToIl2Cpp(this float f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisfloat).f'></a>

`f` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisint)'></a>

## Il2CppSystemObjectExt.ToIl2Cpp(this int) Method

Box a int into an Il2cpp object

```csharp
public static Object ToIl2Cpp(this int i);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.ToIl2Cpp(thisint).i'></a>

`i` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.TypeName(thisIl2CppObjectBase)'></a>

## Il2CppSystemObjectExt.TypeName(this Il2CppObjectBase) Method

Gets the exact il2cpp type name of an object

```csharp
public static string TypeName(this Il2CppObjectBase obj);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemObjectExt.TypeName(thisIl2CppObjectBase).obj'></a>

`obj` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')