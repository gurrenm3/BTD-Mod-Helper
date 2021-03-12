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
            string json = SerialisationUtil.Deserialise<string>(messageBytes);
            Chat_Message message = Read(json);
            PeerID = message.PeerID;
            Sender = message.Sender;
            Message = message.Message;
            IsPrivateMessage = message.IsPrivateMessage;
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