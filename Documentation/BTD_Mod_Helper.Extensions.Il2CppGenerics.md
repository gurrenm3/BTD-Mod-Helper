#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppGenerics Class

Extensions for il2cpp lists

```csharp
public static class Il2CppGenerics
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppGenerics
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.Any<T>(this List<T>, Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this List<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.Any<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_)'></a>

## Il2CppGenerics.Any<T>(this List<T>) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this List<T> source)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Any_T_(thisList_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.FindIndex<T>(this List<T>, Func<T,bool>) Method

Return the index of the element that matches the predicate

```csharp
public static int FindIndex<T>(this List<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.FindIndex<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.First<T>(this List<T>, Func<T,bool>) Method

Return the first element that matches the predicate

```csharp
public static T First<T>(this List<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.First<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.First<T>(this List<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_)'></a>

## Il2CppGenerics.First<T>(this List<T>) Method

Return the first element in the collection

```csharp
public static T First<T>(this List<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.First_T_(thisList_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.First<T>(this List<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.FirstOrDefault<T>(this List<T>, Func<T,bool>) Method

Return the first element that matches the predicate, or return default

```csharp
public static T FirstOrDefault<T>(this List<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault<T>(this List<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_)'></a>

## Il2CppGenerics.FirstOrDefault<T>(this List<T>) Method

Return the first element in the collection, or return default if it's null

```csharp
public static T FirstOrDefault<T>(this List<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault_T_(thisList_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.FirstOrDefault<T>(this List<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Last_T_(thisList_T_)'></a>

## Il2CppGenerics.Last<T>(this List<T>) Method

Return the last item in the collection

```csharp
public static T Last<T>(this List<T> source);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Last_T_(thisList_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Last_T_(thisList_T_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.Last_T_(thisList_T_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.Last<T>(this List<T>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.LastOrDefault<T>(this List<T>, Func<T,bool>) Method

Return the last item in the collection that meets the condition, or return default

```csharp
public static T LastOrDefault<T>(this List<T> source, System.Func<T,bool> predicate);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.LastOrDefault<T>(this List<T>, System.Func<T,bool>).T')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Where_T_(thisList_T_,System.Func_T,bool_)'></a>

## Il2CppGenerics.Where<T>(this List<T>, Func<T,bool>) Method

Return all elements that match the predicate

```csharp
public static List<T> Where<T>(this List<T> source, System.Func<T,bool> predicate)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Where_T_(thisList_T_,System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Where_T_(thisList_T_,System.Func_T,bool_).source'></a>

`source` [Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppGenerics.Where_T_(thisList_T_,System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.Il2CppGenerics.md#BTD_Mod_Helper.Extensions.Il2CppGenerics.Where_T_(thisList_T_,System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.Il2CppGenerics.Where<T>(this List<T>, System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')