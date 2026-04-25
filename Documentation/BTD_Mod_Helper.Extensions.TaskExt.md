#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## TaskExt Class

Extensions for Il2Cpp Task

```csharp
public static class TaskExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TaskExt
### Methods

<a name='BTD_Mod_Helper.Extensions.TaskExt.ContinueWithIl2Cpp_T_(thisTask_T_,System.Action_Task_T__)'></a>

## TaskExt.ContinueWithIl2Cpp<T>(this Task<T>, Action<Task<T>>) Method

Calls ContinueWith properly typed for IL2CPP

```csharp
public static void ContinueWithIl2Cpp<T>(this Task<T> task, System.Action<Task<T>> action);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TaskExt.ContinueWithIl2Cpp_T_(thisTask_T_,System.Action_Task_T__).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TaskExt.ContinueWithIl2Cpp_T_(thisTask_T_,System.Action_Task_T__).task'></a>

`task` [Il2CppSystem.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Threading.Tasks.Task 'Il2CppSystem.Threading.Tasks.Task')

<a name='BTD_Mod_Helper.Extensions.TaskExt.ContinueWithIl2Cpp_T_(thisTask_T_,System.Action_Task_T__).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppSystem.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Threading.Tasks.Task 'Il2CppSystem.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_)'></a>

## TaskExt.Then<T>(this Task<T>, Action<T>, Action<AggregateException>) Method

Calls ContinueWith properly typed for IL2CPP with the task's Result

```csharp
public static void Then<T>(this Task<T> task, System.Action<T> action, System.Action<AggregateException> error=null);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_).T'></a>

`T`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_).task'></a>

`task` [Il2CppSystem.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Threading.Tasks.Task 'Il2CppSystem.Threading.Tasks.Task')

<a name='BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](BTD_Mod_Helper.Extensions.TaskExt.md#BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_).T 'BTD_Mod_Helper.Extensions.TaskExt.Then<T>(this Task<T>, System.Action<T>, System.Action<AggregateException>).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

<a name='BTD_Mod_Helper.Extensions.TaskExt.Then_T_(thisTask_T_,System.Action_T_,System.Action_AggregateException_).error'></a>

`error` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[Il2CppSystem.AggregateException](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.AggregateException 'Il2CppSystem.AggregateException')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')