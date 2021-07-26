using NinjaKiwi.NKMulti;
using UnhollowerBaseLib;

namespace BTD_Mod_Helper.Api.Coop
{
    public class MessageUtils
    {
        public static Message CreateMessage<T>(T objectToSend, string code = "") where T : Il2CppSystem.Object
        {
            throw new System.Exception("This code was broken in BTD6 update 27.0");
            // commented code below broke in update 27.0
            //Il2CppStructArray<byte> serialize = SerialisationUtil.Serialise(objectToSend);

            // this code is commented because code above is broken
            /*code = string.IsNullOrEmpty(code) ? MelonMain.coopMessageCode : code;
            return new Message(code, serialize);*/
        }

        public static T ReadMessage<T>(Il2CppStructArray<byte> serializedMessage)
        {
            throw new System.Exception("This code was broken in BTD6 update 27.0");
            // commented code below broke in update 27.0
            //return SerialisationUtil.Deserialise<T>(serializedMessage);
        }

        public static T ReadMessage<T>(Message message)
        {
            throw new System.Exception("This code was broken in BTD6 update 27.0");
            // commented code below broke in update 27.0
            //return ReadMessage<T>(message.bytes);
        }
    }
}