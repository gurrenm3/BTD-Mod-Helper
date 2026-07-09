using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BTD_Mod_Helper.MSBuildTasks;

/// <summary>
/// Compresses files into zip archives for smaller embedded resource sizes
/// </summary>
public sealed class ZipEmbeddedResourcesTask : Task
{
    [Required]
    public ITaskItem[] SourceFiles { get; set; } = [];

    [Required]
    public string IntermediateOutputPath { get; set; } = string.Empty;

    [Required]
    public string MSBuildProjectDirectory { get; set; } = string.Empty;

    [Output]
    public ITaskItem[] OutputFiles { get; set; } = [];

    public override bool Execute()
    {
        try
        {
            var outputRoot = GetFullPath(IntermediateOutputPath, MSBuildProjectDirectory);
            var outputFiles = new List<ITaskItem>();
            var groupedSourceFiles = SourceFiles
                .Where(sourceFile => !string.IsNullOrWhiteSpace(sourceFile.GetMetadata("Name")))
                .GroupBy(sourceFile => GetZipPath(sourceFile.GetMetadata("Name")), StringComparer.OrdinalIgnoreCase);

            foreach (var sourceFile in SourceFiles.Where(sourceFile => string.IsNullOrWhiteSpace(sourceFile.GetMetadata("Name"))))
            {
                var sourcePath = GetFullPath(sourceFile);

                if (!File.Exists(sourcePath))
                {
                    Log.LogError($"ZipEmbeddedResources source file does not exist: {sourcePath}");
                    return false;
                }

                var relativePath = GetResourcePath(sourceFile);
                var outputPath = Path.Combine(outputRoot, "ZipEmbeddedResources", relativePath + ".zip");
                CreateZip(outputPath, [(sourcePath, ToZipEntryName(relativePath))]);

                var outputItem = new TaskItem(outputPath);
                foreach (DictionaryEntry metadata in sourceFile.CloneCustomMetadata())
                {
                    outputItem.SetMetadata((string) metadata.Key, (string) metadata.Value);
                }

                outputItem.SetMetadata("OriginalItemSpec", sourceFile.ItemSpec);
                outputItem.SetMetadata("TargetPath", relativePath + ".zip");
                outputFiles.Add(outputItem);
            }

            foreach (var group in groupedSourceFiles)
            {
                var sourceFiles = group.ToArray();
                var entries = new List<(string SourcePath, string EntryName)>();

                foreach (var sourceFile in sourceFiles)
                {
                    var sourcePath = GetFullPath(sourceFile);

                    if (!File.Exists(sourcePath))
                    {
                        Log.LogError($"ZipEmbeddedResources source file does not exist: {sourcePath}");
                        return false;
                    }

                    entries.Add((sourcePath, ToZipEntryName(GetResourcePath(sourceFile))));
                }

                var outputPath = Path.Combine(outputRoot, "ZipEmbeddedResources", group.Key);
                CreateZip(outputPath, entries);

                var outputItem = new TaskItem(outputPath);
                foreach (DictionaryEntry metadata in sourceFiles[0].CloneCustomMetadata())
                {
                    outputItem.SetMetadata((string) metadata.Key, (string) metadata.Value);
                }

                outputItem.SetMetadata("OriginalItemSpec", string.Join(";", sourceFiles.Select(sourceFile => sourceFile.ItemSpec)));
                outputItem.SetMetadata("TargetPath", group.Key);
                outputFiles.Add(outputItem);
            }

            OutputFiles = outputFiles.ToArray();
            Log.LogMessage(MessageImportance.Low,
                $"Zipped {SourceFiles.Length} embedded resource file(s) into {OutputFiles.Length} zip file(s).");
            return true;
        }
        catch (Exception exception)
        {
            Log.LogErrorFromException(exception, true);
            return false;
        }
    }

    private static void CreateZip(string outputPath, IEnumerable<(string SourcePath, string EntryName)> entries)
    {
        var outputDirectory = Path.GetDirectoryName(outputPath);

        if (!string.IsNullOrEmpty(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        if (File.Exists(outputPath))
        {
            File.Delete(outputPath);
        }

        using var archive = ZipFile.Open(outputPath, ZipArchiveMode.Create);
        foreach (var (sourcePath, entryName) in entries)
        {
            archive.CreateEntryFromFile(sourcePath, entryName, CompressionLevel.Optimal);
        }
    }

    private static string GetResourcePath(ITaskItem item)
    {
        var link = item.GetMetadata("Link");
        if (!string.IsNullOrWhiteSpace(link))
        {
            return NormalizeProjectRelativePath(link);
        }

        var targetPath = item.GetMetadata("TargetPath");
        if (!string.IsNullOrWhiteSpace(targetPath))
        {
            return NormalizeProjectRelativePath(targetPath);
        }

        return NormalizeProjectRelativePath(item.GetMetadata("RelativeDir") + item.GetMetadata("Filename") +
                                            item.GetMetadata("Extension"));
    }

    private string GetFullPath(ITaskItem item)
    {
        var path = item.GetMetadata("FullPath");
        if (!string.IsNullOrWhiteSpace(path)) return path;

        return GetFullPath(item.ItemSpec, MSBuildProjectDirectory);
    }

    private static string GetFullPath(string path, string baseDirectory)
    {
        return Path.GetFullPath(Path.IsPathRooted(path) ? path : Path.Combine(baseDirectory, path));
    }

    private static string NormalizeProjectRelativePath(string path)
    {
        var normalized = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).TrimStart(Path.DirectorySeparatorChar);
        return normalized.StartsWith(".." + Path.DirectorySeparatorChar, StringComparison.Ordinal) ||
               normalized == ".."
            ? Path.GetFileName(normalized)
            : normalized;
    }

    private static string GetZipPath(string name)
    {
        var zipPath = NormalizeProjectRelativePath(name);
        return Path.GetExtension(zipPath).Equals(".zip", StringComparison.OrdinalIgnoreCase)
            ? zipPath
            : zipPath + ".zip";
    }

    private static string ToZipEntryName(string resourcePath) => resourcePath.Replace(Path.DirectorySeparatorChar, '/');
}
