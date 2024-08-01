using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class for adding a custom Tower to the game. Use alongside <see cref="ModUpgrade" /> to define its upgrades,
/// and optionally <see cref="ModTowerDisplay" /> to define custom displays for it.
/// </summary>
public abstract class ModTower : NamedModContent
{

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
    internal readonly List<ModTowerDisplay> displays = new();
    internal UpgradeModel dummyUpgrade;
    internal ModParagonUpgrade paragonUpgrade;

    internal List<TowerModel> towerModels;

    /// <summary>
    /// Constructor for ModTower, used implicitly by ModContent.Create
    /// </summary>
    /// <exclude />
    protected ModTower()
    {
    }

    /// <summary>
    /// ModTowers register third
    /// </summary>
    /// <exclude />
    protected sealed override float RegistrationPriority => 3;

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 1;

    internal virtual string[] DefaultMods =>
        new[] {"GlobalAbilityCooldowns", "MonkeyEducation", "BetterSellDeals", "VeteranMonkeyTraining"};

    internal virtual ModTowerSet ModTowerSet => null;
    internal virtual int UpgradePaths => 3;
    internal virtual int StartTier => 0;

    /// <summary>
    /// The Portrait for the 0-0-0 tower, by default "[Name]-Portrait"
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string Portrait => GetType().Name + "-Portrait";

    /// <summary>
    /// The Icon for the Tower's purchase button, by default "[Name]-Icon"
    /// <br />
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
    /// <br />
    /// <seealso cref="PixelsPerUnit" />
    /// <seealso cref="Get2DTexture" />
    /// </summary>
    public virtual bool Use2DModel => false;

    /// <summary>
    /// For 2D towers, the ratio between pixels and display units. Higher number -> smaller tower.
    /// <seealso cref="Use2DModel" />
    /// <seealso cref="Get2DTexture" />
    /// </summary>
    [Obsolete("Use Get2DScale")]
    public virtual float PixelsPerUnit => 10f;

    /// <summary>
    /// Makes this Tower not actually add itself to the shop, useful for making subtowers
    /// </summary>
    public virtual bool DontAddToShop => false;

    /// <summary>
    /// The family of Monkeys that your Tower should be put in.
    /// <br />
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
    public virtual int TopPathUpgrades => Upgrades[0].Count;

    /// <summary>
    /// The number of upgrades the tower has in it's 2nd / middle path
    /// </summary>
    public virtual int MiddlePathUpgrades => Upgrades[1].Count;

    /// <summary>
    /// The number of upgrades the tower has in it's 3rd / bottom path
    /// </summary>
    public virtual int BottomPathUpgrades => Upgrades[2].Count;

    /// <summary>
    /// Whether to always make this tower be included in challenges / Bosses / Odysseys etc
    /// </summary>
    public virtual bool AlwaysIncludeInChallenge => true;

    /// <summary>
    /// How many of this tower you can buy at once during a game. By default -1 for no limit.
    /// </summary>
    public virtual int ShopTowerCount => -1;

    /// <summary>
    /// Defines whether / how this ModTower has a Paragon
    /// </summary>
    public virtual ParagonMode ParagonMode => ParagonMode.None;

    /// <summary>
    /// Hotkey to use for placing this tower from the shop
    /// </summary>
    public virtual ModSettingHotkey Hotkey => null;

    internal TowerModel BaseTowerModel => Game.instance.model.GetTowerFromId(BaseTower);

    internal virtual bool ShouldCreateParagon =>
        paragonUpgrade != null &&
        TopPathUpgrades == 5 &&
        MiddlePathUpgrades == 5 &&
        BottomPathUpgrades == 5 &&
        ParagonMode != ParagonMode.None;

    internal readonly SortedDictionary<int, ModUpgrade>[] Upgrades = {new(), new(), new()};
    internal IEnumerable<ModUpgrade> AllUpgrades => Upgrades.SelectMany(upgrades => upgrades.Values);
    internal int[] TierMaxes => [TopPathUpgrades, MiddlePathUpgrades, BottomPathUpgrades];

    /// <summary>
    /// Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades
    /// <br />
    /// Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point
    /// </summary>
    /// <param name="towerModel">The Base Tower Model</param>
    public abstract void ModifyBaseTowerModel(TowerModel towerModel);

    /// <summary>
    /// Further modifies this tower when you go into a new match.
    /// Useful for making conditional effects happen based on settings.
    /// <br />
    /// The normal ApplyUpgrade effects for all upgrades will have already been applied on game start,
    /// so this will simply modify all the TowerModels for this ModTower.
    /// </summary>
    public virtual void ModifyTowerModelForMatch(TowerModel towerModel, IReadOnlyList<ModModel> gameModes)
    {
    }

    /// <inheritdoc cref="ModifyTowerModelForMatch(Il2CppAssets.Scripts.Models.Towers.TowerModel,System.Collections.Generic.IReadOnlyList{Il2CppAssets.Scripts.Models.ModModel})" />
    public virtual void ModifyTowerModelForMatch(TowerModel towerModel, GameModel gameModel)
    {
    }

    internal List<ModUpgrade> GetUpgradesForTiers(params int[] tiers) => AllUpgrades
        .Where(modUpgrade => tiers[modUpgrade.Path] >= modUpgrade.Tier)
        .OrderByDescending(modUpgrade => modUpgrade.Priority)
        .ThenBy(modUpgrade => modUpgrade.Tier)
        .ThenBy(modUpgrade => modUpgrade.Path)
        .ToList();

    internal virtual string TowerId(params int[] tiers)
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
    /// <br />
    /// Used in the default implementation of <see cref="TowerTiers()" />
    /// </summary>
    public virtual bool IsValidCrosspath(params int[] tiers)
    {
        var sorted = tiers.OrderByDescending(num => num).ToArray();
        return sorted[0] <= 5 && sorted[1] <= 2 && sorted[2] == 0;
    }

    /// <summary>
    /// If this is a 2D tower, gets the name of the .png to use for a given set of tiers
    /// <br />
    /// Default Behavior Example: For CardMonkey with tiers 2-3-0, it would try (in order):
    /// CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey
    /// <seealso cref="Use2DModel" />
    /// <see cref="Get2DScale" />
    /// </summary>
    public virtual string Get2DTexture(params int[] tiers)
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
    /// <seealso cref="Use2DModel" />
    /// <seealso cref="Get2DTexture(int[])" />
    /// </summary>
    public virtual float Get2DScale(params int[] tiers) => 1f;

    /// <summary>
    /// Gets the portrait reference this tower should use for the given tiers
    /// <br />
    /// Looks for the highest tier <see cref="ModUpgrade" /> this tower has that defined a
    /// <see cref="ModUpgrade.PortraitReference" />,
    /// falling back to the tower's own base <see cref="PortraitReference" /> by default.
    /// </summary>
    /// <param name="tiers"></param>
    public SpriteReference GetPortraitReferenceForTiers(params int[] tiers) => AllUpgrades
        .Where(modUpgrade => tiers[modUpgrade.Path] >= modUpgrade.Tier && modUpgrade.PortraitReference is not null)
        .OrderByDescending(modUpgrade => modUpgrade.Tier)
        .ThenByDescending(modUpgrade => modUpgrade.Path % 2)
        .ThenBy(modUpgrade => modUpgrade.Path)
        .Select(upgrade => upgrade.PortraitReference)
        .DefaultIfEmpty(PortraitReference)
        .First();

    /// <inheritdoc />
    public override void Register()
    {
        for (var path = ModUpgrade.Top; path <= ModUpgrade.Bottom; path++)
        {
            var highest = Upgrades[path].Values.Select(upgrade => upgrade.Tier).DefaultIfEmpty(0).Max();
            for (var tier = StartTier; tier < highest; tier++)
            {
                if (!Upgrades[path].ContainsKey(tier))
                {
                    throw new Exception($"Tower {Id} is missing upgrade for tier {tier + 1}");
                }
            }
        }

        towerModels = ModTowerHelper.AddTower(this);

        foreach (var towerModel in towerModels)
        {
            ModTowerHelper.FinalizeTowerModel(this, towerModel);
        }

        if (!DontAddToShop)
        {
            var index = GetTowerIndex(Game.instance.model.towerSet.ToList());
            if (index >= 0)
            {
                var shopTowerDetailsModel = new ShopTowerDetailsModel(Id, index, 5, 5, 5, ShopTowerCount);
                Game.instance.model.AddTowerDetails(shopTowerDetailsModel, index);
            }
        }

        ModTowerSet?.towers.Add(this);
    }

    /// <summary>
    /// Gets the base TowerModel for this Tower to use at the given tiers
    /// </summary>
    /// <returns>The 0-0-0 TowerModel for this Tower</returns>
    internal virtual TowerModel GetDefaultTowerModel(int[] tiers = null)
    {
        tiers ??= new[] {0, 0, 0};
        var towerModel = GetBaseTowerModel(tiers);
        towerModel.name = Id;

        towerModel.appliedUpgrades = new Il2CppStringArray(0);
        towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
        towerModel.towerSet = TowerSet;
        towerModel.cost = Cost;
        towerModel.dontDisplayUpgrades = false;
        towerModel.powerName = null;

        towerModel.tier = tiers.Max();
        towerModel.tiers = tiers;

        towerModel.mods = DefaultMods
            .Select(s => new ApplyModModel($"{Id}Upgrades", s, ""))
            .ToArray();

        towerModel.GetDescendants<Model>().ForEach(model =>
        {
            model.name = model.name.Replace(BaseTower, Name);
            model._name = model._name.Replace(BaseTower, Name);
        });

        towerModel.instaIcon = IconReference;
        towerModel.portrait = PortraitReference;
        towerModel.icon = IconReference;

        return towerModel;
    }

    /// <summary>
    /// When adding this tower to the shop, gets the index at which to add the tower relative to the existing ones.
    /// <br />
    /// By default, the tower will be put at the end of the TowerSet category that it's in.
    /// </summary>
    /// <param name="towerSet"></param>
    /// <returns></returns>
    public virtual int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        if (towerSet.LastOrDefault(details => details.GetTower().towerSet == TowerSet) is { } tower)
        {
            return tower.towerIndex + 1;
        }

        return ModTowerSet?.GetTowerStartIndex(towerSet) ?? towerSet.Count;
    }

    internal virtual TowerModel GetBaseParagonModel()
    {
        TowerModel towerModel;
        switch (ParagonMode)
        {
            case ParagonMode.Base000:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] {0, 0, 0});
                break;
            case ParagonMode.Base555:
                towerModel = ModTowerHelper.CreateTowerModel(this, new[] {5, 5, 5});
                break;
            case ParagonMode.None:
            default:
                return null;
        }

        towerModel.appliedUpgrades = new Il2CppStringArray(6);
        for (var i = 0; i < 5; i++)
        {
            towerModel.appliedUpgrades[i] = Upgrades[0][i].Id;
        }

        return towerModel;
    }


    /// <summary>
    /// Creates an UpgradePathModel for a particular upgrade and new tiers
    /// </summary>
    /// <param name="modUpgrade">The upgrade</param>
    /// <param name="newTiers">The new desired tiers of the tower</param>
    /// <returns></returns>
    public virtual UpgradePathModel GetUpgradePathModel(ModUpgrade modUpgrade, int[] newTiers) =>
        new(modUpgrade.Id, TowerId(newTiers));


    /// <summary>
    /// Allows you to override how many possible Upgrade pips it should show as being possible for a tower to get
    /// </summary>
    /// <param name="tower">The TowerToSimulation</param>
    /// <param name="path">What path this is for</param>
    /// <param name="defaultMax">The default maximum</param>
    /// <returns>The new maximum amount of upgrade pips, or null for no change</returns>
    public virtual int? MaxUpgradePips(TowerToSimulation tower, int path, int defaultMax) => null;

    /// <summary>
    /// Allows you to override whether an UpgradePath should be closed or not for a tower
    /// </summary>
    /// <param name="tower">The TowerToSimulation</param>
    /// <param name="path">What path this is for</param>
    /// <param name="defaultClosed">Whether it'd be naturally closed or not</param>
    /// <returns>Whether the upgrade path should be closed, or null for no change</returns>
    public virtual bool? IsUpgradePathClosed(TowerToSimulation tower, int path, bool defaultClosed) => null;

    /// <summary>
    /// Allows you to change the base TowerModel your tower will use at different tiers. Note that you'd need to be
    /// careful if you entirely changed the base tower you're working with at different tiers, as it will still attempt
    /// to apply all the appropriate upgrades. If you would like a ModUpgrade to only have an effect at a given tier,
    /// you could do something like:
    /// <code>
    /// public override void ApplyUpgrade(TowerModel towerModel) {
    ///     if (towerModel.tiers[Path] != Tier) return;
    ///     ...
    /// }
    /// </code>
    /// </summary>
    /// <param name="tiers">Length 3 array of Top/Mid/Bot tiers</param>
    /// <returns>The base TowerModel to use</returns>
    public virtual TowerModel GetBaseTowerModel(params int[] tiers) => !string.IsNullOrEmpty(BaseTower)
        ? BaseTowerModel.MakeCopy(Id)
        : new TowerModel(Id, Id, TowerSet, CreatePrefabReference(""));
}

/// <summary>
/// A convenient generic class for specifying the ModTowerSet that a ModTower uses
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModTower<T> : ModTower where T : ModTowerSet
{
    internal override ModTowerSet ModTowerSet => GetInstance<T>();

    /// <summary>
    /// The custom tower set that this ModTower uses
    /// </summary>
    public sealed override TowerSet TowerSet => ModTowerSet.Set;
}

/// <summary>
/// Defines the Paragon behavior for a ModTower
/// </summary>
public enum ParagonMode
{
    /// <summary>
    /// Don't generate a Paragon
    /// </summary>
    None,

    /// <summary>
    /// Generate a Paragon by applying the ModParagonUpgrade to the 000 version of the tower
    /// </summary>
    Base000,

    /// <summary>
    /// Generate a Paragon by applying the ModParagonUpgrade to the 555 version of the tower
    /// </summary>
    Base555
}