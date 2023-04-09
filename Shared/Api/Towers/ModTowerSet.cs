using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// A custom collection of ModTowers
/// </summary>
public abstract partial class ModTowerSet : NamedModContent
{
    internal static readonly Dictionary<string, ModTowerSet> Cache = new();
    internal static int NextTowerSet { get; private set; } = 2 * (int) Enum.GetValues<TowerSet>().Last();

    /// <summary>
    /// Internal int enum value used for this ModdedTowerSet
    /// </summary>
    public int TowerSetInt { get; private set; }

    /// <summary>
    /// TowerSet enum for this modded TowerSet
    /// </summary>
    public TowerSet Set => (TowerSet) TowerSetInt;

    /// <summary>
    /// ModTowerSets register before ModTowers, alongside ModUpgrades
    /// </summary>
    /// <exclude/>
    protected sealed override float RegistrationPriority => 2;

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
        TowerSetInt = NextTowerSet;
        NextTowerSet *= 2;
    }
        
    /// <summary>
    /// Unused
    /// </summary>
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <summary>
    /// Unused
    /// </summary>
    public sealed override string Description => base.Description;

    internal readonly List<ModTower> towers = new();

    /// <summary>
    /// Name of .png file for the background for towers in the Monkeys menu and the in game shop
    /// </summary>
    public virtual string Container => GetType().Name + "-Container";

    /// <summary>
    /// SpriteReference for the container
    /// </summary>
    public virtual SpriteReference ContainerReference => GetSpriteReferenceOrDefault(Container);

    /// <summary>
    /// Name of .png file for the background used for non-paragon upgrades in the Upgrade screen
    /// </summary>
    public virtual string ContainerLarge => GetType().Name + "-ContainerLarge";

    /// <summary>
    /// SpriteReference for the large container
    /// </summary>
    public virtual SpriteReference ContainerLargeReference => GetSpriteReferenceOrDefault(ContainerLarge);

    /// <summary>
    /// Name of .png file for the group button used in the Monkeys menu
    /// </summary>
    public virtual string Button => GetType().Name + "-Button";

    /// <summary>
    /// SpriteReference for the button
    /// </summary>
    public virtual SpriteReference ButtonReference => GetSpriteReference(Button);

    /// <summary>
    /// Name of .png file for the background for in game portraits
    /// </summary>
    public virtual string Portrait => GetType().Name + "-Portrait";

    /// <summary>
    /// SpriteReference for the portrait
    /// </summary>
    [Obsolete("Only the Portrait property used")]
    public virtual SpriteReference PortraitReference => GetSpriteReference(Portrait);

    /*public virtual string Icon => GetType().Name + "-Icon";
    This is in the game for each tower set, but haven't seen a place where it'd need to be used for custom ones
    public virtual SpriteReference IconReference => GetSpriteReference(Icon);*/

    /// <summary>
    /// Where to place this ModTowerSet in relation to other towerSets. By default at the end.
    /// <br/>
    /// </summary>
    /// <param name="towerSets">The current towerSets that already exist</param>
    /// <returns></returns>
    public virtual int GetTowerSetIndex(List<TowerSet> towerSets)
    {
        return towerSets.Count;
    }

    /// <summary>
    /// Whether this Tower Set should still be allowed to appear in Primary Only, Military Only, Magic Only
    /// </summary>
    public virtual bool AllowInRestrictedModes => false;

    /// <summary>
    /// No loading multiple instances of a ModTowerSet
    /// </summary>
    /// <returns></returns>
    public sealed override IEnumerable<ModContent> Load()
    {
        return base.Load();
    }
}