using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.TowerGraph;
using Assets.Scripts.Models.Towers.TowerGraph.DataModel;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class TowerModelExt
    {
        public static Graph GetTowerGraph(this TowerModel towerModel)
        {
            return Game.instance.GetTowerGraph(towerModel.name);
        }

        public static TowerRootNode GetTowerNode(this TowerModel towerModel)
        {
            return Game.instance.GetTowerNode(towerModel.name);
        }

        public static TowerClassData GetTowerClassData(this TowerModel towerModel)
        {
            return Game.instance.GetTowerClassData(towerModel.baseType);
        }

        public static TowerUpgradeLayout GetTowerUpgradeLayout(this TowerModel towerModel)
        {
            return Game.instance.GetTowerUpgradeLayout(towerModel.name);
        }

        public static bool IsTowerInLoadout(this TowerModel towerModel)
        {
            return Game.instance.GetAdventureTimePlayer().IsTowerInAdventureLoadout(towerModel.name);
        }

        /// <summary>
        /// Duplicate this TowerModel with a unique name. Very useful for making custom TowerModels
        /// </summary>
        /// <param name="towerModel"></param>
        /// <param name="newTowerId">Set's the new towerId of this copy. By default the baseId will be set to this as well</param>
        /// <param name="baseType">Specify a new baseType. Set this if you want a baseType other than the original</param>
        /// <returns></returns>
        public static TowerModel MakeCopy(this TowerModel towerModel, string newTowerId, string newParentTowerId = null, TowerBaseType? baseType = null)
        {
            var duplicate = MakeCopyInternal(towerModel, newTowerId);
            duplicate.towerParentId = string.IsNullOrEmpty(newParentTowerId) ? newTowerId : newParentTowerId;
            if (baseType.HasValue)
                duplicate.baseType = baseType.Value;

            return duplicate;
        }
    }
}
