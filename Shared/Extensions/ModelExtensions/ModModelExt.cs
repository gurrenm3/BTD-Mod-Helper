using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Bloons;

namespace BTD_Mod_Helper.Extensions;
#if BloonsTD6
/// <summary>
/// Extensions for the ModModel (GameMode) class
/// </summary>
public static class ModModelExt
{
    /// <summary>
    /// Check if this has a specific Mutator
    /// </summary>
    /// <typeparam name="T">The Mutator you're checking for</typeparam>
    public static bool HasMutator<T>(this ModModel model) where T : MutatorModModel
    {
        return model.mutatorMods.Any(b => b.IsType<T>());
    }

    /// <summary>
    /// Check if this has a specific Mutator and return it
    /// </summary>
    /// <typeparam name="T">The Mutator you're checking for</typeparam>
    public static bool HasMutator<T>(this ModModel model, out T mutator) where T : MutatorModModel
    {
        mutator = model.GetMutator<T>()!;
        return mutator != null;
    }

    /// <summary>
    /// Return the first Mutator of type T, or null if there isn't one
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model) where T : MutatorModModel
    {
        return model.GetMutators<T>()?.FirstOrDefault();
    }


    /// <summary>
    /// Return the index'th Mutator of type T, or null
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model, int index) where T : MutatorModModel
    {
        return model.GetMutators<T>()?.Skip(index).FirstOrDefault();
    }

    /// <summary>
    /// Return the first Mutator of type T whose name contains the given string, or null
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static T GetMutator<T>(this ModModel model, string nameContains) where T : MutatorModModel
    {
        return model.GetMutators<T>()?.FirstOrDefault(m => m.name.Contains(nameContains));
    }

    /// <summary>
    /// Return all Mutators of type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want</typeparam>
    public static IEnumerable<T> GetMutators<T>(this ModModel model) where T : MutatorModModel
    {
        return model.mutatorMods.Select(b => b?.TryCast<T>()).Where(b => b != null)!;
    }

    /// <summary>
    /// Add a Mutator to this ModModel
    /// </summary>
    public static void AddMutator(this ModModel model, MutatorModModel mutator)
    {
        if (model.mutatorMods != null)
        {
            model.mutatorMods = model.mutatorMods.Append(mutator).ToArray();
            model.AddChildDependant(mutator);
        }
    }

    /// <summary>
    /// Remove the first Mutator of Type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model) where T : MutatorModModel
    {
        var mutator = model.GetMutator<T>();
        if (mutator != null)
        {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Remove the index'th Mutator of Type T
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model, int index) where T : MutatorModModel
    {
        var mutator = model.GetMutator<T>(index);
        if (mutator != null)
        {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Remove the first Mutator of Type T whose name contains a certain string
    /// </summary>
    /// <typeparam name="T">The Mutator you want to remove</typeparam>
    public static void RemoveMutator<T>(this ModModel model, string nameContains) where T : MutatorModModel
    {
        var mutator = model.GetMutator<T>(nameContains);
        if (mutator != null)
        {
            model.RemoveMutator(mutator);
        }
    }

    /// <summary>
    /// Removes a specific mutator from a tower
    /// </summary>
    public static void RemoveMutator(this ModModel model, MutatorModModel mutator)
    {
        if (model.mutatorMods != null)
        {
            model.mutatorMods = model.mutatorMods.Where(b => b?.Equals(mutator) != true).ToArray();
            model.RemoveChildDependant(mutator);
        }
    }

    /// <summary>
    /// Remove all Mutators of type T
    /// </summary>
    public static void RemoveMutators<T>(this ModModel model) where T : MutatorModModel
    {
        var mutators = model.mutatorMods;
        if (mutators != null)
        {
            model.mutatorMods = model.mutatorMods.Where(b =>
            {
                if (b.IsType<T>())
                {
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
    public static void UseRoundSet<T>(this ModModel model) where T : ModRoundSet
    {
        model.RemoveMutators<BloonSetModModel>();
        model.AddMutator(new BloonSetModModel("BloonSetModModel_", ModContent.GetInstance<T>().Id));
    }
}
    
#endif