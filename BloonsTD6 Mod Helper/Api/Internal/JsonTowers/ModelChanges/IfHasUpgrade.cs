using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.ModelChanges;

[JsonObject(MemberSerialization.OptOut)]
internal class IfHasUpgrade : JsonModelChange
{
    public string Upgrade { get; init; }
    public JsonModelChange[] Changes { get; init; }

    public override void Apply(JObject model)
    {
        if (model["appliedUpgrades"] is JArray appliedUpgrades && appliedUpgrades.Contains(Upgrade))
        {
            foreach (var change in Changes)
            {
                change.Apply(model);
            }
        }
    }
}