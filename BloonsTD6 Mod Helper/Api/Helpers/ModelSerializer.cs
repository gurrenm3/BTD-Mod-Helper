using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FuzzySharp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.Knowledge;
using Il2CppAssets.Scripts.Models.Powers.Mods;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppInterop.Runtime;
using Il2CppSystem.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Formatting = Il2CppNewtonsoft.Json.Formatting;
using JsonConvert = Il2CppNewtonsoft.Json.JsonConvert;
using JsonSerializerSettings = Il2CppNewtonsoft.Json.JsonSerializerSettings;
using ReferenceLoopHandling = Il2CppNewtonsoft.Json.ReferenceLoopHandling;
using TypeNameHandling = Il2CppNewtonsoft.Json.TypeNameHandling;
using ValueType = Il2CppSystem.ValueType;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Handles serializing and deserializing models in a way that utilizes their actual constructors
/// </summary>
public static class ModelSerializer
{
    private static readonly bool InferParams = false;

    internal static readonly JsonSerializerSettings Settings = new()
    {
        Formatting = Formatting.Indented,
        // PreserveReferencesHandling = PreserveReferencesHandling.Objects,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        TypeNameHandling = TypeNameHandling.Objects
    };

    private static readonly Dictionary<string, object> Index = new();

    internal static readonly Dictionary<string, string> ParamFixes = new()
    {
        {"id", "name"},
        {"damageAddative", "damageAdditive"},
        {"custonName", "customName"},
        {"mustIncludeAllTags", "mustIncludeAllStates"},
        {"roundsUntilManaDecay", "roundUntilManaDecay"},
        {"addBerserkerBrewToProjectile", "addBerserkerBrewToProjectileModel"},
        {"smallEffectModel", "smallGlowEffectModel"},
        {"targetProjectileId", "targetCPOEPId"},
        {"addEffectToTowersAffected", "displayModel"},
        {"animationState", "triggerState"},
        {"tag", "bloonTag"},
        {"targets", "splits"},
        {"delaySpawnDuration", "lifespan"},
        {"onlyAquireNewTargetIfInvalid", "constantlyAquireNewTarget"},
        {"guid", "guidRef"},
        {"towerStunDisplayAsset", "towerStunEffect"},
        {"marketplaceBonus", "marketplaceLives"},
        {"projMod", "projectileModel"}
    };

    private static object GenerateBaseType(JValue value, Type valueType)
    {
        if (value.Type == JTokenType.Boolean && valueType == typeof(string))
        {
            return value.ToString().ToLower();
        }
        return value.ToObject(valueType);
    }

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

    private static object GenerateObject(JObject jObject, Type type)
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

        var ctor = GetMainConstructor(type, jObject.Properties().Select(property => property.Name));
        if (ctor == null)
        {
            var obj = Activator.CreateInstance(type);

            foreach (var jProperty in jObject.Properties())
            {
                if (type.GetField(jProperty.Name) is { } field)
                {
                    field.SetValue(obj, Generate(jProperty.Value, field.FieldType, field.Name));
                }
                if (type.GetProperty(jProperty.Name) is { } property)
                {
                    property.SetValue(obj, Generate(jProperty.Value, property.PropertyType, property.Name));
                }
            }

            return obj;
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
                if (jObject.Properties()
                        .FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.InvariantCultureIgnoreCase)) is
                    { } p)
                {
                    name = p.Name;
                }
                else if (ParamFixes.TryGetValue(name, out var value) && extraFields.ContainsKey(value))
                {
                    name = value;
                }
                else if (InferParams)
                {
                    var bestChoice = extraFields.Values
                        .Where(p => param.ParameterType.IsAssignableTo(p.PropertyType))
                        .MaxBy(p => Fuzz.Ratio(p.Name, param.Name));

                    if (bestChoice != null)
                    {
                        ModHelper.Msg($"Using bestChoice {bestChoice.Name} for param {name} on type {type.Name}");
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
            if (param.ParameterType.IsAssignableTo(typeof(BehaviorMutator))) continue;

            var jToken = jObject[name];

            // Convert TargetType, etc to String
            if (type.GetProperty(name)?.PropertyType is { } field &&
                !field.IsAssignableTo(param.ParameterType) &&
                IsIl2CppValueType(field) &&
                field.GetProperties().FirstOrDefault(p => p.PropertyType.IsAssignableTo(param.ParameterType)) is { } prop)
            {
                jToken = jToken![prop.Name];
            }

            // This simply doesn't save the values it uses within the model, lol
            if (type == typeof(CallToArmsModel) && jObject["Mutator"] != null)
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

            if (name != "name" && param.IsOptional && fakeFields.Contains(name) || !jObject.ContainsKey(name))
            {
                // Don't calculate generated parameters
                value = param.DefaultValue;
            }
            else
            {
                value = Generate(jToken ?? new JValue(param.DefaultValue), param.ParameterType, param.Name);
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
            if (prop.PropertyType.IsValueType)
            {
                prop.SetValue(result, Generate(jObject[name], prop.PropertyType, name));
            }
        }

        if (jObject.TryGetValue("$id", out var index))
        {
            Index[index.ToString()] = result;
        }

        switch (result)
        {
            case ImfLoanModel imfLoanModel:
                imfLoanModel.imfLoanCollection?.SetName(imfLoanModel.name);
                break;
            case VineRuptureModel vineRuptureModel:
                vineRuptureModel.emission?.SetName(vineRuptureModel.name);
                break;
        }

        return result;
    }

    private static object GenerateValueType(JObject jObject, Type type)
    {
        if (jObject != null &&
            jObject.TryGetValue("$ref", out var reference) &&
            Index.TryGetValue(reference.ToString(), out var cached))
        {
            return cached;
        }

        var ctor = GetMainConstructor(type);

        var result = ctor.Invoke(null);

        if (jObject != null)
        {
            foreach (var property in type.GetProperties().Where(p => p.CanWrite))
            {
                var value = Generate(jObject[property.Name], property.PropertyType, property.Name);
                property.SetValue(result, value);
            }
        }

        if (jObject != null && jObject.TryGetValue("$id", out var index))
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

    internal static bool IsIl2CppNullable(this Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Nullable<>);

    internal static bool IsIl2CppDictionary(this Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Il2CppSystem.Collections.Generic.Dictionary<,>);

    internal static bool IsIl2CppValueType(this Type type) => type.IsAssignableTo(typeof(ValueType));

    private static object Generate(JToken jToken, Type type, string key = null)
    {
        try
        {
            return jToken switch
            {
                null when IsIl2CppValueType(type) => GenerateValueType(null, type),
                null => null,
                JValue value => GenerateBaseType(value, type),
                JArray jArray => GenerateArray(jArray, type),
                JObject jObject when IsIl2CppNullable(type) => GenerateNullable(jObject, type),
                JObject jObject when IsIl2CppValueType(type) => GenerateValueType(jObject, type),
                JObject jObject when IsIl2CppDictionary(type) => GenerateDictionary(jObject, type),
                JObject jObject => GenerateObject(jObject, type),
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

    internal static ConstructorInfo GetMainConstructor(Type type, bool allowValueTypeParams = false) => type
        .GetConstructors()
        .Where(c => c.GetParameters().All(p => p.ParameterType != typeof(IntPtr)))
        .Where(c => !type.IsAssignableTo(typeof(ValueType)) || allowValueTypeParams || c.GetParameters().Length == 0)
        .OrderByDescending(c => c.GetParameters().Length)
        .ThenBy(c => c.GetParameters().Any(p => p.ParameterType.IsGenericType))
        .FirstOrDefault();

    internal static ConstructorInfo GetMainConstructor(Type type, IEnumerable<string> propertyMatches,
        bool allowValueTypeParams = false) => type
        .GetConstructors()
        .Where(c => c.GetParameters().All(p => p.ParameterType != typeof(IntPtr)))
        .Where(c => !type.IsAssignableTo(typeof(ValueType)) || allowValueTypeParams || c.GetParameters().Length == 0)
        .MaxBy(c => c.GetParameters()
            .Select(info => info.Name)
            .Intersect(propertyMatches)
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

    internal static void MakeConsistent(Model model, bool fixAllNames = false)
    {
        // NK stores this as null for no reason
        model.GetDescendants<StripChildrenModel>().ForEach(stripChildren =>
        {
            stripChildren.Mutator.destroyOnDegradeModel ??= new DestroyOnDegradeModel("DestroyBloon");
        });

        // Why purposefully store NaN values ???
        model.GetDescendants<TravelStraitModel>().ForEach(travelStrait =>
        {
            if (float.IsNaN(travelStrait.Lifespan))
            {
                travelStrait.Lifespan = 0;
            }
        });

        model.GetDescendants<CallToArmsModel>().ForEach(callToArms =>
        {
            if (callToArms.buffIconName == null && callToArms.Mutator?.buffIndicator?.iconName is var buffIconName)
            {
                callToArms.buffIconName = buffIconName;
            }
            if (callToArms.buffLocsName == null && callToArms.Mutator?.buffIndicator?.buffName is var buffLocsName)
            {
                callToArms.buffLocsName = buffLocsName;
            }
        });

        model.GetDescendants<TowerModel>().ForEach(tower => MakeConsistent(tower));

        model.GetDescendants<GyrfalconPatternModel>().ForEach(gyrfalconPattern =>
        {
            gyrfalconPattern.cooldownFrames = (int) Math.Round(gyrfalconPattern.cooldown * 60);
        });

        model.GetDescendants<LatchToBloonModel>().ForEach(latchToBloon =>
        {
            latchToBloon.postBloonDestroyTimeFrames = (int) Math.Round(latchToBloon.postBloonDestroyTime * 60);
        });

        model.GetDescendants<AttackModel>().ForEach(attack =>
        {
            if (attack.targetProvider.Is(out GyrfalconPatternModel gyrfalconPattern))
            {
                gyrfalconPattern.cooldownFrames = (int) Math.Round(gyrfalconPattern.cooldown * 60);
            }
        });

        // Handling models whose descendants aren't properly set up by NK
        if (fixAllNames)
        {
            model.GetDescendants<SlowModel>().ForEach(m =>
            {
                m.AddChildDependant(m.effectModel);
                MakeConsistent(m, true);
            });
            model.GetDescendants<AgeModel>().ForEach(m =>
            {
                m.AddChildDependant(m.endOfRoundClearBypassModel);
                MakeConsistent(m, true);
            });
            model.GetDescendants<PreGamePrepModModel>().ForEach(m =>
            {
                m.AddChildDependant(m.projectileModel);
                MakeConsistent(m, true);
            });
            model.GetDescendants<CeramicShockModModel>().ForEach(m =>
            {
                m.AddChildDependant(m.slowModelToUse);
                MakeConsistent(m, true);
            });
            model.GetDescendants<AddAbilityToTowerModModel>().ForEach(m =>
            {
                m.AddChildDependant(m.abilityModel);
                MakeConsistent(m, true);
            });
            model.GetDescendants<VineRuptureModel>().ForEach(m =>
            {
                m.AddChildDependant(m.projectileModel);
                m.AddChildDependant(m.projectileModelHardThorns);
                m.AddChildDependant(m.effectModel);
                MakeConsistent(m, true);
            });
        }

        // This will happen eventually anyway
        if (model.Is(out TowerModel towerModel))
        {
            towerModel.UpdateTargetProviders();
        }
        else if (model.Is(out GameModel gameModel))
        {
            foreach (var knowledgeModel in gameModel.allKnowledge)
            {
                MakeConsistent(knowledgeModel, true);
            }
        } else if (model.Is(out KnowledgeModel knowledgeModel))
        {
            knowledgeModel.GetDescendants<Model>().ForEach(m =>
            {
                if (m.name == "")
                {
                    m.name = m.GetIl2CppType().Name + "_";
                }
            });
        }
    }
}