#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenericsExt Class

Extensions for generic il2cpp lists

```csharp
public static class Il2CppGenericsExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenericsExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.Duplicate<T>(this List<T>) Method

Return a duplicate of this List

```csharp
public static Il2CppSystem.Collections.Generic.List<T> Duplicate<T>(this Il2CppSystem.Collections.Generic.List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisIl2CppSystem.Collections.Generic.List_T_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.Duplicate<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.DuplicateAs<TSource,TCast>(this List<TSource>) Method

Return a duplicate of this list as type TCast

```csharp
public static Il2CppSystem.Collections.Generic.List<TCast> DuplicateAs<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.DuplicateAs<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.GetItemOfType<TSource,TCast>(this List<TSource>) Method

Return the first item of type TCast

```csharp
public static TCast GetItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Item you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TCast')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.GetItemsOfType<TSource,TCast>(this List<TSource>) Method

Return all Items of type TCast

```csharp
public static Il2CppSystem.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.GetItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.HasItemsOfType<TSource,TCast>(this List<TSource>) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.HasItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast)'></a>

## Il2CppGenericsExt.RemoveItem<TSource,TCast>(this List<TSource>, TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItem<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list, TCast itemToRemove)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItem<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.RemoveItemOfType<TSource,TCast>(this List<TSource>) Method

Return this with the first Item of type TCast removed

```csharp
public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_)'></a>

## Il2CppGenericsExt.RemoveItemsOfType<TSource,TCast>(this List<TSource>) Method

Return this with all Items of type TCast removed

```csharp
public static Il2CppSystem.Collections.Generic.List<TSource> RemoveItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).list'></a>

`list` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType_TSource,TCast_(thisIl2CppSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.RemoveItemsOfType<TSource,TCast>(this Il2CppSystem.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.ToArray<T>(this List<T>) Method

Return as an Array

```csharp
public static T[] ToArray<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToArray<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.ToIl2CppReferenceArray<T>(this List<T>) Method

Return as Il2CppReferenceArray

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToIl2CppReferenceArray<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.ToList<T>(this List<T>) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisIl2CppSystem.Collections.Generic.List_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.ToLockList<T>(this List<T>) Method

Return as LockList

```csharp
public static Assets.Scripts.Utils.LockList<T> ToLockList<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.List_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToLockList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList_T_(thisIl2CppSystem.Collections.Generic.List_T_)'></a>

## Il2CppGenericsExt.ToSizedList<T>(this List<T>) Method

Not tested

```csharp
public static Assets.Scripts.Utils.SizedList<T> ToSizedList<T>(this Il2CppSystem.Collections.Generic.List<T> il2CppList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList_T_(thisIl2CppSystem.Collections.Generic.List_T_).il2CppList'></a>

`il2CppList` [Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericsExt.md#BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList_T_(thisIl2CppSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericsExt.ToSizedList<T>(this Il2CppSystem.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')