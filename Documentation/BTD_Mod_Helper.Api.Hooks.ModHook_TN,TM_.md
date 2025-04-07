#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks](README.md#BTD_Mod_Helper.Api.Hooks 'BTD_Mod_Helper.Api.Hooks')

## ModHook<TN,TM> Class

Provides a base mod hook for intercepting and modifying method calls using prefix and postfix hooks

```csharp
public abstract class ModHook<TN,TM> : BTD_Mod_Helper.Api.ModContent
    where TN : System.Delegate
    where TM : System.Delegate
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TN'></a>

`TN`

The type of the unmanaged delegate

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TM'></a>

`TM`

The type of the managed delegate

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModHook<TN,TM>

Derived  
&#8627; [BloonDamageHook](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook.md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDamageHook')  
&#8627; [BloonDegradeHook](BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook.md 'BTD_Mod_Helper.Api.Hooks.BloonHooks.BloonDegradeHook')
### Fields

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.Hook'></a>

## ModHook<TN,TM>.Hook Field

The native hook instance used for attaching the hook

```csharp
protected NativeHook<TN> Hook;
```

#### Field Value
[MelonLoader.NativeUtils.NativeHook](https://docs.microsoft.com/en-us/dotnet/api/MelonLoader.NativeUtils.NativeHook 'MelonLoader.NativeUtils.NativeHook')

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.HookDelegate'></a>

## ModHook<TN,TM>.HookDelegate Field

The delegate instance representing the hook method

```csharp
protected TN HookDelegate;
```

#### Field Value
[TN](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TN 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TN')

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.PostfixList'></a>

## ModHook<TN,TM>.PostfixList Field

Stores postfix hook methods sorted by their priority

```csharp
protected Dictionary<int,List<TM>> PostfixList;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TM](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TM 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TM')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.PrefixList'></a>

## ModHook<TN,TM>.PrefixList Field

Stores prefix hook methods sorted by their priority

```csharp
protected Dictionary<int,List<TM>> PrefixList;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[TM](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TM 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TM')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.HookMethod'></a>

## ModHook<TN,TM>.HookMethod Property

Gets the unmanaged hook method used to intercept the target method

```csharp
protected abstract TN HookMethod { get; }
```

#### Property Value
[TN](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TN 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TN')

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TargetMethod'></a>

## ModHook<TN,TM>.TargetMethod Property

Gets the target method information that this mod hook intercepts

```csharp
protected abstract System.Reflection.MethodInfo TargetMethod { get; }
```

#### Property Value
[System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')
### Methods

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.AddPostfix(TM)'></a>

## ModHook<TN,TM>.AddPostfix(TM) Method

Adds a postfix hook method to be executed after the original method

```csharp
public void AddPostfix(TM method);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.AddPostfix(TM).method'></a>

`method` [TM](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TM 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TM')

The postfix hook method

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.AddPrefix(TM)'></a>

## ModHook<TN,TM>.AddPrefix(TM) Method

Adds a prefix hook method to be executed before the original method

```csharp
public void AddPrefix(TM method);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.AddPrefix(TM).method'></a>

`method` [TM](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md#BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.TM 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>.TM')

The prefix hook method

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.CallOriginalMethod(object[])'></a>

## ModHook<TN,TM>.CallOriginalMethod(object[]) Method

Calls the original (trampoline) method with the specified arguments

```csharp
public object CallOriginalMethod(params object[] args);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.CallOriginalMethod(object[]).args'></a>

`args` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

Arguments to pass to the original method

#### Returns
[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')  
The result of the original method call

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.CreateAndAttachHook()'></a>

## ModHook<TN,TM>.CreateAndAttachHook() Method

Creates and attaches the native hook to the target method.  
Validates the delegate type and attaches the hook if valid.

```csharp
public void CreateAndAttachHook();
```

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.GetBoolValue(bool)'></a>

## ModHook<TN,TM>.GetBoolValue(bool) Method

Converts a boolean value to its byte representation.

```csharp
protected static byte GetBoolValue(bool value);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.GetBoolValue(bool).value'></a>

`value` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

The boolean value to convert.

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')  
A byte value where true is 1 and false is 0.

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.Register()'></a>

## ModHook<TN,TM>.Register() Method

Unused

```csharp
public override void Register();
```