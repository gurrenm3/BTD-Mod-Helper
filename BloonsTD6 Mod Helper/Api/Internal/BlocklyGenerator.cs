using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Helpers;
using FuzzySharp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models.Towers.Mutators;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common;
using Il2CppSystem.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using Object = Il2CppSystem.Object;
using ValueType = Il2CppSystem.ValueType;
namespace BTD_Mod_Helper.Api.Internal;

internal static class BlocklyGenerator
{
    private static readonly Type[] BaseTypes =
    {
        typeof(TowerModel), typeof(UpgradeModel)
    };

    private static readonly Type[] StopBefore =
    {
        typeof(Object), typeof(ValueType)
    };

    private static readonly Type[] GenericArrayTypes =
    {
        typeof(Il2CppStructArray<>), typeof(Il2CppReferenceArray<>), typeof(Il2CppArrayBase<>),
        typeof(Il2CppSystem.Collections.Generic.List<>)
    };

    private static readonly string[] IgnoreMembers =
    {
        "name", "checkedImplementationType", "implementationType", "childDependants", "isWrapped"
    };

    private static readonly Dictionary<Type, int> Types = new();
    private static readonly HashSet<Type> ExtraTypes = new();
    private static readonly HashSet<Type> ArrayTypes = new();
    private static readonly HashSet<Type> DictionaryTypes = new();

    internal static void Generate(string folder)
    {
        var blocks = new List<JObject>();

        ModHelper.Msg("Getting types...");
        GetAllTypes();
        ModHelper.Msg("Finished getting types");
        ArrayTypes.Clear();

        ModHelper.Msg("Generating blocks...");
        blocks.AddRange(BaseTypes.Select(CreateBlock));
        blocks.AddRange(Types.Keys.OrderByDescending(type => Types[type]).Select(CreateBlock));
        blocks.AddRange(ExtraTypes.Select(CreateBlock));
        blocks.AddRange(ArrayTypes.Select(CreateArrayBlock));
        blocks.AddRange(DictionaryTypes.Select(CreateDictionaryBlock));
        File.WriteAllText(Path.Combine(folder, "blocks.json"), new JArray(blocks).ToString(Formatting.Indented));
        ModHelper.Msg("Finished generating blocks");

        ModHelper.Msg("Generating resources...");
        File.WriteAllText(Path.Combine(folder, "prefab-references.json"),
            CreateReferenceMap(typeof(PrefabReference)).ToString(Formatting.Indented));
        File.WriteAllText(Path.Combine(folder, "audio-source-references.json"),
            CreateReferenceMap(typeof(AudioSourceReference)).ToString(Formatting.Indented));
        File.WriteAllText(Path.Combine(folder, "sprite-references.json"),
            CreateReferenceMap(typeof(SpriteReference)).ToString(Formatting.Indented));
        File.WriteAllText(Path.Combine(folder, "towers.json"), GetTowerIds().ToString(Formatting.Indented));
        File.WriteAllText(Path.Combine(folder, "upgrades.json"), GetUpgradeIds().ToString(Formatting.Indented));
        File.WriteAllText(Path.Combine(folder, "all-towers.json"), GetAllTowers().ToString(Formatting.Indented));
        ModHelper.Msg("Finished generating resources");

        ModHelper.Msg($"Saved jsons to {folder}");
    }

    private static JObject CreateBaseBlock(Type type) => new()
    {
        ["type"] = type.BlockName(),
        ["output"] = GetOutputForType(type),
        ["category"] = GetCategory(type, out var subCategory, out var color),
        ["subcategory"] = subCategory,
        ["colour"] = color,
        ["message0"] = $"%1{type.Name}",
        ["args0"] = new JArray
        {
            new JObject
            {
                ["type"] = "field_hidden",
                ["name"] = "$type",
                ["value"] = type.FullTypeName()
            }
        }
    };

    private static JObject CreateBlock(Type type)
    {
        var block = CreateBaseBlock(type);
        if (BaseTypes.Contains(type))
        {
            block["hat"] = "cap";
            block["extensions"] = new JArray {"toggle_hat"};
        }
        if (type.IsAssignableTo(typeof(Model)))
        {
            block["message0"] += "%2";
            ((JArray) block["args0"])!.Add(new JObject
            {
                ["type"] = "field_input",
                ["name"] = "name",
                ["text"] = ""
            });
        }

        var members = type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var ctor = ModelSerializer.GetMainConstructor(type, members.Select(info => info.Name), true);

        var il2CppType = Il2CppType.From(type);
        var badFields = il2CppType.GetProperties().Select(info => info.Name)
            .Concat(il2CppType.GetFields().Where(info => info.IsNotSerialized).Select(info => info.Name))
            .ToList();

        var rows = new List<Tuple<MemberInfo, ParameterInfo, JObject>>();

        foreach (var member in members.OrderBy(info =>
                     info is FieldInfo or PropertyInfo && info.GetUnderlyingType().IsIl2CppArray(out _)))
        {
            if (IncludeMember(member, badFields, ctor, out var param))
            {
                var arg = GetArgForType(member.GetUnderlyingType(), member.Name, param?.DefaultValue, type);
                rows.Add(new Tuple<MemberInfo, ParameterInfo, JObject>(member, param, arg));
                if (type == typeof(UpgradeModel) && member.Name == nameof(UpgradeModel.tier))
                {
                    arg["offset"] = 1;
                }
            }
        }

        var orderedRows = rows
            .OrderBy(row => row.Item3.Value<string>("type")?.StartsWith("input_"))
            .ThenBy(row => row.Item1.GetUnderlyingType().IsIl2CppArray(out _))
            .ToArray();

        if (type.IsValueType() && orderedRows.All(row => row.Item3.Value<string>("type") == "field_number"))
        {
            block["message1"] = orderedRows.Select((row, i) => $"{row.Item1.Name} %{i + 1}").Join(delimiter: " ");
            block["args1"] = new JArray(orderedRows.Select(row => row.Item3));
        }
        else
        {
            var row = 1;

            foreach (var (member, param, arg) in orderedRows)
            {
                var isArray = member.GetUnderlyingType().IsIl2CppArray(out _);

                if (param is {HasDefaultValue: true} && AllowOptional(type, member.Name))
                {
                    if (!block.ContainsKey("mutator"))
                    {
                        block["mutator"] = "optional_rows";
                        block["mutatorOptions"] = new JObject
                        {
                            ["optional"] = new JObject()
                        };
                    }
                    block["mutatorOptions"]!["optional"]![row.ToString()] = member.Name;
                    if (isArray)
                    {
                        block["mutatorOptions"]!["optional"]![(row + 1).ToString()] = member.Name;
                    }
                }

                if (isArray)
                {
                    block["message" + row] = $"{member.Name}";
                    block["args" + row] = new JArray();
                    row++;
                    block["message" + row] = "%1";
                }
                else
                {
                    block["message" + row] = $"{member.Name}%1";
                }

                block["args" + row] = new JArray
                {
                    arg
                };

                row++;
            }
        }

        return block;
    }

    private static JObject CreateArrayBlock(Type type) => new()
    {
        ["type"] = ArrayBlockName(type),
        ["previousStatement"] = ArrayBlockName(type),
        ["category"] = GetCategory(type, out var subCategory, out var color),
        ["subcategory"] = subCategory,
        ["colour"] = color,
        ["message0"] = "%1%2",
        ["args0"] = new JArray
        {
            new JObject
            {
                ["type"] = "field_plus"
            },
            new JObject
            {
                ["type"] = "field_dropdown",
                ["name"] = "$data",
                ["options"] = new JArray
                {
                    new JArray {"null", "null"},
                    new JArray {"empty", "[]"}
                }
            }
        },
        ["message1"] = "%1%2%3",
        ["args1"] = new JArray
        {
            new JObject
            {
                ["type"] = "field_plus"
            },
            new JObject
            {
                ["type"] = "field_minus"
            },
            GetArgForType(type, "i")
        },
        ["data"] = "BLOCKLY_ARRAY",
        ["mutator"] = "plus_minus_rows"
    };

    private static JObject CreateDictionaryBlock(Type type) => new()
    {
        ["type"] = DictionaryBlockName(type.GenericTypeArguments[0], type.GenericTypeArguments[1]),
        ["previousStatement"] = DictionaryBlockName(type.GenericTypeArguments[0], type.GenericTypeArguments[1]),
        ["message0"] = "%1%2%3",
        ["args0"] = new JArray
        {
            new JObject
            {
                ["type"] = "field_hidden",
                ["name"] = "$type",
                ["value"] = type.FullTypeName()
            },
            new JObject
            {
                ["type"] = "field_plus"
            },
            new JObject
            {
                ["type"] = "field_dropdown",
                ["name"] = "$data",
                ["options"] = new JArray
                {
                    new JArray {"null", "null"},
                    new JArray {"empty", "{}"}
                }
            }
        },
        ["message1"] = "%1%2%3%4%5",
        ["args1"] = new JArray
        {
            new JObject
            {
                ["type"] = "field_hidden",
                ["name"] = "$type",
                ["value"] = type.FullTypeName()
            },
            new JObject
            {
                ["type"] = "field_plus"
            },
            new JObject
            {
                ["type"] = "field_minus"
            },
            GetArgForType(type.GenericTypeArguments[0], "key"),
            GetArgForType(type.GenericTypeArguments[1], "value")
        },
        ["data"] = "BLOCKLY_DICTIONARY",
        ["mutator"] = "plus_minus_rows"
    };

    private static JObject CreateReferenceMap(Type ofType)
    {
        var map = new JObject();
        var resourceLocationMap = Addressables.ResourceLocators.First().Cast<ResourceLocationMap>();

        foreach (var (o, locations) in resourceLocationMap.Locations)
        {
            var key = o.ToString();
            if (map.ContainsKey(key)) continue;

            if (!Guid.TryParse(key, out _)) continue;

            var resources = locations
                .Cast<Il2CppReferenceArray<IResourceLocation>>()
                .Where(location => location.InternalId != key && location.InternalId.StartsWith("Assets/"));

            foreach (var resource in resources)
            {
                Type type = null;
                var name = resource.InternalId;

                if (name.Contains("SoundPrefabs") && !name.Contains("Powers/") && !name.Contains("Bloons/"))
                {
                    type = typeof(AudioSourceReference);
                }
                else if (name.EndsWith(".prefab") && name.Contains("Monkeys/"))
                {
                    type = typeof(PrefabReference);
                }
                else if (name.EndsWith(".png") &&
                         (name.Contains("InstaMonkeyIcons") ||
                          name.Contains("MonkeyPortraits") ||
                          name.Contains("UpgradeIcons")))
                {
                    type = typeof(SpriteReference);
                }

                if (type == null || type != ofType) continue;

                map[key] = name
                    .Replace("Assets/Generated/", "")
                    .Replace("Assets/", "")
                    .Replace("ResizedImages/", "")
                    .Replace("SoundPrefabs/", "")
                    .RegexReplace(@"\.(.*)", "");
            }
        }

        return map;
    }

    private static JObject GetTowerIds()
    {
        var jobject = new JObject();
        foreach (var tower in Game.instance.model.towers.Where(model => model.IsBaseTower && model.IsVanillaTower())
                     .OrderBy(model => model.isSubTower))
        {
            jobject[tower.baseId] = tower.towerSet.ToString();
        }
        return jobject;
    }

    private static JObject GetUpgradeIds()
    {
        var jObject = new JObject();
        var local = LocalizationManager.Instance;

        foreach (var tower in Game.instance.model.towers.Where(tower => !tower.isSubTower && tower.IsVanillaTower()))
        {
            foreach (var upgradeId in tower.appliedUpgrades)
            {
                if (jObject.ContainsKey(upgradeId)) continue;

                var upgrade = Game.instance.model.GetUpgrade(upgradeId);
                var displayName = local.GetTextEnglish(upgrade.localizedNameOverride.NullIfEmpty() ?? upgrade.name);

                var upgradeEntry = jObject[upgradeId] = new JObject
                {
                    ["towerId"] = tower.baseId,
                    ["towerName"] = local.GetTextEnglish(tower.baseId),
                    ["towerSet"] = tower.towerSet.ToString()
                };

                if (upgradeId != displayName)
                {
                    upgradeEntry["displayName"] = displayName;
                }
            }
        }

        return jObject;
    }

    private static JObject GetAllTowers()
    {
        var jobject = new JObject();
        foreach (var tower in Game.instance.model.towers.Where(model => model.IsVanillaTower())
                     .OrderBy(model => model.isSubTower))
        {
            jobject[tower.name] = new JObject
            {
                ["towerSet"] = tower.towerSet.ToString(),
                ["path"] = tower.baseId + "/" + tower.name + ".json",
                ["appliedUpgrades"] = new JArray(tower.appliedUpgrades.Select(LocalizationManager.Instance.GetTextEnglish))
            };
        }
        return jobject;
    }

    private static string GetCategory(Type type, out string subCategory, out int color)
    {
        subCategory = null;
        if (BaseTypes.Contains(type))
        {
            color = 0;
            return "Base";
        }
        if (type.IsAssignableTo(typeof(TowerBehaviorModel)) || type.IsAssignableTo(typeof(ApplyModModel)))
        {
            color = 30;
            if (type.IsAssignableTo(typeof(SupportModel)))
            {
                color = 33;
                subCategory = "Support";
            }
            else if (type.Name.Contains("CreateEffect"))
            {
                color = 36;
                subCategory = "Effect";
            }
            else if (type.Name.Contains("CreateSound"))
            {
                color = 39;
                subCategory = "Sound";
            }
            else if (type.Name.Contains("Movement"))
            {
                color = 42;
                subCategory = "Movement";
            }
            return "Tower Behaviors";
        }
        if (type.IsAssignableTo(typeof(AttackBehaviorModel)) || type.IsAssignableTo(typeof(WeaponModel)))
        {
            color = 60;
            if (type.IsAssignableTo(typeof(TargetSupplierModel)))
            {
                color = 63;
                subCategory = "Target Suppliers";
            }
            return "Attack Behaviors";
        }
        if (type.IsAssignableTo(typeof(WeaponBehaviorModel)) || type.IsAssignableTo(typeof(ProjectileModel)))
        {
            color = 90;
            return "Weapon Behaviors";
        }
        if (type.IsAssignableTo(typeof(EmissionModel)))
        {
            color = 100;
            subCategory = "Emissions";
            return "Weapon Behaviors";
        }
        if (type.IsAssignableTo(typeof(EmissionBehaviorModel)))
        {
            color = 110;
            subCategory = "Emission Behaviors";
            return "Weapon Behaviors";
        }
        if (type.IsAssignableTo(typeof(ProjectileBehaviorModel)))
        {
            color = 120;
            if (type.IsAssignableTo(typeof(DamageModel)) || type.IsAssignableTo(typeof(DamageModifierModel)))
            {
                color = 123;
                subCategory = "Support";
            }
            else if (type.Name.Contains("CreateEffect"))
            {
                color = 126;
                subCategory = "Effect";
            }
            else if (type.Name.Contains("CreateSound"))
            {
                color = 129;
                subCategory = "Sound";
            }
            else if (type.Name.StartsWith("Travel"))
            {
                color = 133;
                subCategory = "Travel";
            }
            return "Projectile Behaviors";
        }
        if (type.IsAssignableTo(typeof(AbilityBehaviorModel)))
        {
            color = 150;
            subCategory = "Ability Behaviors";
            return "Other Behaviors";
        }
        if (type.IsAssignableTo(typeof(BloonBehaviorModel)))
        {
            color = 160;
            subCategory = "Bloon Behaviors";
            return "Other Behaviors";
        }
        if (type.IsAssignableTo(typeof(PetBehaviorModel)))
        {
            color = 170;
            subCategory = "Pet Behaviors";
            return "Other Behaviors";
        }
        if (type.IsAssignableTo(typeof(FilterModel)))
        {
            color = 180;
            return "Filters";
        }
        if (type.IsAssignableTo(typeof(TowerFilterModel)))
        {
            color = 190;
            subCategory = "Tower Filters";
            return "Filters";
        }
        if (type.IsAssignableTo(typeof(Model)))
        {
            color = 210;
            if (type.IsAssignableTo(typeof(TowerMutatorModel)))
            {
                color = 220;
                subCategory = "Mutators";
            }
            return "Misc Models";
        }

        color = 240;
        return "Other";
    }

    private static JArray GetOutputForType(Type type)
    {
        var array = new JArray
        {
            type.BlockName()
        };
        var parent = type;
        while ((parent = parent.BaseType) != null && !StopBefore.Contains(parent))
        {
            array.Insert(0, parent.BlockName());
        }
        return array;
    }


    private static JObject GetArgForType(Type rowType, string name, object defaultValue = null, Type parentType = null)
    {
        var arg = new JObject
        {
            ["name"] = name
        };

        if (rowType == typeof(int) || rowType == typeof(short) || rowType == typeof(ushort) || rowType == typeof(long))
        {
            arg["type"] = "field_number";
            arg["value"] = JToken.FromObject(defaultValue ?? 0);
            arg["precision"] = 1;
        }
        else if (rowType == typeof(float))
        {
            arg["type"] = "field_number";
            arg["value"] = JToken.FromObject(defaultValue ?? 0);
        }
        else if (rowType == typeof(bool))
        {
            arg["type"] = "field_dropdown";
            arg["options"] = new JArray(new[]
            {
                new JArray {"false", "false"},
                new JArray {"true", "true"}
            }.OrderByDescending(array => array[1].ToString() == defaultValue?.ToString()?.ToLower()));
        }
        else if (rowType == typeof(string))
        {
            if (IsSpecialString(parentType, name, out var check))
            {
                arg["type"] = "input_value";
                arg["check"] = new JArray {"string", check};
                arg["shadow"] = new JObject
                {
                    ["type"] = "string",
                    ["data"] = new JValue(defaultValue?.ToString() ?? "null")
                };
            }
            else
            {
                arg["type"] = "field_input";
                arg["text"] = new JValue(defaultValue?.ToString() ?? "null");
                arg["spellcheck"] = false;
            }
        }
        else if (rowType.IsIl2CppArray(out var elementType))
        {
            arg["type"] = "input_statement";

            if (elementType == typeof(string) && IsSpecialString(parentType, name, out var newElementType))
            {
                arg["check"] = newElementType + "[]";
                arg["shadow"] = new JObject
                {
                    ["type"] = newElementType + "[]"
                };
            }
            else
            {
                arg["check"] = elementType.ArrayBlockName();
                arg["shadow"] = new JObject
                {
                    ["type"] = elementType.ArrayBlockName()
                };

                ArrayTypes.Add(elementType);
            }

        }
        else if (rowType.IsIl2CppNullable() && rowType.GenericTypeArguments[0] == typeof(bool))
        {
            arg["type"] = "field_dropdown";
            arg["options"] = new JArray(new[]
            {
                new JArray {"null", "null"},
                new JArray {"false", "false"},
                new JArray {"true", "true"}
            }.OrderByDescending(array => array[1].ToString() == defaultValue?.ToString()?.ToLower()));
        }
        else if (rowType.IsIl2CppDictionary())
        {
            var keyType = rowType.GenericTypeArguments[0];
            var valueType = rowType.GenericTypeArguments[1];
            arg["type"] = "input_statement";
            arg["check"] = DictionaryBlockName(keyType, valueType);
            arg["shadow"] = new JObject
            {
                ["type"] = DictionaryBlockName(keyType, valueType)
            };

            DictionaryTypes.Add(rowType);
        }
        else if (rowType.IsEnum)
        {
            if (rowType.GetCustomAttribute<FlagsAttribute>() != null && AllowMultiDropdown(rowType))
            {
                arg["type"] = "field_multi_dropdown";
                arg["bitmap"] = true;
            }
            else
            {
                arg["type"] = "field_dropdown";
            }
            arg["options"] = new JArray(rowType.GetEnumNames()
                .Select((name, i) => new JArray
                {
                    name,
                    Convert.ChangeType(rowType.GetEnumValues().GetValue(i), rowType.GetEnumUnderlyingType())!.ToString()
                })
                .OrderByDescending(array => array[1].ToString() == defaultValue?.ToString()?.ToLower()));
        }
        else
        {
            if (!Types.ContainsKey(rowType) && !BaseTypes.Contains(rowType) && !Il2CppType.From(rowType).IsAbstract)
            {
                ExtraTypes.Add(rowType);
            }

            arg["type"] = "input_value";
            arg["check"] = rowType.BlockName();
            arg["shadow"] = new JObject
            {
                ["type"] = "Shadow",
                ["data"] = rowType.Name
            };
        }

        return arg;
    }

    private static bool IncludeMember(MemberInfo member, IEnumerable<string> badFields,
        ConstructorInfo ctor, out ParameterInfo param)
    {
        param = null;

        if (IgnoreMembers.Contains(member.Name) ||
            badFields.Contains(member.Name) ||
            member.Name.StartsWith("_")) return false;

        var rowType = member switch
        {
            PropertyInfo property when property.SetMethod != null => property.PropertyType,
            FieldInfo {IsLiteral: false, IsInitOnly: false} field => field.FieldType,
            _ => null
        };

        if (rowType == null || rowType.IsAssignableTo(typeof(BehaviorMutator))) return false;

        param = GetParameter(ctor, member);

        return param != null;
    }

    private static ParameterInfo GetParameter(ConstructorInfo ctor, MemberInfo member)
    {
        if (ctor == null) return null;

        var parameters = ctor.GetParameters().ToDictionary(info => info.Name!);

        if (parameters.TryGetValue(member.Name, out var param)) return param;

        foreach (var (paramName, parameter) in parameters)
        {
            if (string.Equals(paramName, member.Name, StringComparison.InvariantCultureIgnoreCase) ||
                ModelSerializer.ParamFixes.TryGetValue(paramName, out var memberName) && memberName == member.Name)
            {
                return parameter;
            }
        }

        return null;
    }

    private static string BlockName(this Type type) =>
        type.IsNested ? type.DeclaringType!.GetName() + "_" + type.GetName() : type.GetName();

    private static string FullTypeName(this Type type) =>
        $"{type.FullName!.Replace("Il2CppAssets", "Assets")}, {type.Assembly.GetName().Name}";

    private static string ArrayBlockName(this Type type) => type.BlockName() + "[]";

    private static string DictionaryBlockName(Type key, Type value) => key.BlockName() + "<>" + value.BlockName();

    private static bool IsIl2CppArray(this Type type, out Type elementType)
    {
        elementType = null;
        if (type == typeof(Il2CppStringArray))
        {
            elementType = typeof(string);
        }
        else if (type.IsGenericType && GenericArrayTypes.Contains(type.GetGenericTypeDefinition()))
        {
            elementType = type.GenericTypeArguments.First();
        }

        return elementType != null;
    }

    private static bool IsValueType(this Type type) => type.IsValueType || type.IsIl2CppValueType();

    private static bool AllowOptional(Type type, string key) =>
        !type.IsValueType() &&
        !type.IsAssignableTo(typeof(UpgradePathModel)) &&
        !(type.IsAssignableTo(typeof(FilterModel)) && key == "isActive");

    internal static void GetAllTypes(GameModel gameModel = null)
    {
        gameModel ??= InGame.instance?.bridge?.Model ?? Game.instance.model;
        foreach (var tower in gameModel.towers)
        {
            tower.GetDescendants<Model>().ForEach(model =>
            {
                var type = model.GetIl2CppType().GetNonIl2CppType();
                if (!BaseTypes.Contains(type) && !Types.TryAdd(type, 1))
                {
                    Types[type]++;
                }
            });
        }
        foreach (var type in typeof(Model).Assembly.GetTypes().Where(t =>
                     t.IsAssignableTo(typeof(Model)) &&
                     !t.IsAssignableTo(typeof(ModModel)) &&
                     !t.IsAssignableTo(typeof(MutatorModModel)) &&
                     t.Namespace!.Contains("Scripts.Models.Towers") &&
                     !BaseTypes.Contains(t) &&
                     !Il2CppType.From(t).IsAbstract))
        {
            Types.TryAdd(type, 1);
        }
    }

    private static Type GetNonIl2CppType(this Il2CppSystem.Type type) =>
        Type.GetType(type.AssemblyQualifiedName.Replace("Assets.", "Il2CppAssets."));

    private static string GetName(this Type type)
    {
        if (type == typeof(int)) return "int";
        if (type == typeof(short)) return "short";
        if (type == typeof(long)) return "long";
        if (type == typeof(float)) return "float";
        if (type == typeof(double)) return "double";
        if (type == typeof(char)) return "char";
        if (type == typeof(bool)) return "bool";
        if (type == typeof(sbyte)) return "sbyte";
        if (type == typeof(byte)) return "byte";
        if (type == typeof(ushort)) return "ushort";
        if (type == typeof(uint)) return "uint";
        if (type == typeof(ulong)) return "ulong";
        if (type == typeof(decimal)) return "decimal";
        if (type == typeof(object)) return "object";
        if (type == typeof(string)) return "string";

        return type.FullName;
    }

    private static bool IsSpecialString(Type type, string name, out string check)
    {
        check = null;
        if (type == null) return false;

        if (type.IsAssignableTo(typeof(UpgradePathModel)) && name == nameof(UpgradePathModel.tower))
            check = "Tower";

        if (type.IsAssignableTo(typeof(UpgradePathModel)) && name == nameof(UpgradePathModel.upgrade))
            check = "Upgrade";

        if (type.IsAssignableTo(typeof(TowerModel)) && name == nameof(TowerModel.appliedUpgrades))
            check = "Upgrade";

        if (type.IsAssignableTo(typeof(FilterInBaseTowerIdModel)) && name == nameof(FilterInBaseTowerIdModel.baseIds))
            check = "Tower";

        return check != null;
    }

    private static bool AllowMultiDropdown(Type type) => type != typeof(TowerSet) && type != typeof(DisplayCategory);
}