using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers;
using System.Runtime.InteropServices;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Simulation.Towers.Weapons.Behaviors;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Simulation;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper
{
    /// <summary>
    /// Extend this Class instead of MelonMod to gain access to dozens of easy to use built-in hooks
    /// </summary>
    public abstract class BloonsATMod : BloonsMod
    {
        #region Misc Hooks

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


        #endregion

        #region Menu Hooks

        /// <summary>
        /// Called when you go to the main menu screen (FrontEnd world)
        ///
        /// Equivalent to a HarmonyPostFix on FrontendWorld.Start
        /// </summary>
        public virtual void OnFrontEndWorld()
        {
        }

        /// <summary>
        /// Called right after a match ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.ShowLevelCompleteScreen
        /// </summary>
        public virtual void OnVictory()
        {

        }

        /// <summary>
        /// Called right after a match is started up (restart included it seems like)
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.StartMatch
        /// </summary>
        /*public virtual void OnMatchStart() // Removed because I couldn't find a good method for this
        {

        }*/

        /// <summary>
        /// Called when a match is restarted
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.Restart
        /// </summary>
        public virtual void OnRestart()
        {

        }

        /// <summary>
        /// Called right after a game ends in victory
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.ToggleFastForward
        /// </summary>
        public virtual void OnFastForwardChanged()
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
        public virtual void PostBloonDamaged(Bloon bloon, float amount, DamageType damageType, 
            [Optional] Projectile projectile, [Optional] DamageDistributionMethod distributeToChildren, 
            [Optional] Tower damageBy, bool allowTransform = true)
        {
        }
        #endregion

        #region Tower Hooks

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
        public virtual void OnTowerSold(Tower tower)
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
        /// Equivalent to a HarmonyPostFix on Tower.ResetHilight
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
        /// Equivalent to a HarmonyPostFix on Simulation.IncreaseCash
        /// </summary>
        public virtual void OnCashAdded(double amount, Simulation.CashIncreaseReason reason)
        {

        }

        /// <summary>
        /// Called right after Cash is removed in a game
        /// 
        /// Equivalent to a HarmonyPostFix on Simulation.DecreaseCash
        /// </summary>
        public virtual void OnCashRemoved(double amount)
        {

        }

        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.RoundStart
        /// </summary>
        public virtual void OnRoundStart(int roundNumber)
        {

        }

        /// <summary>
        /// Called right after a round starts
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.RoundEnd
        /// </summary>
        public virtual void OnRoundEnd(int roundNumber, bool roundCompleted)
        {

        }

        /// <summary>
        /// Called right after a match ends in defeat
        /// 
        /// Equivalent to a HarmonyPostFix on InGame.OnPlayerDeath
        /// </summary>
        public virtual void OnDefeat()
        {

        }

        #endregion

        #region Weapon/Projectile Hooks

        /// <summary>
        /// Called right after a Weapon is created
        ///
        /// Equivalent to a HarmonyPostFix on Weapon.Initialise
        /// </summary>
        public virtual void OnWeaponCreated(Weapon weapon, Entity entity, Model modelToUse)
        {
        }


        /// <summary>
        /// Called right after a Tower's TowerModel is changed for any reason (creation, upgrading, etc.)
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
    }
}
