**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

A custom Round Set is just what it sounds like, a new collection of Rounds you can face alongside the vanilla default and ABR round sets. Round Sets can be used directly for any map if the "Show Roundset Changer" Mod Helper setting is enabled, or they can be used as part of a [Custom Game Mode](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Game-Mode), something that actually adds a new Button in the mode select screen.

# [ModRoundSet](/docs/BTD_Mod_Helper.Api.Bloons.ModRoundSet)

## Common Overrides

`BaseRoundSet`: A common pattern among modded types, this is the round set to use as a starting point that you can edit from. Best to use one of `RoundSetType.Default`, `RoundSetType.ABR` or `RoundSetType.Empty` to have an empty start.

`DefinedRounds`: The total number of rounds that you will be customizing for this Round Set. Afterwards, randomized freeplay rounds start happening.

## Suggested Overrides

`DisplayName`: What your Round Set should be called in the UI

`CustomHints` and `GetHint(int round)`: Set up custom hint messages to pop up as people play through your rounds.

Add an Icon for your Round Set to use in the round changer by using including a .png with the same name as your class, or using the `Icon` / `IconReference` properties.

## Modifying Rounds

There are a number of different methods you can override to help organize your modification/addition of rounds

`ModifyRoundsModels(RoundModel roundModel, int round)`: Called for every round 1 to `DefinedRounds`

`ModifyEasyRoundModels(RoundModel roundModel, int round)`: Called to modify specifically just rounds from 1 to 40

`ModifyMediumRoundModels(RoundModel roundModel, int round)`: Called to modify specifically just rounds from 41 to 60

`ModifyHardRoundModels(RoundModel roundModel, int round)`: Called to modify specifically just rounds from 61 to 80

`ModifyImpoppableRoundModels(RoundModel roundModel, int round)`: Called to modify specifically just rounds from 81 to 100

Your round modification code will likely involve overriding a number of those methods and using a switch statement to define the individual rounds
```cs
public override void ModifyEasyRoundModels(RoundModel roundModel, int round)
{
    switch(round)
    {
        case 1:
            ...
            roundModel.ClearBloonGroups();
            ...
            break;
        case 2:
            ...
            roundModel.AddBloonGroup(...);
            ...
            break;
        case 3:
            ...
            roundModel.AddBloonGroup<MyCustomBloon>(...);
            ...
            break;
        case 4:
            ...
            roundModel.ReplaceBloonInGroups(...);
            ...
            break;
        ...
    }
}
```

## Tips

- Use the Mod Helper's [extension methods](/docs/BTD_Mod_Helper.Extensions.RoundModelExt) for `RoundModel`s
- Don't edit the `emissions` of the RoundModel. That gets automatically populated based on the groups.

## Example

An all regrow version of the default round set, also showcasing the `FindChangedBloonId` extension method as an easy way to find regrow versions of Bloons, if they exist.

```cs
public class AllRegrow : ModRoundSet
{
    public override string BaseRoundSet => RoundSetType.Default;
    public override int DefinedRounds => BaseRounds.Count;
    public override string DisplayName => "All Regrow";
    public override string Icon => VanillaSprites.RegrowBloonIcon;

    public override void ModifyRoundModels(RoundModel roundModel, int round)
    {
        foreach (var group in roundModel.groups)
        {
            var bloon = Game.instance.model.GetBloon(group.bloon);
            if (bloon.FindChangedBloonId(bloonModel => bloonModel.isGrow = true, out var regrowBloon))
            {
                group.bloon = regrowBloon;
            }
        }
    }
}
```




