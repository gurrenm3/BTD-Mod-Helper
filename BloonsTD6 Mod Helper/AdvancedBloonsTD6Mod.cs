using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;
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
    /// <param name="inGame"></param>
    /// <param name="text">the text the hint will have, passed as a ref to allow changes</param>
    public virtual bool PreGetRoundHint(ref InGame inGame, ref string text)
    {
        return true;
    }
    
    /// <summary>
    /// called after the game shows a hint for a specific round
    /// <br/>
    /// Equivalent to a HarmonyPostfix on InGame_GetRoundHint
    /// </summary>
    /// <param name="inGame"></param>
    /// <param name="text">the text the hint will have, passed as a ref to allow changes</param>
    public virtual void PostGetRoundHint(InGame inGame, ref string text)
    {
    }

    /// <summary>
    /// Called before the game thinks a paragon is locked
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on TowerManager_IsParagonLocked
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="result">The result of the method, since it returns a bool, different from what you return</param>
    /// <param name="towerManager"></param>
    public virtual bool PreIsParagonLocked(ref TowerManager towerManager, ref Tower tower, ref bool result)
    {
        return true;
    }
    
    /// <summary>
    /// Called after the game thinks a paragon is locked
    /// <br/>
    /// Equivalent to a HarmonyPostfix on TowerManager_IsParagonLocked
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="result">The result of the method, since it returns a bool, different from what you return</param>
    /// <param name="towerManager"></param>
    public virtual void PostIsParagonLocked(TowerManager towerManager, Tower tower, ref bool result)
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
    /// </summary>
    public virtual bool PreMatchEnd(InGame inGame)
    {
        return true;
    }
    
    /// <summary>
    /// Called before the game is restarted
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame_Restart
    /// </summary>
    public virtual bool PreRestart(InGame inGame)
    {
        return true;
    }
    
    /// <summary>
    /// Called before the game is started
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame_Restart
    /// </summary>
    public virtual bool PreMatchStart(InGame inGame)
    {
        return true;
    }
    
    /// <summary>
    /// Called before a sprite is loaded from a SpriteAtlas
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on SpriteAtlas_GetSprite
    /// </summary>
    /// <param name="spriteAtlas"></param>
    /// <param name="name"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public virtual bool PreSpriteLoaded(ref SpriteAtlas spriteAtlas, ref string name, ref Sprite result)
    {
        return true;
    }
    
    /// <summary>
    /// Called after a sprite is loaded from a SpriteAtlas
    /// </summary>
    /// <param name="spriteAtlas"></param>
    /// <param name="name"></param>
    /// <param name="result"></param>
    public virtual void PostSpriteLoaded(SpriteAtlas spriteAtlas, string name, ref Sprite result)
    {
    }
    
    /// <summary>
    /// Called before the degree mutator for a paragon is loaded
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on ParagonTower_GetDegreeMutator
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <param name="investment"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public virtual bool PreParagonDegreeMutatorLoaded(ref ParagonTower paragonTower, ref float investment, ref ParagonTowerModel.PowerDegreeMutator result)
    {
        return true;
    }
    
    /// <summary>
    /// Called after the degree mutator for a paragon is loaded
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <param name="investment"></param>
    /// <param name="result"></param>
    public virtual void PostParagonDegreeMutatorLoaded(ParagonTower paragonTower, float investment, ref ParagonTowerModel.PowerDegreeMutator result)
    {
    }
    
    /// <summary>
    /// Called before the degree for a paragon is changed
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on ParagonTower_UpdateDegree
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <returns></returns>
    public virtual bool PreParagonDegreeUpdated(ref ParagonTower paragonTower)
    {
        return true;
    }
    
    /// <summary>
    /// Called after the degree for a paragon is changed
    /// </summary>
    /// <param name="paragonTower"></param>
    public virtual void PostParagonDegreeUpdated(ParagonTower paragonTower)
    {
    }
    
    /// <summary>
    /// Called before a tower is sold
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Tower_OnSold
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public virtual bool PreTowerSold(ref Tower tower, ref float amount)
    {
        return true;
    }
    
    /// <summary>
    /// Called before a tower is upgraded
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on TowerManager_UpgradeTower
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="upgradeName"></param>
    /// <param name="newBaseTowerModel"></param>
    /// <returns></returns>
    public virtual bool PreTowerUpgraded(ref Tower tower, string upgradeName, ref TowerModel newBaseTowerModel)
    {
        return true;
    }
    
    /// <summary>
    /// Called before any button in the game is clicked
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Button_OnPointerClick
    /// </summary>
    /// <param name="button"></param>
    /// <param name="clickData"></param>
    /// <returns></returns>
    public virtual bool PreButtonClicked(ref Button button, ref PointerEventData clickData)
    {
        return true;
    }
    
    /// <summary>
    /// Called after any button in the game is clicked
    /// </summary>
    /// <param name="button"></param>
    /// <param name="clickData"></param>
    public virtual void PostButtonClicked(Button button, PointerEventData clickData)
    {
    }
    
}