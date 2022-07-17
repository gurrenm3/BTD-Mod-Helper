#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModLoadTask Class

Class for a Coroutine style task that runs during the BTD6 loading screen

```csharp
public abstract class ModLoadTask : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModLoadTask

Derived  
&#8627; [PreLoadResourcesTask](BTD_Mod_Helper.Api.PreLoadResourcesTask.md 'BTD_Mod_Helper.Api.PreLoadResourcesTask')
### Properties

<a name='BTD_Mod_Helper.Api.ModLoadTask.Description'></a>

## ModLoadTask.Description Property

The in game description of this

```csharp
public sealed override string Description { get; }
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
### Methods

<a name='BTD_Mod_Helper.Api.ModLoadTask.Coroutine()'></a>

## ModLoadTask.Coroutine() Method

Coroutine style function

```csharp
public abstract System.Collections.IEnumerator Coroutine();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')