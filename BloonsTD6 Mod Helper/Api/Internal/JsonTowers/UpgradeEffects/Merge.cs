using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.Internal.JsonTowers.UpgradeEffects;

[JsonObject(MemberSerialization.Fields)]
internal class Merge : JsonUpgradeEffect
{
    private JObject tower;

    public override void Apply(JObject towerModel)
    {
        MergeIn(towerModel, tower);
    }

    private static void MergeIn(JToken source, JToken merge)
    {
        switch (source)
        {
            case JArray sourceArray when merge is JArray mergeArray:
            {
                MergeArray(sourceArray, mergeArray);
                break;
            }
            case JObject sourceObject when merge is JObject mergeObject:
            {
                MergeObject(sourceObject, mergeObject);
                break;
            }
        }
    }

    private static void MergeArray(JArray sourceArray, JArray mergeArray)
    {
        for (var i = 0; i < mergeArray.Count; i++)
        {
            var element = mergeArray[i];
            if (element is JObject objectElement && objectElement.TryGetValue("name", out var name))
            {
                var sourceElement = sourceArray.FirstOrDefault(token =>
                    token is JObject sourceElement && sourceElement["name"] == name);
                if (sourceElement != null)
                {
                    if (objectElement.ContainsKey("$delete"))
                    {
                        sourceArray.Remove(sourceElement);
                    }
                    else
                    {
                        MergeIn(sourceElement, objectElement);
                    }
                }
                else if (!objectElement.ContainsKey("$delete"))
                {
                    sourceArray.Add(objectElement.DeepClone());
                }
            }
            else
            {
                MergeIn(sourceArray[i], element);
            }
        }
    }

    private static void MergeObject(JObject sourceObject, JObject mergeObject)
    {
        foreach (var (key, token) in mergeObject)
        {
            if (sourceObject.TryGetValue(key, out var sourceToken))
            {
                if (sourceToken is JValue)
                {
                    sourceObject[key] = token?.DeepClone();
                }
                else
                {
                    MergeIn(sourceToken, token);
                }
            }
            else
            {
                sourceObject[key] = token?.DeepClone();
            }
        }
    }
}