#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## HashSetExt Class

Extensions for HashSets

```csharp
public static class HashSetExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HashSetExt
### Methods

<a name='BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable_T_(thisSystem.Collections.Generic.HashSet_T_)'></a>

## HashSetExt.EnumerateUntilStable<T>(this HashSet<T>) Method

Enumerates a HashSet without throwing if items are added mid-iteration.  
Yields each item exactly once (items added while iterating will be yielded in a later pass).  
Stops when a pass finds no unseen items.

```csharp
public static System.Collections.Generic.IEnumerable<T> EnumerateUntilStable<T>(this System.Collections.Generic.HashSet<T> set);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable_T_(thisSystem.Collections.Generic.HashSet_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable_T_(thisSystem.Collections.Generic.HashSet_T_).set'></a>

`set` [System.Collections.Generic.HashSet&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')[T](BTD_Mod_Helper.Extensions.HashSetExt.md#BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable_T_(thisSystem.Collections.Generic.HashSet_T_).T 'BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable<T>(this System.Collections.Generic.HashSet<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.HashSet-1 'System.Collections.Generic.HashSet`1')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](BTD_Mod_Helper.Extensions.HashSetExt.md#BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable_T_(thisSystem.Collections.Generic.HashSet_T_).T 'BTD_Mod_Helper.Extensions.HashSetExt.EnumerateUntilStable<T>(this System.Collections.Generic.HashSet<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')