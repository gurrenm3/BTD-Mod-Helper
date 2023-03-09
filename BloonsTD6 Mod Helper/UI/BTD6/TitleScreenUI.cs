using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.BTD6;

/// <summary>
/// Class to access the Title Screen UI
/// </summary>
public static class TitleScreenUI
{
    /// <summary>
    /// Gets the Scene if on the Title Screen menu
    /// </summary>=
    public static Scene? GetScene()
    {
        try
        { return SceneManager.GetSceneByName("TitleScreenUI"); }
        catch (ArgumentException)
        { return null; }
    }

    /// <summary>
    /// Gets the Canvas for the TitleScreenUI, or null
    /// </summary>
    public static Canvas GetCanvas()
    {
        var sceneObjects = GetScene()?.GetRootGameObjects();
        if (sceneObjects is null || sceneObjects.Count == 0)
            return null;

        const int canvasIndex = 3;
        var canvas = sceneObjects[canvasIndex];
        return canvas.GetComponent<Canvas>();
    }

    /// <summary>
    /// Gets the Intermediate Button if on the Map Select Menu, or null
    /// </summary>
    public static Button GetStartButton()
    {
        return GetCanvas()?.GetComponent<Button>("ScreenBoxer/TitleScreen/Start");
    }
}