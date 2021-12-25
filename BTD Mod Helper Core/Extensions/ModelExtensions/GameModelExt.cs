using Assets.Scripts.Models;
using BTD_Mod_Helper.Api.Builders;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class GameModelExt
    {
        /// <summary>
        /// (Cross-Game compatible) Return the instance of the API's BloonModelBuilder. Used to create custom bloon types and add them to the game
        /// </summary>
        public static BloonModelBuilder GetBloonModelBuilder(this GameModel model)
        {
            return BloonModelBuilder.Instance;
        }

        /// <summary>
        /// Returns whether or not a bloon exists with this name
        /// </summary>
        /// <param name="gameModel"></param>
        /// <param name="bloonName"></param>
        /// <returns></returns>
        public static bool DoesBloonExist(this GameModel gameModel, string bloonName)
        {
            return gameModel.bloons.Any(bloon => bloon.name == bloonName);
        }
    }
}