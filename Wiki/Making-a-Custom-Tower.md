---
title: Making a Custom Tower
---
**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki. Without both of those things being true, this likely won't be a very useful resource for you.**

If you want a better understanding of what exactly these steps actually do, then having at least a partial understanding of the [ModContent](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/ModContent) system would be helpful.

If you're not someone who likes following step by step written guides, you can look at these for some complete examples:

Doombubbles' [Card Monkey](https://github.com/doombubbles/card-monkey)

Greenphx's [Mini Custom Towers V2](https://github.com/Greenphx9/BTD6Mods/tree/main/MiniCustomTowersV2)

# ModTower

The first and most important part of making a custom Tower is to create a new class in your project that extends from `ModTower`. As soon as you add in ` : ModTower` to your class, your IDE should prompt you to override a number of required Properties and one required Method. The explanations for those are as follows:

## Required Properties

`TowerSet`: The family of Monkeys that your Tower should be put in. For now, just use one of the default constants provided of `PRIMARY`, `MILITARY`, `MAGIC`, or `SUPPORT`.

`BaseTower`: The id of the default BTD Tower that your Tower is going to be copied from by default. So, if your Tower is most similar to a Dart Monkey, for instance, you should do `public override string BaseTower => TowerType.DartMonkey;`

`Cost`: The base cost that your Tower should be on Medium difficulty.

`TopPathUpgrades`: The number of Upgrades your Tower has / will have in its Top path.

`MiddlePathUpgrades`: The number of Upgrades your Tower has / will have in its Middle path.

`BottomPathUpgrades`: The number of Upgrades your Tower has / will have in its Bottom path.

`Description`: The text description to use for this Tower, as seen in the Upgrade menu and stuff.

## ModifyBaseTowerModel

`ModifyBaseTowerModel(TowerModel towerModel)` is the only required method for you to override, and it's the most important. Here you will handle actually making your Tower different from the one you defined in `BaseTower`. 

The `towerModel` variable represents a `TowerModel` object that has already been prepared by the Mod Helper for you to edit. Basically all of the simple things like `name`, `id`, `tiers`, `appliedUpgrades`, `display` have already been taken care of at this point, so the main thing you need to do here is change the Tower's `behaviors`.

All this method actually needs to do is set up the 0-0-0 version of your Tower, because the `ModUpgrade` system will be doing the rest.

## Portrait and Icon

The Icon and Portrait for your Tower are defaulted to being .png files named `TowerClass`-Portrait and `TowerClass`-Icon where `TowerClass` is the name of your class that extends `ModTower`.

If you want to change this, then you can override the `Portrait` / `Icon` properties.

OR, if you'd rather use existing `SpriteReference`s already in the game instead of adding new .pngs, you can override the `PortraitReference` and `IconReference` properties, and it won't try to use pngs.

## Example

Here's a completed example of a `ModTower` class from the Card Monkey mod

```cs
/* imports */

namespace CardMonkey
{
    /// <summary>
    /// The main class that adds the core tower to the game
    /// </summary>
    public class CardMonkey : ModTower
    {
        // public override string Portrait => "Don't need this, default CardMonkey-Portrait.png";
        // public override string Icon => "Don't need this, default becomes CardMonkey-Icon.png";

        public override string TowerSet => PRIMARY;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 400;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Throws playing cards at Bloons";

        // public override string DisplayName => "Don't need this, by default becomes 'Card Monkey'"

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += 10;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 10;
            
            
            var projectile = attackModel.weapons[0].projectile;
            projectile.ApplyDisplay<RedCardDisplay>();  // Make the projectiles look like Cards
            projectile.pierce += 2;
        }

    }
}
```

***

# ModUpgrade(s)

This is one of the main reasons you'd want to use the Mod Helper for your custom Tower rather than doing it all yourself. Instead of having to define the behavior of every different crosspath of your Tower yourself, the Mod Helper can let you define your individual upgrades and write the exact changes that they apply to the `TowerModel`.

For every Upgrade you want your Tower to have, create a class for it that extends `ModUpgrade<TowerClass>`, where `TowerClass` is your `ModTower` extending class that this upgrade is for. When you do, you'll have to override the following:

## Required Properties

`Path`: Which path this is an upgrade for. Use the provided `TOP`, `MIDDLE`, and `BOTTOM` constants. (But they are just 0, 1, and 2)

`Tier`: What tier the upgrade is, 1 - 5.

`Cost`: The cost that your Upgrade should be on Medium difficulty.

`Description`: The text description to use for this Upgrade, as seen in the Selection Menu and Upgrade Menu.

## ApplyUpgrade

Similarly to `ModTower`, there's just one required method to override, and it's the most important.

`ApplyUpgrade(TowerModel towerModel)` should contain the code to change a `TowerModel` from one that doesn't have the effects of this upgrade to one that does.

Also similarly to `TowerModel`, the basic information of the tower is already there, so if you want this upgrade to have different effects depending on what tier the tower is, you can access `towerModel.tiers` or even `towerModel.appliedUpgrades` (just remember to use `ModContent.UpgradeID<T>()` to use the exact name).

By default, `ModUpgrade`s will be applied in tier order 1 - 5, doing Top -> Middle -> Bottom at each tier. If you want to change that, look at the optional `Priority` property.

## Portrait and Icon

The Icon associated with your Upgrade and the Portrait for your Tower when this is its strongest upgrade are defaulted to being .png files named `UpradeClass`-Portrait and `UpradeClass`-Icon where `UpradeClass` is the name of your class that extends `ModUpgrade`.

If you want to change this, then you can override the `Portrait` / `Icon` properties.

The Mod Helper uses the same logic as the base game does for deciding that towers with two highest tier upgrades at the same tier should have portraits determined as Middle > Top > Bottom.

## Example

Here's a completed example of a `ModUpgrade` class from the Card Monkey mod

```cs
/* imports */

namespace CardMonkey.Upgrades.TopPath
{
    public class Pair : ModUpgrade<CardMonkey>
    {
        // public override string Portrait => "Don't need this, by default becomes Pair-Portrait.png";
        // public override string Icon => "Don't need this, by default becomes Pair-Icon.png";

        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 500;
        
        // public override string DisplayName => "Don't need this, by default becomes 'Pair'"
        
        public override string Description => "Throws two cards at a time";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = 
                new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);
        }
    }
}
```

***

# Tower Visuals

Just using the above steps, you can create a fully functioning Custom Tower. It's just gonna look exactly like the `BaseTower` we copied from :/

If you want to give your Tower a custom look, you have two different options, with a third in the works by us.

First, you can use the 2D Display Model system to just have your Tower rendered as an unanimated png. This is good if you don't want to dip your toes into the world of 3D Display Models even a little bit.

Second, you can create `ModTowerDisplay` classes that are copies of existing BTD 3D models and change their colors and properties.


## 2D Towers

The first thing you need to do is to add `public override bool Use2DModel => true;` to your `ModTower` class.

Then, you'll decide if you want to override the `Get2DTexture(int[] tiers)` method in your `ModTower` class.

`Get2DTexture` takes in an `int[3]` and returns the file name of a the correct texture to display for the tower (no directory path or .png).

By default, if you had a `ModTower` CardMonkey with tiers 2-3-0, it would try (in order): CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey.

If you want to provide different functionality for getting the png file name for your tower, then override this method and do so, otherwise just include as many .pngs as you want with appropriate names and the `ModTower` will use them.

## ModTowerDisplays

`ModTowerDisplays` are a special type of `ModDisplay` you can use that will automatically apply themselves to your Tower, so you don't have to deal with manually applying different displays in your `ModUpgrade` code.

Before you even start this, make sure you've read through [how to use normal ModDisplays](). Once you understand that, then this should be very straightforward.

Instead of extending `ModDisplay` with your class, extend `ModTowerDisplay<TowerClass>` where `TowerClass` is your class that extends `ModTower`.

When you do this, instead of it requiring you to override `ModifyDisplayNode(UnityDisplayNode node)`, it'll require you to override `UseForTower(int[] tiers)`.

`UseForTower` simply takes in an `int[3]` of the Tower's tiers and just returns `true` or `false` for if your Tower should use this Model at those given tiers.

`ModifyDisplayNode` is not required to be overridden, but that's just because it now has the default behavior of setting the Mesh Texture of the Node to be a .png file with the same name as the class. If you want to do something more/other than that, you'll still want to override this method.

## Example

Here's a completed example of a `ModTowerDisplay` class from the CardMonkey mod

```cs
/* imports */

namespace CardMonkey.Displays.Tier5
{
    public class TFDisplay : ModTowerDisplay<CardMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.BoomerangMonkey, 0, 0, 4);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[2] == 5;
        }

        public override float Scale => 1.2f;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            //node.SaveMeshTexture(); used this to get the texture to edit
            //node.PrintInfo(); used this to get the bone names and other info
            
            node.RemoveBone("SuperMonkeyRig:Dart");  // remove the boomerang from his hand
            
            // Name in this case is just 'TFDisplay' so it will find 'TFDiplay.png'
            SetMeshTexture(node, Name);
        }
    }
}
```

***

**Congratulations! You know have all the required information on the Mod Helper's role in making a fully featured Custom Tower. It's actual functionality will come down to how you edit the Models within the `ModifyBaseTower` and `ApplyUpgrade` methods, which means interacting with Ninja Kiwi's own systems. The Mod Helper's extension can make that easier**