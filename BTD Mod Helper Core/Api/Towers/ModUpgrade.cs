using System.Text.RegularExpressions;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Api.Towers
{
    public abstract class ModUpgrade : ModContent
    {
        private UpgradeModel upgradeModel;
        
        protected const int TOP = 0;
        protected const int MIDDLE = 1;
        protected const int BOTTOM = 2;
        protected const int FIRST = 0;
        protected const int SECOND = 1;
        protected const int THIRD = 2;
        protected const int FOURTH = 3;
        protected const int FIFTH = 4;
        
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");
        public virtual int Priority => 0;

        public abstract int Path { get; }
        public abstract int Tier { get; }
        public abstract int Cost { get; }
        public abstract ModTower Tower { get; }
        public abstract string Description { get; }

        public abstract void ApplyUpgrade(TowerModel tower);



        public virtual UpgradeModel GetUpgradeModel()
        {
            if (upgradeModel == null)
            {
                upgradeModel = new UpgradeModel(Id, Cost, 0, GetSpriteReference(mod, Id), Path, Tier, 0, "", "");
            }

            return upgradeModel;
        }
        
    }
}