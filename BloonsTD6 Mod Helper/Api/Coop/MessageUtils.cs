using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Coop
{
    public class MessageUtils
    {
        public static Message CreateMessage<T>(T objectToSend, string code = "") where T : Il2CppSystem.Object
        {
            Il2CppStructArray<byte> serialize = SerialisationUtil.Serialise(objectToSend);

            code = string.IsNullOrEmpty(code) ? MelonMain.coopMessageCode : code;
            return new Message(code, serialize);
        }

        public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage)
        {
            return SerialisationUtil.Deserialise<T>(serializedMessage);
        }
        
        public static T ReadMessage<T>(Message message)
        {
            return ReadMessage<T>(message.bytes);
        }
    }
}