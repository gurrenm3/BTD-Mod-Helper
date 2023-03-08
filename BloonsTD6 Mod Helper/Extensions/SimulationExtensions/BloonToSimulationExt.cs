using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for the BloonToSimulation
/// </summary>
public static partial class BloonToSimulationExt
{
    /// <summary>
    /// Return the DisplayNode for this bloon
    /// </summary>
    /// <returns></returns>
    public static DisplayNode GetDisplayNode(this BloonToSimulation bloonToSim)
    {
        return bloonToSim.GetBloon().GetDisplayNode();
    }

    /// <summary>
    /// Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
    /// </summary>
    /// <returns></returns>
    public static UnityDisplayNode GetUnityDisplayNode(this BloonToSimulation bloonToSim)
    {
        return bloonToSim.GetBloon().GetUnityDisplayNode();
    }

    /// <summary>
    /// Return the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon
    /// </summary>
    public static Bloon GetBloon(this BloonToSimulation bloonToSim)
    {
        return bloonToSim.GetSimBloon();
        //return SessionData.Instance.bloonTracker.GetBloon(bloonToSim.GetId());
    }

    /// <summary>
    /// Return the total distance this BloonToSim has travelled
    /// </summary>
    /// <param name="bloonToSim"></param>
    /// <returns></returns>
    public static float GetDistanceTravelled(this BloonToSimulation bloonToSim)
    {
        var distance = bloonToSim.GetBloon().distanceTraveled;
#if BloonsAT
            bloonToSim.distanceTravelled = distance;
#endif
        return distance;
    }
}