using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Class for serializing and deserializing JSON files
/// </summary>
public class JsonSerializer
{
    /// <summary>
    /// Singleton instance for this class
    /// </summary>
    public static JsonSerializer instance = new();

    /// <summary>
    /// Serialize a il2cpp object
    /// </summary>
    public string Il2CppSerializeJson<T>(T il2cppObject, bool shouldIndent = true) where T : Object
    {
        return JsonUtility.ToJson(il2cppObject, shouldIndent);
    }

    /// <summary>
    /// Serialize a non-il2cpp object
    /// </summary>
    public string SerializeJson<T>(T objectToSerialize, bool shouldIndent = true, bool ignoreNulls = false)
    {
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = ignoreNulls ? NullValueHandling.Ignore : NullValueHandling.Include
        };
        return SerializeJson(objectToSerialize, settings, shouldIndent);
    }

    /// <summary>
    /// Serialize a non-il2cpp object
    /// </summary>
    public string SerializeJson<T>(T objectToSerialize, JsonSerializerSettings serializerSettings,
        bool shouldIndent = true)
    {
        var formatting = shouldIndent ? Formatting.Indented : Formatting.None;
        return JsonConvert.SerializeObject(objectToSerialize, formatting, serializerSettings);
    }


    /// <summary>
    /// Deserialize an Il2cpp object
    /// </summary>
    public T Il2CppDeserializeJson<T>(string text)
    {
        return JsonUtility.FromJson<T>(text);
    }

    /// <summary>
    /// Deserialize a non-Il2cpp object
    /// </summary>
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
        var json = ReadTextFromFile(filePath);
        return string.IsNullOrEmpty(json) ? null : DeserializeJson<T>(json);
    }

    /// <summary>
    /// Create an instance of an il2cpp class from file
    /// </summary>
    /// <typeparam name="T">The type to load</typeparam>
    /// <param name="filePath">Location of the file</param>
    public T Il2CppLoadFromFile<T>(string filePath) where T : class
    {
        var json = ReadTextFromFile(filePath);
        return string.IsNullOrEmpty(json) ? null : Il2CppDeserializeJson<T>(json);
    }

    private string ReadTextFromFile(string filePath)
    {
        if (!IsPathValid(filePath))
            return null;

        var text = File.ReadAllText(filePath);
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
    /// <param name="ignoreNulls">Whether nulls should be ignored</param>
    /// <param name="overwriteExisting">Overwrite the file if it already exists</param>
    /// <param name="shouldIndent">Whether it should be indented</param>
    public void SaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = true, bool ignoreNulls = false
        , bool overwriteExisting = true)
    {
        Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
        CreateDirIfNotFound(savePath);

        var keepOriginal = !overwriteExisting;
        var serialize = new StreamWriter(savePath, keepOriginal);

        var json = SerializeJson(jsonObject, shouldIndent, ignoreNulls);
        serialize.Write(json);
        serialize.Close();
    }

    /// <inheritdoc cref="SaveToFile{T}(T,string,bool,bool,bool)" />
    public void SaveToFile<T>(T jsonObject, string savePath, JsonSerializerSettings serializerSettings
        , bool shouldIndent = true, bool overwriteExisting = true)
    {
        Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
        CreateDirIfNotFound(savePath);

        var keepOriginal = !overwriteExisting;
        var serialize = new StreamWriter(savePath, keepOriginal);

        var json = SerializeJson(jsonObject, serializerSettings, shouldIndent);
        serialize.Write(json);
        serialize.Close();
    }


    /// <inheritdoc cref="SaveToFile{T}(T,string,bool,bool,bool)" />
    public void Il2CppSaveToFile<T>(T jsonObject, string savePath, bool shouldIndent = true,
        bool overwriteExisting = true)
        where T : Object
    {
        Guard.ThrowIfStringIsNull(savePath, "Can't save file, save path is null");
        CreateDirIfNotFound(savePath);

        var keepOriginal = !overwriteExisting;
        var serialize = new StreamWriter(savePath, keepOriginal);

        var json = Il2CppSerializeJson(jsonObject, shouldIndent);
        serialize.Write(json);
        serialize.Close();
    }


    private void CreateDirIfNotFound(string dir)
    {
        var f = new FileInfo(dir);
        if (f.Directory != null)
        {
            Directory.CreateDirectory(f.Directory.FullName);
        }
    }
}