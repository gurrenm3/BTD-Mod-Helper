**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

Creating custom Bloons comes in the form of creating classes that extend `ModBloon`.

If you want to add a `ModBloon` to the game in a natural way, consider [Making a Custom Round Set](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Round-Set) / [Making a Custom Game Mode](https://github.com/gurrenm3/BTD-Mod-Helper/wiki/Making-a-Custom-Game-Mode).

# [ModBloon](/docs/BTD_Mod_Helper.Api.Bloons.ModBloon)

## Required Properties

`BaseBloon`: Akin to ModTower's `BaseTower`, this is the Id of the vanilla Bloon that you want to use as a base for this Bloon. use the Mod Helper provided `BloonType` class for an exact string.

## Optional Properties

`Camo`, `Fortified` and `Regrow`: Makes the particular Bloon generate as having that particular property.

`KeepBaseId`: If you're making a custom Bloon that's supposed to be an extension of a vanilla Bloon, like a Fortified Red Bloon, then set this to true to make sure your Bloon still counts as a vanilla Red Bloon.

`UseIconAsDisplay`: Whether your Bloon's icon should just be it's display instead of having a separate (potentially 3D) ModDisplay. This will default to true if you make a MOAB class bloon.

`DamageStates`: An array of display ids for your Bloon to have as it gets damaged. This is in order from least damaged to most damaged, and it will automatically evenly space the displays out between 100% and 0% health.

## Visuals

You should provide a [Name]-Icon png/jpg for your Bloons icon in menus / the non-MOAB Bloon itself.

There's also the [ModBloonDisplay](/docs/BTD_Mod_Helper.Api.Display.ModBloonDisplay) class you can use to more easily manage your MOAB class displays. Set `T` to be your `ModBloon` class, then set the `Damage` property to be the index that the display should be in `DamageStates`, so 0 = undamaged, increasing from that being more and more damaged.

## Variations

You might want to have different variations of your Bloon that are Fortified/Regrow/Camo etc. To do that, you can use the `ModBloon<T>` class setting `T` as your `ModBloon` to use it as your `BaseBloon` and modify it from there. You can then make use of the helper extensions `BloonModel.MakeChildrenFortified`, `BloonModel.MakeChildrenRegrow` and `BloonModel.MakeChildrenCamo` to easily change all the children. (Note: this doesn't create Bloons that don't already exist like Fortified Reds, just changes children like Ceramics into Fortified Ceramics because those actually exist)

## Examples

The RGB Bloon, a non-MOAB class Bloon that turns into a Red, Blue and Green Bloon

```cs
public class Rgb : ModBloon
{
    public override string BaseBloon => BloonType.Yellow;
        
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.AddToChildren(BloonType.Blue);
        bloonModel.AddToChildren(BloonType.Red);

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}

public class RgbRegrow : ModBloon<Rgb>
{
    public override bool Regrow => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenRegrow();
    }
}

public class RgbCamo : ModBloon<Rgb>
{
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenCamo();
    }
}
    
public class RgbRegrowCamo : ModBloon<Rgb>
{
    public override bool Regrow => true;
    public override bool Camo => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenRegrow();
        bloonModel.MakeChildrenCamo();
    }
}
```

The ROFL, a MOAB class Bloon model that's an upgrade to the BAD and summons one of every base Bloon as children. Also its ModBloonDisplay, showcasing some advanced programmatic loading in action.

```cs
/// <summary>
/// Round Omnipotent Flying Leviathan
/// </summary>
public class Rofl : ModBloon
{
    public override string BaseBloon => BloonType.Bad;
        
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.maxHealth = bloonModel.leakDamage = 50000;
        bloonModel.danger++;
        bloonModel.layerNumber++;
            
        bloonModel.RemoveAllChildren();
            
        bloonModel.AddToChildren(BloonType.Red);
        bloonModel.AddToChildren(BloonType.Blue);
        bloonModel.AddToChildren(BloonType.Green);
        bloonModel.AddToChildren<Rgb>();
        bloonModel.AddToChildren(BloonType.Yellow);
        bloonModel.AddToChildren(BloonType.Pink);
        bloonModel.AddToChildren(BloonType.Purple);
        bloonModel.AddToChildren(BloonType.Lead);
        bloonModel.AddToChildren(BloonType.Black);
        bloonModel.AddToChildren(BloonType.White);
        bloonModel.AddToChildren(BloonType.Zebra);
        bloonModel.AddToChildren(BloonType.Rainbow);
        bloonModel.AddToChildren(BloonType.Ceramic);
        bloonModel.AddToChildren(BloonType.Moab);
        bloonModel.AddToChildren(BloonType.Bfb);
        bloonModel.AddToChildren(BloonType.DdtCamo);
        bloonModel.AddToChildren(BloonType.Zomg);
        bloonModel.AddToChildren(BloonType.Bad);
    }
}
    
public class RoflFortified : ModBloon<Rofl>
{
    public override bool Fortified => true;

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.maxHealth = bloonModel.leakDamage = 100000;
            
        bloonModel.MakeChildrenFortified();
    }
}

public class RoflDisplay : ModBloonDisplay<Rofl>
{
    public override string BaseDisplay => GetBloonDisplay(BloonType.Bad, Damage);

    public override string Name => base.Name + Damage;

    /// <summary>
    /// Still need an empty constructor for the type to be loaded
    /// </summary>
    public RoflDisplay()
    {
    }

    public override int Damage { get; }
        
    public RoflDisplay(int damage)
    {
        Damage = damage;
    }
    
    public override IEnumerable<ModContent> Load()
    {
        for (var damage = 0; damage < 5; damage++)
        {
            yield return new RoflDisplay(damage);
        }
    }

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        foreach (var meshRenderer in node.GetMeshRenderers())
        {
            meshRenderer.SetMainTexture(GetTexture(Name)!);
        }
    }
}

```
