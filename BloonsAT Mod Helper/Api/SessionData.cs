using Assets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Api
{
    public class SessionData
    {
        public static SessionData instance = new SessionData();

        public List<TowerModel> inGameTowerModels;

        public SessionData()
        {
            inGameTowerModels = new List<TowerModel>();
        }
    }
}
