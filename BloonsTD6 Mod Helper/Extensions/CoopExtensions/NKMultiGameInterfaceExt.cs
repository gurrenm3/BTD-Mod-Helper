using Assets.Scripts.Unity;
using BTD_Mod_Helper.Api.Coop;
using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Extensions
{
    public static class NKMultiGameInterfaceExt
    {
        /// <summary>
        /// Send a Message to all players in the lobby
        /// </summary>
        /// <param name="message">Message to send</param>
        public static void SendMessage(this NKMultiGameInterface nkGI, Message message)
        {
            nkGI.relayConnection.Writer.Write(message);
        }

        /// <summary>
        /// Convert an object to json and send it players or a player in the lobby
        /// </summary>
        /// <param name="objectToSend">Object you want to send</param>
        /// <param name="peerId">The id of the peer you want the message to go to. Leave null if you want to send to all players</param>
        /// <param name="code">Coop code used to distinguish this message from others. Like a lock and key for reading messages</param>
        public static void SendMessage<T>(this NKMultiGameInterface nkGI, T objectToSend, byte? peerId = null, string code = "") where T : Il2CppSystem.Object
        {
            var message = MessageUtils.CreateMessage(objectToSend, code);

            var str = Il2CppSystem.Text.Encoding.Default.GetString(message.bytes);
            MelonLoader.MelonLogger.Msg($"str: {str}");

            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }

        /// <summary>
        /// Send a string to players or a player in the lobby
        /// </summary>
        /// <param name="objectToSend">string message to send. Can be JSON</param>
        /// <param name="peerId">The id of the peer you want the message to go to. Leave null if you want to send to all players</param>
        /// <param name="code">Coop code used to distinguish this message from others. Like a lock and key for reading messages</param>
        public static void SendMessage(this NKMultiGameInterface nkGI, Il2CppSystem.String objectToSend, byte? peerId = null, string code = "")
        {
            var message = MessageUtils.CreateMessage(objectToSend, code);

            var str = Il2CppSystem.Text.Encoding.Default.GetString(message.bytes);
            MelonLoader.MelonLogger.Msg($"str: {str}");

            if (peerId.HasValue && peerId != null)
                nkGI.SendToPeer(peerId.Value, message);
            else
                nkGI.relayConnection.Writer.Write(message);
        }

        /// <summary>
        /// Convert messageBytes to an object of type T
        /// </summary>
        /// <typeparam name="T">Type to convert bytes to</typeparam>
        /// <param name="messageBytes">messageBytes</param>
        public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Il2CppStructArray<byte> messageBytes)
        {
            return MessageUtils.ReadMessage<T>(messageBytes);
        }

        /// <summary>
        /// Convert a Message's bytes to an object of type T
        /// </summary>
        /// <typeparam name="T">Type to convert bytes to</typeparam>
        /// <param name="message">Message you want to read</param>
        public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Message message)
        {
            return MessageUtils.ReadMessage<T>(message.GetBytes());
        }

        /// <summary>
        /// Used to read messages from BTD6 InGameChat Mod. If Message is a ChatMessage, will be converted to a Chat_Message object
        /// </summary>
        /// <param name="message"></param>
        public static Chat_Message ReadChatMessage(this NKMultiGameInterface nkGI, Message message)
        {
            if (message.Code != Chat_Message.chatCoopCode)
                return null;
            string json = nkGI.ReadMessage<string>(message.bytes);
            var deserialized = Game.instance.GetJsonSerializer().DeserializeJson<Chat_Message>(json);
            return deserialized;
        }
    }
}