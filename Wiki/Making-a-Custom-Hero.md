**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki. Without both of those things being true, this likely won't be a very useful resource for you.**

Making a custom hero is very much like [Making a Custom Tower](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower). You should be familiar with the information in that guide before reading this one, as some repeated information will be ommitted.

The tl;dr of making a custom Hero is that you just make a custom Tower, but use the `ModHero` and `ModLevel` classes in place of `ModTower` and `ModUpgrade`. If you're someone who likes flying by the seat of your IDE's autocomplete, then that might be as much information as you need to get started.

# ModHero

## Required Properties

`Cost`: Same as with `ModTower`

`BaseTower`: Same as with `ModTower`

`DisplayName`: Same as `ModTower`. This will usually be the name of the Hero, like "Benjamin"

`Description`: Same as `ModTower`. The overall description of your Hero as it appears in menus.

`Title`: The short description of your hero, like "Code Monkey" for Benjamin

`MaxLevel`: Instead of the "___PathUpgrades" properties, you use this to define the max level of your hero. Like with those properties, don't preemptively set this to a higher number than the amount of `ModHeroLevel`s you've actually created so far.

`Level1Description`: The description of the level 1 upgrade of your hero. You won't be making a `ModHeroLevel` for level 1, just 2 and up, so this is defined here. 

`XpRatio`: How fast the hero levels up. Quincy, Gwendolin, Striker Jones, Obyn and Etienne have 1.0; Ezili, Pat Fusty, Brickell, and Sauda have 1.425; Benjamin and Psi have 1.5; and Captain Churchill and Adora have 1.71.

`Abilities`: The total number of abilities that you've added for your Hero.

## Required Methods

`ModifyBaseTowerModel`: Same as `ModTower`. This is defining the behavior of your Level 1 Hero.

## Visuals

You'll want to include 4 images for your base hero:

- [Name]-Portrait: Same as `ModTower` portrait
- [Name]-Icon: Same as `ModTower` icon
- [Name]-Button: The hero button that's used in menus showing which hero you have active
- [Name]-Square: The newer square button that's used in the revamped hero selection screen

Also for the revamped hero select screen, you can override the `NameStyle`, `BackgroundStyle` and `GlowStyle` properties to be the `TowerType.___` of the heroes you'd like to copy the respective elements of.

## Other Properties

`RogueStarterArtifact`: The artifact Id that this hero will start with for Rogue Legends runs. If not specified, the hero will use Starting Strong Common

`RogueStarterInstas`: The insta towers that this hero will start with for Rogue Legends runs. If not specified, the hero will use a 2-0-0 Ninja Monkey and 2-0-0 Alchemist 

## Example

A full example from the Industrial Farmer mod

```cs
public class IndustrialFarmer : ModHero
{
    public override string BaseTower => TowerType.BananaFarmer;

    public override int Cost => 1400;

    public override string DisplayName => "Norman";
    public override string Title => "Industrial Farmer";
    public override string Level1Description => "Collects nearby bananas. Your next Banana Farm is free.";

    public override string Description =>
        "Norman collects your Bananas and helps you expand your farming operations.";

    public override string NameStyle => TowerType.Gwendolin; // Yellow colored
    public override string BackgroundStyle => TowerType.Etienne; // Yellow colored
    public override string GlowStyle => TowerType.StrikerJones; // Yellow colored

    public override float XpRatio => 1.0f;

    public override string RogueStarterArtifact => "TheUnspokenHeroes1";
    public override IEnumerable<(string, int[])> RogueStarterInstas =>
    [
        (TowerType.BananaFarm, [0, 0, 0]),
        (TowerType.EngineerMonkey, [0, 0, 2])
    ];
}
```

# ModHeroLevel

Like with `ModUpgrade`s, you'll want to declare these classes using your `ModHero` class's name as the type parameter to specify it's for them

```cs
public class CustomLevel2 : ModHeroLevel<MyCutomHero>
{
    ...
}
```

## Required Properties

`Level`: Instead of Path and Tier like `ModUpgrade`, you just have this to signify what level this corresponds to.

## Optional Properties

`AbilityName`: If this upgrade adds an ability, then you must indicate the `DisplayName` field of its `AbilityModel` hero

`AbilityDescription`: What you want the displayed description of the ability to be

## Required Methods

`ApplyUpgrade(TowerModel towerModel)`: Just like `ModUpgrade`, apply the effects to the tower model that you want leveling up to provide.

If you're adding a new Ability with this upgrade, as well as making use of the `AbilityName` and `AbilityDescription` properties, you should also be sure to include a line like this when constructing your `AbilityModel`.

```cs
abilityModel.addedViaUpgrade = Id;
```

This will help make sure the Ability is shown properly for this upgrade/level in the Hero screen.

## Visuals

Like with `ModUpgrade`s, if you include an image named after your ModUpgrade with "-Portrait" following it, then your hero will use that as its portrait if it's at least that level.

## Example

A full example from the Industrial Farmer mod

```cs
public class Level7 : ModHeroLevel<IndustrialFarmer>
{
    public override string Description => "Range is increased.";
    public override int Level => 7;
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.range += 15;
        towerModel.GetBehavior<CollectCashZoneModel>().attractRange += 15;
    }
}
```
