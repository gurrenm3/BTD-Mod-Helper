#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks](README.md#BTD_Mod_Helper.Api.Hooks 'BTD_Mod_Helper.Api.Hooks')

## HookPriorityAttribute Class

Specifies the priority of this hook compared to others

```csharp
public class HookPriorityAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; HookPriorityAttribute
### Constructors

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.HookPriorityAttribute(int)'></a>

## HookPriorityAttribute(int) Constructor

<inheritdoc/>

```csharp
public HookPriorityAttribute(int priority=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.HookPriorityAttribute(int).priority'></a>

`priority` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The priority to set
### Fields

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.Default'></a>

## HookPriorityAttribute.Default Field

Represents the default level with a value of 0

```csharp
public const int Default = 0;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.High'></a>

## HookPriorityAttribute.High Field

Represents a high level with a value of 50

```csharp
public const int High = 50;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.Higher'></a>

## HookPriorityAttribute.Higher Field

Represents the higher level with a value of 100

```csharp
public const int Higher = 100;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.Low'></a>

## HookPriorityAttribute.Low Field

Represents a low level with a value of -50

```csharp
public const int Low = -50;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.Lower'></a>

## HookPriorityAttribute.Lower Field

Represents the lower level with a value of -100

```csharp
public const int Lower = -100;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Hooks.HookPriorityAttribute.Priority'></a>

## HookPriorityAttribute.Priority Field

Backing priority value for sorting

```csharp
public int Priority;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')