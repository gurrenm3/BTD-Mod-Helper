**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

A CustomInput is BTD6's mechanism for temporarily taking over the player's cursor to pick a position in the world for some tower action, such as choosing an Overclock recipient or choosing the location for a Wall of Fire. The Mod Helper's `ModCustomInput` lets you define your own.

# [ModCustomInput](/docs/BTD_Mod_Helper.Api.Towers.ModCustomInput)

## Common Overrides

`GetHelperMessage(CustomInput customInput)`: The text shown to the player while the custom input is active (e.g. "Set Patrol Point"). You can return different strings based on what's currently under the cursor by reading `customInput.inputManager.CursorPositionWorld` or `customInput.tower`.

`IsPositionValid(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)`: Decides whether the current cursor position is something the player can confirm on. Defaults to always valid.

`OnValidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)`: Called when the player clicks/releases on a valid position. **The default implementation immediately exits custom input mode**. If you want to keep the input active after a click (e.g. to allow making multiple selections), choose a different strategy for calling `base` / `customInput.inputManager.ExitCustomMode()` yourself.

`OnInvalidPositionCursorUp(CustomInput customInput, Vector2 cursorPosWorld, bool isCursorInWorld)`: Called when the player clicks/releases on an invalid position. By default does nothing, leaving the input active. You could consider calling `customInput.inputManager.SetHelperMessage(message, 3)` to manually display a reason the spot is invalid.

`Update(CustomInput customInput, Vector3 cursorPosUnityWorld, Vector2 cursorPosWorld, bool isCursorActive)`: Called every frame while the input is active. Useful for updating the helper message, preview displays, etc. based on what's under the cursor.

## Other Overrides

`EnterInputMode(CustomInput customInput)` / `ExitInputMode(CustomInput customInput)`: Hooks for when the custom input mode is entered / exited.

`GetCantActivateMessage(CustomInput customInput)`: Returns the default of null to allow the CustomInput to activate normally. Return an error string to prevent the input from activating and instead display the error.

## Activating a Custom Input

There are two main ways to activate your `ModCustomInput`:

**From a TSM Button**: When using [ModTsmTheme](/wiki/Making-a-Custom-TSM-Theme), pass the Id of your `ModCustomInput` as the `customInputId` argument of `AddTSMButton`. Pressing the button will then automatically activate the input, with `customInput.tower` and `customInput.buttonId` populated for you.

```cs
theme.gameObject.AddTSMButton(
    new("MyButton", RightArrowX, AboveArrowsY, DefaultButtonSize),
    VanillaSprites.GreenBtnSquare,
    "MyButton",
    GetId<MyCustomInput>()
);
```

**Programmatically**: Use `PrimeCustomInput` on an `InputManager`.

```cs
inputManager.PrimeCustomInput(ModContent.GetInstance<MyCustomInput>().Activate(inputManager));
```

The static `ModCustomInput.ActiveInput` property tracks which (if any) Mod Helper Custom Input is currently active.

## Example

This is an example from Tactical Tweaks' Pursuit Path Prioritization tweak used for choosing a path on the map.

```cs
public class PursuitCustomInput : ModCustomInput
{
    public override string GetHelperMessage(CustomInput customInput) =>
        "Prioritize pursuing specific path(s)";

    public static PathSegment? GetPath(UnityEngine.Vector2 cursorPosWorld) =>
        Simulation.Current.map.pathManager.FirstPathSegmentInRangeOrDefault(new Vector2(cursorPosWorld), 10);

    public override bool IsPositionValid(CustomInput customInput, UnityEngine.Vector2 cursorPosWorld,
        bool isCursorInWorld)
    {
        return isCursorInWorld && GetPath(cursorPosWorld) != null;
    }

    public override void OnValidPositionCursorUp(CustomInput customInput, UnityEngine.Vector2 cursorPosWorld,
        bool isCursorInWorld)
    {
        var path = GetPath(cursorPosWorld)!.path.def.pathId;

        if (!PathSelections.TryGetValue(customInput.tower.Id, out var paths))
        {
            paths = [];
            PathSelections.Add(customInput.tower.Id, paths);
        }

        if (paths.Contains(path))
        {
            paths.Remove(path);
        }
        else
        {
            paths.Add(path);
        }
        
        base.OnValidPositionCursorUp(customInput, cursorPosWorld, isCursorInWorld);
    }

    public override void Update(CustomInput customInput, UnityEngine.Vector3 cursorPosUnityWorld,
        UnityEngine.Vector2 cursorPosWorld, bool isCursorActive)
    {
        if (!isCursorActive) return;
    
        var path = GetPath(cursorPosWorld)?.path.def.pathId;
    
        var message = GetHelperMessage(customInput);
    
        var pathIds = PathSelections.GetValueOrDefault(customInput.tower.Id, []);
    
        if (path != null)
        {
            message = pathIds.Contains(path) ? $"Stop prioritizing {path}" : $"Start prioritizing {path}";
        }
    
        customInput.inputManager.SetHelperMessage(message);
    }
}
```
