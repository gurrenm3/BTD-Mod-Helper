using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.Commands;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.UI.Modded;
using CommandLine;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BTD_Mod_Helper.Api.Internal;

internal static class ConsoleHandler
{
    public static ModHelperConsole Console { get; private set; }

    public static RectTransform InGamePosition => PopupScreen.instance.popupPositions[1];
    public static RectTransform MenuPosition => PopupScreen.instance.popupPositions[3];

    public static bool ConsoleShowing { get; private set; }

    public static readonly List<Suggestion> CurrentSuggestions = [];

    private static int shiftTimer;

    public static void OnUpdate()
    {
        if (MelonMain.OpenConsole.JustPressed() && !ConsoleShowing && !ModHelperWindow.AnyWindowFocused)
        {
            ShowConsole();
        }

        if (MelonMain.ShiftShiftOpensConsole)
        {
            shiftTimer = Math.Max(0, shiftTimer - 1);
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                if (shiftTimer > 0)
                {
                    ToggleConsole();
                    shiftTimer = 0;
                }
                else
                {
                    shiftTimer = 15;
                }
            }
        }

        if (!ConsoleShowing) return;

        if (!Console.input.InputField.isFocused)
        {
            Console.input.InputField.ActivateInputField();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TryAutocomplete(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HistoryUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HistoryDown();
        }
    }

    public static readonly List<string> ConsoleHistory = [];
    public static int SpotInHistory { get; private set; } = -1;
    public static string HistoryStash { get; set; } = "";

    public static void HistoryUp()
    {
        if (SpotInHistory == -1)
        {
            HistoryStash = Console.Text;
        }
        SpotInHistory++;
        if (SpotInHistory >= ConsoleHistory.Count)
        {
            SpotInHistory = ConsoleHistory.Count - 1;
        }
        else
        {
            Console.Text = ConsoleHistory[SpotInHistory];
            Console.input.InputField.caretPosition = Console.Text.Length;
        }
    }

    public static void HistoryDown()
    {
        SpotInHistory--;
        if (SpotInHistory < -1)
        {
            SpotInHistory = -1;
        }
        if (SpotInHistory == -1)
        {
            Console.Text = HistoryStash;
        }
        else
        {
            Console.Text = ConsoleHistory[SpotInHistory];
            Console.input.InputField.caretPosition = Console.Text.Length;
        }
    }

    public static void ProcessEscape()
    {
        if (ConsoleShowing)
        {
            HideConsole();
        }
    }

    public static void ToggleConsole()
    {
        if (ConsoleShowing)
        {
            HideConsole();
        }
        else
        {
            ShowConsole();
        }
    }

    public static void ShowConsole()
    {
        if (PopupScreen.instance == null || ConsoleShowing) return;

        if (Console == null)
        {
            Console = ModHelperConsole.Create();
        }

        ConsoleShowing = true;
        Console.SetActive(true);

        Console.input.InputField.ActivateInputField();

        Console.SetParent(InGame.instance != null ? InGamePosition : MenuPosition);

        ClearConsole();
    }

    public static void HideConsole()
    {
        if (Console == null) return;

        ConsoleShowing = false;
        Console.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public static void ClearConsole()
    {
        SpotInHistory = -1;
        if (Console != null)
        {
            Console.Text = "";
            Console.Results = "";
        }
        UpdateSuggestions();
    }

    internal static readonly Color ErrorColor = Color.red;
    internal static readonly Color SuccessColor = Color.green;
    internal static readonly Color UnavailableColor = new(.7f, .7f, .7f);

    public static string Highlight(string text, string color) =>
        $"<color={color}>{text}</color>";

    public static void Highlight(ref string text, string color) => text = Highlight(text, color);

    public static string Highlight(string text, Color color) => Highlight(text,
        $"#{(int) (color.r * byte.MaxValue):x2}{(int) (color.g * byte.MaxValue):x2}{(int) (color.b * byte.MaxValue):x2}{(int) (color.a * byte.MaxValue):x2}");

    public static void Highlight(ref string text, Color color) => text = Highlight(text, color);

    public static string HighlightCommand(string text)
    {
        var tokens = text.SplitRespectingQuotes();

        if (tokens.Length == 0) return "";

        var command = tokens[0];

        if (ModCommand.RootCommands.TryGetValue(command, out var c))
        {
            Highlight(ref tokens[0], c.IsAvailable ? SuccessColor : UnavailableColor);

            for (var i = 1; i < tokens.Length; i++)
            {
                if (c.SubCommands.TryGetValue(tokens[i], out var sub))
                {
                    c = sub;
                    Highlight(ref tokens[i], c.IsAvailable ? SuccessColor : UnavailableColor);
                }
            }
        }
        else if (!ModCommand.RootCommands.Keys.Any(s => s.StartsWith(text)))
        {
            Highlight(ref tokens[0], ErrorColor);
        }

        return tokens.Join(delimiter: " ");
    }

    public static void ProcessCommand() => ProcessCommand(Console.Text);

    public static void ProcessCommand(string text) => ProcessCommand(text, new ModCommand.Output()).StartCoroutine();

    public static IEnumerator ProcessCommand(string text, ModCommand.Output output)
    {
        if (string.IsNullOrWhiteSpace(text)) yield break;
        SpotInHistory = -1;
        ConsoleHistory.Insert(0, text);

        Console?.input.InputField.SetText("");
        Console?.input.InputField.ForceLabelUpdate();
        Console?.Results = "Command in progress...";

        var tokens = text.SplitRespectingQuotes();

        var command = tokens[0];

        if (!ModCommand.RootCommands.TryGetValue(command, out var c))
        {
            ModHelper.Error("No Command Found");
            Console?.Results = Highlight("No Command Found", ErrorColor);
            yield break;
        }

        if (c.Parse(tokens[1..], out var parsedCommand, out var errors))
        {
            yield return ProcessCommand(parsedCommand, output);
        }
        else
        {
            if (Console?.Results == "Command in progress...")
            {
                Console.Results = "";
            }
            foreach (var error in errors)
            {
                ModHelper.Error(error);
                Console?.Results += Highlight(error.ToString(), ErrorColor) + "\n";
            }
        }
    }

    public static IEnumerator ProcessCommand(ModCommand command, ModCommand.Output output)
    {
        Console?.run.Button.interactable = false;
        Console?.input.InputField.interactable = false;

        var liveResults = LiveResults(output).StartCoroutine();

        yield return command.ExecuteInternal(output);

        MelonCoroutines.Stop(liveResults);

        Console?.Results = Highlight(output.resultText, output.success ? SuccessColor : ErrorColor);

        Console?.run.Button.interactable = false;
        Console?.input.InputField.interactable = true;
    }

    private static IEnumerator LiveResults(ModCommand.Output output)
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(output.resultText))
            {
                Console?.Results = output.resultText;
            }
            yield return null;
        }
        // ReSharper disable once IteratorNeverReturns
    }

    public static void UpdateSuggestions()
    {
        var text = Console.Text;
        var tokens = text.SplitRespectingQuotes();

        CurrentSuggestions.Clear();

        if (string.IsNullOrEmpty(text))
        {
            CurrentSuggestions.AddRange(
                ModCommand.RootCommands.Values
                    .OrderBy(command => command.Command)
                    .Select(command => command.Suggestion)
            );
        }
        else if (ModCommand.RootCommands.TryGetValue(tokens[0], out var c) &&
                 c.IsAvailable &&
                 text.Length > tokens[0].Length)
        {
            var consumed = 1;
            for (var i = 1; i < tokens.Length; i++)
            {
                if (c.SubCommands.TryGetValue(tokens[i], out var subCommand) &&
                    subCommand.IsAvailable &&
                    (text.EndsWith(" ") || i < tokens.Length - 1))
                {
                    c = subCommand;
                    consumed++;
                }
                else break;
            }

            CurrentSuggestions.AddRange(c.SubCommands.Values.Select(sub => sub.Suggestion));

            if (c.Values.Any())
            {
                var activeIndex = c.ActiveValueIndex(tokens[consumed..], text.EndsWith(" "));
                var valueRows = c.Values.OrderBy(v => v.Index).Select(SuggestionLine).ToList();

                var active = c.Values.ElementAtOrDefault(Math.Max(0, activeIndex));
                if (active != null)
                {
                    var extras = c.SuggestionsForValue(active.Index)
                        .Select(s => new Suggestion(s, "    - " + s, IsValueSuggestion: true));
                    var insertAt = Math.Min(Math.Max(0, activeIndex) + 1, valueRows.Count);
                    valueRows.InsertRange(insertAt, extras);
                }

                CurrentSuggestions.AddRange(valueRows);
            }

            CurrentSuggestions.AddRange(c.Options.OrderBy(o => o.LongName).Select(SuggestionLine));
        }
        else if (tokens.Length == 1)
        {
            CurrentSuggestions.AddRange(
                ModCommand.RootCommands.Values
                    .OrderBy(command => command.Command)
                    .Select(command => command.Suggestion)
            );
        }

        var exactMatch = tokens.Length > 0 &&
                         CurrentSuggestions.Any(s => s.Text == tokens.Last() || s.AltText == tokens.Last());
        if (!exactMatch && tokens.Length > 0 && !text.EndsWith(" "))
        {
            var last = tokens.Last();
            var valueMatch = new Regex(@"\b" + Regex.Escape(last), RegexOptions.IgnoreCase);
            CurrentSuggestions.RemoveAll(s =>
                !valueMatch.IsMatch(s.Text) && !(s.AltText != null && valueMatch.IsMatch(s.AltText)));
        }

        var valueSuggestions = CurrentSuggestions.Where(s => s.IsValueSuggestion).ToList();
        var lastToken = !text.EndsWith(" ") ? tokens.LastOrDefault() : null;
        var selected = lastToken == null ? -1 : valueSuggestions.FindIndex(s => s.Text == lastToken);

        var (start, end) = (0, valueSuggestions.Count);
        if (valueSuggestions.Count > ValueSuggestionDisplayLimit)
        {
            start = Math.Max(0, Math.Max(0, selected) - ValueSuggestionDisplayLimit / 2);
            end = Math.Min(valueSuggestions.Count, start + ValueSuggestionDisplayLimit);
            start = end - ValueSuggestionDisplayLimit;
        }

        var lines = new List<string>();
        var valueIdx = 0;
        var addedBefore = false;
        var addedAfter = false;
        foreach (var s in CurrentSuggestions)
        {
            if (s.IsValueSuggestion)
            {
                var i = valueIdx++;
                if (i < start)
                {
                    if (!addedBefore)
                    {
                        lines.Add("    - ...");
                        addedBefore = true;
                    }
                    continue;
                }
                if (i >= end)
                {
                    if (!addedAfter)
                    {
                        lines.Add("    - ...");
                        addedAfter = true;
                    }
                    continue;
                }
            }
            if (!string.IsNullOrEmpty(s.DisplayLine)) lines.Add(s.DisplayLine);
        }
        Console.Suggestions = lines.Join(delimiter: "\n");
    }

    public static void TryAutocomplete(bool invert = false)
    {
        var text = Console.Text;

        var tokens = text.Split(" ");

        var completions = CurrentSuggestions.Where(s => s.IsCompletion).ToList();
        if (completions.Count == 0) return;

        Suggestion desiredSuggestion;

        if (string.IsNullOrWhiteSpace(text))
        {
            desiredSuggestion = completions[0];
        }
        else
        {
            var currentSuggestion = completions.FirstOrDefault(suggestion =>
                !text.EndsWith(" ") && tokens.LastOrDefault() == suggestion.Text);

            if (currentSuggestion != null)
            {
                var index = completions.IndexOf(currentSuggestion);
                var next = invert ? index - 1 + completions.Count : index + 1;
                desiredSuggestion = completions[next % completions.Count];
            }
            else
            {
                var matcher = new Regex(@"\b" + Regex.Escape(tokens.Last()), RegexOptions.IgnoreCase);
                desiredSuggestion = completions.FirstOrDefault(s => matcher.IsMatch(s.Text));
            }
        }

        if (desiredSuggestion == null) return;

        if (string.IsNullOrWhiteSpace(Console.Text))
        {
            Console.Text = desiredSuggestion.Text;
        }
        else
        {
            var lastSpace = Console.Text.LastIndexOf(" ", StringComparison.Ordinal);

            Console.Text = lastSpace == -1
                ? desiredSuggestion.Text
                : Console.Text[..(lastSpace + 1)] + desiredSuggestion.Text;
        }

        Console.CaretPosition = Console.Text.Length;
    }

    public record Suggestion(string Text, string DisplayLine, string AltText = null, bool IsValueSuggestion = false)
    {
        public bool IsCompletion => !string.IsNullOrEmpty(Text);
    }

    private const int ValueSuggestionDisplayLimit = 5;

    public static Suggestion SuggestionLine(this OptionAttribute o) => new("--" + o.LongName,
        $"--{o.LongName}{(!string.IsNullOrEmpty(o.ShortName) ? ",-" + o.ShortName : "")} ({(o.Required ? "required" : "optional")})     {o.HelpText}",
        string.IsNullOrEmpty(o.ShortName) ? null : "-" + o.ShortName);

    public static Suggestion SuggestionLine(this ValueAttribute v) => new("",
        $"[{v.Index}] ({(v.Required ? "required" : "optional")})    {v.HelpText}");

    internal static bool Errors { get; set; }

    internal static bool FailFast { get; private set; }
    internal static bool QuitAfter { get; private set; }

    internal static IEnumerator RunCommandsFromArgs()
    {
        var args = Environment.GetCommandLineArgs();
        var modHelper = args.IndexOf("--modhelper.run");
        if (modHelper < 0) yield break;

        var remaining = args.Skip(modHelper + 1).ToArray();

        var commandStart = 0;
        while (commandStart < remaining.Length &&
               remaining[commandStart].Length > 1 &&
               remaining[commandStart][0] == '-' &&
               remaining[commandStart].Skip(1).All(char.IsLetter))
        {
            foreach (var c in remaining[commandStart][1..])
            {
                switch (c)
                {
                    case 'e': FailFast = true; break;
                    case 'q': QuitAfter = true; break;
                }
            }
            commandStart++;
        }

        var fails = 0;

        foreach (var command in remaining.Skip(commandStart).Join(delimiter: " ").Split(" && "))
        {
            Errors = false;
            var output = new ModCommand.Output();
            yield return ProcessCommand(command, output);

            if (output.success)
            {
                ModHelper.Msg(output.resultText);
            }
            else
            {
                ModHelper.Error(output.resultText);
            }

            if (output.success && !Errors) continue;

            fails++;

            if (!FailFast) continue;

            Application.Quit(1);
            yield break;
        }

        if (QuitAfter)
        {
            Application.Quit(fails);
        }
    }

    private const int STD_INPUT_HANDLE = -10;

    private const uint ENABLE_PROCESSED_INPUT = 0x0001;
    private const uint ENABLE_LINE_INPUT = 0x0002;
    private const uint ENABLE_ECHO_INPUT = 0x0004;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    internal static void SetupMelonConsole()
    {
        if (!MelonMain.UnlockConsoleInput && !Application.isBatchMode) return;

        var consoleHandle = GetStdHandle(STD_INPUT_HANDLE);
        if (GetConsoleMode(consoleHandle, out var consoleMode))
        {
            consoleMode |= ENABLE_PROCESSED_INPUT | ENABLE_LINE_INPUT | ENABLE_ECHO_INPUT;
            SetConsoleMode(consoleHandle, consoleMode);

            ModHelper.Msg("MelonLoader console input unlocked. You can type stuff here now!");
        }
        else return;

        Task.Run(() =>
        {
            while (true)
            {
                try
                {
                    var input = System.Console.ReadLine();

                    TaskScheduler.ScheduleTask(() => ProcessCommand(input));
                }
                catch (Exception ex)
                {
                    ModHelper.Error($"Console Reader Error: {ex.Message}");
                }
            }
            // ReSharper disable once FunctionNeverReturns
        });
    }

}