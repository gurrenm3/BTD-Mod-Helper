using System.Linq;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Base class for a boss tier
/// </summary>
public abstract class ModBossTier : ModContent
{
    /// <summary>
    /// The ingame boss panel for this tier, may be null
    /// </summary>
    public ModHelperPanel BossPanel { get; set; }
    /// <summary>
    /// Tier of the boss on this round, if not specified, it will automatically be set based on the round
    /// </summary>
    public virtual int Tier => Boss.tiersByRound.IndexOfValue(this)+1;
    
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
    public abstract void ModifyBossBloonModel(BloonModel bossModel);

    /// <summary>
    /// The boss this tier belongs to
    /// </summary>
    protected abstract ModBoss Boss { get; }
    
    /// <summary>
    /// Called when the boss is spawned
    /// </summary>
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
    /// Called when the UI should update after taking damage, only override this if you have custom ui, otherwise use <see cref="OnDamage"/>
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="totalAmount"></param>
    public virtual void OnDamageUI(Bloon bloon, float totalAmount)
    {
        BossPanel.GetComponentFromChildrenByName<Image>("FillArea").fillAmount =
            bloon.health / bloon.bloonModel.maxHealth;
            
        ModBoss.SetHPText(Mathf.FloorToInt(bloon.health), bloon.bloonModel.maxHealth, BossPanel.GetComponentFromChildrenByName<NK_TextMeshProUGUI>("HealthText"));
    }
    
    /// <summary>
    /// Called when the boss reaches a skull
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void SkullReached(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss should get a skull removed from the UI, only override this if you have custom ui, otherwise use <see cref="SkullReached"/>
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void SkullReachedUI(Bloon bloon)
    {
        BossPanel.GetComponentsFromChildrenByName<ModHelperImage>("Skull")[0].DeleteObject();
    }
    
    /// <summary>
    /// Called when the boss timer triggers
    /// </summary>
    /// <param name="boss"></param>
    public virtual void TimerTick(Bloon boss)
    {
    }

    /// <summary>
    /// Positions of the skulls as a float from 0 to 1
    /// </summary>
    /// <remarks>
    /// If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)
    /// </remarks>
    public virtual float[] PercentageValues { get; internal set; }

    /// <summary>
    /// Determines if the boss's health should go down while it's skull effect is on
    /// </summary>
    public virtual bool PreventFallThrough => false;
    
    /// <summary>
    /// Determines if the timer starts immediately
    /// </summary>
    public virtual bool TriggerImmediately => false;

    /// <summary>
    /// Interval between ticks
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
    protected override ModBoss Boss => GetInstance<T>();
}