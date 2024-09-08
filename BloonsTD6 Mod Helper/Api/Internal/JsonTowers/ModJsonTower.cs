using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

[JsonObject(MemberSerialization.OptIn)]
internal class ModJsonTower : ModTower
{
    protected virtual JObject TowerModel { get; set; }

    public List<ModJsonUpgrade> JsonUpgrades { get; } = new();

    [JsonProperty]
    public override string Name { get; }

    [JsonProperty]
    public override string DisplayName { get; }

    [JsonProperty]
    public override string Description { get; }

    [JsonProperty]
    public override TowerSet TowerSet { get; }

    [JsonProperty]
    public override string BaseTower { get; }

    [JsonProperty]
    public override int Cost { get; }

    [JsonProperty]
    public override SpriteReference IconReference { get; }

    [JsonProperty]
    public override SpriteReference PortraitReference { get; }

    [JsonProperty]
    public JsonModelChange[] Changes { get; init; } = Array.Empty<JsonModelChange>();

    // ReSharper disable once ConvertToPrimaryConstructor
    public ModJsonTower
    (
        [JsonProperty] string name, [JsonProperty] string displayName, [JsonProperty] string description,
        [JsonProperty] TowerSet towerSet, [JsonProperty] string baseTower, [JsonProperty] int cost,
        [JsonProperty] SpriteReference iconReference, [JsonProperty] SpriteReference portraitReference
    )
    {
        Name = name;
        DisplayName = displayName;
        Description = description;
        TowerSet = towerSet;
        BaseTower = baseTower;
        Cost = cost;
        IconReference = iconReference;
        PortraitReference = portraitReference;
    }

    public override int TopPathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 0);
    public override int MiddlePathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 1);
    public override int BottomPathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 2);

    private protected override string ID => Name;

    public override void Register()
    {
        TowerModel ??= JObject.Parse(ModelSerializer.SerializeModel(base.BaseTowerModel.Duplicate()));
        foreach (var change in Changes)
        {
            change.Apply(TowerModel);
        }
        base.Register();
    }

    private TowerModel baseTowerModel;

    internal override TowerModel BaseTowerModel =>
        baseTowerModel ??= ModelSerializer.DeserializeModel<TowerModel>(TowerModel);

    public override TowerModel GetBaseTowerModel(int[] tiers)
    {
        if (tiers.SequenceEqual(new[] {0, 0, 0})) 
            return BaseTowerModel.Duplicate();

        var tower = (JObject) TowerModel.DeepClone();

        var upgrades = GetUpgradesForTiers(tiers).Cast<ModJsonUpgrade>().ToArray();

        tower["appliedUpgrades"] = new JArray(upgrades.Select(upgrade => upgrade.Id));

        foreach (var upgrade in upgrades)
        {
            upgrade.Apply(tower);
        }

        return ModelSerializer.DeserializeModel<TowerModel>(tower);
    }

    public override void ModifyBaseTowerModel(TowerModel model)
    {
    }
}