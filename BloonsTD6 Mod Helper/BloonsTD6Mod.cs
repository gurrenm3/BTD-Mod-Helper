using System;
using System.Runtime.InteropServices;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Simulation;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Simulation.Towers.Projectiles;
using Assets.Scripts.Simulation.Towers.Weapons;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;
using UnityEngine;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Assets.Scripts.Simulation.Towers.Behaviors.Attack;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks
    /// </summary>
    public abstract class BloonsTD6Mod : BloonsMod
    {

        /// <summary>
        /// Adds a TowerModel to the official list of TowerModels being used by the game
        ///
        /// Equivalent to calling Game.instance.model.AddTowerToGame(...)
        /// </summary>
        /// <param name="newTowerModel">The new tower model</param>
        /// <param name="towerDetailsModel">A TowerDetailsModel to go with it, if it'll be in the shop</param>
        public static void AddTowerToGame(TowerModel newTowerModel, TowerDetailsModel towerDetailsModel = null)
        {
            Game.instance.model.AddTowerToGame(newTowerModel, towerDetailsModel);
        }

        
        #region Misc Hooks

        /// <summary>
        /// Acts on a Network message that's been sent to the client
        ///
        /// Use Game.instance.GetNKgI().ReadMessage<YOUR_CLASS_NAME>(message) to get back the same object/class you sent.
        ///
        /// If this is one of your messages and you're consuming and acting on it, return true.
        /// Otherwise, return false. Seriously.
        /// </summary>
        public virtual bool ActOnMessage(Message message)
        {
            return false;
        }


        /// <summary>
        /// Called when the player's ProfileModel is loaded.
        /// 
        /// Equivalent to a HarmonyPostFix on ProfileModel_Validate
        /// </summary>
        public virtual void OnProfileLoaded(ProfileModel result)
        {

        }

        /// <summary>
        /// Called when InGame.instance.UnityToSimulation.Simulation is not null
        /// </summary>
        public virtual void OnInGameLoaded(InGame inGame)
        {

        }

        /// <summary>
        /// Called when Game.instance.model is not null
        /// </summary>
        public virtual void OnGameModelLoaded(GameModel model)
        {

        }

        /// <summary>
        /// Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers
        /// 
        /// Equivalent to a HarmonyPostFix on GameModel_CreatedModded
        /// </summary>
        public virtual void OnNewGameModel(GameModel result)
        {
            
        }
        
        /// <summary>
        /// Called when a new GameModel is created, aka when things like Monkey Knowledge are applied to towers
        /// 
        /// Equivalent to a HarmonyPostFix on GameModel_CreatedModded
        /// </summary>
        public virtual void OnNewGameModel(GameModel result, List<ModModel> mods)
        {
            
        }

        #endregion
        
        #region Menu Hooks

        /// <summary>
        /// Called when you go to the main menu screen
        ///
        /// Equivalent to a HarmonyPostFix on MainMenu.OnEnable
        /// </summary>
        public virtual void OnMainMenu()
        {
        }

        /// <summary>
        /// Called right after a match ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.OnVictory
        /// </summary>
        public virtual void OnVictory()
        {

        }

        /// <summary>
        /// Called right after a match is started up (restart included it seems like)
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.StartMatch
        /// </summary>
        public virtual void OnMatchStart()
        {

        }

        /// <summary>
        /// Called when a match is restarted
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.Restart
        /// </summary>
        public virtual void OnRestart(bool removeSave)
        {

        }

        /// <summary>
        /// Called right after a game ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on TimeManager.SetFastForward
        /// </summary>
        public virtual void OnFastForwardChanged(bool newValue)
        {

        }


        /// <summary>
        /// Called right after the game finishes loading everything
        /// 
        /// Equivalent to a HarmonyPostFix on TitleScreen.Start
        /// </summary>
        public virtual void OnTitleScreen()
        {

        }

        #endregion

        #region Bloon Hooks

        /// <summary>
        /// Called right before a Bloon would leak.
        /// Return 'false' to prevent the leak from happening
        ///
        /// Equivalent to a HarmonyPreFix on Bloon.Leaked
        /// </summary>
        public virtual bool PreBloonLeaked(Bloon bloon)
        {
            return true;
        }

        /// <summary>
        /// Called right after a Bloon leaks.
        /// Return 'false' to prevent the leak from happening
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Leaked
        /// </summary>
        public virtual void PostBloonLeaked(Bloon bloon)
        {
        }


        /// <summary>
        /// Called right after a Bloon is first created
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Initialise
        /// </summary>
        public virtual void OnBloonCreated(Bloon bloon)
        {
        }

        /// <summary>
        /// Called right after a Bloon's BloonModel is updated
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.UpdatedModel
        /// </summary>
        public virtual void OnBloonModelUpdated(Bloon bloon, Model model)
        {
        }


        /// <summary>
        /// Called right after a Bloon is destroyed
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.OnDestroy
        /// </summary>
        public virtual void OnBloonDestroy(Bloon bloon)
        {
        }
        
        /// <summary>
        /// Called right after a Bloon is damaged
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Damaged
        /// </summary>
        public virtual void PostBloonDamaged(Bloon bloon, float totalAmount, Projectile projectile, 
            bool distributeToChildren, bool overrideDistributeBlocker, bool createEffect, [Optional] Tower tower, 
            [Optional] BloonProperties immuneBloonProperties, bool canDestroyProjectile = true, 
            bool ignoreNonTargetable = false, bool blockSpawnChildren = false)
        {
        }

        /// <summary>
        /// Called right after a Bloon is damaged
        /// 
        /// Equivalent to a HarmonyPostFix on Bloon.Damaged
        /// </summary>
        // this was removed because it was removed in BTD6 version 25
        /*public virtual void PostBloonDamaged(Bloon bloon, float totalAmount, bool ignoreNonTargetable = false)
        {
        }*/

        #endregion

        #region Tower Hooks

        /// <summary>
        /// Called right before a Tower's 3D graphics are initialized
        /// 
        /// Equivalent to a HarmonyPreFix on InputManager.CreateTowerGraphicsAsync
        /// </summary>
        public virtual void OnTowerGraphicsCreated(TowerModel towerModel, List<UnityDisplayNode> placementGraphics)
        {
        }

        /// <summary>
        /// Called right after a Tower is initialized
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Initialise
        /// </summary>
        public virtual void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
        {
        }

        /// <summary>
        /// Called right after a Tower is destroyed
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Destroyed
        /// </summary>
        public virtual void OnTowerDestroyed(Tower tower)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is sold
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.OnSold
        /// </summary>
        public virtual void OnTowerSold(Tower tower, float amount)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is selected by the player
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.Highlight
        /// </summary>
        public virtual void OnTowerSelected(Tower tower)
        {
        }

        /// <summary>
        /// Called right after a Tower is deselected by the player
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.UnHighlight
        /// </summary>
        public virtual void OnTowerDeselected(Tower tower)
        {
        }
        
        /// <summary>
        /// Called right after a Tower is upgraded
        /// </summary>
        public virtual void OnTowerUpgraded(Tower tower, String upgradeName, TowerModel newBaseTowerModel)
        {
        }
        
        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Tower.UpdatedModel
        /// </summary>
        public virtual void OnTowerModelChanged(Tower tower, Model newModel)
        {
        }
        
        /// <summary>
        /// Called at the end of each round when a Tower's data is saved
        ///
        /// Use saveData.metaData to save custom information
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.GetSavedData
        /// </summary>
        public virtual void OnTowerSaved(Tower tower, TowerSaveDataModel saveData)
        {
            
        }
        
        /// <summary>
        /// Called when you load a save file and a Tower's save data get loaded for the tower
        ///
        /// Use saveData.metaData to load custom information
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.SetSavedData
        /// </summary>
        public virtual void OnTowerLoaded(Tower tower, TowerSaveDataModel saveData)
        {
            
        }
        
        /// <summary>
        /// Called when you load a save file and a Tower's save data get loaded for the tower
        ///
        /// Use saveData.metaData to load custom information
        /// 
        /// Equivalent to a HarmonyPostFix on Tower.SetSavedData
        /// </summary>
        public virtual void CanTowerTargetCamo(Tower tower, ref bool result)
        {
            
        }
        
        #endregion

        #region Simulation Hooks

        /// <summary>
        /// Called right after Cash is added in a game
        /// Tower might be null
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.AddCash
        /// </summary>
        public virtual void OnCashAdded(double amount, Simulation.CashType from,
            int cashIndex, Simulation.CashSource source, Tower tower)
        {
            
        }
        
        /// <summary>
        /// Called right after Cash is removed in a game
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.RemoveCash
        /// </summary>
        public virtual void OnCashRemoved(double amount, Simulation.CashType from, int cashIndex, Simulation.CashSource source)
        {
            
        }
        
        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnRoundStart
        /// </summary>
        public virtual void OnRoundStart()
        {
            
        }
        
        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnRoundEnd
        /// </summary>
        public virtual void OnRoundEnd()
        {
            
        }
        
        /// <summary>
        /// Called right after a match ends in defeat
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.OnDefeat
        /// </summary>
        public virtual void OnDefeat()
        {
            
        }

        #endregion

        #region Weapon/Projectile/Attack Hooks

        /// <summary>
        /// Called right after an Attack is created
        ///
        /// Equivalent to a HarmonyPostFix on Attack.Initialise
        /// </summary>
        public virtual void OnAttackCreated(Attack attack, Entity entity, Model modelToUse)
        {
        }


        /// <summary>
        /// Called right after a Tower's Attack is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Attack.UpdatedModel
        /// </summary>
        public virtual void OnAttackModelChanged(Attack attack, Model newModel)
        {
        }

        /// <summary>
        /// Called right after a Weapon is created
        ///
        /// Equivalent to a HarmonyPostFix on Weapon.Initialise
        /// </summary>
        public virtual void OnWeaponCreated(Weapon weapon, Entity entity, Model modelToUse)
        {
        }

        
        /// <summary>
        /// Called right after a Tower's WeaponModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Weapon.UpdatedModel
        /// </summary>
        public virtual void OnWeaponModelChanged(Weapon weapon, Model newModel)
        {
        }
        
        /// <summary>
        /// Called right after a Projectile is created
        ///
        /// Equivalent to a HarmonyPostFix on Projectile.Initialise
        /// </summary>
        public virtual void OnProjectileCreated(Projectile projectile, Entity entity, Model modelToUse)
        {
        }

        
        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
        ///
        /// Equivalent to a HarmonyPostFix on Projectile.UpdatedModel
        /// </summary>
        public virtual void OnProjectileModelChanged(Projectile projectile, Model newModel)
        {
        }

        #endregion



        public static int CostForDifficulty(int cost, List<ModModel> mods)
        {
            var mult = 1f;
            foreach (var gameModelMod in mods)
            {
                if (gameModelMod.mutatorMods != null)
                {
                    foreach (var mutatorModModel in gameModelMod.mutatorMods)
                    {
                        if (mutatorModModel != null && mutatorModModel.IsType<GlobalCostModModel>())
                        {
                            var mod = mutatorModModel.Cast<GlobalCostModModel>();
                            mult = mod.multiplier;
                        }
                    }
                }
            }

            return CostForDifficulty(cost, mult);
        }

        public static int CostForDifficulty(int cost, GameModel gameModel)
        {
            var difficulty = $"{gameModel.difficultyId}";
            if (string.IsNullOrEmpty(difficulty))
            {
                MelonLogger.Warning("Difficulty cannot be determined at this stage of creating the GameModel");
                MelonLogger.Warning("Use the list of ModModels to find the difficulty instead");
            }

            return CostForDifficulty(cost, gameModel.difficultyId);
        }

        public static int CostForDifficulty(int cost, InGame inGame)
        {
            return CostForDifficulty(cost, inGame.SelectedDifficulty);
        }
    }
}