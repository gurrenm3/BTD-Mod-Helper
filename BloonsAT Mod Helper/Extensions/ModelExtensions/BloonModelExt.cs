using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Rounds;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonModelExt
    {
        public static Il2CppSystem.Collections.Generic.List<BloonModel>
            GetChildBloonModels(this BloonModel bloonModel, Simulation simulation)
        {
            return bloonModel.GetChildBloonModels(simulation.model);
        }

        /// <summary>
        /// Gets the BloonModel for this group
        /// </summary>
        /// <param name="bloonGroupModel"></param>
        /// <returns></returns>
        public static BloonModel GetBloonModel(this BloonGroupData bloonGroupModel)
        {
            return Game.instance.model.GetBloon(bloonGroupModel.bloon);
        }
    }
}
