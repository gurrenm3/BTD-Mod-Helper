using Il2CppNewtonsoft.Json;
using Il2CppSystem.IO;
using UnityEngine;
using Directory = System.IO.Directory;
using File = System.IO.File;
using Path = System.IO.Path;
using Object = Il2CppSystem.Object;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Class replacing the original functionality of FileIOUtil before BTD6 update 33.0
/// </summary>
public static class FileIOHelper
{
    /// <summary>
    /// Same as the original FileIOUtil.sandboxRoot, INCLUDES A SLASH AT THE END
    /// </summary>
    public static string sandboxRoot => Application.persistentDataPath + "/";

    /// <summary>
    /// Same as the original FileIOUtil.GetSandboxPath(), INCLUDES A SLASH AT THE END
    /// </summary>
    public static string GetSandboxPath() => sandboxRoot;

    /// <summary>
    /// Saves an il2cpp object directly to the sandbox path like the original FileIOUtil.SaveObject
    /// <br/>
    /// Will also create subdirectories as needed to save the file
    /// </summary>
    /// <param name="fileName">Name of file, extension included</param>
    /// <param name="data"></param>
    public static void SaveObject(string fileName, Object data)
    {
        var text = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        SaveFile(fileName, text);
    }

    /// <summary>
    /// Same as the original FileIOUtil.LoadObject
    /// </summary>
    /// <param name="fileName">File name within the sandbox directory</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T LoadObject<T>(string fileName) where T : Object
    {
        var text = LoadFile(fileName);

        // return JsonConvert.DeserializeObject<T>(text);
        
        var jsonSerializer = Il2CppNewtonsoft.Json.JsonSerializer.CreateDefault(new JsonSerializerSettings());
        var s = new StringReader(text);
        var reader = new JsonTextReader(s);
        var result = jsonSerializer.Deserialize<T>(reader);
        s.Close();
        reader.Close();
        
        return result;
    }

    /// <summary>
    /// Same as the original FileIOUtil.SaveFile
    /// </summary>
    /// <param name="fileName">File name within the sandbox directory</param>
    /// <param name="text">Text file contents to save</param>
    public static void SaveFile(string fileName, string text)
    {
        var path = Path.Combine(sandboxRoot, fileName);
        var directory = Path.GetDirectoryName(path)!;
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        File.WriteAllText(path, text);
    }

    /// <summary>
    /// Same as the original FileIOUtil.LoadFile
    /// </summary>
    /// <param name="fileName">File name within the sandbox directory</param>
    /// <returns></returns>
    public static string LoadFile(string fileName)
    {
        var path = Path.Combine(sandboxRoot, fileName);
        return File.Exists(path) ? File.ReadAllText(path) : null;
    }

}