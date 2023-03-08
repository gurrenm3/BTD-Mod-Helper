using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Map;
using Il2CppAssets.Scripts.Models.Rounds;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Track;
using Il2CppAssets.Scripts.Unity.Map;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;
using Removeable = Il2CppAssets.Scripts.Simulation.Track.Removeable;
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
    /// Equivalent to a HarmonyPrefix on InGame.GetRoundHint
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
    /// Equivalent to a HarmonyPostfix on InGame.GetRoundHint
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
    /// Equivalent to a HarmonyPrefix on TowerManager.IsParagonLocked
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
    /// Equivalent to a HarmonyPostfix on TowerManager.IsParagonLocked
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
    /// Equivalent to a HarmonyPrefix on InGame.OnVictory
    /// </summary>
    public virtual bool PreOnVictory(InGame inGame)
    {
        return true;
    }

    /// <summary>
    /// Called before the player returns to the MainMenu from a match
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame.Quit
    /// </summary>
    public virtual bool PreMatchEnd(InGame inGame)
    {
        return true;
    }

    /// <summary>
    /// Called before the game is restarted
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame.Restart
    /// </summary>
    public virtual bool PreRestart(InGame inGame)
    {
        return true;
    }

    /// <summary>
    /// Called before the game is started
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on InGame.Restart
    /// </summary>
    public virtual bool PreMatchStart(InGame inGame)
    {
        return true;
    }

    /// <summary>
    /// Called before a sprite is loaded from a SpriteAtlas
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on SpriteAtlas.GetSprite
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
    /// <br/>
    /// Equivalent to a HarmonyPostfix on SpriteAtlas.GetSprite
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
    /// Equivalent to a HarmonyPrefix on ParagonTower.GetDegreeMutator
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <param name="investment"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public virtual bool PreParagonDegreeMutatorLoaded(ref ParagonTower paragonTower, ref float investment,
        ref ParagonTowerModel.PowerDegreeMutator result)
    {
        return true;
    }

    /// <summary>
    /// Called after the degree mutator for a paragon is loaded
    /// <br/>
    /// Equivalent to a HarmonyPostfix on ParagonTower.GetDegreeMutator
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <param name="investment"></param>
    /// <param name="result"></param>
    public virtual void PostParagonDegreeMutatorLoaded(ParagonTower paragonTower, float investment,
        ref ParagonTowerModel.PowerDegreeMutator result)
    {
    }

    /// <summary>
    /// Called before the degree for a paragon is changed
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on ParagonTower.UpdateDegree
    /// </summary>
    /// <param name="paragonTower"></param>
    /// <returns></returns>
    public virtual bool PreParagonDegreeUpdated(ref ParagonTower paragonTower)
    {
        return true;
    }

    /// <summary>
    /// Called after the degree for a paragon is changed
    /// <br/>
    /// Equivalent to a HarmonyPostfix on ParagonTower.UpdateDegree
    /// </summary>
    /// <param name="paragonTower"></param>
    public virtual void PostParagonDegreeUpdated(ParagonTower paragonTower)
    {
    }

    /// <summary>
    /// Called before a tower is sold
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Tower.OnSold
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
    /// Equivalent to a HarmonyPrefix on TowerManager.UpgradeTower
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
    /// Equivalent to a HarmonyPrefix on Button.OnPointerClick
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
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Button.OnPointerClick
    /// </summary>
    /// <param name="button"></param>
    /// <param name="clickData"></param>
    public virtual void PostButtonClicked(Button button, PointerEventData clickData)
    {
    }

    /// <summary>
    /// Called before a new bloon emission is added to the spawner
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Spawner.AddEmissions
    /// </summary>
    /// <param name="spawner"></param>
    /// <param name="newEmissions"></param>
    /// <param name="round"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public virtual bool PreBloonEmissionsAdded(ref Spawner spawner,
        ref Il2CppReferenceArray<BloonEmissionModel> newEmissions, ref int round, int index = 0)
    {
        return true;
    }

    /// <summary>
    /// Called after a new bloon emission is added to the spawner
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Spawner.AddEmissions
    /// </summary>
    /// <param name="spawner"></param>
    /// <param name="newEmissions"></param>
    /// <param name="round"></param>
    /// <param name="index"></param>
    public virtual void PostBloonEmissionsAdded(Spawner spawner, Il2CppReferenceArray<BloonEmissionModel> newEmissions,
        int round, int index = 0)
    {

    }

    /// <summary>
    /// Called before a bloon is emitted from a spawner
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Spawner.Emit
    /// </summary>
    /// <param name="spawner"></param>
    /// <param name="bloonModel"></param>
    /// <param name="round"></param>
    /// <param name="index"></param>
    /// <param name="startingDist"></param>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public virtual bool PreBloonEmitted(ref Spawner spawner, ref BloonModel bloonModel, ref int round, ref int index, ref float startingDist,
        ref Bloon bloon)
    {
        return true;
    }

    /// <summary>
    /// Called after a bloon is emitted from a spawner
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Spawner.Emit
    /// </summary>
    /// <param name="spawner"></param>
    /// <param name="bloonModel"></param>
    /// <param name="round"></param>
    /// <param name="index"></param>
    /// <param name="startingDist"></param>
    /// <param name="bloon"></param>
    public virtual void PostBloonEmitted(Spawner spawner, BloonModel bloonModel, int round, int index, float startingDist,
        ref Bloon bloon)
    {
    }
    
    /// <summary>
    /// Called before the mouse goes over a button
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Button.OnPointerEnter
    /// </summary>
    /// <param name="button"></param>
    /// <param name="eventData"></param>
    /// <returns></returns>
    public virtual bool PrePointerEnterSelectable(ref Selectable button, ref PointerEventData eventData)
    {
        return true;
    }
    
    /// <summary>
    /// Called after the mouse goes over a button
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Button.OnPointerEnter
    /// </summary>
    /// <param name="button"></param>
    /// <param name="eventData"></param>
    public virtual void PostPointerEnterSelectable(ref Selectable button, PointerEventData eventData)
    {
    }

    /// <summary>
    /// Called before the mouse leaves a button
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Button.OnPointerExit
    /// </summary>
    /// <param name="button"></param>
    /// <param name="eventData"></param>
    /// <returns></returns>
    public virtual bool PrePointerExitSelectable(ref Selectable button, ref PointerEventData eventData)
    {
        return true;
    }

    /// <summary>
    /// Called after the mouse leaves a button
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Button.OnPointerExit
    /// </summary>
    /// <param name="button"></param>
    /// <param name="eventData"></param>
    public virtual void PostPointerExitSelectable(ref Selectable button, PointerEventData eventData)
    {
    }
    
    /// <summary>
    /// Called before a MapLoader loads a map
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on MapLoader.LoadMap
    /// </summary>
    /// <param name="mapLoader"></param>
    /// <returns></returns>
    public virtual bool PreMapLoaded(ref MapLoader mapLoader)
    {
        return true;
    }
    
    /// <summary>
    /// Called after a MapLoader loads a map
    /// <br/>
    /// Equivalent to a HarmonyPostfix on MapLoader.LoadMap
    /// </summary>
    /// <param name="mapLoader"></param>
    public virtual void PostMapLoaded(MapLoader mapLoader)
    {
    }
    
    /// <summary>
    /// Called before a Removeable is destroyed
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on Map.DestroyRemoveable
    /// </summary>
    /// <param name="removeable"></param>
    /// <returns></returns>
    public virtual bool PreRemoveableDestroyed(ref Removeable removeable)
    {
        return true;
    }
    
    /// <summary>
    /// Called after a Removeable is destroyed
    /// <br/>
    /// Equivalent to a HarmonyPostfix on Map.DestroyRemoveable
    /// </summary>
    /// <param name="removeable"></param>
    public virtual void PostRemoveableDestroyed(Removeable removeable)
    {
    }

    /// <summary>
    /// Called before a TowerPurchaseButton is created
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on ShopMenu.CreateTowerButton
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="index"></param>
    /// <param name="showAmount"></param>
    /// <param name="button"></param>
    /// <returns></returns>
    public virtual bool PreTowerButtonCreated(ref TowerModel tower, ref int index, ref bool showAmount, ref TowerPurchaseButton button)
    {
        return true;
    }
    
    /// <summary>
    /// Called after a TowerPurchaseButton is created
    /// <br/>
    /// Equivalent to a HarmonyPostfix on ShopMenu.CreateTowerButton
    /// </summary>
    /// <param name="tower"></param>
    /// <param name="index"></param>
    /// <param name="showAmount"></param>
    /// <param name="button"></param>
    public virtual void PostTowerButtonCreated(TowerModel tower, int index, bool showAmount, ref TowerPurchaseButton button)
    {
    }
    
    /// <summary>
    /// Called before a MapModel is created
    /// Return 'false' to prevent the original method from running
    /// <br/>
    /// Equivalent to a HarmonyPrefix on the constructor for MapModel
    /// </summary>
    /// <param name="mapModel"></param>
    /// <returns></returns>
    public virtual bool PreMapModelCreated(ref MapModel mapModel)
    {
        return true;
    }
    
    /// <summary>
    /// Called after a MapModel is created
    /// <br/>
    /// Equivalent to a HarmonyPostfix on the constructor for MapModel
    /// </summary>
    /// <param name="mapModel"></param>
    public virtual void PostMapModelCreated(MapModel mapModel)
    {
    }
    
    
}