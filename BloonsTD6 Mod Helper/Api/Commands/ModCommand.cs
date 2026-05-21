using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Internal;
using CommandLine;

namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Defines a command that can be run from within the Mod Helper developer console
/// </summary>
public abstract class ModCommand : ModContent
{
    internal static readonly Parser Parser = new(settings =>
    {
        settings.HelpWriter = null;
        settings.IgnoreUnknownArguments = false;
    });

    internal static readonly Dictionary<string, ModCommand> AllCommands = new();
    internal static readonly Dictionary<string, ModCommand> RootCommands = new();

    /// <summary>
    /// List of Sub-commands that this command has
    /// </summary>
    public readonly Dictionary<string, ModCommand> SubCommands = new();

    /// <summary>
    /// Other ModCommand that this is nested under, or null if a root command
    /// </summary>
    public virtual ModCommand ParentCommand { get; }

    /// <summary>
    /// The string name of this command
    /// </summary>
    public abstract string Command { get; }

    /// <summary>
    /// Short text description of this command
    /// </summary>
    public abstract string Help { get; }

    /// <summary>
    /// Whether the command is available to users
    /// </summary>
    public virtual bool IsAvailable => true;

    internal bool Available
    {
        get
        {
            try
            {
                return IsAvailable;
            }
            catch (Exception e)
            {
                ModHelper.Warning(e);
                return false;
            }
        }
    }

    /// <summary>
    /// Line of text that appears as a suggestion
    /// </summary>
    public string SuggestionLine =>
        new(ConsoleHandler.Highlight(Command, Available ? ConsoleHandler.SuccessColor : ConsoleHandler.UnavailableColor) +
            " - " +
            Help);

    internal ConsoleHandler.Suggestion Suggestion => new(Command, SuggestionLine);

    /// <summary>
    /// Optional arguments for this command
    /// </summary>
    public IEnumerable<OptionAttribute> Options => GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Select(p => p.GetCustomAttribute<OptionAttribute>())
        .Where(s => s != null);

    /// <summary>
    /// Positional values for this command
    /// </summary>
    public IEnumerable<ValueAttribute> Values => GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Select(p => p.GetCustomAttribute<ValueAttribute>())
        .Where(s => s != null);

    /// <inheritdoc />
    public override void Register()
    {
        AllCommands[Id] = this;
        var commands = ParentCommand?.SubCommands ?? RootCommands;

        if (commands.ContainsKey(Command))
        {
            mod.LoadError($"Command {Command} already registered");
        }
        else
        {
            commands[Command] = this;
        }
    }

    /// <summary>
    /// Runs this command
    /// </summary>
    /// <returns>Whether this command successfully executed</returns>
    public virtual bool Execute(ref string resultText)
    {
        return true;
    }

    /// <summary>
    /// Class that represents the output of a ModCommand execution. This gets passed by reference between Coroutines
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Whether the command has succeeded. True by default; users will need to actively specify a failure.
        /// </summary>
        public bool success;

        /// <summary>
        /// Custom result text to display to the user, if not null
        /// </summary>
        public string resultText;

        /// <summary>
        /// Exception that caused the command to fail, if any
        /// </summary>
        public Exception exception;
    }

    /// <summary>
    /// Runs this command as a coroutine
    /// </summary>
    /// <param name="output">Output object to modify with success, result text, exception</param>
    public virtual IEnumerator Execute(Output output)
    {
        try
        {
            output.success = Execute(ref output.resultText);
        }
        catch (Exception e)
        {
            output.exception = e;
        }
        yield break;
    }


    /// <summary>
    /// Fails the command and displays which subbcommands are available to the user
    /// </summary>
    /// <param name="resultText"></param>
    /// <returns></returns>
    protected bool ExplainSubcommands(out string resultText)
    {
        var subCommands = SubCommands.Values.Where(command => command.Available).ToArray();
        if (subCommands.Any())
        {
            resultText = "Available Subcommands: " + subCommands.Select(s => s.Command).Join(delimiter: ", ");
        }
        else
        {
            resultText = "No Sub Commands Available";
        }

        return false;
    }

    internal IEnumerator ExecuteInternal(Output output)
    {
        if (!Available)
        {
            output.success = false;
            output.resultText = "Command not available";
            yield break;
        }

        output.success = true; // If user doesn't specify otherwise, assume success
        yield return Execute(output);

        output.resultText ??= output.success ? "Command succeeded." : "Command failed.";

        if (output.exception != null)
        {
            ModHelper.Error(output.exception);
        }
    }

    /// <summary>
    /// Closes the command console
    /// </summary>
    protected static void CloseConsole() => ConsoleHandler.HideConsole();

    internal bool Parse(string[] args, out ModCommand parsedCommand, out Error[] errors)
    {
        if (args.Length > 0 && SubCommands.TryGetValue(args[0], out var subCommand))
        {
            return subCommand.Parse(args[1..], out parsedCommand, out errors);
        }

        var success = false;

        var cmd = this;
        var errs = Array.Empty<Error>();

        Parser.ParseArguments(() => this, args).WithParsed(parsed =>
        {
            cmd = parsed;
            success = true;
        }).WithNotParsed(errors =>
        {
            errs = errors.ToArray();
        });

        parsedCommand = cmd;
        errors = errs;

        return success;
    }
}

/// <summary>
/// Defines a ModCommand that is a subcommand of the specified other command
/// </summary>
/// <typeparam name="T">The root command this is a sub command of</typeparam>
public abstract class ModCommand<T> : ModCommand where T : ModCommand
{
    /// <inheritdoc />
    public sealed override ModCommand ParentCommand => GetInstance<T>();
}