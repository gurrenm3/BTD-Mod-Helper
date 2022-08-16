using System;

using Assets.Scripts.Unity.Display;

using System.Collections.Generic;

using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;

using NinjaKiwi.Common;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Object = UnityEngine.Object;

#if BloonsTD6
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers.Projectiles;
#elif BloonsAT
using Assets.Scripts.Models.Display;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Api.Display {
    /// <summary>
    /// A custom Display that is a copy of an existing Display that can be modified
    /// </summary>
    public abstract partial class ModDisplay : ModContent {
        internal static readonly Dictionary<string, ModDisplay> Cache = new();

        /// <summary>
        /// ModDisplays register first
        /// </summary>
        /// <exclude/>
        protected sealed override float RegistrationPriority => 1;

        /// <inheritdoc />
        public sealed override int RegisterPerFrame => 10;

        /// <inheritdoc />
        public override void Register() {
            Cache[Id] = this;
        }

        /// <summary>
        /// The GUID of the display to copy this ModDisplay off of
        /// </summary>
        public virtual string BaseDisplay => "";

        /// <summary>
        /// The prefab reference itself of the base display that will be used
        /// </summary>
        public virtual PrefabReference BaseDisplayReference => CreatePrefabReference(BaseDisplay);

        /// <summary>
        /// Alters the UnityDisplayNode that was copied from the one used by <see cref="BaseDisplay"/>
        /// </summary>
        /// <param name="node">The prototype unity display node</param>
        public virtual void ModifyDisplayNode(UnityDisplayNode node) {
        }

        /// <summary>
        /// Allows you to modify this node asynchronously. On complete must be called for load to work! Takes
        /// place after the non-async ModifyDisplayNode call
        /// </summary>
        /// <param name="node">The prototype unity display node</param>
        /// <param name="onComplete">Callback for when you've finished changing the node</param>
        public virtual void ModifyDisplayNodeAsync(UnityDisplayNode node, Action onComplete) {
            onComplete();
        }

        /// <summary>
        /// The position offset to render the display at (z axis is up toward camera)
        /// </summary>
        public virtual Assets.Scripts.Simulation.SMath.Vector3 PositionOffset => new(0, 0, 0);

        /// <summary>
        /// The scale to render the display at
        /// </summary>
        public virtual float Scale => 1f;

        /// <summary>
        /// How many pixels in a sprite texture should be equal to one unit
        /// </summary>
        [Obsolete("Due to resource pre loading you most likely want to use Scale instead")]
        public virtual float PixelsPerUnit => 10f;

        /// <summary>
        /// If you modify the unity Object and not just the DisplayNode attached to it, then set this to true
        /// </summary>
        [Obsolete("No longer required")] public virtual bool ModifiesUnityObject => false;

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName) {
            node.GetMeshRenderer().SetMainTexture(GetTexture(textureName));
        }

        /// <summary>
        /// Sets the mesh texture to that of a named png
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="textureName">The name of the texture, without .png</param>
        /// <param name="index">The index to set at</param>
        protected void SetMeshTexture(UnityDisplayNode node, string textureName, int index) {
            node.GetMeshRenderer(index).SetMainTexture(GetTexture(textureName));
        }

        /// <summary>
        /// Sets the outline color for the first mesh renderer in the given node
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="color">The color for it to be outlined (when not highlighted)</param>
        protected void SetMeshOutlineColor(UnityDisplayNode node, Color color) {
            node.GetMeshRenderer().SetOutlineColor(color);
        }

        /// <summary>
        /// Sets the outline color for the index'th mesh renderer in the given node
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="color">The color for it to be outlined (when not highlighted)</param>
        /// <param name="index">What index of mesh renderer to use</param>
        protected void SetMeshOutlineColor(UnityDisplayNode node, Color color, int index) {
            node.GetMeshRenderer(index).SetOutlineColor(color);
        }

        #region Applying Methods

        /// <summary>
        /// Applies this ModDisplay to a given BloonModel
        /// </summary>
        public void Apply(BloonModel bloonModel) {
            bloonModel.SetDisplayGUID(Id);
            Apply(bloonModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given TowerModel
        /// </summary>
        public virtual void Apply(TowerModel towerModel) {
#if BloonsTD6
            towerModel.display = CreatePrefabReference(Id);
#endif
            Apply(towerModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given ProjectileModel
        /// </summary>
        public virtual void Apply(ProjectileModel projectileModel) {
#if BloonsTD6
            projectileModel.display = CreatePrefabReference(Id);
#endif
            Apply(projectileModel.GetBehavior<DisplayModel>()!);
        }

        /// <summary>
        /// Applies this ModDisplay to a given DisplayModel
        /// </summary>
        public virtual void Apply(DisplayModel displayModel) {
            displayModel.display = CreatePrefabReference(Id);
#if BloonsTD6
            displayModel.positionOffset = PositionOffset;
            displayModel.scale = Scale;
#endif
        }

        #endregion


        #region Internal Display Loading

        /// <summary>
        /// Gets the prototype to use for a callback in CreateAsync
        /// </summary>
        /// <returns>Whether to still call the original CreateAsync callback</returns>
        internal void Create(Factory factory, PrefabReference prefabReference, Action<UnityDisplayNode> onComplete) {
            GetBasePrototype(factory, node => {
                var newPrototype = CreateNewPrototype(factory, prefabReference, node);
                SetupUDN(newPrototype, () => {
                    var newNode = CreateAsyncCallback(factory, prefabReference, newPrototype);
                    onComplete.Invoke(newNode);
                });
            });
        }

        internal virtual void GetBasePrototype(Factory factory, Action<UnityDisplayNode> onComplete) {
            factory.FindAndSetupPrototypeAsync(BaseDisplayReference, onComplete);
        }

        /// <summary>
        /// Recreated version of the CreateAsync_b__0 callback. Would like to just call this directly, but manually
        /// messing with the __DisplayClass_s proved buggy.
        /// </summary>
        /// <returns>The unity display node for the newly created display</returns>
        internal UnityDisplayNode CreateAsyncCallback(Factory factory, PrefabReference prefabReference,
            UnityDisplayNode prototype) {
            var position = new Vector3(Factory.kOffscreenPosition.x, 0, 0);
            var rotation = Quaternion.identity;
            var newPrototype = Object.Instantiate(prototype.gameObject, position, rotation, factory.DisplayRoot);
            newPrototype.SetActive(true);
            var newNode = newPrototype.GetComponent<UnityDisplayNode>();
            newNode.Create();
            newNode.cloneOf = prefabReference;
            factory.active.Add(newNode);
            return newNode;
        }

        /// <summary>
        /// Creates and stores a new prototype for a prefab reference based on an original prototype
        /// </summary>
        internal UnityDisplayNode CreateNewPrototype(Factory factory, PrefabReference prefabReference,
            UnityDisplayNode prototype) {
            var parent = Game.instance.prototypeObjects.transform;
            var gameObject = Object.Instantiate(prototype.gameObject, parent);
            gameObject.name = Id + "(Clone)";
            var manager = Addressables.Instance.ResourceManager;
            factory.prototypeHandles[prefabReference] = manager.CreateCompletedOperation(gameObject, "");
            return gameObject.GetComponent<UnityDisplayNode>();
        }


        /// <summary>
        /// Applies the effects of a ModDisplay on a UnityDisplayNode
        /// </summary>
        internal void SetupUDN(UnityDisplayNode udn, Action onComplete) {
            udn.RecalculateGenericRenderers();
            try {
                ModifyDisplayNode(udn);
            } catch (Exception e) {
                ModHelper.Error($"Failed to modify DisplayNode for {Name}");
                ModHelper.Error(e);
            }

            try {
                if (Scale is < 1f or > 1f) {
                    udn.transform.GetChild(0).transform.localScale = Scale * Vector3.one;
                }
            } catch (Exception e) {
                ModHelper.Error($"Failed to change scale for {Name}");
                ModHelper.Error(e);
            }

            udn.RecalculateGenericRenderers();

            ModifyDisplayNodeAsync(udn, onComplete);
        }

        #endregion


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