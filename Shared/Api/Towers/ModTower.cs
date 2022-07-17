using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class for adding a custom Tower to the game. Use alongside <see cref="ModUpgrade"/> to define its upgrades,
/// and optionally <see cref="ModTowerDisplay"/> to define custom displays for it.
/// </summary>
public abstract partial class ModTower : NamedModContent
{
    /// <summary>
    /// ModTowers register third
    /// </summary>
    /// <exclude/>
    protected sealed override float RegistrationPriority => 3;

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 1;

    internal virtual string[] DefaultMods =>
        new[] {"GlobalAbilityCooldowns", "MonkeyEducation", "BetterSellDeals", "VeteranMonkeyTraining"};

    internal List<TowerModel> towerModels;
    internal readonly int[] tierMaxes;
    internal readonly List<ModTowerDisplay> displays = new();
    internal virtual ModTowerSet ModTowerSet => null;
    internal virtual int UpgradePaths => 3;

    /// <summary>
    /// The Portrait for the 0-0-0 tower, by default "[Name]-Portrait"
    /// <br/>
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string Portrait => GetType().Name + "-Portrait";

    /// <summary>
    /// The Icon for the Tower's purchase button, by default "[Name]-Icon"
    /// <br/>
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string Icon => GetType().Name + "-Icon";

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReference(Icon);

    /// <summary>
    /// If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference PortraitReference => GetSpriteReference(Portrait);

    /// <summary>
    /// Whether this Tower should display 2-dimensionally, and search for png images
    /// <br/>
    /// <seealso cref="PixelsPerUnit"/>
    /// <seealso cref="Get2DTexture"/>
    /// </summary>
    public virtual bool Use2DModel => false;

    /// <summary>
    /// For 2D towers, the ratio between pixels and display units. Higher number -> smaller tower.
    /// <seealso cref="Use2DModel"/>
    /// <seealso cref="Get2DTexture"/>
    /// </summary>
    public virtual float PixelsPerUnit => 10f;

    /// <summary>
    /// Makes this Tower not actually add itself to the shop, useful for making subtowers
    /// </summary>
    public virtual bool DontAddToShop => false;

    /// <summary>
    /// The string to use for the Primary tower set
    /// </summary>
    protected const string PRIMARY = "Primary";

    /// <summary>
    /// The string to use for the Magic tower set
    /// </summary>
    protected const string MAGIC = "Magic";

    /// <summary>
    /// The string to use for the Military tower set
    /// </summary>
    protected const string MILITARY = "Military";

    /// <summary>
    /// The string to use for the Support tower set
    /// </summary>
    protected const string SUPPORT = "Support";

    /// <summary>
    /// The family of Monkeys that your Tower should be put in.
    /// <br/>
    /// For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.
    /// </summary>
    public abstract string TowerSet { get; }

    /// <summary>
    /// The id of the default BTD Tower that your Tower is going to be copied from by default.
    /// </summary>
    public abstract string BaseTower { get; }

    /// <summary>
    /// The in game cost of this tower (on Medium difficulty)
    /// </summary>
    public abstract int Cost { get; }

    /// <summary>
    /// The number of upgrades the tower has in it's 1st / top path
    /// </summary>
    public abstract int TopPathUpgrades { get; }

    /// <summary>
    /// The number of upgrades the tower has in it's 2nd / middle path
    /// </summary>
    public abstract int MiddlePathUpgrades { get; }

    /// <summary>
    /// The number of upgrades the tower has in it's 3rd / bottom path
    /// </summary>
    public abstract int BottomPathUpgrades { get; }

    /// <summary>
    /// Whether to always make this tower be included in challenges / Bosses / Odysseys etc
    /// </summary>
    public virtual bool AlwaysIncludeInChallenge => true;


    /// <summary>
    /// Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades
    /// <br/>
    /// Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point
    /// </summary>
    /// <param name="towerModel">The Base Tower Model</param>
    public abstract void ModifyBaseTowerModel(TowerModel towerModel);


    internal virtual string TowerId(int[] tiers)
    {
        var id = Id;
        if (tiers.Sum() > 0)
        {
            id += "-" + tiers.Printed();
        }

        return id;
    }

    /// <summary>
    /// Returns all the valid tiers for the TowerModels of this Tower
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<int[]> TowerTiers()
    {
        var results = new List<int[]>();
        for (var i = 0; i <= TopPathUpgrades; i++)
        {
            for (var j = 0; j <= MiddlePathUpgrades; j++)
            {
                for (var k = 0; k <= BottomPathUpgrades; k++)
                {
                    var tiers = new[] {i, j, k};
                    var sorted = tiers.OrderBy(num => -num).ToArray();
                    if (sorted[0] <= 5 && sorted[1] <= 2 && sorted[2] == 0)
                    {
                        results.Add(tiers);
                    }
                }
            }
        }

        return results;
    }

    /// <summary>
    /// If this is a 2D tower, gets the name of the .png to use for a given set of tiers
    /// <br/>
    /// Default Behavior Example: For CardMonkey with tiers 2-3-0, it would try (in order):
    /// CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey
    /// </summary>
    /// <param name="tiers"></param>
    /// <returns></returns>
    public virtual string Get2DTexture(int[] tiers)
    {
        var name = $"{Name}-{tiers.Printed()}";
        if (TextureExists(name))
        {
            return name;
        }

        foreach (var i in tiers.Order())
        {
            if (tiers[i] == 0)
            {
                break;
            }

            var printed = tiers.Printed().ToCharArray();
            for (var j = 0; j < 3; j++)
            {
                if (i != j)
                {
                    printed[j] = 'X';
                }
            }

            name = $"{Name}-{printed}";
            if (TextureExists(name))
            {
                return name;
            }
        }

        return Name;
    }

    /// <summary>
    /// Gets the portrait reference this tower should use for the given tiers
    /// <br/>
    /// Looks for the highest tier <see cref="ModUpgrade"/> this tower has that defined a <see cref="ModUpgrade.PortraitReference"/>,
    /// falling back to the tower's own base <see cref="PortraitReference"/> by default.
    /// </summary>
    /// <param name="tiers"></param>
    public SpriteReference GetPortraitReferenceForTiers(int[] tiers) => upgrades.Cast<ModUpgrade>()
        .Where(modUpgrade => modUpgrade != null &&
                             tiers[modUpgrade.Path] >= modUpgrade.Tier &&
                             modUpgrade.PortraitReference is not null)
        .OrderByDescending(modUpgrade => modUpgrade.Tier)
        .ThenByDescending(modUpgrade => modUpgrade.Path % 2)
        .ThenBy(modUpgrade => modUpgrade.Path)
        .Select(upgrade => upgrade.PortraitReference)
        .DefaultIfEmpty(PortraitReference)
        .First();
}