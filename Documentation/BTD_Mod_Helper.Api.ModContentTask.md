#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api](index.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModContentTask Class

Initial task to register ModContent from other mods

```csharp
internal class ModContentTask : BTD_Mod_Helper.Api.ModLoadTask
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModLoadTask](BTD_Mod_Helper.Api.ModLoadTask.md 'BTD_Mod_Helper.Api.ModLoadTask') &#129106; ModContentTask
### Properties

<a name='BTD_Mod_Helper.Api.ModContentTask.DisplayName'></a>

## ModContentTask.DisplayName Property

The name that will be actually displayed for this in game

```csharp
public override string DisplayName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.ModContentTask.Coroutine()'></a>

## ModContentTask.Coroutine() Method

Registers ModContent from other mods

```csharp
public override System.Collections.IEnumerator Coroutine();
```

#### Returns
[System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator')

<a name='BTD_Mod_Helper.Api.ModContentTask.Load()'></a>

## ModContentTask.Load() Method

Don't load this like a normal task

```csharp
public override System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')