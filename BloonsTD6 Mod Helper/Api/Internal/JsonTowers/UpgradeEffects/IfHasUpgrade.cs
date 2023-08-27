using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.UpgradeEffects;

[JsonObject(MemberSerialization.OptOut)]
internal class IfHasUpgrade : JsonUpgradeEffect
{
    public string Upgrade { get; init; }
    public JsonUpgradeEffect Effect { get; init; }

    public override void Apply(JObject model)
    {
        if (model["appliedUpgrades"] is JArray appliedUpgrades && appliedUpgrades.Contains(Upgrade))
        {
            Effect.Apply(model);
        }
    }
}