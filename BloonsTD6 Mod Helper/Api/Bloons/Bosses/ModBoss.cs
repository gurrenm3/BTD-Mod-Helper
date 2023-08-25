// Adapted from WarperSan's BossPack 

using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Data.Boss;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Bloons.Bosses;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{
    internal static readonly new Dictionary<int, ModBoss> Cache = new();

    internal static int NextBossType { get; private set; } = (int) (Enum.GetValues<BossType>()[^1] + 1);
    internal int BossTypeInt { get; private set; }
    internal BossType BossType => (BossType) BossTypeInt;

    internal const string EventId = "ModBoss";
    internal const string BossTypeKey = "ModBoss-BossType";
    internal const string IsEliteKey = "ModBoss-IsElite";

    internal readonly List<ModBossTier> tiers = new();
    internal readonly SortedList<int, ModBossTier> tiersByRound = new();
    internal int highestTier = 0;

    /// <summary>
    /// The current spawned tier of the boss, may be null
    /// </summary>
    public ModBossTier CurrentTier { get; internal set; } //todo: get this set on save continue

    /// <summary>
    /// Apply your custom modifications to the base bloonModel
    /// </summary>
    /// <param name="bloonModel"></param>
    public abstract void ModifyBaseBloon(BloonModel bloonModel);

    /// <summary>
    /// Called to modify rounds for the boss roundset/>
    /// </summary>
    /// <remarks>
    /// Used in the same way as <see cref="ModRoundSet.ModifyRoundModels"/>
    /// </remarks>
    public virtual void ModifyRoundModels(RoundModel roundModel, int round)
    {
    }

    internal void OnSpawnCallback(Bloon bloon)
    {
        CurrentTier.OnSpawn(bloon);
        OnSpawn(bloon);
    }

    internal void OnLeakCallback(Bloon bloon)
    {
        CurrentTier.OnLeak(bloon);
        OnLeak(bloon);
    }

    internal void OnPopCallback(Bloon bloon)
    {
        CurrentTier.OnPop(bloon);
        OnPop(bloon);
    }

    internal void OnDamageCallback(Bloon bloon, float totalAmount)
    {
        CurrentTier.OnDamage(bloon, totalAmount);
        OnDamage(bloon, totalAmount);
    }

    internal void SkullReachedCallback(Bloon bloon)
    {
        CurrentTier.SkullReached(bloon);
        SkullReached(bloon);
    }

    internal void TimerTickCallback(Bloon bloon)
    {
        CurrentTier.TimerTick(bloon);
        TimerTick(bloon);
    }

    /// <summary>
    /// Called when the boss is spawned, will be called after the current tier's <see cref="ModBossTier.OnSpawn"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnSpawn(Bloon bloon) //todo: fix this not getting called on retry last round
    {
    }

    /// <summary>
    /// Called when the boss is leaked, will be called after the current tier's <see cref="ModBossTier.OnLeak"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnLeak(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss is popped, will be called after the current tier's <see cref="ModBossTier.OnPop"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnPop(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss takes damage, will be called after the current tier's <see cref="ModBossTier.OnDamage"/>
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="totalAmount"></param>
    public virtual void OnDamage(Bloon bloon, float totalAmount)
    {
    }

    /// <summary>
    /// Called when the boss reaches a skull, will be called after the current tier's <see cref="ModBossTier.SkullReached"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void SkullReached(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss timer triggers, only called if <see cref="ModBossTier.Interval"/> is not null. Will be called after the current tier's <see cref="ModBossTier.SkullReached"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void TimerTick(Bloon bloon)
    {
    }

    /// <summary>
    /// The Portrait used in the game over screen when the boss has been defeated
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string DefeatedPortrait => GetType().Name+"-DefeatedPortrait";

    /// <summary>
    /// If you're not going to use a custom .png for your DefeatedPortrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference DefeatedPortraitReference => GetSpriteReferenceOrDefault(DefeatedPortrait);

    /// <summary>
    /// The Portrait used in the game over screen when the boss defeats the player
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string AlivePortrait => GetType().Name + "-AlivePortrait";

    /// <summary>
    /// If you're not going to use a custom .png for your AlivePortrait, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference AlivePortraitReference => GetSpriteReferenceOrDefault(AlivePortrait);

    /// <summary>
    /// The icon used for the "Boss Appears in X rounds" panel and health bar
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

    //todo: figure out exactly how these will be specified, since they use MapLoader.AddAsset, maybe a new display class?
    /// <summary>
    /// The object that will be placed on the boss' spawn point on the track
    /// </summary>
    public virtual string TrackFX => "";

    /// <summary>
    /// If you're not going to use a custom display for your TrackFX, use this to directly control its SpriteReference
    /// </summary>
    public virtual PrefabReference TrackFXReference => CreatePrefabReference(TrackFX);

    /// <summary>
    /// The object that will be placed on the boss' spawn point on the track
    /// </summary>
    public virtual string AmbientMapFX => "";

    /// <summary>
    /// If you're not going to use a custom display for your TrackFX, use this to directly control its SpriteReference
    /// </summary>
    public virtual PrefabReference AmbientMapFXReference => CreatePrefabReference(AmbientMapFX);

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
    public override void RegisterText(Il2CppSystem.Collections.Generic.Dictionary<string, string> textTable)
    {
        base.RegisterText(textTable);
        if (BossMusic != null)
            textTable[BossMusic.GetName()] = BossMusicName;
    }

    /// <inheritdoc />
    public override void Register()
    {
        if (tiers.Count == 0)
            return;
        base.Register();
        BossTypeInt = NextBossType;
        Cache[BossTypeInt] = this;

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
        }
        ModBloon.Cache[bloonModel.name] = this;

        var roundSet = new ModBossRoundSet(BossType, false);
        ModHelper.GetMod<MelonMain>().AddContent(roundSet);
        roundSet.Register();
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