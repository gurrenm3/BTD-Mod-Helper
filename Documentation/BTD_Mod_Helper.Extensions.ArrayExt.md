#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ArrayExt Class

Extensions for arrays

```csharp
public static class ArrayExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ArrayExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_)'></a>

## ArrayExt.AddTo<T>(this T[], List<T>) Method

Return this with Items added to it

```csharp
public static T[] AddTo<T>(this T[] array, System.Collections.Generic.List<T> objectsToAdd)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).T'></a>

`T`

The Type of the Items you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], System.Collections.Generic.List<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).objectsToAdd'></a>

`objectsToAdd` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], System.Collections.Generic.List<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

Items you want to add

#### Returns
[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],System.Collections.Generic.List_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], System.Collections.Generic.List<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T)'></a>

## ArrayExt.AddTo<T>(this T[], T) Method

Return this with an Item added to it

```csharp
public static T[] AddTo<T>(this T[] array, T objectToAdd)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).T'></a>

`T`

The Type of the Item you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).objectToAdd'></a>

`objectToAdd` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T).T')

Item to add to this

#### Returns
[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[])'></a>

## ArrayExt.AddTo<T>(this T[], T[]) Method

Return this with Items added to it

```csharp
public static T[] AddTo<T>(this T[] array, T[] objectsToAdd)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).T'></a>

`T`

The Type of the Items you want to add
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).objectsToAdd'></a>

`objectsToAdd` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Items you want to add

#### Returns
[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.AddTo_T_(thisT[],T[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.AddTo<T>(this T[], T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_)'></a>

## ArrayExt.Any<T>(this T[], Func<T,bool>) Method

Return whether or not there are any elements in this that match the predicate

```csharp
public static bool Any<T>(this T[] array, System.Func<T,bool> predicate);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.ArrayExt.Any<T>(this T[], System.Func<T,bool>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[],System.Func_T,bool_).T 'BTD_Mod_Helper.Extensions.ArrayExt.Any<T>(this T[], System.Func<T,bool>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[])'></a>

## ArrayExt.Any<T>(this T[]) Method

Return whether or not there are any elements in this

```csharp
public static bool Any<T>(this T[] array);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.Any_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.Any<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6)'></a>

## ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1,T2,T3,T4,T5,T6>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3, out T4 param4, out T5 param5, out T6 param6);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T1'></a>

`T1`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T2'></a>

`T2`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T3'></a>

`T3`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T4'></a>

`T4`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T5'></a>

`T5`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T6'></a>

`T6`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param2'></a>

`param2` [T2](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T2 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T2')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param3'></a>

`param3` [T3](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T3 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T3')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param4'></a>

`param4` [T4](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T4 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T4')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param5'></a>

`param5` [T5](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T5 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T5')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).param6'></a>

`param6` [T6](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5,T6_(thisobject[],T1,T2,T3,T4,T5,T6).T6 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5,T6>(this object[], T1, T2, T3, T4, T5, T6).T6')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5)'></a>

## ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1,T2,T3,T4,T5>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3, out T4 param4, out T5 param5);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T1'></a>

`T1`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T2'></a>

`T2`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T3'></a>

`T3`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T4'></a>

`T4`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T5'></a>

`T5`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5).T1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).param2'></a>

`param2` [T2](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T2 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5).T2')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).param3'></a>

`param3` [T3](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T3 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5).T3')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).param4'></a>

`param4` [T4](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T4 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5).T4')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).param5'></a>

`param5` [T5](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4,T5_(thisobject[],T1,T2,T3,T4,T5).T5 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4,T5>(this object[], T1, T2, T3, T4, T5).T5')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4)'></a>

## ArrayExt.CheckTypes<T1,T2,T3,T4>(this object[], T1, T2, T3, T4) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1,T2,T3,T4>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3, out T4 param4);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T1'></a>

`T1`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T2'></a>

`T2`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T3'></a>

`T3`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T4'></a>

`T4`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4>(this object[], T1, T2, T3, T4).T1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).param2'></a>

`param2` [T2](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T2 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4>(this object[], T1, T2, T3, T4).T2')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).param3'></a>

`param3` [T3](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T3 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4>(this object[], T1, T2, T3, T4).T3')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).param4'></a>

`param4` [T4](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3,T4_(thisobject[],T1,T2,T3,T4).T4 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3,T4>(this object[], T1, T2, T3, T4).T4')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3)'></a>

## ArrayExt.CheckTypes<T1,T2,T3>(this object[], T1, T2, T3) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1,T2,T3>(this object[] parameters, out T1 param1, out T2 param2, out T3 param3);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T1'></a>

`T1`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T2'></a>

`T2`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T3'></a>

`T3`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3>(this object[], T1, T2, T3).T1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).param2'></a>

`param2` [T2](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T2 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3>(this object[], T1, T2, T3).T2')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).param3'></a>

`param3` [T3](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2,T3_(thisobject[],T1,T2,T3).T3 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2,T3>(this object[], T1, T2, T3).T3')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2)'></a>

## ArrayExt.CheckTypes<T1,T2>(this object[], T1, T2) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1,T2>(this object[] parameters, out T1 param1, out T2 param2);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).T1'></a>

`T1`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).T2'></a>

`T2`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2>(this object[], T1, T2).T1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).param2'></a>

`param2` [T2](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1,T2_(thisobject[],T1,T2).T2 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1,T2>(this object[], T1, T2).T2')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1_(thisobject[],T1)'></a>

## ArrayExt.CheckTypes<T1>(this object[], T1) Method

Checks if the parameter array has the given types

```csharp
public static bool CheckTypes<T1>(this object[] parameters, out T1 param1);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1_(thisobject[],T1).T1'></a>

`T1`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1_(thisobject[],T1).parameters'></a>

`parameters` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1_(thisobject[],T1).param1'></a>

`param1` [T1](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes_T1_(thisobject[],T1).T1 'BTD_Mod_Helper.Extensions.ArrayExt.CheckTypes<T1>(this object[], T1).T1')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Duplicate_T_(thisT[])'></a>

## ArrayExt.Duplicate<T>(this T[]) Method

Return a duplicate of this Array

```csharp
public static T[] Duplicate<T>(this T[] array);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Duplicate_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Duplicate_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.Duplicate_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.Duplicate<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.Duplicate_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.Duplicate<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.DuplicateAs<TSource,TCast>(this TSource[]) Method

Return a duplicate of this array as type TCast

```csharp
public static TCast[] DuplicateAs<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

The original Array Type

<a name='BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Cast type
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs_TSource,TCast_(thisTSource[]).TCast 'BTD_Mod_Helper.Extensions.ArrayExt.DuplicateAs<TSource,TCast>(this TSource[]).TCast')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_)'></a>

## ArrayExt.FindAll<T>(this T[], Predicate<T>) Method

Retrieves all the elements that match the conditions defined by the specified predicate.

```csharp
public static T[] FindAll<T>(this T[] array, System.Predicate<T> match);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.FindAll<T>(this T[], System.Predicate<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).match'></a>

`match` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.FindAll<T>(this T[], System.Predicate<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

The Predicate delegate that defines the conditions of the elements to search for.

#### Returns
[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.FindAll_T_(thisT[],System.Predicate_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.FindAll<T>(this T[], System.Predicate<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_)'></a>

## ArrayExt.ForEach<T>(this T[], Action<T>) Method

Performs the specified action on each element

```csharp
public static void ForEach<T>(this T[] array, System.Action<T> action);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.ForEach<T>(this T[], System.Action<T>).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ForEach_T_(thisT[],System.Action_T_).T 'BTD_Mod_Helper.Extensions.ArrayExt.ForEach<T>(this T[], System.Action<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

Action to preform on each element

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.GetItemOfType<TSource,TCast>(this TSource[]) Method

Return the first Item of type TCast

```csharp
public static TCast GetItemOfType<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Type of the Item you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[TCast](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType_TSource,TCast_(thisTSource[]).TCast 'BTD_Mod_Helper.Extensions.ArrayExt.GetItemOfType<TSource,TCast>(this TSource[]).TCast')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.GetItemsOfType<TSource,TCast>(this TSource[]) Method

Return all Items of type TCast

```csharp
public static System.Collections.Generic.IEnumerable<TCast> GetItemsOfType<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Type of the Items you want
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TCast](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType_TSource,TCast_(thisTSource[]).TCast 'BTD_Mod_Helper.Extensions.ArrayExt.GetItemsOfType<TSource,TCast>(this TSource[]).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.HasItemsOfType<TSource,TCast>(this TSource[]) Method

Check if this has any items of type TCast

```csharp
public static bool HasItemsOfType<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Type you're checking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.HasItemsOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.IsValid(thisint[])'></a>

## ArrayExt.IsValid(this int[]) Method

Returns whether an int array is a valid set of tiers for a Tower

```csharp
public static bool IsValid(this int[] tiers);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.IsValid(thisint[]).tiers'></a>

`tiers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Order(thisint[])'></a>

## ArrayExt.Order(this int[]) Method

Returns the index of the highest tier, then the middle, then the lowest  
<br/>  
Breaks ties by Middle Path >> Top Path >> Bottom Path

```csharp
public static int[] Order(this int[] arr);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Order(thisint[]).arr'></a>

`arr` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Printed(thisint[])'></a>

## ArrayExt.Printed(this int[]) Method

A string with all array elements printed together with no spaces  
<br/>  
Useful for the suffix for Tower IDS like DartMonkey-230

```csharp
public static string Printed(this int[] arr);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.Printed(thisint[]).arr'></a>

`arr` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The array

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast)'></a>

## ArrayExt.RemoveItem<TSource,TCast>(this TSource[], TCast) Method

Return this with the first Item of type TCast removed

```csharp
public static TSource[] RemoveItem<TSource,TCast>(this TSource[] array, TCast itemToRemove)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem<TSource,TCast>(this TSource[], TCast).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).itemToRemove'></a>

`itemToRemove` [TCast](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).TCast 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem<TSource,TCast>(this TSource[], TCast).TCast')

The specific Item to remove

#### Returns
[TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem_TSource,TCast_(thisTSource[],TCast).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItem<TSource,TCast>(this TSource[], TCast).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.RemoveItemOfType<TSource,TCast>(this TSource[]) Method

Return this with the first Item of type TCast removed

```csharp
public static TSource[] RemoveItemOfType<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Type of the Item you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[])'></a>

## ArrayExt.RemoveItemsOfType<TSource,TCast>(this TSource[]) Method

Return this with all Items of type TCast removed

```csharp
public static TSource[] RemoveItemsOfType<TSource,TCast>(this TSource[] array)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[]).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[]).TCast'></a>

`TCast`

The Type of the Items that you want to remove
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[]).array'></a>

`array` [TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[TSource](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType_TSource,TCast_(thisTSource[]).TSource 'BTD_Mod_Helper.Extensions.ArrayExt.RemoveItemsOfType<TSource,TCast>(this TSource[]).TSource')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppList_T_(thisT[])'></a>

## ArrayExt.ToIl2CppList<T>(this T[]) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this T[] array)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppList_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppList_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppList_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppList<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppReferenceArray_T_(thisT[])'></a>

## ArrayExt.ToIl2CppReferenceArray<T>(this T[]) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this T[] array)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppReferenceArray_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppReferenceArray_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppReferenceArray_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.ToIl2CppReferenceArray<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToLockList_T_(thisT[])'></a>

## ArrayExt.ToLockList<T>(this T[]) Method

Return as LockList

```csharp
public static LockList<T> ToLockList<T>(this T[] array);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToLockList_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToLockList_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ToLockList_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.ToLockList<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToSizedList_T_(thisT[])'></a>

## ArrayExt.ToSizedList<T>(this T[]) Method

Not Tested

```csharp
public static SizedList<T> ToSizedList<T>(this T[] array);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToSizedList_T_(thisT[]).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.ToSizedList_T_(thisT[]).array'></a>

`array` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.ToSizedList_T_(thisT[]).T 'BTD_Mod_Helper.Extensions.ArrayExt.ToSizedList<T>(this T[]).T')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[Il2CppAssets.Scripts.Utils.SizedList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SizedList 'Il2CppAssets.Scripts.Utils.SizedList')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.TryCast_T_(Il2CppObjectBase,T)'></a>

## ArrayExt.TryCast<T>(Il2CppObjectBase, T) Method

Version of TryCast without the generic restriction

```csharp
private static bool TryCast<T>(Il2CppObjectBase obj, out T t);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.TryCast_T_(Il2CppObjectBase,T).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ArrayExt.TryCast_T_(Il2CppObjectBase,T).obj'></a>

`obj` [Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase 'Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase')

<a name='BTD_Mod_Helper.Extensions.ArrayExt.TryCast_T_(Il2CppObjectBase,T).t'></a>

`t` [T](BTD_Mod_Helper.Extensions.ArrayExt.md#BTD_Mod_Helper.Extensions.ArrayExt.TryCast_T_(Il2CppObjectBase,T).T 'BTD_Mod_Helper.Extensions.ArrayExt.TryCast<T>(Il2CppObjectBase, T).T')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')