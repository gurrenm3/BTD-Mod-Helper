using System;
using System.IO;
using MelonLoader.Utils;
namespace BTD_Mod_Helper.Api.Helpers;

internal static class ModHelperFiles
{
    public static void CreateTargetsFile(string path)
    {
        if (!Directory.Exists(path))
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception)
            {
                return;
            }
        }

        var targets = Path.Combine(path, "btd6.targets");
        using var fs = new StreamWriter(targets);
        using var stream =
            ModHelper.MainAssembly.GetManifestResourceStream("BTD_Mod_Helper.btd6.targets");
        using var reader = new StreamReader(stream!);
        var text = reader.ReadToEnd().Replace(
            @"C:\Program Files (x86)\Steam\steamapps\common\BloonsTD6",
            MelonEnvironment.GameRootDirectory);
        fs.Write(text);
    }
}