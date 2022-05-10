using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonModelExt
    {
        public static Il2CppSystem.Collections.Generic.List<BloonModel>
            GetChildBloonModels(this BloonModel bloonModel, Simulation simulation)
        {
            return bloonModel.GetChildBloonModels(simulation.model);
        }
    }
}
