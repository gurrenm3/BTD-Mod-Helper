using System.Collections.Generic;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Towers
{
    internal class ModTowerSetHandler
    {
        internal static readonly Dictionary<string, ModTowerSet> ModTowerSetCache = new Dictionary<string, ModTowerSet>();

        public static void LoadTowerSets(List<ModTowerSet> modTowerSets)
        {
            foreach (var modTowerSet in modTowerSets)
            {
                Game.instance.GetLocalizationManager().textTable[modTowerSet.Id] = modTowerSet.DisplayName;
                
                ModTowerSetCache[modTowerSet.Id] = modTowerSet;
            }
        }
    }
}