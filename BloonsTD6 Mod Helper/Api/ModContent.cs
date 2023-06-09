using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// ModContent serves two major purposes:
/// <br />
/// 1. It is a base class for things that needs to be loaded via reflection from mods and given Ids,
///     such as ModTower and ModUpgrade
/// <br />
/// 2. It is a utility class with methods to access instances of those classes and other resources
/// </summary>
public abstract partial class ModContent : IModContent, IComparable<ModContent>
{

    private const BindingFlags ConstructorFlags = BindingFlags.Instance |
                                                  BindingFlags.Public |
                                                  BindingFlags.NonPublic;

    internal const string HijackSpriteAtlas = "Ui";


    internal readonly Stack<Action> rollbackActions = new();

    /// <summary>
    /// The BloonsTD6Mod that this content was added by
    /// </summary>
    public BloonsTD6Mod mod;
    /// <summary>
    /// The name that will be at the end of the ID for this ModContent, by default the class name
    /// </summary>
    public virtual string Name => GetType().Name;

    /// <summary>
    /// The id that this ModContent will be given; a combination of the Mod's prefix and the name
    /// </summary>
    public string Id => ID;

    /// <summary>
    /// Backing property for ID that's only able to be overriden internally
    /// </summary>
    private protected virtual string ID => GetId(mod, Name);

    /// <summary>
    /// Used to allow some ModContent to Register before or after others
    /// </summary>
    /// <exclude />
    protected virtual float RegistrationPriority => 5f;

    /// <summary>
    /// The order that this ModContent will be loaded/registered in by Mod Helper.
    /// Useful for changing the ordering that it will appear in in-game relative to other content of this type in your mod,
    /// or for making certain content load before others like may be necessary for sub-towers.
    /// Default/0 will use arbitrary ordering.
    /// </summary>
    protected virtual int Order => 0;

    /// <summary>
    /// How many of this ModContent should it try to register in each frame. Higher numbers could lead to faster but choppier
    /// loading.
    /// </summary>
    /// <exclude />
    public virtual int RegisterPerFrame => 20;

    /// <inheritdoc />
    public int CompareTo(ModContent other)
    {
        var compareTo = Order.CompareTo(other.Order);
        if (compareTo == 0)
        {
            compareTo = mod.Priority.CompareTo(other.mod.Priority);
        }
        if (compareTo == 0)
        {
            compareTo = string.Compare(Id, other.Id, StringComparison.Ordinal);
        }
        if (compareTo == 0)
        {
            compareTo = GetHashCode().CompareTo(other.GetHashCode());
        }
        return compareTo;
    }

    /// <summary>
    /// Used for when you want to programmatically create multiple instances of a given ModContent
    /// </summary>
    /// <returns></returns>
    /// <exclude />
    public virtual IEnumerable<ModContent> Load()
    {
        yield return this;
    }

    /// <summary>
    /// Registers this ModContent into the game
    /// </summary>
    /// <exclude />
    public abstract void Register();


    internal static void LoadModContent(BloonsTD6Mod mod)
    {
        mod.Content = mod.GetAssembly()
            .GetValidTypes()
            .Where(CanLoadType)
            .Select(type => CreateInstance(type, mod))
            .Where(content => content != null)
            .OrderBy<ModContent, float>(content => content.RegistrationPriority)
            .ThenBy(content => content.Order)
            .SelectMany(Load)
            .OrderBy(content => content.RegistrationPriority)
            .ThenBy(content => content.Order)
            .ToList();
    }

    private static bool CanLoadType(Type type)
    {
        return !type.IsAbstract &&
               !type.ContainsGenericParameters &&
               typeof(ModContent).IsAssignableFrom(type) &&
               type.GetConstructor(ConstructorFlags, null, Type.EmptyTypes, null) != null;
    }

    private static ModContent CreateInstance(Type type, BloonsTD6Mod mod)
    {
        ModContent instance;
        try
        {
            instance = (ModContent) Activator.CreateInstance(type)!;
            instance.mod = mod;
            ModContentInstances.AddInstance(type, instance);
        }
        catch (Exception e)
        {
            ModHelper.Error($"Error creating default {type.Name}");
            ModHelper.Error("A zero argument constructor is REQUIRED for all ModContent classes");
            ModHelper.Error(e);
            return null;
        }

        return instance;
    }

    /// <summary>
    /// Creates the Instances of a ModContent type within a Mod and adds them to ModContentInstances
    /// </summary>
    private static IEnumerable<ModContent> Load(ModContent instance)
    {
        var type = instance.GetType();
        var content = new List<ModContent>();
        try
        {
            content.AddRange(instance.Load());
            var instances = new List<ModContent>();
            foreach (var modContent in content)
            {
                modContent.mod = instance.mod;
                if (instance.GetType().IsInstanceOfType(modContent))
                {
                    instances.Add(modContent);
                }
            }

            ModContentInstances.AddInstances(type, instances);
        }
        catch (Exception e)
        {
            ModHelper.Error(
                $"Failed loading instances of type {type.Name} for mod {type.Assembly.GetName().Name}");
            ModHelper.Error(e);
        }

        return content;
    }


    internal int GetOrder()
    {
        return Order;
    }

}