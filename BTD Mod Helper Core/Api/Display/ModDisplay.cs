using System.Linq;
using System.Threading.Tasks;
#if BloonsTD6
using System;
using System.Collections.Generic;
using Assets.Scripts.Models.GenericBehaviors;
#endif
#if BloonsAT
using Assets.Scripts.Models.Display;
#endif
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using Task = Il2CppSystem.Threading.Tasks.Task;
using Vector3 = Assets.Scripts.Simulation.SMath.Vector3;

namespace BTD_Mod_Helper.Api.Display
{
#if BloonsTD6
    /// <summary>
    /// A custom Display that is a copy of an existing Display that can be modified
    /// </summary>
    public abstract class ModDisplay : ModContent
    {
        internal static readonly Dictionary<string, ModDisplay> Cache = new Dictionary<string, ModDisplay>();

        /// <summary>
        /// ModDisplays register first
        /// </summary>
        protected sealed override float RegistrationPriority => 1;
        
        /// <inheritdoc />
        protected sealed override void Register()
        {
            Cache[Id] = this;
        }


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
            node.GetMeshRenderer().SetMainTexture(GetTexture(textureName));
        }

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName, int index)
        {
            node.GetMeshRenderer(index).SetMainTexture(GetTexture(textureName));
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
        /// Gets a UnityDisplayNode for a different guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        protected void UseNode(string guid, Action<UnityDisplayNode> action)
        {
            Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(guid, new Action<UnityDisplayNode>((udn) =>
            {
                udn.RecalculateGenericRenderers();
                action(udn);
                udn.RecalculateGenericRenderers();
            }));
        }

        /// <summary>
        /// If you modify the unity Object and not just the DisplayNode attached to it, then set this to true
        /// </summary>
        public virtual bool ModifiesUnityObject => false;


        #region Misc Display Ids

        /// <summary>
        /// The display id for RoadSpikes
        /// </summary>
        public const string Generic2dDisplay = "9dccc16d26c1c8a45b129e2a8cbd17ba";

        public const string EtienneRoombaCat = "Assets/Monkeys/Etienne/Graphics/Pets/Roomba/PetRoombaDisplay.prefab";

        public const string PatFustyPenguinPet =
            "Assets/Monkeys/PatFusty/Graphics/Pets/Penguin/PetPenguinDisplay.prefab";

        public const string GwendolinFirefoxPet = "Assets/Monkeys/Gwendolin/Graphics/Pets/Fox/PetFoxDisplay.prefab";
        public const string QuincyDadPet = "Assets/Monkeys/Quincy/Graphics/Pets/DadofQuincy/DadofQuincyDisplay.prefab";
        public const string EziliFrogPet = "Assets/Monkeys/Ezili/Graphics/Pets/Frog/PetFrogDisplay.prefab";
        public const string ObynGhostWolfPet = "Assets/Monkeys/ObynGreenfoot/Graphics/Pets/Wolf/PetWolfDisplay.prefab";

        public const string BrickellParrotPet =
            "Assets/Monkeys/AdmiralBrickell/Graphics/Pets/Parrot/PetParrotDisplay.prefab";

        public const string ObynBunnyPet = "Assets/Monkeys/ObynGreenfoot/Graphics/Pets/Bunny/PetBunnyDisplay.prefab";
        public const string SaudaCranePet = "Assets/Monkeys/Sauda/Graphics/Pets/Crane/PetCraneDisplay.prefab";

        public const string SuperMonkeyBatPet =
            "Assets/Monkeys/SuperMonkey/Graphics/Pets/Bat/SuperMonkeyBatDisplay.prefab";

        public const string MonkeySubDuckPet =
            "Assets/Monkeys/MonkeySub/Graphics/Pets/RubberDuck/PetRubberDuckDisplay.prefab";

        public const string MonkeyVillageElfPet = "Assets/Monkeys/MonkeyVillage/graphics/Pets/Elf/PetElfDisplay.prefab";

        public const string NinjaMonkeyKiwiPet =
            "Assets/Monkeys/NinjaMonkey/Graphics/Pets/Kiwi/NinjaMonkeyKiwiDisplay.prefab";

        public const string BananaFarmChickenPet =
            "Assets/Monkeys/BananaFarm/Graphics/Pets/Chicken/PetChickenDisplay.prefab";

        public const string BananaFarmer = "Assets/Powers/Graphics/PlaceableItemBananaFarmer.prefab";
        public const string GrimFarmer = "Assets/Powers/Graphics/Cosmetics/PlaceableItemBananaFarmerHalloween.prefab";
        public const string CashDrop = "c737ade5badc75d49b97ac44e123430c";
        public const string CoffinDrop = "Assets/Powers/Graphics/Cosmetics/CoffinDrop.prefab";
        public const string MOABMine = "Assets/Powers/Graphics/PlaceableItemMine.prefab";
        public const string BaubleMine = "Assets/Powers/Graphics/Cosmetics/PlaceableItemMoabMineBauble.prefab";
        public const string RetroTechBot = "Assets/Powers/Graphics/Cosmetics/PlaceableItemTechBotRetro.prefab";
        public const string PortableLake = "Assets/Powers/Graphics/PlaceableItemPool.prefab";
        public const string Pontoon = "Assets/Powers/Graphics/PlaceableItemPontoon.prefab";
        public const string IcebergPontoon = "Assets/Powers/Graphics/Cosmetics/PlaceableItemPontoonIceberg.prefab";
        public const string PortableLavaLake = "Assets/Powers/Graphics/Cosmetics/PlaceableItemLavaLake.prefab";
        public const string TrueSunGod = "Assets/Monkeys/SuperMonkey/Graphics/TrueSunGodMonkey.prefab";
        public const string VengefulTrueSunGod = "Assets/Monkeys/SuperMonkey/Graphics/TrueSunGod555Monkey.prefab";
        public const string VengefulSunAvatar = "Assets/Monkeys/SuperMonkey/Graphics/SunAvatarTurret555.prefab";

        #endregion
    }
#endif
}