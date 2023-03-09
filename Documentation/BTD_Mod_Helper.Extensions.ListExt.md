#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ListExt Class

Extensions for system Lists

```csharp
public static class ListExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ListExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ListExt.Duplicate_T_(thisSystem.Collections.Generic.List_T_)'></a>

## ListExt.Duplicate<T>(this List<T>) Method

Return a duplicate of this

```csharp
public static System.Collections.Generic.List<T> Duplicate<T>(this System.Collections.Generic.List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.Duplicate_T_(thisSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.Duplicate_T_(thisSystem.Collections.Generic.List_T_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.Duplicate_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.Duplicate<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.Duplicate_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.Duplicate<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.DuplicateAs<TSource,TCast>(this List<TSource>) Method

Return a duplicate of this as type TCast

```csharp
public static System.Collections.Generic.List<TCast> DuplicateAs<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.DuplicateAs<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.DuplicateAs_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.ListExt.DuplicateAs<TSource,TCast>(this System.Collections.Generic.List<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.GetItemOfType<TSource,TCast>(this List<TSource>) Method

Return the first item of type TCast

```csharp
public static TCast GetItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Item you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.GetItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.GetItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.ListExt.GetItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TCast')

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.GetItemsOfType<TSource,TCast>(this List<TSource>) Method

Return all Items of type TCast

```csharp
public static System.Collections.Generic.List<TCast> GetItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TCast](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast 'BTD_Mod_Helper.Extensions.ListExt.GetItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.HasItemsOfType<TSource,TCast>(this List<TSource>) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.HasItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool)'></a>

## ListExt.LoadFromFile<T>(this List<T>, string, bool) Method

Load a List from a FilePath

```csharp
public static T LoadFromFile<T>(this System.Collections.Generic.List<T> list, string filePath, out bool success);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).T 'BTD_Mod_Helper.Extensions.ListExt.LoadFromFile<T>(this System.Collections.Generic.List<T>, string, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

FilePath of the saved List

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).success'></a>

`success` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Will be true if the List was successfully loaded, otherwise will be false

#### Returns
[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string,bool).T 'BTD_Mod_Helper.Extensions.ListExt.LoadFromFile<T>(this System.Collections.Generic.List<T>, string, bool).T')  
The loaded List if successful, otherwise default value

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string)'></a>

## ListExt.LoadFromFile<T>(this List<T>, string) Method

Load a List from a FilePath

```csharp
public static T LoadFromFile<T>(this System.Collections.Generic.List<T> list, string filePath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string).T 'BTD_Mod_Helper.Extensions.ListExt.LoadFromFile<T>(this System.Collections.Generic.List<T>, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

FilePath of the saved List

#### Returns
[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.LoadFromFile_T_(thisSystem.Collections.Generic.List_T_,string).T 'BTD_Mod_Helper.Extensions.ListExt.LoadFromFile<T>(this System.Collections.Generic.List<T>, string).T')  
The loaded List if successful, otherwise default value

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast)'></a>

## ListExt.RemoveItem<TSource,TCast>(this List<TSource>, TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static System.Collections.Generic.List<TSource> RemoveItem<TSource,TCast>(this System.Collections.Generic.List<TSource> list, TCast itemToRemove)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItem<TSource,TCast>(this System.Collections.Generic.List<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).TCast 'BTD_Mod_Helper.Extensions.ListExt.RemoveItem<TSource,TCast>(this System.Collections.Generic.List<TSource>, TCast).TCast')

The specific Item to remove

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItem_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_,TCast).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItem<TSource,TCast>(this System.Collections.Generic.List<TSource>, TCast).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.RemoveItemOfType<TSource,TCast>(this List<TSource>) Method

Return this with the first Item of type TCast removed

```csharp
public static System.Collections.Generic.List<TSource> RemoveItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItemOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_)'></a>

## ListExt.RemoveItemsOfType<TSource,TCast>(this List<TSource>) Method

Return this with all Items of type TCast removed

```csharp
public static System.Collections.Generic.List<TSource> RemoveItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TSource](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType_TSource,TCast_(thisSystem.Collections.Generic.List_TSource_).TSource 'BTD_Mod_Helper.Extensions.ListExt.RemoveItemsOfType<TSource,TCast>(this System.Collections.Generic.List<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.ListExt.SaveToFile_T_(thisSystem.Collections.Generic.List_T_,string)'></a>

## ListExt.SaveToFile<T>(this List<T>, string) Method

Save a list to file

```csharp
public static bool SaveToFile<T>(this System.Collections.Generic.List<T> list, string filePath);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.SaveToFile_T_(thisSystem.Collections.Generic.List_T_,string).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.SaveToFile_T_(thisSystem.Collections.Generic.List_T_,string).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.SaveToFile_T_(thisSystem.Collections.Generic.List_T_,string).T 'BTD_Mod_Helper.Extensions.ListExt.SaveToFile<T>(this System.Collections.Generic.List<T>, string).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

The list you want to save

<a name='BTD_Mod_Helper.Extensions.ListExt.SaveToFile_T_(thisSystem.Collections.Generic.List_T_,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The FilePath you want to save it to

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if successful, false if it fails

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppList_T_(thisSystem.Collections.Generic.List_T_)'></a>

## ListExt.ToIl2CppList<T>(this List<T>) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this System.Collections.Generic.List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppList_T_(thisSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppList_T_(thisSystem.Collections.Generic.List_T_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.ToIl2CppList_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.ToIl2CppList<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.List_T_)'></a>

## ListExt.ToIl2CppReferenceArray<T>(this List<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this System.Collections.Generic.List<T> list)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.List_T_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.ToIl2CppReferenceArray<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.ListExt.ToLockList_T_(thisSystem.Collections.Generic.List_T_)'></a>

## ListExt.ToLockList<T>(this List<T>) Method

Return as LockList

```csharp
public static LockList<T> ToLockList<T>(this System.Collections.Generic.List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToLockList_T_(thisSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToLockList_T_(thisSystem.Collections.Generic.List_T_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.ToLockList_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.ToLockList<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.ListExt.ToSizedList_T_(thisSystem.Collections.Generic.List_T_)'></a>

## ListExt.ToSizedList<T>(this List<T>) Method

Not tested

```csharp
public static SizedList<T> ToSizedList<T>(this System.Collections.Generic.List<T> list);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToSizedList_T_(thisSystem.Collections.Generic.List_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ListExt.ToSizedList_T_(thisSystem.Collections.Generic.List_T_).list'></a>

`list` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ListExt.md#BTD_Mod_Helper.Extensions.ListExt.ToSizedList_T_(thisSystem.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ListExt.ToSizedList<T>(this System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[Il2CppAssets.Scripts.Utils.SizedList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SizedList 'Il2CppAssets.Scripts.Utils.SizedList')