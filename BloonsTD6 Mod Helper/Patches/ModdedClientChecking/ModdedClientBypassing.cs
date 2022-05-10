using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Patches.ModdedClientChecking;

/// <summary>
/// You forced our hand :(
/// </summary>
public class ModdedClientBypassing
{
    /// <summary>
    /// The nuclear option would be just setting this to true, which would entirely bypass all of NK's clientside checks
    /// </summary>
    private const bool DefaultBypassCheck = false;

    /// <summary>
    /// Whether the ModdedClient check is currently being bypassed
    /// </summary>
    public static bool CurrentlyBypassingCheck { get; private set; }

    /// <summary>
    /// Called in prefix patches on methods where we think modded clients should be accepted
    /// </summary>
    internal static void StartBypassingCheck()
    {
        CurrentlyBypassingCheck = true;
        Modding.isModdedClient = false;
    }

    /// <summary>
    /// Called in postfix patches on methods where we think modded clients should be accepted
    /// </summary>
    internal static void StopBypassingCheck()
    {
        CurrentlyBypassingCheck = DefaultBypassCheck;
        Modding.isModdedClient = !DefaultBypassCheck;
    }
}