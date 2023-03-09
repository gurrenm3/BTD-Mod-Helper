using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.BTD6;

/// <summary>
/// Class to access the game's Map Select UI
/// </summary>
public static class MapSelectUI
{
    /// <summary>
    /// Gets the Scene if on the Map Select menu
    /// </summary>
    public static Scene? GetScene()
    {
        try
        { return SceneManager.GetSceneByName("MapSelectUI"); }
        catch (ArgumentException)
        { return null; }
    }

    /// <summary>
    /// Gets the Canvas for the MapSelectUI, or null
    /// </summary>
    public static Canvas GetCanvas()
    {
        var sceneObjects = GetScene()?.GetRootGameObjects();
        if (sceneObjects is null || sceneObjects.Count == 0)
            return null;

        const int canvasIndex = 0;
        var canvas = sceneObjects[canvasIndex];
        return canvas.GetComponent<Canvas>();
    }

    /// <summary>
    /// Gets the Beginner Button if on the Map Select Menu, or null
    /// </summary>
    public static Toggle GetBeginnerButton()
    {
        return GetCanvas()?.GetComponent<Toggle>("MapSelectScreen/MapDifficulties/BeginnerBtn");
    }

    /// <summary>
    /// Gets the Intermediate Button if on the Map Select Menu, or null
    /// </summary>
    public static Toggle GetIntermediateButton()
    {
        return GetCanvas()?.GetComponent<Toggle>("MapSelectScreen/MapDifficulties/IntermediateBtn");
    }

    /// <summary>
    /// Gets the Advanced Button if on the Map Select Menu, or null
    /// </summary>
    public static Toggle GetAdvancedButton()
    {
        return GetCanvas()?.GetComponent<Toggle>("MapSelectScreen/MapDifficulties/AdvancedBtn");
    }

    /// <summary>
    /// Gets the Expert Button if on the Map Select Menu, or null
    /// </summary>
    public static Toggle GetExpertButton()
    {
        return GetCanvas()?.GetComponent<Toggle>("MapSelectScreen/MapDifficulties/ExpertBtn");
    }

    /// <summary>
    /// Gets the Extreme Button if on the Map Select Menu, or null
    /// </summary>
    public static Toggle GetExtremeButton()
    {
        return GetCanvas()?.GetComponent<Toggle>("MapSelectScreen/MapDifficulties/ExtremeBtn");
    }
}