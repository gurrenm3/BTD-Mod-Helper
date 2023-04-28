using System;
using System.Linq;
using Il2CppAssets.Scripts.Data.Skins;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Utils;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Class for adding a custom Hero to the game. Use alongside <see cref="ModHeroLevel"/> to give multiple levels.
/// </summary>
public abstract class ModHero : ModTower
{
    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
        ModTowerHelper.FinalizeHero(this);
    }

    /// <inheritdoc />
    public override void RegisterText(Dictionary<string, string> textTable)
    {
        base.RegisterText(textTable);

        textTable[Id + " Short Description"] = Title;
        textTable[Id + " Level 1 Description"] = Level1Description;
    }

    internal override string[] DefaultMods => base.DefaultMods.Concat(new[]
    {
        "EmpoweredHeroes", "HeroicReach", "HeroicVelocity", "QuickHands",
        "Scholarships", "SelfTaughtHeroes", "WeakPoint"
    }).ToArray();

    internal sealed override int UpgradePaths => 1;

    /// <summary>
    /// Heroes aren't in the default shop
    /// </summary>
    public sealed override bool DontAddToShop => true;

    /// <summary>
    /// No paragon heroes
    /// </summary>
    public sealed override ParagonMode ParagonMode => ParagonMode.None;

    /// <summary>
    /// The default hero (or tower) to base your hero off of
    /// </summary>
    public override string BaseTower => TowerType.Quincy;

    /// <summary>
    /// Heroes can only be in the Hero tower set
    /// </summary>
    public sealed override TowerSet TowerSet => TowerSet.Hero;

    /// <summary>
    /// Putting all the hero level upgrades in the top path
    /// </summary>
    public sealed override int TopPathUpgrades => MaxLevel;

    /// <summary>
    /// No other upgrade paths used
    /// </summary>
    public sealed override int MiddlePathUpgrades => 0;

    /// <summary>
    /// No other upgrade paths used
    /// </summary>
    public sealed override int BottomPathUpgrades => 0;

    /// <summary>
    /// Heroes tower tiers are always Level-0-0
    /// </summary>
    /// <returns></returns>
    public sealed override System.Collections.Generic.IEnumerable<int[]> TowerTiers()
    {
        yield return new[] {0, 0, 0};

        for (var i = 2; i <= MaxLevel; i++)
        {
            yield return new[] {i, 0, 0};
        }
    }

    internal override TowerModel GetDefaultTowerModel(int[] tiers = null)
    {
        var baseTowerModel = base.GetDefaultTowerModel(tiers);
        if (!baseTowerModel.HasBehavior<HeroModel>())
        {
            // Unrelated to the actual XpRatio weirdly enough
            baseTowerModel.AddBehavior(new HeroModel($"HeroModel_{Name}", 1.0f, 1.0f));
        }

        return baseTowerModel;
    }

    internal override string TowerId(int[] tiers)
    {
        var id = Id;
        if (tiers[0] > 0)
        {
            id += " " + tiers[0];
        }

        return id;
    }

    /// <summary>
    /// The other hero that has the same colored name in the Heroes menu as you want to use
    /// </summary>
    public virtual string NameStyle => TowerType.Ezili;

    /// <summary>
    /// The other hero that has the same glow color in the Heroes menu as you want to use
    /// </summary>
    public virtual string GlowStyle => TowerType.Ezili;

    /// <summary>
    /// The other hero that has the same background color in the Heroes menu as you want to use
    /// </summary>
    public virtual string BackgroundStyle => TowerType.Ezili;

    /// <summary>
    /// The png name of the Button icon for this hero in the UI, by default Name-Button
    /// </summary>
    public virtual string Button => GetType().Name + "-Button";

    /// <summary>
    /// The exact sprite reference used for the button
    /// </summary>
    public virtual SpriteReference ButtonReference => GetSpriteReferenceOrDefault(Button);

    /// <summary>
    /// The name of the png to try to find for the new hero select screen button
    /// </summary>
    public virtual string Square => GetType().Name + "-Square";

    /// <summary>
    /// The SpriteReference for this hero's Square icon in the new revamped HeroScreen
    /// </summary>
    public virtual SpriteReference SquareReference => GetSpriteReferenceOrDefault(Square);

    /// <summary>
    /// If you want to manually override which portraits your hero uses in the select screen, mess with this
    /// <br/>
    /// By default will find any <see cref="ModUpgrade.PortraitReference"/>s defined in your <see cref="ModHeroLevel"/>s
    /// <br/>
    /// The SpriteReference is the actual image that will be displayed
    /// </summary>
    public virtual System.Collections.Generic.Dictionary<int, SpriteReference> SelectScreenPortraits => new()
    {
        {1, PortraitReference},
        {3, GetPortraitReferenceForTiers(new []{3, 0, 0})},
        {10, GetPortraitReferenceForTiers(new []{10, 0, 0})},
        {20, GetPortraitReferenceForTiers(new []{20, 0, 0})},
    };
    

    /// <summary>
    /// The total number of levels this hero has. Do not set this to anything other than number of ModHeroLevels
    /// that you've actually created for your Hero.
    /// </summary>
    public abstract int MaxLevel { get; }

    /// <summary>
    /// XpRatio to use when determining the default xp costs of the levels.
    /// <br/>
    /// All four base heroes (Quincy, Gwendolin, Striker Jones, Obyn Greenfoot) as well as Etienne have an XP ratio of 1x.
    /// <br/>
    /// Ezili, Pat Fusty, Admiral Brickell, and Sauda have a 1.425x XP ratio.
    /// <br/>
    /// Benjamin and Psi have an XP ratio of 1.5x.
    /// <br/>
    /// Captain Churchill and Adora have a ratio of 1.71x.
    /// </summary>
    public abstract float XpRatio { get; }

    /// <summary>
    /// The short description that appears under the name of the hero
    /// </summary>
    public abstract string Title { get; }

    /// <summary>
    /// The description to use for the first level of your hero
    /// </summary>
    public abstract string Level1Description { get; }

    /// <summary>
    /// The total number of abilities that this hero has as max level
    /// <br/>
    /// OBSOLETE: No longer required to manually specify
    /// </summary>
    [Obsolete("No longer required to manually specify")]
    public virtual int Abilities { get; }

    /// <summary>
    /// Gets the font material for the default SkinData
    /// </summary>
    /// <param name="skinsByName">Existing hero skins by their skin/tower name</param>
    public virtual Material GetFontMaterial(System.Collections.Generic.Dictionary<string, SkinData> skinsByName) =>
        skinsByName.TryGetValue(NameStyle, out var dataForFont)
            ? dataForFont.fontMaterial
            : skinsByName[TowerType.Quincy].fontMaterial;

    /// <summary>
    /// Gets the Background Banner for the default SkinData
    /// </summary>
    /// <param name="skinsByName">Existing hero skins by their skin/tower name</param>
    public virtual PrefabReference GetBackgroundBanner(System.Collections.Generic.Dictionary<string, SkinData> skinsByName) =>
        skinsByName.TryGetValue(GlowStyle, out var dataForFont)
            ? dataForFont.backgroundBanner
            : skinsByName[TowerType.Quincy].backgroundBanner;

    /// <summary>
    /// Gets the background color for the default SkinData
    /// </summary>
    /// <param name="skinsByName">Existing hero skins by their skin/tower name</param>
    public virtual Color GetBackgroundColor(System.Collections.Generic.Dictionary<string, SkinData> skinsByName) =>
        skinsByName.TryGetValue(BackgroundStyle, out var dataForFont)
            ? dataForFont.backgroundColourTintOverride
            : skinsByName[TowerType.Quincy].backgroundColourTintOverride;

    /// <summary>
    /// Creates the SkinData for the default tower
    /// </summary>
    /// <param name="skinsByName">Existing hero skins by their skin/tower name</param>
    public virtual SkinData CreateDefaultSkin(System.Collections.Generic.Dictionary<string, SkinData> skinsByName)
    {
        var skinData = ScriptableObject.CreateInstance<SkinData>();
        skinData.name = skinData.baseTowerName = Id;
        skinData.skinName = Id + " Short Description";
        skinData.description = Id + " Description";
        skinData.icon = ButtonReference;
        skinData.iconSquare = SquareReference;
        skinData.isDefaultTowerSkin = true;

        skinData.unlockedEventSound = new AudioSourceReference
        {
            guidRef = SelectSound
        };
        skinData.unlockedVoiceSound = new AudioSourceReference
        {
            guidRef = ""
        };

        skinData.textMaterialId = NameStyle;
        skinData.fontMaterial = GetFontMaterial(skinsByName);
        skinData.backgroundBanner = GetBackgroundBanner(skinsByName);
        skinData.backgroundColourTintOverride = GetBackgroundColor(skinsByName);

        skinData.StorePortraitsContainer = new PortraitContainer
        {
            items = SelectScreenPortraits.Select(pair => new StorePortraits
            {
                levelTxt = pair.Key.ToString(),
                asset = pair.Value
            }).ToIl2CppList()
        };
        
        // ReSharper disable ArrangeObjectCreationWhenTypeNotEvident
        skinData.SwapAudioContainer = new SwapAudioContainer {items = new()};
        skinData.SwapOverlayContainer = new SwapOverlayContainer {items = new()};
        skinData.SwapPrefabContainer = new SwapPrefabContainer {items = new()};
        skinData.SwapSpriteContainer = new SwapSpriteContainer {items = new()};

        return skinData;
    }

    /// <summary>
    /// Sound to play when you select this hero in the hero select screen, the sound must be registered in the game for it to play
    /// </summary>
    public virtual string SelectSound => "";

    /// <summary>
    /// The index to add this hero at in relation to other heroes
    /// </summary>
    /// <param name="heroSet"></param>
    /// <returns></returns>
    public virtual int GetHeroIndex(System.Collections.Generic.List<HeroDetailsModel> heroSet)
    {
        return heroSet.Count;
    }
}