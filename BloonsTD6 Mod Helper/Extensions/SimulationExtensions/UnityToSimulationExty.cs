using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity.Bridge;

namespace BTD_Mod_Helper.Extensions
{
    public static class UnityToSimulationExt
    {
        /// <summary>
        /// Custom API method that changes the game's round set to a custom RoundSetModel.
        /// </summary>
        /// <param name="roundSet">New Round Set Model to use</param>
        public static void SetRoundSet(this UnityToSimulation unityToSimulation, RoundSetModel roundSet)
        {
            Api.SessionData.RoundSet = roundSet;
        }
    }
}