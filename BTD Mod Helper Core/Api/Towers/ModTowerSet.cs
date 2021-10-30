using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;

namespace BTD_Mod_Helper.Api.Towers
{
    /// <summary>
    /// A custom collection of ModTowers
    /// </summary>
    public class ModTowerSet : ModContent
    {
        internal readonly List<ModTower> towers = new List<ModTower>();

        public virtual string Container => GetType().Name + "-Container";

        public virtual SpriteReference ContainerReference => GetSpriteReference(Container);
        
        public virtual string ContainerLarge => GetType().Name + "-ContainerLarge";

        public virtual SpriteReference ContainerLargeReference => GetSpriteReference(ContainerLarge);
        
        public virtual string Button => GetType().Name + "-Button";
        
        public virtual SpriteReference ButtonReference => GetSpriteReference(Button);

        public virtual string Icon => GetType().Name + "-Icon";
        
        public virtual SpriteReference IconReference => GetSpriteReference(Icon);

        /// <summary>
        /// The name that will be actually displayed for the Tower Set in game
        /// </summary>
        public virtual string DisplayName => Regex.Replace(Name, "(\\B[A-Z])", " $1");

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
        /// The position to start placing ModTowers of this ModTowerSet in relation to other towers
        /// <br/>
        /// By default, will determine the position based on GetTowerSetIndex
        /// <br/>
        /// </summary>
        /// <param name="towerSet">The set of all current tower details</param>
        /// <returns></returns>
        public virtual int GetTowerStartIndex(List<TowerDetailsModel> towerSet)
        {
            var towerSets = towerSet.Select(model => Game.instance.model.GetTowerWithName(model.towerId).towerSet);

            // Group the towers into chunks of the same tower set
            var towerSetChunks = new List<Tuple<string, int>>();
            foreach (var set in towerSets)
            {
                if (towerSetChunks.Last() is Tuple<string, int> last && last.Item1 == set)
                {
                    towerSetChunks[-1] = new Tuple<string, int>(set, last.Item2 + 1);
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
    }
}