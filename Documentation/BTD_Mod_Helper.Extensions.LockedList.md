#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## LockedList Class

Extensions for LockedLists

```csharp
public static class LockedList
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LockedList
### Methods

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.Any<T>(this LockList<T>, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this LockList<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.Any<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_)'></a>

## LockedList.Any<T>(this LockList<T>) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this LockList<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Any_T_(thisLockList_T_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.LockedList.FindIndex_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.FindIndex<T>(this LockList<T>, Func<T,bool>) Method

Return the index of the element that matches the predicate

```csharp
public static int FindIndex<T>(this LockList<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FindIndex_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FindIndex_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.FindIndex_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.FindIndex_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.FindIndex<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.First<T>(this LockList<T>, Func<T,bool>) Method

Return the first element that matches the predicate

```csharp
public static T First<T>(this LockList<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.First<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.First<T>(this LockList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_)'></a>

## LockedList.First<T>(this LockList<T>) Method

Return the first element in the collection

```csharp
public static T First<T>(this LockList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.First_T_(thisLockList_T_).T 'BTD_Mod_Helper.Extensions.LockedList.First<T>(this LockList<T>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.FirstOrDefault<T>(this LockList<T>, Func<T,bool>) Method

Return the first element that matches the predicate, or return default

```csharp
public static T FirstOrDefault<T>(this LockList<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault<T>(this LockList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_)'></a>

## LockedList.FirstOrDefault<T>(this LockList<T>) Method

Return the first element in the collection, or return default if it's null

```csharp
public static T FirstOrDefault<T>(this LockList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault_T_(thisLockList_T_).T 'BTD_Mod_Helper.Extensions.LockedList.FirstOrDefault<T>(this LockList<T>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.ForEach_T_(thisLockList_T_,System.Action_T_)'></a>

## LockedList.ForEach<T>(this LockList<T>, Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this LockList<T> source, System.Action<T> action);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.ForEach_T_(thisLockList_T_,System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.ForEach_T_(thisLockList_T_,System.Action_T_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.ForEach_T_(thisLockList_T_,System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.ForEach_T_(thisLockList_T_,System.Action_T_).T 'BTD_Mod_Helper.Extensions.LockedList.ForEach<T>(this LockList<T>, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element

<a name='BTD_Mod_Helper.Extensions.LockedList.Last_T_(thisLockList_T_)'></a>

## LockedList.Last<T>(this LockList<T>) Method

Return the last item in the collection

```csharp
public static T Last<T>(this LockList<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Last_T_(thisLockList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Last_T_(thisLockList_T_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.Last_T_(thisLockList_T_).T 'BTD_Mod_Helper.Extensions.LockedList.Last<T>(this LockList<T>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.LastOrDefault<T>(this LockList<T>, Func<T,bool>) Method

Return the last item in the collection that meets the condition, or return default

```csharp
public static T LastOrDefault<T>(this LockList<T> source, System.Func<T,bool> predicate);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.LastOrDefault<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.LastOrDefault_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.LastOrDefault<T>(this LockList<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_)'></a>

## LockedList.Where<T>(this LockList<T>, Func<T,bool>) Method

Return all elements that match the predicate

```csharp
public static System.Collections.Generic.List<T> Where<T>(this LockList<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.Where<T>(this LockList<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.LockedList.md#BTD_Mod_Helper.Extensions.LockedList.Where_T_(thisLockList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.LockedList.Where<T>(this LockList<T>, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')