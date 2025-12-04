using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.ModMenu;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.LiNK.Client.LiNKAccountControllers;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BTD_Mod_Helper.UI.BTD6;

internal static class EmbeddedBrowser
{
    public const bool CurrentlyWorking = false;

    public static string CurrentUrl { get; private set; }

    internal static void OpenURL(string url)
    {
        if (!CurrentlyWorking)
        {
            ProcessHelper.OpenURL(url);
            return;
        }

#pragma warning disable CS0162 // Unreachable code detected

        var player = Game.Player;
        var controller = player.webviewLiNKAccountController ??=
            new MobileWebviewLiNKAccountController(player.LiNKAccountController, new Action(() => { }));
        controller.CreateEverything().ContinueWith(new Action<Task>(task =>
        {
            if (task.Status != TaskStatus.RanToCompletion) return;

            CurrentUrl = url;

            controller.viewGameObject.transform.Cast<RectTransform>().sizeDelta = new Vector2(0, -1000);
            var webview = controller.webview;
            controller.PerformLoadTask(webview.ShowPage(url)).ContinueWith(new Action<Task>(t =>
            {
                if (t.Status != TaskStatus.RanToCompletion) return;

                var canvas = controller.viewGameObject.transform.parent.gameObject;
                var panel = canvas.AddModHelperPanel(new Info("TopBar")
                {
                    AnchorMin = new Vector2(0, 1), AnchorMax = new Vector2(1, 1),
                    Pivot = new Vector2(0, 1), Height = 150
                }, null, RectTransform.Axis.Horizontal, 25, 25);
                panel.AddModHelperComponent(ModHelperButton.Create(new Info("CloseButton", 100),
                    VanillaSprites.CloseBtn, new Action(() => controller.DestroyEverything())));
                panel.AddModHelperComponent(ModHelperButton.Create(new Info("BackButton", 100),
                    VanillaSprites.BackBtn, new Action(() => webview.RunJavascript("history.back()"))));
                panel.AddModHelperComponent(ModHelperButton.Create(new Info("RefreshButton", 100),
                    VanillaSprites.RestartBtn, new Action(() => {/* steamWebView.Reload() */})));
                var open = panel.AddModHelperComponent(ModHelperButton.Create(new Info("OpenButton", 100),
                    VanillaSprites.BlueBtn, new Action(() => ProcessHelper.OpenURL(CurrentUrl))));
                var exit = open.AddImage(new Info("Exit", 70), VanillaSprites.ExitIcon);
                exit.RectTransform.Rotate(0, 0, -90);

#if DEBUG
                panel.AddModHelperComponent(ModHelperButton.Create(new Info("GoogleButton", 100),
                    VanillaSprites.ReviewMapBtn, new Action(() =>
                        webview.RunJavascript("location.href = 'https://google.com?theme=dark'"))));
#endif

                FixView(controller.viewGameObject);

                var webView = webview.gameObject;
                var rawImage = webView.AddComponent<RawImage>();
                FixView(webView);
                var webViewTransform = webView.transform.Cast<RectTransform>();
                webViewTransform.localRotation = new Quaternion(0, 0, 180, 0);
                webViewTransform.localScale = new Vector3(-1, 1, 1);
                rawImage.enabled = false;

                // steamWebView.OnPageFinished += new Action<UniWebView, int, string>((_, _, _) => onPageLoad?.Invoke(steamWebView));
            }));
        }));

        PopupScreen.instance.transform.parent.gameObject.GetComponent<Canvas>().sortingOrder = 11;
    }

    private static void FixView(GameObject gameObject)
    {
        var rectTransform = gameObject.transform.Cast<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.localPosition = Vector3.zero;
    }

    /*

    /// <summary>
    /// Block clicks to objects above the webview
    /// </summary>
    [HarmonyPatch(typeof(Event), nameof(Event.current), MethodType.Getter)]
    internal static class Event_get_current
    {
        [HarmonyPostfix]
        private static void Postfix(ref Event __result)
        {
            if (SteamWebView_OnGUI.UsingRawImage && __result is {type: EventType.MouseDown or EventType.ScrollWheel})
            {
                try
                {
                    var results = new List<RaycastResult>();
                    EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
                    {
                        position = Input.mousePosition
                    }, results);
                    if (results.Count == 0 || !results._items[0].gameObject.HasComponent<SteamWebView>())
                    {
                        __result = null;
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning(e);
                }
            }
        }
    }


    /// <summary>
    /// Don't draw the SteamWebView on the entire screen when using the RawImage
    /// </summary>
    [HarmonyPatch(typeof(GUI), nameof(GUI.DrawTexture), typeof(Rect), typeof(Texture))]
    internal static class GUI_DrawTexture
    {
        [HarmonyPrefix]
        private static bool Prefix() => !SteamWebView_OnGUI.UsingRawImage;
    }


    #region Nested type: HTML_URLChanged_t_OnResultWithInfo

    /// <summary>
    /// Keep the CurrentUrl up to date
    /// </summary>
    [HarmonyPatch(typeof(HTML_URLChanged_t), nameof(HTML_URLChanged_t.OnResultWithInfo))]
    internal static class HTML_URLChanged_t_OnResultWithInfo
    {
        [HarmonyPostfix]
        private static void Postfix(IntPtr param, bool failure)
        {
            if (failure) return;

            var e = HTML_URLChanged_t.FromPointer(param);
            var url = e.PchURL;
            if (url.StartsWith("http"))
            {
                CurrentUrl = url;
            }
        }
    }
    [HarmonyPatch(typeof(HtmlSurface), nameof(HtmlSurface.OnFileOpenDialogAPI))]
    internal static class HtmlSurface_OnFileOpenDialogAPI
    {
        [HarmonyPrefix]
        private static bool Prefix(HtmlSurface __instance, HTML_FileOpenDialog_t callbackdata)
        {
            var nativeHtmlSurface = __instance.client.native.htmlSurface;

            return false;
        }
    }

    /// <summary>
    /// Allow mod files to be downloaded through the browser
    /// </summary>
    [HarmonyPatch(typeof(HtmlSurface), nameof(HtmlSurface.OnStartRequestAPI))]
    internal static class HtmlSurface_OnStartRequestAPI
    {
        [HarmonyPrefix]
        private static void Postfix(HtmlSurface __instance, HTML_StartRequest_t callbackdata)
        {
            if (callbackdata.BIsRedirect) return;

            var url = callbackdata.PchURL;

            try
            {
                ModHelperHttp.Client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url)).ContinueWith(task =>
                {
                    var result = task.Result;
                    if (ModHelperGithub.AllContentTypes.Contains(result.Content.Headers.ContentType?.ToString() ?? ""))
                    {
                        ProcessHelper.OpenURL(callbackdata.PchURL);
                    }
                });
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

    /// <summary>
    /// Use a RawImage to render if available so that objects can be displayed on top of it
    /// </summary>
    internal static class SteamWebView_OnGUI
    {
        private static System.Collections.Generic.IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(typeof(SteamWebView), nameof(SteamWebView.OnGUI));
        }

        public static bool UsingRawImage { get; private set; }

        [HarmonyPrefix]
        private static void Prefix(SteamWebView __instance)
        {
            if (__instance.gameObject.HasComponent(out RawImage image))
            {
                UsingRawImage = true;
                image.texture = __instance.texture;
                image.enabled = !__instance.hidden && __instance.browserReady;
            }
        }

        [HarmonyPostfix]
        private static void PostFix()
        {
            UsingRawImage = false;
        }
    }
    */
}