using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// ModContent Class for modifying a certain set of vanilla towers
    /// </summary>
    public abstract class ModVanillaContent : ModContent
    {
        internal abstract IEnumerable<TowerModel> GetAffectedTowers(GameModel gameModel);
        
        /// <summary>
        /// Whether this should only modify the Towers In-Game, or also affect the default GameModel outside a game
        /// </summary>
        public virtual bool AffectBaseGameModel => false;

        /// <summary>
        /// Changes the base cost
        /// </summary>
        public virtual int Cost => -1;

        /// <inheritdoc />
        public sealed override string Name => base.Name;

        /// <summary>
        /// Change the name of it
        /// </summary>
        public virtual string DisplayName => null;
        
        /// <summary>
        /// Change the description of it
        /// </summary>
        public virtual string Description => null;

        /// <summary>
        /// Applies the modifications to the TowerModel
        /// </summary>
        /// <param name="towerModel"></param>
        public abstract void Apply(TowerModel towerModel);

        /// <inheritdoc />
        protected sealed override void Register()
        {
            if (AffectBaseGameModel)
            {
                foreach (var affectedTower in GetAffectedTowers(Game.instance.model))
                {
                    Apply(affectedTower);
                }
            }
        }
    }
}