**This guide assumes that you have an already working custom `ModTower` with all 3 upgrade paths implemented and all 5 upgrades each. If you don't have that then follow [this](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Tower) guide and get all that created first.**

# ModTower Changes

To give your `ModTower` a Paragon, the only change you need to make is to override the `ParagonMode` property. You have the following options for it:

`ParagonMode.Base000`: The Mod Helper will use the 0-0-0 version of your Tower as the base TowerModel for you to create the Paragon from.

`ParagonMode.Base555`: The Mod Helper will use the 5-5-5 version of your Tower (same as you'd get when using the Ultimate Crosspathing mod) as the base TowerModel for you to create the Paragon from.

There's also obviously `ParagonMode.None`, but that's just the default, and if you're reading this guide then you probably don't want to use that.

For example, the Card Monkey mod uses the 555 mode.
```cs
public class CardMonkey : ModTower {

    /* ... */

    public override ParagonMode ParagonMode => ParagonMode.Base555;

    /* ... */

}
```

# ModParagonUpgrade

The next and most important step is to create a new class that extends `ModParagonUpgrade`, and to pass in your `ModTower` as its generic type.

This `ModParagonUpgrade` has all the normal properties for you to override just like a normal `ModUpgrade`. The additional things to note are:

`ApplyUpgrade(TowerModel towerModel)`: Same functionality, this should handle all the logic of the attacks and behaviors of your Paragon. It does *not* need to handle giving your Paragon the `ParagonTowerModel` behavior, because instead...

`ParagonTowerModel`: An optional property for the `ParagonTowerModel` behavior that should be given to this Paragon. If you don't override it, then the Boomerang Paragon's behavior will be used.

`RemoveAbilities`: An optional property for automatically removing any abilities from the base `TowerModel` like real Paragons, defaults to true.

Here's a complete example of a ModParagonUpgrade from the CardMonkey mod:

```cs
public class GodKingOfSpades : ModParagonUpgrade<CardMonkey>
{
    public override int Cost => 400000;
    public override string Description => "Sometimes the hand of fate must be forced...";
    public override string DisplayName => "God-King of Spades";

    // This is getting its Icon and Portrait from GodKingOfSpades-Icon.png and GodKingOfSpace-Portrait.png, so no other overriding needed

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        // Using 555 mode so not much has to be done here if you don't want to
    }
}
```

# New ModTowerDisplays

Paragons use different displays based on what degree they are, and that's normally controlled by the `ParagonTowerModel` behavior. If you don't want to deal with that yourself, you can make use of some new features of `ModTowerDisplay`s:

`ParagonDisplayIndex`: A number between 0 and 4 (inclusive) representing which set of paragon degrees this display applies to

- 0: Degree 1 - 20 
- 1: Degree 21 - 40 
- 2: Degree 41 - 60 
- 3: Degree 61 - 80 
- 4: Degree 81 - 100 

If you don't have one for every index, then the next highest one will be used. By default on a `ModTowerDisplay` this is set to -1, meaning it won't interact with the `ParagonTowerModel` behavior. If you don't care about having different displays, just do everything normally and then set this to 0.

`UseForTower(int[] tiers)`: When overriding this method, return `IsParagon(tiers)` to have it be used for your Paragon.

Here's a complete example of a `ModTowerDisplay` for a Paragon from Card Monkey. This uses the advanced method of overriding `Load()` to create multiple versions of the display, one for each `ParagonDisplayIndex`, in this case at a different scale for each.

```cs

public class CardMonkeyParagonDisplay : ModTowerDisplay<CardMonkey>
{
    public override float Scale => .75f + ParagonDisplayIndex * .025f;  // Higher degree Paragon displays will be bigger

    public override string BaseDisplay =>  // The floating monkey part of the True Sun God
        Game.instance.model.GetTower(TowerType.SuperMonkey, 5).GetAttackModel().GetBehavior<DisplayModel>().display;

    public override bool UseForTower(int[] tiers)
    {
        return IsParagon(tiers);
    }

    /// <summary>
    /// All classes that derive from ModContent MUST have a zero argument constructor to work
    /// </summary>
    public CardMonkeyParagonDisplay()
    {
    }

    public CardMonkeyParagonDisplay(int i)
    {
        ParagonDisplayIndex = i;
    }

    public override int ParagonDisplayIndex { get; }  // Overriding in this way lets us set it in the constructor

    /// <summary>
    /// Create a display for each possible ParagonDisplayIndex
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load()
    {
        for (var i = 0; i < TotalParagonDisplays; i++)
        {
            yield return new CardMonkeyParagonDisplay(i);
        }
    }


    public override string Name => nameof(CardMonkeyParagonDisplay) + ParagonDisplayIndex;  // make sure each instance has its own name

    /// <summary>
    /// Could use the ParagonDisplayIndex property to use different effects based on the paragon strength
    /// </summary>
    /// <param name="node"></param>
    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        //node.PrintInfo();
        //node.SaveMeshTexture();
        SetMeshTexture(node, nameof(CardMonkeyParagonDisplay));
    }
}
```

***

# Congratulations! You know have all the required information on the Mod Helper's role in making custom Paragons for your custom towers. Now you just gotta get into the nitty gritty with behaviors, or not, if you're satisfied with 555 mode.