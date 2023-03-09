using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

public static partial class EntityExt
{
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