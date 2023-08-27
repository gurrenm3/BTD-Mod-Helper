using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Api.Bloons.Bosses;

/// <summary>
/// Base class for a boss tier
/// </summary>
public abstract class ModBossTier : ModContent
{
    internal BloonModel bloonModel { get; set; }

    /// <inheritdoc />
    protected override float RegistrationPriority => 5; // Bosses should register after tiers

    /// <summary>
    /// Tier of the boss on this round, if not specified, it will automatically be set based on the round,
    /// </summary>
    internal int Tier => Boss.tiersByRound.IndexOfValue(this)+1;
    
    /// <summary>
    /// Amount of skulls the boss has
    /// </summary>
    public abstract int Skulls { get; }
    /// <summary>
    /// The round this tier appears on
    /// </summary>
    public abstract int Round { get; }
    
    /// <summary>
    /// Modifies the base boss bloon
    /// </summary>
    /// <param name="bossModel"></param>
    public abstract void ModifyBaseBoss(BloonModel bossModel);

    /// <summary>
    /// The boss this tier belongs to
    /// </summary>
    public abstract ModBoss Boss { get; }
    
    /// <summary>
    /// Called when the boss is spawned
    /// </summary>
    /// <remarks>Called when loading saves and continuing from checkpoints as well</remarks> //because bloon gets reset
    /// <param name="bloon"></param>
    public virtual void OnSpawn(Bloon bloon) { }

    /// <summary>
    /// Called when the boss is leaked
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnLeak(Bloon bloon) { }

    /// <summary>
    /// Called when the boss is popped
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnPop(Bloon bloon) { }

    /// <summary>
    /// Called when the boss takes damage
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="totalAmount"></param>
    public virtual void OnDamage(Bloon bloon, float totalAmount)
    {
    }

    /// <summary>
    /// Called when the boss reaches a skull
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void SkullReached(Bloon bloon)
    {
    }
    
    /// <summary>
    /// Called when the boss timer triggers, only called if <see cref="Interval"/> is not null
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void TimerTick(Bloon bloon)
    {
    }

    /// <summary>
    /// Positions of the skulls as a float from 0 to 1
    /// </summary>
    /// <remarks>
    /// If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)
    /// </remarks>
    public virtual float[] SkullPositions { get; internal set; }

    internal void SetupSkulls(BloonModel bossModel)
    {
        if (SkullPositions == null)
        {
            var skullsCount = Skulls;
            var pV = new List<float>();
            if (skullsCount > 0)
            {
                for (int i = 1; i <= skullsCount; i++)
                {
                    pV.Add(1f - 1f / (skullsCount + 1) * i);
                }
            }
            SkullPositions = pV.ToArray();
        }

        bossModel.AddBehavior(new HealthPercentTriggerModel(Name + "-SkullEffect", false, SkullPositions,
            new[] {Name + "SkullEffect"}, PreventFallThrough));
    }

    internal void SetupTimer(BloonModel bossModel)
    {
        if (Interval != null)
        {
            bossModel.AddBehavior(new TimeTriggerModel(Name + "-TimerTick", Interval.Value, TriggerImmediately, new[]
            {
                Name + "TimerTick"
            }));
        }
    }

    /// <summary>
    /// Determines if the boss's health should go down while it's skull effect is on
    /// </summary>
    public virtual bool PreventFallThrough => false;
    
    /// <summary>
    /// Determines if the timer starts immediately
    /// </summary>
    public virtual bool TriggerImmediately => false;

    /// <summary>
    /// Interval between ticks for the boss' timer, if null, the timer will not be created
    /// </summary>
    public virtual float? Interval => null;

    /// <inheritdoc />
    public override void Register()
    {
        Boss.tiers.Add(this);
        Boss.tiersByRound.Add(Round, this);
        if (Tier > Boss.highestTier)
            Boss.highestTier = Tier;
    }
}
/// <summary>
/// A convenient generic class for specifying the ModBoss that this ModBossTier uses
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class ModBossTier<T> : ModBossTier where T : ModBoss
{
    /// <inheritdoc />
    public override ModBoss Boss => GetInstance<T>();
}