using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;
using Assets.Scripts.Simulation.Track;
using Assets.Scripts.Simulation;
using Assets.Scripts.Models;

#if BloonsTD6
using Assets.Scripts.Simulation.Towers.Projectiles;
#elif BloonsAT
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class InGameExt
    {
        /// <summary>
        /// Get the current Map
        /// </summary>
        public static Map GetMap(this InGame inGame)
        {
            return inGame.GetSimulation()?.Map;
        }

        /// <summary>
        /// Get the current Simulation for this InGame session
        /// </summary>
        public static Simulation GetSimulation(this InGame inGame)
        {
            return inGame.GetUnityToSimulation()?.simulation;
        }

        /// <summary>
        /// The Game.model that is being used for this InGame.instance
        /// </summary>
        public static GameModel GetGameModel(this InGame inGame)
        {
            return inGame.GetSimulation()?.model;
        }

        /// <summary>
        /// Get the main Factory that creates and manages all other Factories
        /// </summary>
        public static FactoryFactory GetMainFactory(this InGame inGame)
        {
            return inGame.GetSimulation()?.factory;
        }

        public static Factory<T> GetFactory<T>(this InGame inGame) where T : RootObject, new()
        {
            return inGame.GetMainFactory()?.GetFactory<T>();
        }

        public static List<Tower> GetTowers(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Tower>();
        }

        public static List<TowerToSimulation> GetTowerSims(this InGame inGame)
        {
            return inGame.GetUnityToSimulation()?.GetAllTowers()?.ToList();
        }

        public static List<Bloon> GetBloons(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Bloon>();
        }

        public static List<BloonToSimulation> GetBloonSims(this InGame inGame)
        {
            return inGame.GetUnityToSimulation()?.GetAllBloons()?.ToList();
        }

        public static List<Projectile> GetProjectiles(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Projectile>();
        }

        /// <summary>
        /// Get the current TowerManager for this game session
        /// </summary>
        public static TowerManager GetTowerManager(this InGame inGame)
        {
            return inGame.GetSimulation().towerManager;
        }

        public static List<AbilityToSimulation> GetAbilities(this InGame inGame)
        {
#if BloonsTD6
            return inGame.GetUnityToSimulation()?.GetAllAbilities(true)?.ToList();
#elif BloonsAT
            return inGame.GetUnityToSimulation()?.GetAllAbilities()?.ToList();
#endif
        }


        public static UnityToSimulation GetUnityToSimulation(this InGame inGame)
        {
#if BloonsTD6
            return inGame.bridge;
#elif BloonsAT
            return inGame.Simulation;
#endif
        }


        /// <summary>
        /// Gets all objects of type T. Does this by returning all objects created by the Factory of type T
        /// </summary>
        /// <typeparam name="T">The type of items you want</typeparam>
        public static List<T> GetAllObjectsOfType<T>(this InGame inGame) where T : RootObject, new()
        {
            var factory = inGame.GetMainFactory()?.GetFactory<T>();
#if BloonsTD6
            return factory?.all?.ToList();
#elif BloonsAT
            return factory?.active?.ToList();
#endif
        }
    }
}
