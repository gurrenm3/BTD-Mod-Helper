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
    public override string Name { get; }

    [JsonProperty]
    public override string DisplayName { get; }

    [JsonProperty]
    public override string Description { get; }

    [JsonProperty]
    public override int Cost { get; }

    [JsonProperty]
    public override int Path { get; }

    [JsonProperty]
    public override int Tier { get; }

    [JsonProperty]
    public override SpriteReference IconReference { get; }

    [JsonProperty]
    public string TowerId { get; init; }

    [JsonProperty]
    public JsonModelChange[] Changes { get; init; }

    public UpgradeModel UpgradeModel { get; set; }

    public ModJsonTower JsonTower { private get; set; }

    public override ModTower Tower => JsonTower;

    public override SpriteReference PortraitReference => null;
    private protected override string ID => Name;

    // ReSharper disable once ConvertToPrimaryConstructor
    public ModJsonUpgrade
    (
        [JsonProperty] string name, [JsonProperty] string displayName, [JsonProperty] string description,
        [JsonProperty] int cost, [JsonProperty] int path, [JsonProperty] int tier,
        [JsonProperty] SpriteReference iconReference
    )
    {
        Name = name;
        DisplayName = displayName;
        Description = description;
        Cost = cost;
        Path = path;
        Tier = tier;
        IconReference = iconReference;
    }

    public override void ApplyUpgrade(TowerModel towerModel)
    {
    }

    public void Apply(JObject jObject)
    {
        foreach (var change in Changes)
        {
            change.Apply(jObject);
        }
    }
}