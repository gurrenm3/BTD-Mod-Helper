using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// A class used to create an Upgrade for a Tower
/// </summary>
public abstract class ModUpgrade : NamedModContent
{

    /// <summary>
    /// Path ID for the Top path
    /// </summary>
    protected const int TOP = 0;

    /// <summary>
    /// Path ID for the Middle path
    /// </summary>
    protected const int MIDDLE = 1;

    /// <summary>
    /// Path ID for the Bottom path
    /// </summary>
    protected const int BOTTOM = 2;
    internal static readonly Dictionary<string, ModUpgrade> Cache = new();
    internal static readonly Dictionary<string, UpgradeModel> UpgradeModelCache = new();

    private UpgradeModel upgradeModel;


    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 2;

    /// <summary>
    /// ModUpgrades register second
    /// </summary>
    /// <exclude />
    protected sealed override float RegistrationPriority => 2;

    private static SpriteReference DefaultIcon => CreateSpriteReference("aa0cb2e090ae15a478243899824ad4b1");

    /// <summary>
    /// The file name without extension for the Portrait for this upgrade
    /// <br />
    /// By default is the same file name as the tower followed by -Portrait
    /// </summary>
    public virtual string Portrait => GetType().Name + "-Portrait";

    /// <summary>
    /// The file name without extension for the Icon for this upgrade
    /// <br />
    /// The Tower follows the default Bloons method of picking a Portrait: choose the highest tier upgrade, and if
    /// there's a tie, choose Mid > Top > Bot (for whatever reason)
    /// <br />
    /// By default is the same file name as the tower followed by -Icon
    /// </summary>
    public virtual string Icon => GetType().Name + "-Icon";

    /// <summary>
    /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrNull(Icon);

    /// <summary>
    /// If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference PortraitReference => GetSpriteReferenceOrNull(Portrait);


    /// <summary>
    /// Custom priority to make this upgrade applied sooner (increased priority) or later (decreased priority)
    /// when the TowerModel is being constructed
    /// </summary>
    public virtual int Priority => 0;

    /// <summary>
    /// Whether this upgrade requires a confirmation popup
    /// </summary>
    public virtual bool NeedsConfirmation => false;

    /// <summary>
    /// The title for the confirmation popup, if needed
    /// </summary>
    public virtual string ConfirmationTitle => null;

    /// <summary>
    /// The body text for the confirmation popup, if needed
    /// </summary>
    public virtual string ConfirmationBody => null;

    /// <summary>
    /// Xp Cost for the upgrade. Meaningless usually because custom heroes automatically are automatically unlocked.
    /// </summary>
    public virtual int XpCost => 0;

    /// <summary>
    /// The upgrade path
    /// Use <see cref="TOP" />, <see cref="MIDDLE" />, <see cref="BOTTOM" />
    /// </summary>
    public abstract int Path { get; }

    /// <summary>
    /// The upgrade tier, 1 for Tier 1 Upgrades, 2 for Tier 2, etc...
    /// </summary>
    public abstract int Tier { get; }

    /// <summary>
    /// How much the upgrade costs on Medium difficulty
    /// </summary>
    public abstract int Cost { get; }

    /// <summary>
    /// The tower that this is an upgrade for
    /// </summary>
    public abstract ModTower Tower { get; }

    /// <inheritdoc />
    public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
    {
        base.RegisterText(textTable);
        if (NeedsConfirmation)
        {
            if (ConfirmationTitle != null)
            {
                textTable[Id + " Title"] = ConfirmationTitle;
            }

            if (ConfirmationBody != null)
            {
                textTable[Id + " Body"] = ConfirmationBody;
            }
        }
    }

    /// <inheritdoc />
    public override void Register()
    {
        upgradeModel = GetUpgradeModel();

        AssignToModTower();

        try
        {
            if (Cache.ContainsKey(upgradeModel.name))
            {
                var message = $"Duplicate Upgrade {upgradeModel.name}";
                ModHelper.Error(message);
                mod.loadErrors.Add(message);
            }
            else
            {
                Game.instance.model.AddUpgrade(upgradeModel);
                Cache[upgradeModel.name] = this;
            }
        }
        finally
        {
            rollbackActions.Push(() =>
            {
                Game.instance.model.upgrades = Game.instance.model.upgrades.RemoveItem(upgradeModel);
                Game.instance.model.upgradesByName?.Remove(upgradeModel.name);
                Game.instance.model.RemoveChildDependant(upgradeModel);
                Cache.Remove(upgradeModel.name);
                UpgradeModelCache.Remove(upgradeModel.name);
            });
        }
    }

    /// <summary>
    /// Assigns this upgrade to its ModTower
    /// </summary>
    protected internal virtual void AssignToModTower()
    {
        if (Path is >= 0 and < 3 && Tower.TierMaxes[Path] >= Tier)
        {
            try
            {
                Tower.Upgrades[Path, Tier - 1] = this;
            }
            catch (Exception)
            {
                ModHelper.Error("Failed to assign ModUpgrade " + Name + " to ModTower's upgrades");
                ModHelper.Error(
                    "Double check that all Path and Tier values are correct");
                throw;
            }
        }
        else
        {
            ModHelper.Warning("Failed to assign ModUpgrade " + Name + $" to ModTower {Tower.Name}'s upgrades");
            ModHelper.Warning("Double check that all Path and Tier values are correct");
            ModHelper.Warning($"{Tower.TierMaxes[Path]} compared to {Tier}");
        }
    }

    /// <summary>
    /// Apply the effects that this upgrade has onto a TowerModel
    /// <br />
    /// The TowerModel's tier(s), applied upgrades and other info will already be correct, so this is mostly about
    /// changing the TowerModel's behavior
    /// <br />
    /// The default ordering of upgrade application is to do them in ascending order of tier, doing Top then Mid
    /// then Bot at each tier. This can be changed using <see cref="Priority" />.
    /// </summary>
    /// <param name="towerModel">The Tower Model</param>
    public abstract void ApplyUpgrade(TowerModel towerModel);

    /// <summary>
    /// Make this upgrade apply additional effects on a towerModel when you go into a new match.
    /// Useful for making conditional effects happen based on settings.
    /// <br />
    /// The normal ApplyUpgrade effects for all upgrades will have already been applied on game start,
    /// so this will simply modify all the TowerModels for this ModTower that have this upgrade.
    /// </summary>
    /// <param name="towerModel">The Tower Model</param>
    /// <param name="gameModes">What GameModes are active for the match</param>
    public virtual void ApplyUpgradeForMatch(TowerModel towerModel, IReadOnlyList<ModModel> gameModes)
    {

    }


    /// <summary>
    /// Apply effects to this Tower Model before all other ApplyUpgrade and LateApplyUpgrade effects have happened
    /// <br />
    /// Otherwise, usual priority / ordering rules still apply
    /// </summary>
    /// <param name="towerModel"></param>
    public virtual void EarlyApplyUpgrade(TowerModel towerModel)
    {
    }

    /// <summary>
    /// Apply effects to this Tower Model after all the other EarlyApplyUpgrade and ApplyUpgrade effects have happened
    /// <br />
    /// Otherwise, usual priority / ordering rules still apply
    /// </summary>
    /// <param name="towerModel"></param>
    public virtual void LateApplyUpgrade(TowerModel towerModel)
    {
    }

    /// <summary>
    /// If you really need to override the way that the ModUpgrade makes its UpgradeModel, go ahead
    /// </summary>
    /// <returns></returns>
    public virtual UpgradeModel GetUpgradeModel()
    {
        return upgradeModel ??= new UpgradeModel(Id, Cost, XpCost, IconReference ?? DefaultIcon,
            Path, Tier - 1, 0, NeedsConfirmation ? Id : "", "");
    }

    /// <summary>
    /// Allows you to dynamically allow an upgrade to not be purchasable based on the InGame values of a Tower
    /// </summary>
    /// <param name="tower"></param>
    /// <returns>If </returns>
    public virtual bool RestrictUpgrading(Tower tower)
    {
        return false;
    }
}

/// <summary>
/// A convenient generic class for specifying the ModTower that this ModUpgrade is for
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModUpgrade<T> : ModUpgrade where T : ModTower
{
    /// <inheritdoc />
    public override ModTower Tower => GetInstance<T>();
}