using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

[JsonObject(MemberSerialization.OptIn)]
internal class ModJsonTowerModel : ModJsonTower
{
    [JsonProperty]
    protected sealed override JObject TowerModel { get; set; }

    // ReSharper disable once ConvertToPrimaryConstructor
    public ModJsonTowerModel
    (
        [JsonProperty] string displayName,
        [JsonProperty] string description,
        [JsonProperty] JObject towerModel
    ) : base
    (
        towerModel.Value<string>("name"), displayName, description, (TowerSet) towerModel.Value<int>("towerSet"),
        towerModel.Value<string>("baseId"), towerModel.Value<int>("cost"),
        towerModel["icon"]?.ToObject<SpriteReference>(ModelConverter.Serializer),
        towerModel["portrait"]?.ToObject<SpriteReference>(ModelConverter.Serializer)
    )
    {
        TowerModel = towerModel;
    }
}