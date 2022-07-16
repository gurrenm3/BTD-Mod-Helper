using Assets.Scripts.Unity.Display;
using Vector3 = Assets.Scripts.Simulation.SMath.Vector3;
using System.Collections.Generic;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers;

#if BloonsTD6
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers.Projectiles;
#elif BloonsAT
using Assets.Scripts.Models.Display;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Api.Display
{
    /// <summary>
    /// A custom Display that is a copy of an existing Display that can be modified
    /// </summary>
    public abstract partial class ModDisplay : ModContent
    {
        internal static readonly Dictionary<string, ModDisplay> Cache = new();

        /// <summary>
        /// ModDisplays register first
        /// </summary>
        /// <exclude/>
        protected sealed override float RegistrationPriority => 1;

        /// <inheritdoc />
        public sealed override int RegisterPerFrame => 100;

        /// <inheritdoc />
        public override void Register()
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
        /// The position offset to render the display at (z axis is up toward camera)
        /// </summary>
        public virtual Vector3 PositionOffset => new(0,0,0);

        /// <summary>
        /// The scale to render the display at
        /// </summary>
        public virtual float Scale => 1f;

        /// <summary>
        /// How many pixels in a sprite texture should be equal to one unit
        /// </summary>
        public virtual float PixelsPerUnit => 10f;

        /// <summary>
        /// If you modify the unity Object and not just the DisplayNode attached to it, then set this to true
        /// </summary>
        public virtual bool ModifiesUnityObject => false;

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName)
        {
            node.GetMeshRenderer().SetMainTexture(GetTexture(textureName)!);
        }

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        /// <param name="index">The index to set at</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName, int index)
        {
            node.GetMeshRenderer(index).SetMainTexture(GetTexture(textureName)!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given BloonModel
        /// </summary>
        public void Apply(BloonModel bloonModel)
        {
            bloonModel.SetDisplayGUID(Id);
            Apply(bloonModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given TowerModel
        /// </summary>
        public void Apply(TowerModel towerModel)
        {
#if BloonsTD6
            towerModel.display = Id;
#endif
            Apply(towerModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given ProjectileModel
        /// </summary>
        public void Apply(ProjectileModel projectileModel)
        {
#if BloonsTD6
            projectileModel.display = Id;
#endif
            Apply(projectileModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given DisplayModel
        /// </summary>
        public void Apply(DisplayModel displayModel)
        {
            displayModel.display = Id;
#if BloonsTD6
            displayModel.positionOffset = PositionOffset;
            displayModel.scale = Scale;
#endif
        }


#region Misc Display Ids

        /// <summary>
        /// The display id for RoadSpikes
        /// </summary>
        public const string Generic2dDisplay = "9dccc16d26c1c8a45b129e2a8cbd17ba";
#pragma warning disable CS1591
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

#pragma warning restore CS1591

#endregion
    }
}