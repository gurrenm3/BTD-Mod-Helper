using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Entities
/// </summary>
public static class EntityExt
{
    /// <summary>
    /// Get the DisplayNode for this Entity
    /// </summary>
    public static DisplayNode GetDisplayNode(this Entity entity)
    {
        return entity.GetDisplayBehavior().node;
    }

    /// <summary>
    /// Get the UnityDisplayNode for this Entity
    /// </summary>
    public static UnityDisplayNode GetUnityDisplayNode(this Entity entity)
    {
        return entity.GetDisplayNode().graphic;
    }
    /// <summary>
    /// Return the Factory that creates Entities
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static Factory<Entity> GetFactory(this Entity entity)
    {
        return InGame.instance.GetFactory<Entity>();
    }
}