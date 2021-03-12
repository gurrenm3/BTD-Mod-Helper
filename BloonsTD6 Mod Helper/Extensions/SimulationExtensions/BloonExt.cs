using Assets.Scripts.Models.Bloons;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame;
using System.Runtime.InteropServices;

namespace BTD_Mod_Helper.Extensions
{
    public static class BloonExt
    {
        /// <summary>
        /// Set bloon to be camo or not. Will change bloonModel to camo version if it exists
        /// </summary>
        /// <param name="isCamo">Should bloon be camo</param>
        public static void SetCamo(this Bloon bloon, bool isCamo)
        {
            BloonModel bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(isCamo, bloonModel.isFortified, bloonModel.isGrow);
        }

        /// <summary>
        /// Set bloon to be fortified or not. Will change bloonModel to fortified version if it exists
        /// </summary>
        /// <param name="isFortified">Should bloon be fortified</param>
        public static void SetFortified(this Bloon bloon, bool isFortified)
        {
            BloonModel bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(bloonModel.isCamo, isFortified, bloonModel.isGrow);
        }

        /// <summary>
        /// Set bloon to be regrow or not. Will change bloonModel to regrow version if it exists
        /// </summary>
        /// <param name="isRegrow">Should bloon be regrow</param>
        public static void SetRegrow(this Bloon bloon, bool isRegrow)
        {
            BloonModel bloonModel = bloon.bloonModel;
            bloon.SetBloonStatus(bloonModel.isCamo, bloonModel.isFortified, isRegrow);
        }

        /// <summary>
        /// Remove current statuses from bloon
        /// </summary>
        /// <param name="removeCamo">Should remove camo if present?</param>
        /// <param name="removeFortify">Should remove fortify if present?</param>
        /// <param name="removeRegrow">Should remove regrow if present?</param>
        public static void RemoveBloonStatus(this Bloon bloon, bool removeCamo, bool removeFortify, bool removeRegrow)
        {
            string bloonId = bloon.bloonModel.id;

            if (bloonId.Contains("Camo") && removeCamo)
                bloonId = bloonId.Replace("Camo", "");
            if (bloonId.Contains("Fortified") && removeFortify)
                bloonId = bloonId.Replace("Fortified", "");
            if (bloonId.Contains("Regrow") && removeRegrow)
                bloonId = bloonId.Replace("Regrow", "");

            BloonModel newBloonModel = Game.instance.model.GetBloonModel(bloonId);
            bloon.bloonModel = newBloonModel;
            bloon.UpdateDisplay();
        }

        /// <summary>
        /// Set the statuses of the bloon. Will change bloonModel if one exists with these statuses
        /// </summary>
        /// <param name="setCamo">Should have camo?</param>
        /// <param name="setFortified">Should have fortify?</param>
        /// <param name="setRegrow">Should have regrow?</param>
        public static void SetBloonStatus(this Bloon bloon, [Optional] bool setCamo, [Optional] bool setFortified, [Optional] bool setRegrow)
        {
            Assets.Scripts.Models.GameModel model = Game.instance.model;
            BloonModel bloonModel = bloon.bloonModel;

            string camoText = (setCamo && model.GetBloonModel(bloonModel.baseId + "Camo") != null) ? "Camo" : "";
            string fortifiedText = (setFortified && model.GetBloonModel(bloonModel.baseId + "Fortified") != null) ? "Fortified" : "";
            string regrowText = (setRegrow && model.GetBloonModel(bloonModel.baseId + "Regrow") != null) ? "Regrow" : "";

            string newBloonID = bloonModel.baseId + regrowText + fortifiedText + camoText;
            bloon.bloonModel = Game.instance.model.GetBloonModel(newBloonID);
            bloon.UpdateDisplay();
        }

        /// <summary>
        /// Get the BloonToSimulation for this specific Bloon
        /// </summary>
        public static BloonToSimulation GetBloonToSim(this Bloon bloon)
        {
            return InGame.Bridge.GetAllBloons().FirstOrDefault(b => b.id == bloon.Id);
        }
    }
}