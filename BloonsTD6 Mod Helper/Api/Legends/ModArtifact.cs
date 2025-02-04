using System;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.Artifacts;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Models.Artifacts;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
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
    public virtual string IconCommon => Icon;

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string IconRare => Icon;

    /// <summary>
    /// The Icon for this Artifact, either a VanillaSprites constant or custom texture name
    /// </summary>
    public virtual string IconLegendary => Icon;

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
    }

    internal System.Collections.Generic.IEnumerable<(int tier, int index)> Tiers
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

    /// <inheritdoc />
    public sealed override void RegisterText(Dictionary<string, string> textTable)
    {
        foreach (var (tier, index) in Tiers)
        {
            textTable[GetId(index)] = tier switch
            {
                Common => DisplayNameCommon,
                Rare => DisplayNameRare,
                Legendary => DisplayNameLegendary,
                _ => DisplayName
            };
            textTable[GetId(index) + "Description"] = tier switch
            {
                Common => DescriptionCommon,
                Rare => DescriptionRare,
                Legendary => DescriptionLegendary,
                _ => Description(tier)
            };
        }
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
        modelBase = model.Cast<ArtifactModelBase>();
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

    /// <inheritdoc />
    public sealed override string GetId(int tier) => base.GetId(tier);

    internal sealed override void SetArtifactModel(ItemArtifactData artifact, ItemArtifactModel model) =>
        artifact.itemArtifactModel = model;

    /// <inheritdoc />
    protected sealed override ItemArtifactModel CreateArtifactModel(int tier, int index) => new(GetId(index), tier,
        Id, new Il2CppReferenceArray<ItemArtifactBehaviorModel>(0), GetId(index), GetId(index) + "Description",
        GetIcon(tier), RarityFrameType.ToString(), false, new RogueInstaMonkey());
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
        GetId(index) + "Description", GetIcon(tier), RarityFrameType.ToString(), new Il2CppStringArray(0), false,
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
        GetId(index) + "Description", GetIcon(tier), RarityFrameType.ToString(), false);
}
