#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenericsExt Class

Extensions for generic il2cpp lists

```csharp
public static class Il2CppGenericsExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenericsExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisList_T_)'></a>

## Il2CppGenericsExt.Duplicate<T>(this List<T>) Method

Return a duplicate of this List

```csharp
public static List<T> Duplicate<T>(this List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisList_T_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.DuplicateAs<TSource,TCast>(this List<TSource>) Method

Return a duplicate of this list as type TCast

```csharp
public static List<TCast> DuplicateAs<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get_T_(thisList_T_,int)'></a>

## Il2CppGenericsExt.Get<T>(this List<T>, int) Method

Gets the item at the specified index. Circumvents "ambiguous indexer" warnings

```csharp
public static T Get<T>(this List<T> list, int index);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get_T_(thisList_T_,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get_T_(thisList_T_,int).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get_T_(thisList_T_,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get_T_(thisList_T_,int).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Get<T>(this List<T>, int).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.GetItemOfType<TSource,TCast>(this List<TSource>) Method

Return the first item of type TCast

```csharp
public static TCast GetItemOfType<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`

The Type of the Item you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisList_TSource_).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType<TSource,TCast>(this List<TSource>).TCast')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.GetItemsOfType<TSource,TCast>(this List<TSource>) Method

Return all Items of type TCast

```csharp
public static List<TCast> GetItemsOfType<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.HasItemsOfType<TSource,TCast>(this List<TSource>) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast)'></a>

## Il2CppGenericsExt.RemoveItem<TSource,TCast>(this List<TSource>, TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static List<TSource> RemoveItem<TSource,TCast>(this List<TSource> list, TCast itemToRemove)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem<TSource,TCast>(this List<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.RemoveItemOfType<TSource,TCast>(this List<TSource>) Method

Return this with the first Item of type TCast removed

```csharp
public static List<TSource> RemoveItemOfType<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisList_TSource_)'></a>

## Il2CppGenericsExt.RemoveItemsOfType<TSource,TCast>(this List<TSource>) Method

Return this with all Items of type TCast removed

```csharp
public static List<TSource> RemoveItemsOfType<TSource,TCast>(this List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisList_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisList_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisList_T_)'></a>

## Il2CppGenericsExt.ToArray<T>(this List<T>) Method

Return as an Array

```csharp
public static T[] ToArray<T>(this List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisList_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisList_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray<T>(this List<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisList_T_)'></a>

## Il2CppGenericsExt.ToIl2CppReferenceArray<T>(this List<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this List<T> il2CppList)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisList_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisList_T_)'></a>

## Il2CppGenericsExt.ToList<T>(this List<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisList_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisList_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList<T>(this List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisList_T_)'></a>

## Il2CppGenericsExt.ToLockList<T>(this List<T>) Method

Return as LockList

```csharp
public static LockList<T> ToLockList<T>(this List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisList_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')