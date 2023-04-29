//Adapted from WarperSan's BossPack 

using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Simulation.Bloons;
using UnityEngine;
using UnityEngine.UI;

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
    internal ModHelperPanel WaitPanel;
    internal ModHelperPanel BossPanel;

    /// <summary>
    /// The number of skulls the boss has each round, goes (round, # of skulls)
    /// </summary>
    public abstract Dictionary<int, int> Skulls { get; }


    /// <summary>
    /// Called when the boss is spawned
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnSpawn(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss is leaked
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnLeak(Bloon bloon)
    {
    }

    /// <summary>
    /// Called when the boss is popped
    /// </summary>
    /// <param name="bloon"></param>
    public virtual void OnPop(Bloon bloon)
    {
    }

    /// <summary>
    /// The speed of the boss, 4.5 is the default for a BAD and 25 is the default for a red bloon
    /// </summary>
    public virtual float Speed => 4.5f;

    /// <summary>
    /// The health of the boss
    /// </summary>
    public virtual float Health => 20_000f;

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
    /// Creates the panel that shows "Boss appears in X rounds"
    /// </summary>
    public virtual ModHelperPanel AddWaitPanel(ModHelperPanel holderPanel)
    {
        var panel = holderPanel.AddPanel(new Info("WaitPanel-" + Name, 0,0,1100, 175), VanillaSprites.SmallSquareWhite);


        panel.AddImage(new Info("Icon", 0, 0, 225, new Vector2(.1f,.5f)), Icon);

        var color = panel.GetComponent<Image>().color;
        color.a = 0.314f;
        color.r = 0f;
        color.g = 0f;
        color.b = 0f;
        panel.GetComponent<Image>().color = color;
        panel.GetComponent<Image>().m_Color = color;
        
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
    public abstract IEnumerable<int> SpawnRounds { get; }

    internal sealed override BloonModel GetDefaultBloonModel()
    {
        var original = base.GetDefaultBloonModel();
        original.RemoveAllChildren();
        original.danger = 16;
        original.overlayClass = BloonOverlayClass.Dreadbloon;
        original.bloonProperties = BloonProperties.None;
        original.tags = new Il2CppStringArray(new[] {"Bad", "Moabs", "Boss"});
        original.maxHealth = Health;
        original.speed = Speed;

        return original;
    }

    /// <inheritdoc />
    public override void Register()
    {
        base.Register();
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