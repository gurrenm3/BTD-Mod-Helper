#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RootObjectLockList Class

Extensions for RootObjectLockLists

```csharp
public static class RootObjectLockList
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RootObjectLockList
### Methods

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast)'></a>

## RootObjectLockList.AddTo<TSource,TCast>(this RootObjectLockList<TSource>, TCast) Method

Return this with an additional Item added to it

```csharp
public static RootObjectLockList<TSource> AddTo<TSource,TCast>(this RootObjectLockList<TSource> lockList, TCast objectToAdd)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).objectToAdd'></a>

`objectToAdd` [TCast](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.RootObjectLockList.AddTo<TSource,TCast>(this RootObjectLockList<TSource>, TCast).TCast')

Item to add

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.Duplicate_T_(thisRootObjectLockList_T_)'></a>

## RootObjectLockList.Duplicate<T>(this RootObjectLockList<T>) Method

Return a duplicate of this

```csharp
public static RootObjectLockList<T> Duplicate<T>(this RootObjectLockList<T> list)
    where T : RootObject;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.Duplicate_T_(thisRootObjectLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.Duplicate_T_(thisRootObjectLockList_T_).list'></a>

`list` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.DuplicateAs_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.DuplicateAs<TSource,TCast>(this RootObjectLockList<TSource>) Method

Return a duplicate of this as type TCast

```csharp
public static RootObjectLockList<TCast> DuplicateAs<TSource,TCast>(this RootObjectLockList<TSource> list)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.DuplicateAs_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.DuplicateAs_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.DuplicateAs_TSource,TCast_(thisRootObjectLockList_TSource_).list'></a>

`list` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.GetItemOfType<TSource,TCast>(this RootObjectLockList<TSource>) Method

```csharp
public static TCast GetItemOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast 'BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemOfType<TSource,TCast>(this RootObjectLockList<TSource>).TCast')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.GetItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>) Method

Return all Items of type TCast

```csharp
public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast 'BTD_Mod_Helper.Extensions.RootObjectLockList.GetItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast)'></a>

## RootObjectLockList.HasItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>, TCast) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList, out TCast item)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).item'></a>

`item` [TCast](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>, TCast).TCast')

The found item, if any

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.HasItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.HasItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast)'></a>

## RootObjectLockList.RemoveItem<TSource,TCast>(this RootObjectLockList<TSource>, TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static RootObjectLockList<TSource> RemoveItem<TSource,TCast>(this RootObjectLockList<TSource> lockList, TCast itemToRemove)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem_TSource,TCast_(thisRootObjectLockList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItem<TSource,TCast>(this RootObjectLockList<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.RemoveItemOfType<TSource,TCast>(this RootObjectLockList<TSource>) Method

Return this with the first Item of type TCast removed

```csharp
public static RootObjectLockList<TSource> RemoveItemOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemOfType_TSource,TCast_(thisRootObjectLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_)'></a>

## RootObjectLockList.RemoveItemsOfType<TSource,TCast>(this RootObjectLockList<TSource>) Method

Return this with all Items of type TCast removed

```csharp
public static RootObjectLockList<TSource> RemoveItemsOfType<TSource,TCast>(this RootObjectLockList<TSource> lockList)
    where TSource : Il2CppObjectBase
    where TCast : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.RemoveItemsOfType_TSource,TCast_(thisRootObjectLockList_TSource_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToArray_T_(thisRootObjectLockList_T_)'></a>

## RootObjectLockList.ToArray<T>(this RootObjectLockList<T>) Method

Return as System.Array

```csharp
public static T[] ToArray<T>(this RootObjectLockList<T> lockList)
    where T : RootObject;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToArray_T_(thisRootObjectLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToArray_T_(thisRootObjectLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[T](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.ToArray_T_(thisRootObjectLockList_T_).T 'BTD_Mod_Helper.Extensions.RootObjectLockList.ToArray<T>(this RootObjectLockList<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppList_T_(thisRootObjectLockList_T_)'></a>

## RootObjectLockList.ToIl2CppList<T>(this RootObjectLockList<T>) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this RootObjectLockList<T> lockList)
    where T : RootObject;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppList_T_(thisRootObjectLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppList_T_(thisRootObjectLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppReferenceArray_T_(thisRootObjectLockList_T_)'></a>

## RootObjectLockList.ToIl2CppReferenceArray<T>(this RootObjectLockList<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this RootObjectLockList<T> lockList)
    where T : RootObject;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppReferenceArray_T_(thisRootObjectLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToIl2CppReferenceArray_T_(thisRootObjectLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToList_T_(thisRootObjectLockList_T_)'></a>

## RootObjectLockList.ToList<T>(this RootObjectLockList<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this RootObjectLockList<T> lockList)
    where T : RootObject;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToList_T_(thisRootObjectLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RootObjectLockList.ToList_T_(thisRootObjectLockList_T_).lockList'></a>

`lockList` [Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.RootObjectLockList.md#BTD_Mod_Helper.Extensions.RootObjectLockList.ToList_T_(thisRootObjectLockList_T_).T 'BTD_Mod_Helper.Extensions.RootObjectLockList.ToList<T>(this RootObjectLockList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')