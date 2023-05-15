//Adapted from WarperSan's BossPack 

using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{
    /// <inheritdoc />
    public sealed override string BaseBloon => BloonType.Bad;

    internal static readonly new Dictionary<string, ModBoss> Cache = new();

    internal ModHelperPanel HoldingPanel;
    internal ModHelperPanel BossPanel;

    /// <summary>
    /// The people who worked/helped to create the mod, but aren't the authors
    /// </summary>
    public virtual string ExtraCredits { get; }

    /// <summary>
    /// Called when the boss is spawned. Must not be overriden
    /// </summary>
    /// <param name="bloon"></param>
    public void OnSpawnMandatory(Bloon bloon)
    {
        int round = InGame.Bridge.GetCurrentRound() + 1;
        BossRoundInfo info = RoundsInfo[round];
        var percentageValues = info.percentageValues;

        if (bloon.bloonModel.HasBehavior<HealthPercentTriggerModel>() && percentageValues != null && percentageValues.Length != 0)
        {
            HealthPercentTriggerModel bossSkulls = bloon.bloonModel.GetBehavior<HealthPercentTriggerModel>();
            bossSkulls.percentageValues = percentageValues;
            bossSkulls.preventFallthrough = info.preventFallThrough != null ? (bool) info.preventFallThrough : false;
        }

        if (info.interval == null)
        {
            if (bloon.bloonModel.HasBehavior<TimeTriggerModel>())
            {
                bloon.bloonModel.RemoveBehavior<TimeTriggerModel>();
            }
        }
        else
        {
            if (!bloon.bloonModel.HasBehavior<TimeTriggerModel>())
            {
                bloon.bloonModel.AddBehavior(new TimeTriggerModel(Name + "-TimerTick"));
            }
            TimeTriggerModel timer = bloon.bloonModel.GetBehavior<TimeTriggerModel>();
            timer.actionIds = new string[] { Name + "TimerTick" };
            timer.interval = (float) info.interval;
            timer.triggerImmediately = info.triggerImmediately != null ? (bool) info.triggerImmediately : false;
        }

        BossPanel = AddBossPanel(HoldingPanel);
        HoldingPanel.SetActive(true);

        OnSpawn(bloon);
    }

    /// <summary>
    /// Called when the boss is spawned
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnSpawn(Bloon bloon) { }

    /// <summary>
    /// Called when the boss is leaked
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnLeak(Bloon bloon)
    {
        HoldingPanel.SetActive(false);
        GameObject.Destroy(BossPanel);
    }

    /// <summary>
    /// Called when the boss is popped
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnPop(Bloon bloon)
    {
        HoldingPanel.SetActive(false);
        GameObject.Destroy(BossPanel);
    }

    /// <summary>
    /// The speed of the boss, 4.5 is the default for a BAD and 25 is the default for a red bloon
    /// </summary>
    public virtual float Speed => this.bloonModel == null ? 4.5f : this.bloonModel.speed;

    /// <summary>
    /// The health of the boss
    /// </summary>
    public virtual float Health => this.bloonModel == null ? 20_000f : this.bloonModel.maxHealth;

    /// <summary>
    /// Defines if the boss is using the default waiting UI
    /// </summary>
    public virtual bool UsingDefaultWaitingUi => true;

    /// <summary>
    /// Creates the panel that shows "Boss appears in X rounds".
    /// </summary>
    /// <remarks>
    /// This must be overriden if UsingDefaultWaitingUi is set to false.
    /// </remarks>
    /// <param name="waitingHolderPanel"></param>
    /// <returns></returns>
    public virtual ModHelperPanel AddWaitPanel(ModHelperPanel waitingHolderPanel) => throw new System.NotImplementedException();

    /// <summary>
    /// Creates the panel for the Boss health bar
    /// </summary>
    /// <param name="holderPanel"></param>
    /// <returns></returns>
    public virtual ModHelperPanel AddBossPanel(ModHelperPanel holderPanel)
    {
        var panel = holderPanel.AddPanel(new Info("BossBar-" + Name, 0, -50, 1100, 175), VanillaSprites.SmallSquareWhite);
        var icon = holderPanel.AddImage(new Info(Name + "-Icon", -550, -50, 200, new Vector2(.1f, .5f)), ModContent.GetSprite(mod, Icon));

        // Icon
        // Stars
        // Slider
        // HP

        return panel;
    }

    /// <summary>
    /// Whether the boss should always cause defeat on leak
    /// </summary>
    public virtual bool AlwaysDefeatOnLeak => true;

    /// <summary>
    /// Whether the boss should block rounds from spawning, behaving like a normal bloon
    /// </summary>
    public virtual bool BlockRounds => false;

    /// <summary>
    /// The rounds the boss should spawn on
    /// </summary>
    public IEnumerable<int> SpawnRounds => RoundsInfo.Keys;

    /// <summary>
    /// Modifies the boss before it is spawned, based on the round
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="round"></param>
    /// <returns></returns>
    public virtual BloonModel ModifyForRound(BloonModel bloon, int round)
    {
        return bloon;
    }

    /// <summary>
    /// Informations about the boss on the round
    /// </summary>
    public abstract Dictionary<int, BossRoundInfo> RoundsInfo { get; }

    /// <summary>
    /// All the informations a boss holds for a specific round
    /// </summary>
    public struct BossRoundInfo
    {
        /// <summary>
        /// Tier of the boss on this round
        /// </summary>
        public uint? tier = null;

        /// <summary>
        /// Amount of skulls the boss has
        /// </summary>
        public uint? skullCount = null;

        /// <summary>
        /// Positions of the skulls
        /// </summary>
        /// <remarks>
        /// If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)
        /// </remarks>
        public float[] percentageValues = null;

        /// <summary>
        /// Determines if the boss's health should go down while it's skull effect is on
        /// </summary>
        public bool? preventFallThrough = null;

        /// <summary>
        /// Determines if the timer starts immediately
        /// </summary>
        public bool? triggerImmediately = null;

        /// <summary>
        /// Interval between ticks
        /// </summary>
        public float? interval = null;

        public BossRoundInfo() { }
    }

    /// <summary>
    /// The description of the skull effect (only used by the Boss API)
    /// </summary>
    public virtual string SkullDescription => "???";
    public bool UsesSkulls => RoundsInfo.Any(info => info.Value.skullCount > 0);

    public virtual void SkullEffectUi()
    {

    }

    /// <summary>
    /// Called when the boss hits a skull
    /// </summary>
    /// <param name="boss"></param>
    public virtual void SkullEffect(Bloon boss) { }

    /// <summary>
    /// The description of the timer effect (only used by the Boss API)
    /// </summary>
    public virtual string TimerDescription => "???";
    public bool UsesTimer => RoundsInfo.Any(info => info.Value.interval != null);

    /// <summary>
    /// Called when the boss timer ticks
    /// </summary>
    /// <param name="boss"></param>
    public virtual void TimerTick(Bloon boss) { }

    internal sealed override BloonModel GetDefaultBloonModel()
    {
        var original = base.GetDefaultBloonModel();
        original.RemoveAllChildren();
        original.danger = 16;
        original.overlayClass = BloonOverlayClass.Dreadbloon;
        original.bloonProperties = BloonProperties.None;
        original.tags = new Il2CppStringArray(new[] { "Bad", "Moabs", "Boss" });
        original.maxHealth = Health;
        original.speed = Speed;
        original.isBoss = true;

        return original;
    }

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();

        foreach (var item in SpawnRounds)
        {
            BossRoundInfo info = RoundsInfo[item];

            // Puts default skulls placement
            if (info.percentageValues == null && info.skullCount != null)
            {
                uint skullsCount = (uint) info.skullCount;

                List<float> percentageValues = new List<float>();

                if (skullsCount > 0)
                {
                    for (int i = 1; i <= skullsCount; i++)
                    {
                        percentageValues.Add(1f - 1f / (skullsCount + 1) * i);
                    }
                }

                info.percentageValues = percentageValues.ToArray();
            }
        }

        if (!bloonModel.HasBehavior<HealthPercentTriggerModel>())
        {
            bloonModel.AddBehavior(new HealthPercentTriggerModel(Name + "-SkullEffect", false, new float[] { }, new string[] { Name + "SkullEffect" }, false));
        }

        Cache[bloonModel.name] = this;
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