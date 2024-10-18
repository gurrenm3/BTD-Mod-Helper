namespace BTD_Mod_Helper.Api.Commands;

/// <summary>
/// Root command for exporting information to files
/// </summary>
public sealed class ExportCommand : ModCommand
{
    /// <inheritdoc />
    public override string Command => "export";

    /// <inheritdoc />
    public override string Help => "Export data to files";

    /// <inheritdoc />
    public override bool Execute(ref string resultText) => ExplainSubcommands(out resultText);
}