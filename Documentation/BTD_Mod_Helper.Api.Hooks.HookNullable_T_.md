#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks](README.md#BTD_Mod_Helper.Api.Hooks 'BTD_Mod_Helper.Api.Hooks')

## HookNullable<T> Struct

Provides a simplified nullable type for unmanaged types, used as a replacement for Il2CPP's nullable implementation

```csharp
public struct HookNullable<T>
    where T : unmanaged, System.ValueType, System.ValueType
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.T'></a>

`T`

The underlying unmanaged type
### Constructors

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.HookNullable(T)'></a>

## HookNullable(T) Constructor

Constructor that takes in the value set

```csharp
public HookNullable(T value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.HookNullable(T).value'></a>

`value` [T](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.T 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.T')

Value to contain
### Fields

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.HasValue'></a>

## HookNullable<T>.HasValue Field

Indicates whether a value is present  
A non-zero value indicates that the [Value](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.Value 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.Value') is valid

```csharp
public byte HasValue;
```

#### Field Value
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.Value'></a>

## HookNullable<T>.Value Field

The underlying value of type [T](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.T 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.T') if available  
Access this value only when [HasValue](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.HasValue 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.HasValue') indicates that a value is present

```csharp
public T Value;
```

#### Field Value
[T](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.T 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.T')
### Methods

<a name='BTD_Mod_Helper.Api.Hooks.HookNullable_T_.GetValueOrDefault()'></a>

## HookNullable<T>.GetValueOrDefault() Method

Adds a quick way to get whatever value is contained

```csharp
public T GetValueOrDefault();
```

#### Returns
[T](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.T 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.T')  
If [HasValue](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.HasValue 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.HasValue') is non-zero, [Value](BTD_Mod_Helper.Api.Hooks.HookNullable_T_.md#BTD_Mod_Helper.Api.Hooks.HookNullable_T_.Value 'BTD_Mod_Helper.Api.Hooks.HookNullable<T>.Value'), otherwise default