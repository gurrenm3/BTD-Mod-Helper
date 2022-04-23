using System;
using System.Linq;
using System.Reflection;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Assemblies
/// </summary>
public static class AssemblyExt
{
    /// <summary>
    /// Gets the bytes for an embedded resource with the given name (found with endsWith), or null if no matches
    /// </summary>
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

    /// <inheritdoc cref="GetEmbeddedResource"/>
    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out byte[] bytes)
    {
        var result = GetEmbeddedResource(assembly, endsWith);
        bytes = result ?? Array.Empty<byte>();
        return result != null;
    }
}