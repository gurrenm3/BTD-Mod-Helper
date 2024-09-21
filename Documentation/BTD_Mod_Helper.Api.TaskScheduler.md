#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## TaskScheduler Class

Class for scheduling Tasks using MelonCoroutines

```csharp
public static class TaskScheduler
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TaskScheduler
### Methods

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_)'></a>

## TaskScheduler.ScheduleTask(Action, ScheduleType, int, Func<bool>) Method

Schedule a task to execute later on as a Coroutine

```csharp
public static void ScheduleTask(System.Action action, BTD_Mod_Helper.Api.Enums.ScheduleType scheduleType, int amountToWait, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).scheduleType'></a>

`scheduleType` [ScheduleType](BTD_Mod_Helper.Api.Enums.ScheduleType.md 'BTD_Mod_Helper.Api.Enums.ScheduleType')

How you want to wait for your task

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).amountToWait'></a>

`amountToWait` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The amount you want to wait

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,System.Func_bool_)'></a>

## TaskScheduler.ScheduleTask(Action, Func<bool>) Method

Schedule a task to execute later on as a Coroutine. By default will wait until the end of this current frame

```csharp
public static void ScheduleTask(System.Action action, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

The action you want to execute once it's time to run your task

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Action,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

Wait for this to be true before executing task

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Collections.IEnumerator)'></a>

## TaskScheduler.ScheduleTask(IEnumerator) Method

Schedule a task to execute right now as a Coroutine

```csharp
public static void ScheduleTask(System.Collections.IEnumerator iEnumerator);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.TaskScheduler.ScheduleTask(System.Collections.IEnumerator).iEnumerator'></a>

`iEnumerator` [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.TaskScheduler.WaiterCoroutine(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_)'></a>

## TaskScheduler.WaiterCoroutine(Action, ScheduleType, int, Func<bool>) Method

This coroutine will wait for amountToWait before finishing

```csharp
private static System.Collections.IEnumerator WaiterCoroutine(System.Action action, BTD_Mod_Helper.Api.Enums.ScheduleType scheduleType, int amountToWait, System.Func<bool> waitCondition=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.TaskScheduler.WaiterCoroutine(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).action'></a>

`action` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')

<a name='BTD_Mod_Helper.Api.TaskScheduler.WaiterCoroutine(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).scheduleType'></a>

`scheduleType` [ScheduleType](BTD_Mod_Helper.Api.Enums.ScheduleType.md 'BTD_Mod_Helper.Api.Enums.ScheduleType')

<a name='BTD_Mod_Helper.Api.TaskScheduler.WaiterCoroutine(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).amountToWait'></a>

`amountToWait` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.TaskScheduler.WaiterCoroutine(System.Action,BTD_Mod_Helper.Api.Enums.ScheduleType,int,System.Func_bool_).waitCondition'></a>

`waitCondition` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')