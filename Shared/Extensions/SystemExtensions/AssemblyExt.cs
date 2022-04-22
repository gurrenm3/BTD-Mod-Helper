using System;
using System.Linq;
using System.Reflection;

namespace BTD_Mod_Helper.Extensions;

public static class AssemblyExt
{
    public static byte[]? GetEmbeddedResource(this Assembly assembly, string endsWith)
    {
        var resource = assembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith("nfd.dll"));
        if (resource != null)
        {
            using var stream = assembly.GetManifestResourceStream(resource);
            if (stream != null)
            {
                return stream.GetByteArray();
            }
        }

        return null;
    }

    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out byte[] bytes)
    {
        var result = GetEmbeddedResource(assembly, endsWith);
        bytes = result ?? Array.Empty<byte>();
        return result != null;
    }
}