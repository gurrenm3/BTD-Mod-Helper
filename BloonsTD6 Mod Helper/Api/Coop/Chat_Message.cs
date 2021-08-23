using Newtonsoft.Json;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Coop
{
    public class Chat_Message
    {
        public const string chatCoopCode = "CHAT";
        public int PeerID { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public bool IsPrivateMessage { get; set; } = false;

        public Chat_Message() { }

        public Chat_Message(Il2CppStructArray<byte> messageBytes)
        {
            var json = Il2CppSystem.Text.Encoding.Default.GetString(messageBytes);
            Chat_Message message = Read(json);
            PeerID = message.PeerID;
            Sender = message.Sender;
            Message = message.Message;
            IsPrivateMessage = message.IsPrivateMessage;

            //throw new System.Exception("This code was broken in BTD6 update 27.0");
            // commented code below broke in update 27.0
            //string json = SerialisationUtil.Deserialise<string>(messageBytes);

            // this code is commented because code above is broken
            /*Chat_Message message = Read(json);
            PeerID = message.PeerID;
            Sender = message.Sender;
            Message = message.Message;
            IsPrivateMessage = message.IsPrivateMessage;*/
        }

        public Chat_Message Read(string json)
        {
            return JsonConvert.DeserializeObject<Chat_Message>(json);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}