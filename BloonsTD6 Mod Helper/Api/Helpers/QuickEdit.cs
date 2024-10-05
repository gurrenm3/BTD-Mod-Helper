using System;
using System.Diagnostics;
using System.IO;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Utility for allowing the user to quickly edit some input in an external program
/// </summary>
public static class QuickEdit
{
    /// <summary>
    /// Prompts the user to edit some text in their selected external program
    /// </summary>
    /// <param name="text">Original text</param>
    /// <param name="fileName">Name for temporary file</param>
    /// <param name="deleteAfter">Whether to try deleting the file when edits conclude</param>
    /// <returns>The edited text</returns>
    public static string EditText(string text, string fileName, bool deleteAfter = true)
    {
        FileIOHelper.SaveFile(fileName, text);

        var path = Path.Combine(FileIOHelper.sandboxRoot, fileName);

        var linux = MelonUtils.IsUnderWineOrSteamProton();

        var command = linux ? "nano" : "notepad";

        if (!string.IsNullOrWhiteSpace(MelonMain.QuickEditProgram))
        {
            command = MelonMain.QuickEditProgram;
        }

        var process = Process.Start(new ProcessStartInfo
        {
            FileName = linux ? "sh" : "cmd.exe",
            Arguments = $"{(linux ? "-c" : "/C")} {command} \"{path}\"",
            CreateNoWindow = command == "nano",
            WindowStyle = command == "nano" ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden,
            UseShellExecute = true,
        });

        if (process == null)
        {
            ModHelper.Warning("Failed to start process");
            return text;
        }

        process.WaitForExit();

        var result = FileIOHelper.LoadFile(fileName);

        if (deleteAfter)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
            }
        }

        return result;
    }
}