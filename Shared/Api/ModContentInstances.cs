using System;
using System.Collections.Generic;
using System.Linq;

namespace BTD_Mod_Helper.Api;

internal static class ModContentInstances {
    internal static Dictionary<Type, List<IModContent>> Instances { get; }

    internal static Dictionary<Type, Action<List<IModContent>>> Actions { get; }

    static ModContentInstances() {
        Instances = new Dictionary<Type, List<IModContent>>();
        Actions = new Dictionary<Type, Action<List<IModContent>>>();
    }

    internal static void SetInstance(Type type, IModContent instance) {
        SetInstances(type, new List<IModContent> { instance });
    }

    internal static void SetInstances(Type type, List<ModContent> instances) {
        SetInstances(type, instances.Cast<IModContent>().ToList());
    }

    internal static void SetInstances(Type type, List<IModContent> instances) {
        if (typeof(IModContent).IsAssignableFrom(type)) {
            Instances[type] = instances.ToList();
            if (Actions.TryGetValue(type, out var action)) {
                action(Instances[type]);
            }
        } else {
            ModHelper.Error($"Tried to add content instances of type {type.Name} that wasn't valid");
        }
    }
}

/// <summary>
/// Static generic class that tracks Instances of ModContent
/// </summary>
/// <typeparam name="T"></typeparam>
internal static class ModContentInstance<T> where T : IModContent {
    internal static T Instance { get; private set; }

    internal static List<T> Instances { get; private set; } = new();

    static ModContentInstance() {
        ModContentInstances.Actions[typeof(T)] = SetInstances;
        if (ModContentInstances.Instances.TryGetValue(typeof(T), out var instances)) {
            SetInstances(instances);
        }
    }

    private static void SetInstances(IEnumerable<IModContent> instances) {
        Instances = instances.Cast<T>().ToList();
        Instance = Instances.First();
    }
}