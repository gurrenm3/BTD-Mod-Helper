using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// A custom collection of ModTowers
    /// </summary>
    public abstract class ModTowerSet : NamedModContent
    {
        internal static readonly Dictionary<string, ModTowerSet> Cache = new Dictionary<string, ModTowerSet>();

        /// <summary>
        /// ModTowerSets register fourth
        /// </summary>
        protected sealed override float RegistrationPriority => 4;

        /// <inheritdoc />
        public sealed override void Register()
        {
            Cache[Id] = this;
        }
        
        /// <summary>
        /// Unused
        /// </summary>
        public sealed override string DisplayNamePlural => base.DisplayNamePlural;

        /// <summary>
        /// Unused
        /// </summary>
        public sealed override string Description => base.Description;

        internal readonly List<ModTower> towers = new List<ModTower>();

        /// <summary>
        /// Name of .png file for the background for towers in the Monkeys menu and the in game shop
        /// </summary>
        public virtual string Container => GetType().Name + "-Container";

        /// <summary>
        /// SpriteReference for the container
        /// </summary>
        public virtual SpriteReference ContainerReference => GetSpriteReference(Container);

        /// <summary>
        /// Name of .png file for the background used for non-paragon upgrades in the Upgrade screen
        /// </summary>
        public virtual string ContainerLarge => GetType().Name + "-ContainerLarge";

        /// <summary>
        /// SpriteReference for the large container
        /// </summary>
        public virtual SpriteReference ContainerLargeReference => GetSpriteReference(ContainerLarge);

        /// <summary>
        /// Name of .png file for the group button used in the Monkeys menu
        /// </summary>
        public virtual string Button => GetType().Name + "-Button";

        /// <summary>
        /// SpriteReference for the button
        /// </summary>
        public virtual SpriteReference ButtonReference => GetSpriteReference(Button);

        /// <summary>
        /// Name of .png file for the background for in game portraits
        /// </summary>
        public virtual string Portrait => GetType().Name + "-Portrait";

        /// <summary>
        /// SpriteReference for the portrait
        /// </summary>
        public virtual SpriteReference PortraitReference => GetSpriteReference(Portrait);

        /*public virtual string Icon => GetType().Name + "-Icon";
        This is in the game for each tower set, but haven't seen a place where it'd need to be used for custom ones
        public virtual SpriteReference IconReference => GetSpriteReference(Icon);*/

        /// <summary>
        /// Where to place this ModTowerSet in relation to other towerSets. By default at the end.
        /// <br/>
        /// </summary>
        /// <param name="towerSets">The current towerSets that already exist</param>
        /// <returns></returns>
        public virtual int GetTowerSetIndex(List<string> towerSets)
        {
            return towerSets.Count;
        }

        /// <summary>
        /// Whether this Tower Set should still be allowed to appear in Primary Only, Military Only, Magic Only
        /// </summary>
        public virtual bool AllowInRestrictedModes => false;

        /// <summary>
        /// The position to start placing ModTowers of this ModTowerSet in relation to other towers
        /// <br/>
        /// By default, will determine the position based on GetTowerSetIndex
        /// <br/>
        /// </summary>
        /// <param name="towerSet">The set of all current tower details</param>
        /// <returns></returns>
        public virtual int GetTowerStartIndex(List<TowerDetailsModel> towerSet)
        {
            var towerSets = towerSet.Select(model => model.GetTower().towerSet);

            // Group the towers into chunks of the same tower set
            var towerSetChunks = new List<Tuple<string, int>>();
            foreach (var set in towerSets)
            {
                if (towerSetChunks.LastOrDefault() is Tuple<string, int> last && last.Item1 == set)
                {
                    towerSetChunks[towerSetChunks.Count - 1] = new Tuple<string, int>(set, last.Item2 + 1);
                }
                else
                {
                    towerSetChunks.Add(new Tuple<string, int>(set, 1));
                }
            }

            // Get the tower set index in relation to the chunks
            var start = GetTowerSetIndex(towerSetChunks.Select(tuple => tuple.Item1).ToList());

            return towerSetChunks.Take(start).Sum(tuple => tuple.Item2);
        }

        /// <summary>
        /// No loading multiple instances of a ModTowerSet
        /// </summary>
        /// <returns></returns>
        public sealed override IEnumerable<ModContent> Load()
        {
            return base.Load();
        }
    }
}