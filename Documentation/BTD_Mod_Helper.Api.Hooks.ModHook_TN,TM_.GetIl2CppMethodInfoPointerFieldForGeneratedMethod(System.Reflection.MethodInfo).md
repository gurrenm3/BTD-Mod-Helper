#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Hooks](README.md#BTD_Mod_Helper.Api.Hooks 'BTD_Mod_Helper.Api.Hooks').[ModHook&lt;TN,TM&gt;](BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.md 'BTD_Mod_Helper.Api.Hooks.ModHook<TN,TM>')

## ModHook<TN,TM>.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(MethodInfo) Delegate

Delegate for retrieving the FieldInfo pointer for a generated method's Il2Cpp method info

```csharp
public delegate System.Reflection.FieldInfo ModHook<TN,TM>.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(System.Reflection.MethodInfo method)
    where TN : System.Delegate
    where TM : System.Delegate;
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(System.Reflection.MethodInfo).TN'></a>

`TN`

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(System.Reflection.MethodInfo).TM'></a>

`TM`
#### Parameters

<a name='BTD_Mod_Helper.Api.Hooks.ModHook_TN,TM_.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(System.Reflection.MethodInfo).method'></a>

`method` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

The method info of the target method

#### Returns
[System.Reflection.FieldInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.FieldInfo 'System.Reflection.FieldInfo')  
The FieldInfo containing the method info pointer