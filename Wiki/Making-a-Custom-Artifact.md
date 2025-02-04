**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as
explained on this wiki.**

Adding custom Artifacts that appear in the Rogue Legends game mode is done via creating classes that extend from
`ModItemArtifact` for permanent in-game-affecting artifacts, `ModBoostArtifact` for temporary in-game-affecting
artifacts, or`ModMapArtifact` for permanent out-of-game-affecting artifacts.
All of these classes extend from `ModArtifact` and have the same core methods and properties that should be overriden.

## Notes

- Each custom ModArtifact class you define will be creating the Common, Rare, and Legendary version; no separate classes
  for each.
- For Item/Map Artifacts, users of your mod will have the artifacts automatically unlocked as starter options.
  - (They are not added to the unlock system to not leave any extraneous modded data in your profile)
- Unlike many other `ModContent` types, `ModArtifacts` do not have a base artifact that they copy from. This is because
  unlike Towers, Heroes, Bloons, etc, Artifacts tend to have only 1-2 behaviors to make them work rather than many
  required boilerplate ones.
- Tier 0 Common, 1 is Rare, 2 is Legendary, but there are also consts defined within `ModArtifact` so you can just write
  `Common` / `Rare` / `Legendary` for the values

## Common Overrides

`ModifyArtifactModel(ArtifactModel artifactModel)`: This method is required for overriding and serves as the place where
the artifact's in-game behavior will be defined.
Its `artifactModel` parameter will be either an `ItemArtifactModel` or `BoostArtifactModel`, and you should use Mod
Helper's standardized `AddBehavior` extension methods to add artifact behaviors.
The `artifactModel.tier` will be populated with either 0 for Common, 1 for Rare, or 2 for Legendary, so use that to give
the different tiers different effects/values.
To see how the vanilla artifacts work, use the Export Game Model button in Mod Helper's settings and view the Artifacts
folder.

`DisplayName`: Override this property to change the displayed name of your artifact. The Common, Rare and Legendary
suffix will be automatically added for the different tiers, so do not include any of those here.

`DescriptionCommon`/`DescriptionRare`/`DescriptionLegendary` or `Description(int tier)`: To give your artifact its
different descriptions, either override the 3 Description properties separately or override the one Description method
that has the tier as the parameter. As above, the tier number is 0 for Common, 1 for Rare, or 2 for Legendary.

`Icon`: Override this property to give an Icon to your artifact using either `VanillaSprites` or the name of an included
custom png (without extension). Artifact Icons are typically 256x256, but primarily utilize the center 150x150 area.
Defaults to your class name, so you don't need to override if your png file has the same name as your class file.

`RarityFrameType`: Override this property to change the frame this artifact frame has to a different tower set's theme.
Defaults to `TowerSet.AllMonkeyTowerSets`.

## Other Overrides

`MinTier`: If you want your Artifact to start at a higher tier and not have lower ones set this value to 1 for Rare or 2
for Legendary. Default behavior is starting at Common.

`MaxTier`: Similarly, if you don't want your artifact to go all the way to Legendary you can override this to
0 for Common or 1 for Rare. Default behavior is ending at Legendary.

`DisplayNameCommon`/`DisplayNameRare`/`DisplayNameLegendary`: If you don't want your artifact to follow the default
Common / Rare / Legendary naming convention that you can override these to change what the final Displayed Names will
be.

`IconCommon`/`IconRare`/`IconLegendary`: Individual overrides if you want to change the icon based on artifact rarity

## Examples

Example of an item artifact that buffs Dart Monkeys. Also showcases using the AddBoostBehavior extension method for
using boost behaviors on a non-Boost artifact (works internally using `InvokeBoostBuffBehaviorModel`).

```cs
public class DartMonkeyEnjoyer : ModItemArtifact
{
    public override string Icon => VanillaSprites.DartMonkeyIcon;

    public override int MinTier => Rare;

    public override string DescriptionRare => "Dart Monkeys do 25% more damage. All other towers do 5% less damage.";
    public override string DescriptionLegendary => "Dart Monkeys do 25% more damage.";

    public override void ModifyArtifactModel(ItemArtifactModel artifactModel)
    {
        artifactModel.AddBoostBehavior(new DamageBoostBehaviorModel("", 1.25f), boost =>
        {
            boost.towerTypes = new[] {TowerType.DartMonkey};
        });

        if (artifactModel.tier != Legendary)
        {
            artifactModel.AddBoostBehavior(new DamageBoostBehaviorModel("", 0.95f), boost =>
            {
                boost.towerTypes = new[] {TowerType.DartMonkey};
                boost.inverseTowerTypes = true;
            });
        }
    }
}
```

A different version that uses custom loading to create artifacts for all towers at once.

```cs
public class TowerEnjoyer : ModItemArtifact
{
    public static readonly string[] AllTowers =
    [
        TowerType.DartMonkey, TowerType.TackShooter, TowerType.GlueGunner, TowerType.IceMonkey, TowerType.BombShooter,
        TowerType.MonkeySub, TowerType.MonkeyBuccaneer, TowerType.SniperMonkey, TowerType.DartlingGunner, TowerType.MonkeyAce, TowerType.HeliPilot,
        TowerType.WizardMonkey, TowerType.NinjaMonkey, TowerType.SuperMonkey, TowerType.Druid, TowerType.Alchemist, TowerType.Mermonkey,
        TowerType.EngineerMonkey, TowerType.SpikeFactory
    ];

    public string TowerId { get; init; } = null!;

    /// <summary>
    /// Automatically load a separate class for every tower
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => AllTowers.Select(tower => new TowerEnjoyer {TowerId = tower});

    /// <summary>
    /// Unique internal name for each class
    /// </summary>
    public override string Name => TowerId + "Enjoyer";

    /// <summary>
    /// Utilize [bracket syntax] to get the localized names from their ids
    /// </summary>
    public override string DisplayName => $"[{TowerId}] Enjoyer";
    public override string Description(int tier) => $"[{TowerId}s] do {Damage(tier):P0} increased damage.";
    
    public override SpriteReference IconReference => Game.instance.model.GetTowerWithName(TowerId).icon;

    public static float Damage(int tier) => tier switch
    {
        Common => .1f,
        Rare => .15f,
        Legendary => .25f
    };

    public override void ModifyArtifactModel(ItemArtifactModel artifactModel)
    {
        artifactModel.AddBoostBehavior(new DamageBoostBehaviorModel("", 1 + Damage(artifactModel.tier)), boost =>
        {
            boost.towerTypes = new[] {TowerId};
        });
    }
}
```