**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

A custom Game Mode is essentially a completely unrestricted challenge editor mode that is present in the GUI as a button alongside the vanilla game modes like Deflation, Apopalypse or Half-Cash.

# [ModGameMode](/docs/BTD_Mod_Helper.Api.Scenarios.ModGameMode)

## Required Overrides

`BaseGameMode`: A common pattern among modded types, this is the game mode to use as a starting point that you can edit from. Best to get the value from the Mod Helper provided `GameModeType` class, or `GameModeType.None` to start off empty.

`Difficulty`: Which difficulty menu the button should be a part of, one of `DifficultyType.Easy`, `DifficultyType.Medium` or `DifficultyType.Hard`.

`ModifyBaseGameModeModel(ModModel)`: Add the custom rules to your Game Mode here. This will mostly come from adding/changing its `MutatorModModel`s, or using extension methods to do that.

## Common Overrides

`DisplayName`: What your Game Mode should be called in the UI

Add an Icon (512x512) for your Game Mode to use in the round changer by using including a .png with the same name as your class, or using the `Icon` / `IconReference` properties.

## Tips

- Internally, the word "Mod" is used to describe Game Modes, which is why the type you edit is a `ModModel`

- Use the Mod Helper's [extension methods](/docs/BTD_Mod_Helper.Extensions.ModModelExt) for modifying the `ModModel`

## Example

This is a Game Mode to go alongside a custom All Regrow round set. It has a base of `GameModeType.None` because the properties of Medium difficulty apply by default unless manually overriden.

```cs
public class AllRegrowMode : ModGameMode
{
    public override string Difficulty => DifficultyType.Medium;

    public override string BaseGameMode => GameModeType.None;
        
    public override string DisplayName => "All Regrow";

    public override string Icon => VanillaSprites.RegrowBloonIcon;

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        gameModeModel.UseRoundSet<AllRegrow>();
    }
}
```
A modified version of Deflation for Hard difficulty using the values from BTD5

```
public class OldDeflation : ModGameMode
{
    public override string Difficulty => DifficultyType.Hard;
        
    public override string BaseGameMode => GameModeType.Deflation;
        
    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        gameModeModel.SetStartingCash(50000);
        gameModeModel.SetStartingRound(30);
        gameModeModel.SetEndingRound(80);
    }
}
```