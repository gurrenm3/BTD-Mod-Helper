using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// A custom collection of ModTowers
/// </summary>
public abstract class ModTowerSet : NamedModContent
{
    internal static readonly Dictionary<string, ModTowerSet> Cache = new();

    internal readonly List<ModTower> towers = new();
    internal static int NextTowerSet { get; private set; } = 2 * (int) Enum.GetValues<TowerSet>()[^1];

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
    /// <exclude />
    protected sealed override float RegistrationPriority => 2;

    /// <summary>
    /// Unused
    /// </summary>
    public sealed override string DisplayNamePlural => base.DisplayNamePlural;

    /// <summary>
    /// Unused
    /// </summary>
    public sealed override string Description => base.Description;

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

    /// <summary>
    /// Name of .png file for the seat to use in Odyssey mode (theoretically)
    /// </summary>
    public virtual string Seat => GetType().Name + "-Seat";

    /// <summary>
    /// SpriteReference for the Seat
    /// </summary>
    public virtual SpriteReference SeatReference =>
        GetSpriteReferenceOrNull(Seat) ?? CreateSpriteReference(VanillaSprites.TowerSeatEmpty);

    /// <summary>
    /// Whether this Tower Set should still be allowed to appear in Primary Only, Military Only, Magic Only
    /// </summary>
    public virtual bool AllowInRestrictedModes => false;

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
        TowerSetInt = NextTowerSet;
        NextTowerSet *= 2;
    }

    /*public virtual string Icon => GetType().Name + "-Icon";
    This is in the game for each tower set, but haven't seen a place where it'd need to be used for custom ones
    public virtual SpriteReference IconReference => GetSpriteReference(Icon);*/

    /// <summary>
    /// Where to place this ModTowerSet in relation to other towerSets. By default at the end.
    /// <br />
    /// </summary>
    /// <param name="towerSets">The current towerSets that already exist</param>
    /// <returns></returns>
    public virtual int GetTowerSetIndex(List<TowerSet> towerSets) => towerSets.Count;

    /// <summary>
    /// No loading multiple instances of a ModTowerSet
    /// </summary>
    /// <returns></returns>
    public sealed override IEnumerable<ModContent> Load() => base.Load();

    /// <summary>
    /// The position to start placing ModTowers of this ModTowerSet in relation to other towers
    /// <br />
    /// By default, will determine the position based on GetTowerSetIndex
    /// <br />
    /// </summary>
    /// <param name="towerSet">The set of all current tower details</param>
    /// <returns></returns>
    public virtual int GetTowerStartIndex(List<TowerDetailsModel> towerSet)
    {
        var towerSets = towerSet.Select(model => model.GetTower().towerSet);

        // Group the towers into chunks of the same tower set
        var towerSetChunks = new List<Tuple<TowerSet, int>>();
        foreach (var set in towerSets)
        {
            if (towerSetChunks.LastOrDefault() is Tuple<TowerSet, int> last && last.Item1 == set)
            {
                towerSetChunks[^1] = new Tuple<TowerSet, int>(set, last.Item2 + 1);
            }
            else
            {
                towerSetChunks.Add(new Tuple<TowerSet, int>(set, 1));
            }
        }

        // Get the tower set index in relation to the chunks
        var start = GetTowerSetIndex(towerSetChunks.Select(tuple => tuple.Item1).ToList());

        return towerSetChunks.Take(start).Sum(tuple => tuple.Item2);
    }
}