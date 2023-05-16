﻿using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
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
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <summary>
    /// If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference PortraitReference => GetSpriteReferenceOrDefault(Portrait);

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
    [Obsolete("Use Get2DScale")]
    public virtual float PixelsPerUnit => 10f;

    /// <summary>
    /// Makes this Tower not actually add itself to the shop, useful for making subtowers
    /// </summary>
    public virtual bool DontAddToShop => false;

    /// <summary>
    /// The string to use for the Primary tower set
    /// </summary>
    [Obsolete("Use TowerSetType.Primary")]
    protected const string PRIMARY = "Primary";

    /// <summary>
    /// The string to use for the Magic tower set
    /// </summary>
    [Obsolete("Use TowerSetType.Magic")]
    protected const string MAGIC = "Magic";

    /// <summary>
    /// The string to use for the Military tower set
    /// </summary>
    [Obsolete("Use TowerSetType.Military")]
    protected const string MILITARY = "Military";

    /// <summary>
    /// The string to use for the Support tower set
    /// </summary>
    [Obsolete("Use TowerSetType.Support")]
    protected const string SUPPORT = "Support";

    /// <summary>
    /// The family of Monkeys that your Tower should be put in.
    /// <br/>
    /// For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.
    /// </summary>
    public abstract TowerSet TowerSet { get; }

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
    /// How many of this tower you can buy at once during a game. By default -1 for no limit.
    /// </summary>
    public virtual int ShopTowerCount => -1;

    /// <summary>
    /// Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades
    /// <br/>
    /// Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point
    /// </summary>
    /// <param name="towerModel">The Base Tower Model</param>
    public abstract void ModifyBaseTowerModel(TowerModel towerModel);

    /// <summary>
    /// Further modifies this tower when you go into a new match.
    /// Useful for making conditional effects happen based on settings.
    /// <br/>
    /// The normal ApplyUpgrade effects for all upgrades will have already been applied on game start,
    /// so this will simply modify all the TowerModels for this ModTower.
    /// </summary>
    /// <param name="towerModel">The Base Tower Model</param>
    /// <param name="gameModes">What GameModes are active for the match</param>
    public virtual void ModifyTowerModelForMatch(TowerModel towerModel, IReadOnlyList<ModModel> gameModes)
    {
    }

    internal List<ModUpgrade> GetUpgradesForTiers(int[] tiers) => Upgrades.Cast<ModUpgrade>()
        .Where(modUpgrade =>
            modUpgrade != null && tiers[modUpgrade.Path] >= modUpgrade.Tier)
        .OrderByDescending(modUpgrade => modUpgrade.Priority)
        .ThenBy(modUpgrade => modUpgrade.Tier)
        .ThenBy(modUpgrade => modUpgrade.Path)
        .ToList();

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
        for (var i = 0; i <= TopPathUpgrades; i++)
        {
            for (var j = 0; j <= MiddlePathUpgrades; j++)
            {
                for (var k = 0; k <= BottomPathUpgrades; k++)
                {
                    var tiers = new[] {i, j, k};
                    if (IsValidCrosspath(tiers))
                    {
                        yield return tiers;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Another way to modify the allowable crosspaths for your tower. By default, checks that the highest tier is at
    /// most 5, the next highest is at most 2, and the last one is 0
    /// <br/>
    /// Used in the default implementation of <see cref="TowerTiers"/>
    /// </summary>
    public virtual bool IsValidCrosspath(int[] tiers)
    {
        var sorted = tiers.OrderByDescending(num => num).ToArray();
        return sorted[0] <= 5 && sorted[1] <= 2 && sorted[2] == 0;
    }

    /// <summary>
    /// If this is a 2D tower, gets the name of the .png to use for a given set of tiers
    /// <br/>
    /// Default Behavior Example: For CardMonkey with tiers 2-3-0, it would try (in order):
    /// CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey
    /// <seealso cref="Use2DModel"/>
    /// <see cref="Get2DScale"/>
    /// </summary>
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
    /// Gets the scale to use for a 2d tower at the given tiers
    /// <seealso cref="Use2DModel"/>
    /// <seealso cref="Get2DTexture"/>
    /// </summary>
    public virtual float Get2DScale(int[] tiers) => 1f;

    /// <summary>
    /// Gets the portrait reference this tower should use for the given tiers
    /// <br/>
    /// Looks for the highest tier <see cref="ModUpgrade"/> this tower has that defined a <see cref="ModUpgrade.PortraitReference"/>,
    /// falling back to the tower's own base <see cref="PortraitReference"/> by default.
    /// </summary>
    /// <param name="tiers"></param>
    public SpriteReference GetPortraitReferenceForTiers(int[] tiers) => Upgrades.Cast<ModUpgrade>()
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