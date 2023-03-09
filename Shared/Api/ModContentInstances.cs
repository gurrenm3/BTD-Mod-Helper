using System;
using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api;

internal static class ModContentInstances
{
    internal static Dictionary<Type, List<IModContent>> Instances { get; }

    internal static Dictionary<Type, Action<List<IModContent>>> Actions { get; }

    static ModContentInstances()
    {
        Instances = new Dictionary<Type, List<IModContent>>();
        Actions = new Dictionary<Type, Action<List<IModContent>>>();
    }

    internal static void AddInstance(Type type, IModContent instance)
    {
        AddInstances(type, new List<IModContent> {instance});
    }

    internal static void AddInstances(Type type, List<ModContent> instances)
    {
        AddInstances(type, instances.Cast<IModContent>().ToList());
    }

    internal static void AddInstances(Type type, List<IModContent> instances)
    {
        if (typeof(IModContent).IsAssignableFrom(type))
        {
            if (!Instances.TryGetValue(type, out var list)) list = Instances[type] = new List<IModContent>();
            list.AddRange(instances);
            if (Actions.TryGetValue(type, out var action))
            {
                action(Instances[type]);
            }
        }
        else
        {
            ModHelper.Error($"Tried to add content instances of type {type.Name} that wasn't valid");
        }
    }
}

/// <summary>
/// Static generic class that tracks Instances of ModContent
/// </summary>
/// <typeparam name="T"></typeparam>
internal static class ModContentInstance<T> where T : IModContent
{
    internal static T Instance { get; private set; }

    internal static List<T> Instances { get; private set; } = new();

    static ModContentInstance()
    {
        ModContentInstances.Actions[typeof(T)] = AddInstances;
        if (ModContentInstances.Instances.TryGetValue(typeof(T), out var instances))
        {
            AddInstances(instances);
        }
    }

    private static void AddInstances(IEnumerable<IModContent> instances)
    {
        Instances ??= new List<T>();
        Instances.AddRange(instances.Cast<T>());
        Instance ??= Instances.First();
    }
}