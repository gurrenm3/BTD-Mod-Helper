#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppIEnumeratorExt Class

Extensions for Il2cpp Ienumerators

```csharp
public static class Il2CppIEnumeratorExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppIEnumeratorExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.Count(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.Count(this IEnumerator) Method

Get the total number of elements

```csharp
public static int Count(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.Count(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.GetItem(thisIEnumerator,int)'></a>

## Il2CppIEnumeratorExt.GetItem(this IEnumerator, int) Method

Return the Item at a specific index

```csharp
public static Object GetItem(this IEnumerator enumerator, int index);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.GetItem(thisIEnumerator,int).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.GetItem(thisIEnumerator,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToIl2CppList(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.ToIl2CppList(this IEnumerator) Method

Return as Il2CppSystem.List

```csharp
public static List<Object> ToIl2CppList(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToIl2CppList(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToIl2CppReferenceArray(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.ToIl2CppReferenceArray(this IEnumerator) Method

Return as Il2CppReferenceArray

```csharp
public static Il2CppReferenceArray<Object> ToIl2CppReferenceArray(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToIl2CppReferenceArray(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToList(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.ToList(this IEnumerator) Method

Return as System.List

```csharp
public static System.Collections.Generic.List<Object> ToList(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToList(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppSystem.Object](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Object 'Il2CppSystem.Object')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToLockList(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.ToLockList(this IEnumerator) Method

Return as LockList

```csharp
public static LockList<Object> ToLockList(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToLockList(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[Il2CppAssets.Scripts.Utils.LockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.LockList 'Il2CppAssets.Scripts.Utils.LockList')

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToRootObjectLockList(thisIEnumerator)'></a>

## Il2CppIEnumeratorExt.ToRootObjectLockList(this IEnumerator) Method

Return as LockList

```csharp
public static RootObjectLockList<RootObject> ToRootObjectLockList(this IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppIEnumeratorExt.ToRootObjectLockList(thisIEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList 'Il2CppAssets.Scripts.Simulation.Objects.RootObjectLockList')