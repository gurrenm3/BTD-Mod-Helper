using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Effects;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Color = UnityEngine.Color;
using Object = UnityEngine.Object;
using Vector3 = Il2CppAssets.Scripts.Simulation.SMath.Vector3;
namespace BTD_Mod_Helper.Api.Display;

/// <summary>
/// A custom Display that is a copy of an existing Display that can be modified
/// </summary>
public abstract class ModDisplay : ModContent
{
    internal static readonly Dictionary<string, ModDisplay> Cache = new();

    /// <summary>
    /// ModDisplays register first
    /// </summary>
    /// <exclude />
    protected sealed override float RegistrationPriority => 1;

    /// <inheritdoc />
    public sealed override int RegisterPerFrame => 10;

    /// <summary>
    /// The GUID of the display to copy this ModDisplay off of
    /// </summary>
    public virtual string BaseDisplay => "";

    /// <summary>
    /// The prefab reference itself of the base display that will be used
    /// </summary>
    public virtual PrefabReference BaseDisplayReference => CreatePrefabReference(BaseDisplay);

    /// <summary>
    /// The position offset to render the display at (z axis is up toward camera)
    /// </summary>
    public virtual Vector3 PositionOffset => new(0);

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
    /// The DisplayCategory to use for the DisplayModel
    /// </summary>
    public virtual DisplayCategory DisplayCategory => DisplayCategory.Default;

    /// <inheritdoc />
    public override void Register()
    {
        Cache[Id] = this;
    }

    /// <summary>
    /// Alters the UnityDisplayNode that was copied from the one used by <see cref="BaseDisplay" />
    /// </summary>
    /// <param name="node">The prototype unity display node</param>
    public virtual void ModifyDisplayNode(UnityDisplayNode node)
    {
    }

    /// <summary>
    /// Allows you to modify this node asynchronously. On complete must be called for load to work! Takes
    /// place after the non-async ModifyDisplayNode call
    /// </summary>
    /// <param name="node">The prototype unity display node</param>
    /// <param name="onComplete">Callback for when you've finished changing the node</param>
    public virtual void ModifyDisplayNodeAsync(UnityDisplayNode node, Action onComplete)
    {
        onComplete();
    }

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
    /// <param name="index">The index to set at</param>
    protected void SetMeshTexture(UnityDisplayNode node, string textureName, int index)
    {
        node.GetMeshRenderer(index).SetMainTexture(GetTexture(textureName));
    }

    /// <summary>
    /// Sets the outline color for the first mesh renderer in the given node
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="color">The color for it to be outlined (when not highlighted)</param>
    protected void SetMeshOutlineColor(UnityDisplayNode node, Color color)
    {
        node.GetMeshRenderer().SetOutlineColor(color);
    }

    /// <summary>
    /// Sets the outline color for the index'th mesh renderer in the given node
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="color">The color for it to be outlined (when not highlighted)</param>
    /// <param name="index">What index of mesh renderer to use</param>
    protected void SetMeshOutlineColor(UnityDisplayNode node, Color color, int index)
    {
        node.GetMeshRenderer(index).SetOutlineColor(color);
    }

    /// <summary>
    /// Sets the sprite texture to that of a named png
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="textureName">The name of the texture, without .png</param>
    protected void Set2DTexture(UnityDisplayNode node, string textureName)
    {
#pragma warning disable CS0618
        var sprite = GetSprite(textureName, PixelsPerUnit);
#pragma warning restore CS0618
        node.GetRenderer<SpriteRenderer>().sprite = sprite;
        node.IsSprite = true;
    }

    /// <summary>
    /// Gets a new DisplayModel based on this ModDisplay
    /// </summary>
    /// <returns></returns>
    public DisplayModel GetDisplayModel() => new($"DisplayModel_{Name}", CreatePrefabReference(Id), 0, DisplayCategory,
        PositionOffset, Scale);

    /// <summary>
    /// Gets the Display for a given tower, optionally for the given tiers
    /// </summary>
    /// <param name="tower">The tower base id</param>
    /// <param name="top">Path 1 tier</param>
    /// <param name="mid">Path 2 tier</param>
    /// <param name="bot">Path 3 tier</param>
    /// <returns>The display GUID</returns>
    protected string GetDisplay(string tower, int top = 0, int mid = 0, int bot = 0) =>
        Game.instance.model.GetTower(tower, top, mid, bot).display.AssetGUID;

    /// <summary>
    /// Gets the Display for a given bloon
    /// </summary>
    /// <param name="bloon"> The bloon base id</param>
    /// <returns>The display GUID</returns>
    protected string GetBloonDisplay(string bloon) =>
        Game.instance.model.GetBloon(bloon).display.AssetGUID;

    /// <summary>
    /// Gets a UnityDisplayNode for a different guid
    /// </summary>
    /// <param name="guid">The asset reference guid to get the node from</param>
    /// <param name="action">What to do with the node</param>
    /// <param name="displayCategory"></param>
    protected void UseNode(string guid, Action<UnityDisplayNode> action, DisplayCategory displayCategory)
    {
        Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(CreatePrefabReference(guid),
            DisplayCategory.Default,
            new Action<UnityDisplayNode>(udn =>
            {
                udn.RecalculateGenericRenderers();
                action(udn);
                udn.RecalculateGenericRenderers();
            }));
    }

    /// <summary>
    /// Gets a UnityDisplayNode for a different guid
    /// </summary>
    /// <param name="guid">The asset reference guid to get the node from</param>
    /// <param name="action">What to do with the node</param>
    protected void UseNode(string guid, Action<UnityDisplayNode> action)
    {
        UseNode(guid, action, DisplayCategory.Default);
    }
    
    #region Applying Methods

    /// <summary>
    /// Applies this ModDisplay to a given BloonModel
    /// </summary>
    public virtual void Apply(BloonModel bloonModel)
    {
        bloonModel.SetDisplayGUID(Id);
        Apply(bloonModel.GetBehavior<DisplayModel>()!);
    }

    /// <summary>
    /// Applies this ModDisplay to a given TowerModel
    /// </summary>
    public virtual void Apply(TowerModel towerModel)
    {
        towerModel.display = CreatePrefabReference(Id);
        Apply(towerModel.GetBehavior<DisplayModel>()!);
    }

    /// <summary>
    /// Applies this ModDisplay to a given ProjectileModel
    /// </summary>
    public virtual void Apply(ProjectileModel projectileModel)
    {
        projectileModel.display = CreatePrefabReference(Id);
        Apply(projectileModel.GetBehavior<DisplayModel>()!);
    }

    /// <summary>
    /// Applies this ModDisplay to a given DisplayModel
    /// </summary>
    public virtual void Apply(DisplayModel displayModel)
    {
        displayModel.display = CreatePrefabReference(Id);

        displayModel.positionOffset = PositionOffset;
        displayModel.scale = Scale;
    }

    /// <summary>
    /// Applies this ModDisplay to a given EffectModel
    /// </summary>
    public virtual void Apply(EffectModel effectModel)
    {
        effectModel.assetId = CreatePrefabReference(Id);
    }

    /// <summary>
    /// Applies this ModDisplay to a given EffectModel
    /// </summary>
    public virtual void Apply(AssetPathModel assetPathModel)
    {
        assetPathModel.assetPath = CreatePrefabReference(Id);
    }

    #endregion


    #region Internal Display Loading

    /// <summary>
    /// Gets the prototype to use for a callback in CreateAsync
    /// </summary>
    internal void Create(Factory factory, PrefabReference prefabReference, Action<UnityDisplayNode> onComplete)
    {
        GetBasePrototype(factory, node =>
        {
            var newPrototype = CreateNewPrototype(factory, prefabReference, node);
            SetupUDN(newPrototype, () =>
            {
                var newNode = CreateAsyncCallback(factory, prefabReference, newPrototype);
                onComplete.Invoke(newNode);
            });
        });
    }

    internal virtual void GetBasePrototype(Factory factory, Action<UnityDisplayNode> onComplete)
    {
        factory.FindAndSetupPrototypeAsync(BaseDisplayReference, DisplayCategory, onComplete);
    }

    /// <summary>
    /// Recreated version of the CreateAsync_b__0 callback. Would like to just call this directly, but manually
    /// messing with the __DisplayClass_s proved buggy.
    /// </summary>
    /// <returns>The unity display node for the newly created display</returns>
    internal UnityDisplayNode CreateAsyncCallback(Factory factory, PrefabReference prefabReference,
        UnityDisplayNode prototype)
    {
        var position = new UnityEngine.Vector3(Factory.kOffscreenPosition.x, 0, 0);
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
        UnityDisplayNode prototype)
    {
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
    internal void SetupUDN(UnityDisplayNode udn, Action onComplete)
    {
        udn.RecalculateGenericRenderers();
        try
        {
            ModifyDisplayNode(udn);
        }
        catch (Exception e)
        {
            ModHelper.Error($"Failed to modify DisplayNode for {Name}");
            ModHelper.Error(e);
        }

        try
        {
            if (Scale is < 1f or > 1f)
            {
                for (var i = 0; i < udn.transform.childCount; i++)
                {
                    udn.transform.GetChild(i).localScale *= Scale;
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Error($"Failed to change scale for {Name}");
            ModHelper.Error(e);
        }

        udn.RecalculateGenericRenderers();

        ModifyDisplayNodeAsync(udn, onComplete);
    }

    #endregion


    #region Misc Display Ids

    /// <summary>
    /// The display id for Road Spikes
    /// </summary>
    public const string Generic2dDisplay = "9dccc16d26c1c8a45b129e2a8cbd17ba";
    /// <summary>
    /// The display id for a Red Bloon
    /// </summary>
    public const string Bloon2dDisplay = "9d3c0064c3ace7448bf8fefa4a97a70f";
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