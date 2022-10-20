#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModLoadTask Class

Class for a Coroutine style task that runs during the BTD6 loading screen

```csharp
public abstract class ModLoadTask : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModLoadTask
### Properties

<a name='BTD_Mod_Helper.Api.ModLoadTask.Description'></a>

## ModLoadTask.Description Property

The subtext that appears to the right of the Display Name at the bottom of the loading screen  
<br/>  
Can be dynamically changed while running the task

```csharp
public virtual string Description { get; set; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModLoadTask.DisplayNamePlural'></a>

## ModLoadTask.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.ModLoadTask.Progress'></a>

## ModLoadTask.Progress Property

If [ShowProgressBar](BTD_Mod_Helper.Api.ModLoadTask.md#BTD_Mod_Helper.Api.ModLoadTask.ShowProgressBar 'BTD_Mod_Helper.Api.ModLoadTask.ShowProgressBar') is enabled, how much Progress should be shown (from 0 to 1)

```csharp
public float Progress { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.ModLoadTask.ShowProgressBar'></a>

## ModLoadTask.ShowProgressBar Property

Whether to show the progress bar during this task or not

```csharp
public virtual bool ShowProgressBar { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.ModLoadTask.Coroutine()'></a>

## ModLoadTask.Coroutine() Method

Coroutine style function

```csharp
public abstract System.Collections.IEnumerator Coroutine();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')