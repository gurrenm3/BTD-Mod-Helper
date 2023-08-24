// Adapted from WarperSan's BossPack 

using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Bloons.Bosses;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{
    internal static readonly new Dictionary<string, ModBoss> Cache = new();
    internal static readonly Dictionary<int, ModBoss> BossesByInt = new();

    internal static int NextBossType { get; private set; } = (int) (Enum.GetValues<BossType>()[^1] + 1);
    internal int BossTypeInt { get; private set; }
    internal BossType BossType => (BossType) BossTypeInt;

    public const string EventId = "ModBoss";
    public const string BossTypeKey = "ModBoss-BossType";
    public const string IsEliteKey = "ModBoss-IsElite";

    internal List<ModBossTier> tiers = new();
    internal SortedList<int, ModBossTier> tiersByRound = new();
    internal int highestTier = 0;

    /// <summary>
    /// The current spawned tier of the boss, may be null
    /// </summary>
    public ModBossTier CurrentTier { get; internal set; }


    /// <summary>
    /// Apply your custom modifications to the base bloonModel
    /// </summary>
    /// <param name="bloonModel"></param>
    public abstract void ModifyBaseBloon(BloonModel bloonModel);

    internal void OnSpawn(Bloon bloon)
    {
        CurrentTier.OnSpawn(bloon);
    }

    internal void OnLeak(Bloon bloon)
    {
        CurrentTier.OnLeak(bloon);
    }

    internal void OnPop(Bloon bloon)
    {
        CurrentTier.OnPop(bloon);
    }

    internal void OnDamage(Bloon bloon, float totalAmount)
    {
        CurrentTier.OnDamage(bloon, totalAmount);
    }

    /// <summary>
    /// Called to modify any/all rounds from 1 to a maximum of 139/>
    /// </summary>
    public virtual void ModifyRoundModels(RoundModel roundModel, int round)
    {
    }

    #region Icons

    /// <summary>
    /// The Portrait used when the boss has been defeated
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string DefeatedPortrait => GetType().Name+"-DefeatedPortrait";

    /// <summary>
    /// If you're not going to use a custom .png for your DefeatedPortrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference DefeatedPortraitReference => GetSpriteReferenceOrDefault(DefeatedPortrait);

    /// <summary>
    /// The Portrait used when the boss defeats the player
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string AlivePortrait => GetType().Name + "-AlivePortrait";

    /// <summary>
    /// If you're not going to use a custom .png for your AlivePortrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference AlivePortraitReference => GetSpriteReferenceOrDefault(AlivePortrait);

    /// <summary>
    /// The icon used for the "Boss Appears in X rounds" panel and health bar //todo: confirm this
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string HudIcon => Icon;

    /// <summary>
    /// If you're not going to use a custom .png for your HudIcon, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference HudIconReference => GetSpriteReferenceOrDefault(HudIcon);

    /// <summary>
    /// The sound played when the boss spawns
    /// </summary>
    public virtual AudioClip BossMusic => null;

    /// <summary>
    /// The name of the sound played when the boss spawns, will be shown in the pause menu
    /// </summary>
    public virtual string BossMusicName => DisplayName + "-Music";

    #endregion

    /// <summary>
    /// The rounds the boss should spawn on
    /// </summary>
    internal IEnumerable<int> SpawnRounds => tiers.Select(x => x.Round - 1);

    /// <inheritdoc />
    public sealed override string BaseBloon => BloonType.Bad;

    /// <inheritdoc/>
    public sealed override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.RemoveAllChildren();
        bloonModel.danger = 16;
        bloonModel.overlayClass = BloonOverlayClass.Dreadbloon;
        bloonModel.bloonProperties = BloonProperties.None;
        bloonModel.tags = new Il2CppStringArray(new[] {"Bad", "Moabs", "Boss"});
        bloonModel.isBoss = true;

        ModifyBaseBloon(bloonModel);
    }


    /// <inheritdoc />
    public override void Register()
    {
        if (tiers.Count == 0)
            return;
        base.Register();
        BossTypeInt = NextBossType;
        BossesByInt[BossTypeInt] = this;

        NextBossType++;

        foreach (var tier in tiers)
        {
            var tierBloonModel = bloonModel.Duplicate();
            tier.SetupSkulls(tierBloonModel);
            tier.SetupTimer(tierBloonModel);

            tier.ModifyBaseBoss(tierBloonModel);

            tierBloonModel.name = tierBloonModel.id = BossTypeInt.ToString() + tier.Tier;
            tierBloonModel.baseId = bloonModel.id;


            Game.instance.model.bloons = Game.instance.model.bloons.AddTo(tierBloonModel);
            Game.instance.model.AddChildDependant(tierBloonModel);
            Game.instance.model.bloonsByName[tierBloonModel.name] = tierBloonModel;
            BloonModelCache[tierBloonModel.name] = tierBloonModel;
            ModBossTier.Cache[tierBloonModel.name] = tier;
        }
        Cache[bloonModel.name] = this;

        var normal = new BossRoundSet(BossType, false);
        //var elite = new BossRoundSet(BossType, true);
        ModHelper.GetMod<MelonMain>().AddContent(normal);
        //ModHelper.GetMod<MelonMain>().AddContent(elite);
        normal.Register();
        //elite.Register();
    }

    /// <inheritdoc />
    public sealed override bool KeepBaseId => false;

    /// <inheritdoc />
    public sealed override bool Regrow => false;

    /// <inheritdoc />
    public sealed override string RegrowsTo => "";

    /// <inheritdoc />
    public sealed override float RegrowRate => 3;
}