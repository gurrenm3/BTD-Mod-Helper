using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Unity.Bridge;

namespace BTD_Mod_Helper.Extensions;

public static partial class BloonToSimulationExt
{
    /// <summary>
    /// Return the Id of this BloonToSimulation
    /// </summary>
    /// <param name="bloonToSim"></param>
    /// <returns></returns>
    public static ObjectId GetId(this BloonToSimulation bloonToSim)
    {
#if BloonsTD6
        return bloonToSim.id;
#elif BloonsAT
            return (int)bloonToSim.id;
#endif
    }
}