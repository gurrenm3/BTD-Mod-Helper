#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenericIEnumerableExt Class

Extensions for il2cpp ienumerables

```csharp
public static class Il2CppGenericIEnumerableExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenericIEnumerableExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.Count<T>(this IEnumerable<T>) Method

Get the total number of elements

```csharp
public static int Count<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.Count<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.GetEnumeratorCollections<T>(this IEnumerable<T>) Method

Get the IEnumerator as type Il2CppSystem.Collections.IEnumerator. Needed for IEnumerator.MoveNext(). Not the same as IEnumerable.GetEnumerator()

```csharp
public static Il2CppSystem.Collections.IEnumerator GetEnumeratorCollections<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetEnumeratorCollections<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_,int)'></a>

## Il2CppGenericIEnumerableExt.GetItem<T>(this IEnumerable<T>, int) Method

Return the Item at a specific index

```csharp
public static Il2CppSystem.Object GetItem<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable, int index);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_,int).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_,int).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>, int).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.GetItem_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToIl2CppList<T>(this IEnumerable<T>) Method

Return as Il2CppSystem.List

```csharp
public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray<T>(this IEnumerable<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray-1 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray-1 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToList<T>(this IEnumerable<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_)'></a>

## Il2CppGenericIEnumerableExt.ToLockList<T>(this IEnumerable<T>) Method

Return as LockList

```csharp
public static Il2CppAssets.Scripts.Utils.LockList<T> ToLockList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T> enumerable)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable-1 'Il2CppSystem.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList-1 'Il2CppAssets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerableExt.ToLockList<T>(this Il2CppSystem.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList-1 'Il2CppAssets.Scripts.Utils.LockList`1')