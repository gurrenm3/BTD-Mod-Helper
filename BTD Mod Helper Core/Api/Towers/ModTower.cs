#if BloonsTD6
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModTower : ModContent
    {
        private static readonly string[] DefaultMods = {"GlobalAbilityCooldowns", "MonkeyEducation", "BetterSellDeals", "VeteranMonkeyTraining"};

        private TowerModel towerModel;
        
        internal readonly int[] tierMaxes;
        internal readonly ModUpgrade[,] upgrades;
        internal readonly List<ModTowerDisplay> displays = new List<ModTowerDisplay>();
        
        /// <summary>
        /// The name that will be actually displayed for the tower in game
        /// </summary>
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");
        /// <summary>
        /// The Portrait for the 0-0-0 tower
        /// </summary>
        public virtual string Portrait => Name + "-Portrait";
        /// <summary>
        /// The Icon for the Tower's purchase button
        /// </summary>
        public virtual string Icon => Name + "-Icon";
        
        /// <summary>
        /// Whether this Tower should display 2-dimensionally, and search for png images
        /// </summary>
        public virtual bool Use2DModel => false;
        
        /// <summary>
        /// For 2D towers, the ratio between pixels and display units. Higher number -> smaller tower.
        /// </summary>
        public virtual float PixelsPerUnit => 10f;

        /// <summary>
        /// The string to use for the Primary tower set
        /// </summary>
        protected const string PRIMARY = "Primary";
        /// <summary>
        /// The string to use for the Magic tower set
        /// </summary>
        protected const string MAGIC = "Magic";
        /// <summary>
        /// The string to use for the Military tower set
        /// </summary>
        protected const string MILITARY = "Military";
        /// <summary>
        /// The string to use for the Support tower set
        /// </summary>
        protected const string SUPPORT = "Support";

        /// <summary>
        /// The family of Monkeys that your Tower should be put in.
        /// <br/>
        /// For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.
        /// </summary>
        public abstract string TowerSet { get; }
        /// <summary>
        /// The id of the default BTD Tower that your Tower is going to be copied from by default.
        /// </summary>
        public abstract string BaseTower { get; }
        /// <summary>
        /// The in game cost of this tower (on Medium difficulty)
        /// </summary>
        public abstract int Cost { get; }
        /// <summary>
        /// The number of upgrades the tower has in it's 1st / top path
        /// </summary>
        public abstract int TopPathUpgrades { get; }
        /// <summary>
        /// The number of upgrades the tower has in it's 2nd / middle path
        /// </summary>
        public abstract int MiddlePathUpgrades { get; }
        /// <summary>
        /// The number of upgrades the tower has in it's 3rd / bottom path
        /// </summary>
        public abstract int BottomPathUpgrades { get; }
        /// <summary>
        /// The in game description of the Tower
        /// </summary>
        public abstract string Description { get; }
        
        /// <summary>
        /// Constructor for ModTower, used implicitly by ModContent.Create
        /// </summary>
        protected ModTower()
        {
            Init(out upgrades, out tierMaxes);
        }

        internal void Init(out ModUpgrade[,] u, out int[] t)
        {
            t = new[] {TopPathUpgrades, MiddlePathUpgrades, BottomPathUpgrades};
            u = new ModUpgrade[3, t.Max()];
        }

        /// <summary>
        /// Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades
        /// <br/>
        /// Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point
        /// </summary>
        /// <param name="towerModel">The Base Tower Model</param>
        public abstract void ModifyBaseTowerModel(TowerModel towerModel);
        
        /// <summary>
        /// Gets the base 0-0-0 TowerModel for this Tower
        /// <br/>
        /// Starts with the <see cref="BaseTower"/>, modifies its default properties as needed,
        /// then calls <see cref="ModifyBaseTowerModel"/> on it.
        /// 
        /// </summary>
        /// <returns>The 0-0-0 TowerModel for this Tower</returns>
        internal TowerModel GetBaseTowerModel()
        {
            if (towerModel == null)
            {
                towerModel = !string.IsNullOrEmpty(BaseTower)
                    ? Game.instance.model.GetTowerFromId(BaseTower).MakeCopy(Id)
                    : new TowerModel(Id, Id);
                towerModel.name = Id;
                
                towerModel.appliedUpgrades = new Il2CppStringArray(0);
                towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
                towerModel.towerSet = TowerSet;
                towerModel.cost = Cost;
                towerModel.dontDisplayUpgrades = false;

                    towerModel.tier = 0;
                towerModel.tiers = new[] {0, 0, 0};

                foreach (var defaultMod in DefaultMods)
                {
                    for (var i = 0; i < towerModel.mods.Count; i++)
                    {
                        var model = towerModel.mods[i];
                        if (model.name != defaultMod)
                        {
                            towerModel.mods = towerModel.mods.RemoveItem(model);
                            break;
                        }
                    }
                }
                
                towerModel.GetDescendants<Model>().ForEach(model =>
                {
                    model.name = model.name.Replace(BaseTower, Name);
                    model._name = model._name.Replace(BaseTower, Name);
                });
            
                towerModel.instaIcon = GetSpriteReference(mod, Icon);
                towerModel.portrait = GetSpriteReference(mod, Portrait);
                towerModel.icon = GetSpriteReference(mod, Icon);
                //towerModel.display = ;
                //towerModel.GetBehavior<DisplayModel>().display = 
            }

            return towerModel;
        }

        /// <summary>
        /// Returns all the valid tiers for the TowerModels of this Tower
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<int[]> TowerTiers()
        {
            var results = new List<int[]>();
            for (var i = 0; i <= TopPathUpgrades; i++)
            {
                for (var j = 0; j <= MiddlePathUpgrades; j++)
                {
                    for (var k = 0; k <= BottomPathUpgrades; k++)
                    {
                        var tiers = new[] {i, j, k};
                        var sorted = tiers.OrderBy(num => -num).ToArray();
                        if (sorted[0] <= 5 && sorted[1] <= 2 && sorted[2] == 0)
                        {
                            results.Add(tiers);
                        }
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// If this is a 2D tower, gets the name of the .png to use for a given set of tiers
        /// <br/>
        /// Default Behavior Example: For CardMonkey with tiers 2-3-0, it would try (in order):
        /// CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey
        /// </summary>
        /// <param name="tiers"></param>
        /// <returns></returns>
        public virtual string Get2DTexture(int[] tiers)
        {
            var name = $"{Name}-{tiers.Printed()}";
            if (ResourceHandler.resources.ContainsKey(GetTextureGUID(name)))
            {
                return name;
            }

            foreach (var i in tiers.Order())
            {
                if (tiers[i] == 0)
                {
                    break;
                }
                var printed = tiers.Printed().ToCharArray();
                for (var j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        printed[j] = 'X';
                    }
                }
                name = $"{Name}-{printed}";
                if (ResourceHandler.resources.ContainsKey(GetTextureGUID(name)))
                {
                    return name;
                }
            }

            return Name;
        }

        /// <summary>
        /// When adding this tower to the shop, gets the index at which to add the tower relative to the existing ones.
        /// <br/>
        /// By default, the tower will be put at the end of the TowerSet category that it's in.
        /// </summary>
        /// <param name="towerSet"></param>
        /// <returns></returns>
        public virtual int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            var index = towerSet.Count;
            var lastOfSet = towerSet.LastOrDefault(tdm => Game.instance.model.GetTowerFromId(tdm.towerId).towerSet == TowerSet);
            if (lastOfSet != default)
            {
                index = towerSet.IndexOf(lastOfSet) + 1;
            }

            return index;
        }
        
    }
}
#endif