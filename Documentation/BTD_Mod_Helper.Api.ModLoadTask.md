#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api](index.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModLoadTask Class

Class for a Coroutine style task that runs during the BTD6 loading screen

```csharp
public abstract class ModLoadTask : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModLoadTask

Derived  
&#8627; [ModContentTask](BTD_Mod_Helper.Api.ModContentTask.md 'BTD_Mod_Helper.Api.ModContentTask')  
&#8627; [PreLoadResourcesTask](BTD_Mod_Helper.Api.PreLoadResourcesTask.md 'BTD_Mod_Helper.Api.PreLoadResourcesTask')  
&#8627; [ByteWaitTask](BTD_Mod_Helper.ByteWaitTask.md 'BTD_Mod_Helper.ByteWaitTask')
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

<a name='BTD_Mod_Helper.Api.ModLoadTask.RegisterPerFrame'></a>

## ModLoadTask.RegisterPerFrame Property

(Cross-Game compatible) How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier loading.

```csharp
public sealed override int RegisterPerFrame { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.ModLoadTask.Coroutine()'></a>

## ModLoadTask.Coroutine() Method

Coroutine style function

```csharp
public abstract System.Collections.IEnumerator Coroutine();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModLoadTask.Register()'></a>

## ModLoadTask.Register() Method

(Cross-Game compatible) Registers this ModContent into the game

```csharp
public override void Register();
```