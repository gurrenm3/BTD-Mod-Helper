using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppInterop.Runtime;
using Il2CppSystem.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;
using Enumerable = Il2CppSystem.Linq.Enumerable;
using Object = Il2CppSystem.Object;
using ValueType = Il2CppSystem.ValueType;

namespace BTD_Mod_Helper.Api.Internal;

/// <summary>
/// A version of JsonConvert that uses modified settings for handling IL2Cpp types, in particular BTD6's Model types
/// </summary>
public static class Il2CppJsonConvert
{
    /// <summary>
    /// Modified settings for handling IL2Cpp types, in particular BTD6's Model types
    /// </summary>
    public static readonly JsonSerializerSettings Settings = new()
    {
        ContractResolver = new ModelContractResolver(),
        Converters = {new Il2CppConverter(), new UnityColorConverter()},
        TypeNameHandling = TypeNameHandling.Objects,
        SerializationBinder = new Il2CppSerializationBinder(),
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        Formatting = Formatting.Indented
    };

    /// <summary>
    /// Serializer for IL2Cpp types, in particular BTD6's Model types
    /// </summary>
    public static readonly JsonSerializer Serializer = JsonSerializer.Create(Settings);

    /// <inheritdoc cref="JsonConvert.SerializeObject(object)"/>
    public static string SerializeObject(Object obj) => JsonConvert.SerializeObject(obj, Settings);

    /// <inheritdoc cref="JsonConvert.DeserializeObject(string)"/>
    public static object DeserializeObject(string value) => JsonConvert.DeserializeObject(value);

    /// <inheritdoc cref="JsonConvert.DeserializeObject{T}(string)"/>
    public static object DeserializeObject<T>(string value) => (T) DeserializeObject(value);

    internal class Il2CppConverter : JsonConverter
    {
        private static readonly AsyncLocal<bool> SkipOnce = new();

        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            if (SkipOnce.Value)
            {
                SkipOnce.Value = false;
                return false;
            }

            return objectType.IsAssignableTo(typeof(Il2CppObjectBase));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is not Il2CppObjectBase baseObj ||
                !baseObj.Is(out Object obj) ||
                obj.GetCSharpType() is not { } realType)
            {
                serializer.Serialize(writer, null);
                return;
            }

            if (realType.IsValueType || realType == typeof(string))
            {
                writer.WriteRawValue(Il2CppNewtonsoft.Json.JsonConvert.SerializeObject(obj));
            }
            else if (obj.Is(out IDictionary dictionary))
            {

                var keys = Enumerable.ToArray(Enumerable.Cast<Object>(dictionary.Keys.Cast<IEnumerable>()));

                writer.WriteStartObject();
                if (serializer.TypeNameHandling is TypeNameHandling.Objects or TypeNameHandling.All)
                {
                    writer.WritePropertyName("$type");
                    writer.WriteValue(value.GetType().AssemblyQualifiedName); // TODO different name?
                }

                foreach (var key in keys)
                {
                    writer.WritePropertyName(key.ToString());
                    serializer.Serialize(writer, dictionary[key]);
                }

                writer.WriteEndObject();
            }
            else if (serializer.ContractResolver.ResolveContract(realType) is JsonArrayContract &&
                     obj.Is(out IEnumerable enumerable))
            {
                var array = Enumerable.ToArray(Enumerable.Cast<Object>(enumerable));

                writer.WriteStartArray();
                foreach (var o in array)
                {
                    serializer.Serialize(writer, o);
                }
                writer.WriteEndArray();
            }
            else
            {
                var newValue = typeof(Object).GetMethod(nameof(Object.Cast))!.MakeGenericMethod(realType).Invoke(value, []);

                SkipOnce.Value = true;
                serializer.Serialize(writer, newValue);
            }

        }

        public override object ReadJson(JsonReader reader, Type type, object existing, JsonSerializer serializer) => null;
    }

    internal class UnityColorConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            objectType == typeof(Color) || objectType == typeof(Color?);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var color = (Color) value;

            writer.WriteStartObject();
            if (serializer.TypeNameHandling is TypeNameHandling.Objects or TypeNameHandling.All)
            {
                writer.WritePropertyName("$type");
                writer.WriteValue(value.GetType().AssemblyQualifiedName);
            }
            writer.WritePropertyName("r");
            writer.WriteValue(color.r);
            writer.WritePropertyName("g");
            writer.WriteValue(color.g);
            writer.WritePropertyName("b");
            writer.WriteValue(color.b);
            writer.WritePropertyName("a");
            writer.WriteValue(color.a);
            writer.WriteEndObject();
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return objectType == typeof(Color?) ? null : default(Color);

            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonSerializationException($"Expected StartObject for Color, got {reader.TokenType}.");

            var jo = JObject.Load(reader);

            var c = new Color(jo.TryGetValue("r", out var r) ? r.Value<float>() : 0f,
                jo.TryGetValue("g", out var g) ? g.Value<float>() : 0f,
                jo.TryGetValue("b", out var b) ? b.Value<float>() : 0f,
                jo.TryGetValue("a", out var a) ? a.Value<float>() : 1f);

            return objectType == typeof(Color?) ? (Color?) c : (object) c;
        }
    }

    internal class Il2CppSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            switch (assemblyName)
            {
                case "Assembly-CSharp" when typeName.StartsWith("Assets."):
                    typeName = typeName.Replace("Assets.", "Il2CppAssets.");
                    break;
                case "Il2CppNinjaKiwi.Common":
                    assemblyName = "NinjaKiwi.Common";
                    typeName = typeName.Replace("Il2CppNinjaKiwi.Common", "NinjaKiwi.Common");
                    break;
            }

            return base.BindToType(assemblyName, typeName);
        }
    }

    internal static readonly Il2CppNewtonsoft.Json.Serialization.DefaultContractResolver Il2CppDefaultContractResolver =
        new();

    internal class Il2CppContractResolver : DefaultContractResolver
    {
        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            if (member.GetUnderlyingType().IsIl2CppNullable())
            {
                var il2cppMember = Il2CppType.From(member.DeclaringType!)
                    .GetMember(member.Name, Il2CppSystem.Reflection.BindingFlags.Instance |
                                            Il2CppSystem.Reflection.BindingFlags.Public |
                                            Il2CppSystem.Reflection.BindingFlags.NonPublic)
                    .First();

                return new Il2CppValueProvider(Il2CppDefaultContractResolver.CreateMemberValueProvider(il2cppMember));
            }

            return base.CreateMemberValueProvider(member);
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var il2cppType = Il2CppType.From(objectType, false);

            var memberNames = il2cppType
                .GetMembers(Il2CppSystem.Reflection.BindingFlags.Instance |
                            Il2CppSystem.Reflection.BindingFlags.Public |
                            Il2CppSystem.Reflection.BindingFlags.NonPublic)
                .Select(info => info.Name)
                .ToHashSet();

            return base
                .GetSerializableMembers(objectType)
                .Where(member => memberNames.Contains(member.Name) &&
                                 member.GetUnderlyingType() != typeof(IntPtr))
                .ToList();
        }
    }

    internal class ModelContractResolver : Il2CppContractResolver
    {
        private bool AllowedMemberType(Type type) =>
            !type.IsAssignableTo(typeof(BehaviorMutator)) &&
            !type.IsAssignableTo(typeof(Il2CppAssets.Scripts.ObjectId)) &&
            !(type.IsGenericType && type.GenericTypeArguments.Any(t => !AllowedMemberType(t)));

        private bool AllowedMember(MemberInfo member) =>
            AllowedMemberType(member.GetUnderlyingType()) &&
            member.Name != nameof(Model.childDependants) &&
            member.Name != nameof(Model.ImplementationType);

        protected override List<MemberInfo> GetSerializableMembers(Type objectType) => base
            .GetSerializableMembers(objectType)
            .Where(AllowedMember)
            .ToList();
    }

    internal class Il2CppValueProvider(Il2CppNewtonsoft.Json.Serialization.IValueProvider il2CppValueProvider)
        : IValueProvider
    {
        public void SetValue(object target, object value)
        {
            il2CppValueProvider.SetValue(target as Object, value as Object);
        }

        public object GetValue(object target)
        {
            return il2CppValueProvider.GetValue(target as Object);
        }
    }

    internal static Type GetCSharpType(this Object obj) => obj.GetIl2CppType().GetCSharpType();

    internal static Type GetCSharpType(this Il2CppSystem.Type il2cppType)
    {
        var name = il2cppType.AssemblyQualifiedName
            .Replace("Assets.Scripts", "Il2CppAssets.Scripts")
            .Replace("NinjaKiwi.Common", "Il2CppNinjaKiwi.Common");

        return Type.GetType(name);
    }

    internal static bool IsIl2CppNullable(this Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Nullable<>);

    internal static bool IsIl2CppDictionary(this Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Collections.Generic.Dictionary<,>);

    internal static bool IsIl2CppValueType(this Type type) => type.IsAssignableTo(typeof(ValueType));
}