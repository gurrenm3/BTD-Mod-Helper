using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

[JsonObject(MemberSerialization.OptIn)]
internal class ModJsonTower : ModTower
{
    [JsonProperty]
    private string description;
    [JsonProperty]
    private string displayName;

    public JObject jObject;
    public TowerModel towerModel;

    public List<ModJsonUpgrade> JsonUpgrades { get; init; } = new();

    public override int TopPathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 0);
    public override int MiddlePathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 1);
    public override int BottomPathUpgrades => JsonUpgrades.Count(upgrade => upgrade.Path == 2);

    internal override TowerModel BaseTowerModel => towerModel;
    public override TowerSet TowerSet => towerModel.towerSet;
    public override string BaseTower => towerModel.name;
    public override int Cost => (int) towerModel.cost;
    public override string Name => towerModel.baseId;
    public override SpriteReference IconReference => towerModel.icon;
    public override SpriteReference PortraitReference => towerModel.portrait;

    public override string DisplayName => displayName;
    public override string Description => description;
    private protected override string ID => Name;

    public override IEnumerable<ModContent> Load()
    {
        yield break;
    }

    public override TowerModel GetBaseTowerModel(int[] tiers)
    {
        if (tiers.SequenceEqual(new[] {0, 0, 0})) return towerModel.Duplicate();

        var tower = (JObject) jObject.DeepClone();

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