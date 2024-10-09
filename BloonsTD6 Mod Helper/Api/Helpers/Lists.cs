using System;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppSystem.IO;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Provides quick access to many major BTD6 object lists
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class Lists : MonoBehaviour
{
    /// <inheritdoc />
    public Lists(IntPtr pointer) : base(pointer)
    {
    }
    
    /// <summary>
    /// All towers currently placed in the game, or null if not in a game
    /// </summary>
    public static Tower[] AllTowers => Instances.TowerManager?.GetTowers().ToIl2CppList().ToArray() ?? Array.Empty<Tower>();

    /// <summary>
    /// All TowerToSimulation objects currently placed in the game, or null if not in a game
    /// </summary>
    public static TowerToSimulation[] AllTTS => Instances.Bridge?.ttss.ToArray()?? Array.Empty<TowerToSimulation>();

    /// <summary>
    /// All Entities in the current game, or null if not in a game
    /// </summary>
    public static Entity[] AllEntities => Instances.FactoryFactory?.GetUncast<Entity>().ToArray()?? Array.Empty<Entity>();
}