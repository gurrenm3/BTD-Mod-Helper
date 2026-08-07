extern alias SourceGenerators;

using System;
using System.IO;
using Xunit;
using ActionsWorkflowGenerator =
    SourceGenerators::BTD_Mod_Helper.SourceGenerators.ActionsWorkflowGenerator;

namespace BTD_Mod_Helper.SourceGenerators.Tests;

public sealed class ActionsWorkflowGeneratorTests : IDisposable
{
    private const string OwnerMarker =
        "# This workflow file is automatically updated by Mod Helper via btd6.targets";
    private readonly string directory = Path.Combine(Path.GetTempPath(), "btd6-mod-helper-generator-tests",
        Guid.NewGuid().ToString("N"));

    [Fact]
    public void UpdatesOnlyExistingManagedWorkflow()
    {
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "build.yml");
        File.WriteAllText(path, OwnerMarker + "\nold\n");

        ActionsWorkflowGenerator.UpdateWorkflow(path, OwnerMarker + "\nnew\n");

        Assert.Equal(OwnerMarker + "\nnew\n", File.ReadAllText(path));
    }

    [Fact]
    public void PreservesCustomizedOrDeletedWorkflow()
    {
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "build.yml");
        File.WriteAllText(path, "# Custom workflow\n");

        ActionsWorkflowGenerator.UpdateWorkflow(path, OwnerMarker + "\nnew\n");
        Assert.Equal("# Custom workflow\n", File.ReadAllText(path));

        File.Delete(path);
        ActionsWorkflowGenerator.UpdateWorkflow(path, OwnerMarker + "\nnew\n");
        Assert.False(File.Exists(path));
    }

    public void Dispose()
    {
        if (Directory.Exists(directory)) Directory.Delete(directory, true);
    }
}
