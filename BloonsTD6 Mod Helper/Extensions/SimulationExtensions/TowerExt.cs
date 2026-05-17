using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.Display.Animation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Towers
/// </summary>
public static class TowerExt
{
    /// <summary>
    /// Change TowerModel to a different one. Will update display
    /// </summary>
    /// <param name="tower">The Simulation Tower</param>
    /// <param name="towerModel">TowerModel to change to</param>
    public static void SetTowerModel(this Tower tower, TowerModel towerModel)
    {
        tower.UpdateRootModel(towerModel);
    }

    /// <summary>
    /// Return the DisplayNode for this Tower
    /// </summary>
    /// <returns></returns>
    public static DisplayNode GetDisplayNode(this Tower tower) => tower.Node;

    /// <summary>
    /// Return the UnityDisplayNode for this Tower. Is apart of DisplayNode. Needed to modify sprites
    /// </summary>
    /// <returns></returns>
    public static UnityDisplayNode GetUnityDisplayNode(this Tower tower) => tower.GetDisplayNode()?.graphic;

    /// <summary>
    /// Sell this tower
    /// </summary>
    public static void SellTower(this Tower tower)
    {
        InGame.instance.SellTower(tower.GetTowerToSim());
    }

    /// <summary>
    /// Return the TowerToSimulation for this specific Tower
    /// </summary>
    public static TowerToSimulation GetTowerToSim(this Tower tower)
    {
        var towerSims = InGame.instance.GetAllTowerToSim();
        return towerSims?.Find(sim => sim.GetTower().Equals(tower));
    }

    /// <summary>
    /// Return the Factory that creates Towers
    /// </summary>
    /// <param name="tower"></param>
    /// <returns></returns>
    public static Factory<Tower> GetFactory(this Tower tower) => InGame.instance.GetFactory<Tower>();

    /// <summary>
    /// Gets all other towers that are in range of this tower not including itself
    /// </summary>
    /// <param name="tower"></param>
    /// <returns></returns>
    public static IEnumerable<Tower> GetTowersInRange(this Tower tower)
    {
        return InGame.instance
            .GetTowerManager()
            .GetTowersInRange(tower.Position, tower.towerModel.range)
            .ToList()
            .Where(t => t.Id != tower.Id);
    }

    /// <summary>
    /// Get the MonkeyAnimationController for this Tower. Needed to modify 3D models
    /// </summary>
    /// <returns></returns>
    public static MonkeyAnimationController GetMonkeyAnimController(this Tower tower) =>
        tower.GetUnityDisplayNode()?.animationController.TryCast<MonkeyAnimationController>();

    /// <summary>
    /// Calls <see cref="Tower.AddMutatorFromParent"/> with a <see cref="ModMutator"/>
    /// </summary>
    public static void AddMutatorFromParent<T>(this Tower tower,
        JToken data = null,
        int time = -1,
        bool updateDuration = true,
        bool applyMutation = true,
        bool onlyTimeoutWhenActive = false,
        bool useRoundTime = true,
        int roundsRemaining = -1) where T : ModMutator
    {
        tower.AddMutatorFromParent(ModContent.CreateMutator<T>(data), time: time, updateDuration: updateDuration,
            applyMutation: applyMutation, onlyTimeoutWhenActive: onlyTimeoutWhenActive,
            useRoundTime: useRoundTime, roundsRemaining: roundsRemaining);
    }

    /// <summary>
    /// Calls <see cref="Tower.AddMutatorIncludeSubTowers"/> with a <see cref="ModMutator"/>
    /// </summary>
    public static void AddMutatorIncludeSubTowers<T>(this Tower tower,
        JToken data = null,
        int time = -1,
        bool updateDuration = true,
        bool applyMutation = true,
        bool onlyTimeoutWhenActive = false,
        bool useRoundTime = true,
        int roundsRemaining = -1) where T : ModMutator
    {
        tower.AddMutatorIncludeSubTowers(ModContent.CreateMutator<T>(data), time: time, updateDuration: updateDuration,
            applyMutation: applyMutation, onlyTimeoutWhenActive: onlyTimeoutWhenActive,
            useRoundTime: useRoundTime, roundsRemaining: roundsRemaining);
    }
}