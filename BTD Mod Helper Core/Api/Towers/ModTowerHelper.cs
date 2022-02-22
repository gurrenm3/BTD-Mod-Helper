using System.Collections.Generic;
using Assets.Scripts.Models.Towers;

namespace BTD_Mod_Helper.Api.Towers
{
    internal static partial class ModTowerHelper
    {
        // Cache of all added TowerModel.name => TowerModel
        internal static readonly Dictionary<string, TowerModel> TowerCache = new Dictionary<string, TowerModel>();

        // Cache of TowerModel.name => ModTower 
        internal static readonly Dictionary<string, ModTower> ModTowerCache = new Dictionary<string, ModTower>();
    }
}