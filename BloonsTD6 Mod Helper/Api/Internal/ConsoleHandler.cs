using System;
using System.Collections.Generic;
using System.Linq;
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

    public static void ProcessCommand(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        ConsoleHistory.Insert(0, text);
        Console.input.InputField.SetText("");
        Console.input.InputField.ForceLabelUpdate();
        Console.Results = "";

        var tokens = text.SplitRespectingQuotes();

        var command = tokens[0];

        if (ModCommand.RootCommands.TryGetValue(command, out var c))
        {
            if (c.Parse(tokens[1..], out var parsedCommand, out var errors))
            {
                var success = parsedCommand.ExecuteInternal(out var resultText);
                Highlight(ref resultText, success ? SuccessColor : ErrorColor);
                Console.Results = resultText;
            }
            else
            {
                foreach (var error in errors)
                {
                    ModHelper.Error(error);
                    Console.Results += Highlight(error.ToString(), ErrorColor);
                }
            }
        }
        else
        {
            Console.Results = Highlight("No Command Found", ErrorColor);
        }
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
            for (var i = 1; i < tokens.Length; i++)
            {
                if (c.SubCommands.TryGetValue(tokens[i], out var subCommand) &&
                    subCommand.IsAvailable &&
                    (text.EndsWith(" ") || i < tokens.Length - 1))
                {
                    c = subCommand;
                }
                else break;
            }
            CurrentSuggestions.AddRange(c.SubCommands.Values.Select(sub => sub.Suggestion));
            CurrentSuggestions.AddRange(c.Values.OrderBy(v => v.Index).Select(SuggestionLine));
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
            CurrentSuggestions.RemoveAll(s =>
                !s.Text.StartsWith(tokens.Last()) && !(s.AltText != null && s.AltText.StartsWith(tokens.Last())));
        }

        Console.Suggestions = CurrentSuggestions.Select(suggestion => suggestion.SuggestionLine).Join(delimiter: "\n");
    }

    public static void TryAutocomplete(bool invert = false)
    {
        var text = Console.Text;

        var tokens = text.Split(" ");

        if (CurrentSuggestions.Count == 0) return;

        Suggestion desiredSuggestion;

        if (string.IsNullOrWhiteSpace(text))
        {
            desiredSuggestion = CurrentSuggestions.FirstOrDefault();
        }
        else
        {
            var currentSuggestion = CurrentSuggestions.FirstOrDefault(suggestion =>
                !text.EndsWith(" ") && tokens.LastOrDefault() == suggestion.Text);

            if (currentSuggestion != null)
            {
                var index = CurrentSuggestions.IndexOf(currentSuggestion);
                desiredSuggestion = CurrentSuggestions[(invert ? index - 1 : index + 1) % CurrentSuggestions.Count];
            }
            else
            {
                desiredSuggestion = CurrentSuggestions.FirstOrDefault(suggestion =>
                    !string.IsNullOrEmpty(suggestion.Text) &&
                    (string.IsNullOrEmpty(text) || suggestion.Text.StartsWith(tokens.Last())));
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

    public record Suggestion(string Text, string SuggestionLine, string AltText = null)
    {
    }

    public static Suggestion SuggestionLine(this OptionAttribute o) => new("--" + o.LongName,
        $"--{o.LongName}{(!string.IsNullOrEmpty(o.ShortName) ? ",-" + o.ShortName : "")} ({(o.Required ? "required" : "optional")})     {o.HelpText}",
        string.IsNullOrEmpty(o.ShortName) ? null : "-" + o.ShortName);

    public static Suggestion SuggestionLine(this ValueAttribute v) => new("",
        $"[{v.Index}] ({(v.Required ? "required" : "optional")})    {v.HelpText}");
}