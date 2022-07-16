#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Patches](index.md#BTD_Mod_Helper.Patches 'BTD_Mod_Helper.Patches')

## Main_GetInitialLoadTasks Class

```csharp
internal static class Main_GetInitialLoadTasks
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Main_GetInitialLoadTasks
### Fields

<a name='BTD_Mod_Helper.Patches.Main_GetInitialLoadTasks.CustomGameModelLoadName'></a>

## Main_GetInitialLoadTasks.CustomGameModelLoadName Field

I noticed that if any tasks are added after the vanilla final task of loading the GameModel, then aren't run.  
But, since most tasks we want to add need to deal with the GameModel, I added in a custom task to load the  
GameModel that can precede our tasks. Then, the real GameModel load task happens, but I've patched it to  
not re-load a new GameModel and instead just return the same one that's already been modified.

```csharp
internal const string CustomGameModelLoadName = Pre-Preparing Darts...;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')