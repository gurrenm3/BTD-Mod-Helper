using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json.Linq;
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
        var resource = Array.Find(assembly.GetManifestResourceNames(), s => s.EndsWith(endsWith));
        return resource != null ? assembly.GetManifestResourceStream(resource) : null;
    }

    /// <inheritdoc cref="GetEmbeddedResource" />
    public static bool TryGetEmbeddedResource(this Assembly assembly, string endsWith, out Stream stream)
    {
        stream = GetEmbeddedResource(assembly, endsWith);
        return stream != null;
    }

    /// <summary>
    /// Gets the contents of an embedded file in this assembly as plain text (UTF8)
    /// </summary>
    public static string GetEmbeddedText(this Assembly assembly, string endsWith)
    {
        using var stream = GetEmbeddedResource(assembly, endsWith);
        using var reader = new StreamReader(stream, Encoding.UTF8);

        return reader.ReadToEnd();
    }

    /// <summary>
    /// Gets the contents of an embedded file in this assembly as json object
    /// </summary>
    public static JObject GetEmbeddedJson(this Assembly assembly, string endsWith)
    {
        return JObject.Parse(assembly.GetEmbeddedText(endsWith));
    }
}