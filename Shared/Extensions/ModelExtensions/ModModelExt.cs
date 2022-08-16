using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Models.Powers.Mods;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.TowerSets.Mods;
using Assets.Scripts.Unity.Towers.Mods;

using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;

namespace BTD_Mod_Helper.Extensions;
#if BloonsTD6
/// <summary>
/// Extensions for the ModModel (GameMode) class
/// </summary>
public static class ModModelExt {
    /// <summary>
    /// Check if this has a specific Mutator
    /// </summary>
    /// <typeparam name="T">The Mutator you're checking for</typeparam>
    public static bool HasMutator<T>(this ModModel model) where T : MutatorModModel {
        return model.mutatorMods.Any(b => b.IsType<T>());
    }

    /// <summary>
    /// Check if this has a specific Mutator and return it
    /// </summary>
    /// <typeparam name="T">The Mutator you're checking for</typeparam>
    public static bool HasMutator<T>(this ModModel model, out T mutator) where T : MutatorModModel {
        mutator = model.GetMutator<T>();
        return mutator != null;
    }

    /// <summary>
    /// Return the first Mutator of type T, or null if there isn't one
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model) where T : MutatorModModel {
        return model.GetMutators<T>()?.FirstOrDefault();
    }


    /// <summary>
    /// Return the index'th Mutator of type T, or null
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model, int index) where T : MutatorModModel {
        return model.GetMutators<T>()?.Skip(index).FirstOrDefault();
    }

    /// <summary>
    /// Return the first Mutator of type T whose name contains the given string, or null
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model, string nameContains) where T : MutatorModModel {
        return model.GetMutators<T>()?.FirstOrDefault(m => m.name.Contains(nameContains));
    }

    /// <summary>
    /// Return all Mutators of type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static IEnumerable<T> GetMutators<T>(this ModModel model) where T : MutatorModModel {
        return model.mutatorMods.Select(b => b?.TryCast<T>()).Where(b => b != null);
    }

    /// <summary>
    /// Add a Mutator to this ModModel
    /// </summary>
    public static void AddMutator(this ModModel model, MutatorModModel mutator) {
        if (model.mutatorMods != null) {
            model.mutatorMods = model.mutatorMods.Append(mutator).ToArray();
            model.AddChildDependant(mutator);
        }
    }

    /// <summary>
    /// Remove the first Mutator of Type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model) where T : MutatorModModel {
        var mutator = model.GetMutator<T>();
        if (mutator != null) {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Remove the index'th Mutator of Type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model, int index) where T : MutatorModModel {
        var mutator = model.GetMutator<T>(index);
        if (mutator != null) {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Remove the first Mutator of Type T whose name contains a certain string
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model, string nameContains) where T : MutatorModModel {
        var mutator = model.GetMutator<T>(nameContains);
        if (mutator != null) {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Removes a specific mutator from a tower
    /// </summary>
    public static void RemoveMutator(this ModModel model, MutatorModModel mutator) {
        if (model.mutatorMods != null) {
            model.mutatorMods = model.mutatorMods.Where(b => b?.Equals(mutator) != true).ToArray();
            model.RemoveChildDependant(mutator);
        }
    }

    /// <summary>
    /// Remove all Mutators of type T
    /// </summary>
    public static void RemoveMutators<T>(this ModModel model) where T : MutatorModModel {
        model.RemoveMutators(m => m.Is<T>());
    }

    /// <summary>
    /// Removes all mutators that match a given condition
    /// </summary>
    public static void RemoveMutators(this ModModel model, Func<MutatorModModel, bool> predicate) {
        var mutators = model.mutatorMods;
        if (mutators != null) {
            model.mutatorMods = model.mutatorMods.Where(b => {
                if (predicate(b)) {
                    return true;
                }

                model.RemoveChildDependant(b);
                return false;
            }).ToArray();
        }
    }

    /// <summary>
    /// Makes this GameMode use the given RoundSet
    /// </summary>
    public static void UseRoundSet(this ModModel model, string roundSetName) {
        model.RemoveMutators<BloonSetModModel>();
        model.AddMutator(new BloonSetModModel("_", roundSetName));
    }

    /// <summary>
    /// Makes this GameMode use the given RoundSet
    /// </summary>
    public static void UseRoundSet<T>(this ModModel model) where T : ModRoundSet {
        model.UseRoundSet(ModContent.GetInstance<T>().Id);
    }

    /// <summary>
    /// Sets the cash this mode starts you with using a <see cref="StartingCashModModel"/>
    /// </summary>
    /// <param name="model"></param>
    /// <param name="baseCash">If not 0, the new base cash amount to set the starting amount to</param>
    /// <param name="addCash">How much cash to add to the default base cash</param>
    /// <param name="multCash">If not 0, an overall multiplier to the amount of starting cash</param>
    public static void SetStartingCash(this ModModel model, int baseCash = 0, int addCash = 0, float multCash = 0) {
        model.RemoveMutators<StartingCashModModel>();
        model.AddMutator(new StartingCashModModel("_", baseCash, addCash, multCash));
    }

    /// <summary>
    /// Sets the life total this mode starts you with using a <see cref="StartingCashModModel"/>
    /// </summary>
    public static void SetStartingHealth(this ModModel model, int health) {
        model.RemoveMutators<StartingHealthModModel>();
        model.AddMutator(new StartingHealthModModel("_", 0, health));
    }

    /// <summary>
    /// Sets the maximum life total this mode starts you with using a <see cref="MaxHealthModModel"/>
    /// </summary>
    public static void SetMaxHealth(this ModModel model, int health) {
        model.RemoveMutators<MaxHealthModModel>();
        model.AddMutator(new MaxHealthModModel("_", 1, 0, health));
    }

    /// <summary>
    /// Sets the round this mode starts at using a <see cref="StartingRoundModModel"/>
    /// </summary>
    public static void SetStartingRound(this ModModel model, int startingRound) {
        model.RemoveMutators<StartingRoundModModel>();
        model.AddMutator(new StartingRoundModModel("_", startingRound));
    }

    /// <summary>
    /// Sets the round this mode ends at using a <see cref="EndRoundModModel"/>
    /// </summary>
    public static void SetEndingRound(this ModModel model, int endingRound) {
        model.RemoveMutators<EndRoundModModel>();
        model.AddMutator(new EndRoundModModel("_", endingRound));
    }

    /// <summary>
    /// Sets whether Monkey Knowledge is enabled for a gamemode
    /// </summary>
    public static void SetMkEnabled(this ModModel model, bool enabled) {
        model.RemoveMutator<DisableMonkeyKnowledgeModModel>();
        if (!enabled) model.AddMutator(new DisableMonkeyKnowledgeModModel("_"));
    }

    /// <summary>
    /// Sets whether Powers are enabled for a game mode
    /// </summary>
    public static void SetPowersEnabled(this ModModel model, bool enabled) {
        /* TODO powers
        model.RemoveMutator<PowerModModel>();
        if (!enabled) model.AddMutator(new DisablePowersModModel("_"));
        */
    }

    /// <summary>
    /// Sets whether Continues are enabled for a game mode
    /// </summary>
    public static void SetContinuesEnabled(this ModModel model, bool enabled) {
        model.RemoveMutator<DisableContinueModModel>();
        if (!enabled) model.AddMutator(new DisableContinueModModel("_"));
    }

    /// <summary>
    /// Sets whether selling towers is enabled for a game mode
    /// </summary>
    public static void SetSellingEnabled(this ModModel model, bool enabled) {
        model.RemoveMutator<DisableSellTowerModModel>();
        if (!enabled) model.AddMutator(new DisableSellTowerModModel("_"));
    }

    /// <summary>
    /// Sets whether extra income is enabled for a game mode
    /// </summary>
    public static void SetIncomeEnabled(this ModModel model, bool enabled) {
        model.RemoveMutator<ChimpsModModel>();
        if (!enabled) model.AddMutator(new ChimpsModModel("_"));
    }

    /// <summary>
    /// Modifies the Health that Bloons with a given tag have, like <see cref="BloonTag.Moabs"/> for all Moabs
    /// </summary>
    /// <param name="model"></param>
    /// <param name="mult">The multiplier to apply to Bloons' health</param>
    /// <param name="tag">The Bloon tag to apply to</param>
    public static void SetBloonHealth(this ModModel model, float mult, string tag) {
        model.RemoveMutators(modModel => modModel.Is(out BloonHealthModel b) && b.bloonTag == tag);
        model.AddMutator(new BloonHealthModel("_", mult, tag));
    }

    /// <summary>
    /// Prevents a particular TowerSet from being used in this mode
    /// </summary>
    /// <param name="model"></param>
    /// <param name="towerSet">The tower set to lock</param>
    /// <param name="locked">Whether to lock or unlock the tower set</param>
    public static void LockTowerSet(this ModModel model, string towerSet, bool locked = true) {
        model.RemoveMutators(modModel => modModel.Is(out LockTowerSetModModel m) && m.towerSetToLock == towerSet);
        if (locked) {
            model.AddMutator(new LockTowerModModel("_", towerSet));
        }
    }

    /// <summary>
    /// Sets the max health and shield amount to 1
    /// </summary>
    public static void SetImpoppable(this ModModel model, bool impoppable = true) {
        model.RemoveMutators<ImpoppableModel>();
        if (impoppable) model.AddMutator(new ImpoppableModel("_"));
    }

    /// <summary>
    /// Sets whether the Bloons go in reverse
    /// </summary>
    public static void SetReversed(this ModModel model, bool reversed = true) {
        model.RemoveMutators<ReverseModel>();
        if (reversed) model.AddMutator(new ReverseModel("_"));
    }

    /// <summary>
    /// Applies a multiplier to all cash gains in the mode (but not starting cash)
    /// </summary>
    public static void SetAllCashMultiplier(this ModModel model, float mult) {
        model.RemoveMutators<ModifyAllCashModModel>();
        model.AddMutator(new ModifyAllCashModModel("_", mult));
    }

    /// <summary>
    /// Sets the portion of cash that should be gotten back when selling (0.7 by default)
    /// </summary>
    public static void SetSellMultiplier(this ModModel model, float mult) {
        model.RemoveMutators<SellMultiplierModModel>();
        model.AddMutator(new SellMultiplierModModel("_", 0, mult));
    }
}
#endif