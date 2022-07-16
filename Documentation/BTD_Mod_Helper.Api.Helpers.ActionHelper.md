#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## ActionHelper Class

Class for converting actions and functions

```csharp
public static class ActionHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ActionHelper
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction(BTD_Mod_Helper.Extensions.Function)'></a>

## ActionHelper.CreateFromOptionalFunction(Function) Method

Converts a nullable function into an action

```csharp
public static System.Action CreateFromOptionalFunction(BTD_Mod_Helper.Extensions.Function funcToExecute);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction(BTD_Mod_Helper.Extensions.Function).funcToExecute'></a>

`funcToExecute` [Function()](BTD_Mod_Helper.Extensions.Function().md 'BTD_Mod_Helper.Extensions.Function()')

#### Returns
[System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

<a name='BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction_T_(BTD_Mod_Helper.Extensions.Function_T_)'></a>

## ActionHelper.CreateFromOptionalFunction<T>(Function<T>) Method

Converts a nullable function into an action

```csharp
public static System.Action<T> CreateFromOptionalFunction<T>(BTD_Mod_Helper.Extensions.Function<T> funcToExecute);
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction_T_(BTD_Mod_Helper.Extensions.Function_T_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction_T_(BTD_Mod_Helper.Extensions.Function_T_).funcToExecute'></a>

`funcToExecute` [BTD_Mod_Helper.Extensions.Function&lt;](BTD_Mod_Helper.Extensions.Function_T_().md 'BTD_Mod_Helper.Extensions.Function<T>()')[T](BTD_Mod_Helper.Api.Helpers.ActionHelper.md#BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction_T_(BTD_Mod_Helper.Extensions.Function_T_).T 'BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction<T>(BTD_Mod_Helper.Extensions.Function<T>).T')[&gt;](BTD_Mod_Helper.Extensions.Function_T_().md 'BTD_Mod_Helper.Extensions.Function<T>()')

#### Returns
[System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Api.Helpers.ActionHelper.md#BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction_T_(BTD_Mod_Helper.Extensions.Function_T_).T 'BTD_Mod_Helper.Api.Helpers.ActionHelper.CreateFromOptionalFunction<T>(BTD_Mod_Helper.Extensions.Function<T>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')