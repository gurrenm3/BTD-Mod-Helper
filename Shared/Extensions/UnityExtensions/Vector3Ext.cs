
using Il2CppAssets.Scripts.Simulation.SMath;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Vectors
/// </summary>
public static class Vector3Ext
{
    /// <summary>
    /// Convert UnityEngine.Vector3 to NinjaKiwi's SMath.Vector3
    /// </summary>
    /// <param name="vector3"></param>
    /// <returns></returns>
    public static Vector3 ToSMathVector(this UnityEngine.Vector3 vector3)
    {
        return new Vector3(vector3);
    }
}