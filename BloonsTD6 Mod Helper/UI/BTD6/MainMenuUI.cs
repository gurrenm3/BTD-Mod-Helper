using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.BTD6;

/// <summary>
/// Class to access the game's Main Menu UI
/// </summary>
public static class MainMenuUI
{
    /// <summary>
    /// Gets the Scene for the Main Menu
    /// </summary>
    public static Scene? GetScene()
    {
        try
        { return SceneManager.GetSceneByName("MainMenuUi"); }
        catch (ArgumentException)
        { return null; }
    }

    /// <summary>
    /// Gets the Canvas for the Main Menu
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
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetMonkeysButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Monkeys/MonkeysAnim/Button");
    }

    /// <summary>
    /// Gets the Heroes Button if on the Main Menu, or null
    /// </summary>
    public static Button GetHeroesButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Heroes/HeroesAnim/Button");
    }

    /// <summary>
    /// Gets the Play Button if on the Main Menu, or null
    /// </summary>
    public static Button GetPlayButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Play/PlayAnim/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetCoopButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/CoOp/CoopAnim/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetPowersButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Powers/PowersAnim/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetKnowledgeButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Knowledge/KnowledgeAnim/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetSettingsButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/Settings/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetAchievementsButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/Achievements/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetStoreButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/Store/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetTrophyStoreButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/TrophyStore/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static Button GetExitButton()
    {
        return GetCanvas()?.GetComponent<Button>("MainMenu/TrophyStore/Button");
    }

    /// <summary>
    /// Gets the Monkeys Button if on the Main Menu, or null
    /// </summary>
    public static NK_TextMeshProUGUI GetXpBarText()
    {
        return GetCanvas()?.GetComponent<NK_TextMeshProUGUI>("MainMenu/PlayerInfo/XpBar/Text");
    }
}