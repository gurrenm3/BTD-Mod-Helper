#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenericIEnumerableExt Class

Extensions for il2cpp ienumerables

```csharp
public static class Il2CppGenericIEnumerableExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenericIEnumerableExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.Count<T>(this IEnumerable<T>) Method

Get the total number of elements

```csharp
public static int Count<T>(this IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.GetEnumeratorCollections<T>(this IEnumerable<T>) Method

Get the IEnumerator as type Il2CppSystem.Collections.IEnumerator. Needed for IEnumerator.MoveNext(). Not the same as  
IEnumerable.GetEnumerator()

```csharp
public static IEnumerator GetEnumeratorCollections<T>(this IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIEnumerable_T_,int)'></a>

## Il2CppGenericIEnumerableExt.GetItem<T>(this IEnumerable<T>, int) Method

Return the Item at a specific index

```csharp
public static Object GetItem<T>(this IEnumerable<T> enumerable, int index);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIEnumerable_T_,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIEnumerable_T_,int).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIEnumerable_T_,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToIl2CppList<T>(this IEnumerable<T>) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable)
    where T : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray<T>(this IEnumerable<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this IEnumerable<T> enumerable)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToList<T>(this IEnumerable<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this IEnumerable<T> enumerable)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList<T>(this IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToLockList<T>(this IEnumerable<T>) Method

Return as LockList

```csharp
public static LockList<T> ToLockList<T>(this IEnumerable<T> enumerable)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[Il2CppNinjaKiwi.Common.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.LockList 'Il2CppNinjaKiwi.Common.LockList')