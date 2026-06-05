using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.UI.Menus;
using CommandLine;

namespace BTD_Mod_Helper.Api.Commands.Open.Screen;

internal class OpenScreenSettingsCommand : ModCommand<OpenScreenCommand>
{
    public override string Command => "settings";

    public override string Help => "Opens the settings screen for a mod";

    [Value(0, Required = true, HelpText = "Mod to open settings screen for")]
    public string ModName { get; set; }

    private static Dictionary<string, MelonBase> Melons => field ??= MelonBase.RegisteredMelons
        .Where(melon => melon.IsUpdaterPlugin() || melon is BloonsMod bloonsMod && bloonsMod.ModSettings.Any())
        .ToDictionary(melon => melon.GetName().Replace(" ", ""));

    public override IEnumerable<string> SuggestionsForValue(int index) => index switch
    {
        0 => Melons.Keys,
        _ => base.SuggestionsForValue(index)
    };

    public override bool Execute(ref string resultText)
    {
        if (!Melons.TryGetValue(ModName, out var melon))
        {
            resultText = "Mod not found";
            return false;
        }

        var menu = GetInstance<ModSettingsMenu>();

        if (menu.IsOpen)
        {
            resultText = "Screen already opened";
            return false;
        }

        ModSettingsMenu.Open(melon);
        CloseConsole();
        return true;
    }
}