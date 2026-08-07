using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace BTD_Mod_Helper.Tools;

internal sealed class GitClient(string workingDirectory)
{
    public GitResult Run(params string[] arguments)
    {
        var startInfo = new ProcessStartInfo("git")
        {
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            StandardOutputEncoding = new UTF8Encoding(false),
            StandardErrorEncoding = new UTF8Encoding(false)
        };
        foreach (var argument in arguments) startInfo.ArgumentList.Add(argument);

        using var process = Process.Start(startInfo) ?? throw new InvalidOperationException("Unable to start git.");
        var stdoutTask = process.StandardOutput.ReadToEndAsync();
        var stderrTask = process.StandardError.ReadToEndAsync();
        process.WaitForExit();
        Task.WaitAll(stdoutTask, stderrTask);
        return new GitResult(process.ExitCode, stdoutTask.Result, stderrTask.Result.Trim());
    }

    public string Require(params string[] arguments)
    {
        var result = Run(arguments);
        if (!result.Success)
            throw new InvalidOperationException(string.IsNullOrEmpty(result.Error) ? "Git command failed." : result.Error);
        return result.Output;
    }
}

internal readonly record struct GitResult(int ExitCode, string Output, string Error)
{
    public bool Success => ExitCode == 0;
}
