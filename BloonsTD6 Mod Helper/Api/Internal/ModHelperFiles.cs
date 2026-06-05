#if !RELEASELITE
using System;
using System.IO;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;

namespace BTD_Mod_Helper.Api.Internal;

internal static class ModHelperFiles
{
    public static void CreateSourcesFiles(string path)
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

        foreach (var file in new[] {"btd6.targets", "launchSettings.json"})
        {
            using var stream = ModHelper.MainAssembly.GetEmbeddedResource(file);
            if (stream == null) continue;
            using var fileStream = File.Create(Path.Combine(path, file));
            stream.CopyTo(fileStream);
        }
    }

    private static bool downloaded;

    internal static void DownloadDocumentationXml(Action onComplete = null)
    {
        if (downloaded || Environment.GetCommandLineArgs().Contains("--modhelper.offline")) return;

        const string url =
            $"https://github.com/{ModHelper.RepoOwner}/{ModHelper.RepoName}/releases/download/{ModHelper.Version}/{ModHelper.XmlName}";
        Task.Run(async () =>
        {
            try
            {
                if (await ModHelperHttp.DownloadFile(url, Path.Combine(MelonEnvironment.ModsDirectory, ModHelper.XmlName)))
                {
                    downloaded = true;
                    ModHelper.Msg($"Downloaded {ModHelper.XmlName} for v{ModHelper.Version}");
                    onComplete?.Invoke();
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        });
    }
}
#endif