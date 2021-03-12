using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace BTD_Mod_Helper.Api
{
    public class JsonSerializer
    {
        public string Il2CppSerializeJson<T>(T il2cppObject, bool shouldIndent = false) where T : Il2CppSystem.Object
        {
            return JsonUtility.ToJson(il2cppObject, shouldIndent);
        }

        public string SerializeJson<T>(T objectToSerialize, bool shouldIndent = false, bool ignoreNulls = false)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = ignoreNulls ? NullValueHandling.Ignore : NullValueHandling.Include
            };
            return SerializeJson(objectToSerialize, settings, shouldIndent: shouldIndent);
        }

        public string SerializeJson<T>(T objectToSerialize, JsonSerializerSettings serializerSettings, bool shouldIndent = false)
        {
            Formatting formatting = shouldIndent ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(objectToSerialize, formatting, serializerSettings);
        }




        public T Il2CppDeserializeJson<T>(string text)
        {
            return JsonUtility.FromJson<T>(text);
        }

        public T DeserializeJson<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }




        /// <summary>
        /// Create an instance of a class from file
        /// </summary>
        /// <typeparam name="T">The type to load</typeparam>
        /// <param name="filePath">Location of the file</param>
        public T LoadFromFile<T>(string filePath) where T : class
        {
            string json = ReadTextFromFile(filePath);
            return (string.IsNullOrEmpty(json)) ? null : DeserializeJson<T>(json);
        }

        public T Il2CppLoadFromFile<T>(string filePath) where T : class
        {
            string json = ReadTextFromFile(filePath);
            return (string.IsNullOrEmpty(json)) ? null : Il2CppDeserializeJson<T>(json);
        }

        private string ReadTextFromFile(string filePath)
        {
            if (!IsPathValid(filePath))
                return null;

            string text = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(text))
                return null;

            return text;
        }

        private bool IsPathValid(string filePath)
        {
            Guard.ThrowIfStringIsNull(filePath, "Can't load file, path is null");
            return File.Exists(filePath);
        }




        /// <summary>
        /// Save an instance of a class to file
        /// </summary>
        /// <typeparam name="T">Type of class to save</typeparam>
        /// <param name="jsonObject">Object to save. Must be of Type T</param>
        /// <param name="savePath">Location to save file to</param>
        /// <param name="overwriteExisting">Overwrite the file if it already exists</param>
        public void SaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = false, bool ignoreNulls = false, bool overwriteExisting = true)
        {
            Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
            CreateDirIfNotFound(savePath);

            bool keepOriginal = !overwriteExisting;
            StreamWriter serialize = new StreamWriter(savePath, keepOriginal);

            string json = SerializeJson(jsonObject, shouldIndent, ignoreNulls);
            serialize.Write(json);
            serialize.Close();
        }

        public void SaveToFile<T>(T jsonObject, string savePath, JsonSerializerSettings serializerSettings
            , bool shouldIndent = false, bool overwriteExisting = true)
        {
            Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
            CreateDirIfNotFound(savePath);

            bool keepOriginal = !overwriteExisting;
            StreamWriter serialize = new StreamWriter(savePath, keepOriginal);

            string json = SerializeJson(jsonObject, serializerSettings, shouldIndent);
            serialize.Write(json);
            serialize.Close();
        }



        public void Il2CppSaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = false, bool overwriteExisting = true)
            where T : Il2CppSystem.Object
        {
            Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
            CreateDirIfNotFound(savePath);

            bool keepOriginal = !overwriteExisting;
            StreamWriter serialize = new StreamWriter(savePath, keepOriginal);

            string json = Il2CppSerializeJson(jsonObject, shouldIndent);
            serialize.Write(json);
            serialize.Close();
        }


        private void CreateDirIfNotFound(string dir)
        {
            FileInfo f = new FileInfo(dir);
            Directory.CreateDirectory(f.Directory.FullName);
        }
    }
}