// Adapted from WarperSan's BossPack 

using System;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
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
    /// <summary>
    /// <see cref="ModBoss"/>s that have been registered. Key is the <see cref="BossTypeInt"/>
    /// </summary>
    internal static readonly new Dictionary<int, ModBoss> Cache = new();
    internal readonly new List<ModBossTierDisplay> displays = new();
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
    public ModBossTier CurrentTier { get; internal set; }

    /// <summary>
    /// Apply your custom modifications to the base bloonModel
    /// </summary>
    /// <param name="bloonModel"></param>
    public abstract void ModifyBaseBloon(BloonModel bloonModel);

    /// <summary>
    /// Called to modify rounds for the boss roundset
    /// </summary>
    /// <remarks>
    /// Used in the same way as <see cref="ModRoundSet.ModifyRoundModels"/>
    /// </remarks>
    public virtual void ModifyRoundModels(RoundModel roundModel, int round)
    {
    }

    internal void OnSpawnCallback(Bloon boss)
    {
        OnSpawn(boss);
        CurrentTier.OnSpawn(boss);
    }

    internal void OnLeakCallback(Bloon boss)
    {
        OnLeak(boss);
        CurrentTier.OnLeak(boss);
    }

    internal void OnPopCallback(Bloon boss)
    {
        OnPop(boss);
        CurrentTier.OnPop(boss);
    }

    internal void OnDamageCallback(Bloon boss, float totalAmount)
    {
        OnDamage(boss, totalAmount);
        CurrentTier.OnDamage(boss, totalAmount);
    }

    internal void SkullReachedCallback(Bloon boss, int skullNumber)
    {
        SkullReached(boss, skullNumber);
        CurrentTier.SkullReached(boss, skullNumber);
    }

    internal void TimerTickCallback(Bloon boss)
    {
        TimerTick(boss);
        CurrentTier.TimerTick(boss);
    }

    /// <summary>
    /// Called when the boss is spawned, will be called before the current tier's <see cref="ModBossTier.OnSpawn"/>
    /// </summary>
    /// <remarks>Called when loading saves and continuing from checkpoints as well</remarks>
    /// <param name="boss"></param>
    public virtual void OnSpawn(Bloon boss)
    {
    }

    /// <summary>
    /// Called when the boss is leaked, will be called before the current tier's <see cref="ModBossTier.OnLeak"/>
    /// </summary>
    /// <param name="boss"></param>
    public virtual void OnLeak(Bloon boss)
    {
    }

    /// <summary>
    /// Called when the boss is popped, will be called before the current tier's <see cref="ModBossTier.OnPop"/>
    /// </summary>
    /// <param name="boss"></param>
    public virtual void OnPop(Bloon boss)
    {
    }

    /// <summary>
    /// Called when the boss takes damage, will be called before the current tier's <see cref="ModBossTier.OnDamage"/>
    /// </summary>
    /// <param name="boss"></param>
    /// <param name="totalAmount"></param>
    public virtual void OnDamage(Bloon boss, float totalAmount)
    {
    }

    /// <summary>
    /// Called when the boss reaches a skull, will be called before the current tier's <see cref="ModBossTier.SkullReached"/>
    /// </summary>
    /// <param name="boss"></param>
    /// <param name="skullNumber"></param>
    public virtual void SkullReached(Bloon boss, int skullNumber)
    {
    }

    /// <summary>
    /// Called when the boss timer triggers, only called if <see cref="ModBossTier.Interval"/> is not null. Will be called before the current tier's <see cref="ModBossTier.TimerTick"/>
    /// </summary>
    /// <param name="boss"></param>
    public virtual void TimerTick(Bloon boss)
    {
    }

    /// <summary>
    /// The Portrait used in the game over screen when the boss has been defeated
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string DefeatedPortrait => GetType().Name + "-DefeatedPortrait";

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
    /// The display name of <see cref="BossMusic"/>, will be shown in the pause menu
    /// </summary>
    public virtual string BossMusicName => DisplayName + "-Music";

    internal string TrackFX {get; set; }

    /// <summary>
    /// If you're not going to use a <see cref="TrackFXDisplay"/> for your TrackFX, use this to directly control its PrefabReference
    /// </summary>
    public virtual PrefabReference TrackFXReference => CreatePrefabReference(TrackFX);

    internal string AmbientMapFX { get; set; }

    /// <summary>
    /// If you're not going to use a <see cref="AmbientMapFXDisplay"/> for your AmbientMapFX, use this to directly control its PrefabReference
    /// </summary>
    public virtual PrefabReference AmbientMapFXReference => CreatePrefabReference(AmbientMapFX);

    /// <summary>
    /// Custom actions that are triggered when the boss reaches a skull, look at ingame boss bloons for valid ids
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.CustomSkullActionIDs"/>, if it is set
    /// </remarks>
    public virtual IEnumerable<string> CustomSkullActionIDs => Array.Empty<string>();

    /// <summary>
    /// Amount of skulls the boss has
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.Skulls"/>, if it is set
    /// </remarks>
    public virtual int Skulls => 0;

    /// <summary>
    /// Positions of the skulls as a float from 0 to 1
    /// </summary>
    /// <remarks>
    /// If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)
    /// </remarks>
    public virtual float[] SkullPositions { get; set; }

    /// <summary>
    /// Determines if the boss's health should go down while it's skull effect is active (only applicable to existing, ingame actions)
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.PreventFallThrough"/>, if it is set
    /// </remarks>
    public virtual bool PreventFallThrough => false;

    /// <summary>
    /// Custom actions that are triggered when the boss timer triggers, look at ingame boss bloons for valid ids
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.CustomTimerActionIDs"/>, if it is set
    /// </remarks>
    public virtual IEnumerable<string> CustomTimerActionIDs => Array.Empty<string>();

    /// <summary>
    /// Determines if the timer triggers when the boss is spawned (only applicable to existing, ingame actions)
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.TriggerImmediately"/>, if it is set
    /// </remarks>
    public virtual bool TriggerImmediately => false;

    /// <summary>
    /// Interval between ticks for the boss' timer, if null, the timer will not be created
    /// </summary>
    /// <remarks>
    /// Will be completely overriden by the current tier's <see cref="ModBossTier.Interval"/>, if it is set
    /// </remarks>
    public virtual float? Interval => null;

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
        bloonModel.damageDisplayStates = new Il2CppReferenceArray<DamageStateModel>(0);

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
            tier.bloonModel = tierBloonModel;

            if (tier.Tier > highestTier)
                highestTier = tier.Tier;

            displays.Find(display => display.Tiers.Contains(tier.Tier) && display.Damage == 0)?.Apply(tierBloonModel);
            var damageDisplays = displays
                .Where(display => display.Tiers.Contains(tier.Tier) && display.Damage > 0)
                .OrderBy(display => display.Damage)
                .ToList();
            if (damageDisplays.Any())
            {
                ApplyDamageStates(tierBloonModel, damageDisplays.Select(display => display.Id).ToList());
            }

            Game.instance.model.bloons = Game.instance.model.bloons.AddTo(tierBloonModel);
            Game.instance.model.AddChildDependant(tierBloonModel);
            Game.instance.model.bloonsByName[tierBloonModel.name] = tierBloonModel;
            BloonModelCache[tierBloonModel.name] = tierBloonModel;
        }

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