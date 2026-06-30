using System;
using System.IO;
using MelonLoader.Utils;
#if !RELEASELITE
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
#endif

namespace BTD_Mod_Helper.Api.Internal;

internal static class ModHelperFiles
{
    public static void CreateSourcesFiles(string path)
    {
        if (!Directory.Exists(path)) return;

        foreach (var file in new[] {"btd6.targets", "launchSettings.json"})
        {
            var text = ModHelper.MainAssembly.GetEmbeddedText(file)
                .Replace(@"C:\Program Files (x86)\Steam\steamapps\common\BloonsTD6", MelonEnvironment.MelonBaseDirectory);
            File.WriteAllText(Path.Combine(path, file), text);
        }
    }

#if !RELEASELITE
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
#endif
}