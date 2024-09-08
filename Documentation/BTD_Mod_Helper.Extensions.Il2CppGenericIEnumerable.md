#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenericIEnumerable Class

Extensions for Il2cpp Ienumerables

```csharp
public static class Il2CppGenericIEnumerable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenericIEnumerable
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_,System.Func_T,bool_)'></a>

## Il2CppGenericIEnumerable.Any<T>(this IEnumerable<T>, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this IEnumerable<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any<T>(this IEnumerable<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerable.Any<T>(this IEnumerable<T>) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this IEnumerable<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Any_T_(thisIEnumerable_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.First_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerable.First<T>(this IEnumerable<T>) Method

Return the first element in the collection

```csharp
public static T First<T>(this IEnumerable<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.First_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.First_T_(thisIEnumerable_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.First_T_(thisIEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.First<T>(this IEnumerable<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_)'></a>

## Il2CppGenericIEnumerable.FirstOrDefault<T>(this IEnumerable<T>, Func<T,bool>) Method

Return the first element that matches the predicate, or return default

```csharp
public static T FirstOrDefault<T>(this IEnumerable<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault<T>(this IEnumerable<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault<T>(this IEnumerable<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerable.FirstOrDefault<T>(this IEnumerable<T>) Method

Return the first element in the collection, or return default if it's null

```csharp
public static T FirstOrDefault<T>(this IEnumerable<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault_T_(thisIEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.FirstOrDefault<T>(this IEnumerable<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach_T_(thisIEnumerable_T_,System.Action_T_)'></a>

## Il2CppGenericIEnumerable.ForEach<T>(this IEnumerable<T>, Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach_T_(thisIEnumerable_T_,System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach_T_(thisIEnumerable_T_,System.Action_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach_T_(thisIEnumerable_T_,System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach_T_(thisIEnumerable_T_,System.Action_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.ForEach<T>(this IEnumerable<T>, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Last_T_(thisIEnumerable_T_)'></a>

## Il2CppGenericIEnumerable.Last<T>(this IEnumerable<T>) Method

Return the last item in the collection

```csharp
public static T Last<T>(this IEnumerable<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Last_T_(thisIEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Last_T_(thisIEnumerable_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Last_T_(thisIEnumerable_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.Last<T>(this IEnumerable<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_)'></a>

## Il2CppGenericIEnumerable.LastOrDefault<T>(this IEnumerable<T>, Func<T,bool>) Method

Return the last item in the collection that meets the condition, or return default

```csharp
public static T LastOrDefault<T>(this IEnumerable<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault<T>(this IEnumerable<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.md#BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault_T_(thisIEnumerable_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenericIEnumerable.LastOrDefault<T>(this IEnumerable<T>, System.Func<T,bool>).T')