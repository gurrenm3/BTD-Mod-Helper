#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## Il2CppEnumerator<T> Class

Wrapper for il2cpp enumerator so that it actually extends the normal System enumerator

```csharp
public class Il2CppEnumerator<T> :
System.Collections.Generic.IEnumerator<T>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppEnumerator<T>

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[T](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md#BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.T 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')
### Constructors

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Il2CppEnumerator(IEnumerable_T_)'></a>

## Il2CppEnumerator(IEnumerable<T>) Constructor

Construction a wrapper for an il2cpp enumerator

```csharp
public Il2CppEnumerator(IEnumerable<T> enumerable);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Il2CppEnumerator(IEnumerable_T_).enumerable'></a>

`enumerable` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Il2CppEnumerator(IEnumerator_T_)'></a>

## Il2CppEnumerator(IEnumerator<T>) Constructor

Construction a wrapper for an il2cpp enumerator

```csharp
public Il2CppEnumerator(IEnumerator<T> enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Il2CppEnumerator(IEnumerator_T_).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.Generic.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerator 'Il2CppSystem.Collections.Generic.IEnumerator')
### Properties

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Current'></a>

## Il2CppEnumerator<T>.Current Property

Gets the element in the collection at the current position of the enumerator.

```csharp
public T Current { get; }
```

Implements [Current](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1.Current 'System.Collections.Generic.IEnumerator`1.Current'), [Current](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.Current 'System.Collections.IEnumerator.Current')

#### Property Value
[T](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md#BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.T 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>.T')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Enumerator'></a>

## Il2CppEnumerator<T>.Enumerator Property

The internal il2cpp enumerator being wrapped

```csharp
public IEnumerator<T> Enumerator { get; }
```

#### Property Value
[Il2CppSystem.Collections.Generic.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerator 'Il2CppSystem.Collections.Generic.IEnumerator')
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Dispose()'></a>

## Il2CppEnumerator<T>.Dispose() Method

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

```csharp
public void Dispose();
```

Implements [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.MoveNext()'></a>

## Il2CppEnumerator<T>.MoveNext() Method

Advances the enumerator to the next element of the collection.

```csharp
public bool MoveNext();
```

Implements [MoveNext()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.MoveNext 'System.Collections.IEnumerator.MoveNext')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The collection was modified after the enumerator was created.

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.Reset()'></a>

## Il2CppEnumerator<T>.Reset() Method

Sets the enumerator to its initial position, which is before the first element in the collection.

```csharp
public void Reset();
```

Implements [Reset()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.Reset 'System.Collections.IEnumerator.Reset')

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
The collection was modified after the enumerator was created.
### Operators

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_(IEnumerable_T_)'></a>

## Il2CppEnumerator<T>.implicit operator Il2CppEnumerator<T>(IEnumerable<T>) Operator

Wraps an il2cpp enumerable

```csharp
public static BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T> implicit operator Il2CppEnumerator<T>(IEnumerable<T> enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_(IEnumerable_T_).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerable 'Il2CppSystem.Collections.Generic.IEnumerable')

#### Returns
[BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator&lt;](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>')[T](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md#BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.T 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>.T')[&gt;](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>')

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_(IEnumerator_T_)'></a>

## Il2CppEnumerator<T>.implicit operator Il2CppEnumerator<T>(IEnumerator<T>) Operator

Wraps an il2cpp enumerator

```csharp
public static BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T> implicit operator Il2CppEnumerator<T>(IEnumerator<T> enumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.op_ImplicitBTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_(IEnumerator_T_).enumerator'></a>

`enumerator` [Il2CppSystem.Collections.Generic.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.IEnumerator 'Il2CppSystem.Collections.Generic.IEnumerator')

#### Returns
[BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator&lt;](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>')[T](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md#BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.T 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>.T')[&gt;](BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.md 'BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator<T>')
### Explicit Interface Implementations

<a name='BTD_Mod_Helper.Api.Helpers.Il2CppEnumerator_T_.System.Collections.IEnumerator.Current'></a>

## Il2CppEnumerator<T>.System.Collections.IEnumerator.Current Property

Gets the current element in the collection.

```csharp
object System.Collections.IEnumerator.Current { get; }
```

Implements [Current](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.Current 'System.Collections.IEnumerator.Current')