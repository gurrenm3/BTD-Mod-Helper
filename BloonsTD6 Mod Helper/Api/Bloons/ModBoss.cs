//Adapted from WarperSan's BossPack 

using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using System.Linq;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Class for adding a new boss to the game
/// </summary>
public abstract class ModBoss : ModBloon
{

    /// <inheritdoc />
    public sealed override string BaseBloon => BloonType.Bad;
    
    internal static readonly new Dictionary<string, ModBoss> Cache = new();
    
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
    public virtual float Health => 100_000f;
    
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
    /// Whether the boss should always cause defeat on leak
    /// </summary>
    public virtual bool AlwaysDefeatOnLeak => true; 
    /// <summary>
    /// Whether the boss should block rounds from spawning
    /// </summary>
    public virtual bool BlockRounds => false;

    /// <summary>
    /// The rounds the boss should spawn on
    /// </summary>
    public abstract IEnumerable<int> SpawnRounds { get; }

    /// <inheritdoc />
    public sealed override bool UseIconAsDisplay => false;

    internal sealed override BloonModel GetDefaultBloonModel()
    {
        var original = base.GetDefaultBloonModel();
        original.RemoveAllChildren();
        original.danger = 16; 
        original.overlayClass = BloonOverlayClass.Dreadbloon;
        original.bloonProperties = BloonProperties.None;
        original.isBoss = true;
        original.tags = new Il2CppStringArray(new[] { "Bad", "Moabs", "Boss" });
        original.maxHealth = Health;
        original.speed = Speed;
        original.Speed = Speed;
        return original;
    }
    
    /// <inheritdoc />
    public override void Register()
    {
        bloonModel = GetDefaultBloonModel();

        try
        {
            ModifyBaseBloonModel(bloonModel);
        }
        catch (Exception)
        {
            ModHelper.Error($"Failed to modify base Bloon model for boss {Id}");
            throw;
        }

        bloonModel.updateChildBloonModels = true;
        
        bloonModel.GenerateDescendentNames();

        displays.FirstOrDefault(display => display.Damage == 0)?.Apply(bloonModel);
        var damageDisplays = displays
            .Where(display => display.Damage > 0)
            .OrderBy(display => display.Damage)
            .ToList();
        if (damageDisplays.Any())
        {
            ApplyDamageStates(bloonModel, damageDisplays.Select(display => display.Id).ToList());
        }
        
        Game.instance.model.bloons = Game.instance.model.bloons.AddTo(bloonModel);
        Game.instance.model.AddChildDependant(bloonModel);
        Game.instance.model.bloonsByName[bloonModel.name] = bloonModel;
        
        Cache[bloonModel.id] = this;
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