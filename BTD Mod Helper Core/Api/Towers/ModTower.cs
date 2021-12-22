#if BloonsTD6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// Class representing a custom Tower being added by a mod
    /// </summary>
    public abstract class ModTower : ModContent
    {
        /// <inheritdoc />
        protected sealed override void Register()
        {
            towerModels = ModTowerHelper.AddTower(this);
        }

        /// <summary>
        /// ModTowers register third
        /// </summary>
        protected sealed override float RegistrationPriority => 3;

        internal override void PostRegister()
        {
            foreach (var towerModel in towerModels)
            {
                ModTowerHelper.FinalizeTowerModel(this, towerModel);
            }

            Game.instance.GetLocalizationManager().textTable[Id] = DisplayName;
            Game.instance.GetLocalizationManager().textTable[Id + "s"] = DisplayNamePlural;
            Game.instance.GetLocalizationManager().textTable[Id + " Description"] = Description;

            if (!DontAddToShop)
            {
                try
                {
                    var index = GetTowerIndex(Game.instance.model.towerSet.ToList());
                    if (index >= 0)
                    {
                        var shopTowerDetailsModel = new ShopTowerDetailsModel(Id, index, 5, 5, 5, -1, 0, null);
                        Game.instance.model.AddTowerDetails(shopTowerDetailsModel, index);
                    }
                }
                catch (Exception)
                {
                    MelonLogger.Error($"Failed to add ModTower {Name} to the shop");
                    throw;
                }
            }

            ModTowerSet?.towers.Add(this);
        }

        internal virtual string[] DefaultMods =>
            new[] {"GlobalAbilityCooldowns", "MonkeyEducation", "BetterSellDeals", "VeteranMonkeyTraining"};

        internal List<TowerModel> towerModels;
        internal readonly int[] tierMaxes;
        internal readonly ModUpgrade[,] upgrades;
        internal readonly List<ModTowerDisplay> displays = new List<ModTowerDisplay>();
        internal ModParagonUpgrade paragonUpgrade;
        internal TowerModel BaseTowerModel => Game.instance.model.GetTowerFromId(BaseTower);
        internal virtual ModTowerSet ModTowerSet => null;
        internal virtual int UpgradePaths => 3;
        internal UpgradeModel dummyUpgrade;

        internal virtual bool ShouldCreateParagon =>
            paragonUpgrade != null &&
            TopPathUpgrades == 5 &&
            MiddlePathUpgrades == 5 &&
            BottomPathUpgrades == 5 &&
            ParagonMode != ParagonMode.None;

        /// <summary>
        /// The name that will be actually displayed for the tower in game
        /// </summary>
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");

        /// <summary>
        /// The name that will actually be display when referring to multiple of the tower
        /// </summary>
        public virtual string DisplayNamePlural => DisplayName + "s";

        /// <summary>
        /// The Portrait for the 0-0-0 tower
        /// </summary>
        public virtual string Portrait => GetType().Name + "-Portrait";

        /// <summary>
        /// The Icon for the Tower's purchase button
        /// </summary>
        public virtual string Icon => GetType().Name + "-Icon";

        /// <summary>
        /// If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference
        /// </summary>
        public virtual SpriteReference IconReference => GetSpriteReference(Icon);

        /// <summary>
        /// If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference
        /// </summary>
        public virtual SpriteReference PortraitReference => GetSpriteReference(Portrait);

        /// <summary>
        /// Whether this Tower should display 2-dimensionally, and search for png images
        /// </summary>
        public virtual bool Use2DModel => false;

        /// <summary>
        /// For 2D towers, the ratio between pixels and display units. Higher number -> smaller tower.
        /// </summary>
        public virtual float PixelsPerUnit => 10f;

        /// <summary>
        /// Makes this Tower not actually add itself to the shop, useful for making subtowers
        /// </summary>
        public virtual bool DontAddToShop => false;

        /// <summary>
        /// Defines whether / how this ModTower has a Paragon
        /// </summary>
        public virtual ParagonMode ParagonMode => ParagonMode.None;

        /// <summary>
        /// Customized order in which to add this ModTower in the shop in relation to others added by your mod
        /// </summary>
        public virtual int Order => 0;

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
            u = new ModUpgrade[UpgradePaths, t.Max()];
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
        internal virtual TowerModel GetDefaultTowerModel()
        {
            var towerModel = !string.IsNullOrEmpty(BaseTower)
                ? BaseTowerModel.MakeCopy(Id)
                : new TowerModel(Id, Id);
            towerModel.name = Id;

            towerModel.appliedUpgrades = new Il2CppStringArray(0);
            towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(0);
            towerModel.towerSet = TowerSet;
            towerModel.cost = Cost;
            towerModel.dontDisplayUpgrades = false;
            towerModel.powerName = null;

            towerModel.tier = 0;
            towerModel.tiers = new[] {0, 0, 0};

            towerModel.mods = DefaultMods
                .Select(s => new ApplyModModel($"{Id}Upgrades", s, ""))
                .ToArray();

            towerModel.GetDescendants<Model>().ForEach(model =>
            {
                model.name = model.name.Replace(BaseTower, Name);
                model._name = model._name.Replace(BaseTower, Name);
            });

            towerModel.instaIcon = IconReference;
            towerModel.portrait = PortraitReference;
            towerModel.icon = IconReference;

            return towerModel;
        }

        internal virtual string TowerId(int[] tiers)
        {
            var id = Id;
            if (tiers.Sum() > 0)
            {
                id += "-" + tiers.Printed();
            }

            return id;
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
            if (GetTextureGUID(name) != null)
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
                if (GetTextureGUID(name) != null)
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
            if (towerSet.LastOrDefault(details => details.GetTower().towerSet == TowerSet) is TowerDetailsModel tower)
            {
                return tower.towerIndex + 1;
            }

            return ModTowerSet?.GetTowerStartIndex(towerSet) ?? towerSet.Count;
        }

        internal virtual TowerModel GetBaseParagonModel()
        {
            TowerModel towerModel;
            switch (ParagonMode)
            {
                case ParagonMode.Base000:
                    towerModel = ModTowerHelper.CreateTowerModel(this, new[] {0, 0, 0});
                    break;
                case ParagonMode.Base555:
                    towerModel = ModTowerHelper.CreateTowerModel(this, new[] {5, 5, 5});
                    break;
                case ParagonMode.None:
                default:
                    return null;
            }

            towerModel.appliedUpgrades = new Il2CppStringArray(6);
            for (var i = 0; i < 5; i++)
            {
                towerModel.appliedUpgrades[i] = upgrades[0, i].Id;
            }

            return towerModel;
        }
    }

    /// <summary>
    /// A convenient generic class for specifying the ModTowerSet that a ModTower uses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModTower<T> : ModTower where T : ModTowerSet
    {
        internal override ModTowerSet ModTowerSet => GetInstance<T>();

        /// <summary>
        /// The custom tower set that this ModTower uses
        /// </summary>
        public sealed override string TowerSet => TowerSet<T>();
    }

    /// <summary>
    /// Defines the Paragon behavior for a ModTower
    /// </summary>
    public enum ParagonMode
    {
        /// <summary>
        /// Don't generate a Paragon
        /// </summary>
        None,

        /// <summary>
        /// Generate a Paragon by applying the ModParagonUpgrade to the 000 version of the tower
        /// </summary>
        Base000,

        /// <summary>
        /// Generate a Paragon by applying the ModParagonUpgrade to the 555 version of the tower
        /// </summary>
        Base555,
    }
}
#endif