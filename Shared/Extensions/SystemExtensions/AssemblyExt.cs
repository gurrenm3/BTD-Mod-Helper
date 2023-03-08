using System.IO;
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
    public static Stream GetEmbeddedResource(this Assembly assembly, string endsWith)
    {
        var resource = assembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(endsWith));
        return resource != null ? assembly.GetManifestResourceStream(resource) : null;
    }

    /// <inheritdoc cref="GetEmbeddedResource"/>
    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out Stream stream)
    {
        stream = GetEmbeddedResource(assembly, endsWith);
        return stream != null;
    }
}