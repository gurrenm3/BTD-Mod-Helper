using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FuzzySharp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppInterop.Runtime;
using Il2CppNewtonsoft.Json;
using Newtonsoft.Json.Linq;
using ValueType = Il2CppSystem.ValueType;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Handles serializing and deserializing models in a way that utilizes their actual constructors
/// </summary>
public static class ModelSerializer
{
    private static readonly JsonSerializerSettings Settings = new()
    {
        Formatting = Formatting.Indented,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        TypeNameHandling = TypeNameHandling.Objects
    };

    private static readonly Dictionary<string, object> Index = new();

    private static readonly Dictionary<string, string> CommonFixes = new()
    {
        {"id", "name"}
    };

    private static readonly Dictionary<Type, Dictionary<string, string>> ParamFixes = new();

    private static object GenerateBaseType(JValue value, Type valueType) =>
        value.ToObject(valueType);

    private static object GenerateArray(JArray jArray, Type type)
    {
        var ctor = GetMainConstructor(type);

        var result = ctor.Invoke(new object[] {jArray.Count});

        var add = type.GetMethod("Add");
        var setItem = type.GetMethod("set_Item")!;

        var elementType = type.GenericTypeArguments.FirstOrDefault(typeof(string));

        for (var i = 0; i < jArray.Count; i++)
        {
            var item = Generate(jArray[i], elementType, i.ToString());
            if (add != null)
            {
                add.Invoke(result, new[] {item});
            }
            else
            {
                setItem.Invoke(result, new[] {i, item});
            }
        }

        return result;
    }

    private static object GenerateObject(JObject jObject, Type type, string key = null)
    {
        if (jObject.TryGetValue("$ref", out var reference) && Index.TryGetValue(reference.ToString(), out var cached))
        {
            return cached;
        }

        if (jObject.TryGetValue("$type", out var typeToken))
        {
            var typePath = typeToken.ToString().Replace("Assets.", "Il2CppAssets.");

            type = Type.GetType(typePath, true)!;
        }

        var ctor = GetMainConstructor(type, jObject);
        if (ctor == null)
        {
            // TODO
            ModHelper.Error("No constructor");
            return null;
        }

        var parameters = new object[ctor.GetParameters().Length];


        var paramNames = ctor.GetParameters().Select(p => p.Name).ToHashSet();

        // Fields not set by the constructor
        var extraFields = type.GetProperties()
            .Where(p => p.CanWrite && !paramNames.Contains(p.Name) && jObject.ContainsKey(p.Name))
            .ToDictionary(p => p.Name, p => p);

        // Fields that are actually properties
        var il2CppType = Il2CppType.From(type);
        var fakeFields = il2CppType.GetProperties().Select(info => info.Name).ToList();

        // Order of fields within the type
        var orderedFields = type.GetProperties().Select(info => info.Name).ToList();

        var paramsByKey = new Dictionary<string, ParameterInfo>();

        // Get the correct json keys to use for each param
        foreach (var param in ctor.GetParameters())
        {
            var name = param.Name ?? throw new ArgumentException(param.ToString());
            if (!jObject.ContainsKey(name))
            {
                if (ParamFixes.TryGetValue(type, out var fixes) && fixes.TryGetValue(name, out var value))
                {
                    name = value;
                }
                else if (CommonFixes.TryGetValue(name, out value) && extraFields.ContainsKey(value))
                {
                    name = value;
                }
                else
                {
                    var bestChoice = extraFields.Values
                        .Where(p => param.ParameterType.IsAssignableTo(p.PropertyType))
                        .MaxBy(p => Fuzz.Ratio(p.Name, param.Name));

                    if (bestChoice != null)
                    {
                        name = bestChoice.Name;
                        extraFields.Remove(name);
                    }
                }

            }

            paramsByKey[name] = param;
        }

        // Go in order of the fields
        foreach (var (name, param) in paramsByKey.OrderBy(pair => orderedFields.IndexOf(pair.Key)))
        {
            var jToken = jObject[name];

            // Convert TargetType, etc to String
            if (type.GetProperty(name)?.PropertyType is { } field &&
                !field.IsAssignableTo(param.ParameterType) &&
                IsValueType(field) &&
                field.GetProperties().FirstOrDefault(p => p.PropertyType.IsAssignableTo(param.ParameterType)) is { } prop)
            {
                jToken = jToken![prop.Name];
            }

            // This simply doesn't save the values it uses within the model, lol
            if (type == typeof(CallToArmsModel))
            {
                var buffIndicator = jObject["Mutator"]!["buffIndicator"]!;
                jToken = name switch
                {
                    "buffLocsName" => buffIndicator["buffName"],
                    "buffIconName" => buffIndicator["iconName"],
                    _ => jToken
                };
            }

            object value;

            if (name != "name" && param.IsOptional && fakeFields.Contains(name))
            {
                // Don't calculate generated parameters
                value = param.DefaultValue;
            }
            else
            {
                value = Generate(jToken, param.ParameterType, param.Name);
                if (name == "name" && (string) value == $"{type.Name}_")
                {
                    value = "";
                }
            }

            parameters[param.Position] = value;
        }

        var result = ctor.Invoke(parameters.ToArray());

        // Override simple values that may be different from constructor
        foreach (var (name, prop) in extraFields)
        {
            if (jObject[name] is JValue jValue)
            {
                prop.SetValue(result, Generate(jValue, prop.PropertyType, name));
            }
        }

        if (jObject.TryGetValue("$id", out var index))
        {
            Index[index.ToString()] = result;
        }

        return result;
    }

    private static object GenerateValueType(JObject jObject, Type type)
    {
        if (jObject.TryGetValue("$ref", out var reference) && Index.TryGetValue(reference.ToString(), out var cached))
        {
            return cached;
        }

        var ctor = GetMainConstructor(type);

        var result = ctor.Invoke(null);

        foreach (var property in type.GetProperties().Where(p => p.CanWrite))
        {
            var value = Generate(jObject[property.Name], property.PropertyType, property.Name);
            property.SetValue(result, value);

            if (property.Name == "actionOnCreate")
            {
                ModHelper.Msg("here");
            }
        }

        if (jObject.TryGetValue("$id", out var index))
        {
            Index[index.ToString()] = result;
        }

        return result;
    }

    private static object GenerateDictionary(JObject jObject, Type type)
    {
        if (jObject.TryGetValue("$ref", out var reference) && Index.TryGetValue(reference.ToString(), out var cached))
        {
            return cached;
        }

        var add = type.GetMethod("Add")!;
        var result = Activator.CreateInstance(type);
        var valueType = type.GenericTypeArguments.Last();

        foreach (var (key, value) in jObject)
        {
            if (key.StartsWith("$")) continue;

            add.Invoke(result, new[] {key, Generate(value, valueType, key)});
        }

        if (jObject.TryGetValue("$id", out var index))
        {
            Index[index.ToString()] = result;
        }

        return result;
    }

    private static object GenerateNullable(JToken jToken, Type type)
    {
        var unbox = type.GetMethod("Unbox", BindingFlags.Public | BindingFlags.Static)!;
        var setValue = type.GetMethod("set_value")!;
        var realType = type.GenericTypeArguments[0];
        var value = Generate(jToken, realType);

        var result = unbox.Invoke(null, new[] {value});

        setValue.Invoke(result, new[] {value});

        return result;
    }

    private static bool IsNullable(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Nullable<>);

    private static bool IsDictionary(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Collections.Generic.Dictionary<,>);

    private static bool IsValueType(Type type) => type.IsAssignableTo(typeof(ValueType));

    private static object Generate(JToken jToken, Type type, string key = null)
    {
        try
        {
            if (jToken == null) return null;

            return jToken switch
            {
                JValue value => GenerateBaseType(value, type),
                JArray jArray => GenerateArray(jArray, type),
                JObject jObject when IsNullable(type) => GenerateNullable(jObject, type),
                JObject jObject when IsValueType(type) => GenerateValueType(jObject, type),
                JObject jObject when IsDictionary(type) => GenerateDictionary(jObject, type),
                JObject jObject => GenerateObject(jObject, type, key),
                _ => null
            };
        }
        catch (Exception e)
        {
            ModHelper.Error(type + " " + key);
            ModHelper.Error(e);
            ModHelper.Error("");
            return null;
        }
    }

    private static ConstructorInfo GetMainConstructor(Type type) => type.GetConstructors()
        .Where(c => c.GetParameters().All(p => p.ParameterType != typeof(IntPtr)))
        .Where(c => type.IsAssignableTo(typeof(ValueType)) ? c.GetParameters().Length == 0 : c.GetParameters().Length > 0)
        .OrderByDescending(c => c.GetParameters().Length)
        .ThenBy(c => c.GetParameters().Any(p => p.ParameterType.IsGenericType))
        .FirstOrDefault();

    private static ConstructorInfo GetMainConstructor(Type type, JObject jObject) => type.GetConstructors()
        .Where(c => c.GetParameters().All(p => p.ParameterType != typeof(IntPtr)))
        .Where(c => type.IsAssignableTo(typeof(ValueType)) ? c.GetParameters().Length == 0 : c.GetParameters().Length > 0)
        .MaxBy(c => c.GetParameters()
            .Select(info => info.Name)
            .Intersect(jObject.Properties().Select(property => property.Name))
            .Count()
        );


    /// <summary>
    /// Serializes a model to JSON, preserving types and references
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static string SerializeModel(Model model)
    {
#if DEBUG
        MakeConsistent(model);
#endif
        return JsonConvert.SerializeObject(model, Settings);
    }

    /// <summary>
    /// Recreates a model from serialized JSON, attempting to exactly recreate its types and references
    /// </summary>
    /// <param name="text">Serialized model JSON string</param>
    /// <typeparam name="T">The type of Model to deserialize this as</typeparam>
    /// <returns></returns>
    public static T DeserializeModel<T>(string text) where T : Model
    {
        Index.Clear();
        var result = Generate(JObject.Parse(text), typeof(T)) as T;
        Index.Clear();

#if DEBUG
        MakeConsistent(result);
#endif

        return result;
    }

    internal static void MakeConsistent(Model model)
    {
        // NK stores this as null for no reason
        model.GetDescendants<StripChildrenModel>().ForEach(stripChildrenModel =>
        {
            stripChildrenModel.Mutator.destroyOnDegradeModel ??= new DestroyOnDegradeModel("DestroyBloon");
        });

        model.GetDescendants<TowerModel>().ForEach(MakeConsistent);

        // This will happen eventually anyway
        if (model.Is(out TowerModel towerModel))
        {
            towerModel.UpdateTargetProviders();
        }
    }
}