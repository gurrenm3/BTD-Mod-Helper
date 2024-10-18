using System;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Properties and methods for helping change in game time / time related values
/// </summary>
public static class TimeHelper
{
    /// <summary>
    /// Override for <see cref="TimeManager.FastForwardTimeScale"/>
    /// </summary>
    public static double OverrideFastForwardTimeScale { get; set; } = Constants.fastForwardTimeScaleMultiplier;

    /// <summary>
    /// Former override for TimeManager.MaxSimulationStepsPerUpdate
    /// </summary>
    [Obsolete("Removed as of BTD6 v45.2")]
    public static double OverrideMaxSimulationStepsPerUpdate { get; set; } = 3;
}