#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## LockedListExt Class

Extensions for system LockedLists

```csharp
public static class LockedListExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LockedListExt
### Methods

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast)'></a>

## LockedListExt.AddTo<TSource,TCast>(this LockList<TSource>, TCast) Method

(Cross-Game compatible) Return this with an additional Item added to it

```csharp
public static Assets.Scripts.Utils.LockList<TSource> AddTo<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList, TCast objectToAdd)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.AddTo<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).objectToAdd'></a>

`objectToAdd` [TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.AddTo<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TCast')

Item to add

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.AddTo<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.Duplicate<T>(this LockList<T>) Method

(Cross-Game compatible) Return a duplicate of this

```csharp
public static Assets.Scripts.Utils.LockList<T> Duplicate<T>(this Assets.Scripts.Utils.LockList<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisAssets.Scripts.Utils.LockList_T_).list'></a>

`list` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.Duplicate<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.Duplicate<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_)'></a>

## LockedListExt.DuplicateAs<TSource,TCast>(this LockList<TSource>) Method

(Cross-Game compatible) Return a duplicate of this as type TCast

```csharp
public static Assets.Scripts.Utils.LockList<TCast> DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).list'></a>

`list` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_)'></a>

## LockedListExt.GetItemsOfType<TSource,TCast>(this LockList<TSource>) Method

(Cross-Game compatible) Return all Items of type TCast

```csharp
public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_)'></a>

## LockedListExt.HasItemsOfType<TSource,TCast>(this LockList<TSource>) Method

(Cross-Game compatible) Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast)'></a>

## LockedListExt.RemoveItem<TSource,TCast>(this LockList<TSource>, TCast) Method

(Cross-Game compatible) Return this with the first Item of type TCast removed

```csharp
public static Assets.Scripts.Utils.LockList<TSource> RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList, TCast itemToRemove)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_)'></a>

## LockedListExt.RemoveItemOfType<TSource,TCast>(this LockList<TSource>) Method

(Cross-Game compatible) Return this with the first Item of type TCast removed

```csharp
public static Assets.Scripts.Utils.LockList<TSource> RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_)'></a>

## LockedListExt.RemoveItemsOfType<TSource,TCast>(this LockList<TSource>) Method

(Cross-Game compatible) Return this with all Items of type TCast removed

```csharp
public static Assets.Scripts.Utils.LockList<TSource> RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource> lockList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[TSource](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.LockList_TSource_).TSource 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.LockList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.ToArray<T>(this LockList<T>) Method

(Cross-Game compatible) Return as System.Array

```csharp
public static T[] ToArray<T>(this Assets.Scripts.Utils.LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisAssets.Scripts.Utils.LockList_T_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToArray<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToArray<T>(this Assets.Scripts.Utils.LockList<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.ToIl2CppList<T>(this LockList<T>) Method

(Cross-Game compatible) Return as Il2CppSystem.List

```csharp
public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this Assets.Scripts.Utils.LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.LockList_T_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.ToIl2CppReferenceArray<T>(this LockList<T>) Method

(Cross-Game compatible) Return as Il2CppReferenceArray

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.LockList<T> lockList)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.LockList_T_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.ToList<T>(this LockList<T>) Method

(Cross-Game compatible) Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this Assets.Scripts.Utils.LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisAssets.Scripts.Utils.LockList_T_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisAssets.Scripts.Utils.LockList_T_)'></a>

## LockedListExt.ToSizedList<T>(this LockList<T>) Method

Not Tested

```csharp
public static Assets.Scripts.Utils.SizedList<T> ToSizedList<T>(this Assets.Scripts.Utils.LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisAssets.Scripts.Utils.LockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisAssets.Scripts.Utils.LockList_T_).lockList'></a>

`lockList` [Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisAssets.Scripts.Utils.LockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList<T>(this Assets.Scripts.Utils.LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')