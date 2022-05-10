﻿using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// Class representing a 
    /// </summary>
    public abstract class ModHeroLevel : ModUpgrade
    {
        internal override void PostRegister()
        {
            if (AbilityName != null)
            {
                Game.instance.GetLocalizationManager().textTable[AbilityName + " Ability"] = AbilityName;
            }

            if (AbilityDescription != null)
            {
                Game.instance.GetLocalizationManager().textTable[AbilityName + " Ability Description"] = AbilityDescription;
            }
        }

        /// <summary>
        /// Internal naming scheme for hero levels
        /// </summary>
        public sealed override string Name => Hero.Name + " Level " + Level;

        private static readonly int[] DefaultXp =
        {
            0, 0, 180, 460, 1000, 1860, 3280, 5180, 8320, 9380, 13620, 16380,
            14400, 16650, 14940, 16380, 17820, 19260, 20700, 16470, 17280
        };

        /// <summary>
        /// No confirmation on hero upgrades
        /// </summary>
        public sealed override bool NeedsConfirmation => base.NeedsConfirmation;

        /// <summary>
        /// No confirmation on hero upgrades
        /// </summary>
        public sealed override string ConfirmationTitle => base.ConfirmationTitle;

        /// <summary>
        /// No confirmation on hero upgrades
        /// </summary>
        public sealed override string ConfirmationBody => base.ConfirmationBody;

        /// <summary>
        /// Hero upgrades don't have individual icons
        /// </summary>
        public sealed override string Icon => null;

        /// <summary>
        /// Hero upgrades don't have individual icons
        /// </summary>
        public sealed override SpriteReference IconReference => null;

        /// <summary>
        /// The upgrade's tier is the hero's level.
        /// </summary>
        public sealed override int Tier => Level;

        /// <summary>
        /// Hero upgrades have no cost
        /// </summary>
        public sealed override int Cost => 0;

        /// <summary>
        /// How much XP the hero needs to get to go from the previous level to this level.
        /// <br/>
        /// Default is calculated the same way Ninja Kiwi does it using 
        /// </summary>
        public override int XpCost => (int)(DefaultXp[Level] * Hero.XpRatio);

        /// <summary>
        /// The ModTower is the ModHero
        /// </summary>
        public sealed override ModTower Tower => Hero;

        /// <summary>
        /// All hero upgrades count as top path
        /// </summary>
        public sealed override int Path => TOP;

        /// <summary>
        /// What level this 
        /// </summary>
        public abstract int Level { get; }
        
        /// <summary>
        /// The tower that this is an upgrade for
        /// </summary>
        public abstract ModHero Hero { get; }

        /// <summary>
        /// DisplayName field of the AbilityModel added at this level, if any
        /// </summary>
        public virtual string AbilityName => null;
        
        /// <summary>
        /// Description of the ability added at this level, if any
        /// </summary>
        public virtual string AbilityDescription => null;
    }

    /// <summary>
    /// Convenient generic class for specifying the ModHero that this ModHeroLevel is for
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModHeroLevel<T> : ModHeroLevel where T : ModHero
    {
        /// <inheritdoc />
        public override ModHero Hero => GetInstance<T>();
    }
}