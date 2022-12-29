#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## LockedListExt Class

Extensions for system LockedLists

```csharp
public static class LockedListExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LockedListExt
### Methods

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast)'></a>

## LockedListExt.AddTo<TSource,TCast>(this LockList<TSource>, TCast) Method

Return this with an additional Item added to it

```csharp
public static LockList<TSource> AddTo<TSource,TCast>(this LockList<TSource> lockList, TCast objectToAdd)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast).objectToAdd'></a>

`objectToAdd` [TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.AddTo_TSource,TCast_(thisLockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.AddTo<TSource,TCast>(this LockList<TSource>, TCast).TCast')

Item to add

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisLockList_T_)'></a>

## LockedListExt.Duplicate<T>(this LockList<T>) Method

Return a duplicate of this

```csharp
public static LockList<T> Duplicate<T>(this LockList<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.Duplicate_T_(thisLockList_T_).list'></a>

`list` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisLockList_TSource_)'></a>

## LockedListExt.DuplicateAs<TSource,TCast>(this LockList<TSource>) Method

Return a duplicate of this as type TCast

```csharp
public static LockList<TCast> DuplicateAs<TSource,TCast>(this LockList<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisLockList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.DuplicateAs_TSource,TCast_(thisLockList_TSource_).list'></a>

`list` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisLockList_TSource_)'></a>

## LockedListExt.GetItemsOfType<TSource,TCast>(this LockList<TSource>) Method

Return all Items of type TCast

```csharp
public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this LockList<TSource> lockList)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisLockList_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType_TSource,TCast_(thisLockList_TSource_).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.GetItemsOfType<TSource,TCast>(this LockList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisLockList_TSource_)'></a>

## LockedListExt.HasItemsOfType<TSource,TCast>(this LockList<TSource>) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this LockList<TSource> lockList)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisLockList_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.HasItemsOfType_TSource,TCast_(thisLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast)'></a>

## LockedListExt.RemoveItem<TSource,TCast>(this LockList<TSource>, TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static LockList<TSource> RemoveItem<TSource,TCast>(this LockList<TSource> lockList, TCast itemToRemove)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem_TSource,TCast_(thisLockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.LockedListExt.RemoveItem<TSource,TCast>(this LockList<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisLockList_TSource_)'></a>

## LockedListExt.RemoveItemOfType<TSource,TCast>(this LockList<TSource>) Method

Return this with the first Item of type TCast removed

```csharp
public static LockList<TSource> RemoveItemOfType<TSource,TCast>(this LockList<TSource> lockList)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisLockList_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemOfType_TSource,TCast_(thisLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisLockList_TSource_)'></a>

## LockedListExt.RemoveItemsOfType<TSource,TCast>(this LockList<TSource>) Method

Return this with all Items of type TCast removed

```csharp
public static LockList<TSource> RemoveItemsOfType<TSource,TCast>(this LockList<TSource> lockList)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisLockList_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.RemoveItemsOfType_TSource,TCast_(thisLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisLockList_T_)'></a>

## LockedListExt.ToArray<T>(this LockList<T>) Method

Return as System.Array

```csharp
public static T[] ToArray<T>(this LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToArray_T_(thisLockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToArray<T>(this LockList<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisLockList_T_)'></a>

## LockedListExt.ToIl2CppList<T>(this LockList<T>) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppList_T_(thisLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisLockList_T_)'></a>

## LockedListExt.ToIl2CppReferenceArray<T>(this LockList<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this LockList<T> lockList)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToIl2CppReferenceArray_T_(thisLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisLockList_T_)'></a>

## LockedListExt.ToList<T>(this LockList<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.LockedListExt.md#BTD_Mod_Helper.Extensions.LockedListExt.ToList_T_(thisLockList_T_).T 'BTD_Mod_Helper.Extensions.LockedListExt.ToList<T>(this LockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisLockList_T_)'></a>

## LockedListExt.ToSizedList<T>(this LockList<T>) Method

Not Tested

```csharp
public static SizedList<T> ToSizedList<T>(this LockList<T> lockList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedListExt.ToSizedList_T_(thisLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[Il2CppAssets.Scripts.Utils.SizedList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SizedList 'Il2CppAssets.Scripts.Utils.SizedList')