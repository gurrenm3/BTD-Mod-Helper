using System;
using System.Linq;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Artifacts;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Artifacts;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using Type = Il2CppSystem.Type;
namespace BTD_Mod_Helper.Api.Legends;

/// <summary>
/// Class for adding a custom Artifact to the Rogue Legends mode
/// </summary>
public abstract class ModArtifact : NamedModContent
{
    internal static readonly System.Collections.Generic.Dictionary<string, (ModArtifact, int)> ArtifactCache = new();
    internal static readonly System.Collections.Generic.Dictionary<string, bool> SmallIconCache = new();

    /// <summary>
    /// Tier for Common Artifacts
    /// </summary>
    protected const int Common = 0;

    /// <summary>
    /// Tier for Rare Artifacts
    /// </summary>
    protected const int Rare = 1;

    /// <summary>
    /// Tier for Legendary Artifacts
    /// </summary>
    protected const int Legendary = 2;


    /// <summary>
    /// Lowest tier this artifact can be at
    /// </summary>
    public virtual int MinTier => Common;

    /// <summary>
    /// Highest tier this artifact can be at
    /// </summary>
    public virtual int MaxTier => Legendary;

    /// <summary>
    /// Displayed Name for the Common tier of this Artifact
    /// </summary>
    public virtual string DisplayNameCommon => DisplayName + " Common";

    /// <summary>
    /// Displayed Name for the Rare tier of this Artifact
    /// </summary>
    public virtual string DisplayNameRare => DisplayName + " Rare";

    /// <summary>
    /// Displayed Name for the Legendary tier of this Artifact
    /// </summary>
    public virtual string DisplayNameLegendary => DisplayName + " Legendary";

    /// <summary>
    /// Description for the Common tier of this Artifact
    /// </summary>
    public virtual string DescriptionCommon => Description(Common);

    /// <summary>
    /// Description for the Rare tier of this Artifact
    /// </summary>
    public virtual string DescriptionRare => Description(Rare);

    /// <summary>
    /// Description for the Legendary tier of this Artifact
    /// </summary>
    public virtual string DescriptionLegendary => Description(Legendary);

    /// <summary>
    /// Artifact's description for a given tier
    /// </summary>
    /// <param name="tier">0 for Common, 1 for Rare, 2 for Legendary</param>
    /// <returns>Displayed description</returns>
    public new virtual string Description(int tier) => $"[Id] Tier {tier}";

    /// <summary>
    /// The tower set themed rarity frame for the artifact
    /// </summary>
    public virtual TowerSet RarityFrameType => TowerSet.AllMonkeyTowerSets;

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string Icon => Name;

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string IconCommon => Icon + "1";

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string IconRare => Icon + "2";

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string IconLegendary => Icon + "3";

    /// <summary>
    /// The Icon SpriteReference for this Artifact
    /// </summary>
    public virtual SpriteReference IconReference => GetSpriteReferenceOrDefault(Icon);

    /// <summary>
    /// The Icon SpriteReference for this Artifact
    /// </summary>
    public virtual SpriteReference IconCommonReference => GetSpriteReferenceOrNull(IconCommon) ?? IconReference;

    /// <summary>
    /// The Icon SpriteReference for this Artifact
    /// </summary>
    public virtual SpriteReference IconRareReference => GetSpriteReferenceOrNull(IconRare) ?? IconReference;

    /// <summary>
    /// The Icon SpriteReference for this Artifact
    /// </summary>
    public virtual SpriteReference IconLegendaryReference => GetSpriteReferenceOrNull(IconLegendary) ?? IconReference;

    /// <summary>
    /// Makes the icon for this artifact smaller to mimic the negative space found on dedicated artifact icons
    /// </summary>
    public virtual bool SmallIcon => false;

    /// <summary>
    /// Gets the id this should use for the given index
    /// </summary>
    /// <param name="index">1, 2 or 3</param>
    /// <returns>The ID to use</returns>
    public virtual string GetId(int index) => Id + index;

    /// <summary>
    /// Gets the icon for a given tier of this artifact
    /// </summary>
    /// <param name="tier">0, 1, or 2</param>
    /// <returns>icon reference</returns>
    public SpriteReference GetIcon(int tier) => tier switch
    {
        Common => IconCommonReference,
        Rare => IconRareReference,
        Legendary => IconLegendaryReference,
        _ => IconReference
    };

    internal abstract ArtifactDataBase CreateArtifactData(int tier, int index, out ArtifactModelBase model);

    internal abstract Type ArtifactType { get; }

    internal abstract bool ShouldUnlock { get; }

    internal virtual string InstaDescription(int tier) => "";

    /// <inheritdoc />
    public sealed override void Register()
    {
        if (MinTier < Common) throw new ArgumentException($"StartsAtTier must be >= {Common}");
        if (MinTier > Legendary) throw new ArgumentException($"StartsAtTier must be <= {Legendary}");
        if (MinTier > MaxTier) throw new ArgumentException("StartsAtTier must be < EndsAtTier");
        if (MaxTier < Common) throw new ArgumentException($"EndsAtTier must be >= {Common}");
        if (MaxTier > Legendary) throw new ArgumentException($"EndsAtTier must be <= {Legendary}");
        if (MaxTier < MinTier) throw new ArgumentException("EndsAtTier must be >= StartsAtTier");

        var artifactsData = GameData.Instance.artifactsData;

        var models = artifactsData.artifactModelsByType[ArtifactType].ToList();
        foreach (var (tier, index) in Tiers)
        {
            artifactsData.AddArtifactData(CreateArtifactData(tier, index, out var model));
            models.Add(model);
        }
        artifactsData.artifactModelsByType[ArtifactType] = models.ToIl2CppList();

        SmallIconCache[Id] = SmallIcon;
    }

    /// <summary>
    /// The tiers this artifact has
    /// </summary>
    public System.Collections.Generic.IEnumerable<(int tier, int index)> Tiers
    {
        get
        {
            var index = 1;
            for (var tier = MinTier; tier <= MaxTier; tier++)
            {
                yield return (tier, index++);
            }
        }
    }

    /// <summary>
    /// All the ArtifactIds that this will be adding
    /// </summary>
    public System.Collections.Generic.IEnumerable<string> Ids
    {
        get
        {
            foreach (var (_, index) in Tiers)
            {
                yield return GetId(index);
            }
        }
    }

    /// <inheritdoc />
    public sealed override void RegisterText(Dictionary<string, string> textTable)
    {
        foreach (var (tier, index) in Tiers)
        {
            textTable[GetId(index)] =
                tier switch
                {
                    Common => DisplayNameCommon,
                    Rare => DisplayNameRare,
                    Legendary => DisplayNameLegendary,
                    _ => DisplayName
                };
            textTable[GetId(index) + "Description"] =
                tier switch
                {
                    Common => DescriptionCommon,
                    Rare => DescriptionRare,
                    Legendary => DescriptionLegendary,
                    _ => Description(tier)
                } +
                InstaDescription(tier);
        }
    }

    /// <summary>
    /// Triggers when this artifact is activated within the simulation for the given tier
    /// <br/>
    /// NOTE: Should be robust against potentially being activated again within the same simulation
    /// </summary>
    /// <param name="simulation">current Sim</param>
    /// <param name="tier">artifact tier</param>
    public virtual void OnActivated(Simulation simulation, int tier)
    {

    }

    /// <summary>
    /// Modifies the game model for a match where this artifact is active at the given tier
    /// </summary>
    /// <param name="gameModel">new game model</param>
    /// <param name="tier">artifact tier</param>
    public virtual void ModifyGameModel(GameModel gameModel, int tier)
    {

    }

    internal static void FixVanillaArtifactDependants()
    {
        if (!ModHelper.Mods.Any(mod => mod.UsesArtifactDependants)) return;

        ModHelper.Msg("Fixing vanilla artifact dependants");
        foreach (var artifact in GameData.Instance.artifactsData.artifactDatas.Values())
        {
            FixDependants(artifact.ArtifactModel());
        }
    }

    internal static void FixDependants(Model model)
    {
        if (model == null || model.childDependants is {Count: > 0}) return;

        var behaviors = model.Is(out ArtifactModelBase artifactModelBase)
            ? artifactModelBase.GetArtifactBehaviorModels()
            : model.BehaviorModels() ?? Array.Empty<Model>();

        try
        {
            artifactModelBase.AddChild(behaviors.Cast<ICollection<Model>>());

            foreach (var behavior in behaviors)
            {
                if (behavior.Is(out InvokeBoostBuffBehaviorModel invokeBoostBuffBehaviorModel))
                {
                    behavior.AddChildDependant(invokeBoostBuffBehaviorModel.boostToInvokeModel);
                    FixDependants(invokeBoostBuffBehaviorModel.boostToInvokeModel);
                }
                else if (behavior.Is(out AddBehaviorArtifactBaseModel addBehaviorArtifactBaseModel))
                {
                    behavior.AddChildDependants(addBehaviorArtifactBaseModel.GetBehaviorModelsToAdd());
                }
                FixDependants(behavior);
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }

    internal static void HandleSmallIcon(RogueArtifactDisplayIcon icon, string artifactBaseId)
    {
        icon.icon.rectTransform.sizeDelta = SmallIconCache.TryGetValue(artifactBaseId, out var smallIcon) && smallIcon
            ? new Vector2(-150, -150)
            : new Vector2(-40, -40);
    }
}

/// <summary>
/// <inheritdoc cref="ModArtifact"/>
/// </summary>
public abstract class ModArtifact<TData, TModel> : ModArtifact
    where TData : ArtifactDataBase where TModel : ArtifactModelBase
{
    internal sealed override ArtifactDataBase CreateArtifactData(int tier, int index, out ArtifactModelBase modelBase)
    {
        var artifact = ScriptableObject.CreateInstance<TData>();
        artifact.name = GetId(index);
        var model = CreateArtifactModel(tier, index);
        ModifyArtifactModel(model);
        SetArtifactModel(artifact, model);
        FixDependants(model);
        modelBase = model.Cast<ArtifactModelBase>();

        ArtifactCache[artifact.name] = (this, tier);
        return artifact;
    }

    /// <summary>
    /// Creates the ArtifactModelBase derived model for this Artifact
    /// </summary>
    /// <param name="tier">0 for Common, 1 for Rare, 2 for Legendary</param>
    /// <param name="index">Artifact index</param>
    /// <returns>Created Artifact Model</returns>
    protected abstract TModel CreateArtifactModel(int tier, int index);

    internal abstract void SetArtifactModel(TData artifact, TModel model);

    /// <summary>
    /// Modifies and adds behaviors to the artifact to define its in-game effcts
    /// </summary>
    /// <param name="artifactModel">Artifact Model</param>
    public abstract void ModifyArtifactModel(TModel artifactModel);

    internal sealed override Type ArtifactType => Il2CppType.Of<TModel>();

}

/// <summary>
/// Class for adding a custom Permanent/Item Artifact to the Rogue Legends mode
/// </summary>
public abstract class ModItemArtifact : ModArtifact<ItemArtifactData, ItemArtifactModel>
{
    internal sealed override bool ShouldUnlock => true;

    /// <summary>
    /// The baseId of the Insta Monkey that this Artifact should add to your party for the given tier. Setting this will
    /// handle adding to the Artifact description
    /// </summary>
    /// <param name="tier">artifact tier 0,1,2</param>
    /// <returns>tower base id</returns>
    public virtual string InstaMonkey(int tier) => null;

    /// <summary>
    /// The baseId of the Insta Monkey that this Artifact should add to your party for the given tier. Setting this will
    /// handle adding to the Artifact description
    /// </summary>
    /// <param name="tier">artifact tier 0,1,2</param>
    /// <returns>3 length array of tiers [top, middle, bottom]</returns>
    public virtual int[] InstaTiers(int tier) => null;

    internal override string InstaDescription(int tier) => InstaMonkey(tier) is { } insta && InstaTiers(tier) is { } tiers
        ? $". Adds a {tiers[0]}-{tiers[1]}-{tiers[2]} [{insta}] to your Party"
        : "";

    /// <inheritdoc />
    public sealed override string GetId(int tier) => base.GetId(tier);

    internal sealed override void SetArtifactModel(ItemArtifactData artifact, ItemArtifactModel model) =>
        artifact.itemArtifactModel = model;

    /// <inheritdoc />
    protected sealed override ItemArtifactModel CreateArtifactModel(int tier, int index) => new(GetId(index), tier,
        Id, new Il2CppReferenceArray<ItemArtifactBehaviorModel>(0), GetId(index), GetId(index) + "Description",
        new Il2CppStringArray(0), GetIcon(tier), RarityFrameType.ToString(), false, false,
        false, InstaMonkey(tier) is { } insta && InstaTiers(tier) is { } tiers
            ? new RogueInstaMonkey
            {
                lootType = RogueLootType.permanent,
                baseId = insta,
                tiers = new Il2CppStructArray<int>(tiers)
            }
            : new RogueInstaMonkey(), 1);
}

/// <summary>
/// Class for adding a custom Boost Artifact to the Rogue Legends mode
/// </summary>
public abstract class ModBoostArtifact : ModArtifact<BoostArtifactData, BoostArtifactModel>
{
    internal sealed override bool ShouldUnlock => false;

    /// <inheritdoc />
    public sealed override string GetId(int index) => "BoostArtifact" + base.GetId(index);

    internal sealed override void SetArtifactModel(BoostArtifactData artifact, BoostArtifactModel model) =>
        artifact.boostArtifactModel = model;

    /// <inheritdoc />
    protected sealed override BoostArtifactModel CreateArtifactModel(int tier, int index) => new(GetId(index),
        tier, Id, new Il2CppReferenceArray<BoostArtifactBehaviorModel>(0), GetId(index),
        GetId(index) + "Description", new Il2CppStringArray(0), GetIcon(tier), RarityFrameType.ToString(),
        new Il2CppStringArray(0), false,
        new Il2CppStructArray<TowerSet>(0), false, new Il2CppStructArray<int>(0), false, false);
}

/// <summary>
/// Class for adding a custom Map Artifact to the Rogue Legends mode
/// </summary>
public abstract class ModMapArtifact : ModArtifact<MapArtifactData, MapArtifactModel>
{
    internal sealed override bool ShouldUnlock => true;

    internal sealed override void SetArtifactModel(MapArtifactData artifact, MapArtifactModel model) =>
        artifact.mapArtifactModel = model;

    /// <inheritdoc />
    protected sealed override MapArtifactModel CreateArtifactModel(int tier, int index) => new(GetId(index),
        tier, Id, new Il2CppReferenceArray<MapArtifactBehaviorModel>(0), GetId(index),
        GetId(index) + "Description", new Il2CppStringArray(0), GetIcon(tier), RarityFrameType.ToString(), false, false,
        false, 1);
}