Certain mods that have a big task that needs to performed when the game starts (such as Ultimate Crosspathing) can make use of Custom Load Tasks to add those tasks to the game's queue of tasks that run like Coroutines in Unity, happening over the course of multiple frames so that the game doesn't lock up.

# [ModLoadTask](https://github.com/gurrenm3/BTD-Mod-Helper/blob/3.0_Features/Documentation/BTD_Mod_Helper.Api.ModLoadTask.md)

## Required Overrides

`DisplayName`: What appears on screen when this task is running

`IEnumerator Coroutine`: The task that the game should run.

For those familiar with Unity Coroutines, this is like those except every yield return statement you do will be treated as a [WaitForEndOfFrame](https://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html).

If you're not familiar, it's a way of taking advantage of C#'s `IEnumerator` class, the back bone of all things you can enumerate like arrays and lists, and using it to define a method that can be run in different sections over the course of multiple frames.

When your task begins running, it'll execute all the code you've written in your `Coroutine` method up until you write
 ```
yield return null;
```
It'll then finish its execution for that frame and wait for the next one, where it will then continue where it left off until it reaches another yield return and so on until the end of the method.

## Reliability

The `ModLoadTask` system relies on some complex patching behind the scenes that's subject to breakage when NK updates. Because of this, the Mod Helper automatically detects if the necessary patches were successful on startup, and if they weren't, it falls back to synchronously running the LoadTasks in one very laggy from on the Title Screen like the old days.

The fact that you used a Load Task should never be the lone reason why your mod doesn't work.

## Example

This task is used internally within the Mod Helper itself to wait for all the [ModByteLoader](https://github.com/gurrenm3/BTD-Mod-Helper/blob/3.0_Features/Documentation/BTD_Mod_Helper.Api.ModByteLoader.md)s to be finished before continuing with other Load tasks. Show cases how you can use your yield statements even inside loops.

```cs
internal class ByteWaitTask : ModLoadTask
{
    public override string DisplayName => "Waiting for ByteLoaders...";

    /// <summary>
    /// Don't automatically load this ModContent, it gets added specially
    /// </summary>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

    /// <summary>
    /// Wait for the bytes to all be loaded
    /// </summary>
    public override IEnumerator Coroutine()
    {
        while (!ModByteLoader.loadedAllBytes)
        {
            yield return null;
        }
    }
}
```

