using BTD_Mod_Helper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api
{
    internal class NkhText
    {
        public string Title;
        public Color TitleColor = Color.white;
        public string Body;
        public Color BodyColor = Color.white;
        //public Vector2? BodyPosition;
        //public Vector2? BodySize;
    }

    internal class NkhMsg
    {
        public NkhText NkhText;
        public double MsgShowTime = 1.5f;
    }

    internal class Notification
    {
        public GameObject gameObject;

        private static AssetBundle assetBundle;
        private static GameObject canvas;

        public Image img;
        public Text title;
        public Text body;
        public NkhMsg currentMsg;
        public int slot;
        public Notification(int slot, NkhMsg msg)
        {
            if (assetBundle == null)
                assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.ingame_popup);
            if (canvas == null)
                canvas = assetBundle.LoadAsset("Canvas").Cast<GameObject>();

            this.slot = slot;
            //======
            // Initialize game object stuff
            //======

            Scene popups = SceneManager.GetSceneByName("Popups");
            Scene mainMenuWorld = SceneManager.GetSceneByName("MainMenuWorld");
            Scene globalScene = SceneManager.GetSceneByName("Global");
            Scene commonForeground = SceneManager.GetSceneByName("CommonForegroundUI");
            Scene mainMenuUI = SceneManager.GetSceneByName("MainMenuUi");


            /*img = canvas.transform.Find("Image").GetComponent<Image>();
            title = canvas.transform.Find("Image/Title").GetComponent<Text>();
            body = canvas.transform.Find("Image/Body").GetComponent<Text>();
           
            gameObject = GameObject.Instantiate(img.gameObject, mainMenuUI.GetRootGameObjects()[0].transform);*/



            gameObject = GameObject.Instantiate(canvas, globalScene.GetRootGameObjects()[0].transform);

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
            int windowHeight = Screen.height;
            //MelonLogger.Log(windowHeight.ToString());

            float test1 = (windowHeight / 8) * 1.155f;
            //var spaceBetweenSlots = 110 * slot;
            //var spaceBetweenSlots = 135* slot;
            float spaceBetweenSlots = test1 * slot;


            Vector3 pos = img.transform.position;
            pos.x = -defaultWidth;
            pos.y -= spaceBetweenSlots + 55;
            pos.z = 955;       //might get rid of this later. Setting ui to be very high up so it won't get put under other stuff. Game camera is at about 995
            nextX = -defaultWidth;
            img.transform.position = pos;


            if (currentMsg.MsgShowTime == 0)
                currentMsg.MsgShowTime = 1.5;
            //prepping final variables for smooth transitions
            msgIsAlive = true;
            doShowMsg = true;
            doStallMsg = false;
            doHideMsg = false;

            UpdateEvent += Notification_UpdateEvent;
        }

        private void Notification_UpdateEvent(object sender, NotificationEventArgs e)
        {
            Update();
        }

        public bool msgIsAlive = true;
        private bool doShowMsg = false;
        private bool doStallMsg = false;
        private bool doHideMsg = false;
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

        private float nextMsgRunTime = 0f;
        private readonly float transitionWaitTimePerRun = 0f;
        private float nextX = 0;
        //private readonly int defaultWidth = 345;
        private readonly int defaultWidth = 500;
        private readonly int maxX = 15;
        private void ShowMsg()
        {
            if (Time.time < nextMsgRunTime)
                return;

            float amtToAdd = 18.5f;
            if ((img.transform.position.x + amtToAdd) >= maxX)
            {
                Slide(maxX);
                doShowMsg = false;
                nextMsgRunTime = Time.time + (float)currentMsg.MsgShowTime;
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

            float amtToSubtract = 6.5f;
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
            GameObject.Destroy(gameObject);

            UpdateEvent -= Notification_UpdateEvent;
            NotificationMgr.notifications.Remove(this);
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
        public class NotificationEventArgs : EventArgs { }
        public void OnUpdate(NotificationEventArgs e)
        {
            UpdateEvent?.Invoke(this, e);
        }
    }



    internal static class NotificationMgr
    {
        private static readonly int maxMessagesAtOnce = 5;
        public static List<Notification> notifications = new List<Notification>();
        public static Queue<NkhMsg> notificationQueue = new Queue<NkhMsg>();
        public static void AddNotification(NkhMsg msg)
        {
            Scene globalScene = SceneManager.GetSceneByName("Global");
            if (!globalScene.IsValid())
                return;

            Transform game = globalScene.GetRootGameObjects()[0].transform.Find("Game");
            if (game is null)
                return;

            //if (InGame.instance == null || notifications.Count >= maxMessagesAtOnce)
            if (notifications.Count >= maxMessagesAtOnce)
            {
                notificationQueue.Enqueue(msg);
                return;
            }

            lock (notifications)
            {

                int slot = 0;
                for (int i = 0; i < maxMessagesAtOnce; i++)  //this terrible looking code gets first availible slot for message. prevents overlapping msgs
                {
                    bool skip = false;
                    foreach (Notification item in notifications)
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

                Notification notification = new Notification(slot, msg);
                notifications.Add(notification);
            }
        }


        public static void CheckForNotifications()
        {
            lock (notifications)
            {
                if (notifications.Any())
                    notifications[notifications.Count - 1].OnUpdate(new Notification.NotificationEventArgs());

                if (notificationQueue.Any() && notifications.Count == 0)
                {
                    while (notifications.Count < maxMessagesAtOnce)
                    {
                        if (notificationQueue.Count == 0)
                            break;

                        AddNotification(notificationQueue.Peek());
                        notificationQueue.Dequeue();
                    }
                }
            }
        }
    }
}
