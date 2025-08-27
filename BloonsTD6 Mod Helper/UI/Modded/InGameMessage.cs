using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.UI.Modded;

internal class NkhText
{
    public string Body;
    public Color BodyColor = Color.white;
    public string Title;
    public Color TitleColor = Color.white;
    //public Vector2? BodyPosition;
    //public Vector2? BodySize;
}

internal class NkhMsg
{
    public double MsgShowTime = 1.5f;
    public NkhText NkhText;
}

internal class Notification
{

    internal static AssetBundle assetBundle;
    internal static GameObject canvas;
    //private readonly int defaultWidth = 345;
    private readonly int defaultWidth = 500;
    private readonly int maxX = 15;
    private readonly float transitionWaitTimePerRun = 0f;
    public Text body;
    public NkhMsg currentMsg;
    private bool doHideMsg;
    private bool doShowMsg;
    private bool doStallMsg;
    public GameObject gameObject;

    public Image img;

    private float nextMsgRunTime;
    private float nextX;
    public int slot;
    public Text title;

    public Notification(int slot, NkhMsg msg)
    {
        if (assetBundle == null)
        {
            assetBundle = ModContent.GetBundle<MelonMain>("ingame_popup");
        }
        if (canvas == null)
        {
            canvas = assetBundle.LoadAssetSync<GameObject>("Canvas");
        }

        this.slot = slot;
        //======
        // Initialize game object stuff
        //======

        var globalScene = SceneManager.GetSceneByName("Global");


        /*img = canvas.transform.Find("Image").GetComponent<Image>();
        title = canvas.transform.Find("Image/Title").GetComponent<Text>();
        body = canvas.transform.Find("Image/Body").GetComponent<Text>();

        gameObject = GameObject.Instantiate(img.gameObject, mainMenuUI.GetRootGameObjects()[0].transform);*/



        gameObject = Object.Instantiate(canvas, globalScene.GetRootGameObjects()[0].transform);

        //tried this to get popup showing on main menu. Didnt work
        /*var canvasPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(canvasPos.x, canvasPos.y, -46); //48*/

        img = gameObject.transform.Find("Image").GetComponent<Image>();
        title = gameObject.transform.Find("Image/Title").GetComponent<Text>();
        body = gameObject.transform.Find("Image/Body").GetComponent<Text>();




        //======
        //set ui elements
        //======
        currentMsg = msg;

        title.text = currentMsg.NkhText.Title;
        title.color = currentMsg.NkhText.TitleColor;
        body.text = currentMsg.NkhText.Body;
        body.color = currentMsg.NkhText.BodyColor;

        //set pos so elements are positioned correctly
        var windowHeight = Screen.height;
        //ModHelper.Log(windowHeight.ToString());

        var test1 = windowHeight / 8 * 1.155f;
        //var spaceBetweenSlots = 110 * slot;
        //var spaceBetweenSlots = 135* slot;
        var spaceBetweenSlots = test1 * slot;


        var transform = img.transform;
        var pos = transform.position;
        pos.x = -defaultWidth;
        pos.y -= spaceBetweenSlots + 55;
        pos.z = 955; //might get rid of this later. Setting ui to be very high up so it won't get put under other stuff. Game camera is at about 995
        nextX = -defaultWidth;
        transform.position = pos;


        if (currentMsg.MsgShowTime == 0)
            currentMsg.MsgShowTime = 1.5;
        //prepping final variables for smooth transitions
        doShowMsg = true;
        doStallMsg = false;
        doHideMsg = false;

        UpdateEvent += Notification_UpdateEvent;
    }

    private void Notification_UpdateEvent(object sender, NotificationEventArgs e)
    {
        Update();
    }

    public void Update()
    {
        if (Time.time < nextMsgRunTime)
            return;

        if (doShowMsg)
            ShowMsg();

        if (doStallMsg)
            StallMsg();

        if (doHideMsg)
            HideMsg();
    }

    private void ShowMsg()
    {
        if (Time.time < nextMsgRunTime)
            return;

        var amtToAdd = 18.5f;
        if (img.transform.position.x + amtToAdd >= maxX)
        {
            Slide(maxX);
            doShowMsg = false;
            nextMsgRunTime = Time.time + (float) currentMsg.MsgShowTime;
            doStallMsg = true;
            return;
        }

        nextX += amtToAdd;
        Slide(nextX);
        nextMsgRunTime = Time.time + transitionWaitTimePerRun;
    }

    private void StallMsg()
    {
        if (Time.time < nextMsgRunTime)
            return;

        doStallMsg = false;
        doHideMsg = true;
    }

    private void HideMsg()
    {
        if (Time.time < nextMsgRunTime)
            return;

        var amtToSubtract = 6.5f;
        if (img.transform.position.x - amtToSubtract <= -defaultWidth)
        {
            Slide(-defaultWidth);
            MsgCleanup();
        }

        nextX -= amtToSubtract;
        Slide(nextX);
        nextMsgRunTime = Time.time + transitionWaitTimePerRun;
    }

    private void MsgCleanup()
    {
        gameObject.SetActive(false);
        Object.Destroy(gameObject);

        UpdateEvent -= Notification_UpdateEvent;
        NotificationMgr.Notifications.Remove(this);
    }



    public void Slide([Optional] float? x, [Optional] float? y, [Optional] float? z)
    {
        if (x == null && y == null)
            return;

        float testZ = 0;
        if (z != null)
            testZ = z.Value;

        if (x != null && y != null)
            img.transform.position = new Vector3(x.Value, y.Value, img.transform.position.z);
        else if (x != null && y == null)
            img.transform.position = new Vector3(x.Value, img.transform.position.y, img.transform.position.z + testZ);
        else if (x == null && y != null)
            img.transform.position = new Vector3(img.transform.position.x, y.Value, img.transform.position.z);
    }


    public static event EventHandler<NotificationEventArgs> UpdateEvent;

    public void OnUpdate(NotificationEventArgs e)
    {
        UpdateEvent?.Invoke(null, e);
    }

    #region Nested type: NotificationEventArgs

    public class NotificationEventArgs : EventArgs
    {
    }

    #endregion
}

internal static class NotificationMgr
{
    private const int maxMessagesAtOnce = 5;
    public static readonly List<Notification> Notifications = new();
    public static readonly Queue<NkhMsg> NotificationQueue = new();

    public static void AddNotification(NkhMsg msg)
    {
        var globalScene = SceneManager.GetSceneByName("Global");
        if (!globalScene.IsValid())
            return;

        var game = globalScene.GetRootGameObjects()[0].transform.Find("Game");
        if (game is null)
            return;

        //if (InGame.instance == null || notifications.Count >= maxMessagesAtOnce)
        lock (Notifications)
        {
            if (Notifications.Count >= maxMessagesAtOnce)
            {
                NotificationQueue.Enqueue(msg);
                return;
            }
        }

        lock (Notifications)
        {

            var slot = 0;
            for (var i = 0;
                 i < maxMessagesAtOnce;
                 i++) //this terrible looking code gets first availible slot for message. prevents overlapping msgs
            {
                if (Notifications.Exists(item => item.slot == i))
                    continue;

                slot = i;
                break;
            }

            try
            {
                var notification = new Notification(slot, msg);
                Notifications.Add(notification);
            }
            catch (Exception)
            {
                ModHelper.Msg($"{msg.NkhText.Title}");
                ModHelper.Msg($"{msg.NkhText.BodyColor}");
            }
        }
    }


    public static void CheckForNotifications()
    {
        lock (Notifications)
        {
            if (Notifications.Any())
                Notifications[^1].OnUpdate(new Notification.NotificationEventArgs());

            if (NotificationQueue.Any() && Notifications.Count == 0)
            {
                while (Notifications.Count < maxMessagesAtOnce)
                {
                    if (NotificationQueue.Count == 0)
                        break;

                    AddNotification(NotificationQueue.Peek());
                    NotificationQueue.Dequeue();
                }
            }
        }
    }

    internal static void Initialise()
    {
        lock (Notifications)
        {
            Notifications.Clear();
            NotificationQueue.Clear();
        }

        try
        {
            // TOD0 why does this fix things lol
            InGame.instance.GetComponentFromChildrenByName<RectTransform>("BlackBarL").Find("Tiled/Edge")
                .SetAsFirstSibling();
        }
        catch (Exception)
        {
            // ignored
        }
    }
}