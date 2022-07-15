using System.IO;

namespace BTD_Mod_Helper.Api.Helpers;

internal static class FileDialogHelper
{
    private static readonly string[] Dlls = {"nfd.dll", "nfd_x86.dll"};

    public static void PrepareNativeDlls()
    {
        foreach (var dll in Dlls)
        {
            var nfd = Path.Combine(MelonUtils.GameDirectory, dll);
            if (!File.Exists(nfd) && ModHelper.MainAssembly.TryGetEmbeddedResource(dll, out var stream))
            {
                using (stream)
                {
                    File.WriteAllBytes(nfd, stream.GetByteArray()!);
                }
            }
        }
    }
}