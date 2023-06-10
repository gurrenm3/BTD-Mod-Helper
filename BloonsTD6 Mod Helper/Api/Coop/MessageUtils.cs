using System.Text;
using Il2CppNinjaKiwi.NKMulti;
using Il2CppSystem;
using Newtonsoft.Json;
namespace BTD_Mod_Helper.Api.Coop;

/// <summary>
/// Utility functions used for sending messages over the network.
/// </summary>
public class MessageUtils
{
    /// <summary>
    /// Creates a message to be sent over the network.
    /// The message will be serialized as JSON.
    /// </summary>
    /// <param name="objectToSend">The object to be sent. The object's properties will be serialized.</param>
    /// <param name="code">Unique code for your specific message.</param>
    public static Message CreateMessageEx<T>(T objectToSend, string code = "")
    {
        var json = JsonConvert.SerializeObject(objectToSend);
        var serialize = Encoding.Default.GetBytes(json);
        code = string.IsNullOrEmpty(code) ? "BTD6_ModHelper" : code;
        return new Message(code, serialize);
    }

    /// <summary>
    /// Reads a message sent from the network.
    /// Assumes message is sent as JSON. (via <see cref="CreateMessageEx{T}" />)
    /// </summary>
    /// <param name="serializedMessage">Raw bytes received from the network.</param>
    public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage)
    {
        var modMessage = Encoding.Default.GetString(serializedMessage);
        return JsonConvert.DeserializeObject<T>(modMessage);
    }

    /// <summary>
    /// Reads a message sent from the network.
    /// Assumes message is sent as JSON. (via <see cref="CreateMessageEx{T}" />)
    /// </summary>
    /// <param name="message">Message received from the network.</param>
    public static T ReadMessage<T>(Message message) => ReadMessage<T>(message.bytes);

    #region Backwards Binary Compatibility

    /// <summary>
    /// Old way to send a message
    /// </summary>
    /// <param name="objectToSend"></param>
    /// <param name="code"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [System.Obsolete($"For backwards compatibility reasons only, please use {nameof(CreateMessageEx)}")]
    public static Message CreateMessage<T>(T objectToSend, string code = "") where T : Object =>
        CreateMessageEx(objectToSend, code);

    #endregion
}