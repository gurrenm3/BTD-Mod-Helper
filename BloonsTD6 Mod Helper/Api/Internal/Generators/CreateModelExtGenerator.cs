using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using DBNull = Il2CppSystem.DBNull;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class CreateModelExtGenerator : ModSourceFileGenerator
{
    private static readonly Il2CppJsonConvert.Il2CppContractResolver Resolver = new();

    internal static readonly Dictionary<(Type, string), string> DefaultValueOverrides = new()
    {
        [(typeof(DamageModel), nameof(DamageModel.distributeToChildren))] = "true",
        [(typeof(DamageModel), nameof(DamageModel.createPopEffect))] = "true",
        [(typeof(EffectModel), nameof(EffectModel.scale))] = "1",
        [(typeof(EffectModel), nameof(EffectModel.lifespan))] = "1",
        [(typeof(DamageModifierModel), "damageMultiplier")] = "1",
        [(typeof(ProjectileModel), nameof(ProjectileModel.vsBlockerRadius))] = "0",
        [(typeof(ProjectileModel), nameof(ProjectileModel.maxPierce))] = "0",
        [(typeof(AttackModel), nameof(AttackModel.addsToSharedGrid))] = "true"
    };

    public override string[] OutputPath => ["Extensions", "ModelExtensions"];
    public override string FileName => "CreateModelExt";
    public override string Namespace => "BTD_Mod_Helper.Extensions";

    public override void Generate(StringBuilder sb)
    {
        var allowedModelNames = Game.instance.model
            .GetDescendants<Model>()
            .ToArray()
            .Select(model => model.GetIl2CppType().Name)
            .ToHashSet();

        var modelTypes = AccessTools.GetTypesFromAssembly(typeof(Model).Assembly).Where(type =>
        {
            try
            {
                return !(type.Namespace ?? "").Contains(".Artifacts.") &&
                       type.IsAssignableTo(typeof(Model)) &&
                       !type.IsAssignableTo(typeof(GameModel)) &&
                       !Il2CppType.From(type).IsAbstract &&
                       !type.IsGenericType;
            }
            catch (Exception)
            {
                return false;
            }
        }).GroupBy(type => type.Name);

        var modelTypeDict = new SortedDictionary<string, Type>();
        foreach (var group in modelTypes)
        {
            if (group.Count() == 1)
            {
                modelTypeDict.Add(group.Key, group.Single());
            }
            else
            {
                foreach (var type in group)
                {
                    var folders = type.Namespace!.Split(".").ToList();
                    folders.RemoveAll(f => group.Any(t => t != type && t.Namespace!.Contains(f)));

                    modelTypeDict.Add(folders.Join(delimiter: "") + group.Key, type);
                }
            }
        }

        sb.Append(
            $"""
             // If it has errors after a BTD6 update, delete it and regenerate it using the `generate creates` command in game

             // ReSharper disable InconsistentNaming
             // ReSharper disable PreferConcreteValueOverDefault
             #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

             namespace {Namespace};

             {modelTypeDict.Select(GenerateFor).Join(delimiter: "\n\n")}

             """);
    }

    private static string GenerateFor(KeyValuePair<string, Type> nameAndType)
    {
        var (name, type) = nameAndType;
        var ctor = ModelSerializer.GetMainConstructor(type);

        var properties = Resolver.GetAllSerializableMembers(type)
            .OfType<PropertyInfo>()
            .Where(p => p.CanWrite && p.Name != nameof(Model.childDependants))
            .ToArray();
        var remainingProperties = properties.ToList();
        var paramsByProp = properties.ToDictionary(p => p, _ => null as ParameterInfo);

        var paramDefaultValues = new List<string>();
        var propDefaultValues = properties.ToDictionary(p => p, p => "args." + p.Name);
        foreach (var param in ctor.GetParameters())
        {
            var property = properties.FirstOrDefault(p => p.Name.Equals(param.Name, StringComparison.OrdinalIgnoreCase));

            if (property == null && ModelSerializer.ParamFixes.TryGetValue(param.Name!, out var fix))
            {
                property = properties.FirstOrDefault(p => p.Name.Equals(fix, StringComparison.OrdinalIgnoreCase));
            }

            var defaultValue = "default";

            if (property == null)
            {
                if (param.ParameterType != typeof(ObjectId) && type != typeof(CreateLightningEffectModel))
                {
                    ModHelper.Warning($"Found no match for param {param.Name} on {type.RealFullName}");
                }

                if (type == typeof(CreateLightningEffectModel))
                {
                    defaultValue = param.Name switch
                    {
                        "displayPath1Small" => "args.displayPaths[0]",
                        "displayPath2Small" => "args.displayPaths[1]",
                        "displayPath3Small" => "args.displayPaths[2]",
                        "displayPath1Medium" => "args.displayPaths[3]",
                        "displayPath2Medium" => "args.displayPaths[4]",
                        "displayPath3Medium" => "args.displayPaths[5]",
                        "displayPath1Large" => "args.displayPaths[6]",
                        "displayPath2Large" => "args.displayPaths[7]",
                        "displayPath3Large" => "args.displayPaths[8]",
                        "displayLength1Small" => "args.displayLengths[0]",
                        "displayLength2Small" => "args.displayLengths[1]",
                        "displayLength3Small" => "args.displayLengths[2]",
                        "displayLength1Medium" => "args.displayLengths[3]",
                        "displayLength2Medium" => "args.displayLengths[4]",
                        "displayLength3Medium" => "args.displayLengths[5]",
                        "displayLength1Large" => "args.displayLengths[6]",
                        "displayLength2Large" => "args.displayLengths[7]",
                        "displayLength3Large" => "args.displayLengths[8]",
                        _ => "default"
                    };
                }
            }
            else
            {
                paramsByProp[property] = param;
                remainingProperties.Remove(property);

                defaultValue = $"args.{property.Name}";

                if (param.ParameterType.IsIl2CppNullable())
                {
                    defaultValue = $"{param.ParameterType.RealFullName}.Unbox({defaultValue})";
                }
                propDefaultValues[property] = defaultValue;
            }

            paramDefaultValues.Add(defaultValue);
        }


        var propertyDefaultValues = new Dictionary<PropertyInfo, string>();
        foreach (var prop in properties)
        {
            var param = paramsByProp[prop];

            var defaultValue = "default";
            var propType = prop.PropertyType;

            var usingOverride = false;
            foreach (var ((t, key), overrideValue) in DefaultValueOverrides)
            {
                if (type.IsAssignableTo(t) && prop.Name == key)
                {
                    defaultValue = overrideValue;
                    usingOverride = true;
                }
            }

            if (!usingOverride)
            {
                if (propType == typeof(PrefabReference) ||
                    propType == typeof(AudioClipReference) ||
                    propType == typeof(SpriteReference) ||
                    propType == typeof(AudioSourceReference) ||
                    propType == typeof(AnimationClipReference))
                {
                    defaultValue = $$"""new {{propType.RealFullName}} { guidRef = "" }""";
                }
                else if (param?.HasDefaultValue == true &&
                         !propType.IsIl2CppNullable() &&
                         !param.ParameterType.IsIl2CppNullable())
                {
                    defaultValue = DefaultValue(param.DefaultValue);
                }
                else if (propType == typeof(string))
                {
                    defaultValue = "\"\"";
                }
                else if (propType == typeof(int) ||
                         propType == typeof(int?) ||
                         propType == typeof(long) ||
                         propType == typeof(long?) ||
                         propType == typeof(float) ||
                         propType == typeof(float?) ||
                         propType == typeof(double) ||
                         propType == typeof(double?))
                {
                    defaultValue = "0";
                }
            }

            propertyDefaultValues[prop] = defaultValue;

            if (propType.IsIl2CppNullable())
            {
                propDefaultValues[prop] =
                    $"{propType.RealFullName}.Unbox({propDefaultValues[prop]}{(propType.GenericTypeArguments.First() is {IsValueType: true} ? "!.Value" : "")})";
            }
        }


        var propertyArgTypes = new Dictionary<PropertyInfo, string>();
        foreach (var prop in properties)
        {
            var argType = prop.PropertyType.RealFullName;
            var paramType = paramsByProp[prop]?.ParameterType;
            if (prop.PropertyType == typeof(Il2CppStringArray))
            {
                argType = "string[]";
            }
            else if (prop.PropertyType.IsGenericType)
            {
                var baseType = prop.PropertyType.GetGenericTypeDefinition();

                if (baseType.IsAssignableTo(typeof(Il2CppArrayBase)))
                {
                    var genType = prop.PropertyType.GenericTypeArguments.First();
                    if (baseType == typeof(Il2CppArrayBase<>))
                    {
                        argType = argType.Replace(nameof(Il2CppArrayBase), genType.IsValueType || genType.IsIl2CppValueType()
                            ? nameof(Il2CppStructArray<>)
                            : nameof(Il2CppReferenceArray<>));
                    }
                    else
                    {
                        argType = genType.RealFullName + "[]";
                    }
                }
                else if (prop.PropertyType.IsIl2CppNullable())
                {
                    var nullableType = prop.PropertyType.GenericTypeArguments.First();
                    argType = nullableType.RealFullName + (nullableType.IsValueType ? "?" : "");
                }
            }
            else if (prop.PropertyType == typeof(TargetType) && paramType == typeof(string))
            {
                argType = "string";
            }

            propertyArgTypes[prop] = argType;
        }

        ModHelper.Msg($"Generated {type.RealFullName}");

        return $$"""
                 public static partial class Create{{name}}Ext
                 {
                     extension({{type.RealFullName}}) 
                     {
                         public static {{type.RealFullName}} Create() => new Args();
                         public static {{type.RealFullName}} Create(Args args) => args;
                     }

                     public partial class Args : ModelArgs<{{type.RealFullName}}>
                     {
                         {{properties
                             .Where(p => p.Name != "name")
                             .Select(p => $$"""public {{propertyArgTypes[p]}} {{p.Name}} { get; set; } = {{propertyDefaultValues[p]}};""")
                             .Join(delimiter: "\n        ")}}
                         
                         public static implicit operator {{type.RealFullName}}(Args args)
                         {
                             var result = new {{type.RealFullName}}({{paramDefaultValues.Join(delimiter: ", ")}});
                             {{remainingProperties.Select(p => $"if (args.{p.Name} != default) result.{p.Name} = {propDefaultValues[p]};").Join(delimiter: "\n            ")}}
                             args.OnCreate(result);
                             return result;   
                         }
                     }
                 }
                 """;
    }

    private static string DefaultValue(object obj) => obj switch
    {
        string s => $"\"{s}\"",
        int i => $"{i}",
        long l => $"{l}l",
        float f => $"{f}f",
        double d => $"{d}d",
        bool b => $"{b.ToString().ToLower()}",
        Enum e => $"{e.GetType().RealFullName}.{e.ToString()}",
        _ => "default"
    };

}