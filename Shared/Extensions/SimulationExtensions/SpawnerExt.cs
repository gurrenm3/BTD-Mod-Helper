using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Track;

#if BloonsTD6
using Assets.Scripts.Unity.UI_New.InGame;
#elif BloonsAT
using Assets.Scripts.Models.Rounds;
#endif

namespace BTD_Mod_Helper.Extensions
{
    /// <summary>
    /// Extensions for Spawners
    /// </summary>
    public static class SpawnerExt
    {
        /// <summary>
        /// (Cross-Game compatible) Spawn a BloonModel on the map
        /// </summary>
        /// <param name="spawner"></param>
        /// <param name="bloonModel"></param>
        public static void Emit(this Spawner spawner, BloonModel bloonModel)
        {
#if BloonsTD6
            spawner.Emit(bloonModel, InGame.Bridge.GetCurrentRound(), 0);
#elif BloonsAT
            var emissionModel = new BloonEmissionModel(bloonType: bloonModel.baseType);
            spawner.Emit(emissionModel);
#endif
        }
    }
}
