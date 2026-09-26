#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppReferenceArray Class

Extensions for il2cpp reference arrays

```csharp
public static class Il2CppReferenceArray
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppReferenceArray
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_)'></a>

## Il2CppReferenceArray.Any<T>(this Il2CppReferenceArray<T>, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this Il2CppReferenceArray<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppReferenceArray.md#BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any<T>(this Il2CppReferenceArray<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_)'></a>

## Il2CppReferenceArray.Any<T>(this Il2CppReferenceArray<T>) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this Il2CppReferenceArray<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.Any_T_(thisIl2CppReferenceArray_T_).source'></a>

`source` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_)'></a>

## Il2CppReferenceArray.FindIndex<T>(this Il2CppReferenceArray<T>, Func<T,bool>) Method

Return the index of the element that matches the predicate

```csharp
public static int FindIndex<T>(this Il2CppReferenceArray<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppReferenceArray.md#BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex_T_(thisIl2CppReferenceArray_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppReferenceArray.FindIndex<T>(this Il2CppReferenceArray<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach_T_(thisIl2CppReferenceArray_T_,System.Action_T_)'></a>

## Il2CppReferenceArray.ForEach<T>(this Il2CppReferenceArray<T>, Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this Il2CppReferenceArray<T> source, System.Action<T> action)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach_T_(thisIl2CppReferenceArray_T_,System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach_T_(thisIl2CppReferenceArray_T_,System.Action_T_).source'></a>

`source` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach_T_(thisIl2CppReferenceArray_T_,System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.Il2CppReferenceArray.md#BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach_T_(thisIl2CppReferenceArray_T_,System.Action_T_).T 'BTD_Mod_Helper.Extensions.Il2CppReferenceArray.ForEach<T>(this Il2CppReferenceArray<T>, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element