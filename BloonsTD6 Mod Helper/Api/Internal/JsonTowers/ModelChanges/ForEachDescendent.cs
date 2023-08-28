using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.ModelChanges;

[JsonObject(MemberSerialization.OptOut)]
internal class ForEachDescendent : JsonModelChange
{
    public JObject Type { get; init; }

    public bool First { get; init; }

    public JsonModelChange[] Changes { get; init; }

    public override void Apply(JObject model)
    {
        if (Type == null || !Type.ContainsKey("$type"))
        {
            ModHelper.Warning("no type");
            return;
        }
        
        foreach (var token in model.PropertyValues())
        {
            switch (token)
            {
                case JObject jObject:
                    if (Traverse(jObject)) return;

                    break;
                case JArray jArray:
                    foreach (var jToken in jArray)
                    {
                        if (jToken is JObject jObject)
                        {
                            if (Traverse(jObject)) return;
                        }
                    }
                    break;
            }
        }
    }

    public bool Traverse(JObject model)
    {
        if (Contains(model, Type))
        {
            foreach (var change in Changes)
            {
                change.Apply(model);
            }
            return First;
        }

        foreach (var token in model.PropertyValues())
        {
            switch (token)
            {
                case JObject jObject:
                    if (Traverse(jObject)) return true;
                    break;
                case JArray jArray:
                    foreach (var jToken in jArray)
                    {
                        if (jToken is JObject jObject)
                        {
                            if (Traverse(jObject)) return true;
                        }
                    }
                    break;
            }
        }

        return false;
    }
}