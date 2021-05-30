using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using UnityEngine;
using Vector3 = Assets.Scripts.Simulation.SMath.Vector3;

namespace BTD_Mod_Helper.Api.Display
{
    /// <summary>
    /// A custom Display that is a copy of an existing Display that can be modified
    /// </summary>
    public abstract class ModDisplay : ModContent
    {
        /// <summary>
        /// The GUID of the display to copy this ModDisplay off of
        /// </summary>
        public abstract string BaseDisplay { get; }

        /// <summary>
        /// Alters the UnityDisplayNode that was copied from the one used by <see cref="BaseDisplay"/>
        /// <br/>
        /// By default, this will change the main texture of the first SkinnedMeshRenderer of the node to that of a
        /// png with the same name as the class
        /// </summary>
        /// <param name="node"></param>
        public virtual void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName)
        {
            node.GetRenderer<SkinnedMeshRenderer>().SetMainTexture(GetTexture(textureName));
        }

        /// <summary>
        /// The position offset to render the display at (z axis is up toward camera)
        /// </summary>
        public virtual Vector3 PositionOffset => Vector3.zero;

        /// <summary>
        /// The scale to render the display at
        /// </summary>
        public virtual float Scale => 1f;
        
        /// <summary>
        /// Gets a new DisplayModel based on this ModDisplay
        /// </summary>
        /// <returns></returns>
        public DisplayModel GetDisplayModel()
        {
            return new DisplayModel($"DisplayModel_{Name}", Id, 0, PositionOffset, Scale);
        }

        /// <summary>
        /// Applies this ModDisplay to a given DisplayModel
        /// </summary>
        /// <param name="displayModel"></param>
        public void Apply(DisplayModel displayModel)
        {
            displayModel.display = Id;
            displayModel.positionOffset = PositionOffset;
            displayModel.scale = Scale;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected UnityDisplayNode GetNode(string guid)
        {
            UnityDisplayNode udn = null;
            Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(guid, 
                new System.Action<UnityDisplayNode>(node => udn = node));
            return udn;
        }
    }
}