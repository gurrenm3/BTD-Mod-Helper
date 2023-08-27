using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

internal abstract class JsonUpgradeEffect
{
    public abstract void Apply(JObject towerModel);
}