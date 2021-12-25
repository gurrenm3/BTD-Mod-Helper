using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModHero : ModTower
    {
        internal override void PostRegister()
        {
            base.PostRegister();
            ModTowerHelper.FinalizeHero(this);
        }

        public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
        {
            base.RegisterText(textTable);
            
            textTable[Id + " Short Description"] = Title;
            textTable[Id + " Level 1 Description"] = Level1Description;
        }

        internal override string[] DefaultMods => base.DefaultMods.Concat(new[]
        {
            "EmpoweredHeroes", "HeroicReach", "HeroicVelocity", "QuickHands", 
            "Scholarships", "SelfTaughtHeroes", "WeakPoint"
        }).ToArray();

        internal sealed override int UpgradePaths => 1;

        /// <summary>
        /// Heroes aren't in the default shop
        /// </summary>
        public sealed override bool DontAddToShop => true;

        /// <summary>
        /// No paragon heroes
        /// </summary>
        public sealed override ParagonMode ParagonMode => ParagonMode.None;

        /// <summary>
        /// No Order among different custom heroes
        /// </summary>
        public sealed override int Order => base.Order;

        /// <summary>
        /// The default hero (or tower) to base your hero off of
        /// </summary>
        public override string BaseTower => TowerType.Quincy;

        /// <summary>
        /// Heroes can only be in the Hero tower set
        /// </summary>
        public sealed override string TowerSet => "Hero";

        /// <summary>
        /// Putting all the hero level upgrades in the top path
        /// </summary>
        public sealed override int TopPathUpgrades => MaxLevel;

        /// <summary>
        /// No other upgrade paths used
        /// </summary>
        public sealed override int MiddlePathUpgrades => 0;

        /// <summary>
        /// No other upgrade paths used
        /// </summary>
        public sealed override int BottomPathUpgrades => 0;

        /// <summary>
        /// Heroes tower tiers are always Level-0-0
        /// </summary>
        /// <returns></returns>
        public sealed override IEnumerable<int[]> TowerTiers()
        {
            yield return new[] { 0, 0, 0 };
            for (var i = 2; i <= MaxLevel; i++)
            {
                yield return new[] { i, 0, 0 };
            }
        }

        internal override TowerModel GetDefaultTowerModel()
        {
            var baseTowerModel = base.GetDefaultTowerModel();
            if (!baseTowerModel.HasBehavior<HeroModel>())
            {
                // Unrelated to the actual XpRatio weirdly enough
                baseTowerModel.AddBehavior(new HeroModel($"HeroModel_{Name}", 1.0f, 1.0f));
            }
            return baseTowerModel;
        }

        internal override string TowerId(int[] tiers)
        {
            var id = Id;
            if (tiers[0] > 0)
            {
                id += " " + tiers[0];
            }
            return id;
        }

        /// <summary>
        /// The other hero that has the same colored name in the Heroes menu as you want to use
        /// </summary>
        public virtual string NameStyle => TowerType.Ezili;

        public virtual string Button => GetType().Name + "-Button";

        public virtual SpriteReference ButtonReference => GetSpriteReference(Button);

        /// <summary>
        /// The total number of levels this hero has. Do not set this to anything other than number of ModHeroLevels
        /// that you've actually created for your Hero.
        /// </summary>
        public abstract int MaxLevel { get; }

        /// <summary>
        /// XpRatio to use when determining the default xp costs of the levels.
        /// <br/>
        /// All four base heroes (Quincy, Gwendolin, Striker Jones, Obyn Greenfoot) as well as Etienne have an XP ratio of 1x.
        /// <br/>
        /// Ezili, Pat Fusty, Admiral Brickell, and Sauda have a 1.425x XP ratio.
        /// <br/>
        /// Benjamin and Psi have an XP ratio of 1.5x.
        /// <br/>
        /// Captain Churchill and Adora have a ratio of 1.71x.
        /// </summary>
        public abstract float XpRatio { get; }

        /// <summary>
        /// The short description that appears under the name of the hero
        /// </summary>
        public abstract string Title { get; }
        
        /// <summary>
        /// The description to use for the first level of your hero
        /// </summary>
        public abstract string Level1Description { get; }
        
        /// <summary>
        /// The total number of abilities that this hero has as max level
        /// </summary>
        public abstract int Abilities { get; }

        /// <summary>
        /// The index to add this hero at in relation to other heroes
        /// </summary>
        /// <param name="heroSet"></param>
        /// <returns></returns>
        public virtual int GetHeroIndex(List<HeroDetailsModel> heroSet)
        {
            return heroSet.Count;
        }
    }
}