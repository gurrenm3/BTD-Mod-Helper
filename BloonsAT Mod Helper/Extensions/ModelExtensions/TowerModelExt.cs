using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.TowerGraph;
using Assets.Scripts.Models.Towers.TowerGraph.DataModel;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
