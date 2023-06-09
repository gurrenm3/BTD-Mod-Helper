using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Spawners
/// </summary>
public static class SpawnerExt
{
    /// <summary>
    /// Spawn a BloonModel on the map
    /// </summary>
    /// <param name="spawner"></param>
    /// <param name="bloonModel"></param>
    public static void Emit(this Spawner spawner, BloonModel bloonModel)
    {

        spawner.Emit(bloonModel, InGame.Bridge.GetCurrentRound(), 0);
    }
}