using System.Collections.Generic;
using UnityEngine;
#pragma warning disable CS1591

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class to statically store RuntimeAnimationControllers for different animations
/// </summary>
public static class Animations
{

    private static readonly Dictionary<string, RuntimeAnimatorController> AnimationsByName = new();
    public static RuntimeAnimatorController GlobalButtonAnimation => Get("GlobalButtonAnimation");
    public static RuntimeAnimatorController TabAnimation => Get("GlobalTabAnimation");
    public static RuntimeAnimatorController GlowPulse => Get("GlowPulse");
    public static RuntimeAnimatorController PopupAnim => Get("PopupAnim");

    internal static void Load()
    {
        if (AnimationsByName.Count == 0)
        {


            var animationControllers = Resources.FindObjectsOfTypeAll<RuntimeAnimatorController>();

            foreach (var runtimeAnimatorController in animationControllers)
            {
                AnimationsByName[runtimeAnimatorController.name] = runtimeAnimatorController;
            }
        }
    }

    /// <summary>
    /// Gets an AnimationController by its name, or null if there isn't one with that name
    /// </summary>
    public static RuntimeAnimatorController Get(string name)
    {
        return AnimationsByName.TryGetValue(name, out var anim) ? anim : null;
    }
}