using BTD_Mod_Helper.Api.Coop;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.NKMulti;
using Il2CppSystem;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for sending and receiving data in coop
/// </summary>
public static class NKMultiGameInterfaceExt
{
    /// <summary>
    /// Returns true if the player is a host in a co-op game.
    /// Works for both lobby and in-game.
    /// </summary>
    public static bool IsCoOpHost(this NKMultiGameInterface nkGi)
    {
        var inGame = InGame.instance;
        var game = Game.instance;

        // Check lobby first.
        // ReSharper disable once Unity.NoNullPropagation
        var connection = game?.GetCoopLobbyConnection();
        if (connection != null)
            return connection.IsAuthority;

        // Then check game.
        if (inGame == null || !inGame.IsCoOpReady())
            return nkGi.PeerID == 1; // The game does this! for lobby etc. Checked in IDA.

        return inGame.coopGame.IsAuthority();
    }

    /// <summary>
    /// Send a Message to all players in the lobby
    /// </summary>
    /// <param name="nkGI"></param>
    /// <param name="message">Message to send</param>
    public static void SendMessage(this NKMultiGameInterface nkGI, Message message)
    {
        nkGI.relayConnection.Writer.Write(message);
    }

    /// <summary>
    /// Convert an object to json and send it players or a player in the lobby
    /// </summary>
    /// <param name="nkGI"></param>
    /// <param name="objectToSend">Object you want to send. The properties of the object will be serialised as JSON.</param>
    /// <param name="peerId">The id of the peer you want the message to go to. Leave null if you want to send to all players</param>
    /// <param name="code">Coop code used to distinguish this message from others. Like a lock and key for reading messages</param>
    public static void SendMessageEx<T>(this NKMultiGameInterface nkGI, T objectToSend, byte? peerId = null,
        string code = "")
    {
        var message = MessageUtils.CreateMessageEx(objectToSend, code);
        if (peerId.HasValue)
            nkGI.SendToPeer(peerId.Value, message);
        else
            nkGI.relayConnection.Writer.Write(message);
    }

    /// <summary>
    /// Send a string to players or a player in the lobby
    /// </summary>
    /// <param name="nkGI"></param>
    /// <param name="objectToSend">string message to send. Can be JSON</param>
    /// <param name="peerId">The id of the peer you want the message to go to. Leave null if you want to send to all players</param>
    /// <param name="code">Coop code used to distinguish this message from others. Like a lock and key for reading messages</param>
    public static void SendMessage(this NKMultiGameInterface nkGI, String objectToSend, byte? peerId = null,
        string code = "")
    {
        var message = MessageUtils.CreateMessageEx(objectToSend, code);
        if (peerId.HasValue)
            nkGI.SendToPeer(peerId.Value, message);
        else
            nkGI.relayConnection.Writer.Write(message);
    }

    /// <summary>
    /// Convert messageBytes to an object of type T
    /// </summary>
    /// <typeparam name="T">Type to convert bytes to</typeparam>
    /// <param name="nkGI"></param>
    /// <param name="messageBytes">messageBytes</param>
    public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Il2CppStructArray<byte> messageBytes) =>
        MessageUtils.ReadMessage<T>(messageBytes);

    /// <summary>
    /// Convert a Message's bytes to an object of type T
    /// </summary>
    /// <typeparam name="T">Type to convert bytes to</typeparam>
    /// <param name="nkGI"></param>
    /// <param name="message">Message you want to read</param>
    public static T ReadMessage<T>(this NKMultiGameInterface nkGI, Message message) =>
        MessageUtils.ReadMessage<T>(message.GetBytes());

    /*/// <summary>
    /// Used to read messages from BTD6 InGameChat Mod. If Message is a ChatMessage, will be converted to a Chat_Message object
    /// </summary>
    /// <param name="message"></param>
    public static Chat_Message ReadChatMessage(this NKMultiGameInterface nkGI, Message message)
    {
        if (message.Code != Chat_Message.chatCoopCode)
            return null;

        string json = nkGI.ReadMessage<string>(message.bytes);
        Chat_Message deserialized = Game.instance.GetJsonSerializer().DeserializeJson<Chat_Message>(json);
        return deserialized;
    }*/

    #region Backwards Binary Compatibility

    /// <summary>
    /// Convert an object to json and send it players or a player in the lobby
    /// </summary>
    /// <param name="nkGI"></param>
    /// <param name="objectToSend">Object you want to send. The properties of the object will be serialised as JSON.</param>
    /// <param name="peerId">The id of the peer you want the message to go to. Leave null if you want to send to all players</param>
    /// <param name="code">Coop code used to distinguish this message from others. Like a lock and key for reading messages</param>
    [System.Obsolete($"For backwards compatibility reasons only, please use {nameof(SendMessageEx)}")]
    public static void SendMessage<T>(this NKMultiGameInterface nkGI, T objectToSend, byte? peerId = null,
        string code = "") where T : Object
    {
        SendMessageEx(nkGI, objectToSend, peerId, code);
    }

    #endregion
}