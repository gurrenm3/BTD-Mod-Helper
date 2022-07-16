#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## SizedListExt Class

Extensions for SizedLists

```csharp
public static class SizedListExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SizedListExt
### Methods

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.Any<T>(this SizedList<T>) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this Assets.Scripts.Utils.SizedList<T> source)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Any<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.Any<T>(this SizedList<T>, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Any<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Any_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Any<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Duplicate_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.Duplicate<T>(this SizedList<T>) Method

Constructs a new SizedList with the same elements

```csharp
public static Assets.Scripts.Utils.SizedList<T> Duplicate<T>(this Assets.Scripts.Utils.SizedList<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Duplicate_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Duplicate_T_(thisAssets.Scripts.Utils.SizedList_T_).list'></a>

`list` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Duplicate_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Duplicate<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Duplicate_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Duplicate<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.DuplicateAs<TSource,TCast>(this SizedList<TSource>) Method

Constructs a new SizedList with the same elements, but casted

```csharp
public static Assets.Scripts.Utils.SizedList<TCast> DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> list)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).list'></a>

`list` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TCast](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast 'BTD_Mod_Helper.Extensions.SizedListExt.DuplicateAs<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.FindIndex<T>(this SizedList<T>, Func<T,bool>) Method

Return the index of the element that matches the predicate

```csharp
public static int FindIndex<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FindIndex<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FindIndex_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FindIndex<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.First<T>(this SizedList<T>) Method

Return the first element in the collection

```csharp
public static T First<T>(this Assets.Scripts.Utils.SizedList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.First<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.First<T>(this Assets.Scripts.Utils.SizedList<T>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.First<T>(this SizedList<T>, Func<T,bool>) Method

Return the first element that matches the predicate

```csharp
public static T First<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.First<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.First<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.First_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.First<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.FirstOrDefault<T>(this SizedList<T>) Method

Return the first element in the collection, or return default if it's null

```csharp
public static T FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.FirstOrDefault<T>(this SizedList<T>, Func<T,bool>) Method

Return the first element that matches the predicate, or return default

```csharp
public static T FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.FirstOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_)'></a>

## SizedListExt.ForEach<T>(this SizedList<T>, Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Action<T> action);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ForEach<T>(this Assets.Scripts.Utils.SizedList<T>, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ForEach_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Action_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ForEach<T>(this Assets.Scripts.Utils.SizedList<T>, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.GetItemOfType<TSource,TCast>(this SizedList<TSource>) Method

Gets the first item of a given type within the list

```csharp
public static TCast GetItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast 'BTD_Mod_Helper.Extensions.SizedListExt.GetItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TCast')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.GetItemsOfType<TSource,TCast>(this SizedList<TSource>) Method

Gets all items of a certain type out of a SizedList

```csharp
public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast 'BTD_Mod_Helper.Extensions.SizedListExt.GetItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.HasItemsOfType<TSource,TCast>(this SizedList<TSource>) Method

Returns whether this has any items of the given type

```csharp
public static bool HasItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.HasItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Last_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.Last<T>(this SizedList<T>) Method

Return the last item in the collection

```csharp
public static T Last<T>(this Assets.Scripts.Utils.SizedList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Last_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Last_T_(thisAssets.Scripts.Utils.SizedList_T_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Last_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Last<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Last_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Last<T>(this Assets.Scripts.Utils.SizedList<T>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.LastOrDefault<T>(this SizedList<T>, Func<T,bool>) Method

Return the last item in the collection that meets the condition, or return default

```csharp
public static T LastOrDefault<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.LastOrDefault<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast)'></a>

## SizedListExt.RemoveItem<TSource,TCast>(this SizedList<TSource>, TCast) Method

Returns a new list with the given item returned

```csharp
public static Assets.Scripts.Utils.SizedList<TSource> RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList, TCast itemToRemove)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>, TCast).TCast')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItem<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.RemoveItemOfType<TSource,TCast>(this SizedList<TSource>) Method

Returns a new list with the first item of a given type returned

```csharp
public static Assets.Scripts.Utils.SizedList<TSource> RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_)'></a>

## SizedListExt.RemoveItemsOfType<TSource,TCast>(this SizedList<TSource>) Method

Returns a new list with all items of a given type removed

```csharp
public static Assets.Scripts.Utils.SizedList<TSource> RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource> sizedList)
    where TSource : Il2CppSystem.Object
    where TCast : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[TSource](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType_TSource,TCast_(thisAssets.Scripts.Utils.SizedList_TSource_).TSource 'BTD_Mod_Helper.Extensions.SizedListExt.RemoveItemsOfType<TSource,TCast>(this Assets.Scripts.Utils.SizedList<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToArray_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.ToArray<T>(this SizedList<T>) Method

Converts a sized list to an array

```csharp
public static T[] ToArray<T>(this Assets.Scripts.Utils.SizedList<T> sizedList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToArray_T_(thisAssets.Scripts.Utils.SizedList_T_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToArray<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToArray<T>(this Assets.Scripts.Utils.SizedList<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.ToIl2CppList<T>(this SizedList<T>) Method

Converts a SizedList to an Il2cpp List

```csharp
public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this Assets.Scripts.Utils.SizedList<T> sizedList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.SizedList_T_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Il2CppSystem.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List-1 'Il2CppSystem.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.ToIl2CppReferenceArray<T>(this SizedList<T>) Method

Converts a SizedList to an Il2cppreferencearray

```csharp
public static UnhollowerBaseLib.Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.SizedList<T> sizedList)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.SizedList_T_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[UnhollowerBaseLib.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToIl2CppReferenceArray<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/UnhollowerBaseLib.Il2CppReferenceArray-1 'UnhollowerBaseLib.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToList_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.ToList<T>(this SizedList<T>) Method

Converts a List to a SizedList

```csharp
public static System.Collections.Generic.List<T> ToList<T>(this Assets.Scripts.Utils.SizedList<T> sizedList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToList_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToList_T_(thisAssets.Scripts.Utils.SizedList_T_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToLockList_T_(thisAssets.Scripts.Utils.SizedList_T_)'></a>

## SizedListExt.ToLockList<T>(this SizedList<T>) Method

Not Tested

```csharp
public static Assets.Scripts.Utils.LockList<T> ToLockList<T>(this Assets.Scripts.Utils.SizedList<T> sizedList);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToLockList_T_(thisAssets.Scripts.Utils.SizedList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.ToLockList_T_(thisAssets.Scripts.Utils.SizedList_T_).sizedList'></a>

`sizedList` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToLockList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToLockList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

#### Returns
[Assets.Scripts.Utils.LockList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.ToLockList_T_(thisAssets.Scripts.Utils.SizedList_T_).T 'BTD_Mod_Helper.Extensions.SizedListExt.ToLockList<T>(this Assets.Scripts.Utils.SizedList<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.LockList-1 'Assets.Scripts.Utils.LockList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_)'></a>

## SizedListExt.Where<T>(this SizedList<T>, Func<T,bool>) Method

Return all elements that match the predicate

```csharp
public static System.Collections.Generic.List<T> Where<T>(this Assets.Scripts.Utils.SizedList<T> source, System.Func<T,bool> predicate)
    where T : Il2CppSystem.Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).source'></a>

`source` [Assets.Scripts.Utils.SizedList&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Where<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SizedList-1 'Assets.Scripts.Utils.SizedList`1')

<a name='BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Where<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.SizedListExt.md#BTD_Mod_Helper.Extensions.SizedListExt.Where_T_(thisAssets.Scripts.Utils.SizedList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.SizedListExt.Where<T>(this Assets.Scripts.Utils.SizedList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')