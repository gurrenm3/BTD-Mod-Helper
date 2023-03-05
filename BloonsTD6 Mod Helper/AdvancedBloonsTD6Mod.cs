using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper;

/// <summary>
/// A more advanced version of the BloonsTD6Mod Class that has postfixes and prefixes for all hooks, along with instances and all parameters for each patch
/// </summary>
public abstract class AdvancedBloonsTD6Mod : BloonsTD6Mod
{
    /// <summary>
    /// Called before the game shows a hint for a specific round
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame_GetRoundHint
    /// </summary>
    public virtual bool PreGetRoundHint(ref InGame inGame, ref string text, int round)
    {
        return true;
    }
    
    /// <summary>
    /// called after the game shows a hint for a specific round
    /// <br/>
    /// Equivalent to a HarmonyPostfix on InGame_GetRoundHint
    /// </summary>
    public virtual void PostGetRoundHint(InGame inGame, string text, int round)
    {
    }

    /// <summary>
    /// Called before the game thinks a paragon is locked
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on TowerManager_IsParagonLocked
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="result">The result of the method, different from what you return</param>
    /// <param name="towerManager"></param>
    public virtual bool PreIsParagonLocked(ref TowerManager towerManager, ref Tower tower, ref bool result)
    {
        return true;
    }
    
    public virtual void PostIsParagonLocked(TowerManager towerManager, Tower tower, bool result)
    {
    }
    
    /// <summary>
    /// Called before the a game is won
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame_OnVictory
    /// </summary>
    public virtual bool PreOnVictory(InGame inGame)
    {
        return true;
    }
    
    /// <summary>
    /// Called before the player returns to the MainMenu from a match
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame_Quit
    public virtual bool PreMatchEnd(InGame inGame)
    {
        return true;
    }
    
    
}