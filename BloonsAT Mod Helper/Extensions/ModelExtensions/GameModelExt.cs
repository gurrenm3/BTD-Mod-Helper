using Assets.Scripts.Models;
using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Models.Rounds;
using BTD_Mod_Helper.Api.Builders;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static class GameModelExt
    {
        /// <summary>
        /// Get the instance of the API's BloonModelBuilder. Used to create custom bloon types and add them to the game
        /// </summary>
        public static BloonModelBuilder GetBloonModelBuilder(this GameModel model)
        {
            return BloonModelBuilder.Instance;
        }

        /// <summary>
        /// Create a BloonEmissionModel from a bloonModel
        /// </summary>
        /// <param name="bloonModel">The bloon model that these bloons should be</param>
        /// <param name="number">Number of Bloons in this emission</param>
        /// <param name="spacing">Space between each bloon in this emission</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, BloonModel bloonModel, int number, float spacing)
        {
            return model.CreateBloonEmissions(bloonModel.baseType, number, spacing);
        }

        /// <summary>
        /// Create a BloonEmissionModel from a bloon's name
        /// </summary>
        /// <param name="baseType">Type of bloon. Example: "Red"</param>
        /// <param name="number">Number of Bloons in this emission</param>
        /// <param name="spacing">Space between each bloon in this emission</param>
        public static Il2CppReferenceArray<BloonEmissionModel> CreateBloonEmissions(this GameModel model, BloonBaseType baseType, int number, float spacing)
        {
            List<BloonEmissionModel> bloonEmissionModels = new List<BloonEmissionModel>();

            for (int i = 0; i < number; i++)
                bloonEmissionModels.Add(model.CreateBloonEmission(baseType, time: (int)spacing * i));

            return bloonEmissionModels.ToIl2CppReferenceArray();
        }

        /// <summary>
        /// Create a single BloonEmission
        /// </summary>
        /// <param name="baseType">Type of this bloon. Example: "Red"</param>
        /// <param name="time">Time the bloon should be spawned</param>
        public static BloonEmissionModel CreateBloonEmission(this GameModel model, BloonBaseType baseType, int time)
        {
            return new BloonEmissionModel(time:time, baseType);
        }
    }
}