using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Display.Animation;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Towers
/// </summary>
public static partial class TowerExt
{
    /// <summary>
    /// Get the MonkeyAnimationController for this Tower. Needed to modify 3D models
    /// </summary>
    /// <returns></returns>
    public static MonkeyAnimationController GetMonkeyAnimController(this Tower tower)
    {
        return tower.GetUnityDisplayNode()?.monkeyAnimationController;
    }
}