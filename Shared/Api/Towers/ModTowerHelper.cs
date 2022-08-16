using System.Collections.Generic;

using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper.Api.Towers;

public static partial class ModTowerHelper {
    // Cache of all added TowerModel.name => TowerModel
    internal static readonly Dictionary<string, TowerModel> TowerCache = new();

    // Cache of TowerModel.name => ModTower 
    internal static readonly Dictionary<string, ModTower> ModTowerCache = new();
}