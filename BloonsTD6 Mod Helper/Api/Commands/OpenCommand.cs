namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Commands for opening specific files / folders
/// </summary>
public sealed class OpenCommand : ModCommand
{
    /// <inheritdoc />
    public override string Command => "open";

    /// <inheritdoc />
    public override string Help => "Open specific files / folders / menus";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}