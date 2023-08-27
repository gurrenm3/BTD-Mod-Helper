using System.Collections.Generic;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

[JsonObject(MemberSerialization.OptIn)]
internal class ModJsonUpgrade : ModUpgrade
{
    [JsonProperty]
    public string tower;
    [JsonProperty]
    public string displayName;
    [JsonProperty]
    public string description;
    [JsonProperty]
    public JsonUpgradeEffect[] effects;

    public UpgradeModel UpgradeModel { get; set; }

    public ModJsonTower JsonTower { private get; set; }

    public override ModTower Tower => JsonTower;

    public override int Path => UpgradeModel.path;
    public override int Tier => UpgradeModel.tier + 1;
    public override int Cost => UpgradeModel.cost;
    public override string Name => UpgradeModel.name;
    public override SpriteReference IconReference => UpgradeModel.icon;
    public override SpriteReference PortraitReference => null;

    public override string DisplayName => displayName;
    public override string Description => description;
    private protected override string ID => Name;

    public override IEnumerable<ModContent> Load()
    {
        yield break;
    }

    public override void ApplyUpgrade(TowerModel towerModel)
    {
    }

    public void Apply(JObject jObject)
    {
        foreach (var upgradeEffect in effects)
        {
            upgradeEffect.Apply(jObject);
        }
    }
}