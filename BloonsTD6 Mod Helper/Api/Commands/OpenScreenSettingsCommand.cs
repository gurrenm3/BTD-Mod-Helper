using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Attributes;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.UI.Menus;

namespace BTD_Mod_Helper.Api.Commands;

internal class OpenScreenSettingsCommand : ModCommand<OpenScreenCommand>
{
    public override string Command => "settings";

    public override string Help => "Opens the settings screen for a mod";

    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);

    public override IEnumerable<ModContent> Load()
    {
        foreach (var content in base.Load())
        {
            yield return content;
        }

        foreach (var melon in MelonBase.RegisteredMelons)
        {
            if (melon.IsUpdaterPlugin() || melon is BloonsMod bloonsMod && bloonsMod.ModSettings.Any())
            {
                yield return new OpenScreenSettingsModCommand(melon);
            }
        }
    }

    [DontLoad]
    private class OpenScreenSettingsModCommand(MelonBase melon) : ModCommand<OpenScreenSettingsCommand>
    {
        public override string Command => melon.GetName().Replace(" ", "");

        public override string Help => $"Opens the settings screen for {melon.Info.Name}";

        public override bool Execute(ref string resultText)
        {
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
}