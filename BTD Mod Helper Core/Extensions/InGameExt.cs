using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Simulation.Factory;
using Assets.Scripts.Simulation.Objects;
using Assets.Scripts.Simulation.Towers;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Collections.Generic;

#if BloonsTD6
using Assets.Scripts.Simulation.Towers.Projectiles;
#elif BloonsAT
using Assets.Scripts.Simulation.Towers.Projectiles.Behaviors;
#endif

namespace BTD_Mod_Helper.Extensions
{
    public static partial class InGameExt
    {
        public static List<Tower> GetTowers(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Tower>().ToList();
        }

        public static List<TowerToSimulation> GetTowerSims(this InGame inGame)
        {
            return inGame.GetUnityToSim().GetAllTowers().ToSystemList();
        }

        public static List<Bloon> GetBloons(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Bloon>().ToList();
        }

        public static List<BloonToSimulation> GetBloonSims(this InGame inGame)
        {
            return inGame.GetUnityToSim().GetAllBloons().ToSystemList();
        }

        public static List<Projectile> GetProjectiles(this InGame inGame)
        {
            return inGame.GetAllObjectsOfType<Projectile>().ToList();
        }

        public static List<AbilityToSimulation> GetAbilities(this InGame inGame)
        {
#if BloonsTD6
            return inGame.GetUnityToSim().GetAllAbilities(true).ToSystemList();
#elif BloonsAT
            return inGame.GetUnityToSim().GetAllAbilities().ToSystemList();
#endif
        }

        public static Factory<T> GetFactory<T>(this InGame inGame) where T : RootObject, new()
        {
            return inGame.GetUnityToSim().GameSimulation.factory.GetFactory<T>();
        }

        public static UnityToSimulation GetUnityToSim(this InGame inGame)
        {
#if BloonsTD6
            return inGame.bridge;
#elif BloonsAT
            return inGame.Simulation;
#endif
        }
    }
}
