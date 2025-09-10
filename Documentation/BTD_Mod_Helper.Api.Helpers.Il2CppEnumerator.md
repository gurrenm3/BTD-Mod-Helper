#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## Il2CppEnumerator Class

Wrapper for il2cpp enumerator so that it actually extends the normal System enumerator

```csharp
public class Il2CppEnumerator :
System.Collections.IEnumerator,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppEnumerator

Implements [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.Il2CppEnumerator(IEnumerable)'></a>

## Il2CppEnumerator(IEnumerable) Constructor

Construction a wrapper for an il2cpp enumerator

```csharp
public Il2CppEnumerator(IEnumerable enumerable);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.Il2CppEnumerator(IEnumerable).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerable 'Il2CppSystem.Collections.IEnumerable')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.Il2CppEnumerator(IEnumerator)'></a>

## Il2CppEnumerator(IEnumerator) Constructor

Construction a wrapper for an il2cpp enumerator

```csharp
public Il2CppEnumerator(IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.Il2CppEnumerator(IEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.Enumerator'></a>

## Il2CppEnumerator.Enumerator Property

The internal il2cpp enumerator being wrapped

```csharp
public IEnumerator Enumerator { get; }
```

#### Property Value
[Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')
### Operators

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator(IEnumerable)'></a>

## Il2CppEnumerator.implicit operator Il2CppEnumerator(IEnumerable) Operator

Wraps an il2cpp enumerable

```csharp
public static BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator implicit operator Il2CppEnumerator(IEnumerable enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator(IEnumerable).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerable 'Il2CppSystem.Collections.IEnumerable')

#### Returns
[Il2CppEnumerator](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator(IEnumerator)'></a>

## Il2CppEnumerator.implicit operator Il2CppEnumerator(IEnumerator) Operator

Wraps an il2cpp enumerator

```csharp
public static BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator implicit operator Il2CppEnumerator(IEnumerator enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator(IEnumerator).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.IEnumerator 'Il2CppSystem.Collections.IEnumerator')

#### Returns
[Il2CppEnumerator](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator')