using Assets.Scripts.Simulation.Display;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity.Display;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Entities
/// </summary>
public static partial class EntityExt {
    /// <summary>
    /// Get the DisplayNode for this Entity
    /// </summary>
    public static DisplayNode GetDisplayNode(this Entity entity) {
        return entity.GetDisplayBehavior().node;
    }

    /// <summary>
    /// Get the UnityDisplayNode for this Entity
    /// </summary>
    public static UnityDisplayNode GetUnityDisplayNode(this Entity entity) {
        return entity.GetDisplayNode().graphic;
    }
}