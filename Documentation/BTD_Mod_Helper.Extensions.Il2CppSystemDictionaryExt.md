#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppSystemDictionaryExt Class

Extensions for il2cpp dictionaries

```csharp
public static class Il2CppSystemDictionaryExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppSystemDictionaryExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V)'></a>

## Il2CppSystemDictionaryExt.Deconstruct<K,V>(this KeyValuePair<K,V>, K, V) Method

Deconstruct method of IL2CPP KeyValuePairs

```csharp
public static void Deconstruct<K,V>(this KeyValuePair<K,V> kvp, out K k, out V v);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).K'></a>

`K`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).V'></a>

`V`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).kvp'></a>

`kvp` [Il2CppSystem.Collections.Generic.KeyValuePair](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.KeyValuePair 'Il2CppSystem.Collections.Generic.KeyValuePair')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).k'></a>

`k` [K](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).K 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct<K,V>(this KeyValuePair<K,V>, K, V).K')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).v'></a>

`v` [V](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct_K,V_(thisKeyValuePair_K,V_,K,V).V 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Deconstruct<K,V>(this KeyValuePair<K,V>, K, V).V')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_)'></a>

## Il2CppSystemDictionaryExt.Entries<TKey,TValue>(this Dictionary<TKey,TValue>) Method

Get all of the entries from this Dictionary

```csharp
public static System.Collections.Generic.IEnumerable<(TKey key,TValue value)> Entries<TKey,TValue>(this Dictionary<TKey,TValue> keyValuePairs);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_).TKey'></a>

`TKey`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_).TValue'></a>

`TValue`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_).keyValuePairs'></a>

`keyValuePairs` [Il2CppSystem.Collections.Generic.Dictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.Dictionary 'Il2CppSystem.Collections.Generic.Dictionary')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[TKey](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_).TKey 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries<TKey,TValue>(this Dictionary<TKey,TValue>).TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[TValue](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries_TKey,TValue_(thisDictionary_TKey,TValue_).TValue 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Entries<TKey,TValue>(this Dictionary<TKey,TValue>).TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ValueTuple 'System.ValueTuple')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetKeys_TKey,TValue_(thisDictionary_TKey,TValue_)'></a>

## Il2CppSystemDictionaryExt.GetKeys<TKey,TValue>(this Dictionary<TKey,TValue>) Method

Get all of the keys from this Dictionary as a list

```csharp
public static List<TKey> GetKeys<TKey,TValue>(this Dictionary<TKey,TValue> keyValuePairs);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetKeys_TKey,TValue_(thisDictionary_TKey,TValue_).TKey'></a>

`TKey`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetKeys_TKey,TValue_(thisDictionary_TKey,TValue_).TValue'></a>

`TValue`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetKeys_TKey,TValue_(thisDictionary_TKey,TValue_).keyValuePairs'></a>

`keyValuePairs` [Il2CppSystem.Collections.Generic.Dictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.Dictionary 'Il2CppSystem.Collections.Generic.Dictionary')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetValues_TKey,TValue_(thisDictionary_TKey,TValue_)'></a>

## Il2CppSystemDictionaryExt.GetValues<TKey,TValue>(this Dictionary<TKey,TValue>) Method

Get all of the values from this Dictionary as a list

```csharp
public static List<TValue> GetValues<TKey,TValue>(this Dictionary<TKey,TValue> keyValuePairs);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetValues_TKey,TValue_(thisDictionary_TKey,TValue_).TKey'></a>

`TKey`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetValues_TKey,TValue_(thisDictionary_TKey,TValue_).TValue'></a>

`TValue`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.GetValues_TKey,TValue_(thisDictionary_TKey,TValue_).keyValuePairs'></a>

`keyValuePairs` [Il2CppSystem.Collections.Generic.Dictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.Dictionary 'Il2CppSystem.Collections.Generic.Dictionary')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys_TKey,TValue_(thisDictionary_TKey,TValue_)'></a>

## Il2CppSystemDictionaryExt.Keys<TKey,TValue>(this Dictionary<TKey,TValue>) Method

Get all of the keys from this Dictionary

```csharp
public static System.Collections.Generic.IEnumerable<TKey> Keys<TKey,TValue>(this Dictionary<TKey,TValue> keyValuePairs);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys_TKey,TValue_(thisDictionary_TKey,TValue_).TKey'></a>

`TKey`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys_TKey,TValue_(thisDictionary_TKey,TValue_).TValue'></a>

`TValue`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys_TKey,TValue_(thisDictionary_TKey,TValue_).keyValuePairs'></a>

`keyValuePairs` [Il2CppSystem.Collections.Generic.Dictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.Dictionary 'Il2CppSystem.Collections.Generic.Dictionary')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TKey](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys_TKey,TValue_(thisDictionary_TKey,TValue_).TKey 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Keys<TKey,TValue>(this Dictionary<TKey,TValue>).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values_TKey,TValue_(thisDictionary_TKey,TValue_)'></a>

## Il2CppSystemDictionaryExt.Values<TKey,TValue>(this Dictionary<TKey,TValue>) Method

Get all of the values from this Dictionary

```csharp
public static System.Collections.Generic.IEnumerable<TValue> Values<TKey,TValue>(this Dictionary<TKey,TValue> keyValuePairs);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values_TKey,TValue_(thisDictionary_TKey,TValue_).TKey'></a>

`TKey`

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values_TKey,TValue_(thisDictionary_TKey,TValue_).TValue'></a>

`TValue`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values_TKey,TValue_(thisDictionary_TKey,TValue_).keyValuePairs'></a>

`keyValuePairs` [Il2CppSystem.Collections.Generic.Dictionary](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.Dictionary 'Il2CppSystem.Collections.Generic.Dictionary')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TValue](BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values_TKey,TValue_(thisDictionary_TKey,TValue_).TValue 'BTD_Mod_Helper.Extensions.Il2CppSystemDictionaryExt.Values<TKey,TValue>(this Dictionary<TKey,TValue>).TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')