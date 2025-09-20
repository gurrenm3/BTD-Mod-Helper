using System;
using System.IO;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;

namespace BTD_Mod_Helper.Api.Internal;

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

    internal static void DownloadDocumentationXml()
    {
        const string url =
            $"https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/releases/download/{ModHelper.Version}/{ModHelper.XmlName}";
        Task.Run(async () =>
        {
            try
            {
                if (await ModHelperHttp.DownloadFile(url, Path.Combine(MelonEnvironment.ModsDirectory, ModHelper.XmlName)))
                {
                    ModHelper.Msg($"Downloaded {ModHelper.XmlName} for v{ModHelper.Version}");
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        });
    }
}