#if BloonsTD6
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.Api.Display
{
    /// <summary>
    /// A ModDisplay that will automatically apply to a ModTower for specific tiers
    /// </summary>
    public abstract class ModTowerDisplay : ModDisplay
    {
        /// <summary>
        /// The ModTower that this ModDisplay is used for
        /// </summary>
        public abstract ModTower Tower { get; }

        /// <summary>
        /// Returns true if this display should be used by its Tower for the given tiers
        /// </summary>
        /// <param name="tiers">The potential tiers of the tower</param>
        /// <returns>If the Tower should have this display</returns>
        public abstract bool UseForTower(int[] tiers);


        /// <summary>
        /// Alters the UnityDisplayNode that was copied from the one used by <see cref="BaseDisplay"/>
        /// <br/>
        /// By default, this will change the main texture of the first SkinnedMeshRenderer of the node to that of a
        /// png with the same name as the class
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }
    
    /// <summary>
    /// A convenient generic class for applying a ModTowerDisplay to a ModTower
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ModTowerDisplay<T> : ModTowerDisplay where T : ModTower
    {
        /// <inheritdoc />
        public override ModTower Tower => GetInstance<T>();
    }
}
#endif