namespace BTD_Mod_Helper.Api.Commands.Open;

/// <summary>
/// Opens specific folders within file explorer
/// </summary>
public sealed class OpenFolderCommand : ModCommand<OpenCommand>
{
    /// <inheritdoc />
    public override string Command => "folder";

    /// <inheritdoc />
    public override string Help => "Opens specific folders within file explorer";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}