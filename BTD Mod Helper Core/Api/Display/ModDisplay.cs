using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles;
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
        /// The display id for RoadSpikes
        /// </summary>
        protected const string Generic2dDisplay = "9dccc16d26c1c8a45b129e2a8cbd17ba";
        
        
        /// <summary>
        /// The GUID of the display to copy this ModDisplay off of
        /// </summary>
        public abstract string BaseDisplay { get; }

        /// <summary>
        /// Alters the UnityDisplayNode that was copied from the one used by <see cref="BaseDisplay"/>
        /// </summary>
        /// <param name="node"></param>
        public abstract void ModifyDisplayNode(UnityDisplayNode node);

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
        /// Sets the sprite texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        protected void Set2DTexture(UnityDisplayNode node, string textureName)
        {
            node.GetRenderer<SpriteRenderer>().sprite = GetSprite(textureName, PixelsPerUnit);
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
        /// How many pixels in a sprite texture should be equal to one unit
        /// </summary>
        public virtual float PixelsPerUnit => 10f;
        
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
        /// Applies this ModDisplay to a given TowerModel
        /// </summary>
        /// <param name="towerModel"></param>
        public void Apply(TowerModel towerModel)
        {
            towerModel.display = Id;
            Apply(towerModel.GetBehavior<DisplayModel>());
        }


        /// <summary>
        /// Applies this ModDisplay to a given ProjectileModel
        /// </summary>
        /// <param name="projectileModel"></param>
        public void Apply(ProjectileModel projectileModel)
        {
            projectileModel.display = Id;
            Apply(projectileModel.GetBehavior<DisplayModel>());
        }

        /// <summary>
        /// Gets the Display for a given tower, optionally for the given tiers
        /// </summary>
        /// <param name="tower">The tower base id</param>
        /// <param name="top">Path 1 tier</param>
        /// <param name="mid">Path 2 tier</param>
        /// <param name="bot">Path 3 tier</param>
        /// <returns>The display GUID</returns>
        protected string GetDisplay(string tower, int top = 0, int mid = 0, int bot = 0)
        {
            return Game.instance.model.GetTower(tower, top, mid, bot).display;
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