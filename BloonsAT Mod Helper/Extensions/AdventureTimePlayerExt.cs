using Assets.Scripts.Models.Profile;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Player;
using System;

namespace BTD_Mod_Helper.Extensions
{
    public static class AdventureTimePlayerExt
    {
        /// <summary>
        /// Returns whether or not the player has any StatusFlags on their account
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool HasStatusFlags(this AdventureTimePlayer player)
        {
            var statusFlags = Enum.GetValues(typeof(ProfileStatusFlags));
            
            foreach (ProfileStatusFlags flag in statusFlags)
            {
                if (Game.instance.GetAdventureTimePlayer().HasStatusFlags(flag))
                    return true;
            }

            return false;
        }
    }
}
