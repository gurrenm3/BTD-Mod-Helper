using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Track;

#if BloonsTD6
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Unity.UI_New.InGame;
#elif BloonsAT
using Assets.Scripts.Models.Rounds;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static class SpawnerExt
    {
        public static void Emit(this Spawner spawner, BloonModel bloonModel)
        {
#if BloonsTD6
            Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator> chargedMutators = new Il2CppSystem.Collections.Generic.List<Bloon.ChargedMutator>();
            Il2CppSystem.Collections.Generic.List<BehaviorMutator> nonChargedMutators = new Il2CppSystem.Collections.Generic.List<BehaviorMutator>();
            spawner.Emit(bloonModel, InGame.Bridge.GetCurrentRound(), 0, chargedMutators, nonChargedMutators);
#elif BloonsAT
            var emissionModel = new BloonEmissionModel(bloonType: bloonModel.baseType);
            spawner.Emit(emissionModel);
#endif
        }
    }
}
