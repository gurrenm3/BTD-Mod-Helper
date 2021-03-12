using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;

namespace BTD_Mod_Helper.BTD6_UI
{
    public static class TitleScreenUI
    {
        public static Scene? GetScene()
        {
            try
            { return SceneManager.GetSceneByName("TitleScreenUI"); }
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

            const int canvasIndex = 3;
            var canvas = sceneObjects[canvasIndex];
            return canvas.GetComponent<Canvas>();
        }

        public static Button GetStartButton()
        {
            return GetCanvas()?.GetComponent<Button>("ScreenBoxer/TitleScreen/Start");
        }
    }
}
