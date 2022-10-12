using System.IO;
using Il2CppNewtonsoft.Json;
using UnityEngine;
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
    public static void SaveObject(string fileName, Il2CppSystem.Object data)
    {
        var path = Path.Combine(sandboxRoot, fileName);
        var directory = Path.GetDirectoryName(path)!;
        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        var text = JsonConvert.SerializeObject(data, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented
        });

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

    /// <summary>
    /// Same as the original FileIOUtil.LoadObject
    /// </summary>
    /// <param name="fileName">File name within the sandbox directory</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T LoadObject<T>(string fileName) where T : Il2CppSystem.Object
    {
        var text = LoadFile(fileName);
        return JsonConvert.DeserializeObject<T>(text);
    }
}