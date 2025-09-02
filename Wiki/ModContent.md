## Overview
The `ModContent` class was added by the Mod Helper to manage the different custom elements of people's mods that the helper loads, like `ModTower`, `ModUpgrade`, `ModDisplay`, etc.

All the different `ModContent` classes that you put in your mod will be automatically handled by the Mod Helper, which included being given a unique internal ID so that you don't have to worry about overlap with other mods.

Because of this, the `ModContent` class comes with many static methods that you can use to access the different loaded elements.

## Helpful Methods

`ModContent.GetInstance<T>()` gets the primary instance of the type `T`, which is either a `ModContent` or a `BloonsMod`. For those new to C# this might seem a little odd, but the gist of why we do this is because we want to let people use Method and Property overrides while still having the classes behave pretty much statically. 

`ModContent.TowerID<T>()` and `ModContent.UpgradeID<T>()` get the internal IDs given to a `ModTower` or `ModUpgrade` by the Mod Helper.

`ModContent.GetTextureGUID<T>(string name)`, `ModContent.GetSpriteReference<T>(string name)`, `ModContent.GetTexture<T>(string name)`, `ModContent.GetSprite<T>(string name)` all help get your custom texture(s) in various formats you might want them in. You can read more about that [here](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Custom-Textures-and-Displays).

Also note that since all the classes like `ModTower` are subclasses of `ModContent`, you can use all the above methods without putting `ModContent.` at the start with those classes.

## Loading Multiple Versions of a Single ModContent

Note: this is an advanced feature that many people may never need to use.

Sometimes you might want to make many different versions of a very similar bit of `ModContent`. Instead of having to manually make a bunch of files, you can override the `Load()` method in your ModContent. This is probably best illustrated with an example:

```cs
 public class CardMonkeyBaseDisplay : ModTowerDisplay<CardMonkey>
 {
     private readonly int[] t;  // the tiers for a specific display
     
     /// <summary>
     /// All classes that derive from ModContent MUST still have a zero argument constructor to work
     /// </summary>
     public CardMonkeyBaseDisplay()
     {
         
     }

     public CardMonkeyBaseDisplay(int[] tiers)
     {
         t = tiers;
     }

     /// <summary>
     /// This is an example of loading multiple instances of the same ModDisplay with different values
     /// </summary>
     /// <returns></returns>
     public override IEnumerable<ModContent> Load()
     {
         for (var i = 0; i <= 2; i++)
         {
             for (var j = 0; j <= 2; j++)
             {
                 for (var k = 0; k <= 2; k++)
                 {
                     var tiers = new[] {i, j, k};
                     if (tiers.IsValid())
                     {
                         yield return new CardMonkeyBaseDisplay(tiers);
                     }
                 }
             }
         }
     }
     
     /* Using the t value for various overrides */
}
```

Now the Mod Helper will create a `CardMonkeyBaseDisplay` for all valid tier 2 or lower crosspaths.

Note that if you do this, you'll then have to use `ModContent.GetInstances<T>()` for getting ALL instances of your `ModContent` and not just the first one.