#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## IEnumerableExt Class

Extensions for the normal System IEnumerable class

```csharp
public static class IEnumerableExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IEnumerableExt
### Methods

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_)'></a>

## IEnumerableExt.ArgMax<T,K>(this IEnumerable<T>, Func<T,K>, IComparer<K>) Method

Returns the argument that maximizes the given value

```csharp
public static T ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T> source, System.Func<T,K> map=null, System.Collections.Generic.IComparer<K> comparer=null);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).T'></a>

`T`

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).K'></a>

`K`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).source'></a>

`source` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,K>, System.Collections.Generic.IComparer<K>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).map'></a>

`map` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,K>, System.Collections.Generic.IComparer<K>).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[K](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).K 'BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,K>, System.Collections.Generic.IComparer<K>).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).comparer'></a>

`comparer` [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[K](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).K 'BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,K>, System.Collections.Generic.IComparer<K>).K')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

#### Returns
[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax_T,K_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,K_,System.Collections.Generic.IComparer_K_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ArgMax<T,K>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,K>, System.Collections.Generic.IComparer<K>).T')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_)'></a>

## IEnumerableExt.CastAll<TSource,TCast>(this IEnumerable<TSource>) Method

Casts a reference array to an IEnumerable of a different Il2cpptype.  
<br/>  
Objects that aren't of the specified type will end up as null in the result

```csharp
public static System.Collections.Generic.IEnumerable<TCast> CastAll<TSource,TCast>(this System.Collections.Generic.IEnumerable<TSource> list)
    where TSource : Object
    where TCast : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_).TSource'></a>

`TSource`

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_).TCast'></a>

`TCast`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_).list'></a>

`list` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TSource](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_).TSource 'BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll<TSource,TCast>(this System.Collections.Generic.IEnumerable<TSource>).TSource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TCast](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll_TSource,TCast_(thisSystem.Collections.Generic.IEnumerable_TSource_).TCast 'BTD_Mod_Helper.Extensions.IEnumerableExt.CastAll<TSource,TCast>(this System.Collections.Generic.IEnumerable<TSource>).TCast')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_)'></a>

## IEnumerableExt.Deconstruct<K,V>(this IGrouping<K,V>, K, List<V>) Method

Deconstruct IGrouping to list

```csharp
public static void Deconstruct<K,V>(this System.Linq.IGrouping<K,V> grouping, out K k, out System.Collections.Generic.List<V> v);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).K'></a>

`K`

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).V'></a>

`V`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).grouping'></a>

`grouping` [System.Linq.IGrouping&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IGrouping-2 'System.Linq.IGrouping`2')[K](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).K 'BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct<K,V>(this System.Linq.IGrouping<K,V>, K, System.Collections.Generic.List<V>).K')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IGrouping-2 'System.Linq.IGrouping`2')[V](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).V 'BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct<K,V>(this System.Linq.IGrouping<K,V>, K, System.Collections.Generic.List<V>).V')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Linq.IGrouping-2 'System.Linq.IGrouping`2')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).k'></a>

`k` [K](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).K 'BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct<K,V>(this System.Linq.IGrouping<K,V>, K, System.Collections.Generic.List<V>).K')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).v'></a>

`v` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[V](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct_K,V_(thisSystem.Linq.IGrouping_K,V_,K,System.Collections.Generic.List_V_).V 'BTD_Mod_Helper.Extensions.IEnumerableExt.Deconstruct<K,V>(this System.Linq.IGrouping<K,V>, K, System.Collections.Generic.List<V>).V')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.OfIl2CppType_T_(thisSystem.Collections.IEnumerable)'></a>

## IEnumerableExt.OfIl2CppType<T>(this IEnumerable) Method

Filters the elements of the IEnumerable by if their Il2Cpp type is T

```csharp
public static System.Collections.Generic.IEnumerable<T> OfIl2CppType<T>(this System.Collections.IEnumerable ienumerable)
    where T : Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.OfIl2CppType_T_(thisSystem.Collections.IEnumerable).T'></a>

`T`

The Il2Cpp type to filter by
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.OfIl2CppType_T_(thisSystem.Collections.IEnumerable).ienumerable'></a>

`ienumerable` [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.OfIl2CppType_T_(thisSystem.Collections.IEnumerable).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.OfIl2CppType<T>(this System.Collections.IEnumerable).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int)'></a>

## IEnumerableExt.Repeat<T>(this IEnumerable<T>, int) Method

Repeats each element in the sequence n times, keeping the same order of elements

```csharp
public static System.Collections.Generic.IEnumerable<T> Repeat<T>(this System.Collections.Generic.IEnumerable<T> enumerable, int n);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int).enumerable'></a>

`enumerable` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat<T>(this System.Collections.Generic.IEnumerable<T>, int).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int).n'></a>

`n` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat_T_(thisSystem.Collections.Generic.IEnumerable_T_,int).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.Repeat<T>(this System.Collections.Generic.IEnumerable<T>, int).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppList_T_(thisSystem.Collections.Generic.IEnumerable_T_)'></a>

## IEnumerableExt.ToIl2CppList<T>(this IEnumerable<T>) Method

Return as Il2CppSystem.List

```csharp
public static List<T> ToIl2CppList<T>(this System.Collections.Generic.IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppList_T_(thisSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppList_T_(thisSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppList_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppList<T>(this System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.IEnumerable_T_)'></a>

## IEnumerableExt.ToIl2CppReferenceArray<T>(this IEnumerable<T>) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T>(this System.Collections.Generic.IEnumerable<T> enumerable)
    where T : Object;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppReferenceArray_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ToIl2CppReferenceArray<T>(this System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToLockList_T_(thisSystem.Collections.Generic.IEnumerable_T_)'></a>

## IEnumerableExt.ToLockList<T>(this IEnumerable<T>) Method

Return as LockList

```csharp
public static LockList<T> ToLockList<T>(this System.Collections.Generic.IEnumerable<T> enumerable);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToLockList_T_(thisSystem.Collections.Generic.IEnumerable_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.IEnumerableExt.ToLockList_T_(thisSystem.Collections.Generic.IEnumerable_T_).enumerable'></a>

`enumerable` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.IEnumerableExt.md#BTD_Mod_Helper.Extensions.IEnumerableExt.ToLockList_T_(thisSystem.Collections.Generic.IEnumerable_T_).T 'BTD_Mod_Helper.Extensions.IEnumerableExt.ToLockList<T>(this System.Collections.Generic.IEnumerable<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')