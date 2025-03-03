using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Artifacts;
using Il2CppAssets.Scripts.Models.Artifacts.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Behavior extensions for ItemArtifactModels and BoostArtifactModels
/// </summary>
public static class ArtifactModelBehaviorExt
{
    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static bool HasBehavior<T>(this ItemArtifactModel model) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.HasBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static T GetBehavior<T>(this ItemArtifactModel model) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    public static List<T> GetBehaviors<T>(this ItemArtifactModel model) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior" />
    public static void AddBehavior<T>(this ItemArtifactModel model, T behavior) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    public static void RemoveBehavior<T>(this ItemArtifactModel model, T behavior) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors<T>(this ItemArtifactModel model) where T : ItemArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors(this ItemArtifactModel model) => ModelBehaviorExt.RemoveBehaviors(model);


    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static bool HasBehavior<T>(this BoostArtifactModel model) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.HasBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static T GetBehavior<T>(this BoostArtifactModel model) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    public static List<T> GetBehaviors<T>(this BoostArtifactModel model) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior" />
    public static void AddBehavior<T>(this BoostArtifactModel model, T behavior) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static void RemoveBehavior<T>(this BoostArtifactModel model) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    public static void RemoveBehavior<T>(this BoostArtifactModel model, T behavior) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors<T>(this BoostArtifactModel model) where T : BoostArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors(this BoostArtifactModel model) => ModelBehaviorExt.RemoveBehaviors(model);


    /// <inheritdoc cref="ModelBehaviorExt.HasBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static bool HasBehavior<T>(this MapArtifactModel model) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.HasBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static T GetBehavior<T>(this MapArtifactModel model) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.GetBehaviors{T}" />
    public static List<T> GetBehaviors<T>(this MapArtifactModel model) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.GetBehaviors<T>(model).ToList();

    /// <inheritdoc cref="ModelBehaviorExt.AddBehavior" />
    public static void AddBehavior<T>(this MapArtifactModel model, T behavior) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.AddBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior{T}(Il2CppAssets.Scripts.Models.Model)" />
    public static void RemoveBehavior<T>(this MapArtifactModel model) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehavior" />
    public static void RemoveBehavior<T>(this MapArtifactModel model, T behavior) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehavior(model, behavior);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors<T>(this MapArtifactModel model) where T : MapArtifactBehaviorModel =>
        ModelBehaviorExt.RemoveBehaviors<T>(model);

    /// <inheritdoc cref="ModelBehaviorExt.RemoveBehaviors{T}" />
    public static void RemoveBehaviors(this MapArtifactModel model) => ModelBehaviorExt.RemoveBehaviors(model);

    /// <summary>
    /// Helper method for ItemArtifacts to easily add BoostArtifactBehaviorModels via InvokeBoostBuffBehaviorModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="boostBehavior">Boost behavior to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific towers</param>
    public static void AddBoostBehavior(this ItemArtifactModel artifact, BoostArtifactBehaviorModel boostBehavior,
        Action<BoostArtifactModel> modifyBoost = null)
    {
        artifact.AddBoostBehaviors([boostBehavior], modifyBoost);
    }

    /// <summary>
    /// Helper method for ItemArtifacts to easily add BoostArtifactBehaviorModels via InvokeBoostBuffBehaviorModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="boostBehaviors">Boost behaviors to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific towers</param>
    public static void AddBoostBehaviors(this ItemArtifactModel artifact,
        IEnumerable<BoostArtifactBehaviorModel> boostBehaviors, Action<BoostArtifactModel> modifyBoost = null)
    {
        var boost = new BoostArtifactModel("", 0, "", boostBehaviors.ToIl2CppReferenceArray(), "", "",
            new SpriteReference(""), "", new Il2CppStringArray(0), false, new Il2CppStructArray<TowerSet>(0), false,
            new Il2CppStructArray<int>(0), false, false);
        modifyBoost?.Invoke(boost);
        var invokeBoost = new InvokeBoostBuffBehaviorModel("", boost);

        artifact.AddBehavior(invokeBoost);
    }

    /// <summary>
    /// Helper method for ItemArtifacts to easily add TowerBehaviors to towers via AddTowerBehaviorsArtifactModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="towerBehavior">Tower behavior to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific towers</param>
    public static void AddTowerBehavior(this ItemArtifactModel artifact, TowerBehaviorModel towerBehavior,
        Action<AddTowerBehaviorsArtifactModel> modifyBoost = null)
    {
        artifact.AddTowerBehaviors([towerBehavior], modifyBoost);
    }

    /// <summary>
    /// Helper method for ItemArtifacts to easily add TowerBehaviors to towers via AddTowerBehaviorsArtifactModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="towerBehaviors">Tower behaviors to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific towers</param>
    public static void AddTowerBehaviors(this ItemArtifactModel artifact,
        IEnumerable<TowerBehaviorModel> towerBehaviors, Action<AddTowerBehaviorsArtifactModel> modifyBoost = null)
    {
        var boost = new AddTowerBehaviorsArtifactModel("", new Il2CppStringArray(0),
            new Il2CppStringArray(0), new Il2CppStringArray(0), new Il2CppStringArray(0),
            new Il2CppStringArray([]), false, new Il2CppStructArray<TowerSet>(0), false,
            new Il2CppStructArray<int>([]), false, false)
        {
            behaviorModels = towerBehaviors.ToIl2CppReferenceArray()
        };
        modifyBoost?.Invoke(boost);

        artifact.AddBehavior(boost);
    }

    /// <summary>
    /// Helper method for ItemArtifacts to easily add ProjectileBehaviors to projectiles via AddProjectileBehaviorsArtifactModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="projectileBehavior">Projectile behavior to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific projectiles</param>
    public static void AddProjectileBehavior(this ItemArtifactModel artifact, ProjectileBehaviorModel projectileBehavior,
        Action<AddProjectileBehaviorsArtifactModel> modifyBoost = null)
    {
        artifact.AddProjectileBehaviors([projectileBehavior], modifyBoost);
    }

    /// <summary>
    /// Helper method for ItemArtifacts to easily add ProjectileBehaviors to projectiles via AddProjectileBehaviorsArtifactModel like many vanilla items do
    /// </summary>
    /// <param name="artifact">this</param>
    /// <param name="projectileBehaviors">Projectile behaviors to add</param>
    /// <param name="modifyBoost">function for modifying the boost, like for filtering it to specific projectiles</param>
    public static void AddProjectileBehaviors(this ItemArtifactModel artifact,
        IEnumerable<ProjectileBehaviorModel> projectileBehaviors, Action<AddProjectileBehaviorsArtifactModel> modifyBoost = null)
    {
        var boost = new AddProjectileBehaviorsArtifactModel("", new Il2CppStringArray(0),
            new Il2CppStringArray(0), new Il2CppStringArray(0), new Il2CppStringArray(0),
            new Il2CppStringArray([]), false, new Il2CppStructArray<TowerSet>(0), false,
            new Il2CppStructArray<int>([]), false, false)
        {
            behaviorModels = projectileBehaviors.ToIl2CppReferenceArray()
        };
        modifyBoost?.Invoke(boost);

        artifact.AddBehavior(boost);
    }
}