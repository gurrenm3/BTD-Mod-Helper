using System.Runtime.InteropServices;
using Il2CppAssets.Scripts;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Display;
using Il2CppAssets.Scripts.Simulation.Factory;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Bridge;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Bloons
/// </summary>
public static class BloonExt
{
    /// <summary>
    /// Return the DisplayNode for this bloon
    /// </summary>
    /// <returns></returns>
    public static DisplayNode GetDisplayNode(this Bloon bloon) => bloon.Node;

    /// <summary>
    /// Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites
    /// </summary>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static UnityDisplayNode GetUnityDisplayNode(this Bloon bloon) => bloon.GetDisplayNode()?.graphic;

    /// <summary>
    /// Creates a new BloonToSimulation based off of this Bloon and stores it for possible later use. It will automatically
    /// destroyed when this Bloon is destroyed
    /// </summary>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static BloonToSimulation CreateBloonToSim(this Bloon bloon)
    {
        var currentPos = new Vector3();
        if (bloon.Position?.ToUnity() != null)
        {
            currentPos = bloon.Position.ToUnity();
        }

        var sim = InGame.instance.GetUnityToSimulation();
        return new BloonToSimulation(sim, bloon.GetId(), currentPos, bloon.bloonModel);
    }

    /// <summary>
    /// Return the Id of this Bloon
    /// </summary>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static ObjectId GetId(this Bloon bloon) => bloon.Id;

    /// <summary>
    /// Return the Factory that creates Bloons
    /// </summary>
    /// <param name="bloon"></param>
    /// <returns></returns>
    public static Factory<Bloon> GetFactory(this Bloon bloon) => InGame.instance.GetFactory<Bloon>();

    /// <summary>
    /// Return the existing BloonToSimulation for this specific Bloon.
    /// </summary>
    public static BloonToSimulation GetBloonToSim(this Bloon bloon)
    {
        var allBloons = InGame.instance.GetUnityToSimulation().GetAllBloons();
        return allBloons?.FirstOrDefault(simulation => simulation.GetBloon() == bloon);
    }

    /// <summary>
    /// Tests whether a project will pop this bloon
    /// </summary>
    /// <param name="bloon"></param>
    /// <param name="projectile"></param>
    /// <returns></returns>
    public static bool WillPopBloon(this Bloon bloon, Projectile projectile) =>
        bloon.WillPopBloon(projectile.projectileModel.GetDamageModel(), projectile);

    /// <summary>
    /// Returns whether or not the bloon was popped rather than leaked.
    /// </summary>
    /// <param name="bloon"></param>
    /// <returns>True if it was popped, false if it was leaked or not destroyed yet</returns>
    public static bool WasBloonPopped(this Bloon bloon)
    {
        //bloon.will
        var leakedBloon = SessionData.Instance.LeakedBloons.Contains(bloon);
        var destroyedBloon = SessionData.Instance.DestroyedBloons.Contains(bloon);
        return destroyedBloon && !leakedBloon;
    }

    /// <summary>
    /// Set bloon to be camo or not. Will change bloonModel to camo version if it exists
    /// </summary>
    /// <param name="bloon">the Bloon</param>
    /// <param name="isCamo">Should bloon be camo</param>
    public static void SetCamo(this Bloon bloon, bool isCamo)
    {
        var bloonModel = bloon.bloonModel;
        bloon.SetBloonStatus(isCamo, bloonModel.isFortified, bloonModel.isGrow);
    }

    /// <summary>
    /// Set bloon to be fortified or not. Will change bloonModel to fortified version if it exists
    /// </summary>
    /// <param name="bloon">the Bloon</param>
    /// <param name="isFortified">Should bloon be fortified</param>
    public static void SetFortified(this Bloon bloon, bool isFortified)
    {
        var bloonModel = bloon.bloonModel;
        bloon.SetBloonStatus(bloonModel.isCamo, isFortified, bloonModel.isGrow);
    }

    /// <summary>
    /// Set bloon to be regrow or not. Will change bloonModel to regrow version if it exists
    /// </summary>
    /// <param name="bloon">the Bloon</param>
    /// <param name="isRegrow">Should bloon be regrow</param>
    public static void SetRegrow(this Bloon bloon, bool isRegrow)
    {
        var bloonModel = bloon.bloonModel;
        bloon.SetBloonStatus(bloonModel.isCamo, bloonModel.isFortified, isRegrow);
    }

    /// <summary>
    /// Remove current statuses from bloon
    /// </summary>
    /// <param name="bloon">the Bloon</param>
    /// <param name="removeCamo">Should remove camo if present?</param>
    /// <param name="removeFortify">Should remove fortify if present?</param>
    /// <param name="removeRegrow">Should remove regrow if present?</param>
    public static void RemoveBloonStatus(this Bloon bloon, bool removeCamo, bool removeFortify, bool removeRegrow)
    {
        var bloonId = bloon.bloonModel.id;

        if (bloonId.Contains("Camo") && removeCamo)
            bloonId = bloonId.Replace("Camo", "");
        if (bloonId.Contains("Fortified") && removeFortify)
            bloonId = bloonId.Replace("Fortified", "");
        if (bloonId.Contains("Regrow") && removeRegrow)
            bloonId = bloonId.Replace("Regrow", "");

        var newBloonModel = Game.instance.model.GetBloon(bloonId);
        bloon.bloonModel = newBloonModel;
        bloon.UpdateDisplay();
    }

    /// <summary>
    /// Set the statuses of the bloon. Will change bloonModel if one exists with these statuses
    /// </summary>
    /// <param name="bloon">the Bloon</param>
    /// <param name="setCamo">Should have camo?</param>
    /// <param name="setFortified">Should have fortify?</param>
    /// <param name="setRegrow">Should have regrow?</param>
    public static void SetBloonStatus(this Bloon bloon, [Optional] bool setCamo, [Optional] bool setFortified,
        [Optional] bool setRegrow)
    {
        var model = Game.instance.model;
        var bloonModel = bloon.bloonModel;

        var camoText = setCamo && model.GetBloon(bloonModel.baseId + "Camo") != null ? "Camo" : "";
        var fortifiedText = setFortified && model.GetBloon(bloonModel.baseId + "Fortified") != null ? "Fortified" : "";
        var regrowText = setRegrow && model.GetBloon(bloonModel.baseId + "Regrow") != null ? "Regrow" : "";

        var newBloonID = bloonModel.baseId + regrowText + fortifiedText + camoText;
        bloon.bloonModel = Game.instance.model.GetBloon(newBloonID);
        bloon.UpdateDisplay();
    }
}