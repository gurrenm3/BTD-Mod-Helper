namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Root command for generating source code files for mods
/// </summary>
public class GenerateCommand : ModCommand
{
    /// <inheritdoc />
    public override string Command => "generate";

    /// <inheritdoc />
    public override string Help => "Generates files for Mod Helper development";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}