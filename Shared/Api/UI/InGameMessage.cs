using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.Api;

internal class NkhText
{
    public string title;
    public Color titleColor = Color.white;
    public string body;
    public Color bodyColor = Color.white;
    //public Vector2? BodyPosition;
    //public Vector2? BodySize;
}

internal class NkhMsg
{
    public NkhText nkhText;
    public double msgShowTime = 1.5f;
}

internal class Notification
{
    public readonly GameObject gameObject;

    private readonly AssetBundle assetBundle;
    private readonly GameObject canvas;

    public readonly Image img;
    public readonly Text title;
    public readonly Text body;
    public readonly NkhMsg currentMsg;
    public readonly int slot;
    public Notification(int slot, NkhMsg msg)
    {
        if (assetBundle == null)
            assetBundle = ModContent.GetBundle<MelonMain>("ingame_popup");
        if (canvas == null)
            canvas = assetBundle.LoadAsset("Canvas").Cast<GameObject>();

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

        title.text = currentMsg.nkhText.title;
        title.color = currentMsg.nkhText.titleColor;
        body.text = currentMsg.nkhText.body;
        body.color = currentMsg.nkhText.bodyColor;

        //set pos so elements are positioned correctly
        var windowHeight = Screen.height;
        //ModHelper.Log(windowHeight.ToString());

        var test1 = (windowHeight / 8) * 1.155f;
        //var spaceBetweenSlots = 110 * slot;
        //var spaceBetweenSlots = 135* slot;
        var spaceBetweenSlots = test1 * slot;


        var transform = img.transform;
        var pos = transform.position;
        pos.x = -DefaultWidth;
        pos.y -= spaceBetweenSlots + 55;
        pos.z = 955;       //might get rid of this later. Setting ui to be very high up so it won't get put under other stuff. Game camera is at about 995
        nextX = -DefaultWidth;
        transform.position = pos;


        if (currentMsg.msgShowTime == 0)
            currentMsg.msgShowTime = 1.5;
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

    private bool doShowMsg;
    private bool doStallMsg;
    private bool doHideMsg;
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

    private float nextMsgRunTime;
    private const float TransitionWaitTimePerRun = 0f;
    private float nextX;
    //private readonly int defaultWidth = 345;
    private const int DefaultWidth = 500;
    private const int MaxX = 15;
    private void ShowMsg()
    {
        if (Time.time < nextMsgRunTime)
            return;

        const float amtToAdd = 18.5f;
        if (img.transform.position.x + amtToAdd >= MaxX)
        {
            Slide(MaxX);
            doShowMsg = false;
            nextMsgRunTime = Time.time + (float)currentMsg.msgShowTime;
            doStallMsg = true;
            return;
        }

        nextX += amtToAdd;
        Slide(nextX);
        nextMsgRunTime = Time.time + TransitionWaitTimePerRun;
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

        const float amtToSubtract = 6.5f;
        if (img.transform.position.x - amtToSubtract <= -DefaultWidth)
        {
            Slide(-DefaultWidth);
            MsgCleanup();
        }

        nextX -= amtToSubtract;
        Slide(nextX);
        nextMsgRunTime = Time.time + TransitionWaitTimePerRun;
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
        
        var transform = img.transform;
        if (x != null && y != null)
            transform.position = new Vector3(x.Value, y.Value, transform.position.z);
        else if (x != null && y == null)
            transform.position = new Vector3(x.Value, img.transform.position.y, transform.position.z + testZ);
        else if (x == null && y != null)
            transform.position = new Vector3(img.transform.position.x, y.Value, transform.position.z);
    }


    public static event EventHandler<NotificationEventArgs> UpdateEvent;

    public class NotificationEventArgs : EventArgs { }
    public void OnUpdate(NotificationEventArgs e)
    {
        UpdateEvent?.Invoke(null, e);
    }
}



internal static class NotificationMgr
{
    private const int MaxMessagesAtOnce = 5;
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
            if (Notifications.Count >= MaxMessagesAtOnce)
            {
                NotificationQueue.Enqueue(msg);
                return;
            }
        }

        lock (Notifications)
        {

            var slot = 0;
            for (var i = 0; i < MaxMessagesAtOnce; i++)  //this terrible looking code gets first availible slot for message. prevents overlapping msgs
            {
                var skip = false;
                foreach (var item in Notifications)
                {
                    if (item.slot == i)
                    {
                        skip = true;
                        break;
                    }
                }

                if (skip)
                    continue;

                slot = i;
                break;
            }

            var notification = new Notification(slot, msg);
            Notifications.Add(notification);
        }
    }


    public static void CheckForNotifications()
    {
        lock (Notifications)
        {
            if (Notifications.Count > 0)
                Notifications[^1].OnUpdate(new Notification.NotificationEventArgs());

            if (NotificationQueue.Count > 0 && Notifications.Count == 0)
            {
                while (Notifications.Count < MaxMessagesAtOnce)
                {
                    if (NotificationQueue.Count == 0)
                        break;

                    AddNotification(NotificationQueue.Peek());
                    NotificationQueue.Dequeue();
                }
            }
        }
    }
}