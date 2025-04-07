#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks](README.md#BTD_Mod_Helper.Api.Hooks 'BTD_Mod_Helper.Api.Hooks')

## HookTargetAttribute Class

Specifies the target type and hook type for a method hook.

```csharp
public class HookTargetAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; HookTargetAttribute
### Constructors

<a name='BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.HookTargetAttribute(System.Type,BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType)'></a>

## HookTargetAttribute(Type, EHookType) Constructor

Specifies the target type and hook type for a method hook.

```csharp
public HookTargetAttribute(System.Type targetType, BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType hookType);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.HookTargetAttribute(System.Type,BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType).targetType'></a>

`targetType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The ModHook type that this hook targets

<a name='BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.HookTargetAttribute(System.Type,BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType).hookType'></a>

`hookType` [EHookType](BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType.md 'BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType')

The type of hook (Prefix or Postfix)
### Properties

<a name='BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.HookType'></a>

## HookTargetAttribute.HookType Property

Gets the hook type indicating when the hook is applied

```csharp
public BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType HookType { get; }
```

#### Property Value
[EHookType](BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType.md 'BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.EHookType')

<a name='BTD_Mod_Helper.Api.Hooks.HookTargetAttribute.TargetType'></a>

## HookTargetAttribute.TargetType Property

Gets the target type that this hook applies to

```csharp
public System.Type TargetType { get; }
```

#### Property Value
[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')