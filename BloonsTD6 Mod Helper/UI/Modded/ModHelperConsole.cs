using System;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Internal;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.Modded;

[RegisterTypeInIl2Cpp(false)]
internal class ModHelperConsole : ModHelperComponent
{
    // public ModHelperPanel panel;
    public ModHelperInputField input;
    public ModHelperText text;

    public ModHelperText suggestions;
    public ModHelperText results;

    public ModHelperImage clickBlocker;

    public ModHelperButton close;
    public ModHelperButton run;

    public string Text
    {
        get => input.InputField.text;
        set => input.InputField.SetText(value);
    }

    public string Suggestions
    {
        get => suggestions.Text.text;
        set => suggestions.SetText(value);
    }

    public string Results
    {
        get => results.Text.text;
        set => results.SetText(value);
    }

    public int CaretPosition
    {
        get => input.InputField.caretPosition;
        set => input.InputField.caretPosition = value;
    }

    /// <inheritdoc />
    public ModHelperConsole(IntPtr ptr) : base(ptr)
    {

    }

    public static ModHelperConsole Create()
    {
        var console = ModHelperComponent.Create<ModHelperConsole>(new Info("ModHelperConsole", 2000, 500)
        {
            Y = 100,
            Pivot = new Vector2(0.5f, 0)
        });

        console.clickBlocker = console.AddImage(new Info("BlockClicks", 10000, 10000), "");
        console.clickBlocker.Image.color = new Color(0, 0, 0, 0.5f);
        console.clickBlocker.AddComponent<Text>();

        console.input = console.AddInputField(new Info("Input")
        {
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 0),
            Height = 100
        }, "", VanillaSprites.BlueInsertPanel, new Action<string>(s =>
        {
            console.text.SetText(ConsoleHandler.HighlightCommand(s));
            ConsoleHandler.UpdateSuggestions();
        }), 52f, TMP_InputField.CharacterValidation.None, TextAlignmentOptions.Left, null, 25);

        console.input.InputField.onSubmit.AddListener(new Action<string>(s =>
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ConsoleHandler.ProcessCommand(s);
            }
        }));
        console.input.InputField.caretColor = Color.white;
        console.input.InputField.customCaretColor = true;

        console.input.Text.Text.AutoLocalize = false;
        console.input.Text.Text.font = Fonts.Inconsolata;

        console.text = console.input.Text.Duplicate(console.input.Text.parent);
        console.text.Text.AutoLocalize = false;
        console.input.Text.Text.color = new Color(0, 0, 0, 0);

        console.suggestions = console.AddText(new Info("Suggestions")
        {
            Y = 100,
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 0),
            Height = 2000
        }, "", 52f, TextAlignmentOptions.BottomLeft);
        console.suggestions.Text.font = Fonts.Inconsolata;
        console.suggestions.Text.AutoLocalize = false;

        console.results = console.AddText(new Info("Results")
        {
            Y = -100,
            AnchorMin = new Vector2(0, 0),
            AnchorMax = new Vector2(1, 0),
            Pivot = new Vector2(0.5f, 1),
            Height = 500
        }, "", 52f, TextAlignmentOptions.TopLeft);
        console.results.Text.font = Fonts.Inconsolata;
        console.results.Text.AutoLocalize = false;

        console.close = console.AddButton(new Info("Close", 100)
        {
            X = -100,
            Anchor = new Vector2(0, 0)
        }, VanillaSprites.CloseBtn, new Action(ConsoleHandler.HideConsole));

        console.run = console.AddButton(new Info("Run", 100)
        {
            X = 100,
            Anchor = new Vector2(1, 0)
        }, VanillaSprites.ContinueBtn, new Action(ConsoleHandler.ProcessCommand));

        return console;
    }

}