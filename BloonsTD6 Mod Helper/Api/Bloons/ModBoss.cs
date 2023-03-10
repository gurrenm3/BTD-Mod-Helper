//Adapted from WarperSan's BossPack 

using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Api.Enums;
using System.Linq;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Unity;

namespace BTD_Mod_Helper.Api.Bloons;

public abstract class ModBoss : ModBloon
{
    public sealed override string BaseBloon => BloonType.Red;
    
    internal static readonly Dictionary<string, ModBoss> Cache = new();
    
    public virtual void OnSpawn(Bloon bloon)
    {
    }
    
    public virtual void OnLeak(Bloon bloon)
    {
    }
    
    public virtual void OnPop(Bloon bloon)
    {
    }

    public virtual float Speed => 1f; //BAD speed
    
    public virtual float Health => 100_000f;
    
    public virtual BloonModel ModifyForRound(BloonModel bloonModel, int round)
    {
        return bloonModel;
    }
    
    public virtual float SpawnDelay => 0f;
    
    public abstract IEnumerable<int> SpawnRounds { get; }

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
            ModHelper.Error($"Failed to modify base Bloon model for {Id}");
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
    
    public virtual bool KillOnLeak => false;

    public virtual bool BlockRounds => false;
    
    public sealed override bool KeepBaseId => false;

    public sealed override bool Regrow => false;
    public sealed override string RegrowsTo => "";

    public sealed override float RegrowRate => 3;
    
    
}