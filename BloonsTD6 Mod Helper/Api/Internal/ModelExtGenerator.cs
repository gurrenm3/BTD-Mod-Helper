using System;
using System.Collections.Generic;
using System.IO;
using Il2CppAssets.Scripts.Models.Artifacts;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Pets;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace BTD_Mod_Helper.Api.Internal;

internal class ModelExtGenerator
{
    private static string Folder => Path.Combine(MelonMain.ModHelperSourceFolder,
        "BloonsTD6 Mod Helper", "Extensions", "BehaviorExtensions");

    private static readonly IEnumerable<Type> ModelTypes =
    [
        typeof(AbilityModel),
        typeof(AddBehaviorToBloonModel),
        typeof(AttackModel),
        typeof(ItemArtifactModel),
        typeof(BoostArtifactModel),
        typeof(MapArtifactModel),
        typeof(BloonModel),
        typeof(EmissionModel),
        typeof(PetModel),
        typeof(PowerModel),
        typeof(ProjectileModel),
        typeof(TowerModel),
        typeof(WeaponModel)
    ];

    private static readonly Dictionary<Type, string> ClassNameOverrides = new()
    {
        {typeof(ItemArtifactModel), "ArtifactModel"},
        {typeof(BoostArtifactModel), "ArtifactModel"},
        {typeof(MapArtifactModel), "ArtifactModel"}
    };

    public static void GenerateAll()
    {
        foreach (var type in ModelTypes)
        {
            var className = ClassNameOverrides.GetValueOrDefault(type, type.Name);

            var text =
                $$"""
                using System.Collections.Generic;
                using System.Diagnostics.CodeAnalysis;
                using System.Linq;
                using BTD_Mod_Helper.Api.Helpers;
                using Il2CppAssets.Scripts.Models;
                using {{type.Namespace}};

                namespace BTD_Mod_Helper.Extensions;

                /// <summary>
                /// Extensions for {{type.Name}}s
                /// </summary>
                public static partial class {{className}}BehaviorExt
                {
                    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
                    public static bool HasBehavior<T>(this {{type.Name}} model) where T : Model => 
                        ModelBehaviorExt.HasBehavior<T>(model);
                            
                    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,out T)" />
                    public static bool HasBehavior<T>(this {{type.Name}} model, [NotNullWhen(true)] out T behavior) where T : Model =>
                        ModelBehaviorExt.HasBehavior<T>(model, out behavior);
                        
                    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model,string,out T)" />
                    public static bool HasBehavior<T>(this {{type.Name}} model, string nameContains, [NotNullWhen(true)] out T behavior) where T : Model =>
                        ModelBehaviorExt.HasBehavior<T>(model, nameContains, out behavior);

                    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
                    public static T GetBehavior<T>(this {{type.Name}} model) where T : Model => 
                        ModelBehaviorExt.GetBehavior<T>(model);

                    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
                    public static T GetBehavior<T>(this {{type.Name}} model, int index) where T : Model =>
                        ModelBehaviorExt.GetBehavior<T>(model, index);

                    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
                    public static T GetBehavior<T>(this {{type.Name}} model, string nameContains) where T : Model =>
                        ModelBehaviorExt.GetBehavior<T>(model, nameContains);

                    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
                    public static List<T> GetBehaviors<T>(this {{type.Name}} model) where T : Model =>
                        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

                    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,Il2CppAssets.Scripts.Models.Model)" />
                    public static void AddBehavior<T>(this {{type.Name}} model, T behavior) where T : Model => 
                        ModelBehaviorExt.AddBehavior(model, behavior);

                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
                    public static void RemoveBehavior<T>(this {{type.Name}} model) where T : Model => 
                        ModelBehaviorExt.RemoveBehavior<T>(model);

                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
                    public static void RemoveBehavior<T>(this {{type.Name}} model, T behavior) where T : Model => 
                        ModelBehaviorExt.RemoveBehavior(model, behavior);
                    
                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,int)" />
                    public static void RemoveBehavior<T>(this {{type.Name}} model, int index) where T : Model =>
                        ModelBehaviorExt.RemoveBehavior<T>(model, index);
                    
                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model,string)" />
                    public static void RemoveBehavior<T>(this {{type.Name}} model, string nameContains) where T : Model =>
                        ModelBehaviorExt.RemoveBehavior<T>(model, nameContains);
                    
                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
                    public static void RemoveBehaviors<T>(this {{type.Name}} model) where T : Model => 
                        ModelBehaviorExt.RemoveBehaviors<T>(model);

                    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
                    public static void RemoveBehaviors(this {{type.Name}} model) => 
                        ModelBehaviorExt.RemoveBehaviors(model);

                    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior(Il2CppAssets.Scripts.Models.Model,BTD_Mod_Helper.Api.Helpers.ModelHelper)"/>
                    public static void AddBehavior(this {{type.Name}} model, ModelHelper behavior) => 
                        ModelBehaviorExt.AddBehavior(model, behavior);
                }
                """;

            var filePath = Path.Combine(Folder, type.Name + "BehaviorExt.cs");

            File.WriteAllText(filePath, text);
        }
    }
}