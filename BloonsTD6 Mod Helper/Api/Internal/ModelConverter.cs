using System;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
namespace BTD_Mod_Helper.Api.Internal;

internal class ModelConverter : JsonConverter
{
    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters = {new ModelConverter()},
        TypeNameHandling = TypeNameHandling.Objects,
        SerializationBinder = new ModelSerializationBinder()
    };
    
    public static readonly JsonSerializer Serializer = JsonSerializer.Create(Settings);

    public override bool CanConvert(Type objectType) => objectType.IsAssignableTo(typeof(Model));

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) =>
        writer.WriteRaw(ModelSerializer.SerializeModel(value as Model));

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) =>
        ModelSerializer.DeserializeModel(JObject.Load(reader), objectType);
}

internal class ModelSerializationBinder : DefaultSerializationBinder
{
    public override Type BindToType(string assemblyName, string typeName)
    {
        if (assemblyName == "Assembly-CSharp" && typeName.StartsWith("Assets."))
        {
            typeName = typeName.Replace("Assets.", "Il2CppAssets.");
        }

        return base.BindToType(assemblyName, typeName);
    }
}