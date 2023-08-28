using System.Linq;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers;

internal abstract class JsonModelChange
{
    public abstract void Apply(JObject model);
    
    protected static bool Contains(JToken container, JToken contained) => container switch
    {
        JObject containerObject when contained is JObject containedObject => Contains(containerObject, containedObject),
        JArray containerArray when contained is JArray containedArray => Contains(containerArray, containedArray),
        _ => JToken.DeepEquals(container, contained)
    };

    protected static bool Contains(JObject container, JObject contained)
    {
        foreach (var (key, value) in contained)
        {
            if (key == "name" &&
                value is JValue {Type: JTokenType.String} name &&
                container.TryGetValue("name", out var containerValue) &&
                containerValue is JValue {Type: JTokenType.String} containerName)
            {
                if (!containerName.Value<string>()!.Contains(name.Value<string>()!)) return false;
            }
            else if (!Contains(container[key], value)) return false;
        }

        return true;
    }

    protected static bool Contains(JArray container, JArray contained)
    {
        for (var i = 0; i < contained.Count; i++)
        {
            var element = contained[i];
            if (element is JObject elementObject && elementObject.TryGetValue("name", out var name))
            {
                var sourceElement = container.FirstOrDefault(token =>
                    token is JObject sourceElement && sourceElement["name"] == name);
                if (sourceElement is JObject sourceObject)
                {
                    if (!Contains(sourceObject, elementObject)) return false;
                }
                else return false;
            }
            else
            {
                if (!Contains(container[i], element)) return false;
            }
        }

        return true;
    }
}