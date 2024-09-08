#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppIEnumerator Class

Extensions for il2cpp ienumerators

```csharp
public static class Il2CppIEnumerator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppIEnumerator
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.Any<T>(this IEnumerator, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Any<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.FindIndex<T>(this IEnumerator, Func<T,bool>) Method

Return the index of the element that matches the predicate

```csharp
public static int FindIndex<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FindIndex<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.First<T>(this IEnumerator, Func<T,bool>) Method

Return the first element that matches the predicate

```csharp
public static T First<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First<T>(this IEnumerator, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator)'></a>

## Il2CppIEnumerator.First<T>(this IEnumerator) Method

Return the first element in the collection

```csharp
public static T First<T>(this IEnumerator source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First_T_(thisIEnumerator).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.First<T>(this IEnumerator).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.FirstOrDefault<T>(this IEnumerator, Func<T,bool>) Method

Return the first element that matches the predicate, or return default

```csharp
public static T FirstOrDefault<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault<T>(this IEnumerator, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator)'></a>

## Il2CppIEnumerator.FirstOrDefault<T>(this IEnumerator) Method

Return the first element in the collection, or return default if it's null

```csharp
public static T FirstOrDefault<T>(this IEnumerator source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault_T_(thisIEnumerator).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.FirstOrDefault<T>(this IEnumerator).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach_T_(thisIEnumerator,System.Action_T_)'></a>

## Il2CppIEnumerator.ForEach<T>(this IEnumerator, Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this IEnumerator source, System.Action<T> action)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach_T_(thisIEnumerator,System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach_T_(thisIEnumerator,System.Action_T_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach_T_(thisIEnumerator,System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach_T_(thisIEnumerator,System.Action_T_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.ForEach<T>(this IEnumerator, System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Last_T_(thisIEnumerator)'></a>

## Il2CppIEnumerator.Last<T>(this IEnumerator) Method

Return the last item in the collection

```csharp
public static T Last<T>(this IEnumerator source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Last_T_(thisIEnumerator).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Last_T_(thisIEnumerator).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Last_T_(thisIEnumerator).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Last<T>(this IEnumerator).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.LastOrDefault<T>(this IEnumerator, Func<T,bool>) Method

Return the last item in the collection that meets the condition, or return default

```csharp
public static T LastOrDefault<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.LastOrDefault<T>(this IEnumerator, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_)'></a>

## Il2CppIEnumerator.Where<T>(this IEnumerator, Func<T,bool>) Method

Return all elements that match the predicate

```csharp
public static System.Collections.Generic.List<T> Where<T>(this IEnumerator source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where<T>(this IEnumerator, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.Il2CppIEnumerator.md#BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where_T_(thisIEnumerator,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppIEnumerator.Where<T>(this IEnumerator, System.Func<T,bool>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')