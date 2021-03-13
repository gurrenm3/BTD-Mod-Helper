using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class BloonToSimulationExt
    {
        public static BloonModel GetBaseModel(this BloonToSimulation bloonToSim)
        {
            return Game.instance?.model?.GetBloon(bloonToSim.Def.GetBaseID());
        }
    }
}
