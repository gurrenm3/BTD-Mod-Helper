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
    public override string DisplayName { get; }

    [JsonProperty]
    public override string Description { get; }

    [JsonProperty]
    public string TowerId { get; init; }

    [JsonProperty] 
    public JsonUpgradeEffect[] Effects { get; init; }

    public UpgradeModel UpgradeModel { get; set; }

    public ModJsonTower JsonTower { private get; set; }

    public override ModTower Tower => JsonTower;

    public override int Path => UpgradeModel.path;
    public override int Tier => UpgradeModel.tier + 1;
    public override int Cost => UpgradeModel.cost;
    public override string Name => UpgradeModel.name;
    public override SpriteReference IconReference => UpgradeModel.icon;
    public override SpriteReference PortraitReference => null;
    private protected override string ID => Name;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ModJsonUpgrade([JsonProperty] string displayName, [JsonProperty] string description)
    {
        DisplayName = displayName;
        Description = description;
    }

    public override void ApplyUpgrade(TowerModel towerModel)
    {
    }

    public void Apply(JObject jObject)
    {
        foreach (var upgradeEffect in Effects)
        {
            upgradeEffect.Apply(jObject);
        }
    }
}