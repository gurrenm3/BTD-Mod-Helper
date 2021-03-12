using BTD_Mod_Helper.Extensions;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BTD_Mod_Helper.BTD6_UI
{
    public static class MainMenuUI
    {
        public static Scene? GetScene()
        {
            try
            { return SceneManager.GetSceneByName("MainMenuUi"); }
            catch (ArgumentException)
            { return null; }
        }

        public static Canvas GetCanvas()
        {
            var scene = GetScene();
            if (!scene.HasValue)
                return null;

            var sceneObjects = scene.Value.GetRootGameObjects();
            if (sceneObjects is null || sceneObjects.Count == 0)
                return null;

            const int canvasIndex = 0;
            var canvas = sceneObjects[canvasIndex];
            return canvas.GetComponent<Canvas>();
        }

        public static Button GetMonkeysButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Monkeys/MonkeysAnim/Button");
        }

        public static Button GetHeroesButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Heroes/HeroesAnim/Button");
        }

        public static Button GetPlayButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Play/PlayAnim/Button");
        }

        public static Button GetCoopButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/CoOp/CoopAnim/Button");
        }

        public static Button GetPowersButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Powers/PowersAnim/Button");
        }

        public static Button GetKnowledgeButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/BottomButtonGroup/Knowledge/KnowledgeAnim/Button");
        }

        public static Button GetSettingsButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/Settings/Button");
        }

        public static Button GetAchievementsButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/Achievements/Button");
        }

        public static Button GetStoreButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/Store/Button");
        }

        public static Button GetTrophyStoreButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/TrophyStore/Button");
        }

        public static Button GetExitButton()
        {
            return GetCanvas()?.GetComponent<Button>("MainMenu/TrophyStore/Button");
        }

        public static NK_TextMeshProUGUI GetXpBarText()
        {
            return GetCanvas()?.GetComponent<NK_TextMeshProUGUI>("MainMenu/PlayerInfo/XpBar/Text");
        }
    }
}